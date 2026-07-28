namespace GCRM
{
	partial class FCitizenListFilters
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
            CheckBoxFilterParty = new CheckBox();
            ComboBoxPoliticalParty = new ComboBox();
            BCancel = new Button();
            BAccept = new Button();
            ComboBoxSex = new ComboBox();
            CheckBoxFilterSex = new CheckBox();
            ComboBoxCitizenTitle = new ComboBox();
            CheckBoxFilterTitle = new CheckBox();
            ComboBoxInstitucion = new ComboBox();
            CheckBoxFilterInstitution = new CheckBox();
            ComboBoxSector = new ComboBox();
            CheckBoxFilterSector = new CheckBox();
            ComboBoxInstitutionCategory = new ComboBox();
            CheckBoxFilterInstitutionCategory = new CheckBox();
            ComboBoxBirthdayYear = new ComboBox();
            CheckBoxFilterBirthdayYear = new CheckBox();
            ComboBoxBirthdayMonth = new ComboBox();
            CheckBoxFilterBirthdayMonth = new CheckBox();
            ComboBoxBirthdayDay = new ComboBox();
            CheckBoxFilterBirthdayDay = new CheckBox();
            ComboBoxCategory = new ComboBox();
            CheckBoxFilterCategory = new CheckBox();
            BSelectInstitution = new Button();
            CheckBoxFilterStatus = new CheckBox();
            ComboBoxStatus = new ComboBox();
            ComboBoxVerifiedBy = new ComboBox();
            CheckBoxFilterVerifiedBy = new CheckBox();
            ComboBoxCreatedBy = new ComboBox();
            CheckBoxFilterCreatedBy = new CheckBox();
            ComboBoxEditedBy = new ComboBox();
            CheckBoxFilterEditedBy = new CheckBox();
            SuspendLayout();
            // 
            // CheckBoxFilterParty
            // 
            CheckBoxFilterParty.AutoSize = true;
            CheckBoxFilterParty.Location = new Point(12, 12);
            CheckBoxFilterParty.Name = "CheckBoxFilterParty";
            CheckBoxFilterParty.Size = new Size(64, 19);
            CheckBoxFilterParty.TabIndex = 0;
            CheckBoxFilterParty.Text = "Partido";
            CheckBoxFilterParty.UseVisualStyleBackColor = true;
            CheckBoxFilterParty.CheckedChanged += CheckBoxFilterParty_CheckedChanged;
            // 
            // ComboBoxPoliticalParty
            // 
            ComboBoxPoliticalParty.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxPoliticalParty.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxPoliticalParty.Enabled = false;
            ComboBoxPoliticalParty.FormattingEnabled = true;
            ComboBoxPoliticalParty.Location = new Point(114, 10);
            ComboBoxPoliticalParty.Name = "ComboBoxPoliticalParty";
            ComboBoxPoliticalParty.Size = new Size(239, 23);
            ComboBoxPoliticalParty.TabIndex = 1;
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(278, 428);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 3;
            BCancel.Text = "&Cerrar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(197, 428);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 2;
            BAccept.Text = "&Aplicar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // ComboBoxSex
            // 
            ComboBoxSex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxSex.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSex.Enabled = false;
            ComboBoxSex.FormattingEnabled = true;
            ComboBoxSex.Location = new Point(114, 39);
            ComboBoxSex.Name = "ComboBoxSex";
            ComboBoxSex.Size = new Size(239, 23);
            ComboBoxSex.TabIndex = 5;
            // 
            // CheckBoxFilterSex
            // 
            CheckBoxFilterSex.AutoSize = true;
            CheckBoxFilterSex.Location = new Point(12, 41);
            CheckBoxFilterSex.Name = "CheckBoxFilterSex";
            CheckBoxFilterSex.Size = new Size(50, 19);
            CheckBoxFilterSex.TabIndex = 4;
            CheckBoxFilterSex.Text = "Sexo";
            CheckBoxFilterSex.UseVisualStyleBackColor = true;
            CheckBoxFilterSex.CheckedChanged += CheckBoxFilterSex_CheckedChanged;
            // 
            // ComboBoxCitizenTitle
            // 
            ComboBoxCitizenTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxCitizenTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxCitizenTitle.Enabled = false;
            ComboBoxCitizenTitle.FormattingEnabled = true;
            ComboBoxCitizenTitle.Location = new Point(114, 68);
            ComboBoxCitizenTitle.Name = "ComboBoxCitizenTitle";
            ComboBoxCitizenTitle.Size = new Size(239, 23);
            ComboBoxCitizenTitle.TabIndex = 7;
            // 
            // CheckBoxFilterTitle
            // 
            CheckBoxFilterTitle.AutoSize = true;
            CheckBoxFilterTitle.Location = new Point(12, 70);
            CheckBoxFilterTitle.Name = "CheckBoxFilterTitle";
            CheckBoxFilterTitle.Size = new Size(57, 19);
            CheckBoxFilterTitle.TabIndex = 6;
            CheckBoxFilterTitle.Text = "Título";
            CheckBoxFilterTitle.UseVisualStyleBackColor = true;
            CheckBoxFilterTitle.CheckedChanged += CheckBoxFilterTitle_CheckedChanged;
            // 
            // ComboBoxInstitucion
            // 
            ComboBoxInstitucion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxInstitucion.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxInstitucion.Enabled = false;
            ComboBoxInstitucion.FormattingEnabled = true;
            ComboBoxInstitucion.Location = new Point(114, 213);
            ComboBoxInstitucion.Name = "ComboBoxInstitucion";
            ComboBoxInstitucion.Size = new Size(213, 23);
            ComboBoxInstitucion.TabIndex = 9;
            // 
            // CheckBoxFilterInstitution
            // 
            CheckBoxFilterInstitution.AutoSize = true;
            CheckBoxFilterInstitution.Location = new Point(12, 215);
            CheckBoxFilterInstitution.Name = "CheckBoxFilterInstitution";
            CheckBoxFilterInstitution.Size = new Size(82, 19);
            CheckBoxFilterInstitution.TabIndex = 8;
            CheckBoxFilterInstitution.Text = "Institución";
            CheckBoxFilterInstitution.UseVisualStyleBackColor = true;
            CheckBoxFilterInstitution.CheckedChanged += CheckBoxFilterInstitution_CheckedChanged;
            // 
            // ComboBoxSector
            // 
            ComboBoxSector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxSector.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSector.Enabled = false;
            ComboBoxSector.FormattingEnabled = true;
            ComboBoxSector.Location = new Point(114, 242);
            ComboBoxSector.Name = "ComboBoxSector";
            ComboBoxSector.Size = new Size(239, 23);
            ComboBoxSector.TabIndex = 11;
            // 
            // CheckBoxFilterSector
            // 
            CheckBoxFilterSector.AutoSize = true;
            CheckBoxFilterSector.Location = new Point(12, 244);
            CheckBoxFilterSector.Name = "CheckBoxFilterSector";
            CheckBoxFilterSector.Size = new Size(59, 19);
            CheckBoxFilterSector.TabIndex = 10;
            CheckBoxFilterSector.Text = "Sector";
            CheckBoxFilterSector.UseVisualStyleBackColor = true;
            CheckBoxFilterSector.CheckedChanged += CheckBoxFilterSector_CheckedChanged;
            // 
            // ComboBoxInstitutionCategory
            // 
            ComboBoxInstitutionCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxInstitutionCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxInstitutionCategory.Enabled = false;
            ComboBoxInstitutionCategory.FormattingEnabled = true;
            ComboBoxInstitutionCategory.Location = new Point(114, 271);
            ComboBoxInstitutionCategory.Name = "ComboBoxInstitutionCategory";
            ComboBoxInstitutionCategory.Size = new Size(239, 23);
            ComboBoxInstitutionCategory.TabIndex = 13;
            // 
            // CheckBoxFilterInstitutionCategory
            // 
            CheckBoxFilterInstitutionCategory.AutoSize = true;
            CheckBoxFilterInstitutionCategory.Location = new Point(12, 273);
            CheckBoxFilterInstitutionCategory.Name = "CheckBoxFilterInstitutionCategory";
            CheckBoxFilterInstitutionCategory.Size = new Size(96, 19);
            CheckBoxFilterInstitutionCategory.TabIndex = 12;
            CheckBoxFilterInstitutionCategory.Text = "C. Institución";
            CheckBoxFilterInstitutionCategory.UseVisualStyleBackColor = true;
            CheckBoxFilterInstitutionCategory.CheckedChanged += CheckBoxFilterCategory_CheckedChanged;
            // 
            // ComboBoxBirthdayYear
            // 
            ComboBoxBirthdayYear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxBirthdayYear.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxBirthdayYear.Enabled = false;
            ComboBoxBirthdayYear.FormattingEnabled = true;
            ComboBoxBirthdayYear.Location = new Point(114, 97);
            ComboBoxBirthdayYear.Name = "ComboBoxBirthdayYear";
            ComboBoxBirthdayYear.Size = new Size(239, 23);
            ComboBoxBirthdayYear.TabIndex = 15;
            // 
            // CheckBoxFilterBirthdayYear
            // 
            CheckBoxFilterBirthdayYear.AutoSize = true;
            CheckBoxFilterBirthdayYear.Location = new Point(12, 99);
            CheckBoxFilterBirthdayYear.Name = "CheckBoxFilterBirthdayYear";
            CheckBoxFilterBirthdayYear.Size = new Size(75, 19);
            CheckBoxFilterBirthdayYear.TabIndex = 14;
            CheckBoxFilterBirthdayYear.Text = "Año Nac.";
            CheckBoxFilterBirthdayYear.UseVisualStyleBackColor = true;
            CheckBoxFilterBirthdayYear.CheckedChanged += CheckBoxFilterBirthdayYear_CheckedChanged;
            // 
            // ComboBoxBirthdayMonth
            // 
            ComboBoxBirthdayMonth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxBirthdayMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxBirthdayMonth.Enabled = false;
            ComboBoxBirthdayMonth.FormattingEnabled = true;
            ComboBoxBirthdayMonth.Location = new Point(114, 126);
            ComboBoxBirthdayMonth.Name = "ComboBoxBirthdayMonth";
            ComboBoxBirthdayMonth.Size = new Size(239, 23);
            ComboBoxBirthdayMonth.TabIndex = 17;
            // 
            // CheckBoxFilterBirthdayMonth
            // 
            CheckBoxFilterBirthdayMonth.AutoSize = true;
            CheckBoxFilterBirthdayMonth.Location = new Point(12, 128);
            CheckBoxFilterBirthdayMonth.Name = "CheckBoxFilterBirthdayMonth";
            CheckBoxFilterBirthdayMonth.Size = new Size(75, 19);
            CheckBoxFilterBirthdayMonth.TabIndex = 16;
            CheckBoxFilterBirthdayMonth.Text = "Mes Nac.";
            CheckBoxFilterBirthdayMonth.UseVisualStyleBackColor = true;
            CheckBoxFilterBirthdayMonth.CheckedChanged += CheckBoxBirthdayMonth_CheckedChanged;
            // 
            // ComboBoxBirthdayDay
            // 
            ComboBoxBirthdayDay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxBirthdayDay.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxBirthdayDay.Enabled = false;
            ComboBoxBirthdayDay.FormattingEnabled = true;
            ComboBoxBirthdayDay.Location = new Point(114, 155);
            ComboBoxBirthdayDay.Name = "ComboBoxBirthdayDay";
            ComboBoxBirthdayDay.Size = new Size(239, 23);
            ComboBoxBirthdayDay.TabIndex = 19;
            // 
            // CheckBoxFilterBirthdayDay
            // 
            CheckBoxFilterBirthdayDay.AutoSize = true;
            CheckBoxFilterBirthdayDay.Location = new Point(12, 157);
            CheckBoxFilterBirthdayDay.Name = "CheckBoxFilterBirthdayDay";
            CheckBoxFilterBirthdayDay.Size = new Size(70, 19);
            CheckBoxFilterBirthdayDay.TabIndex = 18;
            CheckBoxFilterBirthdayDay.Text = "Día Nac.";
            CheckBoxFilterBirthdayDay.UseVisualStyleBackColor = true;
            CheckBoxFilterBirthdayDay.CheckedChanged += CheckBoxBirthdayDay_CheckedChanged;
            // 
            // ComboBoxCategory
            // 
            ComboBoxCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxCategory.Enabled = false;
            ComboBoxCategory.FormattingEnabled = true;
            ComboBoxCategory.Location = new Point(114, 184);
            ComboBoxCategory.Name = "ComboBoxCategory";
            ComboBoxCategory.Size = new Size(239, 23);
            ComboBoxCategory.TabIndex = 21;
            // 
            // CheckBoxFilterCategory
            // 
            CheckBoxFilterCategory.AutoSize = true;
            CheckBoxFilterCategory.Location = new Point(12, 186);
            CheckBoxFilterCategory.Name = "CheckBoxFilterCategory";
            CheckBoxFilterCategory.Size = new Size(77, 19);
            CheckBoxFilterCategory.TabIndex = 20;
            CheckBoxFilterCategory.Text = "Categoría";
            CheckBoxFilterCategory.UseVisualStyleBackColor = true;
            CheckBoxFilterCategory.CheckedChanged += CheckBoxFilterCategory_CheckedChanged_1;
            // 
            // BSelectInstitution
            // 
            BSelectInstitution.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BSelectInstitution.Enabled = false;
            BSelectInstitution.Image = Properties.Resources.Fatcow_Farm_Fresh_Magnifier_16;
            BSelectInstitution.Location = new Point(330, 213);
            BSelectInstitution.Margin = new Padding(0);
            BSelectInstitution.Name = "BSelectInstitution";
            BSelectInstitution.Size = new Size(23, 23);
            BSelectInstitution.TabIndex = 22;
            BSelectInstitution.UseVisualStyleBackColor = true;
            BSelectInstitution.Click += BSelectInstitution_Click;
            // 
            // CheckBoxFilterStatus
            // 
            CheckBoxFilterStatus.AutoSize = true;
            CheckBoxFilterStatus.Location = new Point(12, 302);
            CheckBoxFilterStatus.Name = "CheckBoxFilterStatus";
            CheckBoxFilterStatus.Size = new Size(61, 19);
            CheckBoxFilterStatus.TabIndex = 23;
            CheckBoxFilterStatus.Text = "Estado";
            CheckBoxFilterStatus.UseVisualStyleBackColor = true;
            CheckBoxFilterStatus.CheckedChanged += CheckBoxFilterStatus_CheckedChanged;
            // 
            // ComboBoxStatus
            // 
            ComboBoxStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxStatus.Enabled = false;
            ComboBoxStatus.FormattingEnabled = true;
            ComboBoxStatus.Location = new Point(114, 300);
            ComboBoxStatus.Name = "ComboBoxStatus";
            ComboBoxStatus.Size = new Size(239, 23);
            ComboBoxStatus.TabIndex = 24;
            // 
            // ComboBoxVerifiedBy
            // 
            ComboBoxVerifiedBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxVerifiedBy.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxVerifiedBy.Enabled = false;
            ComboBoxVerifiedBy.FormattingEnabled = true;
            ComboBoxVerifiedBy.Location = new Point(114, 329);
            ComboBoxVerifiedBy.Name = "ComboBoxVerifiedBy";
            ComboBoxVerifiedBy.Size = new Size(239, 23);
            ComboBoxVerifiedBy.TabIndex = 26;
            // 
            // CheckBoxFilterVerifiedBy
            // 
            CheckBoxFilterVerifiedBy.AutoSize = true;
            CheckBoxFilterVerifiedBy.Location = new Point(12, 331);
            CheckBoxFilterVerifiedBy.Name = "CheckBoxFilterVerifiedBy";
            CheckBoxFilterVerifiedBy.Size = new Size(99, 19);
            CheckBoxFilterVerifiedBy.TabIndex = 25;
            CheckBoxFilterVerifiedBy.Text = "Verificado por";
            CheckBoxFilterVerifiedBy.UseVisualStyleBackColor = true;
            CheckBoxFilterVerifiedBy.CheckedChanged += CheckBoxFilterVerifiedBy_CheckedChanged;
            //
            // ComboBoxCreatedBy
            //
            ComboBoxCreatedBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxCreatedBy.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxCreatedBy.Enabled = false;
            ComboBoxCreatedBy.FormattingEnabled = true;
            ComboBoxCreatedBy.Location = new Point(114, 358);
            ComboBoxCreatedBy.Name = "ComboBoxCreatedBy";
            ComboBoxCreatedBy.Size = new Size(239, 23);
            ComboBoxCreatedBy.TabIndex = 28;
            //
            // CheckBoxFilterCreatedBy
            //
            CheckBoxFilterCreatedBy.AutoSize = true;
            CheckBoxFilterCreatedBy.Location = new Point(12, 360);
            CheckBoxFilterCreatedBy.Name = "CheckBoxFilterCreatedBy";
            CheckBoxFilterCreatedBy.Size = new Size(85, 19);
            CheckBoxFilterCreatedBy.TabIndex = 27;
            CheckBoxFilterCreatedBy.Text = "Creado por";
            CheckBoxFilterCreatedBy.UseVisualStyleBackColor = true;
            CheckBoxFilterCreatedBy.CheckedChanged += CheckBoxFilterCreatedBy_CheckedChanged;
            //
            // ComboBoxEditedBy
            //
            ComboBoxEditedBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxEditedBy.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxEditedBy.Enabled = false;
            ComboBoxEditedBy.FormattingEnabled = true;
            ComboBoxEditedBy.Location = new Point(114, 387);
            ComboBoxEditedBy.Name = "ComboBoxEditedBy";
            ComboBoxEditedBy.Size = new Size(239, 23);
            ComboBoxEditedBy.TabIndex = 30;
            //
            // CheckBoxFilterEditedBy
            //
            CheckBoxFilterEditedBy.AutoSize = true;
            CheckBoxFilterEditedBy.Location = new Point(12, 389);
            CheckBoxFilterEditedBy.Name = "CheckBoxFilterEditedBy";
            CheckBoxFilterEditedBy.Size = new Size(87, 19);
            CheckBoxFilterEditedBy.TabIndex = 29;
            CheckBoxFilterEditedBy.Text = "Editado por";
            CheckBoxFilterEditedBy.UseVisualStyleBackColor = true;
            CheckBoxFilterEditedBy.CheckedChanged += CheckBoxFilterEditedBy_CheckedChanged;
            // 
            // FCitizenListFilters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 463);
            ControlBox = false;
            Controls.Add(ComboBoxEditedBy);
            Controls.Add(CheckBoxFilterEditedBy);
            Controls.Add(ComboBoxCreatedBy);
            Controls.Add(CheckBoxFilterCreatedBy);
            Controls.Add(ComboBoxVerifiedBy);
            Controls.Add(CheckBoxFilterVerifiedBy);
            Controls.Add(ComboBoxStatus);
            Controls.Add(CheckBoxFilterStatus);
            Controls.Add(BSelectInstitution);
            Controls.Add(ComboBoxCategory);
            Controls.Add(CheckBoxFilterCategory);
            Controls.Add(ComboBoxBirthdayDay);
            Controls.Add(CheckBoxFilterBirthdayDay);
            Controls.Add(ComboBoxBirthdayMonth);
            Controls.Add(CheckBoxFilterBirthdayMonth);
            Controls.Add(ComboBoxBirthdayYear);
            Controls.Add(CheckBoxFilterBirthdayYear);
            Controls.Add(BAccept);
            Controls.Add(BCancel);
            Controls.Add(ComboBoxInstitutionCategory);
            Controls.Add(CheckBoxFilterInstitutionCategory);
            Controls.Add(ComboBoxSector);
            Controls.Add(CheckBoxFilterSector);
            Controls.Add(ComboBoxInstitucion);
            Controls.Add(CheckBoxFilterInstitution);
            Controls.Add(ComboBoxCitizenTitle);
            Controls.Add(CheckBoxFilterTitle);
            Controls.Add(ComboBoxSex);
            Controls.Add(CheckBoxFilterSex);
            Controls.Add(ComboBoxPoliticalParty);
            Controls.Add(CheckBoxFilterParty);
            MinimumSize = new Size(360, 350);
            Name = "FCitizenListFilters";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Filtros";
            Load += FCitizenListFilters_Load;
            Shown += FCitizenListFilters_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox CheckBoxFilterParty;
		private ComboBox ComboBoxPoliticalParty;
		private Button BCancel;
		private Button BAccept;
		private ComboBox ComboBoxSex;
		private CheckBox CheckBoxFilterSex;
		private ComboBox ComboBoxCitizenTitle;
		private CheckBox CheckBoxFilterTitle;
		private ComboBox ComboBoxInstitucion;
		private CheckBox CheckBoxFilterInstitution;
		private ComboBox ComboBoxSector;
		private CheckBox CheckBoxFilterSector;
		private ComboBox ComboBoxInstitutionCategory;
		private CheckBox CheckBoxFilterInstitutionCategory;
		private ComboBox ComboBoxBirthdayYear;
		private CheckBox CheckBoxFilterBirthdayYear;
		private ComboBox ComboBoxBirthdayMonth;
		private CheckBox CheckBoxFilterBirthdayMonth;
		private ComboBox ComboBoxBirthdayDay;
		private CheckBox CheckBoxFilterBirthdayDay;
		private ComboBox ComboBoxCategory;
		private CheckBox CheckBoxFilterCategory;
		private Button BSelectInstitution;
		private CheckBox CheckBoxFilterStatus;
		private ComboBox ComboBoxStatus;
        private ComboBox ComboBoxVerifiedBy;
        private CheckBox CheckBoxFilterVerifiedBy;
        private ComboBox ComboBoxCreatedBy;
        private CheckBox CheckBoxFilterCreatedBy;
        private ComboBox ComboBoxEditedBy;
        private CheckBox CheckBoxFilterEditedBy;
    }
}