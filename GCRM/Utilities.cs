using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Business;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GCRM
{
	public static class Utilities
	{
		public static int TrimOnRange(int lowest_value, int highest_value, int value)
		{
			value = Math.Max(value, lowest_value);
			value = Math.Min(value, highest_value);

			return value;
		}

		public static void ShowErrorDialog(Business.Error error)
		{
			MessageBox.Show(Errors.GetErrorDescription(error), $"Error{(int)error}: {error.ToString()}", MessageBoxButtons.OK);
		}

		public static void ShowValidationErrorDialog(string errors, string title = "Se encontraron los siguientes problemas: ")
		{
			MessageBox.Show(errors, title, MessageBoxButtons.OK);
		}

		public static void ShowValidationErrorDialog(StringBuilder errors, string title = "Se encontraron los siguientes problemas: ")
		{
			ShowValidationErrorDialog(errors.ToString(), title);
		}

		public static void ShowExceptionDialog(Exception ex)
		{
			MessageBox.Show(ex.Message, "Ocurrió excepción", MessageBoxButtons.OK);
		}

		public static void OpenUrl(string url)
		{
			try
			{
				Process.Start(url);
			}
			catch
			{
				// hack because of this: https://github.com/dotnet/corefx/issues/10361
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					url = url.Replace("&", "^&");
					Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					Process.Start("xdg-open", url);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					Process.Start("open", url);
				}
				else
				{
					throw;
				}
			}
		}
	}
}
