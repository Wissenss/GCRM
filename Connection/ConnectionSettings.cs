using Microsoft.VisualBasic.FileIO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Connection
{
	public static class ConnectionSettings
	{
		public class TFileSettings
		{
			public string Host { get; set; }
			public int Port { get; set; }
			public string Database { get; set; }
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

		public static void WriteSettings(string host, int port, string database)
		{
			JSON = File.ReadAllText(ConnectionFilePath);
			FileSettings = JsonSerializer.Deserialize<TFileSettings>(JSON);

			FileSettings.Host = host;
			FileSettings.Port = port;
			FileSettings.Database = database;

			JSON = JsonSerializer.Serialize<TFileSettings>(FileSettings);
			File.WriteAllText(ConnectionFilePath, JSON);
		}

		public static void LoadSettings()
		{
			ConnectionFilePath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "connection.json");

			//Username = "postgres";
			//Password = "notecreo";
			Username = "gcrm_client";
			Password = "m$!g+38ke~v5NrbXKH'^Zu";

			// read the settings from file

			if (Path.Exists(ConnectionFilePath) == false) // ensure the file exists
			{
				FileSettings = new TFileSettings()
				{
					Host = "localhost",
					Port = 5432,
					Database = "gcrm",
				};

				JSON = JsonSerializer.Serialize<TFileSettings>(FileSettings);

				File.WriteAllText(ConnectionFilePath, JSON);
			}

			JSON = File.ReadAllText(ConnectionFilePath);

			FileSettings = JsonSerializer.Deserialize<TFileSettings>(JSON);

			Host = FileSettings.Host;
			Port = FileSettings.Port;
			Database = FileSettings.Database;
		}
	
		public static bool TestSettings(string host, int port, string database)
		{
			try
			{
				ConnectionSettings.LoadSettings();

				string conn_string = $"Host={host};Port={port};Username={ConnectionSettings.Username};Password={ConnectionSettings.Password};Database={database}";

				NpgsqlDataSourceBuilder builder = new NpgsqlDataSourceBuilder(conn_string);

				NpgsqlDataSource dataSource = builder.Build();

				NpgsqlConnection connection = dataSource.OpenConnection();
				
				bool connected = connection.State == System.Data.ConnectionState.Open;

				connection.Dispose();

				return connected;
			}
			catch (Exception ex)
			{
			}

			return false;
		}

		public static bool TestSettings()
		{
			return TestSettings(Host, Port, Database);
		}
	}
}
