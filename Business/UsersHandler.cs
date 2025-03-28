using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Connection;
using Npgsql;

namespace Business
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

	public class TUser
	{
		public int Id;
		public string Name;
		public string Username;
		public string PasswordHash;
		public List<TUserPermission> Permissions;
		public bool CardDavSyncEnabled;
		public string CardDavURL;
		public string CardDavUsername;
		public string CardDavPassword;
		public TUserGroup Group = new TUserGroup(); 

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			Username = reader.GetString(2);
			PasswordHash = reader.GetString(3);
			CardDavSyncEnabled = reader.GetBoolean(4);
			CardDavURL = reader.GetString(5);
			CardDavUsername = reader.GetString(6);
			CardDavPassword = reader.GetString(7);
			Group.Id = reader.GetInt32(8);
		}

		public bool HasPermission(string permission_name)
		{
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

	public static class UsersHandler
	{
		public static List<TUserPermission> UserPermissionsCatalog { get; private set; }

		static UsersHandler()
		{
			UserPermissionsCatalog = new List<TUserPermission>()
			{
				new TUserPermission(51, "Conexion.Editar"),								// editar la configuración de conexión

				new TUserPermission(61, "Settings.Editar"),
				new TUserPermission(62, "Settings.Consultar"),

				new TUserPermission(72, "Queries.Run"),

				// user related permissions
				new TUserPermission(101, "Usuarios.Editar"),							// editar usuarios
				new TUserPermission(102, "Usuarios.Consultar"),						// consultar la lista de todos los usuarios
				new TUserPermission(103, "Usuarios.Eliminar"),						// eliminar usuarios
				new TUserPermission(104, "Usuarios.Crear"),								// crear usuarios
				
				new TUserPermission(111, "Usuarios.Permisos.Editar"),			// editar los permisos de el/los usuarios
				new TUserPermission(112, "Usuarios.Permisos.Consultar"),	// consultar los permisos
			
				new TUserPermission(151, "Usuarios.Grupos.Editar"),				// editar los grupos de usuarios	
				new TUserPermission(152, "Usuarios.Grupos.Consultar"),			// consultar los grupos de usuarios
				new TUserPermission(153, "Usuarios.Grupos.Eliminar"),			// eliminar los grupos de usuarios
				new TUserPermission(154, "Usuarios.Grupos.Crear"),					// crear los grupos de usuarios

				new TUserPermission(161, "Usuarios.Grupos.Permisos.Editar"),
				new TUserPermission(162, "Usuarios.Grupos.Permisos.Consultar"),

				// institution related permissions
				new TUserPermission(201, "Instituciones.Editar"),
				new TUserPermission(202, "Instituciones.Consultar"),
				new TUserPermission(203, "Instituciones.Eliminar"),
				new TUserPermission(204, "Instituciones.Crear"),

				new TUserPermission(211, "Instituciones.Roles.Editar"),
				new TUserPermission(212, "Instituciones.Roles.Consultar"),
				new TUserPermission(213, "Instituciones.Roles.Eliminar"),
				new TUserPermission(214, "Instituciones.Roles.Crear"),

				new TUserPermission(251, "Instituciones.Categorias.Editar"),
				new TUserPermission(252, "Instituciones.Categorias.Consultar"),
				new TUserPermission(253, "Instituciones.Categorias.Eliminar"),
				new TUserPermission(254, "Instituciones.Categorias.Crear"),

				// citizen related permissions
				new TUserPermission(301, "Ciudadanos.Editar"),
				new TUserPermission(302, "Ciudadanos.Consultar"),
				new TUserPermission(303, "Ciudadanos.Eliminar"),
				new TUserPermission(304, "Ciudadanos.Crear"),

				new TUserPermission(311, "Ciudadanos.NoEspecificarContacto"),
				new TUserPermission(312, "Ciudadanos.NoEspecificarInstitucion"),
				new TUserPermission(313, "Ciudadanos.NoEspecificarCargo"),
				new TUserPermission(314, "Ciudadanos.NoEspecificarCURP"),

				new TUserPermission(331, "Ciudadanos.Electoral.Consultar"),

				new TUserPermission(351, "Ciudadanos.Categorias.Editar"),
				new TUserPermission(352, "Ciudadanos.Categorias.Consultar"),
				new TUserPermission(353, "Ciudadanos.Categorias.Eliminar"),
				new TUserPermission(354, "Ciudadanos.Categorias.Crear"),

				// citizen networks related permissions
				new TUserPermission(401, "Network.Editar"),
				new TUserPermission(402, "Network.Consultar"),
				new TUserPermission(403, "Network.Eliminar"),
				new TUserPermission(404, "Network.Crear"),

				new TUserPermission(411, "Network.Hierarchy.Editar"),

				new TUserPermission(431, "Network.Roles.Editar"),
				new TUserPermission(432, "Network.Roles.Consultar"),
				new TUserPermission(433, "Network.Roles.Eliminar"),
				new TUserPermission(434, "Network.Roles.Crear"),

				new TUserPermission(441, "Network.Roles.hierarchy.Editar"),

				new TUserPermission(461, "Network.Members.Editar"),
				new TUserPermission(462, "Network.Members.Consultar"),
				new TUserPermission(463, "Network.Members.Eliminar"),
				new TUserPermission(464, "Network.Members.Crear"),

				new TUserPermission(471, "Network.Members.Hierarchy.Editar"),

				new TUserPermission(601, "Emails.Consultar"),

				new TUserPermission(611, "Emails.CardDav.Sync")
			};
		}

		public static Error GetUserByUsername(string username, out TUser user)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			user = new TUser();

			string sql = "SELECT * FROM users WHERE username = @username;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@username", username);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows == false)
					{
						error = Error.UserNotFound;
					}
					else
					{
						reader.Read();

						user.FillFromReader(reader);

						user.Permissions = new List<TUserPermission>();
					}
				}
			}

			GetUserPermissions(user.Id, out user.Permissions);

			if (user.Group.Id != 0)
			{
				error = GetUserGroupById(user.Group.Id, out user.Group);

				// TODO: the user should have the joined between the user and the group permissions, not just the ones from the group
				if (error == 0)
					user.Permissions = user.Group.Permissions;
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetUserById(int id, out TUser user)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			user = new TUser();

			string sql = "SELECT * FROM users WHERE id = @id;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows == false)
					{
						error = Error.UserNotFound;
					}
					else
					{
						reader.Read();

						user.FillFromReader(reader);
					}
				}
			}

			GetUserPermissions(id, out user.Permissions);

			if (user.Group.Id != 0)
			{
				error = GetUserGroupById(user.Group.Id, out user.Group);

				// TODO: the user should have the joined between the user and the group permissions, not just the ones from the group
				if (error == 0)
					user.Permissions = user.Group.Permissions;
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}

		public static Error GetUserPermissions(int user_id, out List<TUserPermission> permissions_list)
		{
			var conn = ConnectionPool.GetConnection();

			string sql = "SELECT * FROM user_permissions WHERE user_id = @user_id ORDER BY id;";

			permissions_list = UserPermissionsCatalog.ConvertAll(p => new TUserPermission(p.Id, p.Name, p.Permited));
			permissions_list = permissions_list.OrderBy(p => p.Id).ToList();

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@user_id", user_id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						TUserPermission user_permission = new TUserPermission();

						user_permission.FillFromReader(reader);

						foreach (TUserPermission permission in permissions_list)
						{
							if (user_permission.Id == permission.Id)
							{
								permission.Permited = user_permission.Permited;

								if (reader.Read())
								{
									user_permission.FillFromReader(reader);
								}
								else
								{ 
									break;
								}
							}
						}
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetUsers(out List<TUser> user_list)
		{
			var conn = ConnectionPool.GetConnection();

			user_list = new List<TUser>();

			string sql = "SELECT * FROM users;";

			using (var cmd = new NpgsqlCommand(sql, conn))
			using (var reader = cmd.ExecuteReader()) 
			{
				while (reader.Read())
				{
					TUser user = new TUser();	

					user.FillFromReader(reader);

					user_list.Add(user);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static string GetPasswordHash(string username, string password)
		{
			string password_hash = "";

			using (HashAlgorithm hash = SHA256.Create())
			{
				byte[] byte_hash = hash.ComputeHash(Encoding.UTF8.GetBytes(username+password));

				foreach (byte b in byte_hash)
				{
					password_hash += b.ToString();
				}
			}

			return password_hash;
		}

		public static Error SaveUser(TUser user, bool is_update)
		{
			var conn = ConnectionPool.GetConnection();

			var tran = conn.BeginTransaction();

			string sql = "";

			if (is_update)
			{
				sql = @"
					UPDATE 
						users 
					SET 
						name=@name, 
						username=@username, 
						password_hash=@password_hash, 
						carddav_sync_enabled=@carddav_sync_enabled,
						carddav_url=@carddav_url,		
						carddav_username=@carddav_username,
						carddav_password=@carddav_password,
						user_group_id=@user_group_id	
					WHERE 
						id=@id;";
			}
			else
			{
				sql = @"
					INSERT INTO users(
						name, 
						username, 
						password_hash,
						carddav_sync_enabled,
						carddav_url,		
						carddav_username,
						carddav_password,
						user_group_id
					) VALUES(
						@name, 
						@username, 
						@password_hash,
						@carddav_sync_enabled,
						@carddav_url,		
						@carddav_username,
						@carddav_password,
						@user_group_id
					);";
			}

			using (var cmd = new NpgsqlCommand(sql, conn, tran))
			{
				cmd.Parameters.AddWithValue("@id", user.Id);
				cmd.Parameters.AddWithValue("@name", user.Name);
				cmd.Parameters.AddWithValue("@username", user.Username);
				cmd.Parameters.AddWithValue("@password_hash", user.PasswordHash);
				cmd.Parameters.AddWithValue("carddav_sync_enabled", user.CardDavSyncEnabled);
				cmd.Parameters.AddWithValue("carddav_url", user.CardDavURL);		
				cmd.Parameters.AddWithValue("carddav_username", user.CardDavUsername);
				cmd.Parameters.AddWithValue("carddav_password", user.CardDavPassword);
				cmd.Parameters.AddWithValue("user_group_id", user.Group.Id);

				cmd.ExecuteNonQuery();

				// save the permissions
				cmd.CommandText = "DELETE FROM user_permissions WHERE user_id = @id;";
				cmd.ExecuteNonQuery();

				cmd.CommandText = "INSERT INTO user_permissions(id, user_id, permited) VALUES(@id, @user_id, @permited);";
				
				foreach (TUserPermission permission in user.Permissions)
				{
					cmd.Parameters.Clear();

					cmd.Parameters.AddWithValue("@id", permission.Id);
					cmd.Parameters.AddWithValue("@user_id", user.Id);
					cmd.Parameters.AddWithValue("@permited", permission.Permited);

					cmd.ExecuteNonQuery();
				}
			}

			tran.Commit();

			ConnectionPool.ReleaseConnection(ref conn);	

			return 0;
		}
	
		public static Error GetUserGroupById(int id, out TUserGroup user_group)
		{
			user_group = new TUserGroup();

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT *, (SELECT COUNT(*) FROM users WHERE user_group_id = @id) as no_users FROM user_groups WHERE id = @id;", conn))
			using (var reader = cmd.ExecuteReader())
			{
				if (reader.HasRows == false)
				{
					ConnectionPool.ReleaseConnection(ref conn);

					return Error.UserGroupNotFound;
				}

				reader.Read();

				user_group.FillFromReader(reader);

				user_group.NoUsers = reader.GetInt32(reader.GetOrdinal("no_users"));

				reader.Close();

				// get the group permissions
				cmd.CommandText = "SELECT * FROM user_group_permissions WHERE user_group_id = @id;";

				using (var reader2 = cmd.ExecuteReader())
				{
					while (reader2.Read())
					{
						TUserPermission permission = new TUserPermission();

						permission.FillFromReader(reader2);

						user_group.Permissions.Add(permission);
					}
				}
			}

			GetUserGroupPermissions(id, out user_group.Permissions);

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}

		public static Error GetUserGroupPermissions(int user_group_id, out List<TUserPermission> permissions_list)
		{
			var conn = ConnectionPool.GetConnection();

			string sql = "SELECT * FROM user_group_permissions WHERE user_group_id = @user_group_id ORDER BY id;";

			permissions_list = UserPermissionsCatalog.ConvertAll(p => new TUserPermission(p.Id, p.Name, p.Permited));
			permissions_list = permissions_list.OrderBy(p => p.Id).ToList();

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@user_group_id", user_group_id);

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();

						TUserPermission user_permission = new TUserPermission();

						user_permission.FillFromReader(reader);

						foreach (TUserPermission permission in permissions_list)
						{
							if (user_permission.Id == permission.Id)
							{
								permission.Permited = user_permission.Permited;

								if (reader.Read())
								{
									user_permission.FillFromReader(reader);
								}
								else
								{
									break;
								}
							}
						}
					}
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error GetUserGroups(out List<TUserGroup> user_group_list)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			using (var cmd = new NpgsqlCommand("SELECT * FROM user_groups;", conn))
			using (var reader = cmd.ExecuteReader())
			{
				user_group_list = new List<TUserGroup>();

				while (reader.Read())
				{
					TUserGroup user_group = new TUserGroup();

					user_group.FillFromReader(reader);

					GetUserGroupById(user_group.Id, out user_group);

					user_group_list.Add(user_group);
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return 0;
		}
	
		public static Error SaveUserGroup(TUserGroup user_group, bool is_update)
		{
			Error error = 0;

			var conn = ConnectionPool.GetConnection();

			string sql = "";

			if (is_update)
			{
				sql = @"
					UPDATE 
						user_groups
					SET 
						name=@name
					WHERE 
						id=@id;";
			}
			else
			{
				sql = @"
					INSERT INTO 
					user_groups(
						name
					) VALUES(
						@name
					) RETURNING id;";
			}

			using (var cmd = new NpgsqlCommand(sql, conn))
			{
				cmd.Parameters.AddWithValue("@id", user_group.Id);
				cmd.Parameters.AddWithValue("@name", user_group.Name);

				if (is_update == false)
				{
					user_group.Id = (Int32)(Int64)cmd.ExecuteScalar();
				}
				else
				{
					cmd.ExecuteNonQuery();
				}

				// save the permissions
				cmd.CommandText = "DELETE FROM user_group_permissions WHERE user_group_id = @id;";
				cmd.ExecuteNonQuery();

				cmd.CommandText = "INSERT INTO user_group_permissions(id, user_group_id, permited) VALUES(@id, @user_group_id, @permited);";

				foreach (TUserPermission permission in user_group.Permissions)
				{
					cmd.Parameters.Clear();

					cmd.Parameters.AddWithValue("@id", permission.Id);
					cmd.Parameters.AddWithValue("@user_group_id", user_group.Id);
					cmd.Parameters.AddWithValue("@permited", permission.Permited);

					cmd.ExecuteNonQuery();
				}
			}

			ConnectionPool.ReleaseConnection(ref conn);

			return error;
		}
	}
}
