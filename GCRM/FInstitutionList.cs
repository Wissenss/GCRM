using Business;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;

namespace GCRM
{
	public partial class FInstitutionList : Form
	{
		FColumnChooser ColumnChooserDlg;
		FInstitutionListFilters FiltersDlg;

		public FInstitutionList()
		{
			InitializeComponent();

			DataGridInstitutions.AutoGenerateColumns = false;

			DataGridInstitutions.DataSource = Catalogs.DSCatalogs;
			DataGridInstitutions.DataMember = "DTInstitutions";

			ColumnChooserDlg = new FColumnChooser(DataGridInstitutions);
			FiltersDlg = new FInstitutionListFilters();
		}

		public void LoadList()
		{
			using (new CursorWait())
			{
				Catalogs.LoadDTInstitutions();

				TreeView.BeginUpdate();
				TreeView.Nodes.Clear();

				foreach (DataRow row in Catalogs.DTInstitutions.Rows)
				{
					if ((int)row["parent_institution_id"] == 0)
					{
						TreeNode head_node = new TreeNode((string)row["name"]);

						TreeView.Nodes.Add(head_node);

						PopulateTreeNode(ref head_node, (int)row["id"]);
					}
				}

				TreeView.EndUpdate();

				TreeView.ExpandAll();
			}

			UpdateStatusStrip();
		}

		public void PopulateTreeNode(ref TreeNode node, int id)
		{
			foreach (DataRow row in Catalogs.DTInstitutions.Rows)
			{
				if ((int)row["parent_institution_id"] == id)
				{
					TreeNode child_node = new TreeNode((string)row["name"]);

					node.Nodes.Add(child_node);

					PopulateTreeNode(ref child_node, (int)row["id"]);
				}
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAdd.Visible = Session.HasPermission("Instituciones.Crear");
				BEdit.Visible = Session.HasPermission("Instituciones.Editar");
				BRead.Visible = Session.HasPermission("Instituciones.Consultar");
				BDelete.Visible = Session.HasPermission("Instituciones.Eliminar");
				BCategories.Visible = Session.HasPermission("Instituciones.Categorias.Consultar");
				BDuplicate.Visible = Session.HasPermission("Instituciones.Crear");
				BAttentionRequired.Visible = Session.HasPermission("Instituciones.SetAttentionRequired");
			}
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

		private void BDelete_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionId();

			DialogResult result = MessageBox.Show(
			 "¿Está seguro de que desea eliminar esta institución?",
			 "Confirmar eliminación",
			 MessageBoxButtons.YesNo,
			 MessageBoxIcon.Warning
			 );

			if (result != DialogResult.Yes || id == 0)
			{
				return;
			}

			Error error = InstitutionsHandler.DeleteInstitutionById(id);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			LoadList();
		}

		private void BShowHierarchy_Click(object sender, EventArgs e)
		{
			SplitContainer.Panel2Collapsed = BShowHierarchy.Checked == false;
		}

		private void BSearch_Click(object sender, EventArgs e)
		{
			PanelSearch.Visible = BSearch.Checked;

			FilterList();
		}

		private void FilterList()
		{
			string filter = "true";
			string search = TextBoxSearch.Text.Trim();

			if (BSearch.Checked && search.Length > 0)
			{
				filter += @$" and (
												name like '%{search}%' OR
												society_sector_name like '%{search}%' OR
												category_name like '%{search}%' OR
												description like '%{search}%'
									    )";
			}

			if (FiltersDlg.FilterCategory)
			{
				filter += $" and category_id = {FiltersDlg.Category.Id}";
			}

			if (FiltersDlg.FilterSector)
			{
				filter += $" and society_sector = {(int)FiltersDlg.Sector}";
			}

			Catalogs.DTInstitutions.DefaultView.RowFilter = filter;

			DataGridInstitutions.DataSource = Catalogs.DTInstitutions;
			DataGridInstitutions.Refresh();

			UpdateStatusStrip();
		}

		private void FInstitutionList_Leave(object sender, EventArgs e)
		{
			// clear the filter so when this global datatable is use somewhere we keep on seeing all rows
			Catalogs.DTInstitutions.DefaultView.RowFilter = "";
		}

		private void TextBoxSearch_TextChanged(object sender, EventArgs e)
		{
			FilterList();
		}

		private void BCategories_Click(object sender, EventArgs e)
		{
			using (FInstitutionCategoryList institution_category_list_dlg = new FInstitutionCategoryList())
			{
				institution_category_list_dlg.ShowDialog();
			}

			LoadList();
		}

		private void BExcelExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog.DefaultExt = $".xlsx";
			SaveFileDialog.FileName = $"listado_instituciones_{DateTime.Now.ToString("yyyyMMdd")}";
			SaveFileDialog.Filter = $"Excel (*.xlsx) | Todos (*.*)";

			if (SaveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			try
			{
				using (new CursorWait())
				using (var workbook = new XLWorkbook())
				{
					var worksheet = workbook.Worksheets.Add("Instituciones");

					XLColor headers_color = XLColor.LightGray;

					int row_index = 1;

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "#", headers_color, 3);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Id", headers_color, 3);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Nombre", headers_color, 30);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Sector", headers_color, 25);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Categoría", headers_color, 30);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Descripción", headers_color, 100);

					for (int i = 0; i < DataGridInstitutions.Rows.Count; i++)
					{
						DataGridViewRow row = DataGridInstitutions.Rows[i];

						row_index = 1;

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, i.ToString());
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, ((int)row.Cells["colId"].Value).ToString());
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colName"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colSocietySectorName"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colCategoryName"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colDescription"].Value);
					}

					workbook.SaveAs(SaveFileDialog.FileName);
				}
			}
			catch (Exception ex)
			{
				Utilities.ShowExceptionDialog(ex);
			}
		}

		private void UpdateStatusStrip()
		{
			TSSLRecordCount.Text = $"Registros: {DataGridInstitutions.RowCount}";

			TSSLFilters.Text = "";

			if (FiltersDlg.FilterCategory)
			{
				TSSLFilters.Text += $"Categoría = {FiltersDlg.Category.Name}, ";
			}

			if (FiltersDlg.FilterSector)
			{
				TSSLFilters.Text += $"Sector = {BConstants.GetSocietySectorName(FiltersDlg.Sector)}, ";
			}

			if (TSSLFilters.Text.Length > 0)
			{
				TSSLFilters.Text = $"  Filtros: {TSSLFilters.Text.TrimEnd(',', ' ')}";
			}
		}

		private void BFields_Click(object sender, EventArgs e)
		{
			ColumnChooserDlg.ShowDialog();
		}

		private void BFilter_Click(object sender, EventArgs e)
		{
			if (FiltersDlg.ShowDialog() == DialogResult.OK)
			{
				FilterList();
			}
		}

		private void FInstitutionList_FormClosed(object sender, FormClosedEventArgs e)
		{
			Catalogs.DTInstitutions.DefaultView.RowFilter = "";
		}

		private void BDuplicate_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionId();

			if (id == 0)
				return;

			using (FInstitutionData institution_data_dlg = new FInstitutionData())
			{
				institution_data_dlg.SetAccessMode(FAccessMode.Create);
				institution_data_dlg.DuplicateId(id);

				if (institution_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BAttentionRequired_Click(object sender, EventArgs e)
		{
			if (DataGridInstitutions.SelectedRows.Count == 0)
			{
				return;
			}

			DataGridViewRow row = DataGridInstitutions.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			bool attentionRequired = !(bool)row.Cells["colAttentionRequired"].Value;

			using (new CursorWait())
			{
				Error error = InstitutionsHandler.SetInstitutionAttentionRequired(id, attentionRequired);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}
			}

			// update the data manually as the grid is not updated and doing it may take a long time
			row.Cells["colAttentionRequired"].Value = attentionRequired;

			DataGridInstitutions.InvalidateRow(row.Index);
		}

		private void DataGridInstitutions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridViewRow row = DataGridInstitutions.Rows[e.RowIndex];

			if (row.Cells["colAttentionRequired"].Value == null)
				return;

			if ((bool)row.Cells["colAttentionRequired"].Value)
			{
				e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
				e.CellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 150, 150);
			}
		}
	}
}
