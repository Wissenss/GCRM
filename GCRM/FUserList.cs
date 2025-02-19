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
			DTUsers.Columns.Add("name", typeof(string));
			DTUsers.Columns.Add("username", typeof(string));
			DTUsers.Columns.Add("password_hash", typeof(string));
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
					row["name"] = user.Name;
					row["username"] = user.Username;
					row["password_hash"] = user.PasswordHash;

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
	}
}
