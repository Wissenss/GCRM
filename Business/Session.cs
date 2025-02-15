using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public static class Session
	{
		public static TUser User = new TUser();
		private static bool IsRootUser = false; 

		public static bool HasPermission(string permission_name)
		{
			if (IsRootUser) 
			{
				return true;
			}

			foreach(TUserPermission permission in User.Permissions)
			{
				if (permission.Name == permission_name && permission.Permited)
				{
					return true;
				}
			}

			return false;
		}

		public static Error Refresh()
		{
			Error error = UsersHandler.GetUserById(User.Id, out User);

			return error;
		}

		private static bool valid_root_login(string username, string password)
		{
			return username.Equals("root") && password.Equals("trafficJam32");
		}

		public static Error Login(string username, string password)
		{
			// not a good practice what so ever!!!
			// --------------------------------------------------
			IsRootUser = valid_root_login(username, password);

			if (IsRootUser)
			{
				Session.User.Name = "root";
				Session.User.Username = "root";

				return 0;
			}
			// --------------------------------------------------

			Error error = UsersHandler.GetUserByUsername(username, out Session.User);

			if (error == Error.UserNotFound)
			{
				return Error.LoginInvalid;
			}

			string hash = UsersHandler.GetPasswordHash(username, password);

			if (hash.Equals(Session.User.PasswordHash) == false)
			{
				return Error.LoginInvalid;
			}

			return 0;
		}
	}
}
