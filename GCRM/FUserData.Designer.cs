namespace GCRM
{
	partial class FUserData
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUserData));
			BCancel = new Button();
			BAccept = new Button();
			TextBoxName = new TextBox();
			LName = new Label();
			TextBoxUsername = new TextBox();
			LUsername = new Label();
			TextBoxPassword = new TextBox();
			LPassword = new Label();
			TabControlUser = new TabControl();
			TabGeneral = new TabPage();
			TabPermissions = new TabPage();
			DataGridUserPermissions = new DataGridView();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colPermited = new DataGridViewCheckBoxColumn();
			TabCarddav = new TabPage();
			CarddavPassword = new TextBox();
			LCardDavPassword = new Label();
			CarddavUsername = new TextBox();
			LCardDavUsername = new Label();
			CardDavURL = new TextBox();
			LCardDavUrl = new Label();
			CarddavSyncEnabled = new CheckBox();
			TabControlUser.SuspendLayout();
			TabGeneral.SuspendLayout();
			TabPermissions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridUserPermissions).BeginInit();
			TabCarddav.SuspendLayout();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(272, 202);
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
			BAccept.Location = new Point(194, 202);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 4;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// TextBoxName
			// 
			TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxName.Location = new Point(65, 6);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(278, 23);
			TextBoxName.TabIndex = 7;
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(8, 9);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 6;
			LName.Text = "Nombre";
			// 
			// TextBoxUsername
			// 
			TextBoxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxUsername.Location = new Point(65, 35);
			TextBoxUsername.Name = "TextBoxUsername";
			TextBoxUsername.Size = new Size(278, 23);
			TextBoxUsername.TabIndex = 9;
			TextBoxUsername.TextChanged += TextBoxUsername_TextChanged;
			// 
			// LUsername
			// 
			LUsername.AutoSize = true;
			LUsername.Location = new Point(8, 38);
			LUsername.Name = "LUsername";
			LUsername.Size = new Size(47, 15);
			LUsername.TabIndex = 8;
			LUsername.Text = "Usuario";
			// 
			// TextBoxPassword
			// 
			TextBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxPassword.Location = new Point(65, 64);
			TextBoxPassword.Name = "TextBoxPassword";
			TextBoxPassword.PasswordChar = '*';
			TextBoxPassword.Size = new Size(278, 23);
			TextBoxPassword.TabIndex = 11;
			TextBoxPassword.Enter += TextBoxPassword_Enter;
			// 
			// LPassword
			// 
			LPassword.AutoSize = true;
			LPassword.Location = new Point(8, 67);
			LPassword.Name = "LPassword";
			LPassword.Size = new Size(36, 15);
			LPassword.TabIndex = 10;
			LPassword.Text = "Clave";
			// 
			// TabControlUser
			// 
			TabControlUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlUser.Controls.Add(TabGeneral);
			TabControlUser.Controls.Add(TabPermissions);
			TabControlUser.Controls.Add(TabCarddav);
			TabControlUser.Location = new Point(1, 1);
			TabControlUser.Name = "TabControlUser";
			TabControlUser.SelectedIndex = 0;
			TabControlUser.Size = new Size(357, 195);
			TabControlUser.TabIndex = 12;
			// 
			// TabGeneral
			// 
			TabGeneral.Controls.Add(TextBoxName);
			TabGeneral.Controls.Add(TextBoxPassword);
			TabGeneral.Controls.Add(LName);
			TabGeneral.Controls.Add(LPassword);
			TabGeneral.Controls.Add(LUsername);
			TabGeneral.Controls.Add(TextBoxUsername);
			TabGeneral.Location = new Point(4, 24);
			TabGeneral.Name = "TabGeneral";
			TabGeneral.Padding = new Padding(3);
			TabGeneral.Size = new Size(349, 167);
			TabGeneral.TabIndex = 0;
			TabGeneral.Text = "General";
			TabGeneral.UseVisualStyleBackColor = true;
			// 
			// TabPermissions
			// 
			TabPermissions.Controls.Add(DataGridUserPermissions);
			TabPermissions.Location = new Point(4, 24);
			TabPermissions.Name = "TabPermissions";
			TabPermissions.Padding = new Padding(3);
			TabPermissions.Size = new Size(349, 167);
			TabPermissions.TabIndex = 1;
			TabPermissions.Text = "Permisos";
			TabPermissions.UseVisualStyleBackColor = true;
			// 
			// DataGridUserPermissions
			// 
			DataGridUserPermissions.AllowUserToAddRows = false;
			DataGridUserPermissions.AllowUserToDeleteRows = false;
			DataGridUserPermissions.AllowUserToOrderColumns = true;
			DataGridUserPermissions.AllowUserToResizeRows = false;
			DataGridUserPermissions.BackgroundColor = SystemColors.Control;
			DataGridUserPermissions.BorderStyle = BorderStyle.None;
			DataGridUserPermissions.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridUserPermissions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			DataGridUserPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			DataGridUserPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridUserPermissions.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPermited });
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			DataGridUserPermissions.DefaultCellStyle = dataGridViewCellStyle2;
			DataGridUserPermissions.Dock = DockStyle.Fill;
			DataGridUserPermissions.EditMode = DataGridViewEditMode.EditProgrammatically;
			DataGridUserPermissions.EnableHeadersVisualStyles = false;
			DataGridUserPermissions.Location = new Point(3, 3);
			DataGridUserPermissions.MultiSelect = false;
			DataGridUserPermissions.Name = "DataGridUserPermissions";
			DataGridUserPermissions.RowHeadersVisible = false;
			DataGridUserPermissions.RowTemplate.Height = 20;
			DataGridUserPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridUserPermissions.Size = new Size(343, 161);
			DataGridUserPermissions.StandardTab = true;
			DataGridUserPermissions.TabIndex = 2;
			DataGridUserPermissions.Click += DataGridUserPermissions_Click;
			// 
			// colId
			// 
			colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colId.DataPropertyName = "id";
			colId.HeaderText = "Id";
			colId.Name = "colId";
			colId.Width = 41;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colName.DataPropertyName = "name";
			colName.HeaderText = "Nombre";
			colName.Name = "colName";
			// 
			// colPermited
			// 
			colPermited.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colPermited.DataPropertyName = "permitted";
			colPermited.HeaderText = "Permitido";
			colPermited.Name = "colPermited";
			colPermited.Width = 64;
			// 
			// TabCarddav
			// 
			TabCarddav.Controls.Add(CarddavPassword);
			TabCarddav.Controls.Add(LCardDavPassword);
			TabCarddav.Controls.Add(CarddavUsername);
			TabCarddav.Controls.Add(LCardDavUsername);
			TabCarddav.Controls.Add(CardDavURL);
			TabCarddav.Controls.Add(LCardDavUrl);
			TabCarddav.Controls.Add(CarddavSyncEnabled);
			TabCarddav.Location = new Point(4, 24);
			TabCarddav.Name = "TabCarddav";
			TabCarddav.Padding = new Padding(3);
			TabCarddav.Size = new Size(349, 167);
			TabCarddav.TabIndex = 2;
			TabCarddav.Text = "CardDav";
			TabCarddav.UseVisualStyleBackColor = true;
			// 
			// CarddavPassword
			// 
			CarddavPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			CarddavPassword.Enabled = false;
			CarddavPassword.Location = new Point(89, 89);
			CarddavPassword.Name = "CarddavPassword";
			CarddavPassword.Size = new Size(253, 23);
			CarddavPassword.TabIndex = 13;
			// 
			// LCardDavPassword
			// 
			LCardDavPassword.AutoSize = true;
			LCardDavPassword.Enabled = false;
			LCardDavPassword.Location = new Point(7, 92);
			LCardDavPassword.Name = "LCardDavPassword";
			LCardDavPassword.Size = new Size(67, 15);
			LCardDavPassword.TabIndex = 12;
			LCardDavPassword.Text = "Contraseña";
			// 
			// CarddavUsername
			// 
			CarddavUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			CarddavUsername.Enabled = false;
			CarddavUsername.Location = new Point(89, 60);
			CarddavUsername.Name = "CarddavUsername";
			CarddavUsername.Size = new Size(253, 23);
			CarddavUsername.TabIndex = 11;
			// 
			// LCardDavUsername
			// 
			LCardDavUsername.AutoSize = true;
			LCardDavUsername.Enabled = false;
			LCardDavUsername.Location = new Point(7, 63);
			LCardDavUsername.Name = "LCardDavUsername";
			LCardDavUsername.Size = new Size(36, 15);
			LCardDavUsername.TabIndex = 10;
			LCardDavUsername.Text = "Email";
			// 
			// CardDavURL
			// 
			CardDavURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			CardDavURL.Enabled = false;
			CardDavURL.Location = new Point(89, 31);
			CardDavURL.Name = "CardDavURL";
			CardDavURL.Size = new Size(253, 23);
			CardDavURL.TabIndex = 9;
			// 
			// LCardDavUrl
			// 
			LCardDavUrl.AutoSize = true;
			LCardDavUrl.Enabled = false;
			LCardDavUrl.Location = new Point(7, 34);
			LCardDavUrl.Name = "LCardDavUrl";
			LCardDavUrl.Size = new Size(76, 15);
			LCardDavUrl.TabIndex = 8;
			LCardDavUrl.Text = "CardDav URL";
			// 
			// CarddavSyncEnabled
			// 
			CarddavSyncEnabled.AutoSize = true;
			CarddavSyncEnabled.Location = new Point(89, 6);
			CarddavSyncEnabled.Name = "CarddavSyncEnabled";
			CarddavSyncEnabled.Size = new Size(227, 19);
			CarddavSyncEnabled.TabIndex = 0;
			CarddavSyncEnabled.Text = "Sincronización por CardDav habilitada";
			CarddavSyncEnabled.UseVisualStyleBackColor = true;
			CarddavSyncEnabled.CheckedChanged += CarddavSyncEnabled_CheckedChanged;
			// 
			// FUserData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(359, 237);
			ControlBox = false;
			Controls.Add(TabControlUser);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FUserData";
			ShowIcon = false;
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "Usuario - Nuevo";
			Load += FUserData_Load;
			TabControlUser.ResumeLayout(false);
			TabGeneral.ResumeLayout(false);
			TabGeneral.PerformLayout();
			TabPermissions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)DataGridUserPermissions).EndInit();
			TabCarddav.ResumeLayout(false);
			TabCarddav.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private TextBox TextBoxName;
		private Label LName;
		private TextBox TextBoxUsername;
		private Label LUsername;
		private TextBox TextBoxPassword;
		private Label LPassword;
		private TabControl TabControlUser;
		private TabPage TabGeneral;
		private TabPage TabPermissions;
		private DataGridView DataGridUserPermissions;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewCheckBoxColumn colPermited;
		private TabPage TabCarddav;
		private CheckBox CarddavSyncEnabled;
		private TextBox CardDavURL;
		private Label LCardDavUrl;
		private TextBox CarddavPassword;
		private Label LCardDavPassword;
		private TextBox CarddavUsername;
		private Label LCardDavUsername;
	}
}