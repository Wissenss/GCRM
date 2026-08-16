using Microsoft.VisualBasic.FileIO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GCRM.Infraestructure
{
	public static class ConnectionSettings
	{
		const string default_username = "gcrm_client";
		const string default_password = "m$!g+38ke~v5NrbXKH'^Zu";

        public class TFileSettings
		{
			public string Host { get; set; } = "localhost";
			public int Port { get; set; } = 5432;
			public string Database { get; set; } = "gcrm";
			public string Username { get; set; } = default_username;

            public string Password { get; set; } = default_password;

        }

		private static string ConnectionFilePath;
		private static TFileSettings FileSettings;
		private static string JSON;

		public static string Host { get; private set; }
		public static int Port { get; private set; }
		public static string Username { get; private set; }
		public static string Password { get; private set; }
		public static string Database {  get; private set; }

		static ConnectionSettings()
		{
			LoadSettings();
		}

		public static void WriteHost(string host)
		{
			JSON = File.ReadAllText(ConnectionFilePath);
			FileSettings = JsonSerializer.Deserialize<TFileSettings>(JSON);

			FileSettings.Host = host;

			JSON = JsonSerializer.Serialize<TFileSettings>(FileSettings);
			File.WriteAllText(ConnectionFilePath, JSON);
		}

		public static void WritePort(int port)
		{
			JSON = File.ReadAllText(ConnectionFilePath);
			FileSettings = JsonSerializer.Deserialize<TFileSettings>(JSON);

			FileSettings.Port = port;

			JSON = JsonSerializer.Serialize<TFileSettings>(FileSettings);
			File.WriteAllText(ConnectionFilePath, JSON);
		}

		public static void WriteDatabase(string database)
		{
			JSON = File.ReadAllText(ConnectionFilePath);
			FileSettings = JsonSerializer.Deserialize<TFileSettings>(JSON);

			FileSettings.Database = database;

			JSON = JsonSerializer.Serialize<TFileSettings>(FileSettings);
			File.WriteAllText(ConnectionFilePath, JSON);
		}

		public static void WriteSettings(string host, int port, string database, string username, string password)
		{
            if (username.Trim().Length == 0)
                username = default_username;

            if (password.Trim().Length == 0)
                password = default_password;

            JSON = File.ReadAllText(ConnectionFilePath);
			FileSettings = JsonSerializer.Deserialize<TFileSettings>(JSON);

			FileSettings.Host = host;
			FileSettings.Port = port;
			FileSettings.Database = database;
			FileSettings.Username = username;
			FileSettings.Password = password;

			JSON = JsonSerializer.Serialize<TFileSettings>(FileSettings);
			File.WriteAllText(ConnectionFilePath, JSON);
		}

		public static async void LoadSettings()
		{
			ConnectionFilePath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "connection.json");

			// read the settings from file

			if (Path.Exists(ConnectionFilePath) == false) // ensure the file exists
			{
				FileSettings = new TFileSettings();

				JSON = JsonSerializer.Serialize<TFileSettings>(FileSettings);

				File.WriteAllText(ConnectionFilePath, JSON);
			}

			JSON = File.ReadAllText(ConnectionFilePath);

			FileSettings = JsonSerializer.Deserialize<TFileSettings>(JSON);

			if (FileSettings == null)
			{
				FileSettings = new TFileSettings();
			}

			Host = FileSettings.Host;
			Port = FileSettings.Port;
			Database = FileSettings.Database;
			Username = FileSettings.Username.Trim().Length == 0 ? default_username : FileSettings.Username;
			Password = FileSettings.Password.Trim().Length == 0 ? default_password : FileSettings.Password;
		}
	
		public static async Task<bool> TestSettings(string host, int port, string database, string username, string password)
		{
			try
			{
				ConnectionSettings.LoadSettings();

				if (username.Trim().Length == 0)
					username = default_username;

				if (password.Trim().Length == 0)
					password = default_password;

				string conn_string = $"Host={host};Port={port};Username={username};Password={password};Database={database}";

				NpgsqlDataSourceBuilder builder = new NpgsqlDataSourceBuilder(conn_string);

				NpgsqlDataSource dataSource = builder.Build();

				NpgsqlConnection connection = await dataSource.OpenConnectionAsync();
				
				bool connected = connection.State == System.Data.ConnectionState.Open;

				connection.Dispose();

				return connected;
			}
			catch (Exception ex)
			{
			}

			return false;
		}

		public static async Task<bool> TestSettings()
		{
			return await TestSettings(Host, Port, Database, Username, Password);
		}
	}
}
