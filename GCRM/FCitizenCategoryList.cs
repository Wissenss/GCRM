using Business;
using GCRM.Domain.Enums;
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

	public partial class FCitizenCategoryList : Form
	{

		public FCitizenCategoryList()
		{
			InitializeComponent();

			DataGridUtilities.AddColumn(DataGridCategories, "colId", "Id", "id", false);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridCategories, "colName", "Nombre", "name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCategories, "colDescription", "Descripción", "description", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.Fill);

			DataGridCategories.DataSource = Catalogs.DSCatalogs;
			DataGridCategories.DataMember = "DTCitizenCategories";

			LoadList();

			LoadPermissions();
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAdd.Visible = Session.HasPermission("Ciudadanos.Categorias.Crear");
				BEdit.Visible = Session.HasPermission("Ciudadanos.Categorias.Editar");
				BRead.Visible = Session.HasPermission("Ciudadanos.Categorias.Consultar");
				BDelete.Visible = Session.HasPermission("Ciudadanos.Categorias.Eliminar");
			}
		}

		private void LoadList()
		{
			using (new CursorWait())
			{
				Catalogs.LoadDTCitizenCategories();
			}
		}

		private int GetSelectedCategoryId()
		{
			return DataGridUtilities.GetSelectedId(DataGridCategories, "colId");
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FCitizenCategoryData citizen_category_dlg = new FCitizenCategoryData())
			{
				citizen_category_dlg.SetAccessMode(FAccessMode.Create);

				if (citizen_category_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCategoryId();

			if (id == 0)
			{
				return;
			}

			using (FCitizenCategoryData citizen_category_dlg = new FCitizenCategoryData())
			{
				citizen_category_dlg.SetAccessMode(FAccessMode.Update);
				citizen_category_dlg.SetId(id);

				if (citizen_category_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCategoryId();

			if (id == 0)
			{
				return;
			}

			using (FCitizenCategoryData citizen_category_dlg = new FCitizenCategoryData())
			{
				citizen_category_dlg.SetAccessMode(FAccessMode.Update);
				citizen_category_dlg.SetId(id);
				citizen_category_dlg.ShowDialog();
			}
		}

		private void BDelete_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCategoryId();

			if (id == 0)
			{
				return;
			}

			if (Utilities.ShowDeleteConfirmDialog("¿Desea eliminar la categoría seleccinada?") != DialogResult.Yes)
			{
				return;
			}

			Error error = CitizensHandler.DeleteCitizenCategoryById(id);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			LoadList();
		}
	}
}
