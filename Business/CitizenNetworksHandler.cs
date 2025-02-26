using Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public class TCitizenNetwork
	{
		public int Id;
		public TCitizen LeadCitizen;
		public int ParentNetworkId;
		public string Name;
		public string Description;
		public List<TCitizenNetworkMember> Members;
		public List<TCitizenNetworkRole> Roles;

		public TCitizenNetwork()
		{
			LeadCitizen = new TCitizen();
			Members = new List<TCitizenNetworkMember>();
			Roles = new List<TCitizenNetworkRole>();
		}

		public void FillFromReader(DbDataReader reader)
		{
			LeadCitizen = new TCitizen();
			Members = new List<TCitizenNetworkMember>();
			Roles = new List<TCitizenNetworkRole>();
		}
	}

	public class TCitizenNetworkMember
	{
		public int Id;
		public int CitizenNetworkId;
		public TCitizen Citizen;
		public int ParentMemberId;
		public TCitizenNetworkRole Role;

		public TCitizenNetworkMember()
		{
			Citizen = new TCitizen();
			Role = new TCitizenNetworkRole();
		}

		public void FillFromReader(DbDataReader reader)
		{
			Citizen = new TCitizen();
			Role = new TCitizenNetworkRole();

			Id = reader.GetInt32(0);
			CitizenNetworkId = reader.GetInt32(1);
			Citizen.Id = reader.GetInt32(2);
			Role.Id = reader.GetInt32(3);
		}
	}

	public class TCitizenNetworkRole
	{
		public int Id;
		public int CitizenNetworkId;	
		public string Name;	

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			CitizenNetworkId = reader.GetInt32(2);
		}
	}

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
				cmd.CommandText = "SELECT * FROM citizennetwork_roles WHERE citizennetwork_id = @id;";

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
				cmd.CommandText = "SELECT * FROM citizennetwork_citizens WHERE citizennetwork_id = @id;";

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TCitizenNetworkMember member = new TCitizenNetworkMember();

						member.FillFromReader(reader);

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

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizen_networks;", conn))
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

				// save members
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
				cmd.CommandText = "DELETE * FROM citizennetwork_citizens WHERE citizennetwork_id = @citizennetwork_id";
				cmd.ExecuteNonQuery();

				cmd.CommandText = @"
					INSERT INTO citizennetwork_citizens(
						citizennetwork_id, 
						citizen_id, 
						citizennetwork_role_id)
					VALUES(
						@citizennetwork_id,
						@citizen_id,
						@citizennetwork_role_id)";

				foreach (TCitizenNetworkMember member in citizen_network.Members)
				{
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
					cmd.Parameters.AddWithValue("@citizen_id", member.Citizen.Id);
					cmd.Parameters.AddWithValue("@citizennetwork_role_id", member.Role.Id);

					cmd.ExecuteNonQuery();
				}

				// save roles
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
				cmd.CommandText = "DELETE * FROM citizennetwork_roles WHERE citizennetwork_id = @citizennetwork_id";
				cmd.ExecuteNonQuery();

				cmd.CommandText = @"
					INSERT INTO citizennetwork_roles(
						citizennetwork_id,
						name)
					VALUES(
						@citizennetwork_id,
						@name);
				";

				foreach (TCitizenNetworkRole role in citizen_network.Roles)
				{
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@citizennetwork_id", citizen_network.Id);
					cmd.Parameters.AddWithValue("@name", role.Name);

					cmd.ExecuteNonQuery();
				}
			}

			tran.Commit();

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}
	}
}
