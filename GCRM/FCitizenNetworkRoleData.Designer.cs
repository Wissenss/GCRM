namespace GCRM
{
	partial class FCitizenNetworkRoleData
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
			TextBoxDescription = new TextBox();
			LDescription = new Label();
			TextBoxName = new TextBox();
			LName = new Label();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(234, 132);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 40;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(156, 132);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 39;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Location = new Point(87, 41);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(222, 79);
			TextBoxDescription.TabIndex = 42;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(12, 44);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 44;
			LDescription.Text = "Descripción";
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(87, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(222, 23);
			TextBoxName.TabIndex = 41;
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(12, 15);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 43;
			LName.Text = "Nombre";
			// 
			// FCitizenNetworkRoleData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(321, 167);
			ControlBox = false;
			Controls.Add(TextBoxDescription);
			Controls.Add(LDescription);
			Controls.Add(TextBoxName);
			Controls.Add(LName);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FCitizenNetworkRoleData";
			ShowIcon = false;
			Text = "Rol - Nuevo";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private TextBox TextBoxDescription;
		private Label LDescription;
		private TextBox TextBoxName;
		private Label LName;
	}
}