using Connection;
using Npgsql;
using GCRM.Domain;
using GCRM.Domain.Enums;

namespace Business
{
	public static class AddressesHandler
	{
		public static Error SaveAddress(TAddress address, bool is_update, out int address_id, NpgsqlConnection conn)
		{
			string sql = "";

			if (is_update)
			{
				sql = "UPDATE addresses SET street = @street, number = @number, interior_number = @interior_number, postal_code = @postal_code, state = @state, city = @city, country_type = @country, district = @district WHERE id = @id;";
			}
			else
			{
				sql = "INSERT INTO addresses(street, number, interior_number, postal_code, state, city, country_type, district) VALUES(@street, @number, @interior_number, @postal_code, @state, @city, @country, @district) RETURNING id;";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", address.Id);
				cmd.Parameters.AddWithValue("@street", address.Street);
				cmd.Parameters.AddWithValue("@number", address.Number);
				cmd.Parameters.AddWithValue("@interior_number", address.InteriorNumber);
				cmd.Parameters.AddWithValue("@postal_code", address.PostalCode);
				cmd.Parameters.AddWithValue("@state", address.State);
				cmd.Parameters.AddWithValue("@city", address.City);
				cmd.Parameters.AddWithValue("@country", (int)address.Country);
				cmd.Parameters.AddWithValue("@district", address.District);

				if (is_update)
				{
					cmd.ExecuteNonQuery();
				}
				else
				{
					address.Id = (Int32)(Int64)cmd.ExecuteScalar();
				}
			}

			address_id = address.Id;

			return 0;
		}

		public static Error GetAddressById(int id, out TAddress address)
		{
			Error error = 0;

			address = new TAddress();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM addresses WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						address.FillFromReader(reader);	
					}
					else
					{
						error = Error.AddressNotFound;
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error DeleteAddressById(int id, NpgsqlConnection conn)
		{
			using (var cmd = new NpgsqlCommand("DELETE FROM addresses WHERE id = @id;", conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				cmd.ExecuteNonQuery();
			}

			return 0;
		}

		public static Error GetCitizenAddress(int citizen_id, out TAddress address)
		{
			address = new TAddress();

			return 0;
		}

		public static Error GetAddresses(out List<TAddress> addresses_list)
		{
			addresses_list = new List<TAddress>();

			return 0;
		}
	}
}
