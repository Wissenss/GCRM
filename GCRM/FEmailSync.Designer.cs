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
			BSync = new Button();
			LUser = new Label();
			LPassword = new Label();
			TextBoxUsername = new TextBox();
			TextBoxPassword = new TextBox();
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
			TextBoxCardDavURL.Size = new Size(273, 23);
			TextBoxCardDavURL.TabIndex = 1;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(292, 105);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 6;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BSync
			// 
			BSync.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BSync.Location = new Point(197, 105);
			BSync.Name = "BSync";
			BSync.Size = new Size(89, 23);
			BSync.TabIndex = 5;
			BSync.Text = "&Syncronizar";
			BSync.UseVisualStyleBackColor = true;
			BSync.Click += BSync_Click;
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
			// 
			// TextBoxUsername
			// 
			TextBoxUsername.Location = new Point(94, 41);
			TextBoxUsername.Name = "TextBoxUsername";
			TextBoxUsername.Size = new Size(273, 23);
			TextBoxUsername.TabIndex = 9;
			// 
			// TextBoxPassword
			// 
			TextBoxPassword.Location = new Point(94, 70);
			TextBoxPassword.Name = "TextBoxPassword";
			TextBoxPassword.Size = new Size(273, 23);
			TextBoxPassword.TabIndex = 10;
			// 
			// FEmailSync
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(379, 140);
			ControlBox = false;
			Controls.Add(TextBoxPassword);
			Controls.Add(TextBoxUsername);
			Controls.Add(LPassword);
			Controls.Add(LUser);
			Controls.Add(BCancel);
			Controls.Add(BSync);
			Controls.Add(TextBoxCardDavURL);
			Controls.Add(LCardDavURL);
			Name = "FEmailSync";
			Text = "Sincronizar Email";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LCardDavURL;
		public Button BCancel;
		public Button BSync;
		private Label LUser;
		private Label LPassword;
		public TextBox TextBoxCardDavURL;
		public TextBox TextBoxUsername;
		public TextBox TextBoxPassword;
	}
}