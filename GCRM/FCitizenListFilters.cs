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
using GCRM.Domain;
using GCRM.Domain.Enums;

namespace GCRM
{
    public partial class FCitizenListFilters : Form
    {
        bool loaded = false;

        public bool FilterParty;
        public TPoliticalParty Party;
        public bool FilterSex;
        public TSex Sex;
        public bool FilterCitizenTitle;
        public TCitizenTitle CitizenTitle;
        public bool FilterInstitution;
        public int InstitutionId;
        public string InstitutionName;
        public bool FilterSector;
        public TSocietySector Sector;
        public bool FilterInstitutionCategory;
        public int InstitutionCategoryId;
        public string InstitutionCategoryName;
        public bool FilterBirthdayYear;
        public int BirthdayYear = DateTime.Now.Year;
        public bool FilterBirthdayMonth;
        public int BirthdayMonth = DateTime.Now.Month;
        public bool FilterBirthdayDay;
        public int BirthdayDay = DateTime.Now.Day;
        public bool FilterCategory;
        public int CategoryId;
        public string CategoryName;
        public bool FilterStatus;
        public int Status;
        public bool FilterAttentionRequired;
        public int AttentionRequired;
        public bool FilterVerifiedBy;
        public int VerifiedById;
        public string VerifiedByName;
        public bool FilterCreatedBy;
        public int CreatedById;
        public string CreatedByName;
        public bool FilterEditedBy;
        public int EditedById;
        public string EditedByName;

        DataSet DSFilters;
        DataTable DTYears;
        DataTable DTMonths;
        DataTable DTDays;
        DataTable DTStatus;
        DataTable DTAttentionRequired;
        DataTable DTUsersVerifiedBy;
        DataTable DTUsersCreatedBy;
        DataTable DTUsersEditedBy;

        public FCitizenListFilters()
        {
            InitializeComponent();

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

            DTStatus = new DataTable("DTStatus");
            DTStatus.Columns.Add("value", typeof(int));
            DTStatus.Columns.Add("text", typeof(string));
            DSFilters.Tables.Add(DTStatus);

            DTAttentionRequired = new DataTable("DTAttentionRequired");
            DTAttentionRequired.Columns.Add("value", typeof(int));
            DTAttentionRequired.Columns.Add("text", typeof(string));
            DSFilters.Tables.Add(DTAttentionRequired);

            DTUsersVerifiedBy = new DataTable("DTUsersVerifiedBy");
            DTUsersVerifiedBy.Columns.Add("id", typeof(int));
            DTUsersVerifiedBy.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTUsersVerifiedBy);

            DTUsersCreatedBy = new DataTable("DTUsersCreatedBy");
            DTUsersCreatedBy.Columns.Add("id", typeof(int));
            DTUsersCreatedBy.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTUsersCreatedBy);

            DTUsersEditedBy = new DataTable("DTUsersEditedBy");
            DTUsersEditedBy.Columns.Add("id", typeof(int));
            DTUsersEditedBy.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTUsersEditedBy);
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

            ComboBoxBirthdayDay.SelectedValue = DateTime.Now.Day;
        }

        private void LoadDTStatus()
        {
            DTStatus.BeginLoadData();
            DTStatus.Clear();

            DataRow r1 = DTStatus.NewRow();
            r1["value"] = 1;
            r1["text"] = "Verificados";
            DTStatus.Rows.Add(r1);

            DataRow r2 = DTStatus.NewRow();
            r2["value"] = 2;
            r2["text"] = "No verificados";
            DTStatus.Rows.Add(r2);

            DTStatus.EndLoadData();

            ComboBoxStatus.SelectedValue = 1;
        }

        private void LoadDTAttentionRequired()
        {
            DTAttentionRequired.BeginLoadData();
            DTAttentionRequired.Clear();

            DataRow r1 = DTAttentionRequired.NewRow();
            r1["value"] = 1;
            r1["text"] = "Requiere atención";
            DTAttentionRequired.Rows.Add(r1);

            DataRow r2 = DTAttentionRequired.NewRow();
            r2["value"] = 2;
            r2["text"] = "No requiere atención";
            DTAttentionRequired.Rows.Add(r2);

            DTAttentionRequired.EndLoadData();

            ComboBoxAttentionRequired.SelectedValue = 1;
        }

        private void FillDTUsers(DataTable table, List<TUser> users)
        {
            table.BeginLoadData();
            table.Clear();

            foreach (TUser user in users)
            {
                DataRow row = table.NewRow();

                row["id"] = user.Id;
                row["name"] = user.Name;

                table.Rows.Add(row);
            }

            table.EndLoadData();
        }

        private void LoadDTUsers()
        {
            Error error = UsersHandler.GetUsers(out List<TUser> users);

            if (error != 0)
            {
                Utilities.ShowErrorDialog(error);
                return;
            }

            FillDTUsers(DTUsersVerifiedBy, users);
            FillDTUsers(DTUsersCreatedBy, users);
            FillDTUsers(DTUsersEditedBy, users);
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

            if (CheckBoxFilterInstitutionCategory.Checked && ComboBoxInstitutionCategory.SelectedValue == null)
            {
                errors.AppendLine("Debe especificar la categoría de institución a filtrar");
            }

            if (CheckBoxFilterCategory.Checked && ComboBoxCategory.SelectedValue == null)
            {
                errors.AppendLine("Debe especificar la categoría a filtrar");
            }

            if (CheckBoxFilterVerifiedBy.Checked && ComboBoxVerifiedBy.SelectedValue == null)
            {
                errors.AppendLine("Debe especificar el usuario que verificó a filtrar");
            }

            if (CheckBoxFilterCreatedBy.Checked && ComboBoxCreatedBy.SelectedValue == null)
            {
                errors.AppendLine("Debe especificar el usuario que creó a filtrar");
            }

            if (CheckBoxFilterEditedBy.Checked && ComboBoxEditedBy.SelectedValue == null)
            {
                errors.AppendLine("Debe especificar el usuario que editó a filtrar");
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
            InstitutionName = ComboBoxInstitucion.Text;

            FilterSector = CheckBoxFilterSector.Checked;
            if (ComboBoxSector.SelectedValue != null)
                Sector = (TSocietySector)ComboBoxSector.SelectedValue;

            FilterInstitutionCategory = CheckBoxFilterInstitutionCategory.Checked;
            if (ComboBoxInstitutionCategory.SelectedValue != null)
                InstitutionCategoryId = (int)ComboBoxInstitutionCategory.SelectedValue;
            InstitutionCategoryName = ComboBoxInstitutionCategory.Text;

            FilterBirthdayYear = CheckBoxFilterBirthdayYear.Checked;
            BirthdayYear = (int)ComboBoxBirthdayYear.SelectedValue;

            FilterBirthdayMonth = CheckBoxFilterBirthdayMonth.Checked;
            BirthdayMonth = (int)ComboBoxBirthdayMonth.SelectedValue;

            FilterBirthdayDay = CheckBoxFilterBirthdayDay.Checked;
            BirthdayDay = (int)ComboBoxBirthdayDay.SelectedValue;

            FilterCategory = CheckBoxFilterCategory.Checked;
            if (ComboBoxCategory.SelectedValue != null)
                CategoryId = (int)ComboBoxCategory.SelectedValue;
            CategoryName = ComboBoxCategory.Text;

            FilterStatus = CheckBoxFilterStatus.Checked;
            Status = (int)ComboBoxStatus.SelectedValue;

            FilterAttentionRequired = CheckBoxFilterAttentionRequired.Checked;
            AttentionRequired = (int)ComboBoxAttentionRequired.SelectedValue;

            FilterVerifiedBy = CheckBoxFilterVerifiedBy.Checked;
            if (ComboBoxVerifiedBy.SelectedValue != null)
                VerifiedById = (int)ComboBoxVerifiedBy.SelectedValue;
            VerifiedByName = ComboBoxVerifiedBy.Text;

            FilterCreatedBy = CheckBoxFilterCreatedBy.Checked;
            if (ComboBoxCreatedBy.SelectedValue != null)
                CreatedById = (int)ComboBoxCreatedBy.SelectedValue;
            CreatedByName = ComboBoxCreatedBy.Text;

            FilterEditedBy = CheckBoxFilterEditedBy.Checked;
            if (ComboBoxEditedBy.SelectedValue != null)
                EditedById = (int)ComboBoxEditedBy.SelectedValue;
            EditedByName = ComboBoxEditedBy.Text;

            DialogResult = DialogResult.OK;
        }

        private void FCitizenListFilters_Shown(object sender, EventArgs e)
        {

        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CheckBoxFilterInstitution_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxInstitucion.Enabled = CheckBoxFilterInstitution.Checked;
            BSelectInstitution.Enabled = CheckBoxFilterInstitution.Checked;
        }

        private void CheckBoxFilterSector_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxSector.Enabled = CheckBoxFilterSector.Checked;
        }

        private void CheckBoxFilterCategory_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxInstitutionCategory.Enabled = CheckBoxFilterInstitutionCategory.Checked;
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

        private void CheckBoxFilterCategory_CheckedChanged_1(object sender, EventArgs e)
        {
            ComboBoxCategory.Enabled = CheckBoxFilterCategory.Checked;
        }

        private void BSelectInstitution_Click(object sender, EventArgs e)
        {
            using (FInstitutionList select_dlg = new FInstitutionList())
            {
                select_dlg.SetAccessMode(FAccessMode.Select);

                if (select_dlg.ShowDialog() == DialogResult.OK)
                {
                    int institution_id = select_dlg.GetSelectedInstitutionId();

                    ComboBoxInstitucion.SelectedValue = institution_id;
                }
            }
        }

        private void FCitizenListFilters_Load(object sender, EventArgs e)
        {
            if (loaded)
                return;

            using (new CursorWait())
            {
                // load the datasource
                Catalogs.LoadDTInstitutions();
                Catalogs.LoadDTInstitutionCategories();
                Catalogs.LoadDTCitizenCategories();
                LoadDTYears();
                LoadDTMonths();
                LoadDTDays();
                LoadDTStatus();
                LoadDTAttentionRequired();
                LoadDTUsers();

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

                if (Catalogs.DTInstitutions.Rows.Count > 0)
                    ComboBoxInstitucion.SelectedIndex = 0;

                ComboBoxSector.DataSource = Catalogs.DTSocietySector;
                ComboBoxSector.ValueMember = "value";
                ComboBoxSector.DisplayMember = "text";

                ComboBoxInstitutionCategory.DataSource = Catalogs.DTInstitutionCategories;
                ComboBoxInstitutionCategory.ValueMember = "id";
                ComboBoxInstitutionCategory.DisplayMember = "name";

                if (Catalogs.DTInstitutionCategories.Rows.Count > 0)
                    ComboBoxInstitutionCategory.SelectedIndex = 0;

                ComboBoxBirthdayYear.DataSource = DTYears;
                ComboBoxBirthdayYear.ValueMember = "value";
                ComboBoxBirthdayYear.DisplayMember = "value";

                ComboBoxBirthdayMonth.DataSource = DTMonths;
                ComboBoxBirthdayMonth.ValueMember = "value";
                ComboBoxBirthdayMonth.DisplayMember = "text";

                ComboBoxBirthdayDay.DataSource = DTDays;
                ComboBoxBirthdayDay.ValueMember = "value";
                ComboBoxBirthdayDay.DisplayMember = "value";

                ComboBoxCategory.DataSource = Catalogs.DTCitizenCategories;
                ComboBoxCategory.ValueMember = "id";
                ComboBoxCategory.DisplayMember = "name";

                ComboBoxStatus.DataSource = DTStatus;
                ComboBoxStatus.ValueMember = "value";
                ComboBoxStatus.DisplayMember = "text";

                ComboBoxAttentionRequired.DataSource = DTAttentionRequired;
                ComboBoxAttentionRequired.ValueMember = "value";
                ComboBoxAttentionRequired.DisplayMember = "text";

                if (Catalogs.DTCitizenCategories.Rows.Count > 0)
                    ComboBoxCategory.SelectedIndex = 0;

                ComboBoxVerifiedBy.DataSource = DTUsersVerifiedBy;
                ComboBoxVerifiedBy.ValueMember = "id";
                ComboBoxVerifiedBy.DisplayMember = "name";

                ComboBoxCreatedBy.DataSource = DTUsersCreatedBy;
                ComboBoxCreatedBy.ValueMember = "id";
                ComboBoxCreatedBy.DisplayMember = "name";

                ComboBoxEditedBy.DataSource = DTUsersEditedBy;
                ComboBoxEditedBy.ValueMember = "id";
                ComboBoxEditedBy.DisplayMember = "name";

                if (DTUsersVerifiedBy.Rows.Count > 0)
                {
                    ComboBoxVerifiedBy.SelectedIndex = 0;
                    ComboBoxCreatedBy.SelectedIndex = 0;
                    ComboBoxEditedBy.SelectedIndex = 0;
                }
            }

            loaded = true;
        }

        private void CheckBoxFilterStatus_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxStatus.Enabled = CheckBoxFilterStatus.Checked;
        }

        private void CheckBoxFilterAttentionRequired_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxAttentionRequired.Enabled = CheckBoxFilterAttentionRequired.Checked;
        }

        private void CheckBoxFilterVerifiedBy_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxVerifiedBy.Enabled = CheckBoxFilterVerifiedBy.Checked;
        }

        private void CheckBoxFilterCreatedBy_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxCreatedBy.Enabled = CheckBoxFilterCreatedBy.Checked;
        }

        private void CheckBoxFilterEditedBy_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxEditedBy.Enabled = CheckBoxFilterEditedBy.Checked;
        }
    }
}
