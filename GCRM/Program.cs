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
			QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetHighDpiMode(HighDpiMode.SystemAware);

			Application.Run(new FLogin());
		}
	}
}