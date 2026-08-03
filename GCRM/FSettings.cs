using Business;
using Business.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FSettings : Form
	{

		public FSettings()
		{
			InitializeComponent();

			LoadPermissions();
		}

		private void LoadPermissions()
		{
			if (Session.HasPermission("Settings.Globales.Consultar") == false)
			{
				TabControlSettings.TabPages.Remove(TabGlobalSettings);
			}

			bool can_edit_global_settings = Session.HasPermission("Settings.Globales.Editar");

			TextBoxPurelymailAPIKey.Enabled = can_edit_global_settings;
		}

		private void LoadSettings()
		{
			using (new CursorWait())
			{
				if (Session.HasPermission("Settings.Globales.Consultar"))
				{
					TextBoxPurelymailAPIKey.Text = SettingsHandler.GetSetting("Email.API.Key", "pm-live-eace83da-880e-449f-ab8e-f31b1e25c728");

					byte[] raw_background_img = SettingsHandler.GetSetting<byte[]>("Interface.BackgroundImage", null, 0, false);

					if (raw_background_img != null)
					{
						MemoryStream ms = new MemoryStream(raw_background_img);

						BackgroundImage.Image = Image.FromStream(ms);
					}

					DisplayUppercase.Checked = SettingsHandler.GetSetting<bool>("UI.DisplayUppercase", false);
				}

				SettingsUtilities.InstanceConfiguration instance_configuration = SettingsUtilities.LoadInstanceConfiguration();

				CheckBoxUseExternalPDFViewer.Checked = instance_configuration.UseExternalPDFViewer;
			}
		}

		private void SaveSettings()
		{
			using (new CursorWait())
			{
				if (Session.HasPermission("Settings.Globales.Editar"))
				{
					SettingsHandler.SetSetting("Email.API.Key", TextBoxPurelymailAPIKey.Text.Trim());

					if (BackgroundImage.Image != null)
					{
						using (MemoryStream ms = new MemoryStream())
						{
							BackgroundImage.Image.Save(ms, BackgroundImage.Image.RawFormat);

							SettingsHandler.SetSetting("Interface.BackgroundImage", ms.ToArray(), 0, true);
						}
					}
					else
					{
						SettingsHandler.DeleteSetting("Interface.BackgroundImage", 0);
					}

					SettingsHandler.SetSetting("UI.DisplayUppercase", DisplayUppercase.Checked);
				}

				SettingsUtilities.InstanceConfiguration instance_configuration = new SettingsUtilities.InstanceConfiguration()
				{
					UseExternalPDFViewer = CheckBoxUseExternalPDFViewer.Checked,
				};

				SettingsUtilities.SaveInstanceConfiguration(instance_configuration);
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
			{
				return;
			}

			try
			{
				SaveSettings();

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Utilities.ShowExceptionDialog(ex);
			}
		}

		private void FSettings_Load(object sender, EventArgs e)
		{
			LoadSettings();
		}

		private void BSelectBackgroundImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = $"Imagen (*.jpg, *jpeg, *.png, *.bmp, *tiff, *.tif) | *.jpg; *jpeg; *.png; *.bmp; *tiff; *.tif | Todos (*.*) | *.*";

			if (OpenFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			BackgroundImage.Image = Image.FromFile(OpenFileDialog.FileName);
		}

		private void BClearBackgroundImage_Click(object sender, EventArgs e)
		{
			BackgroundImage.Image = null;
		}
	}
}
