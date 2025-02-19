using Business;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using Reporter;
using System.Data;
using System.Globalization;

namespace GCRM
{
	public partial class FCitizenList : Form
	{
		DataSet DSCitizens;
		DataTable DTCitizens;

		FCitizenListFilters FiltersDlg;

		public FCitizenList()
		{
			InitializeComponent();

			DataGridCitizens.AutoGenerateColumns = false;

			// DataGridCitizensColumns
			AddColumnToDataGrid(DataGridCitizens, "colId", "Id", "id", false);
			AddColumnToDataGrid(DataGridCitizens, "colTitle", "Id Título", "title", false);
			AddColumnToDataGrid(DataGridCitizens, "colName", "Nombre", "name", false);
			AddColumnToDataGrid(DataGridCitizens, "colPaternalName", "Apellido paterno", "paternal_name", false);
			AddColumnToDataGrid(DataGridCitizens, "colMaternalName", "Apellido materno", "maternal_name", false);
			AddColumnToDataGrid(DataGridCitizens, "colObservations", "Observaciones", "observations", false);
			AddColumnToDataGrid(DataGridCitizens, "colSex", "Id Sexo", "sex", false);

			AddColumnToDataGrid(DataGridCitizens, "colAssistantId", "Id Asistente", "assistant_id", false);
			AddColumnToDataGrid(DataGridCitizens, "colAssistantPhone", "Teléfono Asistente", "assistant_phone", false);
			AddColumnToDataGrid(DataGridCitizens, "colAssistantPhoneExtension", "Extensión Teléfono Asistente", "assistant_phone_extension", false);
			AddColumnToDataGrid(DataGridCitizens, "colAssistantPhoneAndExtension", "Tel. Asistente", "assistant_phone_full", false);
			AddColumnToDataGrid(DataGridCitizens, "colAssistantCellphone", "Cel. Asistente", "assistant_cellphone", false);

			AddColumnToDataGrid(DataGridCitizens, "colPhone", "Teléfono", "phone", false);
			AddColumnToDataGrid(DataGridCitizens, "colPoliticalParty", "Id Partido", "political_party", false);
			AddColumnToDataGrid(DataGridCitizens, "colPhoneExtension", "Extensión Teléfono", "phone_extension", false);

			AddColumnToDataGrid(DataGridCitizens, "colInstitutionId", "Id Institución", "institution_id", false);
			AddColumnToDataGrid(DataGridCitizens, "colInstitutionCategoryId", "Id Categoría", "institution_category_id", false);
			AddColumnToDataGrid(DataGridCitizens, "colInstitutionSector", "Id Sector", "institution_sector", false);
			AddColumnToDataGrid(DataGridCitizens, "colInstitutionRoleId", "Id Cargo", "institution_role_id", false);

			AddColumnToDataGrid(DataGridCitizens, "colAddressId", "Id Dirección", "address_id", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressStreet", "Calle", "address_street", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressNumber", "Número", "address_number", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressInteriorNumber", "Número interior", "address_interior_number", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressPostalCode", "Código postal", "address_postal_code", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressState", "Estado", "address_state", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressCity", "Ciudad", "address_city", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressCountry", "Id país", "address_country", false);
			AddColumnToDataGrid(DataGridCitizens, "colAddressCountryName", "País", "address_country_name", false);

			int display_index = 0;

			AddColumnToDataGrid(DataGridCitizens, "colTitleName", "Título", "title_name", true, display_index++, 20, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colFullName", "Nombre", "name_full", true, display_index++, 250, 250, DataGridViewAutoSizeColumnMode.Fill);
			AddColumnToDataGrid(DataGridCitizens, "colInstitutionName", "Institución", "institution_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colInstitutionRoleName", "Cargo", "institution_role_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colInstitutionCategoryName", "Categoría", "institution_category_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colInstitutionSectorName", "Sector", "institution_sector_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colPhoneAndExtension", "Teléfono", "phone_full", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colCellphone", "Celular", "cellphone", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colAssistantName", "Asistente", "assistant_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colSexName", "Sexo", "sex_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colPoliticalPartyName", "Partido", "political_party_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colBirthday", "Nacimiento", "birthday", false, display_index++, 20, 20, DataGridViewAutoSizeColumnMode.AllCells);
			AddColumnToDataGrid(DataGridCitizens, "colCURP", "CURP", "curp", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);

			FiltersDlg = new FCitizenListFilters();

			DSCitizens = new DataSet();

			DTCitizens = new DataTable("DTCitizens");
			DTCitizens.Columns.Add("id", typeof(int));
			DTCitizens.Columns.Add("name", typeof(string));
			DTCitizens.Columns.Add("paternal_name", typeof(string));
			DTCitizens.Columns.Add("maternal_name", typeof(string));
			DTCitizens.Columns.Add("name_full", typeof(string));
			DTCitizens.Columns.Add("title", typeof(TCitizenTitle));
			DTCitizens.Columns.Add("title_name", typeof(string));
			DTCitizens.Columns.Add("curp", typeof(string));

			DTCitizens.Columns.Add("birthday", typeof(DateTime));
			DTCitizens.Columns.Add("birthday_year", typeof(int));
			DTCitizens.Columns.Add("birthday_month", typeof(int));
			DTCitizens.Columns.Add("birthday_day", typeof(int));

			DTCitizens.Columns.Add("observations", typeof(string));
			DTCitizens.Columns.Add("sex", typeof(TSex));
			DTCitizens.Columns.Add("sex_name", typeof(string));
			DTCitizens.Columns.Add("assistant_id", typeof(int));
			DTCitizens.Columns.Add("assistant_name", typeof(string));
			DTCitizens.Columns.Add("assistant_phone", typeof(string));
			DTCitizens.Columns.Add("assistant_phone_extension", typeof(string));
			DTCitizens.Columns.Add("assistant_phone_full", typeof(string));
			DTCitizens.Columns.Add("assistant_cellphone", typeof(string));
			DTCitizens.Columns.Add("phone", typeof(string));
			DTCitizens.Columns.Add("phone_extension", typeof(string));
			DTCitizens.Columns.Add("phone_full", typeof(string));
			DTCitizens.Columns.Add("cellphone", typeof(string));
			DTCitizens.Columns.Add("political_party", typeof(TPoliticalParty));
			DTCitizens.Columns.Add("political_party_name", typeof(string));

			DTCitizens.Columns.Add("institution_id", typeof(int));
			DTCitizens.Columns.Add("institution_name", typeof(string));
			DTCitizens.Columns.Add("institution_category_id", typeof(int));
			DTCitizens.Columns.Add("institution_category_name", typeof(string));
			DTCitizens.Columns.Add("institution_sector", typeof(TSocietySector));
			DTCitizens.Columns.Add("institution_sector_name", typeof(string));

			DTCitizens.Columns.Add("institution_role_id", typeof(int));
			DTCitizens.Columns.Add("institution_role_name", typeof(string));

			DTCitizens.Columns.Add("address_id", typeof(int));
			DTCitizens.Columns.Add("address_street", typeof(string));
			DTCitizens.Columns.Add("address_number", typeof(string));
			DTCitizens.Columns.Add("address_interior_number", typeof(string));
			DTCitizens.Columns.Add("address_postal_code", typeof(string));
			DTCitizens.Columns.Add("address_state", typeof(string));
			DTCitizens.Columns.Add("address_city", typeof(string));
			DTCitizens.Columns.Add("address_country", typeof(TCountry));
			DTCitizens.Columns.Add("address_country_name", typeof(string));

			DSCitizens.Tables.Add(DTCitizens);

			DataGridCitizens.DataSource = DSCitizens;
			DataGridCitizens.DataMember = "DTCitizens";
		}

		private void AddColumnToDataGrid(DataGridView data_grid, string col_name, string header_text, string data_property_name, bool visible = true, int display_index = 0, int width = 100, int min_width = 100, DataGridViewAutoSizeColumnMode auto_size_mode = DataGridViewAutoSizeColumnMode.None)
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

			//data_grid.Columns[col_name].DisplayIndex = display_index;
		}

		public void LoadPermissions()
		{
			BAdd.Visible = Session.HasPermission("Ciudadanos.Crear");
			BEdit.Visible = Session.HasPermission("Ciudadanos.Editar");
			BRead.Visible = Session.HasPermission("Ciudadanos.Consultar");
		}

		private void FCitizenList_Load(object sender, EventArgs e)
		{
			LoadPermissions();
			LoadList();
		}

		private void LoadList()
		{
			DTCitizens.BeginLoadData();
			DTCitizens.Clear();

			List<TCitizen> citizen_list;

			Error error = CitizensHandler.GetCitizens(out citizen_list);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			foreach (TCitizen citizen in citizen_list)
			{
				DataRow row = DTCitizens.NewRow();

				row["id"] = citizen.Id;
				row["name"] = citizen.Name;
				row["paternal_name"] = citizen.PaternalName;
				row["maternal_name"] = citizen.MaternalName;
				row["name_full"] = $"{citizen.Name} {citizen.PaternalName} {citizen.MaternalName}";
				row["title"] = citizen.Title;
				row["title_name"] = BConstants.GetCitizenBriefTitle(citizen.Title);
				row["curp"] = citizen.CURP;

				row["birthday"] = citizen.Birthday;
				row["birthday_year"] = citizen.Birthday.Year;
				row["birthday_month"] = citizen.Birthday.Month;
				row["birthday_day"] = citizen.Birthday.Day;
				
				row["observations"] = citizen.Observations;
				row["sex"] = citizen.Sex;
				row["sex_name"] = BConstants.GetSexName(citizen.Sex);

				if (citizen.Assistant.Id != 0)
				{
					row["assistant_id"] = citizen.Assistant.Id;
					row["assistant_name"] = $"{citizen.Assistant.Name} {citizen.Assistant.PaternalName} {citizen.Assistant.MaternalName}";
					row["assistant_phone"] = citizen.Assistant.Phone;
					row["assistant_phone_extension"] = citizen.Assistant.PhoneExtension;
					row["assistant_phone_full"] = $"{citizen.Assistant.Phone}" + (citizen.Assistant.PhoneExtension.Length > 0 ? $" Ext. {citizen.Assistant.PhoneExtension}" : "");
					row["assistant_cellphone"] = citizen.Assistant.Cellphone;
				}
				else
				{
					row["assistant_id"] = 0;
					row["assistant_name"] = "";
					row["assistant_phone"] = "";
					row["assistant_phone_extension"] = "";
					row["assistant_phone_full"] = "";
					row["assistant_cellphone"] = "";
				}

				row["phone"] = citizen.Phone;
				row["phone_extension"] = citizen.PhoneExtension;
				row["phone_full"] = $"{citizen.Phone}" + (citizen.PhoneExtension.Length > 0 ? $" Ext. {citizen.PhoneExtension}" : "");
				row["cellphone"] = citizen.Cellphone;
				row["political_party"] = citizen.PoliticalParty;
				row["political_party_name"] = BConstants.GetPoliticalPartyCommonName(citizen.PoliticalParty);

				row["institution_id"] = citizen.Institution.Id;
				row["institution_name"] = citizen.Institution.Name;
				row["institution_category_id"] = citizen.Institution.Category.Id;
				row["institution_category_name"] = citizen.Institution.Category.Name;
				row["institution_sector"] = citizen.Institution.Sector;
				row["institution_sector_name"] = BConstants.GetSocietySectorName(citizen.Institution.Sector);

				row["institution_role_id"] = citizen.Role.Id;
				row["institution_role_name"] = citizen.Role.Name;

				row["address_id"] = citizen.Address.Id;
				row["address_street"] = citizen.Address.Street;
				row["address_number"] = citizen.Address.Number;
				row["address_interior_number"] = citizen.Address.InteriorNumber;
				row["address_postal_code"] = citizen.Address.PostalCode;
				row["address_state"] = citizen.Address.State;
				row["address_city"] = citizen.Address.City;
				row["address_country"] = citizen.Address.Country;
				row["address_country_name"] = BConstants.GetCountryCommonName(citizen.Address.Country);

				DTCitizens.Rows.Add(row);
			}

			DTCitizens.EndLoadData();

			FilterList();

			DataGridCitizens.Refresh();
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FCitizenData citizen_data_dlg = new FCitizenData())
			{
				if (citizen_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private int GetSelectedCitizenId()
		{
			if (DataGridCitizens.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridCitizens.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCitizenId();

			if (id == 0)
			{
				return;
			}

			using (FCitizenData citizen_data_dlg = new FCitizenData())
			{
				citizen_data_dlg.SetAccessMode(FAccessMode.Update);
				citizen_data_dlg.SetId(id);

				if (citizen_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCitizenId();

			if (id == 0)
			{
				return;
			}

			using (FCitizenData citizen_data_dlg = new FCitizenData())
			{
				citizen_data_dlg.SetAccessMode(FAccessMode.Read);
				citizen_data_dlg.SetId(id);

				citizen_data_dlg.ShowDialog();
			}
		}

		public void UpdateStatusStrip()
		{
			// record count
			TSSLRecordCount.Text = $"Total: {DataGridCitizens.RowCount}";

			// the filters label
			string filtros = "";

			if (FiltersDlg.FilterCategory)
				filtros += $"Categoría = {FiltersDlg.CategoryId}, ";

			if (FiltersDlg.FilterInstitution)
				filtros += $"Institución = {FiltersDlg.InstitutionId}, "; // todo: make the institution and category not appear as Id but with his actual name

			if (FiltersDlg.FilterSector)
				filtros += $"Sector = {BConstants.GetSocietySectorName(FiltersDlg.Sector)}, ";

			if (FiltersDlg.FilterParty)
				filtros += $"Partido = {BConstants.GetPoliticalPartyCommonName(FiltersDlg.Party)}, ";

			if (FiltersDlg.FilterSex)
				filtros += $"Sexo = {BConstants.GetSexName(FiltersDlg.Sex)}, ";

			if (FiltersDlg.FilterCitizenTitle)
				filtros += $"Título = {BConstants.GetCitizenFullTitle(FiltersDlg.CitizenTitle)}, ";

			if (FiltersDlg.FilterBirthdayYear)
				filtros += $"Año Nac = {FiltersDlg.BirthdayYear}, ";

			if (FiltersDlg.FilterBirthdayMonth)
				filtros += $"Mes Nac = {DateTimeFormatInfo.CurrentInfo.MonthNames[FiltersDlg.BirthdayMonth - 1]}, ";

			if (FiltersDlg.FilterBirthdayDay)
				filtros += $"Día Nac = {FiltersDlg.BirthdayDay}, ";

			if (filtros.Length > 0)
			{
				TSSLFilters.Text = $"  Filtros: {filtros.TrimEnd(',',' ')}";
			}
			else
			{
				TSSLFilters.Text = "";
			}
		}

		private void FilterList()
		{
			string filter = "true";

			if (BSearch.Checked && TextBoxSearch.Text.Trim().Length > 0)
			{
				string search = TextBoxSearch.Text.Trim();

				filter += $" and (name_full like '%{search}%' OR title_name like '%{search}%' OR curp like '%{search}%' OR political_party_name like '%{search}%' OR institution_name like '%{search}%' OR institution_category_name like '%{search}%' OR institution_sector_name like '%{search}%')";
			}

			if (FiltersDlg.FilterSex)
				filter += $" and sex = {(int)FiltersDlg.Sex}";

			if (FiltersDlg.FilterParty)
				filter += $" and political_party = {(int)FiltersDlg.Party}";

			if (FiltersDlg.FilterCitizenTitle)
				filter += $" and title = {(int)FiltersDlg.CitizenTitle}";

			if (FiltersDlg.FilterInstitution)
				filter += $" and institution_id = {FiltersDlg.InstitutionId}";

			if (FiltersDlg.FilterSector)
				filter += $" and institution_sector = {(int)FiltersDlg.Sector}";

			if (FiltersDlg.FilterCategory)
				filter += $" and institution_category_id = {(int)FiltersDlg.CategoryId}";

			if (FiltersDlg.FilterBirthdayYear)
				filter += $" and birthday_year = {FiltersDlg.BirthdayYear}";

			if (FiltersDlg.FilterBirthdayMonth)
				filter += $" and birthday_month = {FiltersDlg.BirthdayMonth}";

			if (FiltersDlg.FilterBirthdayDay)
				filter += $" and birthday_day = {FiltersDlg.BirthdayDay}";

			DTCitizens.DefaultView.RowFilter = filter;

			DataGridCitizens.DataSource = DTCitizens;
			DataGridCitizens.Refresh();

			UpdateStatusStrip();
		}

		private void BFilter_Click(object sender, EventArgs e)
		{
			if (FiltersDlg.ShowDialog() == DialogResult.OK)
			{
				FilterList();
			}
		}

		private void TextBoxSearch_TextChanged(object sender, EventArgs e)
		{
			FilterList();
		}

		private void BSearch_Click(object sender, EventArgs e)
		{
			PanelSearch.Visible = BSearch.Checked;

			FilterList();
		}

		private void SetWorksheetHeaderCell(IXLWorksheet worksheet, int row, int col, string value, XLColor color = null, int width = 20)
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

		private void SetWorksheetCell(IXLWorksheet worksheet, int row, int col, string value, string number_format = null)
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

		private void FExcelExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog.DefaultExt = $".xlsx";
			SaveFileDialog.FileName = $"listado_ciudadanos_{DateTime.Now.ToString("yyyyMMdd")}";
			SaveFileDialog.Filter = $"Excel (*.xlsx) | Todos (*.*)";

			if (SaveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			try
			{
				using (var workbook = new XLWorkbook())
				{
					var worksheet = workbook.Worksheets.Add("Ciudadanos");

					// set the header column style
					XLColor headers_color = XLColor.LightGray;

					int row_index = 1;

					SetWorksheetHeaderCell(worksheet, 1, row_index++, "#", headers_color, 3);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Id", headers_color, 3);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Título", headers_color, 10);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Nombre", headers_color, 30);

					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Nacimiento", headers_color, 15);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Año Nacimiento", headers_color, 15);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Mes Nacimiento", headers_color, 15);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Día Nacimiento", headers_color, 15);

					SetWorksheetHeaderCell(worksheet, 1, row_index++, "CURP", headers_color, 30);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Teléfono", headers_color, 25);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Celular", headers_color, 20);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Partido", headers_color, 10);

					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Asistente", headers_color, 30);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Tel. Asistente", headers_color, 25);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Cel. Asistente", headers_color, 20);

					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Sector", headers_color, 10);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Categoría", headers_color, 20);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Institución", headers_color, 40);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Cargo", headers_color, 20);

					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Calle", headers_color, 35);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Número", headers_color, 15);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Número Interior", headers_color, 15);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Código Postal", headers_color, 15);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Estado", headers_color, 20);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "Ciudad", headers_color, 20);
					SetWorksheetHeaderCell(worksheet, 1, row_index++, "País", headers_color, 20);

					// fill the workseet
					for (int i = 0; i < DataGridCitizens.Rows.Count; i++)
					{
						DataGridViewRow row = DataGridCitizens.Rows[i];

						row_index = 1;

						SetWorksheetCell(worksheet, i + 2, row_index++, i.ToString());
						SetWorksheetCell(worksheet, i + 2, row_index++, ((int)row.Cells["colId"].Value).ToString());
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colTitleName"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colFullName"].Value);

						DateTime birthday = (DateTime)row.Cells["colBirthday"].Value;

						SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("yyyy/MM/dd"), "yyyy/MM/dd");
						SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("yyyy"));
						SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("MMMM"));
						SetWorksheetCell(worksheet, i + 2, row_index++, birthday.Day.ToString());

						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colCURP"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPhoneAndExtension"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colCellphone"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPoliticalPartyName"].Value);

						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantName"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantPhoneAndExtension"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantCellphone"].Value);

						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionSectorName"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionCategoryName"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionName"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionRoleName"].Value);

						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressStreet"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressNumber"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressInteriorNumber"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressPostalCode"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressState"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressCity"].Value);
						SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressCountryName"].Value);
					}

					workbook.SaveAs(SaveFileDialog.FileName);
				}
			}
			catch (Exception ex)
			{
				Utilities.ShowExceptionDialog(ex);
			}
		}

		private void BPrint_Click(object sender, EventArgs e)
		{
			try
			{
				R001 rep_001 = new R001()
				{
					InstitutionId = FiltersDlg.FilterInstitution ? FiltersDlg.InstitutionId : 0,
					InstitutionCategoryId = FiltersDlg.FilterCategory ? FiltersDlg.CategoryId : 0,
					PoliticalParty = FiltersDlg.FilterParty ? FiltersDlg.Party : null,
					Sex = FiltersDlg.FilterSex ? FiltersDlg.Sex : null,
					CitizenTitle = FiltersDlg.FilterCitizenTitle ? FiltersDlg.CitizenTitle : null,
					SocietySector = FiltersDlg.FilterSector ? FiltersDlg.Sector : null,
					BirthdayYear = FiltersDlg.FilterBirthdayYear ? FiltersDlg.BirthdayYear : null,
					BirthdayMonth = FiltersDlg.FilterBirthdayMonth ? FiltersDlg.BirthdayMonth : null,
					BirthdayDay = FiltersDlg.FilterBirthdayDay ? FiltersDlg.BirthdayDay : null,
				};

				rep_001.GeneratePdfAndShow();
			}
			catch (Exception ex)
			{
				Utilities.ShowExceptionDialog(ex);
			}
		}

		private void DataGridCitizens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			BRead_Click(this, null);
		}

		private void DataGridCitizens_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BRead_Click(this, null);
			}
		}

		private void FCitizenList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}
	}
}
