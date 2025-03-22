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
		FColumnChooser ColumnChooserDlg;

		FAccessMode Mode = FAccessMode.Update;

		public FCitizenList()
		{
			InitializeComponent();

			DataGridCitizens.AutoGenerateColumns = false;

			// DataGridCitizensColumns
			DataGridUtilities.AddColumn(DataGridCitizens, "colId", "Id", "id", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colTitle", "Id Título", "title", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colName", "Nombre", "name", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPaternalName", "Apellido paterno", "paternal_name", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colMaternalName", "Apellido materno", "maternal_name", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colObservations", "Observaciones", "observations", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colSex", "Id Sexo", "sex", false);

			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantId", "Id Asistente", "assistant_id", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantPhone", "Teléfono Asistente", "assistant_phone", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantPhoneExtension", "Extensión Teléfono Asistente", "assistant_phone_extension", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantPhoneAndExtension", "Tel. Asistente", "assistant_phone_full", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantCellphone", "Cel. Asistente", "assistant_cellphone", false);

			DataGridUtilities.AddColumn(DataGridCitizens, "colPhone", "Teléfono", "phone", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPoliticalParty", "Id Partido", "political_party", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPhoneExtension", "Extensión Teléfono", "phone_extension", false);

			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionId", "Id Institución", "institution_id", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionCategoryId", "Id Categoría", "institution_category_id", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionSector", "Id Sector", "institution_sector", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionRoleId", "Id Cargo", "institution_role_id", false);

			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressId", "Id Dirección", "address_id", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressStreet", "Calle", "address_street", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressNumber", "Número", "address_number", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressInteriorNumber", "Número interior", "address_interior_number", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressPostalCode", "Código postal", "address_postal_code", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressState", "Estado", "address_state", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressCity", "Ciudad", "address_city", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressCountry", "Id país", "address_country", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressCountryName", "País", "address_country_name", false);

			DataGridUtilities.AddColumn(DataGridCitizens, "colAuthorId", "Id Autor", "author_id", false);
			DataGridUtilities.AddColumn(DataGridCitizens, "colLastEditorId", "Id Último Editor", "editor_id", false);

			DataGridUtilities.AddColumn(DataGridCitizens, "colCategoryId", "Categoría Id", "category_id", false);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridCitizens, "colTitleName", "Título", "title_name", true, display_index++, 20, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colFullName", "Nombre", "name_full", true, display_index++, 250, 250, DataGridViewAutoSizeColumnMode.Fill);
			DataGridUtilities.AddColumn(DataGridCitizens, "colCategoryName", "Categoría", "category_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionName", "Institución", "institution_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionRoleName", "Cargo", "institution_role_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionCategoryName", "Categoría de institución", "institution_category_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionSectorName", "Sector", "institution_sector_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPhoneAndExtension", "Teléfono", "phone_full", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colCellphone", "Celular", "cellphone", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantName", "Asistente", "assistant_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colSexName", "Sexo", "sex_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPoliticalPartyName", "Partido", "political_party_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colBirthday", "Nacimiento", "birthday", false, display_index++, 20, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colCURP", "CURP", "curp", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAuthorName", "Autor", "author_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizens, "colEditorName", "Último editor", "editor_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);

			DataGridCitizens.AllowUserToResizeColumns = true;
			DataGridCitizens.AllowUserToOrderColumns = true;

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

			DTCitizens.Columns.Add("author_id", typeof(int));
			DTCitizens.Columns.Add("author_name", typeof(string));

			DTCitizens.Columns.Add("editor_id", typeof(int));
			DTCitizens.Columns.Add("editor_name", typeof(string));

			DTCitizens.Columns.Add("category_id", typeof(int));
			DTCitizens.Columns.Add("category_name", typeof(string));


			DSCitizens.Tables.Add(DTCitizens);

			DataGridCitizens.DataSource = DSCitizens;
			DataGridCitizens.DataMember = "DTCitizens";

			ColumnChooserDlg = new FColumnChooser(DataGridCitizens);

			LoadPermissions();
		}

		public void SetMode(FAccessMode mode)
		{
			Mode = mode;

			//BAdd.Visible = Mode != FAccessMode.Select;
			BEdit.Visible = Mode != FAccessMode.Select;
			BRead.Visible = Mode != FAccessMode.Select;
			BDelete.Visible = Mode != FAccessMode.Select;
			FExcelExport.Visible = Mode != FAccessMode.Select;
			BPrint.Visible = Mode != FAccessMode.Select;

			BSelect.Visible = Mode == FAccessMode.Select;

			ToolStrip.Refresh();
		}

		public void LoadPermissions()
		{
			Cursor.Current = Cursors.WaitCursor;

			BAdd.Visible = Session.HasPermission("Ciudadanos.Crear");
			BEdit.Visible = Session.HasPermission("Ciudadanos.Editar");
			BRead.Visible = Session.HasPermission("Ciudadanos.Consultar");
			BDelete.Visible = Session.HasPermission("Ciudadanos.Eliminar");
			BCategories.Visible = Session.HasPermission("Ciudadanos.Categorias.Consultar");

			Cursor.Current = Cursors.Default;
		}

		private void FCitizenList_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void LoadList()
		{
			using (new CursorWait())
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

					row["author_id"] = citizen.Author.Id;
					row["author_name"] = citizen.Author.Name;

					row["editor_id"] = citizen.LastEditor.Id;
					row["editor_name"] = citizen.LastEditor.Name;

					row["category_id"] = citizen.Category.Id;
					row["category_name"] = citizen.Category.Name;

					DTCitizens.Rows.Add(row);
				}

				DTCitizens.EndLoadData();

				FilterList();

				DataGridCitizens.Refresh();
			}
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
			Cursor.Current = Cursors.WaitCursor;
			LoadList();
			Cursor.Current = Cursors.Default;
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

			if (FiltersDlg.FilterInstitutionCategory)
				filtros += $"Categoría de institución = {FiltersDlg.InstitutionCategoryId}, ";

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

			if (FiltersDlg.FilterCategory)
				filtros += $"Categoría = {FiltersDlg.CategoryId}, ";

			if (filtros.Length > 0)
			{
				TSSLFilters.Text = $"  Filtros: {filtros.TrimEnd(',', ' ')}";
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

			if (FiltersDlg.FilterInstitutionCategory)
				filter += $" and institution_category_id = {(int)FiltersDlg.InstitutionCategoryId}";

			if (FiltersDlg.FilterBirthdayYear)
				filter += $" and birthday_year = {FiltersDlg.BirthdayYear}";

			if (FiltersDlg.FilterBirthdayMonth)
				filter += $" and birthday_month = {FiltersDlg.BirthdayMonth}";

			if (FiltersDlg.FilterBirthdayDay)
				filter += $" and birthday_day = {FiltersDlg.BirthdayDay}";

			if (FiltersDlg.FilterCategory)
				filter += $" and category_id = {FiltersDlg.CategoryId}";

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
				using (new CursorWait())
				using (var workbook = new XLWorkbook())
				{
					var worksheet = workbook.Worksheets.Add("Ciudadanos");

					// set the header column style
					XLColor headers_color = XLColor.LightGray;

					int row_index = 1;

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "#", headers_color, 3);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Id", headers_color, 3);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Título", headers_color, 10);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Nombre", headers_color, 30);

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Nacimiento", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Año Nacimiento", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Mes Nacimiento", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Día Nacimiento", headers_color, 15);

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "CURP", headers_color, 30);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Teléfono", headers_color, 25);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Celular", headers_color, 20);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Partido", headers_color, 10);

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Asistente", headers_color, 30);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Tel. Asistente", headers_color, 25);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Cel. Asistente", headers_color, 20);

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Sector", headers_color, 10);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Categoría", headers_color, 20);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Institución", headers_color, 40);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Cargo", headers_color, 20);

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Calle", headers_color, 35);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Número", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Número Interior", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Código Postal", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Estado", headers_color, 20);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Ciudad", headers_color, 20);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "País", headers_color, 20);

					// fill the workseet
					for (int i = 0; i < DataGridCitizens.Rows.Count; i++)
					{
						DataGridViewRow row = DataGridCitizens.Rows[i];

						row_index = 1;

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, i.ToString());
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, ((int)row.Cells["colId"].Value).ToString());
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colTitleName"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colFullName"].Value);

						DateTime birthday = (DateTime)row.Cells["colBirthday"].Value;

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("yyyy/MM/dd"), "yyyy/MM/dd");
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("yyyy"));
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("MMMM"));
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.Day.ToString());

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colCURP"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPhoneAndExtension"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colCellphone"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPoliticalPartyName"].Value);

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantName"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantPhoneAndExtension"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantCellphone"].Value);

						if ((int)row.Cells["colInstitutionId"].Value != 0)
						{
							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionSectorName"].Value);
							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionCategoryName"].Value);
							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionName"].Value);
							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionRoleName"].Value);
						}

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressStreet"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressNumber"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressInteriorNumber"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressPostalCode"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressState"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressCity"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAddressCountryName"].Value);
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
				Cursor.Current = Cursors.WaitCursor;

				R001 rep_001 = new R001()
				{
					InstitutionId = FiltersDlg.FilterInstitution ? FiltersDlg.InstitutionId : 0,
					InstitutionCategoryId = FiltersDlg.FilterInstitutionCategory ? FiltersDlg.InstitutionCategoryId : 0,
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
			finally
			{
				Cursor.Current = Cursors.Default;
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

		private void BDelete_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCitizenId();

			DialogResult result = MessageBox.Show(
				"¿Está seguro de que desea eliminar el ciudadano?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning
				);

			if (result != DialogResult.Yes || id == 0)

			{
				return;
			}

			Error error = CitizensHandler.DeleteCitizenById(id);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			LoadList();
		}

		private void BSelect_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		public TCitizen GetSelectedCitizen()
		{
			if (DataGridCitizens.SelectedRows.Count == 0)
			{
				return null;
			}

			DataGridViewRow row = DataGridCitizens.SelectedRows[0];

			TCitizen selected_citizen = new TCitizen()
			{
				Id = (int)row.Cells["colId"].Value,
				Name = (string)row.Cells["colName"].Value,
				PaternalName = (string)row.Cells["colPaternalName"].Value,
				MaternalName = (string)row.Cells["colMaternalName"].Value,
				Phone = (string)row.Cells["colPhone"].Value,
				PhoneExtension = (string)row.Cells["colPhoneExtension"].Value,
				Cellphone = (string)row.Cells["colCellphone"].Value
			};

			return selected_citizen;
		}

		private void BCategories_Click(object sender, EventArgs e)
		{
			using (FCitizenCategoryList citizen_category_list = new FCitizenCategoryList())
			{
				citizen_category_list.ShowDialog();
			}

			LoadList();
		}

		private void BFields_Click(object sender, EventArgs e)
		{
			ColumnChooserDlg.ShowDialog();
		}
	}
}
