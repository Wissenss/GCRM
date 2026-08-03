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
			TabGlobalSettings = new TabPage();
			BClearBackgroundImage = new Button();
			BSelectBackgroundImage = new Button();
			LPicture = new Label();
			BackgroundImage = new PictureBox();
			TextBoxPurelymailAPIKey = new TextBox();
			LPurelymailAPIKey = new Label();
			TabPersonalSettings = new TabPage();
			OpenFileDialog = new OpenFileDialog();
			DisplayUppercase = new CheckBox();
			TabInstallationSettings = new TabPage();
			CheckBoxUseExternalPDFViewer = new CheckBox();
			TabControlSettings.SuspendLayout();
			TabGlobalSettings.SuspendLayout();
			TabInstallationSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)BackgroundImage).BeginInit();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(377, 292);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 2;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(299, 292);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 1;
			BAccept.Text = "&Aplicar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// TabControlSettings
			// 
			TabControlSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlSettings.Controls.Add(TabGlobalSettings);
			TabControlSettings.Controls.Add(TabPersonalSettings);
			TabControlSettings.Controls.Add(TabInstallationSettings);
			TabControlSettings.ImeMode = ImeMode.NoControl;
			TabControlSettings.Location = new Point(12, 12);
			TabControlSettings.Margin = new Padding(0);
			TabControlSettings.Multiline = true;
			TabControlSettings.Name = "TabControlSettings";
			TabControlSettings.SelectedIndex = 0;
			TabControlSettings.Size = new Size(440, 275);
			TabControlSettings.SizeMode = TabSizeMode.Fixed;
			TabControlSettings.TabIndex = 0;
			// 
			// TabGlobalSettings
			// 
			TabGlobalSettings.Controls.Add(DisplayUppercase);
			TabGlobalSettings.Controls.Add(BClearBackgroundImage);
			TabGlobalSettings.Controls.Add(BSelectBackgroundImage);
			TabGlobalSettings.Controls.Add(LPicture);
			TabGlobalSettings.Controls.Add(BackgroundImage);
			TabGlobalSettings.Controls.Add(TextBoxPurelymailAPIKey);
			TabGlobalSettings.Controls.Add(LPurelymailAPIKey);
			TabGlobalSettings.Location = new Point(4, 24);
			TabGlobalSettings.Name = "TabGlobalSettings";
			TabGlobalSettings.Padding = new Padding(5);
			TabGlobalSettings.Size = new Size(432, 247);
			TabGlobalSettings.TabIndex = 0;
			TabGlobalSettings.Text = "Global";
			TabGlobalSettings.UseVisualStyleBackColor = true;
			// 
			// BClearBackgroundImage
			// 
			BClearBackgroundImage.Location = new Point(8, 84);
			BClearBackgroundImage.Name = "BClearBackgroundImage";
			BClearBackgroundImage.Size = new Size(101, 23);
			BClearBackgroundImage.TabIndex = 6;
			BClearBackgroundImage.Text = "Limpiar";
			BClearBackgroundImage.UseVisualStyleBackColor = true;
			BClearBackgroundImage.Click += BClearBackgroundImage_Click;
			// 
			// BSelectBackgroundImage
			// 
			BSelectBackgroundImage.Location = new Point(8, 55);
			BSelectBackgroundImage.Name = "BSelectBackgroundImage";
			BSelectBackgroundImage.Size = new Size(101, 23);
			BSelectBackgroundImage.TabIndex = 5;
			BSelectBackgroundImage.Text = "Seleccionar";
			BSelectBackgroundImage.UseVisualStyleBackColor = true;
			BSelectBackgroundImage.Click += BSelectBackgroundImage_Click;
			// 
			// LPicture
			// 
			LPicture.AutoSize = true;
			LPicture.Location = new Point(8, 37);
			LPicture.Name = "LPicture";
			LPicture.Size = new Size(101, 15);
			LPicture.TabIndex = 4;
			LPicture.Text = "Imagen del fondo";
			// 
			// BackgroundImage
			// 
			BackgroundImage.BackColor = SystemColors.Control;
			BackgroundImage.Location = new Point(120, 37);
			BackgroundImage.Name = "BackgroundImage";
			BackgroundImage.Size = new Size(304, 111);
			BackgroundImage.SizeMode = PictureBoxSizeMode.Zoom;
			BackgroundImage.TabIndex = 3;
			BackgroundImage.TabStop = false;
			// 
			// TextBoxPurelymailAPIKey
			// 
			TextBoxPurelymailAPIKey.Location = new Point(120, 8);
			TextBoxPurelymailAPIKey.Name = "TextBoxPurelymailAPIKey";
			TextBoxPurelymailAPIKey.Size = new Size(304, 23);
			TextBoxPurelymailAPIKey.TabIndex = 0;
			// 
			// LPurelymailAPIKey
			// 
			LPurelymailAPIKey.AutoSize = true;
			LPurelymailAPIKey.Location = new Point(8, 11);
			LPurelymailAPIKey.Name = "LPurelymailAPIKey";
			LPurelymailAPIKey.Size = new Size(106, 15);
			LPurelymailAPIKey.TabIndex = 2;
			LPurelymailAPIKey.Text = "Purelymail API Key";
			// 
			// TabPersonalSettings
			// 
			TabPersonalSettings.Location = new Point(4, 24);
			TabPersonalSettings.Name = "TabPersonalSettings";
			TabPersonalSettings.Padding = new Padding(5);
			TabPersonalSettings.Size = new Size(432, 248);
			TabPersonalSettings.TabIndex = 1;
			TabPersonalSettings.Text = "Personal";
			TabPersonalSettings.UseVisualStyleBackColor = true;
			// 
			// DisplayUppercase
			// 
			DisplayUppercase.AutoSize = true;
			DisplayUppercase.Location = new Point(120, 154);
			DisplayUppercase.Name = "DisplayUppercase";
			DisplayUppercase.Size = new Size(121, 19);
			DisplayUppercase.TabIndex = 7;
			DisplayUppercase.Text = "Display uppercase";
			DisplayUppercase.UseVisualStyleBackColor = true;
			//
			// TabInstallationSettings
			//
			TabInstallationSettings.Controls.Add(CheckBoxUseExternalPDFViewer);
			TabInstallationSettings.Location = new Point(4, 24);
			TabInstallationSettings.Name = "TabInstallationSettings";
			TabInstallationSettings.Padding = new Padding(5);
			TabInstallationSettings.Size = new Size(432, 247);
			TabInstallationSettings.TabIndex = 2;
			TabInstallationSettings.Text = "Instalación";
			TabInstallationSettings.UseVisualStyleBackColor = true;
			//
			// CheckBoxUseExternalPDFViewer
			//
			CheckBoxUseExternalPDFViewer.AutoSize = true;
			CheckBoxUseExternalPDFViewer.Location = new Point(8, 8);
			CheckBoxUseExternalPDFViewer.Name = "CheckBoxUseExternalPDFViewer";
			CheckBoxUseExternalPDFViewer.Size = new Size(158, 19);
			CheckBoxUseExternalPDFViewer.TabIndex = 0;
			CheckBoxUseExternalPDFViewer.Text = "Usar visor de PDF externo";
			CheckBoxUseExternalPDFViewer.UseVisualStyleBackColor = true;
			//
			// FSettings
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(464, 351);
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
			TabGlobalSettings.ResumeLayout(false);
			TabGlobalSettings.PerformLayout();
			TabInstallationSettings.ResumeLayout(false);
			TabInstallationSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)BackgroundImage).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private TabControl TabControlSettings;
		private TabPage TabGlobalSettings;
		private TabPage TabPersonalSettings;
		private TextBox TextBoxPurelymailAPIKey;
		private Label LPurelymailAPIKey;
		private Label LPicture;
		private PictureBox BackgroundImage;
		private OpenFileDialog OpenFileDialog;
		private Button BSelectBackgroundImage;
		private Button BClearBackgroundImage;
		private CheckBox DisplayUppercase;
		private TabPage TabInstallationSettings;
		private CheckBox CheckBoxUseExternalPDFViewer;
	}
}