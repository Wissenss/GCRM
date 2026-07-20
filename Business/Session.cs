using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GCRM.Domain;

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

			return Session.User.HasPermission(permission_name);;
		}

		public static Error Refresh()
		{
			Error error = UsersHandler.GetUserById(User.Id, out User);

			return error;
		}

		private static bool valid_root_login(string username, string password)
		{
			string hash = UsersHandler.GetPasswordHash(username, password);

			return username.Equals("root") && hash.Equals("531761501921173663562461785925019011192679781351239240713687102152101773780247");
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
				Session.User.Enabled = true;
				Session.User.Citizen = new TCitizen();

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

			if (Session.User.Enabled == false)
			{
				return Error.UserUnauthorized;
			}

			return 0;
		}
	}
}
