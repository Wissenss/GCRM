namespace GCRM
{
	partial class FLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));
			BAccept = new Button();
			LUser = new Label();
			LPassword = new Label();
			TextBoxUser = new TextBox();
			TextBoxPassword = new TextBox();
			BCancel = new Button();
			LStatus = new Label();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(91, 94);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 2;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// LUser
			// 
			LUser.AutoSize = true;
			LUser.Location = new Point(12, 36);
			LUser.Name = "LUser";
			LUser.Size = new Size(47, 15);
			LUser.TabIndex = 4;
			LUser.Text = "Usuario";
			// 
			// LPassword
			// 
			LPassword.AutoSize = true;
			LPassword.Location = new Point(12, 65);
			LPassword.Name = "LPassword";
			LPassword.Size = new Size(36, 15);
			LPassword.TabIndex = 5;
			LPassword.Text = "Clave";
			// 
			// TextBoxUser
			// 
			TextBoxUser.Location = new Point(65, 33);
			TextBoxUser.Name = "TextBoxUser";
			TextBoxUser.Size = new Size(179, 23);
			TextBoxUser.TabIndex = 0;
			TextBoxUser.KeyDown += TextBoxUser_KeyDown;
			// 
			// TextBoxPassword
			// 
			TextBoxPassword.Location = new Point(65, 62);
			TextBoxPassword.Name = "TextBoxPassword";
			TextBoxPassword.PasswordChar = '*';
			TextBoxPassword.Size = new Size(179, 23);
			TextBoxPassword.TabIndex = 1;
			TextBoxPassword.KeyDown += TextBoxPassword_KeyDown;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(169, 94);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 3;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// LStatus
			// 
			LStatus.AutoSize = true;
			LStatus.Location = new Point(44, 9);
			LStatus.Name = "LStatus";
			LStatus.Size = new Size(172, 15);
			LStatus.TabIndex = 8;
			LStatus.Text = "Ingrese su usuario y contraseña";
			// 
			// FLogin
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(256, 129);
			ControlBox = false;
			Controls.Add(LStatus);
			Controls.Add(TextBoxPassword);
			Controls.Add(TextBoxUser);
			Controls.Add(LPassword);
			Controls.Add(LUser);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FLogin";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Iniciar Sesión";
			Load += FLogin_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button BAccept;
		private Label LUser;
		private Label LPassword;
		private TextBox TextBoxUser;
		private TextBox TextBoxPassword;
		private Button BCancel;
		private Label LStatus;
	}
}