namespace GCRM
{
	partial class FAbout
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
			LVersion = new Label();
			LCopyright = new Label();
			LContact = new Label();
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
			panel1.Size = new Size(284, 38);
			panel1.TabIndex = 0;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LDescription.Location = new Point(40, 19);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(231, 15);
			LDescription.TabIndex = 2;
			LDescription.Text = "Gobernment Citizen Relationship Manager";
			// 
			// LTitle
			// 
			LTitle.AutoSize = true;
			LTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LTitle.Location = new Point(41, 4);
			LTitle.Name = "LTitle";
			LTitle.Size = new Size(42, 15);
			LTitle.TabIndex = 1;
			LTitle.Text = "GCRM";
			// 
			// PictureBox
			// 
			PictureBox.Image = Properties.Resources.Fatcow_Farm_Fresh_Bookmark_32;
			PictureBox.Location = new Point(3, 3);
			PictureBox.Name = "PictureBox";
			PictureBox.Size = new Size(32, 32);
			PictureBox.TabIndex = 0;
			PictureBox.TabStop = false;
			// 
			// LVersion
			// 
			LVersion.AutoSize = true;
			LVersion.Location = new Point(12, 46);
			LVersion.Name = "LVersion";
			LVersion.Size = new Size(109, 15);
			LVersion.TabIndex = 1;
			LVersion.Text = "Versión: 0.0.6-alpha";
			// 
			// LCopyright
			// 
			LCopyright.AutoSize = true;
			LCopyright.Location = new Point(12, 64);
			LCopyright.Name = "LCopyright";
			LCopyright.Size = new Size(196, 15);
			LCopyright.TabIndex = 2;
			LCopyright.Text = "Copyright: Leonardo Merino Garfias";
			// 
			// LContact
			// 
			LContact.AutoSize = true;
			LContact.Location = new Point(12, 83);
			LContact.Name = "LContact";
			LContact.Size = new Size(190, 15);
			LContact.TabIndex = 3;
			LContact.Text = "Contacto: merinogale@gmail.com";
			// 
			// FAbout
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(284, 108);
			Controls.Add(LContact);
			Controls.Add(LCopyright);
			Controls.Add(LVersion);
			Controls.Add(panel1);
			MaximizeBox = false;
			MaximumSize = new Size(320, 150);
			MinimizeBox = false;
			MinimumSize = new Size(300, 147);
			Name = "FAbout";
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Acerca de";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panel1;
		private PictureBox PictureBox;
		private Label LTitle;
		private Label LDescription;
		private Label LVersion;
		private Label LCopyright;
		private Label LContact;
	}
}