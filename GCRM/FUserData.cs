using Business;
using System.Data;
using System.Text;

namespace GCRM
{
	public partial class FUserData : Form
	{
		DataSet DSUser;
		DataTable DTUserPermissions;
		DataTable DTUserGroups;

		FAccessMode AccessMode = FAccessMode.Create;
		int Id = 0;
		string PasswordHash = "";
		bool PasswordChanged = false;

		bool PermissionsEditingEnabled = false;
		public FUserData()
		{
			InitializeComponent();

			DSUser = new DataSet();

			DTUserGroups = new DataTable("DTUserGroups");
			DTUserGroups.Columns.Add("id", typeof(int));
			DTUserGroups.Columns.Add("name", typeof(string));
			DSUser.Tables.Add(DTUserGroups);

			DTUserPermissions = new DataTable("DTUserPermissions", "DTUserPermissions");
			DTUserPermissions.Columns.Add("id", typeof(int));
			DTUserPermissions.Columns.Add("name", typeof(string));
			DTUserPermissions.Columns.Add("permitted", typeof(bool));
			DSUser.Tables.Add(DTUserPermissions);

			DataGridUserPermissions.DataSource = DSUser;
			DataGridUserPermissions.DataMember = "DTUserPermissions";

			LoadUserGroups();
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				PermissionsEditingEnabled = Session.HasPermission("Usuarios.Permisos.Editar");

				if (Session.HasPermission("Usuarios.Permisos.Consultar") == false)
					TabControlUser.TabPages.Remove(TabPermissions);

				if (Session.HasPermission("Emails.CardDav.Sync") == false)
					TabControlUser.TabPages.Remove(TabCarddav);

				Group.Visible = Session.HasPermission("Usuarios.Permisos.Editar");
				LGroup.Visible = Session.HasPermission("Usuarios.Permisos.Editar");
				Enabled.Visible = Session.HasPermission("Usuarios.Permisos.Editar");
			}
		}

		private void LoadUserGroups()
		{
			using (new CursorWait())
			{
				Error error = UsersHandler.GetUserGroups(out List<TUserGroup> user_groups_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				user_groups_list.Insert(0, new TUserGroup()
				{
					Id = 0,
					Name = "Ninguno"
				});

				DTUserGroups.BeginLoadData();
				DTUserGroups.Clear();

				foreach (TUserGroup user in user_groups_list)
				{
					DataRow row = DTUserGroups.NewRow();

					row["id"] = user.Id;
					row["name"] = user.Name;

					DTUserGroups.Rows.Add(row);
				}

				DTUserGroups.EndLoadData();

				Group.DataSource = DTUserGroups;
				Group.DisplayMember = "name";
				Group.ValueMember = "id";
				Group.SelectedIndex = 0; 
			}
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxUsername.Enabled = AccessMode == FAccessMode.Create;
			TextBoxPassword.Enabled = AccessMode != FAccessMode.Read;

			CarddavSyncEnabled.Enabled = AccessMode != FAccessMode.Read;
			CardDavURL.Enabled = AccessMode != FAccessMode.Read;
			CarddavUsername.Enabled = AccessMode != FAccessMode.Read;
			CarddavPassword.Enabled = AccessMode != FAccessMode.Read;

			Group.Enabled = AccessMode != FAccessMode.Read;
			Enabled.Enabled = AccessMode != FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
		}

		public void SetId(int id)
		{
			using (new CursorWait())
			{
				Id = id;

				TUser user;

				Error error = UsersHandler.GetUserById(id, out user);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				this.Text = $"Usuario - {user.Username}";

				TextBoxName.Text = user.Name;
				TextBoxUsername.Text = user.Username;
				TextBoxPassword.Text = "unknown password"; // the password is not load here, as we only care about the hash, which is assign when changing the contents of this text box 
				PasswordHash = user.PasswordHash;
				CarddavSyncEnabled.Checked = user.CardDavSyncEnabled;
				CardDavURL.Text = user.CardDavURL;
				CarddavPassword.Text = user.CardDavPassword;
				CarddavUsername.Text = user.CardDavUsername;
				Group.SelectedValue = user.Group.Id;
				Enabled.Checked = user.Enabled;

				DTUserPermissions.BeginLoadData();
				DTUserPermissions.Clear();

				foreach (TUserPermission permission in user.Permissions)
				{
					DataRow row = DTUserPermissions.NewRow();

					row["id"] = permission.Id;
					row["name"] = permission.Name;
					row["permitted"] = permission.Permited;

					DTUserPermissions.Rows.Add(row);
				}

				DTUserPermissions.EndLoadData();
			}
		}

		private void FUserData_Load(object sender, EventArgs e)
		{
			LoadPermissions();
		}

		private void TextBoxPassword_Enter(object sender, EventArgs e)
		{
			TextBoxPassword.Text = "";
			PasswordHash = "";
			PasswordChanged = true;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (TextBoxName.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar el nombre");
			}

			if (TextBoxUsername.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar el usuario");
			}

			if (TextBoxPassword.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar la clave");
			}

			if (CarddavSyncEnabled.Checked)
			{
				if (CardDavURL.Text.Trim().Length == 0)
				{
					errors.AppendLine("Debe especificar la URL del servidor CardDAV");
				}

				if (CarddavUsername.Text.Trim().Length == 0)
				{
					errors.AppendLine("Debe especificar el usuario del servidor CardDAV");
				}

				if (CarddavPassword.Text.Trim().Length == 0)
				{
					errors.AppendLine("Debe especificar la clave del servidor CardDAV");
				}
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);

				return false;
			}

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
			{
				return;
			}

			using (new CursorWait())
			{

				TUser user = new TUser()
				{
					Id = Id,
					Name = TextBoxName.Text,
					Username = TextBoxUsername.Text,
					PasswordHash = PasswordHash,
					CardDavSyncEnabled = CarddavSyncEnabled.Checked,
					CardDavURL = CardDavURL.Text.Trim(),
					CardDavUsername = CarddavUsername.Text.Trim(),
					CardDavPassword = CarddavPassword.Text.Trim(),
					Group = new TUserGroup()
					{
						Id = (int)Group.SelectedValue
					},
					Enabled = Enabled.Checked
				};

				if (PasswordChanged)
				{
					user.PasswordHash = UsersHandler.GetPasswordHash(user.Username, TextBoxPassword.Text);
				}

				user.Permissions = new List<TUserPermission>();

				foreach (DataRow row in DTUserPermissions.Rows)
				{
					TUserPermission permission = new TUserPermission()
					{
						Id = (int)row["id"],
						Name = (string)row["name"],
						Permited = (bool)row["permitted"]
					};

					user.Permissions.Add(permission);
				}

				Error error = UsersHandler.SaveUser(user, AccessMode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				if (Session.User.Id == Id)
				{
					Session.Refresh();
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void TextBoxUsername_TextChanged(object sender, EventArgs e)
		{

		}

		private int GetSelectedUserPermissionId()
		{
			if (DataGridUserPermissions.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridUserPermissions.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void DataGridUserPermissions_Click(object sender, EventArgs e)
		{
			int id = GetSelectedUserPermissionId();

			if (id == 0 || PermissionsEditingEnabled == false || AccessMode == FAccessMode.Read)
			{
				return;
			}

			DataGridViewRow row = DataGridUserPermissions.SelectedRows[0];

			if (row.Cells["colPermited"].Selected)
			{
				foreach (DataRow dt_row in DTUserPermissions.Rows)
				{
					if ((int)dt_row["id"] == id)
					{
						dt_row.BeginEdit();
						dt_row["permitted"] = !(bool)dt_row["permitted"];
						dt_row.EndEdit();

						break;
					}
				}
			}
		}

		private void CarddavSyncEnabled_CheckedChanged(object sender, EventArgs e)
		{
			LCardDavUrl.Enabled = CarddavSyncEnabled.Checked && AccessMode != FAccessMode.Read;
			CardDavURL.Enabled = CarddavSyncEnabled.Checked && AccessMode != FAccessMode.Read;
			LCardDavUsername.Enabled = CarddavSyncEnabled.Checked && AccessMode != FAccessMode.Read;
			CarddavUsername.Enabled = CarddavSyncEnabled.Checked && AccessMode != FAccessMode.Read;
			LCardDavPassword.Enabled = CarddavSyncEnabled.Checked && AccessMode != FAccessMode.Read;
			CarddavPassword.Enabled = CarddavSyncEnabled.Checked && AccessMode != FAccessMode.Read;
		}
	}
}
