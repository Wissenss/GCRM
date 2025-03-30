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
	public partial class FUserList : Form
	{
		DataSet DSUsers;
		DataTable DTUsers;

		public FUserList()
		{
			InitializeComponent();

			DSUsers = new DataSet("DSUsers");

			DTUsers = new DataTable("DTUsers", "DTUsers");
			DTUsers.Columns.Add("id", typeof(int));
			DTUsers.Columns.Add("enabled", typeof(bool));
			DTUsers.Columns.Add("name", typeof(string));
			DTUsers.Columns.Add("username", typeof(string));
			DTUsers.Columns.Add("password_hash", typeof(string));
			DTUsers.Columns.Add("carddav_sync_enabled", typeof(bool));
			DTUsers.Columns.Add("group_id", typeof(int));
			DTUsers.Columns.Add("group_name", typeof(string));
			DSUsers.Tables.Add(DTUsers);

			DataGridUsers.DataSource = DSUsers;
			DataGridUsers.DataMember = "DTUsers";
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BEdit.Visible = Session.HasPermission("Usuarios.Editar");
				BAdd.Visible = Session.HasPermission("Usuarios.Crear");
				BRead.Visible = Session.HasPermission("Usuarios.Consultar");
				BSyncAll.Visible = Session.HasPermission("Emails.CardDav.Sync");
			}
		}

		private void FUserList_Load(object sender, EventArgs e)
		{
			LoadPermissions();
			LoadList();
		}

		public void LoadList()
		{
			using (new CursorWait())
			{
				DTUsers.BeginLoadData();
				DTUsers.Rows.Clear();

				List<TUser> users_list = new List<TUser>();

				Error error = UsersHandler.GetUsers(out users_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				foreach (TUser user in users_list)
				{
					DataRow row = DTUsers.NewRow();

					row["id"] = user.Id;
					row["enabled"] = user.Enabled;
					row["name"] = user.Name;
					row["username"] = user.Username;
					row["password_hash"] = user.PasswordHash;
					row["carddav_sync_enabled"] = user.CardDavSyncEnabled;
					row["group_id"] = user.Group.Id;
					row["group_name"] = user.Group.Name;

					DTUsers.Rows.Add(row);
				}

				DTUsers.EndLoadData();
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private int GetSelectedUserId()
		{
			if (DataGridUsers.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridUsers.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FUserData user_data_dlg = new FUserData())
			{
				if (user_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedUserId();

			if (id == 0)
			{
				return;
			}

			using (FUserData user_data_dlg = new FUserData())
			{
				user_data_dlg.SetAccessMode(FAccessMode.Update);
				user_data_dlg.SetId(id);

				if (user_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = GetSelectedUserId();

			if (id == 0)
			{
				return;
			}

			using (FUserData user_data_dlg = new FUserData())
			{
				user_data_dlg.SetAccessMode(FAccessMode.Read);
				user_data_dlg.SetId(id);

				if (user_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BSyncAll_Click(object sender, EventArgs e)
		{
			if (Utilities.ShowConfirmDialog("¿Desea sincronizar todas las cuentas de CardDav?") != DialogResult.Yes)
				return;

			foreach (DataRow row in DTUsers.Rows)
			{
				if ((bool)row["carddav_sync_enabled"] == false)
					continue;

				TUser user = new TUser();

				using (new CursorWait())
				{
					Error error = UsersHandler.GetUserById((int)row["id"], out user);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}
				}

				using (FEmailSync sync_dlg = new FEmailSync())
				{
					sync_dlg.TextBoxCardDavURL.Text = user.CardDavURL;
					sync_dlg.TextBoxUsername.Text = user.CardDavUsername;
					sync_dlg.TextBoxPassword.Text = user.CardDavPassword;

					try
					{
						sync_dlg.BSync_Click(this, null);
					}
					catch (Exception ex)
					{
						Utilities.ShowExceptionDialog(ex);
						continue;
					}
				}
			}
		}
	}
}
