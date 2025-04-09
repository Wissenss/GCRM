using NLog;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

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

					AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

					QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.SetHighDpiMode(HighDpiMode.SystemAware);

					CultureInfo ci = new CultureInfo("es-MX");
					Thread.CurrentThread.CurrentCulture = ci;
					Thread.CurrentThread.CurrentUICulture = ci;

					Application.Run(new FSplashScreen());
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

		static void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
		{
			Logger Logger = NLog.LogManager.GetCurrentClassLogger();

			Exception ex = (Exception)args.ExceptionObject;

			StringBuilder message = new StringBuilder();

			message.AppendLine($"Something went wrong! Unhandled Exception... \n\n{ex.ToString()}\n\n");

			Logger.Debug(message);
		}
	}
}