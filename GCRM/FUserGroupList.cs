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
	public partial class FUserGroupList : Form
	{
		DataSet DSUserGroups;
		DataTable DTUserGroups;

		public FUserGroupList()
		{
			InitializeComponent();

			LoadPermisssions();

			DSUserGroups = new DataSet();
			DTUserGroups = new DataTable("DTUserGroups");
			DTUserGroups.Columns.Add("id", typeof(int));
			DTUserGroups.Columns.Add("name", typeof(string));
			DTUserGroups.Columns.Add("no_users", typeof(int));
			DSUserGroups.Tables.Add(DTUserGroups);

			DataGridUserGroups.AutoGenerateColumns = false;

			DataGridUtilities.AddColumn(DataGridUserGroups, "colId", "Id", "id", false);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridUserGroups, "colName", "Nombre", "name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridUserGroups, "colNoUsers", "No. Usuarios", "no_users", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.Fill);

			DataGridUserGroups.DataSource = DSUserGroups;
			DataGridUserGroups.DataMember = DTUserGroups.TableName;

			LoadUserGroups();
		}

		public void LoadUserGroups()
		{
			using (new CursorWait())
			{
				Error error = UsersHandler.GetUserGroups(out List<TUserGroup> user_groups_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTUserGroups.BeginLoadData();
				DTUserGroups.Clear();

				foreach (TUserGroup user in user_groups_list)
				{
					DataRow row = DTUserGroups.NewRow();

					row["id"] = user.Id;
					row["name"] = user.Name;
					row["no_users"] = user.NoUsers;

					DTUserGroups.Rows.Add(row);
				}

				DTUserGroups.EndLoadData();
			}
		}

		private void LoadPermisssions()
		{
			BAdd.Visible = Session.HasPermission("Usuarios.Grupos.Crear");
			BEdit.Visible = Session.HasPermission("Usuarios.Grupos.Editar");
			BRead.Visible = Session.HasPermission("Usuarios.Grupos.Consultar");
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadUserGroups();
		}

		private int GetSelectedId()
		{
			if (DataGridUserGroups.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridUserGroups.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FUserGroupData user_group_date_dlg = new FUserGroupData())
			{
				user_group_date_dlg.SetAccessMode(FAccessMode.Create);

				if (user_group_date_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadUserGroups();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedId();

			if (id == 0)
			{
				return;
			}

			using (FUserGroupData user_group_date_dlg = new FUserGroupData())
			{
				user_group_date_dlg.SetAccessMode(FAccessMode.Update);
				user_group_date_dlg.SetId(id);

				if (user_group_date_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadUserGroups();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = GetSelectedId();

			if (id == 0)
			{
				return;
			}

			using (FUserGroupData user_group_date_dlg = new FUserGroupData())
			{
				user_group_date_dlg.SetAccessMode(FAccessMode.Read);
				user_group_date_dlg.SetId(id);

				if (user_group_date_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadUserGroups();
				}
			}
		}
	}
}
