using Business;
using ClosedXML.Excel;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FCitizenListImportExcel : Form
	{
		public FCitizenListImportExcel()
		{
			InitializeComponent();
		}

		private void BSelectFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog.DefaultExt = $".xlsx";
			OpenFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";

			if (OpenFileDialog.ShowDialog() != DialogResult.OK)
				return;

			FilePath.Text = OpenFileDialog.FileName;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (FilePath.Text.Trim().Length == 0)
				errors.AppendLine("Debe especificar el archivo");

			decimal[] columns = { NCategoryName.Value, NName.Value, NInstitutionRoleName.Value, NInstitutionName.Value };

			decimal last_value = -1;

			foreach (decimal value in columns.Order())
			{
				if (value == last_value)
				{
					errors.AppendLine("Existen columas sobrelapadas, No puede haber dos características a importar en la misma columna");
					break;
				}

				last_value = value;
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
				return;

			using (FLoading loading_dlg = new FLoading())
			{
				loading_dlg.Show();

				loading_dlg.Text = "Loading file...";

				// here we map the excel contents to objects the backend gets, it is its responsability to ensure
				// the data send here is correct and try to map to the correct records depending on the name
				List<TCitizen> imported_citizens = new List<TCitizen>();

				using (var workbook = new XLWorkbook(FilePath.Text.Trim()))
				{
					var worksheet = workbook.Worksheets.First(); // Or use workbook.Worksheet("SheetName");

					foreach (var row in worksheet.RowsUsed())
					{
						if (row.RowNumber() < NStart.Value)
							continue;

						TCitizen citizen = new TCitizen();

						citizen.Category = new TCitizenCategory();
						citizen.Category.Name = row.Cell((int)NCategoryName.Value).Value.ToString();

						citizen.Name = row.Cell((int)NName.Value).Value.ToString();

						citizen.Institution = new TInstitution();
						citizen.Institution.Name = row.Cell((int)NInstitutionName.Value).Value.ToString();

						citizen.Role = new TInstitutionRole();
						citizen.Role.Name = row.Cell((int)NInstitutionRoleName.Value).Value.ToString();

						imported_citizens.Add(citizen);
					}
				}

				// then we send the request to actually create the citizens, etc...

				Error error = CitizensHandler.ImportCitizens(imported_citizens, out string log, Index => loading_dlg.Text = $"Creating citizen ({Index}/{imported_citizens.Count})");

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
				}

				MessageBox.Show(log, "Log de importación", MessageBoxButtons.OK, MessageBoxIcon.None);
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
