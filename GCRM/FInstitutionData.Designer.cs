namespace GCRM
{
	partial class FInstitutionData
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
            BCancel = new Button();
            BAccept = new Button();
            TabGeneral = new TabPage();
            Template = new ComboBox();
            LTemplate = new Label();
            LAcronym = new Label();
            TextBoxAcronym = new TextBox();
            ComboBoxCategory = new ComboBox();
            ComboBoxParentInstitution = new ComboBox();
            LParentInstitution = new Label();
            LInstitutionCategory = new Label();
            LDescription = new Label();
            TextBoxDescription = new TextBox();
            ComboBoxSocietySector = new ComboBox();
            LSocietySector = new Label();
            LName = new Label();
            TextBoxName = new TextBox();
            TabControlInstitution = new TabControl();
            TabPositions = new TabPage();
            DataGridInstitutionRoles = new DataGridView();
            toolStrip1 = new ToolStrip();
            BAddRole = new ToolStripButton();
            BEditRole = new ToolStripButton();
            BDeleteRole = new ToolStripButton();
            BSearchCitizensWithRole = new ToolStripButton();
            TabAddress = new TabPage();
            TextBoxDistrict = new TextBox();
            LDistrict = new Label();
            LCountryFullName = new Label();
            LCountry = new Label();
            ComboBoxCountry = new ComboBox();
            TextBoxCity = new TextBox();
            LCity = new Label();
            TextBoxState = new TextBox();
            LState = new Label();
            TextBoxPostalCode = new TextBox();
            LPostalCode = new Label();
            TextBoxInteriorNumber = new TextBox();
            LInteriorNumber = new Label();
            TextBoxNumber = new TextBox();
            LNumber = new Label();
            TextBoxStreet = new TextBox();
            LStreet = new Label();
            TabGeneral.SuspendLayout();
            TabControlInstitution.SuspendLayout();
            TabPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridInstitutionRoles).BeginInit();
            toolStrip1.SuspendLayout();
            TabAddress.SuspendLayout();
            SuspendLayout();
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(387, 356);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 2;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(309, 356);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 1;
            BAccept.Text = "&Aceptar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // TabGeneral
            // 
            TabGeneral.BackColor = Color.Transparent;
            TabGeneral.Controls.Add(Template);
            TabGeneral.Controls.Add(LTemplate);
            TabGeneral.Controls.Add(LAcronym);
            TabGeneral.Controls.Add(TextBoxAcronym);
            TabGeneral.Controls.Add(ComboBoxCategory);
            TabGeneral.Controls.Add(ComboBoxParentInstitution);
            TabGeneral.Controls.Add(LParentInstitution);
            TabGeneral.Controls.Add(LInstitutionCategory);
            TabGeneral.Controls.Add(LDescription);
            TabGeneral.Controls.Add(TextBoxDescription);
            TabGeneral.Controls.Add(ComboBoxSocietySector);
            TabGeneral.Controls.Add(LSocietySector);
            TabGeneral.Controls.Add(LName);
            TabGeneral.Controls.Add(TextBoxName);
            TabGeneral.Location = new Point(4, 24);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.Padding = new Padding(3);
            TabGeneral.Size = new Size(463, 323);
            TabGeneral.TabIndex = 0;
            TabGeneral.Text = "General";
            // 
            // Template
            // 
            Template.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Template.DropDownStyle = ComboBoxStyle.DropDownList;
            Template.FlatStyle = FlatStyle.System;
            Template.FormattingEnabled = true;
            Template.Location = new Point(82, 101);
            Template.Name = "Template";
            Template.Size = new Size(375, 23);
            Template.TabIndex = 17;
            Template.SelectedIndexChanged += Template_SelectedIndexChanged;
            // 
            // LTemplate
            // 
            LTemplate.AutoSize = true;
            LTemplate.Location = new Point(7, 104);
            LTemplate.Name = "LTemplate";
            LTemplate.Size = new Size(49, 15);
            LTemplate.TabIndex = 18;
            LTemplate.Text = "Plantilla";
            // 
            // LAcronym
            // 
            LAcronym.AutoSize = true;
            LAcronym.Location = new Point(7, 162);
            LAcronym.Name = "LAcronym";
            LAcronym.Size = new Size(60, 15);
            LAcronym.TabIndex = 16;
            LAcronym.Text = "Acrónimo";
            // 
            // TextBoxAcronym
            // 
            TextBoxAcronym.Location = new Point(82, 159);
            TextBoxAcronym.Name = "TextBoxAcronym";
            TextBoxAcronym.Size = new Size(217, 23);
            TextBoxAcronym.TabIndex = 4;
            // 
            // ComboBoxCategory
            // 
            ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxCategory.FormattingEnabled = true;
            ComboBoxCategory.Location = new Point(82, 43);
            ComboBoxCategory.Name = "ComboBoxCategory";
            ComboBoxCategory.Size = new Size(217, 23);
            ComboBoxCategory.TabIndex = 1;
            // 
            // ComboBoxParentInstitution
            // 
            ComboBoxParentInstitution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxParentInstitution.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxParentInstitution.FlatStyle = FlatStyle.System;
            ComboBoxParentInstitution.FormattingEnabled = true;
            ComboBoxParentInstitution.Location = new Point(82, 72);
            ComboBoxParentInstitution.Name = "ComboBoxParentInstitution";
            ComboBoxParentInstitution.Size = new Size(375, 23);
            ComboBoxParentInstitution.TabIndex = 2;
            // 
            // LParentInstitution
            // 
            LParentInstitution.AutoSize = true;
            LParentInstitution.Location = new Point(7, 75);
            LParentInstitution.Name = "LParentInstitution";
            LParentInstitution.Size = new Size(62, 15);
            LParentInstitution.TabIndex = 13;
            LParentInstitution.Text = "Inst. padre";
            // 
            // LInstitutionCategory
            // 
            LInstitutionCategory.AutoSize = true;
            LInstitutionCategory.Location = new Point(7, 46);
            LInstitutionCategory.Name = "LInstitutionCategory";
            LInstitutionCategory.Size = new Size(58, 15);
            LInstitutionCategory.TabIndex = 11;
            LInstitutionCategory.Text = "Categoría";
            // 
            // LDescription
            // 
            LDescription.AutoSize = true;
            LDescription.Location = new Point(7, 190);
            LDescription.Name = "LDescription";
            LDescription.Size = new Size(69, 15);
            LDescription.TabIndex = 10;
            LDescription.Text = "Descripción";
            // 
            // TextBoxDescription
            // 
            TextBoxDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxDescription.Location = new Point(82, 188);
            TextBoxDescription.Multiline = true;
            TextBoxDescription.Name = "TextBoxDescription";
            TextBoxDescription.Size = new Size(375, 129);
            TextBoxDescription.TabIndex = 5;
            // 
            // ComboBoxSocietySector
            // 
            ComboBoxSocietySector.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSocietySector.FlatStyle = FlatStyle.System;
            ComboBoxSocietySector.FormattingEnabled = true;
            ComboBoxSocietySector.Location = new Point(82, 15);
            ComboBoxSocietySector.Name = "ComboBoxSocietySector";
            ComboBoxSocietySector.Size = new Size(217, 23);
            ComboBoxSocietySector.TabIndex = 0;
            // 
            // LSocietySector
            // 
            LSocietySector.AutoSize = true;
            LSocietySector.Location = new Point(7, 15);
            LSocietySector.Name = "LSocietySector";
            LSocietySector.Size = new Size(40, 15);
            LSocietySector.TabIndex = 7;
            LSocietySector.Text = "Sector";
            // 
            // LName
            // 
            LName.AutoSize = true;
            LName.Location = new Point(7, 133);
            LName.Name = "LName";
            LName.Size = new Size(51, 15);
            LName.TabIndex = 6;
            LName.Text = "Nombre";
            // 
            // TextBoxName
            // 
            TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxName.Location = new Point(82, 130);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(375, 23);
            TextBoxName.TabIndex = 3;
            // 
            // TabControlInstitution
            // 
            TabControlInstitution.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControlInstitution.Controls.Add(TabGeneral);
            TabControlInstitution.Controls.Add(TabPositions);
            TabControlInstitution.Controls.Add(TabAddress);
            TabControlInstitution.Location = new Point(1, 1);
            TabControlInstitution.Margin = new Padding(1);
            TabControlInstitution.Name = "TabControlInstitution";
            TabControlInstitution.SelectedIndex = 0;
            TabControlInstitution.Size = new Size(471, 351);
            TabControlInstitution.TabIndex = 0;
            // 
            // TabPositions
            // 
            TabPositions.Controls.Add(DataGridInstitutionRoles);
            TabPositions.Controls.Add(toolStrip1);
            TabPositions.Location = new Point(4, 24);
            TabPositions.Name = "TabPositions";
            TabPositions.Padding = new Padding(3);
            TabPositions.Size = new Size(463, 323);
            TabPositions.TabIndex = 1;
            TabPositions.Text = "Cargos";
            TabPositions.UseVisualStyleBackColor = true;
            // 
            // DataGridInstitutionRoles
            // 
            DataGridInstitutionRoles.AllowUserToAddRows = false;
            DataGridInstitutionRoles.AllowUserToDeleteRows = false;
            DataGridInstitutionRoles.AllowUserToOrderColumns = true;
            DataGridInstitutionRoles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            DataGridInstitutionRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridInstitutionRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridInstitutionRoles.BackgroundColor = SystemColors.Control;
            DataGridInstitutionRoles.BorderStyle = BorderStyle.None;
            DataGridInstitutionRoles.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridInstitutionRoles.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridInstitutionRoles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridInstitutionRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridInstitutionRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGridInstitutionRoles.DefaultCellStyle = dataGridViewCellStyle3;
            DataGridInstitutionRoles.Dock = DockStyle.Fill;
            DataGridInstitutionRoles.EnableHeadersVisualStyles = false;
            DataGridInstitutionRoles.ImeMode = ImeMode.NoControl;
            DataGridInstitutionRoles.Location = new Point(3, 28);
            DataGridInstitutionRoles.MultiSelect = false;
            DataGridInstitutionRoles.Name = "DataGridInstitutionRoles";
            DataGridInstitutionRoles.ReadOnly = true;
            DataGridInstitutionRoles.RowHeadersVisible = false;
            DataGridInstitutionRoles.RowTemplate.Height = 20;
            DataGridInstitutionRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridInstitutionRoles.ShowCellToolTips = false;
            DataGridInstitutionRoles.Size = new Size(457, 292);
            DataGridInstitutionRoles.StandardTab = true;
            DataGridInstitutionRoles.TabIndex = 8;
            DataGridInstitutionRoles.CellFormatting += DataGridInstitutionRoles_CellFormatting;
            DataGridInstitutionRoles.SelectionChanged += DataGridInstitutionRoles_SelectionChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { BAddRole, BEditRole, BDeleteRole, BSearchCitizensWithRole });
            toolStrip1.Location = new Point(3, 3);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(457, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "ToolStripInstitutionPositions";
            // 
            // BAddRole
            // 
            BAddRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
            BAddRole.ImageScaling = ToolStripItemImageScaling.None;
            BAddRole.ImageTransparentColor = Color.Magenta;
            BAddRole.Margin = new Padding(1, 2, 1, 2);
            BAddRole.Name = "BAddRole";
            BAddRole.Padding = new Padding(2, 0, 2, 0);
            BAddRole.Size = new Size(73, 21);
            BAddRole.Text = "&Agregar";
            BAddRole.Click += BAddRole_Click;
            // 
            // BEditRole
            // 
            BEditRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
            BEditRole.ImageScaling = ToolStripItemImageScaling.None;
            BEditRole.ImageTransparentColor = Color.Magenta;
            BEditRole.Margin = new Padding(1, 2, 1, 2);
            BEditRole.Name = "BEditRole";
            BEditRole.Padding = new Padding(2, 0, 2, 0);
            BEditRole.Size = new Size(61, 21);
            BEditRole.Text = "&Editar";
            BEditRole.Click += BEditRole_Click;
            // 
            // BDeleteRole
            // 
            BDeleteRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Cancel_16;
            BDeleteRole.ImageTransparentColor = Color.Magenta;
            BDeleteRole.Margin = new Padding(1, 2, 1, 2);
            BDeleteRole.Name = "BDeleteRole";
            BDeleteRole.Padding = new Padding(2, 0, 2, 0);
            BDeleteRole.Size = new Size(63, 21);
            BDeleteRole.Text = "&Borrar";
            BDeleteRole.Click += BDeleteRole_Click;
            // 
            // BSearchCitizensWithRole
            // 
            BSearchCitizensWithRole.Alignment = ToolStripItemAlignment.Right;
            BSearchCitizensWithRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Search_accounts_16;
            BSearchCitizensWithRole.ImageScaling = ToolStripItemImageScaling.None;
            BSearchCitizensWithRole.ImageTransparentColor = Color.Magenta;
            BSearchCitizensWithRole.Name = "BSearchCitizensWithRole";
            BSearchCitizensWithRole.Size = new Size(175, 22);
            BSearchCitizensWithRole.Text = "&Ver ciudadanos con el cargo";
            BSearchCitizensWithRole.Click += BSearchCitizensWithRole_Click;
            // 
            // TabAddress
            // 
            TabAddress.Controls.Add(TextBoxDistrict);
            TabAddress.Controls.Add(LDistrict);
            TabAddress.Controls.Add(LCountryFullName);
            TabAddress.Controls.Add(LCountry);
            TabAddress.Controls.Add(ComboBoxCountry);
            TabAddress.Controls.Add(TextBoxCity);
            TabAddress.Controls.Add(LCity);
            TabAddress.Controls.Add(TextBoxState);
            TabAddress.Controls.Add(LState);
            TabAddress.Controls.Add(TextBoxPostalCode);
            TabAddress.Controls.Add(LPostalCode);
            TabAddress.Controls.Add(TextBoxInteriorNumber);
            TabAddress.Controls.Add(LInteriorNumber);
            TabAddress.Controls.Add(TextBoxNumber);
            TabAddress.Controls.Add(LNumber);
            TabAddress.Controls.Add(TextBoxStreet);
            TabAddress.Controls.Add(LStreet);
            TabAddress.Location = new Point(4, 24);
            TabAddress.Name = "TabAddress";
            TabAddress.Padding = new Padding(3);
            TabAddress.Size = new Size(463, 323);
            TabAddress.TabIndex = 2;
            TabAddress.Text = "Dirección";
            TabAddress.UseVisualStyleBackColor = true;
            // 
            // TextBoxDistrict
            // 
            TextBoxDistrict.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxDistrict.Location = new Point(57, 67);
            TextBoxDistrict.Name = "TextBoxDistrict";
            TextBoxDistrict.Size = new Size(400, 23);
            TextBoxDistrict.TabIndex = 3;
            // 
            // LDistrict
            // 
            LDistrict.AutoSize = true;
            LDistrict.Location = new Point(7, 70);
            LDistrict.Name = "LDistrict";
            LDistrict.Size = new Size(48, 15);
            LDistrict.TabIndex = 56;
            LDistrict.Text = "Colonia";
            // 
            // LCountryFullName
            // 
            LCountryFullName.AutoSize = true;
            LCountryFullName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LCountryFullName.ForeColor = SystemColors.HotTrack;
            LCountryFullName.Location = new Point(183, 186);
            LCountryFullName.Name = "LCountryFullName";
            LCountryFullName.Size = new Size(155, 15);
            LCountryFullName.TabIndex = 54;
            LCountryFullName.Text = "- Estados Unidos Mexicanos";
            // 
            // LCountry
            // 
            LCountry.AutoSize = true;
            LCountry.Location = new Point(7, 186);
            LCountry.Name = "LCountry";
            LCountry.Size = new Size(28, 15);
            LCountry.TabIndex = 53;
            LCountry.Text = "País";
            // 
            // ComboBoxCountry
            // 
            ComboBoxCountry.FormattingEnabled = true;
            ComboBoxCountry.Location = new Point(57, 183);
            ComboBoxCountry.Name = "ComboBoxCountry";
            ComboBoxCountry.Size = new Size(120, 23);
            ComboBoxCountry.TabIndex = 7;
            // 
            // TextBoxCity
            // 
            TextBoxCity.Location = new Point(57, 96);
            TextBoxCity.Name = "TextBoxCity";
            TextBoxCity.Size = new Size(120, 23);
            TextBoxCity.TabIndex = 4;
            TextBoxCity.Text = "Aguascalientes";
            // 
            // LCity
            // 
            LCity.AutoSize = true;
            LCity.Location = new Point(6, 99);
            LCity.Name = "LCity";
            LCity.Size = new Size(45, 15);
            LCity.TabIndex = 52;
            LCity.Text = "Ciudad";
            // 
            // TextBoxState
            // 
            TextBoxState.Location = new Point(57, 125);
            TextBoxState.Name = "TextBoxState";
            TextBoxState.Size = new Size(120, 23);
            TextBoxState.TabIndex = 5;
            TextBoxState.Text = "Aguascalientes";
            // 
            // LState
            // 
            LState.AutoSize = true;
            LState.Location = new Point(6, 128);
            LState.Name = "LState";
            LState.Size = new Size(42, 15);
            LState.TabIndex = 51;
            LState.Text = "Estado";
            // 
            // TextBoxPostalCode
            // 
            TextBoxPostalCode.Location = new Point(57, 154);
            TextBoxPostalCode.Name = "TextBoxPostalCode";
            TextBoxPostalCode.Size = new Size(120, 23);
            TextBoxPostalCode.TabIndex = 6;
            // 
            // LPostalCode
            // 
            LPostalCode.AutoSize = true;
            LPostalCode.Location = new Point(6, 157);
            LPostalCode.Name = "LPostalCode";
            LPostalCode.Size = new Size(28, 15);
            LPostalCode.TabIndex = 50;
            LPostalCode.Text = "C.P.";
            // 
            // TextBoxInteriorNumber
            // 
            TextBoxInteriorNumber.Location = new Point(256, 38);
            TextBoxInteriorNumber.Name = "TextBoxInteriorNumber";
            TextBoxInteriorNumber.Size = new Size(101, 23);
            TextBoxInteriorNumber.TabIndex = 2;
            // 
            // LInteriorNumber
            // 
            LInteriorNumber.AutoSize = true;
            LInteriorNumber.Location = new Point(183, 41);
            LInteriorNumber.Name = "LInteriorNumber";
            LInteriorNumber.Size = new Size(67, 15);
            LInteriorNumber.TabIndex = 49;
            LInteriorNumber.Text = "No. Interior";
            // 
            // TextBoxNumber
            // 
            TextBoxNumber.Location = new Point(57, 38);
            TextBoxNumber.Name = "TextBoxNumber";
            TextBoxNumber.Size = new Size(120, 23);
            TextBoxNumber.TabIndex = 1;
            // 
            // LNumber
            // 
            LNumber.AutoSize = true;
            LNumber.Location = new Point(6, 41);
            LNumber.Name = "LNumber";
            LNumber.Size = new Size(26, 15);
            LNumber.TabIndex = 48;
            LNumber.Text = "No.";
            // 
            // TextBoxStreet
            // 
            TextBoxStreet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxStreet.Location = new Point(57, 9);
            TextBoxStreet.Name = "TextBoxStreet";
            TextBoxStreet.Size = new Size(400, 23);
            TextBoxStreet.TabIndex = 0;
            // 
            // LStreet
            // 
            LStreet.AutoSize = true;
            LStreet.Location = new Point(7, 12);
            LStreet.Name = "LStreet";
            LStreet.Size = new Size(33, 15);
            LStreet.TabIndex = 47;
            LStreet.Text = "Calle";
            // 
            // FInstitutionData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 391);
            ControlBox = false;
            Controls.Add(TabControlInstitution);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            Name = "FInstitutionData";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Institución - Nueva";
            Load += FInstitutionData_Load;
            TabGeneral.ResumeLayout(false);
            TabGeneral.PerformLayout();
            TabControlInstitution.ResumeLayout(false);
            TabPositions.ResumeLayout(false);
            TabPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridInstitutionRoles).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            TabAddress.ResumeLayout(false);
            TabAddress.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BCancel;
		private Button BAccept;
		private TabPage TabGeneral;
		private TabControl TabControlInstitution;
		private TabPage TabPositions;
		private Label LName;
		private TextBox TextBoxName;
		private Label LSocietySector;
		private ComboBox ComboBoxSocietySector;
		private TextBox TextBoxDescription;
		private Label LDescription;
		private ToolStrip toolStrip1;
		private Label LInstitutionCategory;
		private ToolStripButton BAddRole;
		private ToolStripButton BEditRole;
		private ComboBox ComboBoxParentInstitution;
		private Label LParentInstitution;
		private ComboBox ComboBoxCategory;
		private Label LAcronym;
		private TextBox TextBoxAcronym;
		private ToolStripButton BDeleteRole;
		private DataGridView DataGridInstitutionRoles;
		private ComboBox Template;
		private Label LTemplate;
		private ToolStripButton BSearchCitizensWithRole;
        private TabPage TabAddress;
        private TextBox TextBoxDistrict;
        private Label LDistrict;
        private Label LCountryFullName;
        private Label LCountry;
        private ComboBox ComboBoxCountry;
        private TextBox TextBoxCity;
        private Label LCity;
        private TextBox TextBoxState;
        private Label LState;
        private TextBox TextBoxPostalCode;
        private Label LPostalCode;
        private TextBox TextBoxInteriorNumber;
        private Label LInteriorNumber;
        private TextBox TextBoxNumber;
        private Label LNumber;
        private TextBox TextBoxStreet;
        private Label LStreet;
    }
}