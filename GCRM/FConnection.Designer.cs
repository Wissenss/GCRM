namespace GCRM
{
	partial class FConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FConnection));
            LHost = new Label();
            TextBoxHost = new TextBox();
            TextBoxDatabase = new TextBox();
            LDatabase = new Label();
            LPort = new Label();
            NumericPort = new NumericUpDown();
            BAccept = new Button();
            BTest = new Button();
            BCancel = new Button();
            TextBoxUsername = new TextBox();
            LUsername = new Label();
            TextBoxPassword = new TextBox();
            LPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)NumericPort).BeginInit();
            SuspendLayout();
            // 
            // LHost
            // 
            LHost.AutoSize = true;
            LHost.Location = new Point(12, 15);
            LHost.Name = "LHost";
            LHost.Size = new Size(32, 15);
            LHost.TabIndex = 0;
            LHost.Text = "Host";
            // 
            // TextBoxHost
            // 
            TextBoxHost.Location = new Point(78, 12);
            TextBoxHost.Name = "TextBoxHost";
            TextBoxHost.Size = new Size(174, 23);
            TextBoxHost.TabIndex = 1;
            // 
            // TextBoxDatabase
            // 
            TextBoxDatabase.Location = new Point(78, 70);
            TextBoxDatabase.Name = "TextBoxDatabase";
            TextBoxDatabase.Size = new Size(174, 23);
            TextBoxDatabase.TabIndex = 3;
            // 
            // LDatabase
            // 
            LDatabase.AutoSize = true;
            LDatabase.Location = new Point(12, 73);
            LDatabase.Name = "LDatabase";
            LDatabase.Size = new Size(55, 15);
            LDatabase.TabIndex = 2;
            LDatabase.Text = "Database";
            // 
            // LPort
            // 
            LPort.AutoSize = true;
            LPort.Location = new Point(12, 43);
            LPort.Name = "LPort";
            LPort.Size = new Size(29, 15);
            LPort.TabIndex = 4;
            LPort.Text = "Port";
            // 
            // NumericPort
            // 
            NumericPort.Location = new Point(78, 41);
            NumericPort.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            NumericPort.Name = "NumericPort";
            NumericPort.Size = new Size(174, 23);
            NumericPort.TabIndex = 5;
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(96, 166);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 6;
            BAccept.Text = "&Aceptar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // BTest
            // 
            BTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BTest.Location = new Point(15, 166);
            BTest.Name = "BTest";
            BTest.Size = new Size(75, 23);
            BTest.TabIndex = 8;
            BTest.Text = "&Probar";
            BTest.UseVisualStyleBackColor = true;
            BTest.Click += BTest_Click;
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(177, 166);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 9;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // TextBoxUsername
            // 
            TextBoxUsername.Location = new Point(78, 99);
            TextBoxUsername.Name = "TextBoxUsername";
            TextBoxUsername.Size = new Size(174, 23);
            TextBoxUsername.TabIndex = 11;
            // 
            // LUsername
            // 
            LUsername.AutoSize = true;
            LUsername.Location = new Point(12, 102);
            LUsername.Name = "LUsername";
            LUsername.Size = new Size(60, 15);
            LUsername.TabIndex = 10;
            LUsername.Text = "Username";
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Location = new Point(78, 128);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.Size = new Size(174, 23);
            TextBoxPassword.TabIndex = 13;
            // 
            // LPassword
            // 
            LPassword.AutoSize = true;
            LPassword.Location = new Point(12, 131);
            LPassword.Name = "LPassword";
            LPassword.Size = new Size(57, 15);
            LPassword.TabIndex = 12;
            LPassword.Text = "Password";
            // 
            // FConnection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 201);
            ControlBox = false;
            Controls.Add(TextBoxPassword);
            Controls.Add(LPassword);
            Controls.Add(TextBoxUsername);
            Controls.Add(LUsername);
            Controls.Add(BCancel);
            Controls.Add(BTest);
            Controls.Add(BAccept);
            Controls.Add(NumericPort);
            Controls.Add(LPort);
            Controls.Add(TextBoxDatabase);
            Controls.Add(LDatabase);
            Controls.Add(TextBoxHost);
            Controls.Add(LHost);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(280, 240);
            MinimumSize = new Size(280, 190);
            Name = "FConnection";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Parámetros de conexión";
            Load += FConnection_Load;
            ((System.ComponentModel.ISupportInitialize)NumericPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LHost;
		private TextBox TextBoxHost;
		private TextBox TextBoxDatabase;
		private Label LDatabase;
		private Label LPort;
		private NumericUpDown NumericPort;
		private Button BAccept;
		private Button BTest;
		private Button BCancel;
        private TextBox TextBoxUsername;
        private Label LUsername;
        private TextBox TextBoxPassword;
        private Label LPassword;
    }
}