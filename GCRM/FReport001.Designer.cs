namespace GCRM
{
    partial class FReport001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReport001));
            BCancel = new Button();
            BAccept = new Button();
            CitizenTitle = new ComboBox();
            CheckBoxFilterCitizenTitle = new CheckBox();
            Sex = new ComboBox();
            CheckBoxFilterSex = new CheckBox();
            Party = new ComboBox();
            CheckBoxFilterParty = new CheckBox();
            Institution = new ComboBox();
            CheckBoxFilterInstitution = new CheckBox();
            InstitutionCategory = new ComboBox();
            CheckBoxFilterInstitutionCategory = new CheckBox();
            Sector = new ComboBox();
            CheckBoxFilterSector = new CheckBox();
            BirthdayYear = new ComboBox();
            CheckBoxFilterBirthdayYear = new CheckBox();
            BirthdayMonth = new ComboBox();
            CheckBoxFilterBirthdayMonth = new CheckBox();
            BirthdayDay = new ComboBox();
            CheckBoxFilterBirthdayDay = new CheckBox();
            SuspendLayout();
            //
            // BCancel
            //
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(363, 279);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 20;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            //
            // BAccept
            //
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(280, 279);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 19;
            BAccept.Text = "&Generar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            //
            // CitizenTitle
            //
            CitizenTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CitizenTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            CitizenTitle.Enabled = false;
            CitizenTitle.FormattingEnabled = true;
            CitizenTitle.Location = new Point(180, 12);
            CitizenTitle.Name = "CitizenTitle";
            CitizenTitle.Size = new Size(258, 23);
            CitizenTitle.TabIndex = 0;
            //
            // CheckBoxFilterCitizenTitle
            //
            CheckBoxFilterCitizenTitle.AutoSize = true;
            CheckBoxFilterCitizenTitle.Location = new Point(12, 14);
            CheckBoxFilterCitizenTitle.Name = "CheckBoxFilterCitizenTitle";
            CheckBoxFilterCitizenTitle.Size = new Size(53, 19);
            CheckBoxFilterCitizenTitle.TabIndex = 1;
            CheckBoxFilterCitizenTitle.Text = "Título";
            CheckBoxFilterCitizenTitle.UseVisualStyleBackColor = true;
            CheckBoxFilterCitizenTitle.CheckedChanged += CheckBoxFilterCitizenTitle_CheckedChanged;
            //
            // Sex
            //
            Sex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Sex.DropDownStyle = ComboBoxStyle.DropDownList;
            Sex.Enabled = false;
            Sex.FormattingEnabled = true;
            Sex.Location = new Point(180, 41);
            Sex.Name = "Sex";
            Sex.Size = new Size(258, 23);
            Sex.TabIndex = 2;
            //
            // CheckBoxFilterSex
            //
            CheckBoxFilterSex.AutoSize = true;
            CheckBoxFilterSex.Location = new Point(12, 43);
            CheckBoxFilterSex.Name = "CheckBoxFilterSex";
            CheckBoxFilterSex.Size = new Size(48, 19);
            CheckBoxFilterSex.TabIndex = 3;
            CheckBoxFilterSex.Text = "Sexo";
            CheckBoxFilterSex.UseVisualStyleBackColor = true;
            CheckBoxFilterSex.CheckedChanged += CheckBoxFilterSex_CheckedChanged;
            //
            // Party
            //
            Party.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Party.DropDownStyle = ComboBoxStyle.DropDownList;
            Party.Enabled = false;
            Party.FormattingEnabled = true;
            Party.Location = new Point(180, 70);
            Party.Name = "Party";
            Party.Size = new Size(258, 23);
            Party.TabIndex = 4;
            //
            // CheckBoxFilterParty
            //
            CheckBoxFilterParty.AutoSize = true;
            CheckBoxFilterParty.Location = new Point(12, 72);
            CheckBoxFilterParty.Name = "CheckBoxFilterParty";
            CheckBoxFilterParty.Size = new Size(63, 19);
            CheckBoxFilterParty.TabIndex = 5;
            CheckBoxFilterParty.Text = "Partido";
            CheckBoxFilterParty.UseVisualStyleBackColor = true;
            CheckBoxFilterParty.CheckedChanged += CheckBoxFilterParty_CheckedChanged;
            //
            // Institution
            //
            Institution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Institution.DropDownStyle = ComboBoxStyle.DropDownList;
            Institution.Enabled = false;
            Institution.FormattingEnabled = true;
            Institution.Location = new Point(180, 99);
            Institution.Name = "Institution";
            Institution.Size = new Size(258, 23);
            Institution.TabIndex = 6;
            //
            // CheckBoxFilterInstitution
            //
            CheckBoxFilterInstitution.AutoSize = true;
            CheckBoxFilterInstitution.Location = new Point(12, 101);
            CheckBoxFilterInstitution.Name = "CheckBoxFilterInstitution";
            CheckBoxFilterInstitution.Size = new Size(84, 19);
            CheckBoxFilterInstitution.TabIndex = 7;
            CheckBoxFilterInstitution.Text = "Institución";
            CheckBoxFilterInstitution.UseVisualStyleBackColor = true;
            CheckBoxFilterInstitution.CheckedChanged += CheckBoxFilterInstitution_CheckedChanged;
            //
            // InstitutionCategory
            //
            InstitutionCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InstitutionCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            InstitutionCategory.Enabled = false;
            InstitutionCategory.FormattingEnabled = true;
            InstitutionCategory.Location = new Point(180, 128);
            InstitutionCategory.Name = "InstitutionCategory";
            InstitutionCategory.Size = new Size(258, 23);
            InstitutionCategory.TabIndex = 8;
            //
            // CheckBoxFilterInstitutionCategory
            //
            CheckBoxFilterInstitutionCategory.AutoSize = true;
            CheckBoxFilterInstitutionCategory.Location = new Point(12, 130);
            CheckBoxFilterInstitutionCategory.Name = "CheckBoxFilterInstitutionCategory";
            CheckBoxFilterInstitutionCategory.Size = new Size(162, 19);
            CheckBoxFilterInstitutionCategory.TabIndex = 9;
            CheckBoxFilterInstitutionCategory.Text = "Categoría de institución";
            CheckBoxFilterInstitutionCategory.UseVisualStyleBackColor = true;
            CheckBoxFilterInstitutionCategory.CheckedChanged += CheckBoxFilterInstitutionCategory_CheckedChanged;
            //
            // Sector
            //
            Sector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Sector.DropDownStyle = ComboBoxStyle.DropDownList;
            Sector.Enabled = false;
            Sector.FormattingEnabled = true;
            Sector.Location = new Point(180, 157);
            Sector.Name = "Sector";
            Sector.Size = new Size(258, 23);
            Sector.TabIndex = 10;
            //
            // CheckBoxFilterSector
            //
            CheckBoxFilterSector.AutoSize = true;
            CheckBoxFilterSector.Location = new Point(12, 159);
            CheckBoxFilterSector.Name = "CheckBoxFilterSector";
            CheckBoxFilterSector.Size = new Size(59, 19);
            CheckBoxFilterSector.TabIndex = 11;
            CheckBoxFilterSector.Text = "Sector";
            CheckBoxFilterSector.UseVisualStyleBackColor = true;
            CheckBoxFilterSector.CheckedChanged += CheckBoxFilterSector_CheckedChanged;
            //
            // BirthdayYear
            //
            BirthdayYear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BirthdayYear.DropDownStyle = ComboBoxStyle.DropDownList;
            BirthdayYear.Enabled = false;
            BirthdayYear.FormattingEnabled = true;
            BirthdayYear.Location = new Point(180, 186);
            BirthdayYear.Name = "BirthdayYear";
            BirthdayYear.Size = new Size(258, 23);
            BirthdayYear.TabIndex = 12;
            //
            // CheckBoxFilterBirthdayYear
            //
            CheckBoxFilterBirthdayYear.AutoSize = true;
            CheckBoxFilterBirthdayYear.Location = new Point(12, 188);
            CheckBoxFilterBirthdayYear.Name = "CheckBoxFilterBirthdayYear";
            CheckBoxFilterBirthdayYear.Size = new Size(146, 19);
            CheckBoxFilterBirthdayYear.TabIndex = 13;
            CheckBoxFilterBirthdayYear.Text = "Año de nacimiento";
            CheckBoxFilterBirthdayYear.UseVisualStyleBackColor = true;
            CheckBoxFilterBirthdayYear.CheckedChanged += CheckBoxFilterBirthdayYear_CheckedChanged;
            //
            // BirthdayMonth
            //
            BirthdayMonth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BirthdayMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            BirthdayMonth.Enabled = false;
            BirthdayMonth.FormattingEnabled = true;
            BirthdayMonth.Location = new Point(180, 215);
            BirthdayMonth.Name = "BirthdayMonth";
            BirthdayMonth.Size = new Size(258, 23);
            BirthdayMonth.TabIndex = 14;
            //
            // CheckBoxFilterBirthdayMonth
            //
            CheckBoxFilterBirthdayMonth.AutoSize = true;
            CheckBoxFilterBirthdayMonth.Location = new Point(12, 217);
            CheckBoxFilterBirthdayMonth.Name = "CheckBoxFilterBirthdayMonth";
            CheckBoxFilterBirthdayMonth.Size = new Size(145, 19);
            CheckBoxFilterBirthdayMonth.TabIndex = 15;
            CheckBoxFilterBirthdayMonth.Text = "Mes de nacimiento";
            CheckBoxFilterBirthdayMonth.UseVisualStyleBackColor = true;
            CheckBoxFilterBirthdayMonth.CheckedChanged += CheckBoxFilterBirthdayMonth_CheckedChanged;
            //
            // BirthdayDay
            //
            BirthdayDay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BirthdayDay.DropDownStyle = ComboBoxStyle.DropDownList;
            BirthdayDay.Enabled = false;
            BirthdayDay.FormattingEnabled = true;
            BirthdayDay.Location = new Point(180, 244);
            BirthdayDay.Name = "BirthdayDay";
            BirthdayDay.Size = new Size(258, 23);
            BirthdayDay.TabIndex = 16;
            //
            // CheckBoxFilterBirthdayDay
            //
            CheckBoxFilterBirthdayDay.AutoSize = true;
            CheckBoxFilterBirthdayDay.Location = new Point(12, 246);
            CheckBoxFilterBirthdayDay.Name = "CheckBoxFilterBirthdayDay";
            CheckBoxFilterBirthdayDay.Size = new Size(133, 19);
            CheckBoxFilterBirthdayDay.TabIndex = 17;
            CheckBoxFilterBirthdayDay.Text = "Día de nacimiento";
            CheckBoxFilterBirthdayDay.UseVisualStyleBackColor = true;
            CheckBoxFilterBirthdayDay.CheckedChanged += CheckBoxFilterBirthdayDay_CheckedChanged;
            //
            // FReport001
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 314);
            ControlBox = false;
            Controls.Add(CheckBoxFilterBirthdayDay);
            Controls.Add(BirthdayDay);
            Controls.Add(CheckBoxFilterBirthdayMonth);
            Controls.Add(BirthdayMonth);
            Controls.Add(CheckBoxFilterBirthdayYear);
            Controls.Add(BirthdayYear);
            Controls.Add(CheckBoxFilterSector);
            Controls.Add(Sector);
            Controls.Add(CheckBoxFilterInstitutionCategory);
            Controls.Add(InstitutionCategory);
            Controls.Add(CheckBoxFilterInstitution);
            Controls.Add(Institution);
            Controls.Add(CheckBoxFilterParty);
            Controls.Add(Party);
            Controls.Add(CheckBoxFilterSex);
            Controls.Add(Sex);
            Controls.Add(CheckBoxFilterCitizenTitle);
            Controls.Add(CitizenTitle);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FReport001";
            Text = "001: Catálogo de ciudadanos";
            Load += FReport001_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BAccept;
        private ComboBox CitizenTitle;
        private CheckBox CheckBoxFilterCitizenTitle;
        private ComboBox Sex;
        private CheckBox CheckBoxFilterSex;
        private ComboBox Party;
        private CheckBox CheckBoxFilterParty;
        private ComboBox Institution;
        private CheckBox CheckBoxFilterInstitution;
        private ComboBox InstitutionCategory;
        private CheckBox CheckBoxFilterInstitutionCategory;
        private ComboBox Sector;
        private CheckBox CheckBoxFilterSector;
        private ComboBox BirthdayYear;
        private CheckBox CheckBoxFilterBirthdayYear;
        private ComboBox BirthdayMonth;
        private CheckBox CheckBoxFilterBirthdayMonth;
        private ComboBox BirthdayDay;
        private CheckBox CheckBoxFilterBirthdayDay;
    }
}
