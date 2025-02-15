using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}
