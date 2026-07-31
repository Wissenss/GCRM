namespace GCRM
{
    partial class FReport004
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReport004));
            BCancel = new Button();
            BAccept = new Button();
            BExport = new Button();
            Category = new ComboBox();
            CheckBoxFilterCategory = new CheckBox();
            Sector = new ComboBox();
            CheckBoxFilterSector = new CheckBox();
            SuspendLayout();
            //
            // BCancel
            //
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(298, 76);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 4;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            //
            // BAccept
            //
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(220, 76);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 3;
            BAccept.Text = "&Ver";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            //
            // BExport
            //
            BExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BExport.Location = new Point(142, 76);
            BExport.Name = "BExport";
            BExport.Size = new Size(75, 23);
            BExport.TabIndex = 14;
            BExport.Text = "&Guardar";
            BExport.UseVisualStyleBackColor = true;
            BExport.Click += BExport_Click;
            //
            // Category
            //
            Category.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Category.DropDownStyle = ComboBoxStyle.DropDownList;
            Category.Enabled = false;
            Category.FormattingEnabled = true;
            Category.Location = new Point(95, 12);
            Category.Name = "Category";
            Category.Size = new Size(278, 23);
            Category.TabIndex = 10;
            //
            // CheckBoxFilterCategory
            //
            CheckBoxFilterCategory.AutoSize = true;
            CheckBoxFilterCategory.Location = new Point(12, 14);
            CheckBoxFilterCategory.Name = "CheckBoxFilterCategory";
            CheckBoxFilterCategory.Size = new Size(77, 19);
            CheckBoxFilterCategory.TabIndex = 11;
            CheckBoxFilterCategory.Text = "Categoría";
            CheckBoxFilterCategory.UseVisualStyleBackColor = true;
            CheckBoxFilterCategory.CheckedChanged += CheckBoxFilterCategory_CheckedChanged;
            //
            // Sector
            //
            Sector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Sector.DropDownStyle = ComboBoxStyle.DropDownList;
            Sector.Enabled = false;
            Sector.FormattingEnabled = true;
            Sector.Location = new Point(95, 41);
            Sector.Name = "Sector";
            Sector.Size = new Size(278, 23);
            Sector.TabIndex = 12;
            //
            // CheckBoxFilterSector
            //
            CheckBoxFilterSector.AutoSize = true;
            CheckBoxFilterSector.Location = new Point(12, 43);
            CheckBoxFilterSector.Name = "CheckBoxFilterSector";
            CheckBoxFilterSector.Size = new Size(59, 19);
            CheckBoxFilterSector.TabIndex = 13;
            CheckBoxFilterSector.Text = "Sector";
            CheckBoxFilterSector.UseVisualStyleBackColor = true;
            CheckBoxFilterSector.CheckedChanged += CheckBoxFilterSector_CheckedChanged;
            //
            // FReport004
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 111);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Controls.Add(CheckBoxFilterSector);
            Controls.Add(Sector);
            Controls.Add(CheckBoxFilterCategory);
            Controls.Add(Category);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            Controls.Add(BExport);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FReport004";
            Text = "004: Catálogo de instituciones";
            Load += FReport004_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BAccept;
        private Button BExport;
        private ComboBox Category;
        private CheckBox CheckBoxFilterCategory;
        private ComboBox Sector;
        private CheckBox CheckBoxFilterSector;
    }
}
