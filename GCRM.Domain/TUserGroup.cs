using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TUserGroup
	{
		public int Id;
		public string Name;
		public List<TUserPermission> Permissions = new List<TUserPermission>();

		public int NoUsers;

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
		}
	}
}
