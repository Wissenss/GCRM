namespace GCRM
{
    partial class FReport006
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReport006));
            BCancel = new Button();
            BSave = new Button();
            Citizen = new ComboBox();
            LCitizen = new Label();
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
            // Citizen
            // 
            Citizen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Citizen.DropDownStyle = ComboBoxStyle.DropDownList;
            Citizen.FormattingEnabled = true;
            Citizen.Location = new Point(81, 12);
            Citizen.Name = "Citizen";
            Citizen.Size = new Size(292, 23);
            Citizen.TabIndex = 10;
            // 
            // LCitizen
            // 
            LCitizen.AutoSize = true;
            LCitizen.Location = new Point(12, 15);
            LCitizen.Name = "LCitizen";
            LCitizen.Size = new Size(65, 15);
            LCitizen.TabIndex = 11;
            LCitizen.Text = "Ciudadano";
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
            // FReport006
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(385, 84);
            ControlBox = false;
            Controls.Add(LCitizen);
            Controls.Add(Citizen);
            Controls.Add(BCancel);
            Controls.Add(BGenerate);
            Controls.Add(BSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FReport006";
            Text = "006: Ciudadano";
            Load += FReport006_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BSave;
        private ComboBox Citizen;
        private Label LCitizen;
        private Button BGenerate;
    }
}
