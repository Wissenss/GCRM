namespace GCRM
{
	partial class FInstitutionListFilters
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
			ComboBoxCategory = new ComboBox();
			CheckBoxFilterCategory = new CheckBox();
			ComboBoxSector = new ComboBox();
			CheckBoxFilterSector = new CheckBox();
			BAccept = new Button();
			BCancel = new Button();
			SuspendLayout();
			// 
			// ComboBoxCategory
			// 
			ComboBoxCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxCategory.Enabled = false;
			ComboBoxCategory.FormattingEnabled = true;
			ComboBoxCategory.Location = new Point(95, 12);
			ComboBoxCategory.Name = "ComboBoxCategory";
			ComboBoxCategory.Size = new Size(269, 23);
			ComboBoxCategory.TabIndex = 25;
			// 
			// CheckBoxFilterCategory
			// 
			CheckBoxFilterCategory.AutoSize = true;
			CheckBoxFilterCategory.Location = new Point(12, 14);
			CheckBoxFilterCategory.Name = "CheckBoxFilterCategory";
			CheckBoxFilterCategory.Size = new Size(77, 19);
			CheckBoxFilterCategory.TabIndex = 24;
			CheckBoxFilterCategory.Text = "Categoría";
			CheckBoxFilterCategory.UseVisualStyleBackColor = true;
			CheckBoxFilterCategory.CheckedChanged += CheckBoxFilterCategory_CheckedChanged;
			// 
			// ComboBoxSector
			// 
			ComboBoxSector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxSector.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxSector.Enabled = false;
			ComboBoxSector.FormattingEnabled = true;
			ComboBoxSector.Location = new Point(95, 41);
			ComboBoxSector.Name = "ComboBoxSector";
			ComboBoxSector.Size = new Size(269, 23);
			ComboBoxSector.TabIndex = 23;
			// 
			// CheckBoxFilterSector
			// 
			CheckBoxFilterSector.AutoSize = true;
			CheckBoxFilterSector.Location = new Point(12, 43);
			CheckBoxFilterSector.Name = "CheckBoxFilterSector";
			CheckBoxFilterSector.Size = new Size(59, 19);
			CheckBoxFilterSector.TabIndex = 22;
			CheckBoxFilterSector.Text = "Sector";
			CheckBoxFilterSector.UseVisualStyleBackColor = true;
			CheckBoxFilterSector.CheckedChanged += CheckBoxFilterSector_CheckedChanged;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(208, 77);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 26;
			BAccept.Text = "&Aplicar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(289, 77);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 27;
			BCancel.Text = "&Cerrar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// FInstitutionListFilters
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(376, 112);
			ControlBox = false;
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Controls.Add(ComboBoxCategory);
			Controls.Add(CheckBoxFilterCategory);
			Controls.Add(ComboBoxSector);
			Controls.Add(CheckBoxFilterSector);
			Name = "FInstitutionListFilters";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Filtros";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox ComboBoxCategory;
		private CheckBox CheckBoxFilterCategory;
		private ComboBox ComboBoxSector;
		private CheckBox CheckBoxFilterSector;
		private Button BAccept;
		private Button BCancel;
	}
}