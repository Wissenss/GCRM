using Connection;
using Npgsql;
using System.Data;
using System.Data.Common;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace Business
{
	public static class CitizensHandler
	{
		public static Error GetCitizenById(int id, out TCitizen citizen)
		{
			Error error = 0;

			citizen = new TCitizen();

			var conn = ConnectionPool.GetConnection();

			string sql = @"
				WITH ranked_contact_numbers AS (
					SELECT 
						cn.id,
						cn.entity_id,
						cn.number,
						cn.extension,
						cn.carddav_sync,
						cn.contact_number_type,
						ROW_NUMBER() OVER (PARTITION BY cn.entity_id ORDER BY cn.id) AS row_number,
						ROW_NUMBER() OVER (PARTITION BY cn.entity_id, cn.contact_number_type ORDER BY cn.id) AS type_row_number
					FROM
						contact_numbers cn
					WHERE
						entity_type = 1001 AND entity_id = @id
				),

				ranked_institution_roles AS (
					SELECT
						cir.citizen_id,
						cir.position,
						cir.institution_id,
						cir.institution_role_id,
						cir.institution_template_role_id,
						cir.is_institution_template_role,
						is_active,
						is_start_defined,
						started_at,
						is_end_defined,
						ended_at,
						ROW_NUMBER() OVER (PARTITION BY cir.citizen_id ORDER BY cir.position) AS row_number
					FROM
						citizen_institution_roles cir
					WHERE
						cir.citizen_id = @id
				),

				normalized_ranked_institution_roles AS (
					SELECT
						citizen_id,
						MAX(CASE WHEN row_number = 1 THEN institution_id END) AS institution_id,
						MAX(CASE WHEN row_number = 1 THEN institution_role_id END) AS institution_role_id,
						MAX(CASE WHEN row_number = 1 THEN institution_template_role_id END) AS institution_template_role_id,
						(SUM(CASE WHEN row_number = 1 AND is_institution_template_role THEN 1 ELSE 0 END) > 0) AS is_institution_template_role,
						MAX(CASE WHEN row_number = 2 THEN institution_id END) AS institution2_id,
						MAX(CASE WHEN row_number = 2 THEN institution_role_id END) AS institution2_role_id,
						MAX(CASE WHEN row_number = 2 THEN institution_template_role_id END) AS institution2_template_role_id,
						(SUM(CASE WHEN row_number = 2 AND is_institution_template_role THEN 1 ELSE 0 END) > 0) AS is_institution2_template_role,
						MAX(CASE WHEN row_number = 3 THEN institution_id END) AS institution3_id,
						MAX(CASE WHEN row_number = 3 THEN institution_role_id END) AS institution3_role_id,
						MAX(CASE WHEN row_number = 3 THEN institution_template_role_id END) AS institution3_template_role_id,
						(SUM(CASE WHEN row_number = 3 AND is_institution_template_role THEN 1 ELSE 0 END) > 0) AS is_institution3_template_role
					FROM ranked_institution_roles
					GROUP BY citizen_id
				),

				normalized_ranked_contact_numbers AS (
					SELECT
						entity_id,
						MAX(CASE WHEN row_number = 1 THEN id END)                AS phone1_id,
						MAX(CASE WHEN row_number = 1 THEN number END)            AS phone1_number,
						MAX(CASE WHEN row_number = 1 THEN extension END)         AS phone1_number_extension,
						MAX(CASE WHEN row_number = 2 THEN id END)                AS phone2_id,						
						MAX(CASE WHEN row_number = 2 THEN number END)            AS phone2_number,
						MAX(CASE WHEN row_number = 2 THEN extension END)         AS phone2_number_extension,
						MAX(CASE WHEN row_number = 3 THEN id END)                AS phone3_id,						
						MAX(CASE WHEN row_number = 3 THEN number END)            AS phone3_number,
						MAX(CASE WHEN row_number = 3 THEN extension END)         AS phone3_number_extension,
						MAX(CASE WHEN contact_number_type = 20 AND type_row_number = 1 THEN id END)     AS cellphone_id,
						MAX(CASE WHEN contact_number_type = 20 AND type_row_number = 1 THEN number END) AS cellphone,
						MAX(CASE WHEN row_number = 5 THEN id END)                AS carddav_sync_id,
						MAX(CASE WHEN row_number = 5 THEN carddav_sync::int END) AS carddav_sync_enabled,
						MAX(CASE WHEN row_number = 5 THEN number END)            AS carddav_sync_number,
						MAX(CASE WHEN row_number = 5 THEN extension END)         AS carddav_sync_extension
					FROM ranked_contact_numbers
					GROUP BY entity_id
				)

				SELECT 
					c.id,
					c.name,
					c.paternal_name,
					c.maternal_name,
					c.title_type,
					c.curp,
					c.birthday,
					c.observations,
					c.sex_type,
					c.address_id,
					c.assistant_id,
					c.political_party_type,
					COALESCE(nrir.institution_id, 0) AS institution_id,
					COALESCE(nrir.institution_role_id, nrir.institution_template_role_id, 0) AS institution_role_id,
					c.email,
					c.created_by_id,
					c.created_date,
					c.edit_by_id,
					c.edit_date,
					c.voter_code,
					c.voter_ocr,
					c.voter_cic,
					c.voter_section,
					c.citizen_category_id,
					COALESCE(nrir.institution2_id, 0) AS institution2_id,
					COALESCE(nrir.institution2_role_id, nrir.institution2_template_role_id, 0) AS institution2_role_id,
					COALESCE(nrir.institution3_id, 0) AS institution3_id,
					COALESCE(nrir.institution3_role_id, nrir.institution3_template_role_id, 0) AS institution3_role_id,
					c.attention_required,
					c.is_political_activist,
					c.political_register_date,
					COALESCE(itr.institution_template_id, 0) AS institution_template_role_id,
					COALESCE(itr2.institution_template_id, 0) AS institution2_template_role_id,
					COALESCE(itr3.institution_template_id, 0) AS institution3_template_role_id,
					c.known_birthday,
					c.known_birthyear,
					c.known_political_register_date,

					c.verified_by_id,
					c.verified_at,
					c.verified,

					a.id AS address_id,
					a.street AS address_street,
					a.number AS address_number,
					a.interior_number AS address_interior_number,
					a.postal_code AS address_postal_code,
					a.state AS address_state,
					a.city AS address_city,
					a.country_type AS address_country_type,
					a.district AS address_district,
					
					COALESCE(nrcn.phone1_id, 0) AS phone1_id,
					COALESCE(nrcn.phone1_number, '') AS phone1_number,
					COALESCE(nrcn.phone1_number_extension, '') AS phone1_number_extension,
					COALESCE(nrcn.phone2_id, 0) AS phone2_id,					
					COALESCE(nrcn.phone2_number, '') AS phone2_number,
					COALESCE(nrcn.phone2_number_extension, '') AS phone2_number_extension,
					COALESCE(nrcn.phone3_id, 0) AS phone3_id,					
					COALESCE(nrcn.phone3_number, '') AS phone3_number,	
					COALESCE(nrcn.phone3_number_extension, '') AS phone3_number_extension,
					COALESCE(nrcn.cellphone_id, 0) AS cellphone_id,					
					COALESCE(nrcn.cellphone, '') AS cellphone,
					COALESCE(nrcn.carddav_sync_id, 0) AS carddav_sync_id,					
					COALESCE(nrcn.carddav_sync_number, '') AS carddav_sync_number,
					COALESCE(nrcn.carddav_sync_extension, '') AS carddav_sync_extension,
					COALESCE(nrcn.carddav_sync_enabled, 0) <> 0 AS carddav_sync_enabled,

					COALESCE(cr.id, 0) AS UserRelationshipId
				FROM 
					citizens c
					LEFT JOIN citizen_relationships cr ON (cr.user_id = @userId AND cr.related_citizen_id = c.id)
					LEFT JOIN addresses a ON a.id = c.address_id
					LEFT JOIN normalized_ranked_contact_numbers nrcn ON c.id = nrcn.entity_id
					LEFT JOIN normalized_ranked_institution_roles nrir ON c.id = nrir.citizen_id
					LEFT JOIN institution_template_roles itr ON nrir.institution_template_role_id = itr.id
					LEFT JOIN institution_template_roles itr2 ON nrir.institution2_template_role_id = itr2.id
					LEFT JOIN institution_template_roles itr3 ON nrir.institution3_template_role_id = itr3.id
				WHERE
					c.id = @id;
			";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@userId", Session.User.Id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						citizen.FillFromReader(reader);

						citizen.Phone.Id = reader.GetInt32("phone1_id");
						citizen.Phone.Number = reader.GetString("phone1_number");
						citizen.Phone.Extension = reader.GetString("phone1_number_extension");
						citizen.Phone2.Id = reader.GetInt32("phone2_id");
						citizen.Phone2.Number = reader.GetString("phone2_number");
						citizen.Phone2.Extension = reader.GetString("phone2_number_extension");
						citizen.Phone3.Id = reader.GetInt32("phone3_id");
						citizen.Phone3.Number = reader.GetString("phone3_number");
						citizen.Phone3.Extension = reader.GetString("phone3_number_extension");
						citizen.Cellphone.Id = reader.GetInt32("cellphone_id");
						citizen.Cellphone.Number = reader.GetString("cellphone");
						citizen.CardDavSyncNumber.Id = reader.GetInt32("carddav_sync_id");
						citizen.CardDavSyncNumber.Number = reader.GetString("carddav_sync_number");
						citizen.CardDavSyncNumber.Extension = reader.GetString("carddav_sync_extension");
						citizen.CardDavSyncNumber.CarddavSync = reader.GetBoolean("carddav_sync_enabled");

						if (error == 0 && citizen.Assistant.Id != 0)
							error = GetCitizenAssistantById(citizen.Assistant.Id, out citizen.Assistant);

						if (error == 0 && citizen.Address.Id != 0)
						{
							citizen.Address.Street = reader.GetString("address_street");
							citizen.Address.Number = reader.GetString("address_number");
							citizen.Address.InteriorNumber = reader.GetString("address_interior_number");
							citizen.Address.PostalCode = reader.GetString("address_postal_code");
							citizen.Address.State = reader.GetString("address_state");
							citizen.Address.City = reader.GetString("address_city");
							citizen.Address.Country = (TCountry)reader.GetInt32("address_country_type");
							citizen.Address.District = reader.GetString("address_district");
						}

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

						if (error == 0 && citizen.VerifiedBy.Id != 0)
							error = UsersHandler.GetUserById(citizen.VerifiedBy.Id, out citizen.VerifiedBy);

						if (error == 0)
						{
							citizen.UserRelationship.Id = reader.GetInt32("UserRelationshipId");

							if (citizen.UserRelationship.Id != 0)
								error = GetCitizenRelationshipById(citizen.UserRelationship.Id, out citizen.UserRelationship);
						}
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

			var tran = conn.BeginTransaction();

			TCitizen citizen;

			error = GetCitizenById(id, out citizen);

			// check there is no citizen having this as assistant
			if (error == 0)
			{
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
			}

			// check there is no citizen network having this as a member
			if (error == 0)
			{
				using (var cmd = new NpgsqlCommand("SELECT * FROM citizennetwork_citizens WHERE citizen_id = @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							error = Error.CitizenInUseOnNetwork;
						}
					}
				}
			}

			if (error == 0)
			{
				using (var cmd = new NpgsqlCommand("DELETE FROM citizens WHERE id = @id;", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);

					cmd.ExecuteNonQuery();
				}
			}

			// delete related contact numbers
			if (error == 0)
			{
				using (var cmd = new NpgsqlCommand("DELETE FROM contact_numbers WHERE entity_id = @id AND entity_type = @type;", conn))
				{
					cmd.Parameters.AddWithValue("@id", citizen.Id);
					cmd.Parameters.AddWithValue("@type", (int)TEntityType.citizen);

					cmd.ExecuteNonQuery();
				}
			}

			// delete related address
			if (error == 0)
			{
				error = AddressesHandler.DeleteAddressById(citizen.Address.Id, conn);
			}
			
			if (error == 0)
			{
				EventLogHandler.AddEventLog(TEventLogType.citizen_delete, Session.User.Id, id, TEntityType.citizen, citizen, DateTime.Now);
				
				tran.Commit();
			}
			else
			{
				tran.Rollback();
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetCitizenAssistantById(int id, out TCitizen citizen_assistant)
		{
			Error error = 0;

			citizen_assistant = new TCitizen();

			var conn = ConnectionPool.GetConnection();

			string sql = @"
				WITH ranked_contact_numbers AS (
					SELECT
						cn.number,
						cn.extension,
						cn.contact_number_type,
						ROW_NUMBER() OVER (ORDER BY cn.id) AS row_number,
						ROW_NUMBER() OVER (PARTITION BY cn.contact_number_type ORDER BY cn.id) AS type_row_number
					FROM
						contact_numbers cn
					WHERE
						entity_type = 1001 AND entity_id = @id
				),

				normalized_ranked_contact_numbers AS (
					SELECT
						MAX(CASE WHEN row_number = 1 THEN number END) AS phone_number,
						MAX(CASE WHEN row_number = 1 THEN extension END) AS phone_extension,
						MAX(CASE WHEN contact_number_type = 20 AND type_row_number = 1 THEN number END) AS cellphone
					FROM ranked_contact_numbers
				)

				SELECT
					c.id,
					c.name,
					c.paternal_name,
					c.maternal_name,
					COALESCE(nrcn.phone_number, '') AS phone_number,
					COALESCE(nrcn.phone_extension, '') AS phone_extension,
					COALESCE(nrcn.cellphone, '') AS cellphone
				FROM
					citizens c
					LEFT JOIN normalized_ranked_contact_numbers nrcn ON TRUE
				WHERE
					c.id = @id;
			";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						citizen_assistant.Id = reader.GetInt32("id");
						citizen_assistant.Name = reader.GetString("name");
						citizen_assistant.PaternalName = reader.GetString("paternal_name");
						citizen_assistant.MaternalName = reader.GetString("maternal_name");
						citizen_assistant.Phone.Number = reader.GetString("phone_number");
						citizen_assistant.Phone.Extension = reader.GetString("phone_extension");
						citizen_assistant.Cellphone.Number = reader.GetString("cellphone");
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

			// ensure the carddav sync number is not repeated
			if (citizen.CardDavSyncNumber.CarddavSync == true)
			{
				using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM contact_numbers WHERE carddav_sync = TRUE AND number = @number AND extension = @extension AND id <> @id", conn))
				{
					cmd.Parameters.AddWithValue("@id", citizen.CardDavSyncNumber.Id);
					cmd.Parameters.AddWithValue("@number", citizen.CardDavSyncNumber.Number);
					cmd.Parameters.AddWithValue("@extension", citizen.CardDavSyncNumber.Extension);

					int contact_numbers_repeated = (Int32)(Int64)cmd.ExecuteScalar();

					if (contact_numbers_repeated > 0)
					{
						error = Error.ContactNumberWithCarddavSyncEnabledRepeated;
					}
				}
			}

			// save address
			if (error == 0)
			{
				error = AddressesHandler.SaveAddress(citizen.Address, is_update, out citizen.Address.Id, conn);
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
								-- phone=@phone,
								-- phone_extension=@phone_extension,
								-- cellphone=@cellphone,
								political_party_type=@political_party,
								email=@email,
								edit_by_id=@edit_by_id,
								edit_Date=@edit_date,
								voter_code = @voter_code,
								voter_ocr = @voter_ocr,
								voter_cic = @voter_cic,
								voter_section = @voter_section,
								citizen_category_id = @category_id,
								is_political_activist = @is_political_activist,
								political_register_date = @political_register_date,
								-- phone2 = @phone2,
								-- phone2_extension = @phone2_extension,
								-- phone3 = @phone3,
								-- phone3_extension = @phone3_extension,
								known_birthday = @known_birthday,
								known_birthyear = @known_birthyear,
								known_political_register_date = @known_political_register_date,
								verified_by_id = @verified_by_id,
								verified_at = @verified_at,
								verified = @verified
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
								-- phone,
								-- phone_extension,
								-- cellphone,
								political_party_type,
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
								attention_required,
								is_political_activist,
								political_register_date,
								-- phone2,
								-- phone2_extension,
								-- phone3,
								-- phone3_extension,
								known_birthday,
								known_birthyear,
								verified_by_id,
								verified_at,
								verified
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
								-- @phone,
								-- @phone_extension,
								-- @cellphone,
								@political_party,
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
								@attention_required,
								@is_political_activist,
								@political_register_date,
								-- @phone2,
								-- @phone2_extension,
								-- @phone3,
								-- @phone3_extension,
								@known_birthday,
								@known_birthyear,
								@verified_by_id,
								@verified_at,
								@verified
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
					cmd.Parameters.AddWithValue("@political_party", (int)citizen.PoliticalParty);
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
					// attention_required is not part of the UPDATE, so editing a citizen never clears it; it is only set on creation and toggled via SetCitizenAttentionRequired
					cmd.Parameters.AddWithValue("@attention_required", false);
					cmd.Parameters.AddWithValue("@is_political_activist", citizen.IsPoliticalActivist);
					cmd.Parameters.AddWithValue("@political_register_date", citizen.PoliticalRegisterDate);
					cmd.Parameters.AddWithValue("@known_birthday", citizen.KnownBirthday);
					cmd.Parameters.AddWithValue("@known_birthyear", citizen.KnownBirthyear);
					cmd.Parameters.AddWithValue("@known_political_register_date", citizen.KnownPoliticalRegisterDate);
					cmd.Parameters.AddWithValue("@verified_by_id", citizen.VerifiedBy.Id == 0 ? (object)DBNull.Value : citizen.VerifiedBy.Id);
					cmd.Parameters.AddWithValue("@verified_at", citizen.Verified ? (object)citizen.VerifiedAt : DBNull.Value);
					cmd.Parameters.AddWithValue("@verified", citizen.Verified);

					if (is_update)
					{
						cmd.ExecuteNonQuery();
					}
					else
					{
						citizen.Id = (Int32)(Int64)cmd.ExecuteScalar();
					}

					citizen.UserRelationship.User = Session.User;
					citizen.UserRelationship.Citizen.Id = Session.User.Citizen.Id;
					citizen.UserRelationship.RelatedTo.Id = citizen.Id;
				}
			}

			// save institution roles
			using (var cmd = new NpgsqlCommand("DELETE FROM citizen_institution_roles WHERE citizen_id = @citizen_id;", conn))
			{
				cmd.Parameters.AddWithValue("@citizen_id", citizen.Id);

				cmd.ExecuteNonQuery();
			}

			if (error == 0)
			{
				var institution_roles = new[] {
					(position: 1, institution: citizen.Institution, role: citizen.Role),
					(position: 2, institution: citizen.Institution2, role: citizen.Role2),
					(position: 3, institution: citizen.Institution3, role: citizen.Role3)
				};

				string sql_institution_role = @"
					INSERT INTO citizen_institution_roles(
						position,
						citizen_id,
						institution_id,
						institution_role_id,
						institution_template_role_id,
						is_institution_template_role
					) VALUES (
						@position,
						@citizen_id,
						@institution_id,
						@institution_role_id,
						@institution_template_role_id,
						@is_institution_template_role
					);
				";

				using (var batch = conn.CreateBatch())
				{
					foreach (var (position, institution, role) in institution_roles)
					{
						if (institution.Id == 0)
							continue;

						var cmd = new NpgsqlBatchCommand(sql_institution_role);

						cmd.Parameters.AddWithValue("@position", position);
						cmd.Parameters.AddWithValue("@citizen_id", citizen.Id);
						cmd.Parameters.AddWithValue("@institution_id", institution.Id);
						cmd.Parameters.AddWithValue("@institution_role_id", (!role.IsTemplateRole && role.Id != 0) ? (object)role.Id : DBNull.Value);
						cmd.Parameters.AddWithValue("@institution_template_role_id", (role.IsTemplateRole && role.Id != 0) ? (object)role.Id : DBNull.Value);
						cmd.Parameters.AddWithValue("@is_institution_template_role", role.IsTemplateRole);

						batch.BatchCommands.Add(cmd);
					}

					if (batch.BatchCommands.Count > 0)
						batch.ExecuteNonQuery();
				}
			}

			// save contacts numbers
			using (var cmd = new NpgsqlCommand("DELETE FROM contact_numbers WHERE entity_id = @entity_id AND entity_type = 1001;", conn))
			{
				cmd.Parameters.AddWithValue("@entity_id", citizen.Id);

				cmd.ExecuteNonQuery();
			}

			if (error == 0)
			{
				TCitizenContactNumber[] phones = new TCitizenContactNumber[] {
					citizen.Phone,
					citizen.Phone2,
					citizen.Phone3,
					citizen.Cellphone,
					citizen.CardDavSyncNumber
				};

				string sql = "";

				sql = @"
					INSERT INTO
						contact_numbers(
							contact_number_type,
							number,
							extension,
							carddav_sync,
							entity_id,
							entity_type
					) VALUES (
							@type,
							@number,
							@extension,
							@carddav_sync,
							@entity_id,
							1001
					)
				";

				using (var batch = conn.CreateBatch())
				{
					foreach (TCitizenContactNumber cn in phones) {
						var cmd = new NpgsqlBatchCommand(sql);

						cmd.Parameters.AddWithValue("@type", (int)cn.ContactNumberType);
						cmd.Parameters.AddWithValue("@number", cn.Number);
						cmd.Parameters.AddWithValue("@extension", cn.Extension);
						cmd.Parameters.AddWithValue("@carddav_sync", cn.CarddavSync);
						cmd.Parameters.AddWithValue("@entity_id", citizen.Id);
						cmd.Parameters.AddWithValue("@id", cn.Id);

						batch.BatchCommands.Add(cmd);
					}

					batch.ExecuteNonQuery();
				}
			}

			// save the relationship
			if (error == 0 && citizen.UserRelationship.Enabled)
			{
				error = SaveCitizenRelationship(citizen.UserRelationship, citizen.UserRelationship.Id != 0);
			}
			else if (error == 0 && citizen.UserRelationship.Id != 0)
			{
				error = SetEnabledCitizenRelationship(citizen.UserRelationship.Id, citizen.UserRelationship.Enabled);
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

		public static Error GetAttentionRequiredCitizenCount(out int count)
		{
			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM citizens WHERE attention_required = TRUE;", conn))
			{
				count = (Int32)(Int64)cmd.ExecuteScalar();
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		private static Error GetCitizensWithCondition(string condition, out List<TCitizen> citizen_list)
		{
			citizen_list = new List<TCitizen>();

			var conn = ConnectionPool.GetConnection();

			string sql = $@"

				WITH ranked_contact_numbers AS (
					SELECT 
						cn.entity_id,
						cn.number,
						cn.extension,
						cn.carddav_sync,
						cn.contact_number_type,
						ROW_NUMBER() OVER (PARTITION BY cn.entity_id ORDER BY cn.id) AS row_number,
						ROW_NUMBER() OVER (PARTITION BY cn.entity_id, cn.contact_number_type ORDER BY cn.id) AS type_row_number
					FROM
						contact_numbers cn
					WHERE
						entity_type = 1001
				),

				normalized_ranked_contact_numbers AS (
					SELECT
						entity_id,
						MAX(CASE WHEN row_number = 1 THEN number END)    AS phone1_number,
						MAX(CASE WHEN row_number = 1 THEN extension END) AS phone1_number_extension,
						MAX(CASE WHEN row_number = 2 THEN number END)    AS phone2_number,
						MAX(CASE WHEN row_number = 2 THEN extension END) AS phone2_number_extension,
						MAX(CASE WHEN row_number = 3 THEN number END)    AS phone3_number,
						MAX(CASE WHEN row_number = 3 THEN extension END) AS phone3_number_extension,
						MAX(CASE WHEN contact_number_type = 20 AND type_row_number = 1 THEN number END) AS cellphone,
						MAX(CASE WHEN row_number = 5 THEN carddav_sync::int END) AS carddav_sync_enabled,
						MAX(CASE WHEN row_number = 5 THEN number END)    AS carddav_sync_number,
						MAX(CASE WHEN row_number = 5 THEN extension END) AS carddav_sync_extension
					FROM ranked_contact_numbers
					GROUP BY entity_id
				),

				ranked_institution_roles AS(
					SELECT
						cir.citizen_id,
						cir.position,
						cir.institution_id,
						cir.institution_role_id,
						cir.institution_template_role_id,
						cir.is_institution_template_role,
						is_active,
						is_start_defined,
						started_at,
						is_end_defined,
						ended_at,
						ROW_NUMBER() OVER (PARTITION BY cir.citizen_id ORDER BY cir.position) AS row_number
					FROM
						citizen_institution_roles cir
				),

				normalized_ranked_institution_roles AS(
					SELECT
						citizen_id,
						MAX(CASE WHEN row_number = 1 THEN institution_id END) AS institution_id,
						MAX(CASE WHEN row_number = 1 THEN institution_role_id END) AS institution_role_id,
						MAX(CASE WHEN row_number = 1 THEN institution_template_role_id END) AS institution_template_role_id,
						(SUM(CASE WHEN row_number = 1 AND is_institution_template_role THEN 1 ELSE 0 END) > 0)AS is_institution_template_role,
						MAX(CASE WHEN row_number = 2 THEN institution_id END) AS institution2_id,
						MAX(CASE WHEN row_number = 2 THEN institution_role_id END) AS institution2_role_id,
						MAX(CASE WHEN row_number = 2 THEN institution_template_role_id END) AS institution2_template_role_id,
						(SUM(CASE WHEN row_number = 2 AND is_institution_template_role THEN 1 ELSE 0 END) > 0) AS is_institution2_template_role,
						MAX(CASE WHEN row_number = 3 THEN institution_id END) AS institution3_id,
						MAX(CASE WHEN row_number = 3 THEN institution_role_id END) AS institution3_role_id,
						MAX(CASE WHEN row_number = 3 THEN institution_template_role_id END) AS institution3_template_role_id,
						(SUM(CASE WHEN row_number = 3 AND is_institution_template_role THEN 1 ELSE 0 END) > 0) AS is_institution3_template_role
					FROM ranked_institution_roles
					GROUP BY citizen_id
				)

				SELECT
					c.id,
					c.name,
					c.paternal_name,
					c.maternal_name,
					c.title_type,
					c.curp,
					c.birthday,
					c.observations,
					c.sex_type,
					c.address_id,
					c.assistant_id,
					c.political_party_type,
					COALESCE(nrir.institution_id, 0) AS institution_id,
					COALESCE(nrir.institution_role_id, nrir.institution_template_role_id, 0) AS institution_role_id,
					c.email,
					c.created_by_id,
					c.created_date,
					c.edit_by_id,
					c.edit_date,
					c.voter_code,
					c.voter_ocr,
					c.voter_cic,
					c.voter_section,
					c.citizen_category_id,
					COALESCE(nrir.institution2_id, 0) AS institution2_id,
					COALESCE(nrir.institution2_role_id, nrir.institution2_template_role_id, 0) AS institution2_role_id,
					COALESCE(nrir.institution3_id, 0) AS institution3_id,
					COALESCE(nrir.institution3_role_id, nrir.institution3_template_role_id, 0) AS institution3_role_id,
					c.attention_required,
					c.is_political_activist,
					c.political_register_date,
					COALESCE(itr.institution_template_id, 0) AS institution_template_role_id,
					COALESCE(itr2.institution_template_id, 0) AS institution2_template_role_id,
					COALESCE(itr3.institution_template_id, 0) AS institution3_template_role_id,
					c.known_birthday,
					c.known_birthyear,
					c.known_political_register_date,
					c.verified_by_id,
					c.verified_at,
					c.verified,

					u.name as author_name,
					i.name as institution_name,
					i.society_sector_type as institution_society_sector_type,
					i.description as institution_description,
					i.category_id as institution_category_id,
					ic.name as institution_category_name,
					ic.description as institution_category_description,
					ir.name as institution_role_name,
					ir.description as institution_role_description,

					a.street,
					a.number,
					a.interior_number,
					a.postal_code,
					a.state,
					a.city,
					a.country_type,
					a.district,

					COALESCE(nrcn.phone1_number, '') AS phone1_number,
					COALESCE(nrcn.phone1_number_extension, '') AS phone1_number_extension,
					COALESCE(nrcn.phone2_number, '') AS phone2_number,
					COALESCE(nrcn.phone2_number_extension, '') AS phone2_number_extension,
					COALESCE(nrcn.phone3_number, '') AS phone3_number,
					COALESCE(nrcn.phone3_number_extension, '') AS phone3_number_extension,
					COALESCE(nrcn.cellphone, '') AS contact_cellphone,
					COALESCE(nrcn.carddav_sync_number, '') AS carddav_sync_number,
					COALESCE(nrcn.carddav_sync_extension, '') AS carddav_sync_extension,
					COALESCE(nrcn.carddav_sync_enabled, 0) <> 0 AS carddav_sync_enabled,

					c_self.name as assistant_name,
					c_self.paternal_name as assistant_paternal_name,
					c_self.maternal_name as assistant_maternal_name,
					cc.name as category_name,
					u2.name as editor_name,
					u3.name as verified_by_name,

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
					ir3.description as institution3_role_description,

					itr.name as institution_template_role_name,
					itr.description as institution_template_role_description,
					itr2.name as institution2_template_role_name,
					itr2.description as institution2_template_role_description,
					itr3.name as institution3_template_role_name,
					itr3.description as institution3_template_role_description
				FROM 
					citizens c 
					LEFT JOIN citizen_categories cc ON c.citizen_category_id = cc.id
					LEFT JOIN citizens c_self ON c.assistant_id = c_self.id
					LEFT JOIN users u ON c.created_by_id = u.id
					LEFT JOIN users u2 ON c.edit_by_id = u2.id
					LEFT JOIN users u3 ON c.verified_by_id = u3.id

					LEFT JOIN normalized_ranked_contact_numbers nrcn ON (c.id = nrcn.entity_id)

					LEFT JOIN normalized_ranked_institution_roles nrir ON (c.id = nrir.citizen_id)

					LEFT JOIN institutions i ON nrir.institution_id = i.id
					LEFT JOIN institution_categories ic ON i.category_id = ic.id
					LEFT JOIN institution_roles ir ON nrir.institution_role_id = ir.id
					LEFT JOIN institution_template_roles itr ON nrir.institution_template_role_id = itr.id

					LEFT JOIN institutions i2 ON nrir.institution2_id = i2.id
					LEFT JOIN institution_categories ic2 ON i2.category_id = ic2.id
					LEFT JOIN institution_roles ir2 ON nrir.institution2_role_id = ir2.id
					LEFT JOIN institution_template_roles itr2 ON nrir.institution2_template_role_id = itr2.id

					LEFT JOIN institutions i3 ON nrir.institution3_id = i3.id
					LEFT JOIN institution_categories ic3 ON i3.category_id = ic3.id
					LEFT JOIN institution_roles ir3 ON nrir.institution3_role_id = ir3.id
					LEFT JOIN institution_template_roles itr3 ON nrir.institution3_template_role_id = itr3.id

					LEFT JOIN addresses a ON c.address_id = a.id
				WHERE
					TRUE
          {condition}
				ORDER BY name, paternal_name, maternal_name;
			";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				using (var reader = cmd.ExecuteReader()) 
				{
					while (reader.Read())
					{
						TCitizen citizen = new TCitizen();
						
						citizen.FillFromReader(reader);
						
						if (citizen.Assistant.Id != 0)
						{
							citizen.Assistant.Name = reader.GetString("assistant_name");
							citizen.Assistant.PaternalName = reader.GetString("assistant_paternal_name");
							citizen.Assistant.MaternalName = reader.GetString("assistant_maternal_name");
						}

						if (citizen.Institution.Id != 0)
						{
							citizen.Institution.Name = reader.GetString("institution_name");
							citizen.Institution.Sector = (TSocietySector)reader.GetInt32("institution_society_sector_type");
							citizen.Institution.Description = reader.GetString("institution_description");
							citizen.Institution.Category.Id = reader.GetInt32("institution_category_id");

							if (citizen.Institution.Category.Id != 0)
							{
								citizen.Institution.Category.Name = reader.GetString("institution_category_name");
								citizen.Institution.Category.Description = reader.GetString("institution_category_description");
							}
						}

						if (citizen.Role.Id != 0)
						{
                            citizen.Role.InstitutionId = citizen.Institution.Id;

                            if (citizen.Role.IsTemplateRole)
							{
								citizen.Role.Name = reader.GetString("institution_template_role_name");
								citizen.Role.Description = reader.GetString("institution_template_role_description");
							}
							else
							{
								citizen.Role.Name = reader.GetString("institution_role_name");
								citizen.Role.Description = reader.GetString("institution_role_description");
							}
						}

						if (citizen.Institution2.Id != 0)
						{
							citizen.Institution2.Name = reader.GetString("institution2_name");
							citizen.Institution2.Sector = (TSocietySector)reader.GetInt32("institution2_society_sector_type");
							citizen.Institution2.Description = reader.GetString("institution2_description");
							citizen.Institution2.Category.Id = reader.GetInt32("institution2_category_id");

							if (citizen.Institution2.Category.Id != 0)
							{
								citizen.Institution2.Category.Name = reader.GetString("institution2_category_name");
								citizen.Institution2.Category.Description = reader.GetString("institution2_category_description");
							}
						}

						if (citizen.Role2.Id != 0)
						{
							citizen.Role2.InstitutionId = citizen.Institution2.Id;

							if (citizen.Role2.IsTemplateRole)
							{
								citizen.Role2.Name = reader.GetString("institution2_template_role_name");
								citizen.Role2.Description = reader.GetString("institution2_template_role_description");
							}
							else
							{
								citizen.Role2.Name = reader.GetString("institution2_role_name");
								citizen.Role2.Description = reader.GetString("institution2_role_description");
							}
						}

						if (citizen.Institution3.Id != 0)
						{
							citizen.Institution3.Name = reader.GetString("institution3_name");
							citizen.Institution3.Sector = (TSocietySector)reader.GetInt32("institution3_society_sector_type");
							citizen.Institution3.Description = reader.GetString("institution3_description");
							citizen.Institution3.Category.Id = reader.GetInt32("institution3_category_id");

							if (citizen.Institution3.Category.Id != 0)
							{
								citizen.Institution3.Category.Name = reader.GetString("institution3_category_name");
								citizen.Institution3.Category.Description = reader.GetString("institution3_category_description");
							}
						}

						if (citizen.Role3.Id != 0)
						{
                            citizen.Role3.InstitutionId = citizen.Institution3.Id;

                            if (citizen.Role3.IsTemplateRole)
							{
								citizen.Role3.Name = reader.GetString("institution3_template_role_name");
								citizen.Role3.Description = reader.GetString("institution3_template_role_description");
							}
							else
							{
								citizen.Role3.Name = reader.GetString("institution3_role_name");
								citizen.Role3.Description = reader.GetString("institution3_role_description");
							}
						}

						if (citizen.Address.Id != 0)
						{
							citizen.Address.Street = reader.GetString("street");
							citizen.Address.Number = reader.GetString("number");
							citizen.Address.InteriorNumber = reader.GetString("interior_number");
							citizen.Address.PostalCode = reader.GetString("postal_code");
							citizen.Address.State = reader.GetString("state");
							citizen.Address.City = reader.GetString("city");
							citizen.Address.Country = (TCountry)reader.GetInt32("country_type");
							citizen.Address.District = reader.GetString("district");
						}

						if (citizen.Author.Id != 0)
						{
							citizen.Author.Name = reader.GetString("author_name");
						}

						if (citizen.LastEditor.Id != 0)
						{
							citizen.LastEditor.Name = reader.GetString("editor_name");
						}

						if (citizen.VerifiedBy.Id != 0)
						{
							citizen.VerifiedBy.Name = reader.GetString("verified_by_name");
						}

						if (citizen.Category.Id != 0)
						{
							citizen.Category.Name = reader.GetString("category_name");
						}

						citizen.Phone.Number = reader.GetString("phone1_number");
						citizen.Phone.Extension = reader.GetString("phone1_number_extension");
						citizen.Phone2.Number = reader.GetString("phone2_number");
						citizen.Phone2.Extension = reader.GetString("phone2_number_extension");
						citizen.Phone3.Number = reader.GetString("phone3_number");
						citizen.Phone3.Extension = reader.GetString("phone3_number_extension");
						citizen.Cellphone.Number = reader.GetString("contact_cellphone");
						citizen.CardDavSyncNumber.Number = reader.GetString("carddav_sync_number");
						citizen.CardDavSyncNumber.Extension = reader.GetString("carddav_sync_extension");
						citizen.CardDavSyncNumber.CarddavSync = reader.GetBoolean("carddav_sync_enabled");

						citizen_list.Add(citizen);
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetCitizens(out List<TCitizen> citizen_list)
		{
			return GetCitizensWithCondition("", out citizen_list);
		}

		public static Error GetCitizensWhosBirhdayFallsOn(DateTime birthday, out List<TCitizen> citizen_list)
		{
			var conn = ConnectionPool.GetConnection();

			Error error = 0;

			citizen_list = new List<TCitizen>();

			string sql = "SELECT Id FROM citizens WHERE EXTRACT(MONTH FROM birthday) = @month AND EXTRACT(DAY FROM birthday) = @day AND known_birthday = true";

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

		public static Error GetCitizensWithInstitutionRole(int institution_id, int role_id, out List<TCitizen> citizen_list)
		{
			string condition = $@"
				AND (
					c.id IN (
						SELECT 
							citizen_id 
						FROM 
							citizen_institution_roles cir_ 
						WHERE 
							( cir_.institution_id = {institution_id} AND cir_.institution_role_id = {role_id} )
							OR ( cir_.institution_id = {institution_id} AND cir_.institution_template_role_id = {role_id} )
					)
				)
			";

			return GetCitizensWithCondition(condition, out citizen_list);
		}

		public static Error GetCitizensWithRoleInInstitution(int institution_id, out List<TCitizen> citizens)
		{
            string condition = $@"
				AND (
					c.id IN (
						SELECT 
							citizen_id 
						FROM 
							citizen_institution_roles cir_ 
						WHERE 
							cir_.institution_id = {institution_id}
					)
				)
			";

            return GetCitizensWithCondition(condition, out citizens);
        }

		public static Error ImportCitizens(List<TCitizen> to_import, out string import_log, Action<int> callback)
		{
			Error error = 0;

			StringBuilder log = new StringBuilder();

			var conn = ConnectionPool.GetConnection();
			var tran = conn.BeginTransaction();

			try
			{
				for(int i = 0; i < to_import.Count; i++)
				{
					callback(i);

					TCitizen citizen = to_import[i];

					// first, check if there is a user with the given name, if so, skip it...
					using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM citizens WHERE name = @name", conn))
					{
						cmd.Parameters.AddWithValue("@name", citizen.Name);

						if ((Int32)(Int64)cmd.ExecuteScalar() > 0)
						{
							log.AppendLine($"found citizen with same: \"{citizen.Name}\"... skipped!");

							continue;
						}
					}

					// if category id == 0, then lookup category by name, if not found, create it
					if (citizen.Category.Id == 0)
					{
						using (var cmd = new NpgsqlCommand("SELECT Id FROM citizen_categories WHERE name = @name;", conn))
						{
							cmd.Parameters.AddWithValue("@name", citizen.Category.Name);

							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									reader.Read();

									citizen.Category.Id = reader.GetInt32(0);
								}
								else
								{
									reader.Close();

									cmd.CommandText = "INSERT INTO citizen_categories(name) VALUES(@name) RETURNING id;";

									citizen.Category.Id = (Int32)(Int64)cmd.ExecuteScalar();

									log.AppendLine($"category created:");
									log.AppendLine($"  id  : {citizen.Category.Id}");
									log.AppendLine($"  name: {citizen.Category.Name}");
								}
							}
						}
					}

					// if institution id == 0, then lookup institution by name, if not found, create it
					if (citizen.Institution.Id == 0)
					{
						using (var cmd = new NpgsqlCommand("SELECT id FROM institutions WHERE name = @name;", conn))
						{
							cmd.Parameters.AddWithValue("@name", citizen.Institution.Name);

							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									reader.Read();

									citizen.Institution.Id = reader.GetInt32(0);
								}
								else
								{
									reader.Close();

									cmd.CommandText = @"
										INSERT INTO institutions(
											name,
											society_sector_type
										) VALUES(
											@name,
											0
										) RETURNING id;";

									citizen.Institution.Id = (Int32)(Int64)cmd.ExecuteScalar();

									log.AppendLine($"institution created:");
									log.AppendLine($"  id:   {citizen.Institution.Id}");
									log.AppendLine($"  name: {citizen.Institution.Name}");
								}
							}
						}
					}

					// if role id == 0, then lookup role by name and institution id, if not found, create it within the given institution
					if (citizen.Role.Id == 0)
					{
						using (var cmd = new NpgsqlCommand("SELECT id FROM institution_roles WHERE name = @name AND institution_id = @institution_id;", conn))
						{
							cmd.Parameters.AddWithValue("@name", citizen.Role.Name);
							cmd.Parameters.AddWithValue("@institution_id", citizen.Institution.Id);

							using (var reader = cmd.ExecuteReader())
							{
								if (reader.HasRows)
								{
									reader.Read();

									citizen.Role.Id = reader.GetInt32(0);
								}
								else
								{
									reader.Close();

									cmd.CommandText = "INSERT INTO institution_roles(name, institution_id) VALUES(@name, @institution_id) RETURNING id;";

									log.AppendLine($"institution created:");
									log.AppendLine($"  id:             {citizen.Role.Id}");
									log.AppendLine($"  name:           {citizen.Role.Name}");
									log.AppendLine($"  institution_id: {citizen.Role.InstitutionId}");

									citizen.Role.Id = (Int32)(Int64)cmd.ExecuteScalar();
								}
							}
						}
					}

					// el nuevo usario necesita una dirección sí o sí
					using (var cmd = new NpgsqlCommand("INSERT INTO addresses DEFAULT VALUES RETURNING id;", conn))
					{
						citizen.Address = new TAddress();
						citizen.Address.Id = (Int32)(Int64)cmd.ExecuteScalar();
					}

					citizen.Title = TCitizenTitle.None;
					citizen.Sex = TSex.Unknown;

					// un intento por determinar el título y sexo del ciudadano en base a lo que pudiese venir en el nombre
					foreach (TCitizenTitle title in Enum.GetValues(typeof(TCitizenTitle)))
					{
						string low_name = citizen.Name.ToLower();

						if (low_name.StartsWith(BConstants.GetCitizenBriefTitle(title).ToLower()))
						{
							citizen.Title = title;
						}
						else if (low_name.StartsWith(BConstants.GetCitizenBriefTitle(title, TSex.Male).ToLower()))
						{
							citizen.Title = title;
							citizen.Sex = TSex.Male;
						}
						else if (low_name.StartsWith(BConstants.GetCitizenBriefTitle(title, TSex.Female).ToLower()))
						{
							citizen.Title = title;
							citizen.Sex = TSex.Female;
						}
					}

					// finalmente, creamos al ciudadano
					string sql = @"
						INSERT INTO citizens(
							name,
							title_type,
							sex_type,
							citizen_category_id,
							address_id,
							known_birthday,
							known_birthyear
						) VALUES (
							@name,
							@title_type,
							@sex_type,
							@citizen_category_id,
							@address_id,
							false,
							false
						) RETURNING id;
					";

					using (var cmd = new NpgsqlCommand(sql, conn))
					{
						cmd.Parameters.AddWithValue("@name", citizen.Name);
						cmd.Parameters.AddWithValue("@title_type", (int)citizen.Title);
						cmd.Parameters.AddWithValue("@sex_type", (int)citizen.Sex);
						cmd.Parameters.AddWithValue("@citizen_category_id", citizen.Category.Id);
						cmd.Parameters.AddWithValue("@address_id", citizen.Address.Id);

						citizen.Id = (Int32)(Int64)cmd.ExecuteScalar();

						log.AppendLine($"citizen created: ");
						log.AppendLine($"  id:                  {citizen.Id}");
						log.AppendLine($"  name:                {citizen.Name}");
						log.AppendLine($"  institution id:      {citizen.Institution.Id}");
						log.AppendLine($"  institution role id: {citizen.Role.Id}");
					}

					// save the institution/role assignment (position 1) if one was resolved above
					if (citizen.Institution.Id != 0)
					{
						using (var cmd = new NpgsqlCommand(@"
							INSERT INTO citizen_institution_roles(
								position,
								citizen_id,
								institution_id,
								institution_role_id,
								institution_template_role_id,
								is_institution_template_role
							) VALUES (
								1,
								@citizen_id,
								@institution_id,
								@institution_role_id,
								NULL,
								false
							);", conn))
						{
							cmd.Parameters.AddWithValue("@citizen_id", citizen.Id);
							cmd.Parameters.AddWithValue("@institution_id", citizen.Institution.Id);
							cmd.Parameters.AddWithValue("@institution_role_id", citizen.Role.Id == 0 ? (object)DBNull.Value : citizen.Role.Id);

							cmd.ExecuteNonQuery();
						}
					}
				}

				tran.Commit();
			}
			catch (Exception ex)
			{
				error = Error.Unknown;

				log.AppendLine($"unknown exception: {ex.Message}");

				tran.Rollback();
			}
			finally
			{
				ConnectionPool.ReleaseConnection(ref conn);

				import_log = log.ToString();
			}

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

			using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM citizens WHERE citizen_category_id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				int citizen_with_category = (Int32)(Int64)cmd.ExecuteScalar();

				if (citizen_with_category > 0)
				{
					ConnectionPool.ReleaseConnection(ref conn);
					return Error.CitizenCategoryInUse;
				}

				cmd.CommandText = "DELETE FROM citizen_categories WHERE id = @id;";
				cmd.ExecuteNonQuery();
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error GetCitizenRelationshipById(int id, out TCitizenRelationship relationship)
		{
			Error error = 0;

			relationship = new TCitizenRelationship();

			var conn = ConnectionPool.GetConnection();

			string sql = @"
				SELECT 
					cr.*,
					crr.name AS RoleName
				FROM 
					citizen_relationships cr
					LEFT JOIN citizen_relationship_roles crr ON cr.citizen_relationship_role_id = crr.id
				WHERE 
					cr.id = @id;
			";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows == false)
					{
						ConnectionPool.ReleaseConnection(ref conn);
						return Error.CitizenRelationshipNotFound;
					}

					reader.Read();

					relationship.FillFromReader(reader);

					relationship.Role.Name = reader.GetString("RoleName");
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error SaveCitizenRelationship(TCitizenRelationship relationship, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			string sql = "";

			if (is_update)
			{
				sql = @"
					UPDATE 
						citizen_relationships 
					SET
						citizen_id = @citizen_id,
						related_citizen_id = @related_citizen_id,
						citizen_relationship_role_id = @citizen_relationship_role_id,
						affinity_score = @affinity_score,
						known_start_date = @known_start_date,
						known_end_date = @known_end_date,
						start_date = @start_date,
						end_date = @end_date,
						notes = @notes,
						user_id = @user_id,
						enabled = @enabled,
						priority_score = @priority_score
					WHERE
						id = @id;";
			}
			else
			{
				sql = @"
					INSERT INTO citizen_relationships(
						citizen_id,
						related_citizen_id,
						citizen_relationship_role_id,
						affinity_score,
						known_start_date,
						known_end_date,
						start_date,
						end_date,
						notes,
						user_id,
						enabled,
						priority_score
					) VALUES (
						@citizen_id,
						@related_citizen_id,
						@citizen_relationship_role_id,
						@affinity_score,
						@known_start_date,
						@known_end_date,
						@start_date,
						@end_date,
						@notes,
						@user_id,
						@enabled,
						@priority_score
					) RETURNING id;";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", relationship.Id);
				cmd.Parameters.AddWithValue("@citizen_id", relationship.Citizen.Id);
				cmd.Parameters.AddWithValue("@related_citizen_id", relationship.RelatedTo.Id);
				cmd.Parameters.AddWithValue("@citizen_relationship_role_id", relationship.Role.Id);
				cmd.Parameters.AddWithValue("@affinity_score", relationship.AffinityScore);
				cmd.Parameters.AddWithValue("@known_start_date", relationship.KnownStartDate);
				cmd.Parameters.AddWithValue("@known_end_date", relationship.KnownEndDate);
				cmd.Parameters.AddWithValue("@start_date", relationship.StartDate);
				cmd.Parameters.AddWithValue("@end_date", relationship.EndDate);
				cmd.Parameters.AddWithValue("@notes", relationship.Notes);
				cmd.Parameters.AddWithValue("@user_id", relationship.User.Id);
				cmd.Parameters.AddWithValue("@enabled", relationship.Enabled);
				cmd.Parameters.AddWithValue("@priority_score", relationship.PriorityScore);

				if (is_update)
				{
					cmd.ExecuteNonQuery();
				}
				else
				{
					relationship.Id = (Int32)(Int64)cmd.ExecuteScalar();
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error SetEnabledCitizenRelationship(int relationshipId, bool enabled)
		{
			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("UPDATE citizen_relationships SET enabled = @enabled WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@enabled", enabled);
				cmd.Parameters.AddWithValue("@id", relationshipId);
				cmd.ExecuteNonQuery();
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetCitizenRelationships(out List<TCitizenRelationship> relationships)
		{
			var conn = ConnectionPool.GetConnection();

			relationships = new List<TCitizenRelationship>();

			string sql = @"
				SELECT
					cr.*,
					c1.name AS citizen_name,
					c1.paternal_name AS citizen_paternal_name,
					c1.maternal_name AS citizen_maternal_name,
					c2.name AS related_name,
					c2.paternal_name AS related_paternal_name,
					c2.maternal_name AS related_maternal_name,
					crr.name AS role_name,
					u.name AS user_name
				FROM 
					citizen_relationships cr
					LEFT JOIN citizens c1 ON c1.id = cr.citizen_id
					LEFT JOIN citizens c2 ON c2.id = cr.related_citizen_id
					LEFT JOIN citizen_relationship_roles crr ON crr.id = cr.citizen_relationship_role_id
					LEFT JOIN users u ON cr.user_id = u.id
				WHERE 
					true;
			";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						var relation = new TCitizenRelationship();

						relation.FillFromReader(reader);

						if (relation.Citizen.Id != 0)
						{
							relation.Citizen.Name = reader.GetString("citizen_name");
							relation.Citizen.PaternalName = reader.GetString("citizen_paternal_name");
							relation.Citizen.MaternalName = reader.GetString("citizen_maternal_name");
						}

						if (relation.RelatedTo.Id != 0)
						{
							relation.RelatedTo.Name = reader.GetString("related_name");
							relation.RelatedTo.PaternalName = reader.GetString("related_paternal_name");
							relation.RelatedTo.MaternalName = reader.GetString("related_maternal_name");
						}

						if (relation.Role.Id != 0)
						{
							relation.Role.Name = reader.GetString("role_name");
						}

						if (relation.User.Id != 0)
						{
							relation.User.Name = reader.GetString("user_name");
						}

						relationships.Add(relation);	
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetCitizenRelationshipRoles(out List<TCitizenRelationshipRole> relationshipRoles)
		{
			var conn = ConnectionPool.GetConnection();

			relationshipRoles = new List<TCitizenRelationshipRole>();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizen_relationship_roles;", conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while (reader.Read())
				{
					var role = new TCitizenRelationshipRole();

					role.FillFromReader(reader);

					relationshipRoles.Add(role);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error GetCitizenRelationshipRoleById(int id, out TCitizenRelationshipRole role)
		{
			var conn = ConnectionPool.GetConnection();

			role = new TCitizenRelationshipRole();	

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizen_relationship_roles WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows == false)
					{
						ConnectionPool.ReleaseConnection(ref conn);
						return Error.CitizenRelationshipRoleNotFound;
					}

					reader.Read();

					role.FillFromReader(reader);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error SaveCitizenRelationshipRole(TCitizenRelationshipRole role, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			string sql = "";

			if (is_update)
			{
				sql = @"
					UPDATE 
						citizen_relationship_roles 
					SET 
						name = @name
					WHERE
						id = @id;";
			}
			else
			{
				sql = @"
					INSERT INTO citizen_relationship_roles (
						name
					) VALUES (
						@name
					) RETURNING id;";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@name", role.Name);
				cmd.Parameters.AddWithValue("@id", role.Id);

				if (is_update)
				{
					cmd.ExecuteNonQuery();
				}
				else
				{
					role.Id = (Int32)(Int64)cmd.ExecuteScalar();
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);	

			return 0;
		}
	
		public static Error DeleteCitizenRelationshipRoleById(int id)
		{
			// TODO

			return 0;
		}
	}
}
