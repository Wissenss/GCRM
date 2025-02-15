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
	public partial class FInstitutionList : Form
	{
		public FInstitutionList()
		{
			InitializeComponent();

			DataGridInstitutions.DataSource = Catalogs.DSCatalogs;
			DataGridInstitutions.DataMember = "DTInstitutions";
		}

		public void LoadList()
		{
			Catalogs.LoadDTInstitutions();
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void LoadPermissions()
		{
			BAdd.Visible = Session.HasPermission("Instituciones.Crear");
			BEdit.Visible = Session.HasPermission("Instituciones.Editar");
			BRead.Visible = Session.HasPermission("Instituciones.Consultar");
		}

		private void FInstitutionList_Load(object sender, EventArgs e)
		{
			LoadPermissions();

			LoadList();
		}

		private int GetSelectedInstitutionId()
		{
			if (DataGridInstitutions.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridInstitutions.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FInstitutionData institution_data_dlg = new FInstitutionData())
			{
				institution_data_dlg.SetAccessMode(FAccessMode.Create);

				if (institution_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionId();

			if (id == 0)
			{
				return;
			}

			using (FInstitutionData institution_data_dlg = new FInstitutionData())
			{
				institution_data_dlg.SetAccessMode(FAccessMode.Update);
				institution_data_dlg.SetId(id);

				if (institution_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionId();

			if (id == 0)
			{
				return;
			}

			using (FInstitutionData institution_data_dlg = new FInstitutionData())
			{
				institution_data_dlg.SetAccessMode(FAccessMode.Read);
				institution_data_dlg.SetId(id);

				institution_data_dlg.ShowDialog();
			}
		}
	}
}
