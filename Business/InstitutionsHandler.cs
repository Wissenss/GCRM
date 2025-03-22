using Connection;
using Npgsql;
using System.Data.Common;

namespace Business
{
	public class TInstitutionCategory
	{
		public int Id;
		public string Name;
		public string Description;

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			Description = reader.GetString(2);
		}
	}

	public class TInstitutionRole
	{
		public int Id;
		public string Name;
		public int InstitutionId;
		public int ParentRoleId;
		public string Description;

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			InstitutionId = reader.GetInt32(2);
			ParentRoleId = reader.GetInt32(3);
			Description = reader.GetString(4);
		}
	}

	public class TInstitution
	{
		public int Id;
		public string Name;
		public string Description;
		public TSocietySector Sector;
		public TInstitutionCategory Category = new TInstitutionCategory();
		public List<TInstitutionRole> Roles;
		public int ParentInstitutionId;
		public TUser Author = new TUser();
		public DateTime CreatedDate;
		public TUser LastEditor = new TUser();
		public DateTime EditDate;

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name= reader.GetString(1);
			Sector = (TSocietySector)reader.GetInt32(2);
			Category.Id = reader.GetInt32(3);
			Description = reader.GetString(4);
			ParentInstitutionId = reader.GetInt32(5);
			Author.Id = reader.GetInt32(6);
			CreatedDate = reader.GetDateTime(7);
			LastEditor.Id = reader.GetInt32(8);
			EditDate = reader.GetDateTime(9);
		}
	}

	public static class InstitutionsHandler
	{ 
		public static Error SaveInstitution(TInstitution institution, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			var tran = conn.BeginTransaction();

			// #54 - the institution name cannot be repeated

			using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM institutions WHERE name = @name and id <> @id; ", conn))
			{
				cmd.Parameters.AddWithValue("@id", institution.Id);
				cmd.Parameters.AddWithValue("@name", institution.Name);

				int records_with_same_name = (Int32)(Int64)cmd.ExecuteScalar();

				if (records_with_same_name > 0)
				{
					tran.Rollback();
					ConnectionPool.ReleaseConnection(ref conn);

					return Error.InstitutionRepeatedName;
				}
			}

			string sql = "";

			if (is_update)
			{
				sql = @"
					UPDATE 
						institutions 
					SET 
						name = @name, 
						society_sector_type = @society_sector, 
						category_id = @category_id, 
						description = @description, 
						parent_institution_id = @parent_institution_id,
						edit_by_id = @edit_by_id,
						edit_date = @edit_date
					WHERE 
						id = @id;";
			}
			else
			{
				sql = @"
					INSERT INTO institutions(
						name, 
						society_sector_type, 
						category_id, 
						description, 
						parent_institution_id,
						created_by_id,
						created_date,
						edit_by_id,
						edit_date
					) 
					VALUES(
						@name, 
						@society_sector, 
						@category_id, 
						@description, 
						@parent_institution_id,
						@created_by_id,
						@created_date,
						@edit_by_id,
						@edit_date) 
					RETURNING id;";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", institution.Id);
				cmd.Parameters.AddWithValue("@name", institution.Name);
				cmd.Parameters.AddWithValue("@society_sector", (int)institution.Sector);
				cmd.Parameters.AddWithValue("@category_id", institution.Category.Id);
				cmd.Parameters.AddWithValue("@description", institution.Description);
				cmd.Parameters.AddWithValue("@parent_institution_id", institution.ParentInstitutionId);
				cmd.Parameters.AddWithValue("@created_by_id", institution.Author.Id);
				cmd.Parameters.AddWithValue("@created_date", institution.CreatedDate);
				cmd.Parameters.AddWithValue("@edit_by_id", institution.LastEditor.Id);
				cmd.Parameters.AddWithValue("@edit_date", institution.EditDate);

				if (is_update)
				{
					cmd.ExecuteNonQuery();
				}
				else
				{
					institution.Id = (Int32)(Int64)cmd.ExecuteScalar();
				}

				foreach (TInstitutionRole role in institution.Roles)
				{
					if (role.Id == 0)
					{
						cmd.CommandText = "INSERT INTO institution_roles(name, institution_id, parent_role_id, description) VALUES(@name, @institution_id, @parent_role_id, @description);";
					}
          else
          {
						cmd.CommandText = "UPDATE institution_roles SET name = @name, institution_id=@institution_id, parent_role_id=@parent_role_id, description=@description WHERE id = @id";
          }
					
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@id", role.Id);
					cmd.Parameters.AddWithValue("@name", role.Name);
					cmd.Parameters.AddWithValue("@institution_id", institution.Id);
					cmd.Parameters.AddWithValue("@parent_role_id", role.ParentRoleId);
					cmd.Parameters.AddWithValue("@description", role.Description);

					cmd.ExecuteNonQuery();
				}
			}

			tran.Commit();	

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error DeleteInstitutionById(int id)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			// check there is no citizen with this institution
			using (var cmd = new NpgsqlCommand("SELECT * FROM citizens WHERE institution_id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						error = Error.InstitutionCategoryInUse;
					}
				}
			}

			// check there is no institution with this institution
			if (error != 0)
			{
				using (var cmd = new NpgsqlCommand("SELECT * FROM institutions WHERE parent_institution_id = @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							error = Error.InstitutionCategoryInUse;
						}
					}
				}
			}

			if (error == 0)
			{
				using (var cmd = new NpgsqlCommand("DELETE FROM institution_roles WHERE institution_id = @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);

					cmd.ExecuteNonQuery();

					cmd.CommandText = "DELETE FROM institutions WHERE id = @id;";

					cmd.ExecuteNonQuery();
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error DeleteInstitutionCategoryById(int id)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			// check there is no institution using this category
			using (var cmd = new NpgsqlCommand("SELECT * FROM institutions WHERE category_id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						error = Error.InstitutionCategoryInUse;
					}
				}
			}

			if (error == 0)
			{
				using (var cmd = new NpgsqlCommand("DELETE FROM institution_categories WHERE id = @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);

					cmd.ExecuteNonQuery();
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetInstitutionById(int id, out TInstitution institution)
		{ 
			institution = new TInstitution();

			var conn = ConnectionPool.GetConnection();

			Error error = 0;

			using (var cmd = new NpgsqlCommand("SELECT * FROM institutions WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader()) 
				{	
					if (reader.HasRows)
					{
						reader.Read();

						institution.FillFromReader(reader);

						error = GetInstitutionCategoryById(institution.Category.Id, out institution.Category);
					}
					else
					{
						error = Error.InstitutionNotFound;
					}
				}
			}

			GetInstitutionRoles(id, out institution.Roles);

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetNullInstitution(out TInstitution institution)
		{
			TInstitution null_institution = new TInstitution()
			{
				Id = 0,
				Name = "Desconocida",
				Sector = TSocietySector.None,
				ParentInstitutionId = 0,
			};

			GetNullInstitutionRoles(out null_institution.Roles);

			institution = null_institution;

			return 0;
		}

		public static Error GetNullInstitutionRoles(out List<TInstitutionRole> institution_roles)
		{
			List<TInstitutionRole> null_institution_roles = new List<TInstitutionRole>()
			{
				new TInstitutionRole()
				{
					Id = 0,
					Name = "Desconocido",
					Description = ""
				}
			};

			institution_roles = null_institution_roles;

			return 0;	
		}

		public static Error GetInstitutions(out List<TInstitution> institution_list)
		{
			institution_list = new List<TInstitution>();

			var conn = ConnectionPool.GetConnection();

			string sql = @"
				SELECT 
					i.*, 
					ic.name as category_name,
					ic.description as category_description
				FROM 
					institutions i
					LEFT JOIN institution_categories ic ON i.category_id = ic.id 
				ORDER BY name;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while (reader.Read())
				{
					TInstitution institution = new TInstitution();

					institution.FillFromReader(reader);

					if (institution.Category.Id != 0)
					{
						institution.Category.Name = reader.GetString(reader.GetOrdinal("category_name"));
						institution.Category.Description = reader.GetString(reader.GetOrdinal("category_description"));
					}

					institution_list.Add(institution);	
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetInstitutionRoles(int institution_id, out List<TInstitutionRole> institution_roles)
		{
			var conn = ConnectionPool.GetConnection();

			string sql = "SELECT * FROM institution_roles WHERE institution_id = @institution_id ORDER BY id;";

			institution_roles = new List<TInstitutionRole>();

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@institution_id", institution_id);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TInstitutionRole role = new TInstitutionRole();

						role.FillFromReader(reader);

						institution_roles.Add(role);
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error SaveInstitutionCategory(TInstitutionCategory category, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			string sql;

			if (is_update)
			{
				sql = "UPDATE institution_categories SET name = @name, description = @description WHERE id = @id;";
			}
			else
			{
				sql = "INSERT INTO institution_categories(name, description) VALUES(@name, @description);";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", category.Id);
				cmd.Parameters.AddWithValue("@name", category.Name);
				cmd.Parameters.AddWithValue("@description", category.Description);

				cmd.ExecuteNonQuery();
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetInstitutionCategoryById(int id, out TInstitutionCategory category)
		{
			var conn = ConnectionPool.GetConnection();

			Error error = 0;

			category = new TInstitutionCategory();

			using (var cmd = new NpgsqlCommand("SELECT * FROM institution_categories WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						category.FillFromReader(reader);
					}
					else
					{
						error = Error.InstitutionCategoryNotFound;
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetInstitutionCategories(out List<TInstitutionCategory> category_list)
		{
			var conn = ConnectionPool.GetConnection();

			category_list = new List<TInstitutionCategory>();

			using (var cmd = new NpgsqlCommand("SELECT * FROM institution_categories ORDER BY name;", conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TInstitutionCategory category = new TInstitutionCategory();

						category.FillFromReader(reader);

						category_list.Add(category);
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error GetInstitutionRoleById(int id, out TInstitutionRole role)
		{
			role = new TInstitutionRole();

			var conn = ConnectionPool.GetConnection();

			Error error = 0;

			using (var cmd = new NpgsqlCommand("SELECT * FROM institution_roles WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						role.FillFromReader(reader);
					}
					else
					{
						error = Error.InstitutionRoleNotFound;
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}
	}
}
