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
			LHost = new Label();
			TextBoxHost = new TextBox();
			TextBoxDatabase = new TextBox();
			LDatabase = new Label();
			LPort = new Label();
			NumericPort = new NumericUpDown();
			BAccept = new Button();
			BTest = new Button();
			BCancel = new Button();
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
			TextBoxHost.Location = new Point(73, 12);
			TextBoxHost.Name = "TextBoxHost";
			TextBoxHost.Size = new Size(179, 23);
			TextBoxHost.TabIndex = 1;
			// 
			// TextBoxDatabase
			// 
			TextBoxDatabase.Location = new Point(73, 70);
			TextBoxDatabase.Name = "TextBoxDatabase";
			TextBoxDatabase.Size = new Size(179, 23);
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
			NumericPort.Location = new Point(73, 41);
			NumericPort.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
			NumericPort.Name = "NumericPort";
			NumericPort.Size = new Size(179, 23);
			NumericPort.TabIndex = 5;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(96, 116);
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
			BTest.Location = new Point(15, 116);
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
			BCancel.Location = new Point(177, 116);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 9;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// FConnection
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(264, 151);
			ControlBox = false;
			Controls.Add(BCancel);
			Controls.Add(BTest);
			Controls.Add(BAccept);
			Controls.Add(NumericPort);
			Controls.Add(LPort);
			Controls.Add(TextBoxDatabase);
			Controls.Add(LDatabase);
			Controls.Add(TextBoxHost);
			Controls.Add(LHost);
			MaximumSize = new Size(280, 190);
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
	}
}