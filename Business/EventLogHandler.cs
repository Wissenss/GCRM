using Connection;
using Npgsql;
using System.Data.Common;
using System.Text;
using System.Text.Json;

namespace Business
{
	public enum TEntityType
	{
		unknown = 0,
		
		user = 1,

		citizen = 1001,
		citizen_category = 1002,

		institution = 2001,
		institution_category = 2002,
	}

	public enum TEventLogType
	{
		unknown = 0,

		citizen_add = 1001,
		citizen_edit = 1002,
		citizen_delete = 1003,
		citizen_attention_required = 1004,

		citizen_category_add = 1501,
		citizen_category_edit = 1502,
		citizen_category_delete = 1503,

		institution_add = 2001,
		institution_edit = 2002,
		institution_delete = 2003,
		institution_attention_required = 2004,

		institution_category_add = 2501,
		institution_category_edit = 2502,
		institution_category_delete = 2503,
	}

	public class TEventLogEntity
	{
		public int Id;
		public TEntityType EntityType;
	}

	public class TEventLog
	{
		public int Id;
		public string Message;
		public TUser User = new TUser();
		public TEventLogEntity PrimaryEntity = new TEventLogEntity();
		public DateTime DateTime;
		public TEventLogType Type;
		public string Version;

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			User.Id = reader.GetInt32(1);
			Message = reader.GetString(2);


			PrimaryEntity.Id = reader.GetInt32(3);
			PrimaryEntity.EntityType = (TEntityType)reader.GetInt32(4);

			DateTime = reader.GetDateTime(5);

			Type = (TEventLogType)reader.GetInt32(6); 

			Version = reader.GetString(7);
		}
	}

	public class EventLogHandler
	{
		public static Error AddEventLog(TEventLog log)
		{
			var conn = ConnectionPool.GetConnection();

			string sql = @"
				INSERT INTO event_logs(
					message,	
					user_id, 
					primary_entity_id, 
					primary_entity_type,
					datetime,
					type	
				)VALUES(
					@message, 
					@user_id, 
					@primary_entity_id, 
					@primary_entity_type,
					@datetime,
					@type);";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@message", log.Message);
				cmd.Parameters.AddWithValue("@user_id", log.User.Id);
				cmd.Parameters.AddWithValue("@primary_entity_id", log.PrimaryEntity.Id);
				cmd.Parameters.AddWithValue("@primary_entity_type", (int)log.PrimaryEntity.EntityType);
				cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
				cmd.Parameters.AddWithValue("@type", (int)log.Type);	

				cmd.ExecuteNonQuery();
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetEventLogs(out List<TEventLog> logs)
		{
			logs = new List<TEventLog>();

			var conn = ConnectionPool.GetConnection();

			string sql = "SELECT el.*, u.name as user_name FROM event_logs el LEFT JOIN users u ON el.user_id = u.id ORDER BY datetime DESC;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			using (var reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					var log = new TEventLog();

					log.FillFromReader(reader);

					if (log.User.Id != 0)
						log.User.Name = reader.GetString(reader.GetOrdinal("user_name"));

					logs.Add(log);
				}
			}

			return 0;
		}
	
		public static Error AddEventLog(TEventLogType event_type, int user_id, int entity_id, TEntityType entity_type, TEntity entity, DateTime datetime)
		{
			TEventLog log = new TEventLog()
			{
				Message = "",
				User = new TUser() { Id = user_id },
				PrimaryEntity = new TEventLogEntity() { Id = entity_id, EntityType = entity_type },
				DateTime = datetime,
				Type = event_type
			};

			StringBuilder message = new StringBuilder();

			message.AppendLine($"GCRM v{BConstants.GetProductVersion()} ACTION LOG");
			message.AppendLine($"==================================================");
			message.AppendLine($"evento:  {BConstants.GetEventLogTypeName(log.Type)}");
			message.AppendLine($"fecha/hora:   {log.DateTime}");

			if (entity != null)
			{
				message.AppendLine($"entidad: ");
				message.AppendLine($"{entity.GetAsLogString()}");
			}

			message.AppendLine($"==================================================");

			log.Message = message.ToString().Replace("\\u", "\r\n");

			return AddEventLog(log);
		}

		public static Error AddEventLog(TEventLogType event_type, int user_id, int entity_id, TEntityType entity_type, string message, DateTime datetime)
		{
			TEventLog log = new TEventLog()
			{
				Message = message,
				User = new TUser() { Id = user_id },
				PrimaryEntity = new TEventLogEntity() { Id = entity_id, EntityType = entity_type },
				DateTime = datetime,
				Type = event_type
			};

			return AddEventLog(log);
		}
	} 
}