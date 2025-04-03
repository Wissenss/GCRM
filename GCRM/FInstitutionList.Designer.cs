namespace GCRM
{
	partial class FInstitutionList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInstitutionList));
			ToolStrip = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			BRead = new ToolStripButton();
			BRefresh = new ToolStripButton();
			BDelete = new ToolStripButton();
			toolStripSeparator6 = new ToolStripSeparator();
			BDuplicate = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			BShowHierarchy = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			BFields = new ToolStripButton();
			BFilter = new ToolStripButton();
			toolStripSeparator5 = new ToolStripSeparator();
			toolStripSeparator3 = new ToolStripSeparator();
			BExcelExport = new ToolStripButton();
			BPrint = new ToolStripButton();
			toolStripSeparator4 = new ToolStripSeparator();
			BCategories = new ToolStripButton();
			BInstitutionTemplates = new ToolStripButton();
			BSearch = new ToolStripButton();
			toolStripSeparator7 = new ToolStripSeparator();
			BAttentionRequired = new ToolStripButton();
			DataGridInstitutions = new DataGridView();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colAcronym = new DataGridViewTextBoxColumn();
			colSocietySector = new DataGridViewTextBoxColumn();
			colSocietySectorName = new DataGridViewTextBoxColumn();
			colCategoryId = new DataGridViewTextBoxColumn();
			colCategoryName = new DataGridViewTextBoxColumn();
			colDescription = new DataGridViewTextBoxColumn();
			colParentInstitutionId = new DataGridViewTextBoxColumn();
			colAuthorId = new DataGridViewTextBoxColumn();
			colAuthorName = new DataGridViewTextBoxColumn();
			colIdEditor = new DataGridViewTextBoxColumn();
			colEditorName = new DataGridViewTextBoxColumn();
			colAttentionRequired = new DataGridViewCheckBoxColumn();
			SplitContainer = new SplitContainer();
			TreeView = new TreeView();
			TextBoxSearch = new TextBox();
			PanelSearch = new Panel();
			SaveFileDialog = new SaveFileDialog();
			StatusStrip = new StatusStrip();
			TSSLRecordCount = new ToolStripStatusLabel();
			TSSLFilters = new ToolStripStatusLabel();
			TSSLRecordAttentionRequiredCount = new ToolStripStatusLabel();
			ToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutions).BeginInit();
			((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
			SplitContainer.Panel1.SuspendLayout();
			SplitContainer.Panel2.SuspendLayout();
			SplitContainer.SuspendLayout();
			PanelSearch.SuspendLayout();
			StatusStrip.SuspendLayout();
			SuspendLayout();
			// 
			// ToolStrip
			// 
			ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStrip.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh, BDelete, toolStripSeparator6, BDuplicate, toolStripSeparator1, BShowHierarchy, toolStripSeparator2, BFields, BFilter, toolStripSeparator5, toolStripSeparator3, BExcelExport, BPrint, toolStripSeparator4, BCategories, BInstitutionTemplates, BSearch, toolStripSeparator7, BAttentionRequired });
			ToolStrip.Location = new Point(0, 0);
			ToolStrip.Name = "ToolStrip";
			ToolStrip.RenderMode = ToolStripRenderMode.System;
			ToolStrip.Size = new Size(1105, 40);
			ToolStrip.TabIndex = 1;
			ToolStrip.Text = "toolStrip1";
			// 
			// BAdd
			// 
			BAdd.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAdd.ImageScaling = ToolStripItemImageScaling.None;
			BAdd.ImageTransparentColor = Color.Magenta;
			BAdd.Margin = new Padding(1, 2, 1, 2);
			BAdd.Name = "BAdd";
			BAdd.Padding = new Padding(2, 8, 2, 8);
			BAdd.Size = new Size(73, 36);
			BAdd.Text = "&Agregar";
			BAdd.Click += BAdd_Click;
			// 
			// BEdit
			// 
			BEdit.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEdit.ImageScaling = ToolStripItemImageScaling.None;
			BEdit.ImageTransparentColor = Color.Magenta;
			BEdit.Margin = new Padding(1, 2, 1, 2);
			BEdit.Name = "BEdit";
			BEdit.Padding = new Padding(2, 8, 2, 8);
			BEdit.Size = new Size(61, 36);
			BEdit.Text = "&Editar";
			BEdit.Click += BEdit_Click;
			// 
			// BRead
			// 
			BRead.Image = Properties.Resources.Fatcow_Farm_Fresh_Magnifier_16;
			BRead.ImageTransparentColor = Color.Magenta;
			BRead.Margin = new Padding(1, 2, 1, 2);
			BRead.Name = "BRead";
			BRead.Padding = new Padding(2, 8, 2, 8);
			BRead.Size = new Size(82, 36);
			BRead.Text = "&Consultar";
			BRead.Click += BRead_Click;
			// 
			// BRefresh
			// 
			BRefresh.Alignment = ToolStripItemAlignment.Right;
			BRefresh.Image = Properties.Resources.Fatcow_Farm_Fresh_Database_refresh_16;
			BRefresh.ImageScaling = ToolStripItemImageScaling.None;
			BRefresh.ImageTransparentColor = Color.Magenta;
			BRefresh.Margin = new Padding(1, 2, 1, 2);
			BRefresh.Name = "BRefresh";
			BRefresh.Padding = new Padding(2, 8, 2, 8);
			BRefresh.Size = new Size(83, 36);
			BRefresh.Text = "Actualiza&r";
			BRefresh.Click += BRefresh_Click;
			// 
			// BDelete
			// 
			BDelete.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
			BDelete.ImageScaling = ToolStripItemImageScaling.None;
			BDelete.ImageTransparentColor = Color.Magenta;
			BDelete.Name = "BDelete";
			BDelete.Size = new Size(59, 37);
			BDelete.Text = "&Borrar";
			BDelete.Click += BDelete_Click;
			// 
			// toolStripSeparator6
			// 
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new Size(6, 40);
			// 
			// BDuplicate
			// 
			BDuplicate.Image = Properties.Resources.Fatcow_Farm_Fresh_Blogs_16;
			BDuplicate.ImageScaling = ToolStripItemImageScaling.None;
			BDuplicate.ImageTransparentColor = Color.Magenta;
			BDuplicate.Name = "BDuplicate";
			BDuplicate.Size = new Size(71, 37);
			BDuplicate.Text = "&Duplicar";
			BDuplicate.Click += BDuplicate_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 40);
			// 
			// BShowHierarchy
			// 
			BShowHierarchy.Alignment = ToolStripItemAlignment.Right;
			BShowHierarchy.CheckOnClick = true;
			BShowHierarchy.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_16;
			BShowHierarchy.ImageScaling = ToolStripItemImageScaling.None;
			BShowHierarchy.ImageTransparentColor = Color.Magenta;
			BShowHierarchy.Name = "BShowHierarchy";
			BShowHierarchy.Size = new Size(93, 37);
			BShowHierarchy.Text = "Ver Jerarquía";
			BShowHierarchy.Click += BShowHierarchy_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 40);
			// 
			// BFields
			// 
			BFields.Alignment = ToolStripItemAlignment.Right;
			BFields.Image = Properties.Resources.Fatcow_Farm_Fresh_Layouts_header_select_16;
			BFields.ImageScaling = ToolStripItemImageScaling.None;
			BFields.ImageTransparentColor = Color.Magenta;
			BFields.Margin = new Padding(1, 2, 1, 2);
			BFields.Name = "BFields";
			BFields.Padding = new Padding(2, 8, 2, 8);
			BFields.Size = new Size(75, 36);
			BFields.Text = "Cam&pos";
			BFields.Click += BFields_Click;
			// 
			// BFilter
			// 
			BFilter.Alignment = ToolStripItemAlignment.Right;
			BFilter.Image = Properties.Resources.Fatcow_Farm_Fresh_Filter_16;
			BFilter.ImageScaling = ToolStripItemImageScaling.None;
			BFilter.ImageTransparentColor = Color.Magenta;
			BFilter.Name = "BFilter";
			BFilter.Size = new Size(57, 37);
			BFilter.Text = "&Filtrar";
			BFilter.Click += BFilter_Click;
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(6, 40);
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new Size(6, 40);
			// 
			// BExcelExport
			// 
			BExcelExport.Image = Properties.Resources.Fatcow_Farm_Fresh_Export_excel_16;
			BExcelExport.ImageScaling = ToolStripItemImageScaling.None;
			BExcelExport.ImageTransparentColor = Color.Magenta;
			BExcelExport.Name = "BExcelExport";
			BExcelExport.Size = new Size(70, 37);
			BExcelExport.Text = "E&xportar";
			BExcelExport.Click += BExcelExport_Click;
			// 
			// BPrint
			// 
			BPrint.Image = Properties.Resources.Fatcow_Farm_Fresh_Printer_16;
			BPrint.ImageScaling = ToolStripItemImageScaling.None;
			BPrint.ImageTransparentColor = Color.Magenta;
			BPrint.Name = "BPrint";
			BPrint.Size = new Size(73, 37);
			BPrint.Text = "Im&primir";
			BPrint.Click += BPrint_Click;
			// 
			// toolStripSeparator4
			// 
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new Size(6, 40);
			// 
			// BCategories
			// 
			BCategories.Image = Properties.Resources.Fatcow_Farm_Fresh_Module_16;
			BCategories.ImageScaling = ToolStripItemImageScaling.None;
			BCategories.ImageTransparentColor = Color.Magenta;
			BCategories.Name = "BCategories";
			BCategories.Size = new Size(83, 37);
			BCategories.Text = "Categorías";
			BCategories.Click += BCategories_Click;
			// 
			// BInstitutionTemplates
			// 
			BInstitutionTemplates.Image = Properties.Resources.Fatcow_Farm_Fresh_Blueprints_16;
			BInstitutionTemplates.ImageScaling = ToolStripItemImageScaling.None;
			BInstitutionTemplates.ImageTransparentColor = Color.Magenta;
			BInstitutionTemplates.Name = "BInstitutionTemplates";
			BInstitutionTemplates.Size = new Size(74, 37);
			BInstitutionTemplates.Text = "Plantillas";
			// 
			// BSearch
			// 
			BSearch.Alignment = ToolStripItemAlignment.Right;
			BSearch.CheckOnClick = true;
			BSearch.Image = Properties.Resources.Fatcow_Farm_Fresh_Find_16;
			BSearch.ImageScaling = ToolStripItemImageScaling.None;
			BSearch.ImageTransparentColor = Color.Magenta;
			BSearch.Name = "BSearch";
			BSearch.Size = new Size(62, 37);
			BSearch.Text = "Bu&scar";
			BSearch.Click += BSearch_Click;
			// 
			// toolStripSeparator7
			// 
			toolStripSeparator7.Name = "toolStripSeparator7";
			toolStripSeparator7.Size = new Size(6, 40);
			// 
			// BAttentionRequired
			// 
			BAttentionRequired.Image = Properties.Resources.Fatcow_Farm_Fresh_Tag_red_16;
			BAttentionRequired.ImageScaling = ToolStripItemImageScaling.None;
			BAttentionRequired.ImageTransparentColor = Color.Magenta;
			BAttentionRequired.Name = "BAttentionRequired";
			BAttentionRequired.Size = new Size(68, 20);
			BAttentionRequired.Text = "Resal&tar";
			BAttentionRequired.Click += BAttentionRequired_Click;
			// 
			// DataGridInstitutions
			// 
			DataGridInstitutions.AllowUserToAddRows = false;
			DataGridInstitutions.AllowUserToDeleteRows = false;
			DataGridInstitutions.AllowUserToOrderColumns = true;
			DataGridInstitutions.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
			DataGridInstitutions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridInstitutions.BackgroundColor = SystemColors.Control;
			DataGridInstitutions.BorderStyle = BorderStyle.None;
			DataGridInstitutions.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridInstitutions.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridInstitutions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridInstitutions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridInstitutions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridInstitutions.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colAcronym, colSocietySector, colSocietySectorName, colCategoryId, colCategoryName, colDescription, colParentInstitutionId, colAuthorId, colAuthorName, colIdEditor, colEditorName, colAttentionRequired });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridInstitutions.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridInstitutions.Dock = DockStyle.Fill;
			DataGridInstitutions.EnableHeadersVisualStyles = false;
			DataGridInstitutions.Location = new Point(0, 0);
			DataGridInstitutions.MultiSelect = false;
			DataGridInstitutions.Name = "DataGridInstitutions";
			DataGridInstitutions.ReadOnly = true;
			DataGridInstitutions.RowHeadersVisible = false;
			DataGridInstitutions.RowTemplate.Height = 20;
			DataGridInstitutions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridInstitutions.Size = new Size(1105, 399);
			DataGridInstitutions.StandardTab = true;
			DataGridInstitutions.TabIndex = 3;
			DataGridInstitutions.CellFormatting += DataGridInstitutions_CellFormatting;
			// 
			// colId
			// 
			colId.DataPropertyName = "id";
			colId.DividerWidth = 1;
			colId.HeaderText = "Id";
			colId.Name = "colId";
			colId.ReadOnly = true;
			colId.Visible = false;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colName.DataPropertyName = "name";
			colName.DividerWidth = 1;
			colName.HeaderText = "Nombre";
			colName.Name = "colName";
			colName.ReadOnly = true;
			colName.Width = 150;
			// 
			// colAcronym
			// 
			colAcronym.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colAcronym.DataPropertyName = "acronym";
			colAcronym.DividerWidth = 1;
			colAcronym.HeaderText = "Acrónimo";
			colAcronym.Name = "colAcronym";
			colAcronym.ReadOnly = true;
			colAcronym.Visible = false;
			// 
			// colSocietySector
			// 
			colSocietySector.DataPropertyName = "society_sector";
			colSocietySector.DividerWidth = 1;
			colSocietySector.HeaderText = "Id Sector";
			colSocietySector.Name = "colSocietySector";
			colSocietySector.ReadOnly = true;
			colSocietySector.Visible = false;
			// 
			// colSocietySectorName
			// 
			colSocietySectorName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colSocietySectorName.DataPropertyName = "society_sector_name";
			colSocietySectorName.DividerWidth = 1;
			colSocietySectorName.HeaderText = "Sector";
			colSocietySectorName.Name = "colSocietySectorName";
			colSocietySectorName.ReadOnly = true;
			colSocietySectorName.Width = 60;
			// 
			// colCategoryId
			// 
			colCategoryId.DataPropertyName = "category_id";
			colCategoryId.DividerWidth = 1;
			colCategoryId.HeaderText = "Id Categoría";
			colCategoryId.Name = "colCategoryId";
			colCategoryId.ReadOnly = true;
			colCategoryId.Visible = false;
			// 
			// colCategoryName
			// 
			colCategoryName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colCategoryName.DataPropertyName = "category_name";
			colCategoryName.DividerWidth = 1;
			colCategoryName.HeaderText = "Categoría";
			colCategoryName.Name = "colCategoryName";
			colCategoryName.ReadOnly = true;
			// 
			// colDescription
			// 
			colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colDescription.DataPropertyName = "description";
			colDescription.DividerWidth = 1;
			colDescription.HeaderText = "Descripción";
			colDescription.Name = "colDescription";
			colDescription.ReadOnly = true;
			colDescription.Width = 893;
			// 
			// colParentInstitutionId
			// 
			colParentInstitutionId.DataPropertyName = "parent_institution_id";
			colParentInstitutionId.HeaderText = "Institución Padre";
			colParentInstitutionId.Name = "colParentInstitutionId";
			colParentInstitutionId.ReadOnly = true;
			colParentInstitutionId.Visible = false;
			// 
			// colAuthorId
			// 
			colAuthorId.DataPropertyName = "author_id";
			colAuthorId.DividerWidth = 1;
			colAuthorId.HeaderText = "Id Autor";
			colAuthorId.Name = "colAuthorId";
			colAuthorId.ReadOnly = true;
			colAuthorId.Visible = false;
			// 
			// colAuthorName
			// 
			colAuthorName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colAuthorName.DataPropertyName = "author_name";
			colAuthorName.DividerWidth = 1;
			colAuthorName.HeaderText = "Autor";
			colAuthorName.MinimumWidth = 20;
			colAuthorName.Name = "colAuthorName";
			colAuthorName.ReadOnly = true;
			colAuthorName.Visible = false;
			colAuthorName.Width = 120;
			// 
			// colIdEditor
			// 
			colIdEditor.DataPropertyName = "editor_id";
			colIdEditor.DividerWidth = 1;
			colIdEditor.HeaderText = "Id último editor";
			colIdEditor.Name = "colIdEditor";
			colIdEditor.ReadOnly = true;
			colIdEditor.Visible = false;
			// 
			// colEditorName
			// 
			colEditorName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colEditorName.DataPropertyName = "editor_name";
			colEditorName.DividerWidth = 1;
			colEditorName.HeaderText = "Último editor";
			colEditorName.MinimumWidth = 20;
			colEditorName.Name = "colEditorName";
			colEditorName.ReadOnly = true;
			colEditorName.Visible = false;
			colEditorName.Width = 120;
			// 
			// colAttentionRequired
			// 
			colAttentionRequired.DataPropertyName = "attention_required";
			colAttentionRequired.HeaderText = "Atención requerida";
			colAttentionRequired.Name = "colAttentionRequired";
			colAttentionRequired.ReadOnly = true;
			colAttentionRequired.Resizable = DataGridViewTriState.True;
			colAttentionRequired.SortMode = DataGridViewColumnSortMode.Automatic;
			colAttentionRequired.Visible = false;
			// 
			// SplitContainer
			// 
			SplitContainer.Dock = DockStyle.Fill;
			SplitContainer.Location = new Point(0, 79);
			SplitContainer.Name = "SplitContainer";
			// 
			// SplitContainer.Panel1
			// 
			SplitContainer.Panel1.Controls.Add(DataGridInstitutions);
			// 
			// SplitContainer.Panel2
			// 
			SplitContainer.Panel2.Controls.Add(TreeView);
			SplitContainer.Panel2Collapsed = true;
			SplitContainer.Size = new Size(1105, 399);
			SplitContainer.SplitterDistance = 506;
			SplitContainer.TabIndex = 4;
			// 
			// TreeView
			// 
			TreeView.BackColor = SystemColors.Control;
			TreeView.BorderStyle = BorderStyle.None;
			TreeView.Dock = DockStyle.Fill;
			TreeView.Location = new Point(0, 0);
			TreeView.Name = "TreeView";
			TreeView.Size = new Size(96, 100);
			TreeView.TabIndex = 0;
			// 
			// TextBoxSearch
			// 
			TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxSearch.Location = new Point(8, 8);
			TextBoxSearch.Name = "TextBoxSearch";
			TextBoxSearch.PlaceholderText = "Ingrese el texto a buscar...";
			TextBoxSearch.Size = new Size(1790, 23);
			TextBoxSearch.TabIndex = 1;
			TextBoxSearch.TextChanged += TextBoxSearch_TextChanged;
			// 
			// PanelSearch
			// 
			PanelSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			PanelSearch.Controls.Add(TextBoxSearch);
			PanelSearch.Dock = DockStyle.Top;
			PanelSearch.Location = new Point(0, 40);
			PanelSearch.Name = "PanelSearch";
			PanelSearch.Size = new Size(1105, 39);
			PanelSearch.TabIndex = 7;
			PanelSearch.Visible = false;
			// 
			// StatusStrip
			// 
			StatusStrip.Items.AddRange(new ToolStripItem[] { TSSLRecordAttentionRequiredCount, TSSLRecordCount, TSSLFilters });
			StatusStrip.Location = new Point(0, 478);
			StatusStrip.Name = "StatusStrip";
			StatusStrip.Size = new Size(1105, 22);
			StatusStrip.TabIndex = 4;
			StatusStrip.Text = "statusStrip1";
			// 
			// TSSLRecordCount
			// 
			TSSLRecordCount.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TSSLRecordCount.Margin = new Padding(0, 3, 5, 2);
			TSSLRecordCount.Name = "TSSLRecordCount";
			TSSLRecordCount.Size = new Size(78, 17);
			TSSLRecordCount.Text = "Registros: 274";
			// 
			// TSSLFilters
			// 
			TSSLFilters.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TSSLFilters.Name = "TSSLFilters";
			TSSLFilters.Size = new Size(132, 17);
			TSSLFilters.Text = "Filtros: Sexo = Masculino";
			// 
			// TSSLRecordAttentionRequiredCount
			// 
			TSSLRecordAttentionRequiredCount.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			TSSLRecordAttentionRequiredCount.ForeColor = Color.Red;
			TSSLRecordAttentionRequiredCount.Margin = new Padding(0, 3, 5, 2);
			TSSLRecordAttentionRequiredCount.Name = "TSSLRecordAttentionRequiredCount";
			TSSLRecordAttentionRequiredCount.Size = new Size(115, 17);
			TSSLRecordAttentionRequiredCount.Text = "Atención requerida: 0";
			// 
			// FInstitutionList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1105, 500);
			Controls.Add(SplitContainer);
			Controls.Add(PanelSearch);
			Controls.Add(ToolStrip);
			Controls.Add(StatusStrip);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FInstitutionList";
			Text = "Instituciones";
			FormClosing += FInstitutionList_FormClosing;
			FormClosed += FInstitutionList_FormClosed;
			Load += FInstitutionList_Load;
			Leave += FInstitutionList_Leave;
			ToolStrip.ResumeLayout(false);
			ToolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutions).EndInit();
			SplitContainer.Panel1.ResumeLayout(false);
			SplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
			SplitContainer.ResumeLayout(false);
			PanelSearch.ResumeLayout(false);
			PanelSearch.PerformLayout();
			StatusStrip.ResumeLayout(false);
			StatusStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip ToolStrip;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private DataGridView DataGridInstitutions;
		private SplitContainer SplitContainer;
		private TreeView TreeView;
		private ToolStripButton BDelete;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BShowHierarchy;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton BSearch;
		private TextBox TextBoxSearch;
		private Panel PanelSearch;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripButton BCategories;
		private ToolStripButton BExcelExport;
		private ToolStripSeparator toolStripSeparator4;
		private SaveFileDialog SaveFileDialog;
		private StatusStrip StatusStrip;
		private ToolStripStatusLabel TSSLRecordCount;
		private ToolStripButton BFilter;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripButton BFields;
		private ToolStripStatusLabel TSSLFilters;
		private ToolStripButton BDuplicate;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripSeparator toolStripSeparator7;
		private ToolStripButton BAttentionRequired;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colAcronym;
		private DataGridViewTextBoxColumn colSocietySector;
		private DataGridViewTextBoxColumn colSocietySectorName;
		private DataGridViewTextBoxColumn colCategoryId;
		private DataGridViewTextBoxColumn colCategoryName;
		private DataGridViewTextBoxColumn colDescription;
		private DataGridViewTextBoxColumn colParentInstitutionId;
		private DataGridViewTextBoxColumn colAuthorId;
		private DataGridViewTextBoxColumn colAuthorName;
		private DataGridViewTextBoxColumn colIdEditor;
		private DataGridViewTextBoxColumn colEditorName;
		private DataGridViewCheckBoxColumn colAttentionRequired;
		private ToolStripButton BPrint;
		private ToolStripButton BInstitutionTemplates;
		private ToolStripStatusLabel TSSLRecordAttentionRequiredCount;
	}
}