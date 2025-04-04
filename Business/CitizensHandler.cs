using Connection;
using Npgsql;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Business
{
	public class TCitizenCategory
	{
		public int Id;
		public string Name;
		public string Description;

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(reader.GetOrdinal("id"));
			Name = reader.GetString(reader.GetOrdinal("name"));
			Description = reader.GetString(reader.GetOrdinal("description"));
		}
	}

	public class TCitizenContactNumber
	{
		public string Number;
		public string Extension;

		private string GetNumericString(string raw_string)
		{
			string clean_string = "";

			foreach (char character in raw_string)
			{
				if (Char.IsNumber(character))
				{
					clean_string += character;
				}
			}

			return clean_string;
		}

		public string NumericNumber
		{
			get
			{
				return GetNumericString(Number);
			}
		}

		public string NumericExtension
		{
			get
			{
				return GetNumericString(Extension);
			}
		}

		public string FullNumber
		{
			get
			{
				string number = "";

				if (Number.Length > 0)
				{
					number += Number;

					if (Extension.Length > 0)
					{
						number += $" Ext. {Extension}";
					}
				}

				return number;
			}
		}

		public string FullNumberWithPrefix
		{
			get
			{
				if (FullNumber.Length > 0)
				{
					return "Tel. " + FullNumber;
				}

				return FullNumber;
			}
		}
	}

	public class TCitizen : TEntity
	{
		public int Id;
		public string Name;
		public string PaternalName;
		public string MaternalName;
		public TCitizenTitle Title;
		public string CURP;
		public DateTime Birthday;
		public string Observations;
		public TSex Sex;
		public TAddress Address = new TAddress();
		public TCitizen Assistant;
		public TCitizenContactNumber Phone = new TCitizenContactNumber();
		public TCitizenContactNumber Phone2 = new TCitizenContactNumber();
		public TCitizenContactNumber Phone3 = new TCitizenContactNumber();
		public string Cellphone;
		public string Email;
		public TPoliticalParty PoliticalParty;
		public TInstitution Institution = new TInstitution();
		public TInstitution Institution2 = new TInstitution();
		public TInstitution Institution3 = new TInstitution();
		public TInstitutionRole Role = new TInstitutionRole();
		public TInstitutionRole Role2 = new TInstitutionRole();
		public TInstitutionRole Role3 = new TInstitutionRole();
		public TUser Author = new TUser();
		public DateTime CreatedDate;
		public TUser LastEditor = new TUser();	
		public DateTime EditDate;

		public string VoterCode;
		public string VoterOCR;
		public string VoterCIC;
		public string VoterSection;

		public bool AttentionRequired;

		public bool IsPoliticalActivist;
		public DateTime PoliticalRegisterDate;

		public TCitizenCategory Category = new TCitizenCategory();

		public string FullName 
		{ 
			get 
			{
				return $"{Name} {PaternalName} {MaternalName}";
			} 
		}

		private string GetNameStringWithFirstCapitals(string name_string)
		{
			List<string> word_list = name_string.Split(' ').ToList();
			string[] uncapitalizable_words = { "de", "del", "la" };

			string formated_name = "";

			foreach (string word in word_list)
			{
				string formated_word = word;

				if (uncapitalizable_words.Contains(word.ToLower()) == false)
				{
					if (formated_word.Length == 0)
						continue;

					formated_word = formated_word.First().ToString().ToUpper() + formated_word.Substring(1).ToLower();
				}
				else
				{
					formated_word = formated_word.ToLower();
				}

				formated_name += formated_word + " ";
			}

			return formated_name.Trim();
		}

		public string FullNameWithFirstCapitals
		{
			get
			{
				return GetNameStringWithFirstCapitals(FullName);
			}
		}

		public string NameWithFirstCapitals
		{
			get 
			{
				return GetNameStringWithFirstCapitals(Name);
			}
		}

		public string MaternalNameWithFirstCapitals
		{
			get
			{
				return GetNameStringWithFirstCapitals(MaternalName);
			}
		}

		public string PaternalNameWithFirstCapitals
		{
			get
			{
				return GetNameStringWithFirstCapitals(PaternalName);
			}
		}

		public void FillFromReader(DbDataReader reader)
		{
			Assistant = new TCitizen();
			Institution = new TInstitution();

			Id = reader.GetInt32(0);
			Name = reader.GetString(1);	
			PaternalName = reader.GetString(2);
			MaternalName = reader.GetString(3);
			Title = (TCitizenTitle)reader.GetInt32(4);
			CURP = reader.GetString(5);
			Birthday = reader.GetDateTime(6);
			Observations = reader.GetString(7);
			Sex = (TSex)reader.GetInt32(8);
			Address.Id = reader.GetInt32(9);
			Assistant.Id = reader.GetInt32(10);
			Phone.Number = reader.GetString(11);
			Phone.Extension = reader.GetString(12);
			Cellphone = reader.GetString(13);
			PoliticalParty = (TPoliticalParty)reader.GetInt32(14);
			Institution.Id = reader.GetInt32(15);
			Role.Id = reader.GetInt32(16);
			Email = reader.GetString(17);
			Author.Id = reader.GetInt32(18);
			CreatedDate = reader.GetDateTime(19);
			LastEditor.Id = reader.GetInt32(20);
			EditDate = reader.GetDateTime(21);
			VoterCode = reader.GetString(22);
			VoterOCR = reader.GetString(23);
			VoterCIC = reader.GetString(24);
			VoterSection = reader.GetString(25);
			Category.Id = reader.GetInt32(26);
			Institution2.Id = reader.GetInt32(27);
			Role2.Id = reader.GetInt32(28);
			Institution3.Id = reader.GetInt32(29);
			Role3.Id = reader.GetInt32(30);
			AttentionRequired = reader.GetBoolean(31);
			IsPoliticalActivist = reader.GetBoolean(32);
			PoliticalRegisterDate = reader.GetDateTime(33);
			Phone2.Number = reader.GetString(34);
			Phone2.Extension = reader.GetString(35);
			Phone3.Number = reader.GetString(36);
			Phone3.Extension = reader.GetString(37);

			// if the value of the template is set for the role, then it is a template role 
			Role.InstitutionTemplateId = reader.GetInt32(38);
			Role2.InstitutionTemplateId = reader.GetInt32(39);
			Role3.InstitutionTemplateId = reader.GetInt32(40);
		}
	
		public override string GetAsLogString()
		{
			StringBuilder log_string = new StringBuilder();

			log_string.AppendLine($"Id:              \t{Id}");
			log_string.AppendLine($"Name:            \t{Name}");
			log_string.AppendLine($"Paternal Name:   \t{PaternalName}");
			log_string.AppendLine($"Maternal Name:   \t{MaternalName}");
			log_string.AppendLine($"Title:           \t{Title}");
			log_string.AppendLine($"CURP:            \t{CURP}");
			log_string.AppendLine($"Birthday:        \t{Birthday}");
			log_string.AppendLine($"Observations:    \t{Observations}");
			log_string.AppendLine($"Sex:             \t{Sex}");
			log_string.AppendLine($"Address:         \t{Address.Id}");
			log_string.AppendLine($"Assistant:       \t{Assistant.Id}");
			log_string.AppendLine($"Phone:           \t{Phone.Number}");
			log_string.AppendLine($"Phone Ext:       \t{Phone.Extension}");
			log_string.AppendLine($"Phone2:          \t{Phone2.Number}");
			log_string.AppendLine($"Phone2 Ext:      \t{Phone2.Extension}");
			log_string.AppendLine($"Phone3:          \t{Phone3.Number}");
			log_string.AppendLine($"Phone3 Ext:      \t{Phone3.Extension}");
			log_string.AppendLine($"Cellphone:       \t{Cellphone}");
			log_string.AppendLine($"Email:           \t{Email}");
			log_string.AppendLine($"Political Party: \t{PoliticalParty}");
			log_string.AppendLine($"Institution:     \t{Institution.Id}");
			log_string.AppendLine($"Role:            \t{Role.Id}");
			log_string.AppendLine($"Author:          \t{Author.Id}");
			log_string.AppendLine($"Created Date:    \t{CreatedDate}");
			log_string.AppendLine($"Last Editor:     \t{LastEditor.Id}");
			log_string.AppendLine($"Edit Date:       \t{EditDate}");
			log_string.AppendLine($"Voter Code:      \t{VoterCode}");
			log_string.AppendLine($"Voter OCR:       \t{VoterOCR}");
			log_string.AppendLine($"Voter CIC:       \t{VoterCIC}");
			log_string.AppendLine($"Voter Section:   \t{VoterSection}");
			log_string.AppendLine($"Category:        \t{Category.Id}");

			return log_string.ToString();
		}
	}

	public static class CitizensHandler
	{
		public static Error GetCitizenById(int id, out TCitizen citizen)
		{
			Error error = 0;

			citizen = new TCitizen();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizens WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						citizen.FillFromReader(reader);

						if (error == 0 && citizen.Assistant.Id != 0)
							error = GetCitizenAssistantById(citizen.Assistant.Id, out citizen.Assistant);

						if (error == 0 && citizen.Address.Id != 0)
							error = AddressesHandler.GetAddressById(citizen.Address.Id, out citizen.Address);

						if (error == 0 && citizen.Institution.Id != 0)
							error = InstitutionsHandler.GetInstitutionById(citizen.Institution.Id, out citizen.Institution);

						if (error == 0 && citizen.Institution2.Id != 0)
							error = InstitutionsHandler.GetInstitutionById(citizen.Institution2.Id, out citizen.Institution2);

						if (error == 0 && citizen.Institution3.Id != 0)
							error = InstitutionsHandler.GetInstitutionById(citizen.Institution3.Id, out citizen.Institution3);

						if (error == 0 && citizen.Role.Id != 0)
							error = InstitutionsHandler.GetInstitutionRoleById(citizen.Role.Id, citizen.Role.IsTemplateRole, out citizen.Role);

						if (error == 0 && citizen.Role2.Id != 0)
							error = InstitutionsHandler.GetInstitutionRoleById(citizen.Role2.Id, citizen.Role2.IsTemplateRole, out citizen.Role2);

						if (error == 0 && citizen.Role3.Id != 0)
							error = InstitutionsHandler.GetInstitutionRoleById(citizen.Role3.Id, citizen.Role3.IsTemplateRole, out citizen.Role3);
					}
					else
					{
						error = Error.CitizenNotFound;
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error DeleteCitizenById(int id)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			// check there is no citizen having this as assistant
			using (var cmd = new NpgsqlCommand("SELECT * FROM citizens WHERE assistant_id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						error = Error.CitizenInUse;
					}
				}
			}

			TCitizen citizen;

			error = GetCitizenById(id, out citizen);

			if (error == 0)
			{
				using (var cmd = new NpgsqlCommand("DELETE FROM citizens WHERE id = @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);

					cmd.ExecuteNonQuery();
				}
			}

			if (error == 0)
			{
				EventLogHandler.AddEventLog(TEventLogType.citizen_delete, Session.User.Id, id, TEntityType.citizen, citizen, DateTime.Now);
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetCitizenAssistantById(int id, out TCitizen citizen_assistant)
		{
			Error error = 0;

			citizen_assistant = new TCitizen();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizens WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						citizen_assistant.FillFromReader(reader);
					}
					else
					{
						error = Error.CitizenNotFound;
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error SaveCitizen(TCitizen citizen, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			var tran = conn.BeginTransaction();

			Error error = 0;

			// ensure one CURP is not used more than once
			if (citizen.CURP != "")
			{
				using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM citizens WHERE curp = @curp AND id <> @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", citizen.Id);
					cmd.Parameters.AddWithValue("@curp", citizen.CURP);

					int citizens_with_same_curp = (Int32)(Int64)cmd.ExecuteScalar();

					if (citizens_with_same_curp > 0)
					{
						error = Error.CitizenWithSameCURP;
					}
				}
			}

			// ensure no more than one citizen has the same name
			using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM citizens WHERE name = @name AND paternal_name = @paternal_name AND maternal_name = @maternal_name AND id <> @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", citizen.Id);
				cmd.Parameters.AddWithValue("@name", citizen.Name);
				cmd.Parameters.AddWithValue("@paternal_name", citizen.PaternalName);
				cmd.Parameters.AddWithValue("@maternal_name", citizen.MaternalName);

				int citizens_with_same_name = (Int32)(Int64)cmd.ExecuteScalar();

				if (citizens_with_same_name > 0)
				{
					error = Error.CitizenWithSameName;
				}
			}

			// ensure no more than one citizen has the same voter code
			if (citizen.VoterCode != "")
			{
				using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM citizens WHERE voter_code = @voter_code AND id <> @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", citizen.Id);
					cmd.Parameters.AddWithValue("@voter_code", citizen.VoterCode);

					int citizens_with_same_voter_code = (Int32)(Int64)cmd.ExecuteScalar();

					if (citizens_with_same_voter_code > 0)
					{
						error = Error.CitizenWithSameVoterCode;
					}
				}
			}

			// save address
			if (error == 0)
			{
				error = AddressesHandler.SaveAddress(citizen.Address, is_update, out citizen.Address.Id);
			}

			// save citizen record
			if (error == 0)
			{
				using (var cmd = new NpgsqlCommand("", conn))
				{
					if (is_update)
					{
						cmd.CommandText = @"
							UPDATE 
								citizens 
							SET 
								name=@name, 
								paternal_name=@paternal_name, 
								maternal_name=@maternal_name, 
								title_type=@title, 
								curp=@curp, 
								birthday=@birthday, 
								observations=@observations,
								sex_type=@sex,
								address_id=@address_id,
								assistant_id=@assistant_id,
								phone=@phone,
								phone_extension=@phone_extension,
								cellphone=@cellphone,
								political_party_type=@political_party,
								institution_id=@institution_id,
								institution_role_id=@institution_role_id,
								email=@email,
								edit_by_id=@edit_by_id,
								edit_Date=@edit_date,
								voter_code = @voter_code,
								voter_ocr = @voter_ocr,
								voter_cic = @voter_cic,
								voter_section = @voter_section,
								citizen_category_id = @category_id,
								institution2_id = @institution2_id,
								institution3_id = @institution3_id,	
								institution2_role_id = @institution2_role_id,
								institution3_role_id = @institution3_role_id,
								attention_required = @attention_required,
								is_political_activist = @is_political_activist,
								political_register_date = @political_register_date,
								phone2 = @phone2,
								phone2_extension = @phone2_extension,
								phone3 = @phone3,
								phone3_extension = @phone3_extension,
								institution_template_role_id = @institution_template_role_id,
								institution2_template_role_id = @institution2_template_role_id,
								institution3_template_role_id = @institution3_template_role_id
							WHERE
								id=@id;";
					}
					else
					{
						cmd.CommandText = @"
							INSERT INTO citizens(
								name, 
								paternal_name, 
								maternal_name, 
								title_type, 
								curp, 
								birthday, 
								observations,
								sex_type,
								address_id,
								assistant_id,
								phone,
								phone_extension,
								cellphone,
								political_party_type,
								institution_id,
								institution_role_id,
								email,
								created_by_id,
								created_date,
								edit_by_id,
								edit_date,
								voter_code,
								voter_ocr,
								voter_cic,
								voter_section,
								citizen_category_id,
								institution2_id,	
								institution3_id,
								institution2_role_id,
								institution3_role_id,
								attention_required,
								is_political_activist,
								political_register_date,
								phone2,
								phone2_extension,
								phone3,
								phone3_extension,
								institution_template_role_id,
								institution2_template_role_id
								institution3_template_role_id
							)
							VALUES(
								@name, 
								@paternal_name, 
								@maternal_name, 
								@title, 
								@curp, 
								@birthday, 
								@observations,
								@sex,
								@address_id,
								@assistant_id,
								@phone,
								@phone_extension,
								@cellphone,
								@political_party,
								@institution_id,
								@institution_role_id,
								@email,
								@created_by_id,
								@created_date,
								@edit_by_id,
								@edit_date,
								@voter_code,
								@voter_ocr,
								@voter_cic,
								@voter_section,
								@category_id,
								@institution2_id,
								@institution3_id,
								@institution2_role_id,
								@institution3_role_id,
								@attention_required,
								@is_political_activist,
								@political_register_date,
								@phone2,
								@phone2_extension,
								@phone3,
								@phone3_extension,
								@institution_template_role_id,		
								@institution2_template_role_id,	
								@institution3_template_role_id
							) 
							RETURNING id;";
					}

					cmd.Parameters.AddWithValue("@id", citizen.Id);
					cmd.Parameters.AddWithValue("@name", citizen.Name);
					cmd.Parameters.AddWithValue("@paternal_name", citizen.PaternalName);
					cmd.Parameters.AddWithValue("@maternal_name", citizen.MaternalName);
					cmd.Parameters.AddWithValue("@title", (int)citizen.Title);
					cmd.Parameters.AddWithValue("@curp", citizen.CURP);
					cmd.Parameters.AddWithValue("@birthday", citizen.Birthday);
					cmd.Parameters.AddWithValue("@observations", citizen.Observations);
					cmd.Parameters.AddWithValue("@sex", (int)citizen.Sex);
					cmd.Parameters.AddWithValue("@address_id", citizen.Address.Id);
					cmd.Parameters.AddWithValue("@assistant_id", citizen.Assistant.Id);
					cmd.Parameters.AddWithValue("@phone", citizen.Phone.Number);
					cmd.Parameters.AddWithValue("@phone_extension", citizen.Phone.Extension);
					cmd.Parameters.AddWithValue("@phone2", citizen.Phone2.Number);
					cmd.Parameters.AddWithValue("@phone2_extension", citizen.Phone2.Extension);
					cmd.Parameters.AddWithValue("@phone3", citizen.Phone3.Number);
					cmd.Parameters.AddWithValue("@phone3_extension", citizen.Phone3.Extension);
					cmd.Parameters.AddWithValue("@cellphone", citizen.Cellphone);
					cmd.Parameters.AddWithValue("@political_party", (int)citizen.PoliticalParty);
					cmd.Parameters.AddWithValue("@institution_id", citizen.Institution.Id);
					cmd.Parameters.AddWithValue("@institution_role_id", citizen.Role.Id);
					cmd.Parameters.AddWithValue("@email", citizen.Email);
					cmd.Parameters.AddWithValue("@created_by_id", citizen.Author.Id);
					cmd.Parameters.AddWithValue("@created_date", citizen.CreatedDate);
					cmd.Parameters.AddWithValue("@edit_by_id", citizen.LastEditor.Id);
					cmd.Parameters.AddWithValue("@edit_date", citizen.EditDate);
					cmd.Parameters.AddWithValue("@voter_code", citizen.VoterCode);
					cmd.Parameters.AddWithValue("@voter_ocr", citizen.VoterOCR);
					cmd.Parameters.AddWithValue("@voter_cic", citizen.VoterCIC);
					cmd.Parameters.AddWithValue("@voter_section", citizen.VoterSection);
					cmd.Parameters.AddWithValue("@category_id", citizen.Category.Id);
					cmd.Parameters.AddWithValue("@institution2_id", citizen.Institution2.Id);
					cmd.Parameters.AddWithValue("@institution3_id", citizen.Institution3.Id);
					cmd.Parameters.AddWithValue("@institution2_role_id", citizen.Role2.Id);
					cmd.Parameters.AddWithValue("@institution3_role_id", citizen.Role3.Id);
					cmd.Parameters.AddWithValue("@attention_required", false); // editing should always set attention required to false
					cmd.Parameters.AddWithValue("@is_political_activist", citizen.IsPoliticalActivist);
					cmd.Parameters.AddWithValue("@political_register_date", citizen.PoliticalRegisterDate);
					cmd.Parameters.AddWithValue("@institution_template_role_id", citizen.Role.InstitutionTemplateId);
					cmd.Parameters.AddWithValue("@institution2_template_role_id", citizen.Role2.InstitutionTemplateId);
					cmd.Parameters.AddWithValue("@institution3_template_role_id", citizen.Role3.InstitutionTemplateId);

					if (is_update)
					{
						cmd.ExecuteNonQuery();
					}
					else
					{
						citizen.Id = (Int32)(Int64)cmd.ExecuteScalar();
					}
				}
			}

			if (error == 0)
				EventLogHandler.AddEventLog(is_update ? TEventLogType.citizen_edit : TEventLogType.citizen_add, citizen.LastEditor.Id, citizen.Id, TEntityType.citizen, citizen, citizen.EditDate);

			tran.Commit();

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error SetCitizenAttentionRequired(int citizen_id, bool attention_required)
		{
			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("UPDATE citizens SET attention_required = @attention_required WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", citizen_id);
				cmd.Parameters.AddWithValue("@attention_required", attention_required);

				cmd.ExecuteNonQuery();
			}

			StringBuilder log_message = new StringBuilder();

			log_message.AppendLine($"GCRM v{BConstants.GetProductVersion()} ACTION LOG");
			log_message.AppendLine($"==================================================");
			log_message.AppendLine($"evento:  {BConstants.GetEventLogTypeName(TEventLogType.citizen_attention_required)}");
			log_message.AppendLine($"fecha/hora:   {DateTime.Now}");
			log_message.AppendLine($"entidad: ");
			log_message.AppendLine($"ciudadano id: \t{citizen_id}");
			log_message.AppendLine($"atención requerida: \t{attention_required}");
			log_message.AppendLine($"==================================================");

			EventLogHandler.AddEventLog(TEventLogType.citizen_attention_required, Session.User.Id, citizen_id, TEntityType.citizen, log_message.ToString(), DateTime.Now);

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetCitizens(out List<TCitizen> citizen_list)
		{
			citizen_list = new List<TCitizen>();

			var conn = ConnectionPool.GetConnection();

			string sql = @"
				SELECT 
					c.*, 
					u.name as author_name, 
					i.name as institution_name,
					i.society_sector_type as institution_society_sector_type,
					i.description as institution_description,
					i.category_id as institution_category_id,
					ic.name as institution_category_name,
					ic.description as institution_category_description,
					ir.name as institution_role_name,
					ir.description as institution_role_description,
					a.*,
					c_self.name as assistant_name,
					c_self.paternal_name as assistant_paternal_name,
					c_self.maternal_name as assistant_maternal_name,
					c_self.phone as assistant_phone,
					c_self.phone_extension as assistant_phone_extension,
					c_self.cellphone as assistant_cellphone,
					cc.name as category_name,
					u2.name as editor_name,

					i2.name as institution2_name,
					i2.society_sector_type as institution2_society_sector_type,
					i2.description as institution2_description,
					i2.category_id as institution2_category_id,
					ic2.name as institution2_category_name,
					ic2.description as institution2_category_description,
					ir2.name as institution2_role_name,
					ir2.description as institution2_role_description,

					i3.name as institution3_name,	
					i3.society_sector_type as institution3_society_sector_type,
					i3.description as institution3_description,
					i3.category_id as institution3_category_id,
					ic3.name as institution3_category_name,	
					ic3.description as institution3_category_description,
					ir3.name as institution3_role_name,
					ir3.description as institution3_role_description
				FROM 
					citizens c 
					LEFT JOIN users u ON c.created_by_id = u.id 
					LEFT JOIN institutions i ON c.institution_id = i.id 
					LEFT JOIN institution_categories ic ON i.category_id = ic.id
					LEFT JOIN institution_roles ir ON c.institution_role_id = ir.id
					LEFT JOIN addresses a ON c.address_id = a.id
					LEFT JOIN citizens c_self ON c.assistant_id = c.id
					LEFT JOIN citizen_categories cc ON c.citizen_category_id = cc.id 
					LEFT JOIN users u2 ON c.edit_by_id = u2.id
					LEFT JOIN institutions i2 ON c.institution2_id = i2.id 
					LEFT JOIN institution_categories ic2 ON i2.category_id = ic2.id
					LEFT JOIN institution_roles ir2 ON c.institution_role_id = ir2.id
					LEFT JOIN institutions i3 ON c.institution_id = i3.id 
					LEFT JOIN institution_categories ic3 ON i3.category_id = ic3.id
					LEFT JOIN institution_roles ir3 ON c.institution_role_id = ir3.id
				ORDER BY name, paternal_name, maternal_name;
			";

			using (var cmd = new NpgsqlCommand(sql, conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while (reader.Read())
				{
					TCitizen citizen = new TCitizen();

					citizen.FillFromReader(reader);

					if (citizen.Assistant.Id != 0)
					{
						citizen.Assistant.Name = reader.GetString(reader.GetOrdinal("assistant_name"));
						citizen.Assistant.Name = reader.GetString(reader.GetOrdinal("assistant_paternal_name"));
						citizen.Assistant.Name = reader.GetString(reader.GetOrdinal("assistant_maternal_name"));
						citizen.Assistant.Name = reader.GetString(reader.GetOrdinal("assistant_phone"));
						citizen.Assistant.Name = reader.GetString(reader.GetOrdinal("assistant_phone_extension"));
						citizen.Assistant.Name = reader.GetString(reader.GetOrdinal("assistant_cellphone"));
					}

					if (citizen.Institution.Id != 0)
					{
						citizen.Institution.Name = reader.GetString(reader.GetOrdinal("institution_name"));
						citizen.Institution.Sector = (TSocietySector)reader.GetInt32(reader.GetOrdinal("institution_society_sector_type"));
						citizen.Institution.Description = reader.GetString(reader.GetOrdinal("institution_description"));
						citizen.Institution.Category.Id = reader.GetInt32(reader.GetOrdinal("institution_category_id"));

						if (citizen.Institution.Category.Id != 0)
						{
							citizen.Institution.Category.Name = reader.GetString(reader.GetOrdinal("institution_category_name"));
							citizen.Institution.Category.Description = reader.GetString(reader.GetOrdinal("institution_category_description"));
						}
					}

					if (citizen.Role.Id != 0)
					{
						citizen.Role.Name = reader.GetString(reader.GetOrdinal("institution_role_name"));
						citizen.Role.Description = reader.GetString(reader.GetOrdinal("institution_role_description"));
					}

					if (citizen.Institution2.Id != 0)
					{
						citizen.Institution2.Name = reader.GetString(reader.GetOrdinal("institution2_name"));
						citizen.Institution2.Sector = (TSocietySector)reader.GetInt32(reader.GetOrdinal("institution2_society_sector_type"));
						citizen.Institution2.Description = reader.GetString(reader.GetOrdinal("institution2_description"));
						citizen.Institution2.Category.Id = reader.GetInt32(reader.GetOrdinal("institution2_category_id"));

						if (citizen.Institution2.Category.Id != 0)
						{
							citizen.Institution2.Category.Name = reader.GetString(reader.GetOrdinal("institution2_category_name"));
							citizen.Institution2.Category.Description = reader.GetString(reader.GetOrdinal("institution2_category_description"));
						}
					}

					if (citizen.Role2.Id != 0)
					{
						citizen.Role2.Name = reader.GetString(reader.GetOrdinal("institution2_role_name"));
						citizen.Role2.Description = reader.GetString(reader.GetOrdinal("institution2_role_description"));
					}

					if (citizen.Institution3.Id != 0)
					{
						citizen.Institution3.Name = reader.GetString(reader.GetOrdinal("institution3_name"));
						citizen.Institution3.Sector = (TSocietySector)reader.GetInt32(reader.GetOrdinal("institution3_society_sector_type"));
						citizen.Institution3.Description = reader.GetString(reader.GetOrdinal("institution3_description"));
						citizen.Institution3.Category.Id = reader.GetInt32(reader.GetOrdinal("institution3_category_id"));

						if (citizen.Institution3.Category.Id != 0)
						{
							citizen.Institution3.Category.Name = reader.GetString(reader.GetOrdinal("institution3_category_name"));
							citizen.Institution3.Category.Description = reader.GetString(reader.GetOrdinal("institution3_category_description"));
						}
					}

					if (citizen.Role3.Id != 0)
					{
						citizen.Role3.Name = reader.GetString(reader.GetOrdinal("institution3_role_name"));
						citizen.Role3.Description = reader.GetString(reader.GetOrdinal("institution3_role_description"));
					}

					if (citizen.Address.Id != 0)
					{
						citizen.Address.Street = reader.GetString(reader.GetOrdinal("street"));
						citizen.Address.Number = reader.GetString(reader.GetOrdinal("number"));
						citizen.Address.InteriorNumber = reader.GetString(reader.GetOrdinal("interior_number"));
						citizen.Address.PostalCode = reader.GetString(reader.GetOrdinal("postal_code"));
						citizen.Address.State = reader.GetString(reader.GetOrdinal("state"));
						citizen.Address.City = reader.GetString(reader.GetOrdinal("city"));
						citizen.Address.Country = (TCountry)reader.GetInt32(reader.GetOrdinal("country_type"));
						citizen.Address.District = reader.GetString(reader.GetOrdinal("district"));
					}

					if (citizen.Author.Id != 0)
					{
						citizen.Author.Name = reader.GetString(reader.GetOrdinal("author_name"));
					}

					if (citizen.LastEditor.Id != 0)
					{
						citizen.LastEditor.Name = reader.GetString(reader.GetOrdinal("editor_name"));
					}

					if (citizen.Category.Id != 0)
					{
						citizen.Category.Name = reader.GetString(reader.GetOrdinal("category_name"));
					}

					citizen_list.Add(citizen);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetCitizensWhosBirhdayFallsOn(DateTime birthday, out List<TCitizen> citizen_list)
		{
			var conn = ConnectionPool.GetConnection();

			Error error = 0;

			citizen_list = new List<TCitizen>();

			string sql = "SELECT Id FROM citizens WHERE EXTRACT(MONTH FROM birthday) = @month AND EXTRACT(DAY FROM birthday) = @day";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@month", birthday.Month);
				cmd.Parameters.AddWithValue("@day", birthday.Day);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						TCitizen citizen;

						GetCitizenById(reader.GetInt32(0), out citizen);

						citizen_list.Add(citizen);
					}
				}
			}

			if (DateTime.IsLeapYear(birthday.Year) && birthday.Month == 2 && birthday.Day == 28) // no funny business february
			{
				List<TCitizen> citizen_list_leap_year;

				error = GetCitizensWhosBirhdayFallsOn(birthday.AddDays(1), out citizen_list_leap_year);

				citizen_list.AddRange(citizen_list_leap_year);
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetCitizenCategoryById(int id, out TCitizenCategory category)
		{
			category = new TCitizenCategory();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizen_categories WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows == false)
					{
						return Error.CitizenCategoryNotFound;
					}

					reader.Read();

					category = new TCitizenCategory();
					category.FillFromReader(reader);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetCitizenCategories(out List<TCitizenCategory> categories)
		{
			categories = new List<TCitizenCategory>();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizen_categories;", conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while(reader.Read())
				{
					TCitizenCategory category = new TCitizenCategory();
					category.FillFromReader(reader);
					categories.Add(category);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error SaveCitizenCategory(TCitizenCategory category, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			var tran = conn.BeginTransaction();

			try
			{
				string sql = "";

				if (is_update)
				{
					sql = @"UPDATE citizen_categories SET name = @name, description = @description WHERE id = @id;";
				}
				else
				{
					sql = @"INSERT INTO citizen_categories(name, description) VALUES (@name, @description);";
				}

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@id", category.Id);
					cmd.Parameters.AddWithValue("@name", category.Name);
					cmd.Parameters.AddWithValue("@description", category.Description);

					cmd.ExecuteNonQuery();
				}
				
				tran.Commit();
			}
			catch (Exception ex)
			{
				tran.Rollback();
			}

			ConnectionPool.ReleaseConnection(ref conn);	

			return 0;
		}

		public static Error DeleteCitizenCategoryById(int id)
		{
			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizens WHERE citizen_category_id = @id;"))
			{
				cmd.Parameters.AddWithValue("@id", id);

				int citizen_with_category = (Int32)(Int64)cmd.ExecuteScalar();

				if (citizen_with_category > 0)
				{
					ConnectionPool.ReleaseConnection(ref conn);
					return Error.CitizenCategoryInUse;
				}

				cmd.CommandText = "DELETE citizen_categories WHERE id = @id;";
				cmd.ExecuteNonQuery();
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	}
}
