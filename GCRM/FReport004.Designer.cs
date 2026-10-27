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
            BSave = new Button();
            Category = new ComboBox();
            CheckBoxFilterCategory = new CheckBox();
            Sector = new ComboBox();
            CheckBoxFilterSector = new CheckBox();
            BGenerate = new Button();
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
            // BSave
            //
            BSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BSave.Location = new Point(12, 76);
            BSave.Name = "BSave";
            BSave.Size = new Size(75, 23);
            BSave.TabIndex = 14;
            BSave.Text = "&Guardar";
            BSave.UseVisualStyleBackColor = true;
            BSave.Visible = false;
            BSave.Click += BSave_Click;
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
            // BGenerate
            //
            BGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BGenerate.Location = new Point(217, 76);
            BGenerate.Name = "BGenerate";
            BGenerate.Size = new Size(75, 23);
            BGenerate.TabIndex = 3;
            BGenerate.Text = "G&enerar";
            BGenerate.UseVisualStyleBackColor = true;
            BGenerate.Click += BGenerate_Click;
            //
            // FReport004
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(385, 111);
            ControlBox = false;
            Controls.Add(CheckBoxFilterSector);
            Controls.Add(Sector);
            Controls.Add(CheckBoxFilterCategory);
            Controls.Add(Category);
            Controls.Add(BCancel);
            Controls.Add(BGenerate);
            Controls.Add(BSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FReport004";
            Text = "004: Catálogo de instituciones";
            Load += FReport004_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BSave;
        private ComboBox Category;
        private CheckBox CheckBoxFilterCategory;
        private ComboBox Sector;
        private CheckBox CheckBoxFilterSector;
        private Button BGenerate;
    }
}
