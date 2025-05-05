namespace GCRM
{
	partial class FCitizenListImportExcel
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
			FilePath = new TextBox();
			BSelectFile = new Button();
			label1 = new Label();
			NStart = new NumericUpDown();
			NCategoryName = new NumericUpDown();
			NName = new NumericUpDown();
			label2 = new Label();
			label3 = new Label();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			label6 = new Label();
			NInstitutionName = new NumericUpDown();
			label5 = new Label();
			NInstitutionRoleName = new NumericUpDown();
			label4 = new Label();
			OpenFileDialog = new OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)NStart).BeginInit();
			((System.ComponentModel.ISupportInitialize)NCategoryName).BeginInit();
			((System.ComponentModel.ISupportInitialize)NName).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NInstitutionName).BeginInit();
			((System.ComponentModel.ISupportInitialize)NInstitutionRoleName).BeginInit();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(289, 254);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 4;
			BCancel.Text = "&Cerrar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(211, 254);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 3;
			BAccept.Text = "&Importar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// FilePath
			// 
			FilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			FilePath.Location = new Point(66, 12);
			FilePath.Name = "FilePath";
			FilePath.ReadOnly = true;
			FilePath.Size = new Size(269, 23);
			FilePath.TabIndex = 5;
			// 
			// BSelectFile
			// 
			BSelectFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BSelectFile.Image = Properties.Resources.Fatcow_Farm_Fresh_Magnifier_16;
			BSelectFile.Location = new Point(341, 12);
			BSelectFile.Name = "BSelectFile";
			BSelectFile.Size = new Size(23, 23);
			BSelectFile.TabIndex = 6;
			BSelectFile.UseVisualStyleBackColor = true;
			BSelectFile.Click += BSelectFile_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 16);
			label1.Name = "label1";
			label1.Size = new Size(48, 15);
			label1.TabIndex = 7;
			label1.Text = "Archivo";
			// 
			// NStart
			// 
			NStart.Location = new Point(75, 22);
			NStart.Name = "NStart";
			NStart.Size = new Size(72, 23);
			NStart.TabIndex = 8;
			NStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// NCategoryName
			// 
			NCategoryName.Location = new Point(75, 51);
			NCategoryName.Name = "NCategoryName";
			NCategoryName.Size = new Size(75, 23);
			NCategoryName.TabIndex = 11;
			NCategoryName.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// NName
			// 
			NName.Location = new Point(75, 22);
			NName.Name = "NName";
			NName.Size = new Size(75, 23);
			NName.TabIndex = 13;
			NName.Value = new decimal(new int[] { 4, 0, 0, 0 });
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 24);
			label2.Name = "label2";
			label2.Size = new Size(55, 15);
			label2.TabIndex = 14;
			label2.Text = "Iniciar en";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(11, 53);
			label3.Name = "label3";
			label3.Size = new Size(58, 15);
			label3.TabIndex = 15;
			label3.Text = "Categoría";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(NStart);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new Point(12, 42);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(352, 56);
			groupBox1.TabIndex = 16;
			groupBox1.TabStop = false;
			groupBox1.Text = "Filas";
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(NInstitutionName);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(NInstitutionRoleName);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(NCategoryName);
			groupBox2.Controls.Add(NName);
			groupBox2.Controls.Add(label3);
			groupBox2.Location = new Point(12, 104);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(352, 144);
			groupBox2.TabIndex = 17;
			groupBox2.TabStop = false;
			groupBox2.Text = "Columnas";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(6, 82);
			label6.Name = "label6";
			label6.Size = new Size(63, 15);
			label6.TabIndex = 20;
			label6.Text = "Institución";
			// 
			// NInstitutionName
			// 
			NInstitutionName.Location = new Point(75, 80);
			NInstitutionName.Name = "NInstitutionName";
			NInstitutionName.Size = new Size(75, 23);
			NInstitutionName.TabIndex = 19;
			NInstitutionName.Value = new decimal(new int[] { 6, 0, 0, 0 });
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(30, 111);
			label5.Name = "label5";
			label5.Size = new Size(39, 15);
			label5.TabIndex = 18;
			label5.Text = "Cargo";
			// 
			// NInstitutionRoleName
			// 
			NInstitutionRoleName.Location = new Point(75, 109);
			NInstitutionRoleName.Name = "NInstitutionRoleName";
			NInstitutionRoleName.Size = new Size(75, 23);
			NInstitutionRoleName.TabIndex = 17;
			NInstitutionRoleName.Value = new decimal(new int[] { 5, 0, 0, 0 });
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(18, 24);
			label4.Name = "label4";
			label4.Size = new Size(51, 15);
			label4.TabIndex = 16;
			label4.Text = "Nombre";
			// 
			// OpenFileDialog
			// 
			OpenFileDialog.FileName = "openFileDialog1";
			// 
			// FCitizenListImportExcel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(376, 289);
			ControlBox = false;
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(label1);
			Controls.Add(BSelectFile);
			Controls.Add(FilePath);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FCitizenListImportExcel";
			Text = "Importar Ciudadanos";
			((System.ComponentModel.ISupportInitialize)NStart).EndInit();
			((System.ComponentModel.ISupportInitialize)NCategoryName).EndInit();
			((System.ComponentModel.ISupportInitialize)NName).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NInstitutionName).EndInit();
			((System.ComponentModel.ISupportInitialize)NInstitutionRoleName).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private TextBox FilePath;
		private Button BSelectFile;
		private Label label1;
		private NumericUpDown NStart;
		private NumericUpDown NName;
		private NumericUpDown NCategoryName;
		private Label label2;
		private Label label3;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Label label6;
		private NumericUpDown NInstitutionName;
		private Label label5;
		private NumericUpDown NInstitutionRoleName;
		private Label label4;
		private OpenFileDialog OpenFileDialog;
	}
}