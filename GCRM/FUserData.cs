using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FUserData : Form
	{
		DataSet DSUser;
		DataTable DTUserPermissions;

		FAccessMode AccessMode = FAccessMode.Create;
		int Id = 0;
		string PasswordHash = "";
		bool PasswordChanged = false;

		bool PermissionsEditingEnabled = false;
		public FUserData()
		{
			InitializeComponent();

			DSUser = new DataSet();

			DTUserPermissions = new DataTable("DTUserPermissions", "DTUserPermissions");
			DTUserPermissions.Columns.Add("id", typeof(int));
			DTUserPermissions.Columns.Add("name", typeof(string));
			DTUserPermissions.Columns.Add("permitted", typeof(bool));
			DSUser.Tables.Add(DTUserPermissions);

			DataGridUserPermissions.DataSource = DSUser;
			DataGridUserPermissions.DataMember = "DTUserPermissions";
		}

		private void LoadPermissions()
		{
			PermissionsEditingEnabled = Session.HasPermission("Usuarios.Permisos.Editar");

			if (Session.HasPermission("Usuarios.Permisos.Consultar") == false)
			{
				TabControlUser.TabPages.RemoveAt(1);
			}
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxName.Enabled = AccessMode == FAccessMode.Create;
			TextBoxUsername.Enabled = AccessMode == FAccessMode.Create;
			TextBoxPassword.Enabled = AccessMode != FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";

			//DataGridUserPermissions.Enabled = AccessMode != FAccessMode.Read;
		}

		public void SetId(int id)
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

			TUser user = new TUser()
			{
				Id = Id,
				Name = TextBoxName.Text,
				Username = TextBoxUsername.Text,
				PasswordHash = PasswordHash,
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

			DataGridViewRow row		 = DataGridUserPermissions.SelectedRows[0];

			if (row.Cells["colPermited"].Selected)
			{
				//row.Cells["colPermited"].Value = !(bool)row.Cells["colPermited"].Value;

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
	}
}
