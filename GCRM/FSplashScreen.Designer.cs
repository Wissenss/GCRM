namespace GCRM
{
	partial class FSplashScreen
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
			panel1 = new Panel();
			LDescription = new Label();
			LTitle = new Label();
			PictureBox = new PictureBox();
			ProgressBar = new ProgressBar();
			LStatus = new Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.GradientInactiveCaption;
			panel1.Controls.Add(LDescription);
			panel1.Controls.Add(LTitle);
			panel1.Controls.Add(PictureBox);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Padding = new Padding(5);
			panel1.Size = new Size(424, 48);
			panel1.TabIndex = 1;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LDescription.Location = new Point(45, 24);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(231, 15);
			LDescription.TabIndex = 2;
			LDescription.Text = "Gobernment Citizen Relationship Manager";
			// 
			// LTitle
			// 
			LTitle.AutoSize = true;
			LTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LTitle.Location = new Point(46, 9);
			LTitle.Name = "LTitle";
			LTitle.Size = new Size(42, 15);
			LTitle.TabIndex = 1;
			LTitle.Text = "GCRM";
			// 
			// PictureBox
			// 
			PictureBox.Image = Properties.Resources.Fatcow_Farm_Fresh_Bookmark_32;
			PictureBox.Location = new Point(8, 7);
			PictureBox.Name = "PictureBox";
			PictureBox.Size = new Size(32, 32);
			PictureBox.TabIndex = 0;
			PictureBox.TabStop = false;
			// 
			// ProgressBar
			// 
			ProgressBar.ForeColor = SystemColors.GradientInactiveCaption;
			ProgressBar.Location = new Point(12, 88);
			ProgressBar.Name = "ProgressBar";
			ProgressBar.Size = new Size(400, 23);
			ProgressBar.Style = ProgressBarStyle.Marquee;
			ProgressBar.TabIndex = 13;
			// 
			// LStatus
			// 
			LStatus.AutoSize = true;
			LStatus.Location = new Point(12, 61);
			LStatus.Name = "LStatus";
			LStatus.Size = new Size(99, 15);
			LStatus.TabIndex = 14;
			LStatus.Text = "Iniciando sistema";
			// 
			// FSplashScreen
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(424, 131);
			ControlBox = false;
			Controls.Add(LStatus);
			Controls.Add(ProgressBar);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FSplashScreen";
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "FSplashScreen";
			Shown += FSplashScreen_Shown;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panel1;
		private Label LDescription;
		private Label LTitle;
		private PictureBox PictureBox;
		private ProgressBar ProgressBar;
		private Label LStatus;
	}
}