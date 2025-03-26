using NLog;
using System.Text;

namespace GCRM
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			SetLogger();

			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

			QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetHighDpiMode(HighDpiMode.SystemAware);

			Application.Run(new FSplashScreen());
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