namespace GCRM
{
	partial class FSettings
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
			TabControlSettings = new TabControl();
			TabEmailSettings = new TabPage();
			TextBoxPurelymailAPIKey = new TextBox();
			LPurelymailAPIKey = new Label();
			TabControlSettings.SuspendLayout();
			TabEmailSettings.SuspendLayout();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(377, 294);
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
			BAccept.Location = new Point(299, 294);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 3;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// TabControlSettings
			// 
			TabControlSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlSettings.Controls.Add(TabEmailSettings);
			TabControlSettings.Location = new Point(1, 1);
			TabControlSettings.Name = "TabControlSettings";
			TabControlSettings.SelectedIndex = 0;
			TabControlSettings.Size = new Size(463, 287);
			TabControlSettings.TabIndex = 5;
			// 
			// TabEmailSettings
			// 
			TabEmailSettings.Controls.Add(TextBoxPurelymailAPIKey);
			TabEmailSettings.Controls.Add(LPurelymailAPIKey);
			TabEmailSettings.Location = new Point(4, 24);
			TabEmailSettings.Name = "TabEmailSettings";
			TabEmailSettings.Padding = new Padding(3);
			TabEmailSettings.Size = new Size(455, 259);
			TabEmailSettings.TabIndex = 0;
			TabEmailSettings.Text = "Email";
			TabEmailSettings.UseVisualStyleBackColor = true;
			// 
			// TextBoxPurelymailAPIKey
			// 
			TextBoxPurelymailAPIKey.Location = new Point(119, 12);
			TextBoxPurelymailAPIKey.Name = "TextBoxPurelymailAPIKey";
			TextBoxPurelymailAPIKey.Size = new Size(328, 23);
			TextBoxPurelymailAPIKey.TabIndex = 1;
			// 
			// LPurelymailAPIKey
			// 
			LPurelymailAPIKey.AutoSize = true;
			LPurelymailAPIKey.Location = new Point(7, 15);
			LPurelymailAPIKey.Name = "LPurelymailAPIKey";
			LPurelymailAPIKey.Size = new Size(106, 15);
			LPurelymailAPIKey.TabIndex = 0;
			LPurelymailAPIKey.Text = "Purelymail API Key";
			// 
			// FSettings
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(464, 329);
			ControlBox = false;
			Controls.Add(TabControlSettings);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			MaximumSize = new Size(500, 390);
			MinimumSize = new Size(480, 368);
			Name = "FSettings";
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "Configuración";
			Load += FSettings_Load;
			TabControlSettings.ResumeLayout(false);
			TabEmailSettings.ResumeLayout(false);
			TabEmailSettings.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private TabControl TabControlSettings;
		private TabPage TabEmailSettings;
		private TextBox TextBoxPurelymailAPIKey;
		private Label LPurelymailAPIKey;
	}
}