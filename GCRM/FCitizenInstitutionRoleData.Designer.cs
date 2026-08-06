namespace GCRM
{
	partial class FCitizenInstitutionRoleData
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
            BCancel = new Button();
            BAccept = new Button();
            LInstitution = new Label();
            ComboBoxInstitution = new ComboBox();
            LRole = new Label();
            ComboBoxRole = new ComboBox();
            CheckBoxActive = new CheckBox();
            CheckBoxStartDefined = new CheckBox();
            DateTimePickerStart = new DateTimePicker();
            CheckBoxEndDefined = new CheckBox();
            DateTimePickerEnd = new DateTimePicker();
            comboBoxRoleVariation = new ComboBox();
            LInstitutionSectorAndCategory = new Label();
            BAddRole = new Button();
            BAddRoleVariation = new Button();
            LRoleVariant = new Label();
            SuspendLayout();
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(426, 223);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 8;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(348, 223);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 7;
            BAccept.Text = "&Aceptar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // LInstitution
            // 
            LInstitution.AutoSize = true;
            LInstitution.Location = new Point(12, 40);
            LInstitution.Name = "LInstitution";
            LInstitution.Size = new Size(63, 15);
            LInstitution.TabIndex = 9;
            LInstitution.Text = "Institución";
            // 
            // ComboBoxInstitution
            // 
            ComboBoxInstitution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxInstitution.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxInstitution.FormattingEnabled = true;
            ComboBoxInstitution.Location = new Point(79, 37);
            ComboBoxInstitution.Name = "ComboBoxInstitution";
            ComboBoxInstitution.Size = new Size(422, 23);
            ComboBoxInstitution.TabIndex = 0;
            ComboBoxInstitution.SelectedIndexChanged += ComboBoxInstitution_SelectedIndexChanged;
            // 
            // LRole
            // 
            LRole.AutoSize = true;
            LRole.Location = new Point(12, 94);
            LRole.Name = "LRole";
            LRole.Size = new Size(39, 15);
            LRole.TabIndex = 10;
            LRole.Text = "Cargo";
            // 
            // ComboBoxRole
            // 
            ComboBoxRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxRole.FormattingEnabled = true;
            ComboBoxRole.Location = new Point(79, 91);
            ComboBoxRole.Name = "ComboBoxRole";
            ComboBoxRole.Size = new Size(344, 23);
            ComboBoxRole.TabIndex = 1;
            ComboBoxRole.SelectedIndexChanged += ComboBoxRole_SelectedIndexChanged;
            // 
            // CheckBoxActive
            // 
            CheckBoxActive.AutoSize = true;
            CheckBoxActive.Checked = true;
            CheckBoxActive.CheckState = CheckState.Checked;
            CheckBoxActive.Location = new Point(79, 12);
            CheckBoxActive.Name = "CheckBoxActive";
            CheckBoxActive.Size = new Size(60, 19);
            CheckBoxActive.TabIndex = 3;
            CheckBoxActive.Text = "Activo";
            CheckBoxActive.UseVisualStyleBackColor = true;
            // 
            // CheckBoxStartDefined
            // 
            CheckBoxStartDefined.AutoSize = true;
            CheckBoxStartDefined.Location = new Point(80, 150);
            CheckBoxStartDefined.Name = "CheckBoxStartDefined";
            CheckBoxStartDefined.Size = new Size(55, 19);
            CheckBoxStartDefined.TabIndex = 4;
            CheckBoxStartDefined.Text = "Inicio";
            CheckBoxStartDefined.UseVisualStyleBackColor = true;
            CheckBoxStartDefined.CheckedChanged += CheckBoxStartDefined_CheckedChanged;
            // 
            // DateTimePickerStart
            // 
            DateTimePickerStart.Enabled = false;
            DateTimePickerStart.Format = DateTimePickerFormat.Short;
            DateTimePickerStart.Location = new Point(149, 149);
            DateTimePickerStart.Name = "DateTimePickerStart";
            DateTimePickerStart.Size = new Size(153, 23);
            DateTimePickerStart.TabIndex = 5;
            // 
            // CheckBoxEndDefined
            // 
            CheckBoxEndDefined.AutoSize = true;
            CheckBoxEndDefined.Location = new Point(80, 180);
            CheckBoxEndDefined.Name = "CheckBoxEndDefined";
            CheckBoxEndDefined.Size = new Size(42, 19);
            CheckBoxEndDefined.TabIndex = 6;
            CheckBoxEndDefined.Text = "Fin";
            CheckBoxEndDefined.UseVisualStyleBackColor = true;
            CheckBoxEndDefined.CheckedChanged += CheckBoxEndDefined_CheckedChanged;
            // 
            // DateTimePickerEnd
            // 
            DateTimePickerEnd.Enabled = false;
            DateTimePickerEnd.Format = DateTimePickerFormat.Short;
            DateTimePickerEnd.Location = new Point(149, 178);
            DateTimePickerEnd.Name = "DateTimePickerEnd";
            DateTimePickerEnd.Size = new Size(153, 23);
            DateTimePickerEnd.TabIndex = 12;
            // 
            // comboBoxRoleVariation
            // 
            comboBoxRoleVariation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxRoleVariation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRoleVariation.FormattingEnabled = true;
            comboBoxRoleVariation.Location = new Point(79, 120);
            comboBoxRoleVariation.Name = "comboBoxRoleVariation";
            comboBoxRoleVariation.Size = new Size(344, 23);
            comboBoxRoleVariation.TabIndex = 13;
            // 
            // LInstitutionSectorAndCategory
            // 
            LInstitutionSectorAndCategory.AutoSize = true;
            LInstitutionSectorAndCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LInstitutionSectorAndCategory.ForeColor = SystemColors.HotTrack;
            LInstitutionSectorAndCategory.Location = new Point(79, 68);
            LInstitutionSectorAndCategory.Name = "LInstitutionSectorAndCategory";
            LInstitutionSectorAndCategory.Size = new Size(157, 15);
            LInstitutionSectorAndCategory.TabIndex = 40;
            LInstitutionSectorAndCategory.Text = "Gobierno - Gobierno Federal";
            // 
            // BAddRole
            // 
            BAddRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BAddRole.Enabled = false;
            BAddRole.Location = new Point(429, 90);
            BAddRole.Name = "BAddRole";
            BAddRole.Size = new Size(72, 23);
            BAddRole.TabIndex = 55;
            BAddRole.Text = "Nuevo";
            BAddRole.UseVisualStyleBackColor = true;
            BAddRole.Click += BAddRole_Click;
            // 
            // BAddRoleVariation
            // 
            BAddRoleVariation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BAddRoleVariation.Enabled = false;
            BAddRoleVariation.Location = new Point(429, 120);
            BAddRoleVariation.Name = "BAddRoleVariation";
            BAddRoleVariation.Size = new Size(72, 23);
            BAddRoleVariation.TabIndex = 56;
            BAddRoleVariation.Text = "Nueva";
            BAddRoleVariation.UseVisualStyleBackColor = true;
            BAddRoleVariation.Click += BAddRoleVariation_Click;
            // 
            // LRoleVariant
            // 
            LRoleVariant.AutoSize = true;
            LRoleVariant.Location = new Point(12, 123);
            LRoleVariant.Name = "LRoleVariant";
            LRoleVariant.Size = new Size(49, 15);
            LRoleVariant.TabIndex = 57;
            LRoleVariant.Text = "Variante";
            // 
            // FCitizenInstitutionRoleData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 258);
            ControlBox = false;
            Controls.Add(LRoleVariant);
            Controls.Add(BAddRoleVariation);
            Controls.Add(BAddRole);
            Controls.Add(LInstitutionSectorAndCategory);
            Controls.Add(comboBoxRoleVariation);
            Controls.Add(DateTimePickerEnd);
            Controls.Add(CheckBoxEndDefined);
            Controls.Add(DateTimePickerStart);
            Controls.Add(CheckBoxStartDefined);
            Controls.Add(CheckBoxActive);
            Controls.Add(ComboBoxRole);
            Controls.Add(LRole);
            Controls.Add(ComboBoxInstitution);
            Controls.Add(LInstitution);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            MaximumSize = new Size(529, 297);
            MinimumSize = new Size(529, 297);
            Name = "FCitizenInstitutionRoleData";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Cargo del ciudadano";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
		private Button BAccept;
		private Label LInstitution;
		private ComboBox ComboBoxInstitution;
		private Label LRole;
		private ComboBox ComboBoxRole;
		private CheckBox CheckBoxActive;
		private CheckBox CheckBoxStartDefined;
		private DateTimePicker DateTimePickerStart;
		private CheckBox CheckBoxEndDefined;
		private DateTimePicker DateTimePickerEnd;
        private ComboBox comboBoxRoleVariation;
        private Label LInstitutionSectorAndCategory;
        private Button BAddRole;
        private Button BAddRoleVariation;
        private Label LRoleVariant;
    }
}
