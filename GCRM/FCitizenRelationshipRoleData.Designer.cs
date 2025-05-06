namespace GCRM
{
	partial class FCitizenRelationshipRoleData
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
			TBName = new TextBox();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(258, 86);
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
			BAccept.Location = new Point(180, 86);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 3;
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
			LName.TabIndex = 5;
			LName.Text = "Nombre";
			// 
			// TBName
			// 
			TBName.Location = new Point(69, 12);
			TBName.Name = "TBName";
			TBName.Size = new Size(264, 23);
			TBName.TabIndex = 6;
			// 
			// FCitizenRelationshipRoleData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(345, 121);
			ControlBox = false;
			Controls.Add(TBName);
			Controls.Add(LName);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FCitizenRelationshipRoleData";
			Text = "Vínculo relacional";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private Label LName;
		private TextBox TBName;
	}
}