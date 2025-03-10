namespace GCRM
{
	partial class FEmailData
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
			LEmail = new Label();
			TextBoxName = new TextBox();
			LDomain = new Label();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(237, 51);
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
			BAccept.Location = new Point(159, 51);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 1;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// LEmail
			// 
			LEmail.AutoSize = true;
			LEmail.Location = new Point(12, 12);
			LEmail.Name = "LEmail";
			LEmail.Size = new Size(36, 15);
			LEmail.TabIndex = 5;
			LEmail.Text = "Email";
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(54, 9);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(155, 23);
			TextBoxName.TabIndex = 0;
			// 
			// LDomain
			// 
			LDomain.AutoSize = true;
			LDomain.Location = new Point(215, 12);
			LDomain.Name = "LDomain";
			LDomain.Size = new Size(101, 15);
			LDomain.TabIndex = 7;
			LDomain.Text = "@purelymail.com";
			// 
			// FEmailData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(324, 86);
			ControlBox = false;
			Controls.Add(LDomain);
			Controls.Add(TextBoxName);
			Controls.Add(LEmail);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FEmailData";
			ShowIcon = false;
			Text = "Email - Nuevo";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private Label LEmail;
		private TextBox TextBoxName;
		private Label LDomain;
	}
}