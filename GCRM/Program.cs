using NLog;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace GCRM
{
	internal static class Program
	{
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			bool is_new_instance = true;
			string application_name = "GCRM";

#if DEBUG
			application_name = "GCRM_DEBUG";
#endif

			using (Mutex mutex = new Mutex(true, application_name, out is_new_instance))
			{
				if (is_new_instance)
				{
					SetLogger();

					System.Windows.Forms.Application.ThreadException += OnUnhandledThreadException;
					AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;

					QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

					System.Windows.Forms.Application.EnableVisualStyles();
					System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
					System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

					CultureInfo ci = new CultureInfo("es-MX");
					Thread.CurrentThread.CurrentCulture = ci;
					Thread.CurrentThread.CurrentUICulture = ci;

					System.Windows.Forms.Application.Run(new FSplashScreen());
				}
				else
				{
					Process current = Process.GetCurrentProcess();
					
					foreach (Process process in Process.GetProcessesByName(current.ProcessName))
					{
						if (process.Id != current.Id)
						{
							SetForegroundWindow(process.MainWindowHandle);
							break;
						}
					}
				}
			}
		}

		static void SetLogger()
		{
			string log_file = Path.Join(Path.GetTempPath(), "GCRM\\gcrm_log.log");

			NLog.LogManager.Setup().LoadConfiguration(builder =>
			{
				builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(log_file);
			});
		}

		static void OnUnhandledException(Exception exception)
		{
			Logger Logger = NLog.LogManager.GetCurrentClassLogger();

			StringBuilder message = new StringBuilder();

			message.AppendLine($"Something went wrong! Unhandled Exception... \n\n{exception.ToString()}\n\n");

			Logger.Debug(message);
		}

		static void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs args)
		{
			Exception ex = (Exception)args.ExceptionObject;

			OnUnhandledException(ex);
		}

		static void OnUnhandledThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			Exception ex = e.Exception;

			OnUnhandledException(ex);
		}
	}
}