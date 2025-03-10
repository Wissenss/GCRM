using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FCitizenListFilters : Form
	{
		public bool FilterParty;
		public TPoliticalParty Party;
		public bool FilterSex;
		public TSex Sex;
		public bool FilterCitizenTitle;
		public TCitizenTitle CitizenTitle;
		public bool FilterInstitution;
		public int InstitutionId;
		public bool FilterSector;
		public TSocietySector Sector;
		public bool FilterCategory;
		public int CategoryId;
		public bool FilterBirthdayYear;
		public int BirthdayYear = DateTime.Now.Year;
		public bool FilterBirthdayMonth;
		public int BirthdayMonth = DateTime.Now.Month;
		public bool FilterBirthdayDay;
		public int BirthdayDay = DateTime.Now.Day;

		DataSet DSFilters;
		DataTable DTYears;
		DataTable DTMonths;
		DataTable DTDays;

		public FCitizenListFilters()
		{
			InitializeComponent();

			Cursor.Current = Cursors.WaitCursor;

			// load the datasource
			Catalogs.LoadDTInstitutions();
			Catalogs.LoadDTInstitutionCategories();

			DSFilters = new DataSet();

			DTYears = new DataTable("DTYears");
			DTYears.Columns.Add("value", typeof(int));
			DSFilters.Tables.Add(DTYears);

			DTMonths = new DataTable("DTMonths");
			DTMonths.Columns.Add("value", typeof(int));
			DTMonths.Columns.Add("text", typeof(string));
			DSFilters.Tables.Add(DTMonths);

			DTDays = new DataTable("DTDays");
			DTDays.Columns.Add("value", typeof(int));
			DSFilters.Tables.Add(DTDays);

			LoadDTYears();
			LoadDTMonths();
			LoadDTDays();

			// bind the comboboxes
			ComboBoxCitizenTitle.DataSource = Catalogs.DTCitizenTitles;
			ComboBoxCitizenTitle.ValueMember = "value";
			ComboBoxCitizenTitle.DisplayMember = "text";

			ComboBoxPoliticalParty.DataSource = Catalogs.DTPoliticalParties;
			ComboBoxPoliticalParty.ValueMember = "value";
			ComboBoxPoliticalParty.DisplayMember = "text";

			ComboBoxSex.DataSource = Catalogs.DTSex;
			ComboBoxSex.ValueMember = "value";
			ComboBoxSex.DisplayMember = "text";

			ComboBoxInstitucion.DataSource = Catalogs.DTInstitutions;
			ComboBoxInstitucion.ValueMember = "id";
			ComboBoxInstitucion.DisplayMember = "name";

			ComboBoxSector.DataSource = Catalogs.DTSocietySector;
			ComboBoxSector.ValueMember = "value";
			ComboBoxSector.DisplayMember = "text";

			ComboBoxCategory.DataSource = Catalogs.DTInstitutionCategories;
			ComboBoxCategory.ValueMember = "id";
			ComboBoxCategory.DisplayMember = "name";

			ComboBoxBirthdayYear.DataSource = DTYears;
			ComboBoxBirthdayYear.ValueMember = "value";
			ComboBoxBirthdayYear.DisplayMember = "value";

			ComboBoxBirthdayMonth.DataSource = DTMonths;
			ComboBoxBirthdayMonth.ValueMember = "value";
			ComboBoxBirthdayMonth.DisplayMember = "text";

			ComboBoxBirthdayDay.DataSource = DTDays;
			ComboBoxBirthdayDay.ValueMember = "value";
			ComboBoxBirthdayDay.DisplayMember = "value";

			Cursor.Current = Cursors.Default;
		}

		private void LoadDTYears()
		{
			int start_year = 1950;

			DTYears.BeginLoadData();
			DTYears.Clear();

			for (int i = start_year; i <= DateTime.Now.Year; i++)
			{
				DataRow row = DTYears.NewRow();

				row["value"] = i;

				DTYears.Rows.Add(row);
			}

			DTYears.EndLoadData();
		}

		private void LoadDTMonths()
		{
			DTMonths.BeginLoadData();
			DTMonths.Clear();

			for (int i = 1; i <= 12; i++)
			{
				DataRow row = DTMonths.NewRow();

				row["value"] = i;
				row["text"] = DateTimeFormatInfo.CurrentInfo.MonthNames[i - 1];

				DTMonths.Rows.Add(row);
			}

			DTMonths.EndLoadData();
		}

		private void LoadDTDays()
		{
			DTDays.BeginLoadData();
			DTDays.Clear();

			for (int i = 1; i <= 31; i++)
			{
				DataRow row = DTDays.NewRow();

				row["value"] = i;

				DTDays.Rows.Add(row);
			}

			DTDays.EndLoadData();
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (CheckBoxFilterInstitution.Checked && ComboBoxInstitucion.SelectedValue == null)
			{
				errors.AppendLine("Debe especificar la institución a filtrar");
			}

			if (CheckBoxFilterSector.Checked && ComboBoxSector.SelectedValue == null)
			{
				errors.AppendLine("Debe especificar el sector a filtrar");
			}

			if (CheckBoxFilterCategory.Checked && ComboBoxCategory.SelectedValue == null)
			{
				errors.AppendLine("Debe especificar la categoría a filtrar");
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
			{
				return;
			}

			FilterCitizenTitle = CheckBoxFilterTitle.Checked;
			CitizenTitle = (TCitizenTitle)ComboBoxCitizenTitle.SelectedValue;

			FilterSex = CheckBoxFilterSex.Checked;
			Sex = (TSex)ComboBoxSex.SelectedValue;

			FilterParty = CheckBoxFilterParty.Checked;
			Party = (TPoliticalParty)ComboBoxPoliticalParty.SelectedValue;

			FilterInstitution = CheckBoxFilterInstitution.Checked;
			if (ComboBoxInstitucion.SelectedValue != null)
				InstitutionId = (int)ComboBoxInstitucion.SelectedValue;

			FilterSector = CheckBoxFilterSector.Checked;
			if (ComboBoxSector.SelectedValue != null)
				Sector = (TSocietySector)ComboBoxSector.SelectedValue;

			FilterCategory = CheckBoxFilterCategory.Checked;
			if (ComboBoxCategory.SelectedValue != null)
				CategoryId = (int)ComboBoxCategory.SelectedValue;

			FilterBirthdayYear = CheckBoxFilterBirthdayYear.Checked;
			BirthdayYear = (int)ComboBoxBirthdayYear.SelectedValue;

			FilterBirthdayMonth = CheckBoxFilterBirthdayMonth.Checked;
			BirthdayMonth = (int)ComboBoxBirthdayMonth.SelectedValue;

			FilterBirthdayDay = CheckBoxFilterBirthdayDay.Checked;
			BirthdayDay = (int)ComboBoxBirthdayDay.SelectedValue;

			DialogResult = DialogResult.OK;
		}

		private void FCitizenListFilters_Shown(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			CheckBoxFilterTitle.Checked = FilterCitizenTitle;
			ComboBoxCitizenTitle.SelectedValue = CitizenTitle;
			CheckBoxFilterParty.Checked = FilterParty;
			ComboBoxPoliticalParty.SelectedValue = Party;
			CheckBoxFilterSex.Checked = FilterSex;
			ComboBoxSex.SelectedValue = Sex;
			CheckBoxFilterInstitution.Checked = FilterInstitution;
			ComboBoxInstitucion.SelectedValue = InstitutionId;
			CheckBoxFilterSector.Checked = FilterSector;
			ComboBoxSector.SelectedValue = Sector;
			CheckBoxFilterCategory.Checked = FilterCategory;
			ComboBoxCategory.SelectedValue = CategoryId;
			ComboBoxBirthdayYear.SelectedValue = BirthdayYear;
			ComboBoxBirthdayMonth.SelectedValue = BirthdayMonth;
			ComboBoxBirthdayDay.SelectedValue = BirthdayDay;

			Cursor.Current = Cursors.Default;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void CheckBoxFilterInstitution_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxInstitucion.Enabled = CheckBoxFilterInstitution.Checked;
		}

		private void CheckBoxFilterSector_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxSector.Enabled = CheckBoxFilterSector.Checked;
		}

		private void CheckBoxFilterCategory_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxCategory.Enabled = CheckBoxFilterCategory.Checked;
		}

		private void CheckBoxFilterBirthdayYear_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxBirthdayYear.Enabled = CheckBoxFilterBirthdayYear.Checked;
		}

		private void CheckBoxBirthdayMonth_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxBirthdayMonth.Enabled = CheckBoxFilterBirthdayMonth.Checked;
		}

		private void CheckBoxBirthdayDay_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxBirthdayDay.Enabled = CheckBoxFilterBirthdayDay.Checked;
		}

		private void CheckBoxFilterParty_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxPoliticalParty.Enabled = CheckBoxFilterParty.Checked;
		}

		private void CheckBoxFilterSex_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxSex.Enabled = CheckBoxFilterSex.Checked;
		}

		private void CheckBoxFilterTitle_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxCitizenTitle.Enabled = CheckBoxFilterTitle.Checked;
		}
	}
}
