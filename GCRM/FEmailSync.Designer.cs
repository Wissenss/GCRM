namespace GCRM
{
	partial class FEmailSync
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
			LCardDavURL = new Label();
			TextBoxCardDavURL = new TextBox();
			BCancel = new Button();
			BAccept = new Button();
			LUser = new Label();
			LPassword = new Label();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			SuspendLayout();
			// 
			// LCardDavURL
			// 
			LCardDavURL.AutoSize = true;
			LCardDavURL.Location = new Point(12, 15);
			LCardDavURL.Name = "LCardDavURL";
			LCardDavURL.Size = new Size(76, 15);
			LCardDavURL.TabIndex = 0;
			LCardDavURL.Text = "CardDav URL";
			// 
			// TextBoxCardDavURL
			// 
			TextBoxCardDavURL.Location = new Point(94, 12);
			TextBoxCardDavURL.Name = "TextBoxCardDavURL";
			TextBoxCardDavURL.Size = new Size(259, 23);
			TextBoxCardDavURL.TabIndex = 1;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(278, 110);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 6;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(183, 110);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(89, 23);
			BAccept.TabIndex = 5;
			BAccept.Text = "&Syncronizar";
			BAccept.UseVisualStyleBackColor = true;
			// 
			// LUser
			// 
			LUser.AutoSize = true;
			LUser.Location = new Point(12, 44);
			LUser.Name = "LUser";
			LUser.Size = new Size(47, 15);
			LUser.TabIndex = 7;
			LUser.Text = "Usuario";
			// 
			// LPassword
			// 
			LPassword.AutoSize = true;
			LPassword.Location = new Point(12, 73);
			LPassword.Name = "LPassword";
			LPassword.Size = new Size(67, 15);
			LPassword.TabIndex = 8;
			LPassword.Text = "Contraseña";
			LPassword.Click += AppPassword_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(94, 41);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(259, 23);
			textBox1.TabIndex = 9;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(94, 70);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(259, 23);
			textBox2.TabIndex = 10;
			// 
			// FEmailSync
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(365, 145);
			ControlBox = false;
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(LPassword);
			Controls.Add(LUser);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(TextBoxCardDavURL);
			Controls.Add(LCardDavURL);
			Name = "FEmailSync";
			Text = "Syncronizar Email";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LCardDavURL;
		private TextBox TextBoxCardDavURL;
		public Button BCancel;
		public Button BAccept;
		private Label LUser;
		private Label LPassword;
		private TextBox textBox1;
		private TextBox textBox2;
	}
}