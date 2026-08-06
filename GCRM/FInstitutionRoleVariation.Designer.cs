namespace GCRM
{
	partial class FInstitutionRoleVariation
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
            LName = new Label();
            TextBoxName = new TextBox();
            SuspendLayout();
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(237, 41);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 2;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(159, 41);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 1;
            BAccept.Text = "&Aceptar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // LName
            // 
            LName.AutoSize = true;
            LName.Location = new Point(12, 15);
            LName.Name = "LName";
            LName.Size = new Size(51, 15);
            LName.TabIndex = 3;
            LName.Text = "Nombre";
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(87, 12);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(225, 23);
            TextBoxName.TabIndex = 0;
            // 
            // FInstitutionRoleVariation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 76);
            ControlBox = false;
            Controls.Add(TextBoxName);
            Controls.Add(LName);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            Name = "FInstitutionRoleVariation";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Variante - Nueva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
		private Button BAccept;
		private Label LName;
		private TextBox TextBoxName;
	}
}
