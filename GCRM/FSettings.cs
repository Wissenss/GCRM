using Business.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FSettings : Form
	{
		FAccessMode Mode = FAccessMode.Read;

		public FSettings()
		{
			InitializeComponent();
		}

		public void SetAccessMode(FAccessMode mode)
		{
			Mode = mode;

			TextBoxPurelymailAPIKey.Enabled = Mode != FAccessMode.Read; 
		}

		private void LoadSettings()
		{
			using (new CursorWait())
			{
				TextBoxPurelymailAPIKey.Text = SettingsHandler.GetSetting("Email.API.Key", "pm-live-eace83da-880e-449f-ab8e-f31b1e25c728");
			}
		}

		private void SaveSettings()
		{
			using (new CursorWait())
			{
				SettingsHandler.SetSetting("Email.API.Key", TextBoxPurelymailAPIKey.Text.Trim());
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
	}
}
