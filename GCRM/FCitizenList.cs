using Business;
using Business.Business;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using Reporter;
using System.Data;
using System.Globalization;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;
using System.Diagnostics;

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

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridCitizens, "colTitleName", "Título", "title_name", true, display_index++, 50, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colFullName", "Nombre completo", "name_full", true, display_index++, 250, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionName", "Institución", "institution_name", true, display_index++, 200, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionRoleName", "Cargo", "institution_role_name", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionCategoryName", "Categoría de institución", "institution_category_name", true, display_index++, 300, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionSectorName", "Sector", "institution_sector_name", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPhoneAndExtension", "Teléfono", "phone_full", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colCellphone", "Celular", "cellphone", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colBirthday", "Nacimiento", "birthday_displayed", false, display_index++, 20, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colBirthdayMonth", "Mes nacimiento", "birthday_month_name", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colBirthdayDay", "Día nacimiento", "birthday_day", true, display_index++, 20, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAuthorName", "Autor", "author_name", true, display_index++, 150, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colEditorName", "Último editor", "editor_name", true, display_index++, 150, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colVerified", "Verificado", "verified", true, display_index++, 80, 20, DataGridViewAutoSizeColumnMode.None, DataGridColumnType.CheckBox);
			DataGridUtilities.AddColumn(DataGridCitizens, "colVerifiedByName", "Verificado por", "verified_by_name", true, display_index++, 150, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colVerifiedDate", "Fecha verificación", "verified_at", true, display_index++, 100, 20);

			// hidden by default
			DataGridUtilities.AddColumn(DataGridCitizens, "colCategoryName", "Categoría", "category_name", false, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantName", "Asistente", "assistant_name", false, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colSexName", "Sexo", "sex_name", false, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPoliticalPartyName", "Partido", "political_party_name", false, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colCURP", "CURP", "curp", false, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colName", "Nombre", "name", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPaternalName", "Apellido paterno", "paternal_name", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colMaternalName", "Apellido materno", "maternal_name", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colObservations", "Observaciones", "observations", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantPhone", "Teléfono Asistente", "assistant_phone", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantPhoneExtension", "Extensión Teléfono Asistente", "assistant_phone_extension", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantPhoneAndExtension", "Tel. Asistente", "assistant_phone_full", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantCellphone", "Cel. Asistente", "assistant_cellphone", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAttentionRequired", "Atención requerida", "attention_required", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPhone2AndExtension", "Teléfono 2", "phone2_full", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPhone3AndExtension", "Teléfono 3", "phone3_full", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressStreet", "Calle", "address_street", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressNumber", "Número", "address_number", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressInteriorNumber", "Número interior", "address_interior_number", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressPostalCode", "Código postal", "address_postal_code", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressState", "Estado", "address_state", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressCity", "Ciudad", "address_city", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressCountryName", "País", "address_country_name", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution2Name", "Institución 2", "institution2_name", true, display_index++, 200, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution2RoleName", "Cargo 2", "institution2_role_name", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution3Name", "Institución 3", "institution3_name", true, display_index++, 200, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution3RoleName", "Cargo 3", "institution3_role_name", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colCreatedDate", "Fecha alta", "created_date", false, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colEditedDate", "Fecha edición", "edited_date", false, display_index++, 100, 20);

			// ids are less important for the users
			DataGridUtilities.AddColumn(DataGridCitizens, "colBirthdayRaw", "Nacimiento Crudo", "birthday", false, display_index++, 20, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colBirthdayKnown", "Nacimiento conocido", "birthday_known", false, display_index++, 20, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colBirthdayYearKnown", "Año nacimiento conocido", "birthday_year_known", false, display_index++, 20, 20);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressCountry", "Id país", "address_country", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionSector", "Id Sector", "institution_sector", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionCategoryId", "Id Categoría", "institution_category_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colPoliticalParty", "Id Partido", "political_party", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colId", "Id", "id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionId", "Id Institución", "institution_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitutionRoleId", "Id Cargo", "institution_role_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution2Id", "Id Institución 2", "institution2_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution2RoleId", "Id Cargo 2", "institution2_role_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution3Id", "Id Institución 3", "institution3_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colInstitution3RoleId", "Id Cargo 3", "institution3_role_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAddressId", "Id Dirección", "address_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colTitle", "Id Título", "title", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colSex", "Id Sexo", "sex", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAssistantId", "Id Asistente", "assistant_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colAuthorId", "Id Autor", "author_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colLastEditorId", "Id Último Editor", "editor_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colVerifiedById", "Id Verificado por", "verified_by_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridCitizens, "colCategoryId", "Categoría Id", "category_id", false, display_index++);


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
			DTCitizens.Columns.Add("birthday_displayed", typeof(string));
			DTCitizens.Columns.Add("birthday_year", typeof(int));
			DTCitizens.Columns.Add("birthday_month", typeof(int));
			DTCitizens.Columns.Add("birthday_month_name", typeof(string));
			DTCitizens.Columns.Add("birthday_day", typeof(int));
			DTCitizens.Columns.Add("birthday_known", typeof(bool));
			DTCitizens.Columns.Add("birthday_year_known", typeof(bool));

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
			DTCitizens.Columns.Add("phone2", typeof(string));
			DTCitizens.Columns.Add("phone2_extension", typeof(string));
			DTCitizens.Columns.Add("phone2_full", typeof(string));
			DTCitizens.Columns.Add("phone3", typeof(string));
			DTCitizens.Columns.Add("phone3_extension", typeof(string));
			DTCitizens.Columns.Add("phone3_full", typeof(string));
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

			DTCitizens.Columns.Add("institution2_id", typeof(int));
			DTCitizens.Columns.Add("institution2_name", typeof(string));
			DTCitizens.Columns.Add("institution2_role_id", typeof(int));
			DTCitizens.Columns.Add("institution2_role_name", typeof(string));

			DTCitizens.Columns.Add("institution3_id", typeof(int));
			DTCitizens.Columns.Add("institution3_name", typeof(string));
			DTCitizens.Columns.Add("institution3_role_id", typeof(int));
			DTCitizens.Columns.Add("institution3_role_name", typeof(string));

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
			DTCitizens.Columns.Add("created_date", typeof(DateTime));

			DTCitizens.Columns.Add("editor_id", typeof(int));
			DTCitizens.Columns.Add("editor_name", typeof(string));
			DTCitizens.Columns.Add("edited_date", typeof(DateTime));

			DTCitizens.Columns.Add("verified", typeof(bool));
			DTCitizens.Columns.Add("verified_by_id", typeof(int));
			DTCitizens.Columns.Add("verified_by_name", typeof(string));
			DTCitizens.Columns.Add("verified_at", typeof(DateTime));

			DTCitizens.Columns.Add("category_id", typeof(int));
			DTCitizens.Columns.Add("category_name", typeof(string));

			DTCitizens.Columns.Add("attention_required", typeof(bool));

			DSCitizens.Tables.Add(DTCitizens);

			DataGridCitizens.DataSource = DSCitizens;
			DataGridCitizens.DataMember = "DTCitizens";

			ColumnChooserDlg = new FColumnChooser(DataGridCitizens);

			LoadPermissions();
		}

		public void SetMode(FAccessMode mode)
		{
			Mode = mode;

			BEdit.Visible = Mode != FAccessMode.Select;
			BRead.Visible = Mode != FAccessMode.Select;
			BDelete.Visible = Mode != FAccessMode.Select;
			FExcelExport.Visible = Mode != FAccessMode.Select;
			BPrint.Visible = Mode != FAccessMode.Select;
			BAttentionRequired.Visible = Mode != FAccessMode.Select;
			BCategories.Visible = Mode != FAccessMode.Select;

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
			BAttentionRequired.Visible = Session.HasPermission("Ciudadanos.SetAttentionRequired");
			BExcelImport.Visible = Session.HasPermission("Ciudadanos.Excel.Import");

			Cursor.Current = Cursors.Default;
		}

		private void FCitizenList_Load(object sender, EventArgs e)
		{
			LoadList();

			SettingsUtilities.TryLoadFormConfiguration(this, "citizens\\main_form");
			DataGridUtilities.TryLoadConfiguration(DataGridCitizens, "citizens\\main_data_grid");
		}

		private void LoadList()
		{
			using (new CursorWait())
			{
				var stopwatch = Stopwatch.StartNew();

				DTCitizens.BeginLoadData();
				DTCitizens.Clear();

				List<TCitizen> citizen_list;

				Error error = CitizensHandler.GetCitizens(out citizen_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}
				
				bool display_upper = SettingsHandler.GetSetting<bool>("UI.DisplayUppercase", false);

				foreach (TCitizen citizen in citizen_list)
				{
					DataRow row = DTCitizens.NewRow();

					if (display_upper)
						citizen.PropertiesToUpper();

					row["id"] = citizen.Id;
					row["name"] = citizen.Name;
					row["paternal_name"] = citizen.PaternalName;
					row["maternal_name"] = citizen.MaternalName;
					row["name_full"] = $"{citizen.Name} {citizen.PaternalName} {citizen.MaternalName}";
					row["title"] = citizen.Title;
					row["title_name"] = BConstants.GetCitizenBriefTitle(citizen.Title, citizen.Sex);
					row["curp"] = citizen.CURP;

					row["birthday"] = citizen.Birthday;
					row["birthday_displayed"] = citizen.DisplayBirthday;
					row["birthday_year"] = citizen.Birthday.Year;
					row["birthday_month"] = citizen.Birthday.Month;
					string birthday_month_name = DateTimeFormatInfo.CurrentInfo.MonthNames[citizen.Birthday.Month - 1];
					row["birthday_month_name"] = birthday_month_name.ToUpper().First() + birthday_month_name.Substring(1);
					row["birthday_day"] = citizen.Birthday.Day;
					row["birthday_known"] = citizen.KnownBirthday;
					row["birthday_year_known"] = citizen.KnownBirthyear;

					row["observations"] = citizen.Observations;
					row["sex"] = citizen.Sex;
					row["sex_name"] = BConstants.GetSexName(citizen.Sex);

					if (citizen.Assistant.Id != 0)
					{
						row["assistant_id"] = citizen.Assistant.Id;
						row["assistant_name"] = $"{citizen.Assistant.Name} {citizen.Assistant.PaternalName} {citizen.Assistant.MaternalName}";
						row["assistant_phone"] = citizen.Assistant.Phone.Number;
						row["assistant_phone_extension"] = citizen.Assistant.Phone.Extension;
						row["assistant_phone_full"] = $"{citizen.Assistant.Phone.FullNumber}";
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

					row["phone"] = citizen.Phone.Number;
					row["phone_extension"] = citizen.Phone.Extension;
					row["phone_full"] = $"{citizen.Phone.FullNumber}";

					row["phone2"] = citizen.Phone2.Number;
					row["phone2_extension"] = citizen.Phone2.Extension;
					row["phone2_full"] = $"{citizen.Phone2.FullNumber}";

					row["phone3"] = citizen.Phone3.Number;
					row["phone3_extension"] = citizen.Phone3.Extension;
					row["phone3_full"] = $"{citizen.Phone3.FullNumber}";

					row["cellphone"] = citizen.Cellphone.FullNumber;
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

					row["institution2_id"] = citizen.Institution2.Id;
					row["institution2_name"] = citizen.Institution2.Name;
					row["institution2_role_id"] = citizen.Role2.Id;
					row["institution2_role_name"] = citizen.Role2.Name;

					row["institution3_id"] = citizen.Institution3.Id;
					row["institution3_name"] = citizen.Institution3.Name;
					row["institution3_role_id"] = citizen.Role3.Id;
					row["institution3_role_name"] = citizen.Role3.Name;

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
					row["created_date"] = citizen.CreatedDate;

					row["editor_id"] = citizen.LastEditor.Id;
					row["editor_name"] = citizen.LastEditor.Name;
					row["edited_date"] = citizen.EditDate;

					row["verified"] = citizen.Verified;
					row["verified_by_id"] = citizen.VerifiedBy.Id;
					row["verified_by_name"] = citizen.VerifiedBy.Name ?? "";
					row["verified_at"] = citizen.VerifiedAt;

					row["category_id"] = citizen.Category.Id;
					row["category_name"] = citizen.Category.Name;

					row["attention_required"] = citizen.AttentionRequired;

					if (display_upper)
					{
						row["title_name"] = row["title_name"].ToString().ToUpper();
					}

					DTCitizens.Rows.Add(row);
				}

				DTCitizens.EndLoadData();

				FilterList();

				DataGridCitizens.Refresh();

				stopwatch.Stop();

				//TSSLDebug.Text = $"time elapsed: {stopwatch.ElapsedMilliseconds} ms";
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

			// records that require attention
			int attentrion_required = 0;

			foreach (DataRow row in DTCitizens.Rows)
			{
				if ((bool)row["attention_required"])
					attentrion_required++;
			}

			TSSLRecordAttentionRequiredCount.Visible = attentrion_required > 0;
			TSSLRecordAttentionRequiredCount.Text = $"Atención requerida: {attentrion_required}";

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

			if (FiltersDlg.FilterStatus)
			{
				if (FiltersDlg.Status == 1)
				{
					filtros += $"Verificados, ";
				}
				else if (FiltersDlg.Status == 2)
				{
					filtros += $"No verificados, ";
				}
			}

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
			string search = TextBoxSearch.Text.Trim();

			if (BSearch.Checked && search.Length > 0)
			{
				filter += DataGridUtilities.GetFilterCondititonForTextSearch(DataGridCitizens, DTCitizens, search);
			}

			if (FiltersDlg.FilterSex)
				filter += $" and sex = {(int)FiltersDlg.Sex}";

			if (FiltersDlg.FilterParty)
				filter += $" and political_party = {(int)FiltersDlg.Party}";

			if (FiltersDlg.FilterCitizenTitle)
				filter += $" and title = {(int)FiltersDlg.CitizenTitle}";

			if (FiltersDlg.FilterInstitution)
				filter += $" and (institution_id = {FiltersDlg.InstitutionId} or institution2_id = {FiltersDlg.InstitutionId} or institution3_id = {FiltersDlg.InstitutionId})";

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

			if (FiltersDlg.FilterStatus)
			{
				if (FiltersDlg.Status == 1)
				{
					filter += $" and verified = true";
				}
				else if (FiltersDlg.Status == 2)
				{
					filter += $" and verified = false";
				}
			}

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

			if (BSearch.Checked)
				TextBoxSearch.Focus();

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
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Día Nacimiento", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Mes Nacimiento", headers_color, 15);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Año Nacimiento", headers_color, 15);

					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "CURP", headers_color, 30);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Teléfono", headers_color, 25);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Teléfono 2", headers_color, 25);
					ExcelUtilities.SetWorksheetHeaderCell(worksheet, 1, row_index++, "Teléfono 3", headers_color, 25);
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

						if ((bool)row.Cells["colBirthdayKnown"].Value)
						{
							DateTime birthday = (DateTime)row.Cells["colBirthdayRaw"].Value;

							if ((bool)row.Cells["colBirthdayYearKnown"].Value)
								ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("yyyy/MM/dd"), "yyyy/MM/dd");
							else
								ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("MM/dd"), "MM/dd");


							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.Day.ToString());
							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("MMMM"));

							if ((bool)row.Cells["colBirthdayYearKnown"].Value)
								ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, birthday.ToString("yyyy"));
							else
								row_index++;
						}
						else
							row_index += 4;

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colCURP"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPhoneAndExtension"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPhone2AndExtension"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPhone3AndExtension"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colCellphone"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colPoliticalPartyName"].Value);

						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantName"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantPhoneAndExtension"].Value);
						ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colAssistantCellphone"].Value);

						if ((int)row.Cells["colInstitutionId"].Value != 0)
						{
							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionSectorName"].Value);

							if ((int)row.Cells["colInstitutionCategoryId"].Value != 0)
								ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionCategoryName"].Value);
							else
								row_index ++;
							
							ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionName"].Value);

							if ((int)row.Cells["colInstitutionRoleId"].Value != 0)
							{
								ExcelUtilities.SetWorksheetCell(worksheet, i + 2, row_index++, (string)row.Cells["colInstitutionRoleName"].Value);
							}
							else
								row_index++;
						}
						else
							row_index += 4;

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
				using (new CursorWait())
				{
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
						Order = (FiltersDlg.FilterBirthdayDay || FiltersDlg.FilterBirthdayMonth) ? TR001Order.CitizenBirthday : TR001Order.CitizenName
					};

					rep_001.GeneratePdfAndShow();
				}
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
				Cellphone = new TCitizenContactNumber()
				{
					Number = (string)row.Cells["colCellphone"].Value
				}
			};

			//selected_citizen.Phone.Number = (string)row.Cells["colPhone"].Value;
			//selected_citizen.Phone.Extension = (string)row.Cells["colPhoneExtension"].Value;
			selected_citizen.Phone.Number = "";
			selected_citizen.Phone.Extension = "";

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

		private void BAttentionRequired_Click(object sender, EventArgs e)
		{
			if (DataGridCitizens.SelectedRows.Count == 0)
			{
				return;
			}

			DataGridViewRow row = DataGridCitizens.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			bool attentionRequired = !(bool)row.Cells["colAttentionRequired"].Value;

			using (new CursorWait())
			{
				Error error = CitizensHandler.SetCitizenAttentionRequired(id, attentionRequired);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}
			}

			// update the data manually as the grid is not updated and doing it may take a long time
			row.Cells["colAttentionRequired"].Value = attentionRequired;

			DataGridCitizens.InvalidateRow(row.Index);

			UpdateStatusStrip();
		}

		private void DataGridCitizens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridViewRow row = DataGridCitizens.Rows[e.RowIndex];

			if (row.Cells["colAttentionRequired"].Value == null)
				return;

			if ((bool)row.Cells["colAttentionRequired"].Value)
			{
				e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
				e.CellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 150, 150);
			}
		}

		private void FCitizenList_FormClosing(object sender, FormClosingEventArgs e)
		{
			DataGridUtilities.TrySaveConfiguration(DataGridCitizens, "citizens\\main_data_grid");
			SettingsUtilities.TrySaveFormConfiguration(this, "citizens\\main_form");
		}

		private void BExcelImport_Click(object sender, EventArgs e)
		{
			using (var import_dlg = new FCitizenListImportExcel())
			{
				import_dlg.ShowDialog();
			}
		}
	}
}
