using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;
using QuestPDF.Fluent;
using Reporter;
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
    public partial class FReport001 : Form
    {
        DataSet DSFilters;
        DataTable DTCitizenTitles;
        DataTable DTSex;
        DataTable DTParties;
        DataTable DTInstitutions;
        DataTable DTInstitutionCategories;
        DataTable DTSectors;
        DataTable DTBirthdayYears;
        DataTable DTBirthdayMonths;
        DataTable DTBirthdayDays;

        public FReport001()
        {
            InitializeComponent();

            DSFilters = new DataSet();

            DTCitizenTitles = new DataTable();
            DTCitizenTitles.Columns.Add("value", typeof(int));
            DTCitizenTitles.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTCitizenTitles);

            DTSex = new DataTable();
            DTSex.Columns.Add("value", typeof(int));
            DTSex.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTSex);

            DTParties = new DataTable();
            DTParties.Columns.Add("value", typeof(int));
            DTParties.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTParties);

            DTInstitutions = new DataTable();
            DTInstitutions.Columns.Add("id", typeof(int));
            DTInstitutions.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTInstitutions);

            DTInstitutionCategories = new DataTable();
            DTInstitutionCategories.Columns.Add("id", typeof(int));
            DTInstitutionCategories.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTInstitutionCategories);

            DTSectors = new DataTable();
            DTSectors.Columns.Add("value", typeof(int));
            DTSectors.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTSectors);

            DTBirthdayYears = new DataTable();
            DTBirthdayYears.Columns.Add("value", typeof(int));
            DTBirthdayYears.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTBirthdayYears);

            DTBirthdayMonths = new DataTable();
            DTBirthdayMonths.Columns.Add("value", typeof(int));
            DTBirthdayMonths.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTBirthdayMonths);

            DTBirthdayDays = new DataTable();
            DTBirthdayDays.Columns.Add("value", typeof(int));
            DTBirthdayDays.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTBirthdayDays);
        }

        private void LoadCatalogs()
        {
            using (new CursorWait())
            {
                DTCitizenTitles.BeginLoadData();
                DTCitizenTitles.Clear();
                foreach (TCitizenTitle title in Enum.GetValues(typeof(TCitizenTitle)))
                    AddRow(DTCitizenTitles, (int)title, BConstants.GetCitizenFullTitle(title));
                DTCitizenTitles.EndLoadData();

                CitizenTitle.DataSource = DTCitizenTitles;
                CitizenTitle.ValueMember = "value";
                CitizenTitle.DisplayMember = "name";
                CitizenTitle.SelectedIndex = 0;

                DTSex.BeginLoadData();
                DTSex.Clear();
                foreach (TSex sex in Enum.GetValues(typeof(TSex)))
                    AddRow(DTSex, (int)sex, BConstants.GetSexName(sex));
                DTSex.EndLoadData();

                Sex.DataSource = DTSex;
                Sex.ValueMember = "value";
                Sex.DisplayMember = "name";
                Sex.SelectedIndex = 0;

                DTParties.BeginLoadData();
                DTParties.Clear();
                foreach (TPoliticalParty party in Enum.GetValues(typeof(TPoliticalParty)))
                    AddRow(DTParties, (int)party, BConstants.GetPoliticalPartyCommonName(party));
                DTParties.EndLoadData();

                Party.DataSource = DTParties;
                Party.ValueMember = "value";
                Party.DisplayMember = "name";
                Party.SelectedIndex = 0;

                Error error = InstitutionsHandler.GetInstitutions(out List<TInstitution> institution_list);

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTInstitutions.BeginLoadData();
                DTInstitutions.Clear();
                foreach (TInstitution institution in institution_list)
                    AddRow(DTInstitutions, institution.Id, institution.Name, "id");
                DTInstitutions.EndLoadData();

                Institution.DataSource = DTInstitutions;
                Institution.ValueMember = "id";
                Institution.DisplayMember = "name";

                if (DTInstitutions.Rows.Count > 0)
                    Institution.SelectedIndex = 0;

                error = InstitutionsHandler.GetInstitutionCategories(out List<TInstitutionCategory> category_list);

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTInstitutionCategories.BeginLoadData();
                DTInstitutionCategories.Clear();
                foreach (TInstitutionCategory category in category_list)
                    AddRow(DTInstitutionCategories, category.Id, category.Name, "id");
                DTInstitutionCategories.EndLoadData();

                InstitutionCategory.DataSource = DTInstitutionCategories;
                InstitutionCategory.ValueMember = "id";
                InstitutionCategory.DisplayMember = "name";

                if (DTInstitutionCategories.Rows.Count > 0)
                    InstitutionCategory.SelectedIndex = 0;

                DTSectors.BeginLoadData();
                DTSectors.Clear();
                foreach (TSocietySector sector in Enum.GetValues(typeof(TSocietySector)))
                    AddRow(DTSectors, (int)sector, BConstants.GetSocietySectorName(sector));
                DTSectors.EndLoadData();

                Sector.DataSource = DTSectors;
                Sector.ValueMember = "value";
                Sector.DisplayMember = "name";
                Sector.SelectedIndex = 0;

                DTBirthdayYears.BeginLoadData();
                DTBirthdayYears.Clear();
                for (int year = 1950; year <= DateTime.Now.Year; year++)
                    AddRow(DTBirthdayYears, year, year.ToString());
                DTBirthdayYears.EndLoadData();

                BirthdayYear.DataSource = DTBirthdayYears;
                BirthdayYear.ValueMember = "value";
                BirthdayYear.DisplayMember = "name";
                BirthdayYear.SelectedValue = DateTime.Now.Year;

                DTBirthdayMonths.BeginLoadData();
                DTBirthdayMonths.Clear();
                for (int month = 1; month <= 12; month++)
                    AddRow(DTBirthdayMonths, month, DateTimeFormatInfo.CurrentInfo.MonthNames[month - 1]);
                DTBirthdayMonths.EndLoadData();

                BirthdayMonth.DataSource = DTBirthdayMonths;
                BirthdayMonth.ValueMember = "value";
                BirthdayMonth.DisplayMember = "name";
                BirthdayMonth.SelectedValue = DateTime.Now.Month;

                DTBirthdayDays.BeginLoadData();
                DTBirthdayDays.Clear();
                for (int day = 1; day <= 31; day++)
                    AddRow(DTBirthdayDays, day, day.ToString());
                DTBirthdayDays.EndLoadData();

                BirthdayDay.DataSource = DTBirthdayDays;
                BirthdayDay.ValueMember = "value";
                BirthdayDay.DisplayMember = "name";
                BirthdayDay.SelectedValue = DateTime.Now.Day;
            }
        }

        private void AddRow(DataTable table, int value, string name, string value_column = "value")
        {
            DataRow row = table.NewRow();

            row[value_column] = value;
            row["name"] = name;

            table.Rows.Add(row);
        }

        private void FReport001_Load(object sender, EventArgs e)
        {
            LoadCatalogs();
        }

        private void CheckBoxFilterCitizenTitle_CheckedChanged(object sender, EventArgs e)
        {
            CitizenTitle.Enabled = CheckBoxFilterCitizenTitle.Checked;
        }

        private void CheckBoxFilterSex_CheckedChanged(object sender, EventArgs e)
        {
            Sex.Enabled = CheckBoxFilterSex.Checked;
        }

        private void CheckBoxFilterParty_CheckedChanged(object sender, EventArgs e)
        {
            Party.Enabled = CheckBoxFilterParty.Checked;
        }

        private void CheckBoxFilterInstitution_CheckedChanged(object sender, EventArgs e)
        {
            Institution.Enabled = CheckBoxFilterInstitution.Checked;
        }

        private void CheckBoxFilterInstitutionCategory_CheckedChanged(object sender, EventArgs e)
        {
            InstitutionCategory.Enabled = CheckBoxFilterInstitutionCategory.Checked;
        }

        private void CheckBoxFilterSector_CheckedChanged(object sender, EventArgs e)
        {
            Sector.Enabled = CheckBoxFilterSector.Checked;
        }

        private void CheckBoxFilterBirthdayYear_CheckedChanged(object sender, EventArgs e)
        {
            BirthdayYear.Enabled = CheckBoxFilterBirthdayYear.Checked;
        }

        private void CheckBoxFilterBirthdayMonth_CheckedChanged(object sender, EventArgs e)
        {
            BirthdayMonth.Enabled = CheckBoxFilterBirthdayMonth.Checked;
        }

        private void CheckBoxFilterBirthdayDay_CheckedChanged(object sender, EventArgs e)
        {
            BirthdayDay.Enabled = CheckBoxFilterBirthdayDay.Checked;
        }

        private bool TryBuildReport(out R001 report)
        {
            int? birthday_month = CheckBoxFilterBirthdayMonth.Checked ? (int)BirthdayMonth.SelectedValue : null;
            int? birthday_day = CheckBoxFilterBirthdayDay.Checked ? (int)BirthdayDay.SelectedValue : null;

            report = new R001()
            {
                InstitutionId = CheckBoxFilterInstitution.Checked ? (int)Institution.SelectedValue : 0,
                InstitutionCategoryId = CheckBoxFilterInstitutionCategory.Checked ? (int)InstitutionCategory.SelectedValue : 0,
                CitizenTitle = CheckBoxFilterCitizenTitle.Checked ? (TCitizenTitle)CitizenTitle.SelectedValue : null,
                Sex = CheckBoxFilterSex.Checked ? (TSex)Sex.SelectedValue : null,
                PoliticalParty = CheckBoxFilterParty.Checked ? (TPoliticalParty)Party.SelectedValue : null,
                SocietySector = CheckBoxFilterSector.Checked ? (TSocietySector)Sector.SelectedValue : null,
                BirthdayYear = CheckBoxFilterBirthdayYear.Checked ? (int)BirthdayYear.SelectedValue : null,
                BirthdayMonth = birthday_month,
                BirthdayDay = birthday_day,
                Order = (birthday_month != null || birthday_day != null) ? TR001Order.CitizenBirthday : TR001Order.CitizenName
            };

            Error error = report.PrepareReport();

            if (error != Error.None)
            {
                Utilities.ShowErrorDialog(error);
                return false;
            }

            return true;
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BGenerate_Click(object sender, EventArgs e)
        {
            if (TryBuildReport(out R001 report))
            {
                if (SettingsUtilities.LoadInstanceConfiguration().UseExternalPDFViewer)
                {
                    report.RDocument.GeneratePdfAndShow();
                }
                else
                {
                    using (FDocumentViewer viewer = new FDocumentViewer())
                    {
                        viewer.PrintSettings.Landscape = false;
                        viewer.LoadDocument(report.RDocument);
                        viewer.ShowDialog();
                    }
                }
            }
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if (TryBuildReport(out R001 report) == false)
                return;

            using SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                FileName = "R001_CatalogoCiudadanos.pdf"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                report.RDocument.GeneratePdf(dialog.FileName);
        }
    }
}
