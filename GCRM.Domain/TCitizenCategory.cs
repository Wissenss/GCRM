using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TCitizenCategory
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
	}
}
