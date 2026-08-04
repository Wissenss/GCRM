namespace GCRM
{
	partial class FCitizenList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCitizenList));
            colId = new DataGridViewTextBoxColumn();
            colTitleType = new DataGridViewTextBoxColumn();
            colInstitutionId = new DataGridViewTextBoxColumn();
            colInsitutionCategoryId = new DataGridViewTextBoxColumn();
            colInstitutionSector = new DataGridViewTextBoxColumn();
            colAssistantId = new DataGridViewTextBoxColumn();
            colAddressCountry = new DataGridViewTextBoxColumn();
            colSexType = new DataGridViewTextBoxColumn();
            colPoliticalPartyId = new DataGridViewTextBoxColumn();
            colAddressId = new DataGridViewTextBoxColumn();
            colTitleName = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPaternalName = new DataGridViewTextBoxColumn();
            colMaternalName = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colAssistantName = new DataGridViewTextBoxColumn();
            colInstitutionName = new DataGridViewTextBoxColumn();
            colInstitutionCategoryName = new DataGridViewTextBoxColumn();
            colInstitutionSectorName = new DataGridViewTextBoxColumn();
            colPhoneAndExtension = new DataGridViewTextBoxColumn();
            colCellphone = new DataGridViewTextBoxColumn();
            colCURP = new DataGridViewTextBoxColumn();
            colObservations = new DataGridViewTextBoxColumn();
            colSexName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colPhoneExtension = new DataGridViewTextBoxColumn();
            colPoliticalPartyName = new DataGridViewTextBoxColumn();
            colBirthday = new DataGridViewTextBoxColumn();
            colAddressStreet = new DataGridViewTextBoxColumn();
            colAddressNumber = new DataGridViewTextBoxColumn();
            colAddressInteriorNumber = new DataGridViewTextBoxColumn();
            colAddressPostalCode = new DataGridViewTextBoxColumn();
            colAddressState = new DataGridViewTextBoxColumn();
            colAddressCity = new DataGridViewTextBoxColumn();
            colAddressCountryName = new DataGridViewTextBoxColumn();
            ToolStrip = new ToolStrip();
            BAdd = new ToolStripButton();
            BEdit = new ToolStripButton();
            BRead = new ToolStripButton();
            BRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BFields = new ToolStripButton();
            BFilter = new ToolStripButton();
            BDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            BExcelImport = new ToolStripButton();
            FExcelExport = new ToolStripButton();
            BPrint = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            BSearch = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            BCategories = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            BSelect = new ToolStripButton();
            BAttentionRequired = new ToolStripButton();
            PanelSearch = new Panel();
            TextBoxSearch = new TextBox();
            SaveFileDialog = new SaveFileDialog();
            DataGridCitizens = new DataGridView();
            statusStrip1 = new StatusStrip();
            TSSLRecordAttentionRequiredCount = new ToolStripStatusLabel();
            TSSLRecordCount = new ToolStripStatusLabel();
            TSSLFilters = new ToolStripStatusLabel();
            TSSLDebug = new ToolStripStatusLabel();
            TSSLAttentionReason = new ToolStripStatusLabel();
            ToolStrip.SuspendLayout();
            PanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridCitizens).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // colId
            // 
            colId.DataPropertyName = "id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colTitleType
            // 
            colTitleType.DataPropertyName = "title";
            colTitleType.HeaderText = "Id Título";
            colTitleType.Name = "colTitleType";
            colTitleType.ReadOnly = true;
            colTitleType.Visible = false;
            // 
            // colInstitutionId
            // 
            colInstitutionId.DataPropertyName = "institution_id";
            colInstitutionId.HeaderText = "Id Institucion";
            colInstitutionId.Name = "colInstitutionId";
            colInstitutionId.ReadOnly = true;
            colInstitutionId.Visible = false;
            // 
            // colInsitutionCategoryId
            // 
            colInsitutionCategoryId.DataPropertyName = "institution_category_id";
            colInsitutionCategoryId.HeaderText = "Id Categoría Institución";
            colInsitutionCategoryId.Name = "colInsitutionCategoryId";
            colInsitutionCategoryId.ReadOnly = true;
            colInsitutionCategoryId.Visible = false;
            // 
            // colInstitutionSector
            // 
            colInstitutionSector.DataPropertyName = "institution_sector";
            colInstitutionSector.HeaderText = "Id Sector Institución";
            colInstitutionSector.Name = "colInstitutionSector";
            colInstitutionSector.ReadOnly = true;
            colInstitutionSector.Visible = false;
            // 
            // colAssistantId
            // 
            colAssistantId.DataPropertyName = "assistant_id";
            colAssistantId.HeaderText = "Id Asistente";
            colAssistantId.Name = "colAssistantId";
            colAssistantId.ReadOnly = true;
            colAssistantId.Visible = false;
            // 
            // colAddressCountry
            // 
            colAddressCountry.DataPropertyName = "address_country";
            colAddressCountry.HeaderText = "Id País";
            colAddressCountry.Name = "colAddressCountry";
            colAddressCountry.ReadOnly = true;
            colAddressCountry.Visible = false;
            // 
            // colSexType
            // 
            colSexType.DataPropertyName = "sex";
            colSexType.HeaderText = "Id Sexo";
            colSexType.Name = "colSexType";
            colSexType.ReadOnly = true;
            colSexType.Visible = false;
            // 
            // colPoliticalPartyId
            // 
            colPoliticalPartyId.DataPropertyName = "political_party";
            colPoliticalPartyId.HeaderText = "Id Partido Político";
            colPoliticalPartyId.Name = "colPoliticalPartyId";
            colPoliticalPartyId.ReadOnly = true;
            colPoliticalPartyId.Visible = false;
            // 
            // colAddressId
            // 
            colAddressId.DataPropertyName = "address_id";
            colAddressId.HeaderText = "Id dirección";
            colAddressId.Name = "colAddressId";
            colAddressId.ReadOnly = true;
            colAddressId.Visible = false;
            // 
            // colTitleName
            // 
            colTitleName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTitleName.DataPropertyName = "title_name";
            colTitleName.Frozen = true;
            colTitleName.HeaderText = "Título";
            colTitleName.MinimumWidth = 50;
            colTitleName.Name = "colTitleName";
            colTitleName.ReadOnly = true;
            colTitleName.Width = 50;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "name";
            colName.HeaderText = "Nombre";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Visible = false;
            // 
            // colPaternalName
            // 
            colPaternalName.DataPropertyName = "paternal_name";
            colPaternalName.HeaderText = "Apellido Paterno";
            colPaternalName.Name = "colPaternalName";
            colPaternalName.ReadOnly = true;
            colPaternalName.Visible = false;
            // 
            // colMaternalName
            // 
            colMaternalName.DataPropertyName = "maternal_name";
            colMaternalName.HeaderText = "Apellido Materno";
            colMaternalName.Name = "colMaternalName";
            colMaternalName.ReadOnly = true;
            colMaternalName.Visible = false;
            // 
            // colFullName
            // 
            colFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colFullName.DataPropertyName = "name_full";
            colFullName.Frozen = true;
            colFullName.HeaderText = "Nombre";
            colFullName.MinimumWidth = 140;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            colFullName.Width = 170;
            // 
            // colAssistantName
            // 
            colAssistantName.DataPropertyName = "assistant_name";
            colAssistantName.HeaderText = "Asistente";
            colAssistantName.MinimumWidth = 140;
            colAssistantName.Name = "colAssistantName";
            colAssistantName.ReadOnly = true;
            colAssistantName.Width = 140;
            // 
            // colInstitutionName
            // 
            colInstitutionName.DataPropertyName = "institution_name";
            colInstitutionName.HeaderText = "Institución";
            colInstitutionName.Name = "colInstitutionName";
            colInstitutionName.ReadOnly = true;
            // 
            // colInstitutionCategoryName
            // 
            colInstitutionCategoryName.DataPropertyName = "institution_category_name";
            colInstitutionCategoryName.HeaderText = "Categoría";
            colInstitutionCategoryName.Name = "colInstitutionCategoryName";
            colInstitutionCategoryName.ReadOnly = true;
            // 
            // colInstitutionSectorName
            // 
            colInstitutionSectorName.DataPropertyName = "institution_sector_name";
            colInstitutionSectorName.HeaderText = "Sector";
            colInstitutionSectorName.Name = "colInstitutionSectorName";
            colInstitutionSectorName.ReadOnly = true;
            colInstitutionSectorName.Width = 60;
            // 
            // colPhoneAndExtension
            // 
            colPhoneAndExtension.DataPropertyName = "phone_full";
            colPhoneAndExtension.HeaderText = "Teléfono";
            colPhoneAndExtension.Name = "colPhoneAndExtension";
            colPhoneAndExtension.ReadOnly = true;
            colPhoneAndExtension.Width = 120;
            // 
            // colCellphone
            // 
            colCellphone.DataPropertyName = "cellphone";
            colCellphone.HeaderText = "Celular";
            colCellphone.Name = "colCellphone";
            colCellphone.ReadOnly = true;
            // 
            // colCURP
            // 
            colCURP.DataPropertyName = "curp";
            colCURP.HeaderText = "CURP";
            colCURP.Name = "colCURP";
            colCURP.ReadOnly = true;
            colCURP.Visible = false;
            colCURP.Width = 150;
            // 
            // colObservations
            // 
            colObservations.DataPropertyName = "observations";
            colObservations.HeaderText = "Observaciones";
            colObservations.Name = "colObservations";
            colObservations.ReadOnly = true;
            colObservations.Visible = false;
            // 
            // colSexName
            // 
            colSexName.DataPropertyName = "sex_name";
            colSexName.HeaderText = "Sexo";
            colSexName.Name = "colSexName";
            colSexName.ReadOnly = true;
            colSexName.Visible = false;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "phone";
            colPhone.HeaderText = "Teléfono";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            colPhone.Visible = false;
            // 
            // colPhoneExtension
            // 
            colPhoneExtension.DataPropertyName = "phone_extension";
            colPhoneExtension.HeaderText = "Extensión";
            colPhoneExtension.Name = "colPhoneExtension";
            colPhoneExtension.ReadOnly = true;
            colPhoneExtension.Visible = false;
            // 
            // colPoliticalPartyName
            // 
            colPoliticalPartyName.DataPropertyName = "political_party_name";
            colPoliticalPartyName.HeaderText = "Partido";
            colPoliticalPartyName.Name = "colPoliticalPartyName";
            colPoliticalPartyName.ReadOnly = true;
            colPoliticalPartyName.Width = 60;
            // 
            // colBirthday
            // 
            colBirthday.DataPropertyName = "birthday";
            colBirthday.HeaderText = "Nacimiento";
            colBirthday.Name = "colBirthday";
            colBirthday.ReadOnly = true;
            colBirthday.Visible = false;
            colBirthday.Width = 80;
            // 
            // colAddressStreet
            // 
            colAddressStreet.DataPropertyName = "address_street";
            colAddressStreet.HeaderText = "Calle";
            colAddressStreet.Name = "colAddressStreet";
            colAddressStreet.ReadOnly = true;
            colAddressStreet.Visible = false;
            // 
            // colAddressNumber
            // 
            colAddressNumber.DataPropertyName = "address_number";
            colAddressNumber.HeaderText = "Número";
            colAddressNumber.Name = "colAddressNumber";
            colAddressNumber.ReadOnly = true;
            colAddressNumber.Visible = false;
            // 
            // colAddressInteriorNumber
            // 
            colAddressInteriorNumber.DataPropertyName = "address_interior_number";
            colAddressInteriorNumber.HeaderText = "Número interior";
            colAddressInteriorNumber.Name = "colAddressInteriorNumber";
            colAddressInteriorNumber.ReadOnly = true;
            colAddressInteriorNumber.Visible = false;
            // 
            // colAddressPostalCode
            // 
            colAddressPostalCode.DataPropertyName = "address_postal_code";
            colAddressPostalCode.HeaderText = "Código Postal";
            colAddressPostalCode.Name = "colAddressPostalCode";
            colAddressPostalCode.ReadOnly = true;
            colAddressPostalCode.Visible = false;
            // 
            // colAddressState
            // 
            colAddressState.DataPropertyName = "address_state";
            colAddressState.HeaderText = "Estado";
            colAddressState.Name = "colAddressState";
            colAddressState.ReadOnly = true;
            colAddressState.Visible = false;
            // 
            // colAddressCity
            // 
            colAddressCity.DataPropertyName = "address_city";
            colAddressCity.HeaderText = "Ciudad";
            colAddressCity.Name = "colAddressCity";
            colAddressCity.ReadOnly = true;
            colAddressCity.Visible = false;
            // 
            // colAddressCountryName
            // 
            colAddressCountryName.DataPropertyName = "address_country_name";
            colAddressCountryName.HeaderText = "País";
            colAddressCountryName.Name = "colAddressCountryName";
            colAddressCountryName.ReadOnly = true;
            colAddressCountryName.Visible = false;
            // 
            // ToolStrip
            // 
            ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            ToolStrip.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh, toolStripSeparator1, BFields, BFilter, BDelete, toolStripSeparator2, BExcelImport, FExcelExport, BPrint, toolStripSeparator4, BSearch, toolStripSeparator5, BCategories, toolStripSeparator3, BSelect, BAttentionRequired });
            ToolStrip.Location = new Point(2, 2);
            ToolStrip.Name = "ToolStrip";
            ToolStrip.RenderMode = ToolStripRenderMode.System;
            ToolStrip.Size = new Size(1179, 40);
            ToolStrip.TabIndex = 4;
            ToolStrip.Text = "toolStrip1";
            // 
            // BAdd
            // 
            BAdd.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            BRead.Image = Properties.Resources.Fatcow_Farm_Fresh_Information_16;
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 40);
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
            BFilter.ImageTransparentColor = Color.Magenta;
            BFilter.Margin = new Padding(1, 2, 1, 2);
            BFilter.Name = "BFilter";
            BFilter.Padding = new Padding(2, 8, 2, 8);
            BFilter.Size = new Size(61, 36);
            BFilter.Text = "&Filtrar";
            BFilter.Click += BFilter_Click;
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
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 40);
            // 
            // BExcelImport
            // 
            BExcelImport.Image = Properties.Resources.Fatcow_Farm_Fresh_Excel_imports_16;
            BExcelImport.ImageScaling = ToolStripItemImageScaling.None;
            BExcelImport.ImageTransparentColor = Color.Magenta;
            BExcelImport.Name = "BExcelImport";
            BExcelImport.Size = new Size(73, 37);
            BExcelImport.Text = "&Importar";
            BExcelImport.Click += BExcelImport_Click;
            // 
            // FExcelExport
            // 
            FExcelExport.Image = Properties.Resources.Fatcow_Farm_Fresh_Excel_exports_16;
            FExcelExport.ImageScaling = ToolStripItemImageScaling.None;
            FExcelExport.ImageTransparentColor = Color.Magenta;
            FExcelExport.Margin = new Padding(1, 2, 1, 2);
            FExcelExport.Name = "FExcelExport";
            FExcelExport.Padding = new Padding(2, 8, 2, 8);
            FExcelExport.Size = new Size(74, 36);
            FExcelExport.Text = "E&xportar";
            FExcelExport.Click += FExcelExport_Click;
            // 
            // BPrint
            // 
            BPrint.Image = Properties.Resources.Fatcow_Farm_Fresh_Printer_16;
            BPrint.ImageTransparentColor = Color.Magenta;
            BPrint.Margin = new Padding(1, 2, 1, 2);
            BPrint.Name = "BPrint";
            BPrint.Padding = new Padding(2, 8, 2, 8);
            BPrint.Size = new Size(77, 36);
            BPrint.Text = "&Imprimir";
            BPrint.Visible = false;
            BPrint.Click += BPrint_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 40);
            // 
            // BSearch
            // 
            BSearch.Alignment = ToolStripItemAlignment.Right;
            BSearch.CheckOnClick = true;
            BSearch.Image = Properties.Resources.Fatcow_Farm_Fresh_Find_16;
            BSearch.ImageTransparentColor = Color.Magenta;
            BSearch.Margin = new Padding(1, 2, 1, 2);
            BSearch.Name = "BSearch";
            BSearch.Padding = new Padding(2, 8, 2, 8);
            BSearch.Size = new Size(66, 36);
            BSearch.Text = "&Buscar";
            BSearch.Click += BSearch_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 40);
            // 
            // BCategories
            // 
            BCategories.Image = Properties.Resources.Fatcow_Farm_Fresh_Module_16;
            BCategories.ImageScaling = ToolStripItemImageScaling.None;
            BCategories.ImageTransparentColor = Color.Magenta;
            BCategories.Margin = new Padding(1, 2, 1, 2);
            BCategories.Name = "BCategories";
            BCategories.Padding = new Padding(2, 8, 2, 8);
            BCategories.Size = new Size(87, 36);
            BCategories.Text = "Categorías";
            BCategories.Click += BCategories_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 40);
            // 
            // BSelect
            // 
            BSelect.Image = Properties.Resources.Fatcow_Farm_Fresh_Check_box_16;
            BSelect.ImageScaling = ToolStripItemImageScaling.None;
            BSelect.ImageTransparentColor = Color.Magenta;
            BSelect.Name = "BSelect";
            BSelect.Size = new Size(87, 37);
            BSelect.Text = "&Seleccionar";
            BSelect.Visible = false;
            BSelect.Click += BSelect_Click;
            // 
            // BAttentionRequired
            // 
            BAttentionRequired.Image = Properties.Resources.Fatcow_Farm_Fresh_Bookmark_red_16;
            BAttentionRequired.ImageScaling = ToolStripItemImageScaling.None;
            BAttentionRequired.ImageTransparentColor = Color.Magenta;
            BAttentionRequired.Margin = new Padding(1, 2, 1, 2);
            BAttentionRequired.Name = "BAttentionRequired";
            BAttentionRequired.Padding = new Padding(2, 8, 2, 8);
            BAttentionRequired.Size = new Size(72, 36);
            BAttentionRequired.Text = "Necesita &atención";
            BAttentionRequired.Click += BAttentionRequired_Click;
            // 
            // PanelSearch
            // 
            PanelSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelSearch.Controls.Add(TextBoxSearch);
            PanelSearch.Dock = DockStyle.Top;
            PanelSearch.Location = new Point(2, 42);
            PanelSearch.Name = "PanelSearch";
            PanelSearch.Size = new Size(1179, 39);
            PanelSearch.TabIndex = 6;
            PanelSearch.Visible = false;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxSearch.Location = new Point(8, 8);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.PlaceholderText = "Ingrese el texto a buscar...";
            TextBoxSearch.Size = new Size(1163, 23);
            TextBoxSearch.TabIndex = 1;
            TextBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            // 
            // DataGridCitizens
            // 
            DataGridCitizens.AllowUserToAddRows = false;
            DataGridCitizens.AllowUserToDeleteRows = false;
            DataGridCitizens.AllowUserToOrderColumns = true;
            DataGridCitizens.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            DataGridCitizens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridCitizens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridCitizens.BackgroundColor = SystemColors.Control;
            DataGridCitizens.BorderStyle = BorderStyle.None;
            DataGridCitizens.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridCitizens.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridCitizens.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridCitizens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridCitizens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGridCitizens.DefaultCellStyle = dataGridViewCellStyle3;
            DataGridCitizens.Dock = DockStyle.Fill;
            DataGridCitizens.EnableHeadersVisualStyles = false;
            DataGridCitizens.ImeMode = ImeMode.NoControl;
            DataGridCitizens.Location = new Point(2, 81);
            DataGridCitizens.MultiSelect = false;
            DataGridCitizens.Name = "DataGridCitizens";
            DataGridCitizens.ReadOnly = true;
            DataGridCitizens.RowHeadersVisible = false;
            DataGridCitizens.RowTemplate.Height = 20;
            DataGridCitizens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridCitizens.ShowCellToolTips = false;
            DataGridCitizens.Size = new Size(1179, 520);
            DataGridCitizens.StandardTab = true;
            DataGridCitizens.TabIndex = 7;
            DataGridCitizens.CellDoubleClick += DataGridCitizens_CellDoubleClick;
            DataGridCitizens.CellFormatting += DataGridCitizens_CellFormatting;
            DataGridCitizens.KeyDown += DataGridCitizens_KeyDown;
            DataGridCitizens.SelectionChanged += DataGridCitizens_SelectionChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { TSSLRecordAttentionRequiredCount, TSSLRecordCount, TSSLFilters, TSSLAttentionReason, TSSLDebug });
            statusStrip1.Location = new Point(2, 601);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1179, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
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
            // TSSLRecordCount
            // 
            TSSLRecordCount.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TSSLRecordCount.Margin = new Padding(0, 3, 5, 2);
            TSSLRecordCount.Name = "TSSLRecordCount";
            TSSLRecordCount.Size = new Size(78, 17);
            TSSLRecordCount.Text = "Registros: 524";
            // 
            // TSSLFilters
            // 
            TSSLFilters.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TSSLFilters.Margin = new Padding(0, 3, 5, 2);
            TSSLFilters.Name = "TSSLFilters";
            TSSLFilters.Size = new Size(132, 17);
            TSSLFilters.Text = "Filtros: Sexo = Masculino";
            TSSLFilters.TextAlign = ContentAlignment.MiddleLeft;
            //
            // TSSLAttentionReason
            //
            TSSLAttentionReason.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TSSLAttentionReason.ForeColor = Color.Red;
            TSSLAttentionReason.Margin = new Padding(0, 3, 5, 2);
            TSSLAttentionReason.Name = "TSSLAttentionReason";
            TSSLAttentionReason.Size = new Size(0, 17);
            TSSLAttentionReason.TextAlign = ContentAlignment.MiddleLeft;
            //
            // TSSLDebug
            // 
            TSSLDebug.Name = "TSSLDebug";
            TSSLDebug.Size = new Size(0, 17);
            // 
            // FCitizenList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 625);
            Controls.Add(DataGridCitizens);
            Controls.Add(statusStrip1);
            Controls.Add(PanelSearch);
            Controls.Add(ToolStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FCitizenList";
            Padding = new Padding(2);
            Text = "Ciudadanos";
            FormClosing += FCitizenList_FormClosing;
            Load += FCitizenList_Load;
            KeyDown += FCitizenList_KeyDown;
            ToolStrip.ResumeLayout(false);
            ToolStrip.PerformLayout();
            PanelSearch.ResumeLayout(false);
            PanelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridCitizens).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip ToolStrip;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BFilter;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton FExcelExport;
		private ToolStripButton BPrint;
		private Panel PanelSearch;
		private TextBox TextBoxSearch;
		private ToolStripButton BSearch;
		private ToolStripSeparator toolStripSeparator4;
		private SaveFileDialog SaveFileDialog;
		private ToolStripButton BFields;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colTitleType;
		private DataGridViewTextBoxColumn colInstitutionId;
		private DataGridViewTextBoxColumn colInsitutionCategoryId;
		private DataGridViewTextBoxColumn colInstitutionSector;
		private DataGridViewTextBoxColumn colAssistantId;
		private DataGridViewTextBoxColumn colAddressCountry;
		private DataGridViewTextBoxColumn colSexType;
		private DataGridViewTextBoxColumn colPoliticalPartyId;
		private DataGridViewTextBoxColumn colAddressId;
		private DataGridViewTextBoxColumn colTitleName;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colPaternalName;
		private DataGridViewTextBoxColumn colMaternalName;
		private DataGridViewTextBoxColumn colFullName;
		private DataGridViewTextBoxColumn colAssistantName;
		private DataGridViewTextBoxColumn colInstitutionName;
		private DataGridViewTextBoxColumn colInstitutionCategoryName;
		private DataGridViewTextBoxColumn colInstitutionSectorName;
		private DataGridViewTextBoxColumn colPhoneAndExtension;
		private DataGridViewTextBoxColumn colCellphone;
		private DataGridViewTextBoxColumn colCURP;
		private DataGridViewTextBoxColumn colObservations;
		private DataGridViewTextBoxColumn colSexName;
		private DataGridViewTextBoxColumn colPhone;
		private DataGridViewTextBoxColumn colPhoneExtension;
		private DataGridViewTextBoxColumn colPoliticalPartyName;
		private DataGridViewTextBoxColumn colBirthday;
		private DataGridViewTextBoxColumn colAddressStreet;
		private DataGridViewTextBoxColumn colAddressNumber;
		private DataGridViewTextBoxColumn colAddressInteriorNumber;
		private DataGridViewTextBoxColumn colAddressPostalCode;
		private DataGridViewTextBoxColumn colAddressState;
		private DataGridViewTextBoxColumn colAddressCity;
		private DataGridViewTextBoxColumn colAddressCountryName;
		private DataGridView DataGridCitizens;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel TSSLRecordCount;
		private ToolStripStatusLabel TSSLFilters;
		private ToolStripButton BDelete;
		private ToolStripButton BSelect;
		private ToolStripButton BCategories;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripButton BAttentionRequired;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripStatusLabel TSSLRecordAttentionRequiredCount;
		private ToolStripButton BExcelImport;
		private ToolStripStatusLabel TSSLDebug;
		private ToolStripStatusLabel TSSLAttentionReason;
	}
}