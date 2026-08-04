namespace GCRM
{
	partial class FAttentionRequired
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
			LReason = new Label();
			TextBoxReason = new TextBox();
			BCancel = new Button();
			BAccept = new Button();
			SuspendLayout();
			//
			// LReason
			//
			LReason.AutoSize = true;
			LReason.Location = new Point(12, 9);
			LReason.Name = "LReason";
			LReason.Size = new Size(45, 15);
			LReason.TabIndex = 0;
			LReason.Text = "Motivo";
			//
			// TextBoxReason
			//
			TextBoxReason.Location = new Point(12, 27);
			TextBoxReason.Multiline = true;
			TextBoxReason.Name = "TextBoxReason";
			TextBoxReason.Size = new Size(298, 107);
			TextBoxReason.TabIndex = 1;
			//
			// BCancel
			//
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(235, 140);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 3;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			//
			// BAccept
			//
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(157, 140);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 2;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			//
			// FAttentionReasonDialog
			//
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(322, 175);
			ControlBox = false;
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(TextBoxReason);
			Controls.Add(LReason);
			Name = "FAttentionReasonDialog";
			Text = "Atención requerida";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label LReason;
		private TextBox TextBoxReason;
		private Button BCancel;
		private Button BAccept;
	}
}
