using Business.Business;
using Business;
using Connection;
using System.Diagnostics;
using System.Text;

namespace GCRM
{
	public partial class FSplashScreen : Form
	{
		public FSplashScreen()
		{
			InitializeComponent();

			LTitle.Text += $" v{Utilities.GetProductVersion()}";
		}

		private async Task<bool> ConnectoToServer()
		{
			ConnectionSettings.LoadSettings();

			if (ConnectionSettings.TestSettings() == false)
			{
				using (FConnection connection_dlg = new FConnection())
				{
					connection_dlg.SetAccessMode(FAccessMode.Update);

					if (connection_dlg.ShowDialog() == DialogResult.Cancel)
					{
						Application.Exit();
					}
				}
			}

			return true;
		}

		private async Task<bool> CheckClientVersion()
		{
			string client_version = Utilities.GetProductVersion();
			string necessary_client_version = SettingsHandler.GetSetting("client_version", client_version);

			if (necessary_client_version != client_version)
			{
				if (MessageBox.Show($"La versión del cliente \"{client_version}\" es distinta a la necesaria \"{necessary_client_version}\" \n ¿Desea actualizar su sistema a la última versión?", "Actualización necesaria", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					LStatus.Text = "Iniciando actualización del sistema...";

					string install_directory = AppDomain.CurrentDomain.BaseDirectory;
					string download_directory = Path.Join(install_directory, "Downloads\\");
					string update_file = Path.Join(download_directory, "gcrm_update.7z");
					string update_uncompress_file = Path.Join(Path.GetTempPath(), "GCRM\\gcrm_update_uncompress\\");

					LStatus.Text = "Descargando la última versión disponible...";

					// download the latest release
					TOperatingSystem os = TOperatingSystem.WindowsX86;

					if (Environment.Is64BitOperatingSystem)
						os = TOperatingSystem.WindowsX64;

					await GithubUtilities.DownloadLatestRelease(os, update_file);

					LStatus.Text = "Descomprimiendo archivos...";

					// unzip the file
					await SevenZipUtilities.UnzipFile(update_file, update_uncompress_file);

					LStatus.Text = "Iniciando rutina de actualización...";

					// copy uncopressed files to install directory
					StringBuilder update_script = new StringBuilder();

					update_script.Append($" /K");
					update_script.Append($" (echo 'starting system update')");
					update_script.Append($" & (timeout 4)");
					update_script.Append($" & (echo 'replacing files')");
					update_script.Append($" & (xcopy \"{update_uncompress_file}\" \"{install_directory}\" /Y /E /H /C /I)");
					update_script.Append($" & (echo 're-starting system')");
					update_script.Append($" & ({System.Environment.ProcessPath})");
					update_script.Append($" & (echo 'system update finished, you may close this window')");
					update_script.Append($" & (exit)");

					Process.Start(new ProcessStartInfo()
					{
						FileName = "cmd.exe",
						Arguments = update_script.ToString(),
						UseShellExecute = true,
						Verb = "runas"
					});

					// kill current process
					Application.Exit();
				}
				else
				{
					Application.Exit();
				}
			}

			return true;
		}

		private async Task<bool> LoadAllCatalogs()
		{
			Catalogs.LoadAll();

			return true;
		}

		private async void FSplashScreen_Shown(object sender, EventArgs e)
		{
			await Task.Delay(300);

			LStatus.Text = "Conectando al servidor...";

			await ConnectoToServer();

			LStatus.Text = "Revisando versión del cliente...";

			await CheckClientVersion();

			LStatus.Text = "Cargando catálogos...";

			await LoadAllCatalogs();

			LStatus.Text = "Iniciando sesión...";

			Hide();

			FLogin login_form = new FLogin();

			login_form.Show();
		}
	}
}
