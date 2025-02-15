using Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name= reader.GetString(1);
			Sector = (TSocietySector)reader.GetInt32(2);
			Category.Id = reader.GetInt32(3);
			Description = reader.GetString(4);
		}
	}

	public static class InstitutionsHandler
	{ 
		public static Error SaveInstitution(TInstitution institution, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			var tran = conn.BeginTransaction();

			string sql = "";

			if (is_update)
			{
				sql = "UPDATE institutions SET name = @name, society_sector_type = @society_sector, category_id = @category_id, description = @description WHERE id = @id;";
			}
			else
			{
				sql = "INSERT INTO institutions(name, society_sector_type, category_id, description) VALUES(@name, @society_sector, @category_id, @description) RETURNING id;";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", institution.Id);
				cmd.Parameters.AddWithValue("@name", institution.Name);
				cmd.Parameters.AddWithValue("@society_sector", (int)institution.Sector);
				cmd.Parameters.AddWithValue("@category_id", institution.Category.Id);
				cmd.Parameters.AddWithValue("@description", institution.Description);

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

		public static Error GetInstitutions(out List<TInstitution> institution_list)
		{
			institution_list = new List<TInstitution>();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM institutions;", conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while (reader.Read())
				{
					TInstitution institution = new TInstitution();

					institution.FillFromReader(reader);

					GetInstitutionCategoryById(institution.Category.Id, out institution.Category);

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

		// this one is already implemented in the CitizensHandler
		//public static Error GetCitizenInstitutionRoles(out List<TInstitutionRole> roles_list)
		//{
		//	roles_list = new List<TInstitutionRole>();

		//	return 0;
		//}

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

			using (var cmd = new NpgsqlCommand("SELECT * FROM institution_categories;", conn))
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
