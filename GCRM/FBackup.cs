using GCRM.Infraestructure;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GCRM
{
    public partial class FBackup : Form
    {
        public FBackup()
        {
            InitializeComponent();
        }

        private void UpdateOutput(string text)
        {
            if (this.Output.InvokeRequired)
            {
                this.Output.Invoke(new Action(() => UpdateOutput(text)));
            }
            else
            {
                this.Output.AppendText(text + Environment.NewLine);
            }
        }

        private async void DoBackup()
        {
            ConnectionSettings.LoadSettings();

            BGenerar.Enabled = false;
            ProgressBar.Style = ProgressBarStyle.Marquee;
            ProgressBar.MarqueeAnimationSpeed = 30;
            Text = "Generando respaldo...";

            SaveFileDialog.Filter = "Archivo de respaldo (*.backup)|*.backup";
            SaveFileDialog.FileName = $"backup_{ConnectionSettings.Database}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.backup";

            if (SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                BGenerar.Enabled = true;
                Text = "Respaldo cancelado.";
                return;
            }

            try
            {
                StringBuilder args = new StringBuilder();

                args.Append($"\"postgresql://{ConnectionSettings.Username}:{ConnectionSettings.Password}@{ConnectionSettings.Host}:{ConnectionSettings.Port}/{ConnectionSettings.Database}\" ");
                args.Append($"-F c -f \"{SaveFileDialog.FileName}\"");

                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    FileName = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Libs", "pg_dump.exe"),
                    Arguments = args.ToString(),
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;

                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            UpdateOutput(e.Data);
                        }
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            UpdateOutput($"ERROR: {e.Data}");
                        }
                    };

                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await process.WaitForExitAsync();

                    Text = "Proceso terminado.";
                    ProgressBar.Style = ProgressBarStyle.Blocks;
                    ProgressBar.Value = 100;
                }
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);

                Text = "Error al generar el respaldo.";
            }
            finally
            {
                BGenerar.Enabled = true;
            }
        }

        private async void BGenerar_Click(object sender, EventArgs e)
        {
            DoBackup();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
