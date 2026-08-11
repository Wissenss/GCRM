using GCRM.Infraestructure;
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
	public partial class FConnection : Form
	{
		FAccessMode AccessMode = FAccessMode.Read;

		public FConnection()
		{
			InitializeComponent();
		}

		private async Task<bool> TestConnection()
		{
			using (new CursorWait())
			{
				string host = TextBoxHost.Text.Trim();
				int port = (int)NumericPort.Value;
				string database = TextBoxDatabase.Text.Trim();

				return await ConnectionSettings.TestSettings(host, port, database);
			}
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxHost.Enabled = AccessMode == FAccessMode.Update;
			NumericPort.Enabled = AccessMode == FAccessMode.Update;
			TextBoxDatabase.Enabled = AccessMode == FAccessMode.Update;	

			BTest.Visible = AccessMode == FAccessMode.Update;
			BAccept.Visible = AccessMode == FAccessMode.Update;

			BCancel.Text = AccessMode == FAccessMode.Update ? "&Cancelar" : "&Cerrar";
		}

		private async void BTest_Click(object sender, EventArgs e)
		{
			if (await TestConnection())
			{
				Utilities.ShowValidationErrorDialog("Conexión exitosa!");
			}
			else
			{
				Utilities.ShowValidationErrorDialog("Conexión fallida!");
			}
		}

		private async void BAccept_Click(object sender, EventArgs e)
		{
			using (new CursorWait())
			{
				if (await TestConnection() == false)
				{
					Utilities.ShowValidationErrorDialog("Conexión fallida, compruebe los parámetros de conexión");
					return;
				}

				string host = TextBoxHost.Text.Trim();
				int port = (int)NumericPort.Value;
				string database = TextBoxDatabase.Text.Trim();

				ConnectionSettings.WriteSettings(host, port, database);

				ConnectionPool.Refresh();

				DialogResult = DialogResult.OK;
			}
		}

		private void FConnection_Load(object sender, EventArgs e)
		{
			SetAccessMode(AccessMode);

			using (new CursorWait())
			{
				ConnectionSettings.LoadSettings();

				TextBoxHost.Text = ConnectionSettings.Host;
				NumericPort.Value = (decimal)ConnectionSettings.Port;
				TextBoxDatabase.Text = ConnectionSettings.Database;
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
