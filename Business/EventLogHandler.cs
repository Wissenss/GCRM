using Connection;
using Npgsql;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace Business
{
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