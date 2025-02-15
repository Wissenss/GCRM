using Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business
{
	public class TCitizen
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
		public string Phone;
		public string PhoneExtension;
		public string Cellphone;
		public string Email;
		public TPoliticalParty PoliticalParty;
		public TInstitution Institution;
		public TInstitutionRole Role;

		public void FillFromReader(DbDataReader reader)
		{
			Assistant = new TCitizen();
			Institution = new TInstitution();
			Role = new TInstitutionRole();

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
			Phone = reader.GetString(11);
			PhoneExtension = reader.GetString(12);
			Cellphone = reader.GetString(13);
			PoliticalParty = (TPoliticalParty)reader.GetInt32(14);
			Institution.Id = reader.GetInt32(15);
			Role.Id = reader.GetInt32(16);
			Email = reader.GetString(17);
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

						if (citizen.Assistant.Id != 0)
						{
							error = GetCitizenAssistantById(citizen.Assistant.Id, out citizen.Assistant);
						}

						if (error == 0)
						{
							error = AddressesHandler.GetAddressById(citizen.Address.Id, out citizen.Address);
						}

						if (error == 0)
						{
							if (citizen.Institution.Id != 0)
							{
								error = InstitutionsHandler.GetInstitutionById(citizen.Institution.Id, out citizen.Institution);
							}
							else
							{
								citizen.Institution = new TInstitution();
							}
						}

						if (error == 0)
						{
							if (citizen.Role.Id != 0)
							{
								error = InstitutionsHandler.GetInstitutionRoleById(citizen.Role.Id, out citizen.Role);
							}
							else
							{
								citizen.Role = new TInstitutionRole();
							}
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

			if (error == 0)
			{
				error = AddressesHandler.SaveAddress(citizen.Address, is_update, out citizen.Address.Id);
			}

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
								email=@email
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
								email
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
								@email)
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
					cmd.Parameters.AddWithValue("@phone", citizen.Phone);
					cmd.Parameters.AddWithValue("@phone_extension", citizen.PhoneExtension);
					cmd.Parameters.AddWithValue("@cellphone", citizen.Cellphone);
					cmd.Parameters.AddWithValue("@political_party", (int)citizen.PoliticalParty);
					cmd.Parameters.AddWithValue("@institution_id", citizen.Institution.Id);
					cmd.Parameters.AddWithValue("@institution_role_id", citizen.Role.Id);
					cmd.Parameters.AddWithValue("@email", citizen.Email);

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

			tran.Commit();

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetCitizens(out List<TCitizen> citizen_list)
		{
			citizen_list = new List<TCitizen>();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM citizens ORDER BY name, paternal_name, maternal_name;", conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while (reader.Read())
				{
					TCitizen citizen = new TCitizen();

					citizen.FillFromReader(reader);

					if (citizen.Assistant.Id != 0)
					{
						GetCitizenAssistantById(citizen.Assistant.Id, out citizen.Assistant);
					}

					if (citizen.Institution.Id != 0)
					{
						InstitutionsHandler.GetInstitutionById(citizen.Institution.Id, out citizen.Institution);
					}

					if (citizen.Address.Id != 0)
					{
						AddressesHandler.GetAddressById(citizen.Address.Id, out citizen.Address);
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
	}
}
