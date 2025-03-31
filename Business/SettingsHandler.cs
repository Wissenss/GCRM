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

			private static Error CreateSettingFromRawValue(string name, object value, Type type, int user_id)
			{
				BDBTypeSettingDatatype setting_datatype = BDBTypes.GetSettingDataTypeFromType(type);

				string sql = "";

				switch (setting_datatype)
				{
					case BDBTypeSettingDatatype.String: sql = "INSERT INTO settings(name, string_value, datatype, user_id) VALUES(@name, @value, 'string', @user_id);"; break;
					case BDBTypeSettingDatatype.Boolean: sql = "INSERT INTO settings(name, boolean_value, datatype, user_id) VALUES(@name, @value, 'boolean', @user_id)"; break;
					case BDBTypeSettingDatatype.Numeric: sql = "INSERT INTO settings(name, numeric_value, datatype, user_id) VALUES(@name, @value, 'numeric', @user_id)"; break;
					case BDBTypeSettingDatatype.Blob: sql = "INSERT INTO settings(name, blob_value, datatype, user_id) VALUES(@name, @value, 'blob', @user_id)"; break;
				}

				var conn = ConnectionPool.GetConnection();

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@name", name);
					cmd.Parameters.AddWithValue("@value", value);
					cmd.Parameters.AddWithValue("@user_id", user_id);
					
					cmd.ExecuteNonQuery();
				}

				ConnectionPool.ReleaseConnection(ref conn);

				return 0;
			}

			private static Error UpdateSettingFromRawValue(string name, object value, Type type, int user_id)
			{
				BDBTypeSettingDatatype setting_datatype = BDBTypes.GetSettingDataTypeFromType(type);

				string sql = "";

				switch (setting_datatype)
				{
					case BDBTypeSettingDatatype.String: sql = "UPDATE settings SET string_value = @value, datatype = 'string', user_id = @user_id WHERE name = @name;"; break;
					case BDBTypeSettingDatatype.Boolean: sql = "UPDATE settings SET boolean_value = @value, datatype = 'boolean', user_id = @user_id WHERE name = @name;"; break;
					case BDBTypeSettingDatatype.Numeric: sql = "UPDATE settings SET numeric_value = @value, datatype = 'numeric', user_id = @user_id WHERE name = @name;"; break;
					case BDBTypeSettingDatatype.Blob: sql = "UPDATE settings SET blob_value = @value, datatype = 'blob', user_id = @user_id WHERE name = @name;"; break;
				}

				var conn = ConnectionPool.GetConnection();

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@name", name);
					cmd.Parameters.AddWithValue("@value", value);
					cmd.Parameters.AddWithValue("@user_id", user_id);

					cmd.ExecuteNonQuery();
				}

				ConnectionPool.ReleaseConnection(ref conn);

				return 0;
			}

			public static Error SettingExists(string name, int user_id = 0)
			{
				Error error = 0;

				var conn = ConnectionPool.GetConnection();

				string sql = "SELECT * FROM settings WHERE name = @name AND user_id = @user_id;";

				using (var cmd = new NpgsqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@name", name);
					cmd.Parameters.AddWithValue("@user_id", user_id);

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

			private static Error GetRawSettingValueByName(string name, Type type, object _default, out object value, int user_id = 0, bool add_if_non_existent = true)
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

							byte[] blob_value = null;

							if (reader.IsDBNull(7) == false)
								blob_value = reader.GetFieldValue<byte[]>(7); 

							BDBTypeSettingDatatype setting_datatype = BDBTypes.GetSettingDataTypeFromString(reader.GetString(5));

							switch (setting_datatype)
							{
								case BDBTypeSettingDatatype.Numeric: value = numeric_value; break;
								case BDBTypeSettingDatatype.Boolean: value = boolean_value; break;
								case BDBTypeSettingDatatype.String: value = string_value; break;
								case BDBTypeSettingDatatype.Blob: value = blob_value; break;
							}
						}
						else if (add_if_non_existent)
						{
							error = CreateSettingFromRawValue(name, value, type, user_id);
						}
					}
				}

				ConnectionPool.ReleaseConnection(ref conn);

				return error;
			}

			public static Error DeleteSetting(string name, int user_id = 0)
			{
				Error error = 0;

				var conn = ConnectionPool.GetConnection();

				using (var cmd = new NpgsqlCommand("DELETE FROM settings WHERE name = @name AND user_id = @user_id;", conn))
				{
					cmd.Parameters.AddWithValue("@name", name);
					cmd.Parameters.AddWithValue("@user_id", user_id);

					cmd.ExecuteNonQuery();
				}

				ConnectionPool.ReleaseConnection(ref conn);

				return error;
			}

			public static T GetSetting<T>(string name, T _default, int user_id = 0, bool add_if_non_existent = true)
			{
				object raw_value;

				Error error = GetRawSettingValueByName(name, typeof(T), _default, out raw_value, user_id, add_if_non_existent);

				if (error != 0)
				{
					throw new Exception($"internal handler error. {error.ToString()} {(int)error}: {Errors.GetErrorDescription(error)}");
				}

				return (T)Convert.ChangeType(raw_value, typeof(T));
			}

			public static void SetSetting<T>(string name, T value, int user_id = 0, bool add_if_non_existent = true)
			{
				Error error = SettingExists(name);

				if (error == 0)
				{
					error = UpdateSettingFromRawValue(name, value, typeof(T), user_id);
				}
				else if (error == Error.SettingNotFound)
				{
					error = 0;

					if (add_if_non_existent)
					{
						error = CreateSettingFromRawValue(name, value, typeof(T), user_id);
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
