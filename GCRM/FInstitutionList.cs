using Business;
using DocumentFormat.OpenXml.Spreadsheet;
using QuestPDF.Fluent;
using Reporter;
using System.Data;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FInstitutionList : Form
	{
		FColumnChooser ColumnChooserDlg;
		FInstitutionListFilters FiltersDlg;
		FAccessMode AccessMode = FAccessMode.Read;

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

				if (BShowHierarchy.Checked)
				{
					RenderTree();
				}
			}

			UpdateStatusStrip();
		}

		private void RenderTree()
		{
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

		private void PopulateTreeNode(ref TreeNode node, int id)
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

		private void SetControls()
		{
			using (new CursorWait())
			{
				BAdd.Visible = Session.HasPermission("Instituciones.Crear");
				BEdit.Visible = Session.HasPermission("Instituciones.Editar");
				BRead.Visible = Session.HasPermission("Instituciones.Consultar") && AccessMode != FAccessMode.Select;
				BDelete.Visible = Session.HasPermission("Instituciones.Eliminar") && AccessMode != FAccessMode.Select;
				BCategories.Visible = Session.HasPermission("Instituciones.Categorias.Consultar") && AccessMode != FAccessMode.Select;
				BDuplicate.Visible = Session.HasPermission("Instituciones.Crear") && AccessMode != FAccessMode.Select;
				BAttentionRequired.Visible = Session.HasPermission("Instituciones.SetAttentionRequired");
				BInstitutionTemplates.Visible = Session.HasPermission("Instituciones.Plantillas.Consultar") && AccessMode != FAccessMode.Select;
				BExcelExport.Visible = AccessMode != FAccessMode.Select;
				//BPrint.Visible = AccessMode != FAccessMode.Select;
				BSelect.Visible = AccessMode == FAccessMode.Select;
			}
		}

		private void FInstitutionList_Load(object sender, EventArgs e)
		{
			SetControls();

			LoadList();

			SettingsUtilities.TryLoadFormConfiguration(this, "institutions\\main_form");
			DataGridUtilities.TryLoadConfiguration(DataGridInstitutions, "institutions\\main_data_grid");
		}

		public int GetSelectedInstitutionId()
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

			RenderTree();
		}

		private void BSearch_Click(object sender, EventArgs e)
		{
			PanelSearch.Visible = BSearch.Checked;

			if (BSearch.Checked)
				TextBoxSearch.Focus();

			FilterList();
		}

		private void FilterList()
		{
			string filter = "true";
			string search = TextBoxSearch.Text.Trim();

			if (BSearch.Checked && search.Length > 0)
			{
				filter += DataGridUtilities.GetFilterCondititonForTextSearch(DataGridInstitutions, Catalogs.DTInstitutions, search);
			}

			if (FiltersDlg.FilterCategory)
			{
				filter += $" and category_id = {FiltersDlg.CategoryId}";
			}

			if (FiltersDlg.FilterSector)
			{
				filter += $" and society_sector = {(int)FiltersDlg.Sector}";
			}

			if (FiltersDlg.FilterAttentionRequired)
			{
				if (FiltersDlg.AttentionRequired == 1)
				{
					filter += $" and attention_required = true";
				}
				else if (FiltersDlg.AttentionRequired == 2)
				{
					filter += $" and attention_required = false";
				}
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

			String title = $"Listado de Instituciones al {DateTime.Now.ToString("yyyy-MM-dd")}";

			if (TSSLFilters.Text.Trim().Length > 0)
			{
				title += $" ({TSSLFilters.Text} ) ";
			}

			DataGridUtilities.ExportToExcel(DataGridInstitutions, SaveFileDialog.FileName, title);
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			SetControls();
		}

		private void UpdateStatusStrip()
		{
			TSSLRecordCount.Text = $"Registros: {DataGridInstitutions.RowCount}";

			// records that require attention
			int attentrion_required = 0;

			foreach (DataRow row in Catalogs.DTInstitutions.Rows)
			{
				if ((bool)row["attention_required"])
					attentrion_required++;
			}

			TSSLRecordAttentionRequiredCount.Visible = attentrion_required > 0;
			TSSLRecordAttentionRequiredCount.Text = $"Atención requerida: {attentrion_required}";

			// filtros
			TSSLFilters.Text = "";

			if (FiltersDlg.FilterCategory)
			{
				TSSLFilters.Text += $"Categoría = {FiltersDlg.CategoryName}, ";
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

			string reason = "";

			if (attentionRequired)
			{
				using (FAttentionRequired reason_dlg = new FAttentionRequired())
				{
					if (reason_dlg.ShowDialog() != DialogResult.OK)
					{
						return;
					}

					reason = reason_dlg.Reason;
				}
			}
			else
			{
				DialogResult confirm_result = Utilities.ShowConfirmDialog(
					"¿Desea marcar este registro como atendido?\n\nAl confirmar, asume la responsabilidad de haber resuelto el motivo por el cual el registro fue marcado como \"atención requerida\"."
				);

				if (confirm_result != DialogResult.Yes)
				{
					return;
				}
			}

			using (new CursorWait())
			{
				Error error = InstitutionsHandler.SetInstitutionAttentionRequired(id, attentionRequired, reason);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}
			}

			// update the data manually as the grid is not updated and doing it may take a long time
			row.Cells["colAttentionRequired"].Value = attentionRequired;
			row.Cells["colAttentionRequiredReason"].Value = reason;

			DataGridInstitutions.InvalidateRow(row.Index);

			UpdateStatusStrip();
			UpdateAttentionRequiredControls();
		}

		private void DataGridInstitutions_SelectionChanged(object sender, EventArgs e)
		{
			UpdateAttentionRequiredControls();
		}

		private void UpdateAttentionRequiredControls()
		{
			DataGridViewRow row = DataGridInstitutions.SelectedRows.Count > 0 ? DataGridInstitutions.SelectedRows[0] : null;

			bool attentionRequired = row?.Cells["colAttentionRequired"].Value is bool value && value;

			BAttentionRequired.Text = attentionRequired ? "&Atendido" : "Necesita &atención";

			TSSLAttentionReason.Text = attentionRequired ? $"Motivo atención: {row.Cells["colAttentionRequiredReason"].Value}" : "";
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

		private void FInstitutionList_FormClosing(object sender, FormClosingEventArgs e)
		{
			SettingsUtilities.TrySaveFormConfiguration(this, "institutions\\main_form");
			DataGridUtilities.TrySaveConfiguration(DataGridInstitutions, "institutions\\main_data_grid");
		}

		private void BPrint_Click(object sender, EventArgs e)
		{
			using (new CursorWait())
			{
				R004DocumentModel model = new R004DocumentModel();

				// filters
				if (FiltersDlg.FilterCategory)
					model.Category = new TInstitutionCategory() { Id = FiltersDlg.CategoryId, Name = FiltersDlg.CategoryName };

				if (FiltersDlg.FilterSector)
					model.SocietySector = FiltersDlg.Sector;

				// institution list
				foreach (DataGridViewRow row in DataGridInstitutions.Rows)
				{
					TInstitution institution = new TInstitution();

					institution.Id = (int)row.Cells["colId"].Value;
					institution.Name = (string)row.Cells["colName"].Value;
					institution.Acronym = (string)row.Cells["colAcronym"].Value;
					institution.Category.Id = (int)row.Cells["colCategoryId"].Value;

					if (institution.Category.Id != 0)
					{
						institution.Category.Name = (string)row.Cells["colCategoryName"].Value;
					}

					institution.Sector = (TSocietySector)row.Cells["colSocietySector"].Value;
					institution.Description = (string)row.Cells["colDescription"].Value;

					model.Institutions.Add(institution);
				}

				R004Document document = new R004Document(model);

				document.GeneratePdfAndShow();
			}
		}

		private void BInstitutionTemplates_Click(object sender, EventArgs e)
		{
			using (FInstitutionTemplateList template_list_dlt = new FInstitutionTemplateList())
			{
				template_list_dlt.ShowDialog();
			}
		}

		private void BSelect_Click(object sender, EventArgs e)
		{
			if (GetSelectedInstitutionId() != 0)
			{
				DialogResult = DialogResult.OK;
			}
		}

		private void DataGridInstitutions_DoubleClick(object sender, EventArgs e)
		{
			if (AccessMode == FAccessMode.Select)
			{
				BSelect_Click(sender, null);
			}
		}
	}
}
