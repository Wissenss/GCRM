using Connection;
using Npgsql;
using System.Data.Common;
using System.Text;

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

	public class TInstitutionTemplate
	{
		public int Id;
		public string Name;
		public string Description;

		public List<TInstitutionRole> Roles = new List<TInstitutionRole>();

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
		public int InstitutionTemplateId;
		public int ParentRoleId;
		public string Description;

		public string NameWithFirstCapital
		{
			get
			{
				if (Name.Length == 0)
					return "";

				string formated_name = Name.ToLower();

				formated_name = formated_name.First().ToString().ToUpper() + formated_name.Substring(1);

				return formated_name;
			}
		}

		public bool IsTemplateRole
		{
			get
			{
				return InstitutionTemplateId > 0;
			}
		}

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			InstitutionId = reader.GetInt32(2);
			ParentRoleId = reader.GetInt32(3);
			Description = reader.GetString(4);

			InstitutionTemplateId = 0;
		}

		public void FillFromReaderTemplate(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			InstitutionTemplateId = reader.GetInt32(1);
			Name = reader.GetString(2);
			Description = reader.GetString(3);

			ParentRoleId = 0;
			InstitutionId = 0;
		}
	}

	public class TInstitution : TEntity
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
		public string Acronym;
		public bool AttentionRequired;
		public TInstitutionTemplate Template = new TInstitutionTemplate();

		public string NameWithFirstCapital
		{
			get
			{
				if (Name.Length == 0)
					return "";

				string formated_name = Name.ToLower();

				formated_name = formated_name.First().ToString().ToUpper() + formated_name.Substring(1);

				return formated_name;
			}
		}

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
			Acronym = reader.GetString(10);
			AttentionRequired = reader.GetBoolean(11);
			Template.Id = reader.GetInt32(12);
		}

		public override string GetAsLogString()
		{
			StringBuilder log_string = new StringBuilder();

			log_string.AppendLine($"Id:                  \t{Id}");
			log_string.AppendLine($"Name:                \t{Name}");
			log_string.AppendLine($"Description:         \t{Description}");
			log_string.AppendLine($"Sector:              \t{Sector}");
			log_string.AppendLine($"Category:            \t{Category.Id}");
			log_string.AppendLine($"Roles:               \t{Roles.Count}");
			log_string.AppendLine($"ParentInstitutionId: \t{ParentInstitutionId}");
			log_string.AppendLine($"Author:              \t{Author.Id}");
			log_string.AppendLine($"CreatedDate:         \t{CreatedDate}");
			log_string.AppendLine($"LastEditor:          \t{LastEditor.Id}");
			log_string.AppendLine($"EditDate:            \t{EditDate}");
			log_string.AppendLine($"Acronym:             \t{Acronym}");
			log_string.AppendLine($"AttentionRequired:   \t{AttentionRequired}");
			log_string.AppendLine($"Template:            \t{Template.Id}");

			return log_string.ToString();
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
						edit_date = @edit_date,
						acronym = @acronym,
						attention_required = @attention_required,
						institution_template_id = @institution_template_id	
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
						edit_date,
						acronym,
						attention_required,
						institution_template_id
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
						@edit_date,
						@acronym,
						@attention_required,
						@institution_template_id
					) 
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
				cmd.Parameters.AddWithValue("@acronym", institution.Acronym);
				cmd.Parameters.AddWithValue("@attention_required", false); // editing the institution will always set the attention required flag to false
				cmd.Parameters.AddWithValue("@institution_template_id", institution.Template.Id);

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

				// delete roles that are not in the list
				List<int> role_ids_to_delete = new List<int>();

				cmd.CommandText = "SELECT id FROM institution_roles WHERE institution_id = @institution_id;";

				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@institution_id", institution.Id);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						bool found = false;

						foreach (TInstitutionRole role in institution.Roles)
						{
							if (role.Id == reader.GetInt32(0) || role.Id == 0)
							{
								found = true;
								break;
							}
						}

						if (!found)
						{
							role_ids_to_delete.Add(reader.GetInt32(0));
						}
					}
				}

				foreach (int role_id in role_ids_to_delete)
				{
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@id", role_id);

					// no citizen can have this role
					cmd.CommandText = "SELECT COUNT(*) FROM citizens WHERE institution_role_id = @id OR institution2_role_id = @id OR institution3_role_id = @id;";

					int citizens_with_role = (Int32)(Int64)cmd.ExecuteScalar();

					if (citizens_with_role > 0)
					{
						tran.Rollback();

						ConnectionPool.ReleaseConnection(ref conn);

						return Error.InstitutionRoleInUser;
					}

					cmd.CommandText = "DELETE FROM institution_roles WHERE id = @id;";

					cmd.ExecuteNonQuery();
				}
			}

			EventLogHandler.AddEventLog(is_update ? TEventLogType.institution_edit : TEventLogType.institution_add, institution.LastEditor.Id, institution.Id, TEntityType.institution, institution, DateTime.Now);

			tran.Commit();

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error SetInstitutionAttentionRequired(int institution_id, bool attention_required)
		{
			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("UPDATE institutions SET attention_required = @attention_required WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", institution_id);
				cmd.Parameters.AddWithValue("@attention_required", attention_required);

				cmd.ExecuteNonQuery();
			}

			StringBuilder log_message = new StringBuilder();

			log_message.AppendLine($"GCRM v{BConstants.GetProductVersion()} ACTION LOG");
			log_message.AppendLine($"==================================================");
			log_message.AppendLine($"evento:  {BConstants.GetEventLogTypeName(TEventLogType.institution_attention_required)}");
			log_message.AppendLine($"fecha/hora:   {DateTime.Now}");
			log_message.AppendLine($"entidad: ");
			log_message.AppendLine($"institución id: \t{institution_id}");
			log_message.AppendLine($"atención requerida: \t{attention_required}");
			log_message.AppendLine($"==================================================");

			EventLogHandler.AddEventLog(TEventLogType.institution_attention_required, Session.User.Id, institution_id, TEntityType.institution, log_message.ToString(), DateTime.Now);

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error DeleteInstitutionById(int id)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			// check there is no citizen with this institution
			using (var cmd = new NpgsqlCommand("SELECT * FROM citizens WHERE institution_id = @id OR institution2_id = @id OR institution3_id = @id;", conn))
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
			if (error == 0)
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

			TInstitution institution = new TInstitution();

			if (error == 0)
			{
				error = GetInstitutionById(id, out institution);
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

			if (error == 0)
			{
				error = EventLogHandler.AddEventLog(TEventLogType.institution_delete, Session.User.Id, institution.Id, TEntityType.institution, institution, DateTime.Now);
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

						if (error == 0 && institution.Template.Id > 0)
						{
							error = GetInstitutionTemplateById(institution.Template.Id, out institution.Template);
						}
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

			string sql = @"
				SELECT 
					i.*, 
					ic.name as category_name,
					ic.description as category_description,
					u.name as author_name,	
					u2.name as editor_name,
					it.name as template_name	
				FROM 
					institutions i
					LEFT JOIN institution_categories ic ON i.category_id = ic.id 
					LEFT JOIN users u ON i.created_by_id = u.id
					LEFT JOIN users u2 ON i.edit_by_id = u2.id
					LEFT JOIN institution_templates it ON i.institution_template_id = it.id
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

					if (institution.Author.Id != 0)
					{
						institution.Author.Name = reader.GetString(reader.GetOrdinal("author_name"));
					}

					if (institution.LastEditor.Id != 0)
					{
						institution.LastEditor.Name = reader.GetString(reader.GetOrdinal("editor_name"));
					}

					if (institution.Template.Id != 0)
					{
						institution.Template.Name = reader.GetString(reader.GetOrdinal("template_name"));
					}

					institution_list.Add(institution);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetInstitutionRoles(int institution_id, out List<TInstitutionRole> institution_roles)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			string sql = "SELECT * FROM institution_roles WHERE institution_id = @institution_id ORDER BY id;";
			
			institution_roles = new List<TInstitutionRole>();

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@institution_id", institution_id);
				
				// get the roles

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TInstitutionRole role = new TInstitutionRole();

						role.FillFromReader(reader);

						institution_roles.Add(role);
					}
				}

				// get the template roles

				error = GetInstitutionTemplateRoles(institution_id, out List<TInstitutionRole> template_roles_list);

				if (error == 0)
				{
					foreach (TInstitutionRole role in template_roles_list)
					{
						institution_roles.Add(role);
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
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

		public static Error GetInstitutionRoleById(int id, bool is_template_role, out TInstitutionRole role)
		{
			role = new TInstitutionRole();

			var conn = ConnectionPool.GetConnection();

			Error error = 0;

			if (is_template_role)
			{
				using (var cmd = new NpgsqlCommand("SELECT * FROM institution_template_roles WHERE id = @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							reader.Read();

							role.FillFromReaderTemplate(reader);
						}
						else
						{
							error = Error.InstitutionTemplateRoleNotFound;
						}
					}
				}
			}
			else
			{
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
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetInstitutionTemplateById(int id, out TInstitutionTemplate template)
		{
			Error error = 0;

			template = new TInstitutionTemplate();

			var conn = ConnectionPool.GetConnection();

			string sql = "SELECT * FROM institution_templates WHERE id = @id;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						template.Id = reader.GetInt32(0);
						template.Name = reader.GetString(1);
						template.Description = reader.GetString(2);

						error = GetInstitutionTemplateRoles(template.Id, out template.Roles);
					}
					else
					{
						error = Error.InstitutionNotFound;
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetInstitutionTemplateRoles(int institution_id, out List<TInstitutionRole> template_roles_list)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			template_roles_list = new List<TInstitutionRole>();

			string sql = @"
				SELECT 
					itr.*
				FROM 
					institution_template_roles itr 
				ORDER BY 
					itr.id;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@institution_template_id", institution_id);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TInstitutionRole role = new TInstitutionRole();

						role.FillFromReaderTemplate(reader);

						template_roles_list.Add(role);
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetInstitutionTemplates(out List<TInstitutionTemplate> institution_templates)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			institution_templates = new List<TInstitutionTemplate>();

			string sql = "SELECT * FROM institution_templates ORDER BY name;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TInstitutionTemplate template = new TInstitutionTemplate();

						template.FillFromReader(reader);

						institution_templates.Add(template);
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error SaveInstitutionTemplate(TInstitutionTemplate institution_template, bool is_update)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();
			var tran = conn.BeginTransaction();

			string sql = "";

			if (is_update)
			{
				sql = "UPDATE institution_templates SET name = @name, description = @description WHERE id = @id;";
			}
			else
			{
				sql = "INSERT INTO institution_templates(name, description) VALUES(@name, @description);";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", institution_template.Id);
				cmd.Parameters.AddWithValue("@name", institution_template.Name);
				cmd.Parameters.AddWithValue("@description", institution_template.Description);

				cmd.ExecuteNonQuery();

				// save the roles
				foreach (TInstitutionRole role in institution_template.Roles)
				{
					if (role.Id == 0)
					{
						cmd.CommandText = "INSERT INTO institution_template_roles(name, institution_template_id, description) VALUES(@name, @institution_template_id, @description);";
					}
					else
					{
						cmd.CommandText = "UPDATE institution_template_roles SET name = @name, institution_template_id=@institution_template_id, description=@description WHERE id = @id";
					}

					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@id", role.Id);
					cmd.Parameters.AddWithValue("@name", role.Name);
					cmd.Parameters.AddWithValue("@institution_template_id", institution_template.Id);
					cmd.Parameters.AddWithValue("@description", role.Description);

					cmd.ExecuteNonQuery();
				}
			}

			tran.Commit();

			return error;
		}

		public static Error DeleteInstitutionTemplateById(int id)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();
			var tran = conn.BeginTransaction();

			// check there is no institution using this template

			using (var cmd = new NpgsqlCommand("SELECT * FROM institutions WHERE institution_template_id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Close();

						tran.Rollback();
						ConnectionPool.ReleaseConnection(ref conn);
						return Error.InstitutionTemplateInUse;
					}
				}
			}

			using (var cmd = new NpgsqlCommand("DELETE FROM institution_template_roles WHERE institution_template_id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				cmd.ExecuteNonQuery();

				cmd.CommandText = "DELETE FROM institution_templates WHERE id = @id;";

				cmd.ExecuteNonQuery();
			}

			tran.Commit();
			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}
	}
}
