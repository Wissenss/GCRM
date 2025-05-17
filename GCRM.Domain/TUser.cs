using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TUser
	{
		public int Id;
		public string Name;
		public string Username;
		public string PasswordHash;
		public List<TUserPermission> Permissions = new List<TUserPermission>();
		public bool CardDavSyncEnabled;
		public string CardDavURL;
		public string CardDavUsername;
		public string CardDavPassword;
		public TUserGroup Group = new TUserGroup();
		public bool Enabled;
		public TCitizen Citizen;

		public void FillFromReader(DbDataReader reader)
		{
			Citizen = new TCitizen();

			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			Username = reader.GetString(2);
			PasswordHash = reader.GetString(3);
			CardDavSyncEnabled = reader.GetBoolean(4);
			CardDavURL = reader.GetString(5);
			CardDavUsername = reader.GetString(6);
			CardDavPassword = reader.GetString(7);
			Group.Id = reader.GetInt32(8);
			Enabled = reader.GetBoolean(9);
			Citizen.Id = reader.GetInt32(10);
		}

		public bool HasPermission(string permission_name)
		{
			if (Enabled == false)
				return false;

			foreach (TUserPermission permission in Permissions)
			{
				if (permission.Name == permission_name && permission.Permited)
				{
					return true;
				}
			}

			return false;
		}

		public bool HasPermission(int permission_id)
		{
			if (Enabled == false)
				return false;

			foreach (TUserPermission permission in Permissions)
			{
				if (permission.Id == permission_id && permission.Permited)
				{
					return true;
				}
			}

			return false;
		}
	}
}
