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
	public partial class FInstitutionTemplateData : Form
	{
		DataSet DSTemplate;
		DataTable DTTemplateRoles;

		FAccessMode AccessMode = FAccessMode.Create;

		private int Id;

		public FInstitutionTemplateData()
		{
			InitializeComponent();

			DSTemplate = new DataSet();
			DTTemplateRoles = new DataTable("DTTemplateRoles");
			DTTemplateRoles.Columns.Add("id", typeof(int));
			DTTemplateRoles.Columns.Add("name", typeof(string));
			DTTemplateRoles.Columns.Add("description", typeof(string));
			DSTemplate.Tables.Add(DTTemplateRoles);

			DataGridTemplateRoles.AutoGenerateColumns = false;

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridTemplateRoles, "colName", "Nombre", "name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridTemplateRoles, "colDescription", "Descripción", "description", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.Fill);
			DataGridUtilities.AddColumn(DataGridTemplateRoles, "colId", "Id", "id", false, display_index++);

			DataGridTemplateRoles.DataSource = DSTemplate;
			DataGridTemplateRoles.DataMember = DTTemplateRoles.TableName;

			LoadPermissions();
		}

		public void LoadPermissions()
		{
			using (new CursorWait())
			{
				if (Session.HasPermission("Instituciones.Plantillas.Roles.Consultar") == false)
				{
					TabControlTemplate.TabPages.Remove(TabRoles);
				}

				BAddRole.Visible = Session.HasPermission("Instituciones.Plantillas.Roles.Crear");
				BEditRole.Visible = Session.HasPermission("Instituciones.Plantillas.Roles.Editar");
				//BDeleteRole.Visible = Session.HasPermission("Instituciones.Plantillas.Roles.Eliminar");
			}
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxDescription.Enabled = AccessMode != FAccessMode.Read;
			BAddRole.Enabled = AccessMode != FAccessMode.Read;
			BEditRole.Enabled = AccessMode != FAccessMode.Read;
			//BDeleteRole.Enabled = AccessMode != FAccessMode.Read; // TODO: allow role deletion
			DataGridTemplateRoles.Enabled = AccessMode != FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
		}

		public void SetId(int templateId)
		{
			using (new CursorWait())
			{
				Id = templateId;

				TInstitutionTemplate template;
				Error error = InstitutionsHandler.GetInstitutionTemplateById(Id, out template);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				TextBoxName.Text = template.Name;
				TextBoxDescription.Text = template.Description;

				DTTemplateRoles.BeginLoadData();
				DTTemplateRoles.Clear();

				foreach (TInstitutionRole role in template.Roles)
				{
					DataRow row = DTTemplateRoles.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;
					row["description"] = role.Description;

					DTTemplateRoles.Rows.Add(row);
				}

				DTTemplateRoles.EndLoadData();

				Text = $"Plantilla de Institución - {template.Name}";
			}
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			using (new CursorWait())
			{
				TInstitutionTemplate template = new TInstitutionTemplate();

				template.Id = Id;
				template.Name = TextBoxName.Text;
				template.Description = TextBoxDescription.Text;

				template.Roles = new List<TInstitutionRole>();

				foreach (DataRow row in DTTemplateRoles.Rows)
				{
					TInstitutionRole role = new TInstitutionRole();

					role.Id = (int)row["id"];
					role.Name = (string)row["name"];
					role.Description = (string)row["description"];
					role.InstitutionTemplateId = Id;

					template.Roles.Add(role);
				}

				Error error = InstitutionsHandler.SaveInstitutionTemplate(template, AccessMode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void BAddRole_Click(object sender, EventArgs e)
		{
			using (FInstitutionTemplateRoleData role_dlg = new FInstitutionTemplateRoleData())
			{
				role_dlg.Id = 0;
				role_dlg.TextBoxName.Text = "";
				role_dlg.TextBoxDescription.Text = "";

				if (role_dlg.ShowDialog(this) == DialogResult.OK)
				{
					DataRow row = DTTemplateRoles.NewRow();

					row["id"] = role_dlg.Id;
					row["name"] = role_dlg.TextBoxName.Text.Trim();
					row["description"] = role_dlg.TextBoxDescription.Text.Trim();

					DTTemplateRoles.Rows.Add(row);
				}
			}
		}

		private void BEditRole_Click(object sender, EventArgs e)
		{
			if (DataGridTemplateRoles.SelectedRows.Count == 0)
				return;

			DataGridViewRow selectedRow = DataGridTemplateRoles.SelectedRows[0];

			using (FInstitutionTemplateRoleData role_dlg = new FInstitutionTemplateRoleData())
			{
				role_dlg.Id = (int)selectedRow.Cells["colId"].Value;
				role_dlg.TextBoxName.Text = (string)selectedRow.Cells["colName"].Value;
				role_dlg.TextBoxDescription.Text = (string)selectedRow.Cells["colDescription"].Value;

				if (role_dlg.ShowDialog(this) == DialogResult.OK)
				{
					foreach (DataRow row in DTTemplateRoles.Rows)
					{
						if ((int)row["id"] == role_dlg.Id)
						{
							row.BeginEdit();

							row["id"] = role_dlg.Id;
							row["name"] = role_dlg.TextBoxName.Text.Trim();
							row["description"] = role_dlg.TextBoxDescription.Text.Trim();

							row.EndEdit();
							
							break;
						}
					}
				}
			}
		}
	}
}
