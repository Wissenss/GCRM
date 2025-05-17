using Business;
using System.Data;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FCitizenRelationshipRoleList : Form
	{
		DataSet DSRelationshipRoles;
		DataTable DTRelationshipRoles;

		public FCitizenRelationshipRoleList()
		{
			InitializeComponent();

			DSRelationshipRoles = new DataSet();

			DTRelationshipRoles = new DataTable();
			DTRelationshipRoles.Columns.Add("id", typeof(int));
			DTRelationshipRoles.Columns.Add("name", typeof(string));
			DSRelationshipRoles.Tables.Add(DTRelationshipRoles);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridRelationships, "colId", "Id", "id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colName", "Relación", "name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.Fill);

			DataGridRelationships.DataSource = DSRelationshipRoles;
			DataGridRelationships.DataMember = DTRelationshipRoles.TableName;

			LoadPermissions();
			LoadList();
		}

		private void LoadPermissions()
		{
			BAdd.Visible = Session.User.HasPermission("Ciudadanos.Relaciones.Roles.Crear");
			BEdit.Visible = Session.User.HasPermission("Ciudadanos.Relaciones.Roles.Editar");
			BRead.Visible = Session.User.HasPermission("Ciudadanos.Relaciones.Roles.Consultar");
			BDelete.Visible = Session.User.HasPermission("Ciudadanos.Relaciones.Roles.Eliminar");
		}

		private void LoadList()
		{
			using (new CursorWait())
			{
				Error error = CitizensHandler.GetCitizenRelationshipRoles(out List<TCitizenRelationshipRole> roles);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTRelationshipRoles.BeginLoadData();
				DTRelationshipRoles.Clear();

				foreach (TCitizenRelationshipRole role in roles)
				{
					DataRow row = DTRelationshipRoles.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;

					DTRelationshipRoles.Rows.Add(row);
				}

				DTRelationshipRoles.EndLoadData();
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (var role_dlg = new FCitizenRelationshipRoleData())
			{
				role_dlg.SetMode(FAccessMode.Create);

				if (role_dlg.ShowDialog() == DialogResult.OK)
					LoadList();
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = DataGridUtilities.GetSelectedId(DataGridRelationships);

			if (id == 0)
				return;

			using (var role_dlg = new FCitizenRelationshipRoleData())
			{
				role_dlg.SetMode(FAccessMode.Update);
				role_dlg.SetId(id);

				if (role_dlg.ShowDialog() == DialogResult.OK)
					LoadList();
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = DataGridUtilities.GetSelectedId(DataGridRelationships);

			if (id == 0)
				return;

			using (var role_dlg = new FCitizenRelationshipRoleData())
			{
				role_dlg.SetMode(FAccessMode.Update);
				role_dlg.SetId(id);
				role_dlg.ShowDialog();
			}
		}

		private void BDelete_Click(object sender, EventArgs e)
		{
			int id = DataGridUtilities.GetSelectedId(DataGridRelationships);

			if (id == 0)
				return;

			Error error = CitizensHandler.DeleteCitizenRelationshipRoleById(id);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			LoadList();
		}
	}
}
