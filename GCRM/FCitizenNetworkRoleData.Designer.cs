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
			TextBoxName = new TextBox();
			LName = new Label();
			TextBoxDescription = new TextBox();
			LDescription = new Label();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(234, 149);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 40;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(156, 149);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 39;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
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
			// TextBoxDescription
			// 
			TextBoxDescription.Location = new Point(87, 41);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(222, 102);
			TextBoxDescription.TabIndex = 44;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(12, 44);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 45;
			LDescription.Text = "Descripción";
			// 
			// FCitizenNetworkRoleData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(321, 184);
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
		private TextBox TextBoxName;
		private Label LName;
		private TextBox TextBoxDescription;
		private Label LDescription;
	}
}