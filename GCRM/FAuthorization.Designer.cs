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
			TextBoxPassword = new TextBox();
			TextBoxUser = new TextBox();
			LPassword = new Label();
			LUser = new Label();
			BCancel = new Button();
			BAccept = new Button();
			ListBoxAuthorizatinActions = new ListBox();
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
			// TextBoxPassword
			// 
			TextBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxPassword.Location = new Point(12, 222);
			TextBoxPassword.Name = "TextBoxPassword";
			TextBoxPassword.PasswordChar = '*';
			TextBoxPassword.Size = new Size(240, 23);
			TextBoxPassword.TabIndex = 2;
			// 
			// TextBoxUser
			// 
			TextBoxUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxUser.Location = new Point(12, 178);
			TextBoxUser.Name = "TextBoxUser";
			TextBoxUser.Size = new Size(240, 23);
			TextBoxUser.TabIndex = 1;
			// 
			// LPassword
			// 
			LPassword.AutoSize = true;
			LPassword.Location = new Point(12, 204);
			LPassword.Name = "LPassword";
			LPassword.Size = new Size(36, 15);
			LPassword.TabIndex = 12;
			LPassword.Text = "Clave";
			// 
			// LUser
			// 
			LUser.AutoSize = true;
			LUser.Location = new Point(12, 160);
			LUser.Name = "LUser";
			LUser.Size = new Size(47, 15);
			LUser.TabIndex = 11;
			LUser.Text = "Usuario";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(177, 256);
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
			BAccept.Location = new Point(99, 256);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 3;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// ListBoxAuthorizatinActions
			// 
			ListBoxAuthorizatinActions.Enabled = false;
			ListBoxAuthorizatinActions.FormattingEnabled = true;
			ListBoxAuthorizatinActions.ItemHeight = 15;
			ListBoxAuthorizatinActions.Location = new Point(12, 27);
			ListBoxAuthorizatinActions.Name = "ListBoxAuthorizatinActions";
			ListBoxAuthorizatinActions.Size = new Size(240, 124);
			ListBoxAuthorizatinActions.TabIndex = 14;
			// 
			// FAuthorization
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(264, 291);
			ControlBox = false;
			Controls.Add(ListBoxAuthorizatinActions);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(TextBoxPassword);
			Controls.Add(TextBoxUser);
			Controls.Add(LPassword);
			Controls.Add(LUser);
			Controls.Add(LAuthorization);
			MaximumSize = new Size(300, 330);
			MinimumSize = new Size(280, 310);
			Name = "FAuthorization";
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "Autorización Requerida";
			Load += FAuthorization_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LAuthorization;
		private TextBox TextBoxPassword;
		private TextBox TextBoxUser;
		private Label LPassword;
		private Label LUser;
		private Button BCancel;
		private Button BAccept;
		private ListBox ListBoxAuthorizatinActions;
	}
}