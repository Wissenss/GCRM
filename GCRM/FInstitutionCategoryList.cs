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
	public partial class FInstitutionCategoryList : Form
	{
		public FInstitutionCategoryList()
		{
			InitializeComponent();

			DataGridInstitutionCategories.DataSource = Catalogs.DSCatalogs;
			DataGridInstitutionCategories.DataMember = "DTInstitutionCategories";
		}

		private void LoadList()
		{
			Catalogs.LoadDTInstitutionCategories();
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void LoadPermissions()
		{
			BAdd.Visible = Session.HasPermission("Instituciones.Categorias.Crear");
			BEdit.Visible = Session.HasPermission("Instituciones.Categorias.Editar");
			BRead.Visible = Session.HasPermission("Instituciones.Categorias.Consultar");
		}

		private void FInstitutionCategoryList_Load(object sender, EventArgs e)
		{
			LoadList();
			LoadPermissions();
		}

		private int GetSelectedInstitutionCategoryId()
		{
			if (DataGridInstitutionCategories.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridInstitutionCategories.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FInstitutionCategoryData institution_categor_dlg = new FInstitutionCategoryData())
			{
				if (institution_categor_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionCategoryId();

			if (id == 0)
			{
				return;
			}

			using (FInstitutionCategoryData institution_categor_dlg = new FInstitutionCategoryData())
			{
				institution_categor_dlg.SetAccessMode(FAccessMode.Update);
				institution_categor_dlg.SetId(id);

				if (institution_categor_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionCategoryId();

			if (id == 0)
			{
				return;
			}

			using (FInstitutionCategoryData institution_categor_dlg = new FInstitutionCategoryData())
			{
				institution_categor_dlg.SetAccessMode(FAccessMode.Read);
				institution_categor_dlg.SetId(id);

				if (institution_categor_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}
	}
}
