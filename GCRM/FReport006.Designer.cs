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
            BAccept = new Button();
            Citizen = new ComboBox();
            LCitizen = new Label();
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
            // BAccept
            //
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(220, 49);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 3;
            BAccept.Text = "&Generar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
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
            LCitizen.Size = new Size(63, 15);
            LCitizen.TabIndex = 11;
            LCitizen.Text = "Ciudadano";
            //
            // FReport006
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 84);
            ControlBox = false;
            Controls.Add(LCitizen);
            Controls.Add(Citizen);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FReport006";
            Text = "006: Ciudadano";
            Load += FReport006_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BAccept;
        private ComboBox Citizen;
        private Label LCitizen;
    }
}
