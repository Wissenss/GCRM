namespace GCRM
{
	partial class FCitizenCategoryData
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
			LName = new Label();
			TextBoxName = new TextBox();
			TextBoxDescription = new TextBox();
			LDescription = new Label();
			BCancel = new Button();
			BAccept = new Button();
			SuspendLayout();
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(12, 22);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 0;
			LName.Text = "Nombre";
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(87, 19);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(223, 23);
			TextBoxName.TabIndex = 1;
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Location = new Point(87, 48);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(223, 86);
			TextBoxDescription.TabIndex = 3;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(12, 51);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 2;
			LDescription.Text = "Descripción";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(235, 140);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 5;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(157, 140);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 4;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// FCitizenCategoryData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(322, 175);
			ControlBox = false;
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(TextBoxDescription);
			Controls.Add(LDescription);
			Controls.Add(TextBoxName);
			Controls.Add(LName);
			Name = "FCitizenCategoryData";
			Text = "Categoría - Nueva";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LName;
		private TextBox TextBoxName;
		private TextBox TextBoxDescription;
		private Label LDescription;
		private Button BCancel;
		private Button BAccept;
	}
}