using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using BrightIdeasSoftware;
using Business;
using ClosedXML.Excel;

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

		public static DialogResult ShowDeleteConfirmDialog(string message)
		{
			DialogResult result = MessageBox.Show(
				message,
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning
			);

			return result;
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

		public static string GetProductVersion()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fileVersionInfo.ProductVersion;

			return version;
		}
	}

	public static class DataGridUtilities
	{
		public static void AddColumn(DataGridView data_grid, string col_name, string header_text, string data_property_name, bool visible = true, int display_index = 0, int width = 100, int min_width = 100, DataGridViewAutoSizeColumnMode auto_size_mode = DataGridViewAutoSizeColumnMode.None)
		{
			DataGridViewColumn column = new DataGridViewColumn();

			// cell template
			DataGridViewCell cell = new DataGridViewTextBoxCell();
			column.CellTemplate = cell;

			// customaizable values
			column.Name = col_name;
			column.DataPropertyName = data_property_name;
			column.HeaderText = header_text;
			column.DefaultCellStyle = data_grid.DefaultCellStyle;
			column.Width = width;
			column.MinimumWidth = min_width;
			column.AutoSizeMode = auto_size_mode;
			column.Visible = visible;
			column.DisplayIndex = display_index;

			// defaults
			column.Resizable = DataGridViewTriState.True;
			column.DividerWidth = 1;
			column.FillWeight = auto_size_mode == DataGridViewAutoSizeColumnMode.Fill ? 100 : 1;
			column.Frozen = false;

			data_grid.Columns.Add(column);
		}
	}

	public static class ExcelUtilities
	{
		public static void SetWorksheetHeaderCell(IXLWorksheet worksheet, int row, int col, string value, XLColor color = null, int width = 20)
		{
			// set the value
			worksheet.Cell(row, col).Value = value;

			// set the width
			worksheet.Column(col).Width = width;

			// set the background color
			if (color != null)
			{
				worksheet.Cell(row, col).Style.Fill.BackgroundColor = color;
			}

			// set the font style
			worksheet.Cell(row, col).Style.Font.Bold = true;

			// set the borders
			worksheet.Cell(row, col).Style.Border.RightBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.TopBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.RightBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.LeftBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.TopBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.BottomBorderColor = XLColor.Black;
		}

		public static void SetWorksheetCell(IXLWorksheet worksheet, int row, int col, string value, string number_format = null)
		{
			// set the value
			worksheet.Cell(row, col).Value = value;

			if (number_format != null)
			{
				worksheet.Cell(row, col).Style.NumberFormat.Format = number_format;
			}

			// set the borders
			worksheet.Cell(row, col).Style.Border.RightBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.TopBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.RightBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.LeftBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.TopBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.BottomBorderColor = XLColor.Black;
		}
	}

	public static class TreeViewUtilities
	{
		public static IEnumerable<TreeNode> CollectTreeNodes(TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				yield return node;

				foreach (var child in CollectTreeNodes(node.Nodes))
					yield return child;
			}
		}

		public static void ExpandToLevel(TreeNodeCollection nodes, int level)
		{
			if (level > 0)
			{
				foreach (TreeNode node in nodes)
				{
					node.Expand();
					ExpandToLevel(node.Nodes, level - 1);
				}
			}
		}
	}

	public static class ObjectTreeViewUtilities
	{
		public static void ExpandToLevel<T>(TreeListView treeListView, List<T> objects, int level)
		{
			if (level > 0)
			{
				foreach (object node in objects)
				{
					treeListView.Expand(node);
					ExpandToLevel(treeListView, objects, level - 1);
				}
			}
		}
	}
}
