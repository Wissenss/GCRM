using Npgsql;
using Npgsql.Replication.PgOutput;

namespace Connection
{
	public static class ConnectionPool
	{
		private static int __PoolSize;
		private static string __ConnectionString = "Host=localhost;Username=postgres;Password=notecreo;Database=gcrm";
		private static List<Boolean> __PoolObjectAvailable;
		private static List<NpgsqlConnection> __Pool;
		private static bool __IsStarted = false;

		static ConnectionPool()
		{
			//Start();
		}

		public static async void StartAsync(int size = 10)
		{
			__PoolSize = size;

			// create the connection string
			ConnectionSettings.LoadSettings();

			__ConnectionString = $"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};Username={ConnectionSettings.Username};Password={ConnectionSettings.Password};Database={ConnectionSettings.Database}";

			// start the pool
			__PoolObjectAvailable = new List<Boolean>();
			__Pool = new List<NpgsqlConnection>();

			for (int i = 0; i < __PoolSize; i++)
			{
				__Pool.Add(await CreateConnectionAsync());
				__PoolObjectAvailable.Add(true);
			}

			__IsStarted = true;
		}

		public static void Start(int size = 10)
		{
			__PoolSize = size;

			// create the connection string
			ConnectionSettings.LoadSettings();

			__ConnectionString = $"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};Username={ConnectionSettings.Username};Password={ConnectionSettings.Password};Database={ConnectionSettings.Database}";

			// start the pool
			__PoolObjectAvailable = new List<Boolean>();
			__Pool = new List<NpgsqlConnection>();

			for (int i = 0; i < __PoolSize; i++)
			{
				__Pool.Add(CreateConnection());
				__PoolObjectAvailable.Add(true);
			}

			__IsStarted = true;
		}

		private static void Stop()
		{
			if (!__IsStarted)
				return;

			__PoolObjectAvailable.Clear();

			foreach(NpgsqlConnection connection in __Pool)
			{
				connection.Close();
			}

			__Pool.Clear();

			__ConnectionString = "";

			__PoolSize = 0;

			__IsStarted = false;
		}
		
		public static void Refresh()
		{
			Stop();
			Start();
		}

		private static async Task<NpgsqlConnection> CreateConnectionAsync()
		{
			NpgsqlDataSourceBuilder builder = new NpgsqlDataSourceBuilder(__ConnectionString);
			NpgsqlDataSource dataSource = builder.Build();
			NpgsqlConnection connection = await dataSource.OpenConnectionAsync();

			return connection;
		}

		private static NpgsqlConnection CreateConnection()
		{
			NpgsqlDataSourceBuilder builder = new NpgsqlDataSourceBuilder(__ConnectionString);
			NpgsqlDataSource dataSource = builder.Build();
			NpgsqlConnection connection = dataSource.OpenConnection();

			return connection;
		}

		public static async Task<NpgsqlConnection> GetConnectionAsync()
		{
			for (int i = 0; i < __Pool.Count; i++)
			{
				NpgsqlConnection connection = __Pool[i];
				bool available = __PoolObjectAvailable[i];

				if (available)
				{
					__PoolObjectAvailable[i] = false;
					return connection;
				}
			}

			NpgsqlConnection new_connection = await CreateConnectionAsync();

			__Pool.Add(new_connection);
			__PoolObjectAvailable.Add(false);

			return new_connection;
		}

		public static NpgsqlConnection GetConnection()
		{
			for (int i = 0; i < __Pool.Count; i++)
			{
				NpgsqlConnection connection = __Pool[i];
				bool available = __PoolObjectAvailable[i];

				if (available)
				{
					__PoolObjectAvailable[i] = false;
					return connection;
				}
			}

			NpgsqlConnection new_connection = CreateConnection();

			__Pool.Add(new_connection);
			__PoolObjectAvailable.Add(false);

			return new_connection;
		}

		public static void ReleaseConnection(ref NpgsqlConnection connection)
		{
			int connection_index = __Pool.IndexOf(connection);

			if (connection_index != -1)
			{
				if (connection_index >= __PoolSize)
				{
					__PoolObjectAvailable.RemoveAt(connection_index);
					__Pool.RemoveAt(connection_index);
				}
				else
				{
					__PoolObjectAvailable[connection_index] = true;
				}
			}
		}

	}
}
