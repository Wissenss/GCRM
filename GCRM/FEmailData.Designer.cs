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
			LUser = new Label();
			TextBoxName = new TextBox();
			ComboBoxDomains = new ComboBox();
			LDomain = new Label();
			LFullEmail = new Label();
			TextBoxPassword = new TextBox();
			LPassword = new Label();
			AllowPasswordReset = new CheckBox();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(253, 170);
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
			BAccept.Location = new Point(175, 170);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 3;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// LUser
			// 
			LUser.AutoSize = true;
			LUser.Location = new Point(12, 12);
			LUser.Name = "LUser";
			LUser.Size = new Size(47, 15);
			LUser.TabIndex = 5;
			LUser.Text = "Usuario";
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(85, 9);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(243, 23);
			TextBoxName.TabIndex = 0;
			TextBoxName.TextChanged += TextBoxName_TextChanged;
			// 
			// ComboBoxDomains
			// 
			ComboBoxDomains.FormattingEnabled = true;
			ComboBoxDomains.Location = new Point(85, 38);
			ComboBoxDomains.Name = "ComboBoxDomains";
			ComboBoxDomains.Size = new Size(243, 23);
			ComboBoxDomains.TabIndex = 1;
			ComboBoxDomains.TextChanged += ComboBoxDomains_TextChanged;
			// 
			// LDomain
			// 
			LDomain.AutoSize = true;
			LDomain.Location = new Point(12, 41);
			LDomain.Name = "LDomain";
			LDomain.Size = new Size(53, 15);
			LDomain.TabIndex = 7;
			LDomain.Text = "Dominio";
			// 
			// LFullEmail
			// 
			LFullEmail.AutoSize = true;
			LFullEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LFullEmail.ForeColor = SystemColors.HotTrack;
			LFullEmail.Location = new Point(85, 71);
			LFullEmail.Name = "LFullEmail";
			LFullEmail.Size = new Size(130, 15);
			LFullEmail.TabIndex = 8;
			LFullEmail.Text = "usuario@dominio.com";
			// 
			// TextBoxPassword
			// 
			TextBoxPassword.Enabled = false;
			TextBoxPassword.Location = new Point(85, 98);
			TextBoxPassword.Name = "TextBoxPassword";
			TextBoxPassword.Size = new Size(243, 23);
			TextBoxPassword.TabIndex = 2;
			TextBoxPassword.Text = "cambiame2025";
			// 
			// LPassword
			// 
			LPassword.AutoSize = true;
			LPassword.Location = new Point(12, 101);
			LPassword.Name = "LPassword";
			LPassword.Size = new Size(67, 15);
			LPassword.TabIndex = 10;
			LPassword.Text = "Contraseña";
			// 
			// AllowPasswordReset
			// 
			AllowPasswordReset.AutoSize = true;
			AllowPasswordReset.Enabled = false;
			AllowPasswordReset.Location = new Point(85, 127);
			AllowPasswordReset.Name = "AllowPasswordReset";
			AllowPasswordReset.Size = new Size(175, 19);
			AllowPasswordReset.TabIndex = 11;
			AllowPasswordReset.Text = "Permitir cambiar contraseña";
			AllowPasswordReset.UseVisualStyleBackColor = true;
			// 
			// FEmailData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(340, 205);
			ControlBox = false;
			Controls.Add(AllowPasswordReset);
			Controls.Add(TextBoxPassword);
			Controls.Add(LPassword);
			Controls.Add(LFullEmail);
			Controls.Add(LDomain);
			Controls.Add(ComboBoxDomains);
			Controls.Add(TextBoxName);
			Controls.Add(LUser);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FEmailData";
			ShowIcon = false;
			Text = "Email - Nuevo";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Button BCancel;
		public Button BAccept;
		public Label LUser;
		public TextBox TextBoxName;
		public ComboBox ComboBoxDomains;
		private ComboBox comboBox1;
		public Label LDomain;
		public Label LFullEmail;
		public TextBox TextBoxPassword;
		public Label LPassword;
		private CheckBox AllowPasswordReset;
	}
}