using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TCitizenCategory : TEntity
	{
		public int Id;
		public string Name = "";
		public string Description = "";

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(reader.GetOrdinal("id"));
			Name = reader.GetString(reader.GetOrdinal("name"));
			Description = reader.GetString(reader.GetOrdinal("description"));
		}

		public void PropertiesToUpper()
		{
			Name = Name.ToUpper();
			Description = Description.ToUpper();
		}

		public override string GetAsLogString()
		{
			StringBuilder log_string = new StringBuilder();

			log_string.AppendLine($"Id:              \t{Id}");
			log_string.AppendLine($"Name:            \t{Name}");
			log_string.AppendLine($"Description:     \t{Description}");

			return log_string.ToString();
		}
	}
}
