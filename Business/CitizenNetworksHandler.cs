using Npgsql;
using System.Data.Common;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Infraestructure;

namespace Business
{
	public static class CitizenNetworksHandler
	{
		public static Error GetCitizenNetworkById(int id, out TCitizenNetwork citizen_network)
		{
			var conn = ConnectionPool.GetConnection();

			Error error = 0;

			citizen_network = new TCitizenNetwork();

			using (var cmd = new NpgsqlCommand("", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				// query the general info
				cmd.CommandText = "SELECT * FROM citizennetworks WHERE id = @id;";

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						citizen_network.FillFromReader(reader);

						if (error == 0 && citizen_network.LeadCitizen.Id != 0)
						{
							error = CitizensHandler.GetCitizenById(citizen_network.LeadCitizen.Id, out citizen_network.LeadCitizen);
						}
					}
					else
					{
						error = Error.CitizenNetworkNotFound;
					}
				}

				// query the roles
				cmd.CommandText = "SELECT * FROM citizennetwork_roles WHERE citizennetwork_id = @id ORDER BY nivel;";

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TCitizenNetworkRole role = new TCitizenNetworkRole();

						role.FillFromReader(reader);

						citizen_network.Roles.Add(role);
					}
				}

				// query the members
				cmd.CommandText = @"
					SELECT 
						m.*, 
						r.id AS role_id, 
						r.name AS role_name,
						r.nivel AS role_level
					FROM 
						citizennetwork_citizens m 
						LEFT JOIN citizennetwork_roles r ON m.citizennetwork_citizen_role_id = r.id 
					WHERE m.citizennetwork_id = @id;";

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TCitizenNetworkMember member = new TCitizenNetworkMember();

						member.FillFromReader(reader);

						if (member.Citizen.Id != 0)
						{
							error = CitizensHandler.GetCitizenById(member.Citizen.Id, out member.Citizen);
						}

						member.Role.Id = reader.GetInt32(reader.GetOrdinal("role_id"));
						member.Role.Name = reader.GetString(reader.GetOrdinal("role_name"));
						member.Role.Level = reader.GetInt32(reader.GetOrdinal("role_level"));

						citizen_network.Members.Add(member);
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetCitizenNetworks(out List<TCitizenNetwork> citizen_networks_list)
		{
			var conn = ConnectionPool.GetConnection();

			citizen_networks_list = new List<TCitizenNetwork>();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizennetworks;", conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while (reader.Read())
				{
					TCitizenNetwork network = new TCitizenNetwork();

					network.FillFromReader(reader);

					citizen_networks_list.Add(network);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error SaveCitizenNetwork(TCitizenNetwork citizen_network, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			var tran = conn.BeginTransaction();

			Error error = 0;

			using (var cmd = new NpgsqlCommand("", conn))
			{
				// save general info
				cmd.Parameters.AddWithValue("@id", citizen_network.Id);
				cmd.Parameters.AddWithValue("@lead_citizen_id", citizen_network.LeadCitizen.Id);
				cmd.Parameters.AddWithValue("@parent_network_id", citizen_network.ParentNetworkId);
				cmd.Parameters.AddWithValue("@name", citizen_network.Name);
				cmd.Parameters.AddWithValue("@description", citizen_network.Description);	

				if (is_update)
				{
					cmd.CommandText = @"
						UPDATE citizennetworks 
						SET 
							lead_citizen_id=@lead_citizen_id, 
							parent_network_id=@parent_network_id, 
							name=@name, 
							description=@description
						WHERE 
							id=@id;";

					cmd.ExecuteNonQuery();
				}
				else
				{
					cmd.CommandText = @"
						INSERT INTO citizennetworks(
							lead_citizen_id,
							parent_network_id,
							name,
							description)
						VALUES(
							@lead_citizen_id,
							@parent_network_id,
							@name,
							@description)
						RETURNING id;";

					citizen_network.Id = (Int32)(Int64)cmd.ExecuteScalar();
				}

				// save roles
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
				cmd.CommandText = "DELETE FROM citizennetwork_roles WHERE citizennetwork_id = @citizennetwork_id";
				cmd.ExecuteNonQuery();

				cmd.CommandText = @"
					INSERT INTO citizennetwork_roles(
						citizennetwork_id,
						name,
						description,
						nivel)
					VALUES(
						@citizennetwork_id,
						@name,
						@description,
						@nivel)
					RETURNING id;
				";

				foreach (TCitizenNetworkRole role in citizen_network.Roles)
				{
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
					cmd.Parameters.AddWithValue("@name", role.Name);
					cmd.Parameters.AddWithValue("@description", role.Description);
					cmd.Parameters.AddWithValue("@nivel", role.Level);

					int new_role_id = (Int32)(Int64)cmd.ExecuteScalar();

					// ugly... here we assign the correct (generated by postrgress db) id for the role
					foreach (TCitizenNetworkMember member in citizen_network.Members)
					{
						if (member.Role.Id == role.Id)
						{
							member.Role.Id = new_role_id;	
						}
					}

					role.Id = new_role_id;
				}

				// save members
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
				cmd.CommandText = "DELETE FROM citizennetwork_citizens WHERE citizennetwork_id = @citizennetwork_id";
				cmd.ExecuteNonQuery();

				cmd.CommandText = @"
					INSERT INTO citizennetwork_citizens(
						citizennetwork_id, 
						citizen_id, 
						citizennetwork_citizen_role_id,
						parent_member_id)
					VALUES(
						@citizennetwork_id,
						@citizen_id,
						@citizennetwork_citizen_role_id,
						@parent_member_id)
					RETURNING id;";

				// uglier, all that follows is because we dont know the ids until they are assigned, so similar to the roles,
				// we need to replace the records relationship little by litte
				// really tried to find another way to do this but couldn't find it :s

				// first, pre-sort the member list so that members with parent_member_id = 0 are asigned first, as we dont have to know the id when initialy creating them
				citizen_network.Members = citizen_network.Members.OrderBy(m => m.ParentMemberId).ToList();

				// then, save the original ids so that when the correction for the right ids happen we don't worry about overlaping ids
				List<int> original_parent_member_ids = citizen_network.Members.Select(m => m.ParentMemberId).ToList();

				for (int i = 0; i < citizen_network.Members.Count(); i++)
				{
					TCitizenNetworkMember member = citizen_network.Members[i];

					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
					cmd.Parameters.AddWithValue("@citizen_id", member.Citizen.Id);
					cmd.Parameters.AddWithValue("@citizennetwork_citizen_role_id", member.Role.Id);
					cmd.Parameters.AddWithValue("@parent_member_id", member.ParentMemberId);

					int new_member_id = (Int32)(Int64)cmd.ExecuteScalar();

					// finally the actual fix happens
					for (int j = 0; j < citizen_network.Members.Count(); j++)
					{
						TCitizenNetworkMember member_to_fix = citizen_network.Members[j];

						if (original_parent_member_ids[j] == member.Id)
						{
							member_to_fix.ParentMemberId = new_member_id;
						}
					}

					member.Id = new_member_id;
				}
			}

			tran.Commit();

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}
	}
}
