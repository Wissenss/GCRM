using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	using System;
	using Npgsql;
	using Connection;

	namespace Business
	{
		public static class SettingsHandler
		{

			private static Error CreateSettingFromRawValue(string name, object value, Type type)
			{
				BDBTypeSettingDatatype setting_datatype = BDBTypes.GetSettingDataTypeFromType(type);

				string sql = "";

				switch (setting_datatype)
				{
					case BDBTypeSettingDatatype.String: sql = "INSERT INTO settings(name, string_value, datatype) VALUES(@name, @value, 'string');"; break;
					case BDBTypeSettingDatatype.Boolean: sql = "INSERT INTO settings(name, boolean_value, datatype) VALUES(@name, @value, 'boolean')"; break;
					case BDBTypeSettingDatatype.Numeric: sql = "INSERT INTO settings(name, numeric_value, datatype) VALUES(@name, @value, 'numeric')"; break;
				}

				var conn = ConnectionPool.GetConnection();

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@name", name);
					cmd.Parameters.AddWithValue("@value", value);

					cmd.ExecuteNonQuery();
				}

				ConnectionPool.ReleaseConnection(ref conn);

				return 0;
			}

			private static Error UpdateSettingFromRawValue(string name, object value, Type type)
			{
				BDBTypeSettingDatatype setting_datatype = BDBTypes.GetSettingDataTypeFromType(type);

				string sql = "";

				switch (setting_datatype)
				{
					case BDBTypeSettingDatatype.String: sql = "UPDATE settings SET string_value = @value, datatype = 'string' WHERE name = @name;"; break;
					case BDBTypeSettingDatatype.Boolean: sql = "UPDATE settings SET boolean_value = @value, datatype = 'boolean' WHERE name = @name;"; break;
					case BDBTypeSettingDatatype.Numeric: sql = "UPDATE settings SET numeric_value = @value, datatype = 'numeric' WHERE name = @name;"; break;
				}

				var conn = ConnectionPool.GetConnection();

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@name", name);
					cmd.Parameters.AddWithValue("@value", value);

					cmd.ExecuteNonQuery();
				}

				ConnectionPool.ReleaseConnection(ref conn);

				return 0;
			}

			public static Error SettingExists(string name)
			{
				Error error = 0;

				var conn = ConnectionPool.GetConnection();

				string sql = "SELECT * FROM settings WHERE name = @name;";

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@name", name);

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows == false)
						{
							error = Error.SettingNotFound;
						}
					}
				}

				return error;
			}

			private static Error GetRawSettingValueByName(string name, Type type, object _default, out object value, bool add_if_non_existent = true)
			{
				Error error = 0;

				var conn = ConnectionPool.GetConnection();

				value = _default;

				string sql = "SELECT * FROM settings WHERE name = @name;";

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@name", name);

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							reader.Read();

							string string_value = reader.GetString(2);
							bool boolean_value = reader.GetBoolean(3);
							decimal numeric_value = reader.GetDecimal(4);

							BDBTypeSettingDatatype setting_datatype = BDBTypes.GetSettingDataTypeFromString(reader.GetString(5));

							switch (setting_datatype)
							{
								case BDBTypeSettingDatatype.Numeric: value = numeric_value; break;
								case BDBTypeSettingDatatype.Boolean: value = boolean_value; break;
								case BDBTypeSettingDatatype.String: value = string_value; break;
							}
						}
						else if (add_if_non_existent)
						{
							error = CreateSettingFromRawValue(name, value, type);
						}
					}
				}

				ConnectionPool.ReleaseConnection(ref conn);

				return error;
			}

			public static T GetSetting<T>(string name, T _default, bool add_if_non_existent = true)
			{
				object raw_value;

				Error error = GetRawSettingValueByName(name, typeof(T), _default, out raw_value, add_if_non_existent);

				if (error != 0)
				{
					throw new Exception($"internal handler error. {error.ToString()} {(int)error}: {Errors.GetErrorDescription(error)}");
				}

				return (T)Convert.ChangeType(raw_value, typeof(T));
			}

			public static void SetSetting<T>(string name, T value, bool add_if_non_existent = true)
			{
				Error error = SettingExists(name);

				if (error == 0)
				{
					error = UpdateSettingFromRawValue(name, value, typeof(T));
				}
				else if (error == Error.SettingNotFound)
				{
					error = 0;

					if (add_if_non_existent)
					{
						error = CreateSettingFromRawValue(name, value, typeof(T));
					}
				}

				if (error != 0)
				{
					throw new Exception($"internal handler error. {error.ToString()} {(int)error}: {Errors.GetErrorDescription(error)}");
				}
			}
		}
	}

}
