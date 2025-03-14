namespace GCRM
{
	partial class FEmailBilling
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
			label1 = new Label();
			LCredit = new Label();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(221, 69);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 7;
			BCancel.Text = "&Cerrar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(103, 9);
			label1.Name = "label1";
			label1.Size = new Size(104, 15);
			label1.TabIndex = 8;
			label1.Text = "Crédito disponible";
			// 
			// LCredit
			// 
			LCredit.AutoSize = true;
			LCredit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LCredit.ForeColor = SystemColors.HotTrack;
			LCredit.Location = new Point(131, 36);
			LCredit.Name = "LCredit";
			LCredit.Size = new Size(45, 15);
			LCredit.TabIndex = 9;
			LCredit.Text = "$12.04";
			// 
			// FEmailBilling
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(308, 104);
			ControlBox = false;
			Controls.Add(LCredit);
			Controls.Add(label1);
			Controls.Add(BCancel);
			Name = "FEmailBilling";
			Text = "Factura";
			Load += FEmailBilling_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Button BCancel;
		private Label label1;
		private Label LCredit;
	}
}