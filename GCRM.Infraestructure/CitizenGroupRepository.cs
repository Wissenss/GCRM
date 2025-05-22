using GCRM.Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Infraestructure
{
	public class CitizenGroupRepository : IRepository<TCitizenGroup>
	{
		public UnitOfWork UOW { get; set; }

		public CitizenGroupRepository(UnitOfWork uow)
		{
			UOW = uow;
		}

		public TCitizenGroup? GetById(int id)
		{
			TCitizenGroup? group = null;

			using (var cmd = UOW.connection.CreateCommand())
			{
				cmd.CommandText = "SELECT * FROM citizen_groups WHERE id = @id;";
				cmd.Parameters.AddWithValue("id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						group = new TCitizenGroup();

						group.Id = reader.GetInt32("id");
						group.Name = reader.GetString("name");
						group.Description = reader.GetString("description");
					}
					else
					{
						return null;
					}
				}
			}

			return group;
		}

		public IEnumerable<TCitizen> GetMembers(int id)
		{
			List<TCitizen> members = new List<TCitizen>();

			using (var cmd = UOW.connection.CreateCommand())
			{
				cmd.CommandText = @"
					SELECT 
						cgc.*,
						c.name AS citizen_name,
						c.paternal_name AS citizen_paternal_name,
						c.maternal_name AS citizen_maternal_name
					FROM 
						citizen_group_citizens cgc
						LEFT JOIN citizens c ON cgc.citizen_id = c.id
					WHERE 
						group_id = @id;";

				cmd.Parameters.AddWithValue("id", id);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TCitizen member = new TCitizen();

						member.Id = reader.GetInt32("citizen_id");
						member.Name = reader.GetString("citizen_name");
						member.PaternalName = reader.GetString("citizen_paternal_name");
						member.MaternalName = reader.GetString("citizen_maternal_name");

						members.Add(member);
					}
				}
			}

			return members;
		}

		public TCitizenGroup? GetByIdWithMembers(int id)
		{
			TCitizenGroup? group = GetById(id);

			if (group != null)
				group.Members = GetMembers(group.Id).ToList();

			return group;
		}

		public IEnumerable<TCitizenGroup> GetAll()
		{
			List<TCitizenGroup> all = new List<TCitizenGroup>();

			string sql = @"
				SELECT
					cg.*
				FROM citizen_groups cg
			";

			using (var cmd = UOW.connection.CreateCommand())
			{
				cmd.CommandText = sql;

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TCitizenGroup group = new TCitizenGroup()
						{
							Id = reader.GetInt32("id"),
							Name = reader.GetString("name"),
							Description = reader.GetString("description"),
						};

						all.Add(group);
					}
				}
			}

			return all;
		}

		public int Add(TCitizenGroup group)
		{
			string sql = @"
				INSERT INTO citizen_groups(name, description)
				VALUES(@name, @description)
				RETURNING id;
			";

			using (var cmd = UOW.connection.CreateCommand())
			{
				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@name", group.Name);
				cmd.Parameters.AddWithValue("@description", group.Description);

				int id = (Int32)(Int64)cmd.ExecuteScalar();

				return id;
			}
		}

		public void AddMembers(int id, IEnumerable<TCitizen> members)
		{
			using (var batch = UOW.connection.CreateBatch())
			{
				foreach (var member in members)
				{
					var cmd = new NpgsqlBatchCommand("INSERT INTO citizen_group_citizens(group_id, citizen_id) VALUES(@group_id, @citizen_id);");

					cmd.Parameters.AddWithValue("group_id", id);
					cmd.Parameters.AddWithValue("citizen_id", member.Id);

					batch.BatchCommands.Add(cmd);
				}

				batch.ExecuteNonQuery();
			}
		}

		public void Update(TCitizenGroup group)
		{
			string sql = @"
				UPDATE citizen_groups SET
					name = @name,
					description = @description
				WHERE id = @id;
			";

			using (var cmd = UOW.connection.CreateCommand())
			{
				cmd.CommandText = sql;
				
				cmd.Parameters.AddWithValue("@id", group.Id);
				cmd.Parameters.AddWithValue("@name", group.Name);
				cmd.Parameters.AddWithValue("@description", group.Description);

				cmd.ExecuteNonQuery();
			}
		}

		public void Delete(int id)
		{
			string sql = "DELETE FROM citizen_groups WHERE id = @id";

			using (var cmd = UOW.connection.CreateCommand())
			{
				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();
			}
		}
	
		public void DeleteMembers(int id)
		{
			string sql = "DELETE FROM citizen_group_citizens WHERE group_id = @id";

			using (var cmd = UOW.connection.CreateCommand())
			{
				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
