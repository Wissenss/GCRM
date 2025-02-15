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
			ComboBoxPoliticalParty.Enabled = false;
			ComboBoxPoliticalParty.FormattingEnabled = true;
			ComboBoxPoliticalParty.Location = new Point(100, 10);
			ComboBoxPoliticalParty.Name = "ComboBoxPoliticalParty";
			ComboBoxPoliticalParty.Size = new Size(172, 23);
			ComboBoxPoliticalParty.TabIndex = 1;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(197, 206);
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
			BAccept.Location = new Point(116, 206);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 2;
			BAccept.Text = "&Aplicar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// ComboBoxSex
			// 
			ComboBoxSex.Enabled = false;
			ComboBoxSex.FormattingEnabled = true;
			ComboBoxSex.Location = new Point(100, 39);
			ComboBoxSex.Name = "ComboBoxSex";
			ComboBoxSex.Size = new Size(172, 23);
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
			ComboBoxCitizenTitle.Enabled = false;
			ComboBoxCitizenTitle.FormattingEnabled = true;
			ComboBoxCitizenTitle.Location = new Point(100, 68);
			ComboBoxCitizenTitle.Name = "ComboBoxCitizenTitle";
			ComboBoxCitizenTitle.Size = new Size(172, 23);
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
			ComboBoxInstitucion.Enabled = false;
			ComboBoxInstitucion.FormattingEnabled = true;
			ComboBoxInstitucion.Location = new Point(100, 97);
			ComboBoxInstitucion.Name = "ComboBoxInstitucion";
			ComboBoxInstitucion.Size = new Size(172, 23);
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
			ComboBoxSector.Enabled = false;
			ComboBoxSector.FormattingEnabled = true;
			ComboBoxSector.Location = new Point(100, 126);
			ComboBoxSector.Name = "ComboBoxSector";
			ComboBoxSector.Size = new Size(172, 23);
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
			ComboBoxCategory.Enabled = false;
			ComboBoxCategory.FormattingEnabled = true;
			ComboBoxCategory.Location = new Point(100, 155);
			ComboBoxCategory.Name = "ComboBoxCategory";
			ComboBoxCategory.Size = new Size(172, 23);
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
			// FCitizenListFilters
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(284, 241);
			ControlBox = false;
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
			MaximumSize = new Size(300, 280);
			MinimumSize = new Size(300, 280);
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
	}
}