using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TUserPermission
	{
		public int Id;
		public int UserId;
		public string Name;
		public bool Permited;

		public TUserPermission()
		{

		}
		public TUserPermission(int id, string name, bool permited = false)
		{
			Id = id;
			Name = name;
			Permited = permited;
		}

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			UserId = reader.GetInt32(1);
			Permited = reader.GetBoolean(2);
		}
	}
}
