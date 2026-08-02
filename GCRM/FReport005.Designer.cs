namespace GCRM
{
    partial class FReport005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReport005));
            BCancel = new Button();
            BSave = new Button();
            Institution = new ComboBox();
            LInstitution = new Label();
            BGenerate = new Button();
            SuspendLayout();
            //
            // BCancel
            //
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(298, 49);
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
            BSave.Location = new Point(12, 49);
            BSave.Name = "BSave";
            BSave.Size = new Size(75, 23);
            BSave.TabIndex = 5;
            BSave.Text = "&Guardar";
            BSave.UseVisualStyleBackColor = true;
            BSave.Visible = false;
            BSave.Click += BSave_Click;
            //
            // Institution
            //
            Institution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Institution.DropDownStyle = ComboBoxStyle.DropDownList;
            Institution.FormattingEnabled = true;
            Institution.Location = new Point(81, 12);
            Institution.Name = "Institution";
            Institution.Size = new Size(292, 23);
            Institution.TabIndex = 10;
            //
            // LInstitution
            //
            LInstitution.AutoSize = true;
            LInstitution.Location = new Point(12, 15);
            LInstitution.Name = "LInstitution";
            LInstitution.Size = new Size(63, 15);
            LInstitution.TabIndex = 11;
            LInstitution.Text = "Institución";
            //
            // BGenerate
            //
            BGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BGenerate.Location = new Point(217, 49);
            BGenerate.Name = "BGenerate";
            BGenerate.Size = new Size(75, 23);
            BGenerate.TabIndex = 3;
            BGenerate.Text = "G&enerar";
            BGenerate.UseVisualStyleBackColor = true;
            BGenerate.Click += BGenerate_Click;
            //
            // FReport005
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 84);
            ControlBox = false;
            Controls.Add(LInstitution);
            Controls.Add(Institution);
            Controls.Add(BCancel);
            Controls.Add(BGenerate);
            Controls.Add(BSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FReport005";
            Text = "005: Institución";
            Load += FReport005_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BSave;
        private ComboBox Institution;
        private Label LInstitution;
        private Button BGenerate;
    }
}