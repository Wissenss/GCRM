namespace GCRM
{
	partial class FInstitutionTemplateRoleData
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
			TextBoxDescription = new TextBox();
			LDescription = new Label();
			TextBoxName = new TextBox();
			LName = new Label();
			BCancel = new Button();
			BAccept = new Button();
			SuspendLayout();
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Location = new Point(88, 41);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(225, 79);
			TextBoxDescription.TabIndex = 10;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(13, 44);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 14;
			LDescription.Text = "Descripción";
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(88, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(225, 23);
			TextBoxName.TabIndex = 9;
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(13, 15);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 13;
			LName.Text = "Nombre";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(238, 131);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 12;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(160, 131);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 11;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// FInstitutionTemplateRoleData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(318, 166);
			ControlBox = false;
			Controls.Add(TextBoxDescription);
			Controls.Add(LDescription);
			Controls.Add(TextBoxName);
			Controls.Add(LName);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FInstitutionTemplateRoleData";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Rol Plantilla - Nuevo";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label LDescription;
		private Label LName;
		private Button BCancel;
		private Button BAccept;
		public TextBox TextBoxDescription;
		public TextBox TextBoxName;
	}
}