namespace GCRM
{
	partial class FCitizenNetworkMemberData
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
			TextBoxName = new TextBox();
			LCitizen = new Label();
			BSelectLeadCitizen = new Button();
			LRol = new Label();
			ComboBoxRoles = new ComboBox();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(312, 82);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 42;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(234, 82);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 41;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(83, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.ReadOnly = true;
			TextBoxName.Size = new Size(226, 23);
			TextBoxName.TabIndex = 44;
			// 
			// LCitizen
			// 
			LCitizen.AutoSize = true;
			LCitizen.Location = new Point(12, 16);
			LCitizen.Name = "LCitizen";
			LCitizen.Size = new Size(65, 15);
			LCitizen.TabIndex = 45;
			LCitizen.Text = "Ciudadano";
			// 
			// BSelectLeadCitizen
			// 
			BSelectLeadCitizen.Location = new Point(312, 12);
			BSelectLeadCitizen.Name = "BSelectLeadCitizen";
			BSelectLeadCitizen.Size = new Size(75, 23);
			BSelectLeadCitizen.TabIndex = 46;
			BSelectLeadCitizen.Text = "Seleccionar";
			BSelectLeadCitizen.UseVisualStyleBackColor = true;
			BSelectLeadCitizen.Visible = false;
			// 
			// LRol
			// 
			LRol.AutoSize = true;
			LRol.Location = new Point(12, 44);
			LRol.Name = "LRol";
			LRol.Size = new Size(24, 15);
			LRol.TabIndex = 47;
			LRol.Text = "Rol";
			// 
			// ComboBoxRoles
			// 
			ComboBoxRoles.FormattingEnabled = true;
			ComboBoxRoles.Location = new Point(83, 41);
			ComboBoxRoles.Name = "ComboBoxRoles";
			ComboBoxRoles.Size = new Size(226, 23);
			ComboBoxRoles.TabIndex = 48;
			// 
			// FCitizenNetworkMemberData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(399, 117);
			ControlBox = false;
			Controls.Add(ComboBoxRoles);
			Controls.Add(LRol);
			Controls.Add(BSelectLeadCitizen);
			Controls.Add(TextBoxName);
			Controls.Add(LCitizen);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FCitizenNetworkMemberData";
			Text = "Miembro - Nuevo";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private TextBox TextBoxName;
		private Label LCitizen;
		private Button BSelectLeadCitizen;
		private Label LRol;
		private ComboBox ComboBoxRoles;
	}
}