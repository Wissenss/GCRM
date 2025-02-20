namespace GCRM
{
	partial class FAuthorization
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
			LAuthorization = new Label();
			TextBoxAutorizationActions = new TextBox();
			TextBoxPassword = new TextBox();
			TextBoxUser = new TextBox();
			LPassword = new Label();
			LUser = new Label();
			BCancel = new Button();
			BAccept = new Button();
			SuspendLayout();
			// 
			// LAuthorization
			// 
			LAuthorization.AutoSize = true;
			LAuthorization.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			LAuthorization.ForeColor = SystemColors.ControlText;
			LAuthorization.Location = new Point(12, 9);
			LAuthorization.Name = "LAuthorization";
			LAuthorization.Size = new Size(55, 15);
			LAuthorization.TabIndex = 0;
			LAuthorization.Text = "Acciones";
			// 
			// TextBoxAutorizationActions
			// 
			TextBoxAutorizationActions.Location = new Point(12, 27);
			TextBoxAutorizationActions.Multiline = true;
			TextBoxAutorizationActions.Name = "TextBoxAutorizationActions";
			TextBoxAutorizationActions.Size = new Size(232, 96);
			TextBoxAutorizationActions.TabIndex = 1;
			// 
			// TextBoxPassword
			// 
			TextBoxPassword.Location = new Point(12, 194);
			TextBoxPassword.Name = "TextBoxPassword";
			TextBoxPassword.PasswordChar = '*';
			TextBoxPassword.Size = new Size(232, 23);
			TextBoxPassword.TabIndex = 10;
			// 
			// TextBoxUser
			// 
			TextBoxUser.Location = new Point(12, 150);
			TextBoxUser.Name = "TextBoxUser";
			TextBoxUser.Size = new Size(232, 23);
			TextBoxUser.TabIndex = 9;
			// 
			// LPassword
			// 
			LPassword.AutoSize = true;
			LPassword.Location = new Point(12, 176);
			LPassword.Name = "LPassword";
			LPassword.Size = new Size(36, 15);
			LPassword.TabIndex = 12;
			LPassword.Text = "Clave";
			// 
			// LUser
			// 
			LUser.AutoSize = true;
			LUser.Location = new Point(12, 132);
			LUser.Name = "LUser";
			LUser.Size = new Size(47, 15);
			LUser.TabIndex = 11;
			LUser.Text = "Usuario";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(169, 234);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 14;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(91, 234);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 13;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			// 
			// FAuthorization
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(256, 269);
			ControlBox = false;
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(TextBoxPassword);
			Controls.Add(TextBoxUser);
			Controls.Add(LPassword);
			Controls.Add(LUser);
			Controls.Add(TextBoxAutorizationActions);
			Controls.Add(LAuthorization);
			Name = "FAuthorization";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Autorización Requerida";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LAuthorization;
		private TextBox TextBoxAutorizationActions;
		private TextBox TextBoxPassword;
		private TextBox TextBoxUser;
		private Label LPassword;
		private Label LUser;
		private Button BCancel;
		private Button BAccept;
	}
}