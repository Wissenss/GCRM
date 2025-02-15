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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			//Application.
			//ApplicationConfiguration.Initialize();
			//Application.SetCompatibleTextRenderingDefault(true);
			//Application.SetHighDpiMode(HighDpiMode.SystemAware);
			//Application.
			Application.Run(new FLogin());
		}
	}
}