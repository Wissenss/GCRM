using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Business;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

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
			/* --------------------------------------------------
             * 
             * default root credentials are:
			 *
             * username: root
             * password: trafficJam32
             *
			 * this are only valid if setting "RootLogin.Enabled" is true
             * sysadmin should set it to false once the admin user is created
			 * 
			 * -------------------------------------------------- */

			if (SettingsHandler.GetSetting<bool>("RootLogin.Enabled", true, 0, true) == false)
			{
				return false;
			}

			string hash = UsersHandler.GetPasswordHash(username, password);

			return username.Equals("root") && hash.Equals("531761501921173663562461785925019011192679781351239240713687102152101773780247");
		}

		public static Error Login(string username, string password)
		{
			IsRootUser = valid_root_login(username, password);

			if (IsRootUser)
			{
				Session.User = new TUser()
				{
					Name = "root",
					Username = "root",
					Enabled = true,
					Citizen = new TCitizen(),
				};

				trace_login(username);

				return 0;
			}
			
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

			trace_login(username);

			return 0;
		}

		private static void trace_login(string username)
		{
			StringBuilder log_message = new StringBuilder();

			log_message.AppendLine($"GCRM v{BConstants.GetProductVersion()} ACTION LOG");
			log_message.AppendLine($"==================================================");
			log_message.AppendLine($"evento:  {BConstants.GetEventLogTypeName(TEventLogType.user_login)}");
			log_message.AppendLine($"fecha/hora:   {DateTime.Now}");
			log_message.AppendLine($"entidad: ");
			log_message.AppendLine($"usuario: \t{username}");
			log_message.AppendLine($"==================================================");

			EventLogHandler.AddEventLog(TEventLogType.user_login, Session.User.Id, Session.User.Id, TEntityType.user, log_message.ToString(), DateTime.Now);
		}
	}
}
