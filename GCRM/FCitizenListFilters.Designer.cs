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
			ComboBoxCategory = new ComboBox();
			CheckBoxFilterCategory = new CheckBox();
			ComboBoxBirthdayYear = new ComboBox();
			CheckBoxFilterBirthdayYear = new CheckBox();
			ComboBoxBirthdayMonth = new ComboBox();
			CheckBoxFilterBirthdayMonth = new CheckBox();
			ComboBoxBirthdayDay = new ComboBox();
			CheckBoxFilterBirthdayDay = new CheckBox();
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
			ComboBoxPoliticalParty.Enabled = false;
			ComboBoxPoliticalParty.FormattingEnabled = true;
			ComboBoxPoliticalParty.Location = new Point(100, 10);
			ComboBoxPoliticalParty.Name = "ComboBoxPoliticalParty";
			ComboBoxPoliticalParty.Size = new Size(232, 23);
			ComboBoxPoliticalParty.TabIndex = 1;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(257, 276);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 3;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(176, 276);
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
			ComboBoxSex.Enabled = false;
			ComboBoxSex.FormattingEnabled = true;
			ComboBoxSex.Location = new Point(100, 39);
			ComboBoxSex.Name = "ComboBoxSex";
			ComboBoxSex.Size = new Size(232, 23);
			ComboBoxSex.TabIndex = 5;
			// 
			// CheckBoxFilterSex
			// 
			CheckBoxFilterSex.AutoSize = true;
			CheckBoxFilterSex.Location = new Point(12, 41);
			CheckBoxFilterSex.Name = "CheckBoxFilterSex";
			CheckBoxFilterSex.Size = new Size(51, 19);
			CheckBoxFilterSex.TabIndex = 4;
			CheckBoxFilterSex.Text = "Sexo";
			CheckBoxFilterSex.UseVisualStyleBackColor = true;
			CheckBoxFilterSex.CheckedChanged += CheckBoxFilterSex_CheckedChanged;
			// 
			// ComboBoxCitizenTitle
			// 
			ComboBoxCitizenTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxCitizenTitle.Enabled = false;
			ComboBoxCitizenTitle.FormattingEnabled = true;
			ComboBoxCitizenTitle.Location = new Point(100, 68);
			ComboBoxCitizenTitle.Name = "ComboBoxCitizenTitle";
			ComboBoxCitizenTitle.Size = new Size(232, 23);
			ComboBoxCitizenTitle.TabIndex = 7;
			// 
			// CheckBoxFilterTitle
			// 
			CheckBoxFilterTitle.AutoSize = true;
			CheckBoxFilterTitle.Location = new Point(12, 70);
			CheckBoxFilterTitle.Name = "CheckBoxFilterTitle";
			CheckBoxFilterTitle.Size = new Size(56, 19);
			CheckBoxFilterTitle.TabIndex = 6;
			CheckBoxFilterTitle.Text = "Título";
			CheckBoxFilterTitle.UseVisualStyleBackColor = true;
			CheckBoxFilterTitle.CheckedChanged += CheckBoxFilterTitle_CheckedChanged;
			// 
			// ComboBoxInstitucion
			// 
			ComboBoxInstitucion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxInstitucion.Enabled = false;
			ComboBoxInstitucion.FormattingEnabled = true;
			ComboBoxInstitucion.Location = new Point(100, 97);
			ComboBoxInstitucion.Name = "ComboBoxInstitucion";
			ComboBoxInstitucion.Size = new Size(232, 23);
			ComboBoxInstitucion.TabIndex = 9;
			// 
			// CheckBoxFilterInstitution
			// 
			CheckBoxFilterInstitution.AutoSize = true;
			CheckBoxFilterInstitution.Location = new Point(12, 99);
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
			ComboBoxSector.Enabled = false;
			ComboBoxSector.FormattingEnabled = true;
			ComboBoxSector.Location = new Point(100, 126);
			ComboBoxSector.Name = "ComboBoxSector";
			ComboBoxSector.Size = new Size(232, 23);
			ComboBoxSector.TabIndex = 11;
			// 
			// CheckBoxFilterSector
			// 
			CheckBoxFilterSector.AutoSize = true;
			CheckBoxFilterSector.Location = new Point(12, 128);
			CheckBoxFilterSector.Name = "CheckBoxFilterSector";
			CheckBoxFilterSector.Size = new Size(59, 19);
			CheckBoxFilterSector.TabIndex = 10;
			CheckBoxFilterSector.Text = "Sector";
			CheckBoxFilterSector.UseVisualStyleBackColor = true;
			CheckBoxFilterSector.CheckedChanged += CheckBoxFilterSector_CheckedChanged;
			// 
			// ComboBoxCategory
			// 
			ComboBoxCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxCategory.Enabled = false;
			ComboBoxCategory.FormattingEnabled = true;
			ComboBoxCategory.Location = new Point(100, 155);
			ComboBoxCategory.Name = "ComboBoxCategory";
			ComboBoxCategory.Size = new Size(232, 23);
			ComboBoxCategory.TabIndex = 13;
			// 
			// CheckBoxFilterCategory
			// 
			CheckBoxFilterCategory.AutoSize = true;
			CheckBoxFilterCategory.Location = new Point(12, 157);
			CheckBoxFilterCategory.Name = "CheckBoxFilterCategory";
			CheckBoxFilterCategory.Size = new Size(77, 19);
			CheckBoxFilterCategory.TabIndex = 12;
			CheckBoxFilterCategory.Text = "Categoría";
			CheckBoxFilterCategory.UseVisualStyleBackColor = true;
			CheckBoxFilterCategory.CheckedChanged += CheckBoxFilterCategory_CheckedChanged;
			// 
			// ComboBoxBirthdayYear
			// 
			ComboBoxBirthdayYear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxBirthdayYear.Enabled = false;
			ComboBoxBirthdayYear.FormattingEnabled = true;
			ComboBoxBirthdayYear.Location = new Point(100, 184);
			ComboBoxBirthdayYear.Name = "ComboBoxBirthdayYear";
			ComboBoxBirthdayYear.Size = new Size(232, 23);
			ComboBoxBirthdayYear.TabIndex = 15;
			// 
			// CheckBoxFilterBirthdayYear
			// 
			CheckBoxFilterBirthdayYear.AutoSize = true;
			CheckBoxFilterBirthdayYear.Location = new Point(12, 186);
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
			ComboBoxBirthdayMonth.Enabled = false;
			ComboBoxBirthdayMonth.FormattingEnabled = true;
			ComboBoxBirthdayMonth.Location = new Point(100, 213);
			ComboBoxBirthdayMonth.Name = "ComboBoxBirthdayMonth";
			ComboBoxBirthdayMonth.Size = new Size(232, 23);
			ComboBoxBirthdayMonth.TabIndex = 17;
			// 
			// CheckBoxFilterBirthdayMonth
			// 
			CheckBoxFilterBirthdayMonth.AutoSize = true;
			CheckBoxFilterBirthdayMonth.Location = new Point(12, 215);
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
			ComboBoxBirthdayDay.Enabled = false;
			ComboBoxBirthdayDay.FormattingEnabled = true;
			ComboBoxBirthdayDay.Location = new Point(100, 242);
			ComboBoxBirthdayDay.Name = "ComboBoxBirthdayDay";
			ComboBoxBirthdayDay.Size = new Size(232, 23);
			ComboBoxBirthdayDay.TabIndex = 19;
			// 
			// CheckBoxFilterBirthdayDay
			// 
			CheckBoxFilterBirthdayDay.AutoSize = true;
			CheckBoxFilterBirthdayDay.Location = new Point(12, 244);
			CheckBoxFilterBirthdayDay.Name = "CheckBoxFilterBirthdayDay";
			CheckBoxFilterBirthdayDay.Size = new Size(70, 19);
			CheckBoxFilterBirthdayDay.TabIndex = 18;
			CheckBoxFilterBirthdayDay.Text = "Día Nac.";
			CheckBoxFilterBirthdayDay.UseVisualStyleBackColor = true;
			CheckBoxFilterBirthdayDay.CheckedChanged += CheckBoxBirthdayDay_CheckedChanged;
			// 
			// FCitizenListFilters
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(344, 311);
			ControlBox = false;
			Controls.Add(ComboBoxBirthdayDay);
			Controls.Add(CheckBoxFilterBirthdayDay);
			Controls.Add(ComboBoxBirthdayMonth);
			Controls.Add(CheckBoxFilterBirthdayMonth);
			Controls.Add(ComboBoxBirthdayYear);
			Controls.Add(CheckBoxFilterBirthdayYear);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Controls.Add(ComboBoxCategory);
			Controls.Add(CheckBoxFilterCategory);
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
			MaximumSize = new Size(380, 370);
			MinimumSize = new Size(360, 350);
			Name = "FCitizenListFilters";
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Filtros";
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
		private ComboBox ComboBoxCategory;
		private CheckBox CheckBoxFilterCategory;
		private ComboBox ComboBoxBirthdayYear;
		private CheckBox CheckBoxFilterBirthdayYear;
		private ComboBox ComboBoxBirthdayMonth;
		private CheckBox CheckBoxFilterBirthdayMonth;
		private ComboBox ComboBoxBirthdayDay;
		private CheckBox CheckBoxFilterBirthdayDay;
	}
}