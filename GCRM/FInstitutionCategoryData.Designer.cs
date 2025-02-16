namespace GCRM
{
	partial class FInstitutionCategoryData
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
			TextBoxDescription = new TextBox();
			LDescription = new Label();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(237, 126);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 3;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(159, 126);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 2;
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
			LName.TabIndex = 4;
			LName.Text = "Nombre";
			// 
			// TextBoxName
			// 
			TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxName.Location = new Point(87, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(225, 23);
			TextBoxName.TabIndex = 0;
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxDescription.Location = new Point(87, 41);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(225, 75);
			TextBoxDescription.TabIndex = 1;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(12, 44);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 6;
			LDescription.Text = "Descripción";
			// 
			// FInstitutionCategoryData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(324, 161);
			ControlBox = false;
			Controls.Add(TextBoxDescription);
			Controls.Add(LDescription);
			Controls.Add(TextBoxName);
			Controls.Add(LName);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			MaximumSize = new Size(360, 220);
			Name = "FInstitutionCategoryData";
			ShowIcon = false;
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "Categoría - Nueva";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private Label LName;
		private TextBox TextBoxName;
		private TextBox TextBoxDescription;
		private Label LDescription;
	}
}