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
	public class TAddress
	{
		public int Id;
		public string Street;
		public string Number;
		public string InteriorNumber;
		public string PostalCode;
		public string State;
		public string City;
		public TCountry Country;

		public string FullAddress
		{
			get
			{
				return GetFullAddress();
			}
		}

		public string GetFullAddress()
		{
			string full_address = "";

			if (Street?.Trim().Length > 0)
				full_address += Street;

			if (Number?.Trim().Length > 0)
				full_address += $" No. {Number} ";

			if (InteriorNumber?.Trim().Length > 0)
				full_address += $"Int. {InteriorNumber} ";

			if (State?.Trim().Length > 0)
				full_address += $"{State}";

			if (City?.Trim().Length > 0)
				full_address += $"{City}";

			if (PostalCode?.Trim().Length > 0)
				full_address += $"C.P. {PostalCode}";

			return full_address;
		}

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Street = reader.GetString(1);
			Number = reader.GetString(2);
			InteriorNumber = reader.GetString(3);
			PostalCode = reader.GetString(4);
			State = reader.GetString(5);
			City = reader.GetString(6);
			Country = (TCountry)reader.GetInt32(7);
		}
	}

	public static class AddressesHandler
	{
		public static Error SaveAddress(TAddress address, bool is_update, out int address_id)
		{
			var conn = ConnectionPool.GetConnection();

			string sql = "";

			if (is_update)
			{
				sql = "UPDATE addresses SET street = @street, number = @number, interior_number = @interior_number, postal_code = @postal_code, state = @state, city = @city, country_type = @country WHERE id = @id;";
			}
			else
			{
				sql = "INSERT INTO addresses(street, number, interior_number, postal_code, state, city, country_type) VALUES(@street, @number, @interior_number, @postal_code, @state, @city, @country) RETURNING id;";
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

				if (is_update)
				{
					cmd.ExecuteNonQuery();
				}
				else
				{
					address.Id = (Int32)(Int64)cmd.ExecuteScalar();
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);	

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
