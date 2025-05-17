using GCRM.Domain.Enums;
using System.Data.Common;

namespace GCRM.Domain
{
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
}
