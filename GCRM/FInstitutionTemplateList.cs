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
	public partial class FInstitutionTemplateList : Form
	{
		DataSet DSTemplates;
		DataTable DTTemplates;

		public FInstitutionTemplateList()
		{
			InitializeComponent();

			DSTemplates = new DataSet();
			DTTemplates = new DataTable("DTTemplates");
			DTTemplates.Columns.Add("id", typeof(int));
			DTTemplates.Columns.Add("name", typeof(string));
			DTTemplates.Columns.Add("description", typeof(string));
			DSTemplates.Tables.Add(DTTemplates);

			DataGridInstitutionTemplates.DataSource = DSTemplates;
			DataGridInstitutionTemplates.DataMember = DTTemplates.TableName;

			LoadPermissions();
			LoadList();
		}

		public void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAdd.Visible = Session.HasPermission("Instituciones.Plantillas.Crear");
				BEdit.Visible = Session.HasPermission("Instituciones.Plantillas.Editar");
				BDelete.Visible = Session.HasPermission("Instituciones.Plantillas.Eliminar");
				BRead.Visible = Session.HasPermission("Instituciones.Plantillas.Ver");
			}
		}

		public void LoadList()
		{
			using (new CursorWait())
			{
				List<TInstitutionTemplate> templates_list;

				Error error = InstitutionsHandler.GetInstitutionTemplates(out templates_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTTemplates.BeginLoadData();
				DTTemplates.Clear();

				foreach (TInstitutionTemplate template in templates_list)
				{
					DataRow row = DTTemplates.NewRow();

					row["Id"] = template.Id;
					row["Name"] = template.Name;
					row["Description"] = template.Description;

					DTTemplates.Rows.Add(row);
				}

				DTTemplates.EndLoadData();
			}
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FInstitutionTemplateData template_data_dlg = new FInstitutionTemplateData())
			{
				template_data_dlg.SetAccessMode(FAccessMode.Create);

				if (template_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = DataGridUtilities.GetSelectedId(DataGridInstitutionTemplates, "colId");

			if (id == 0)
				return;

			using (FInstitutionTemplateData template_data_dlg = new FInstitutionTemplateData())
			{
				template_data_dlg.SetAccessMode(FAccessMode.Update);
				template_data_dlg.SetId(id);

				if (template_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = DataGridUtilities.GetSelectedId(DataGridInstitutionTemplates, "Id");

			if (id == 0)
				return;

			using (FInstitutionTemplateData template_data_dlg = new FInstitutionTemplateData())
			{
				template_data_dlg.SetAccessMode(FAccessMode.Read);
				template_data_dlg.SetId(id);

				template_data_dlg.ShowDialog();
			}
		}

		private void BDelete_Click(object sender, EventArgs e)
		{
			int id = DataGridUtilities.GetSelectedId(DataGridInstitutionTemplates);

			if (id == 0)
				return;

			if (Utilities.ShowDeleteConfirmDialog("¿Desea eliminar la plantilla seleccionada?") != DialogResult.Yes)
				return;

			using (new CursorWait())
			{
				Error error = InstitutionsHandler.DeleteInstitutionTemplateById(id);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				LoadList();
			}
		}
	}
}
