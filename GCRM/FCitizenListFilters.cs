using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

		public FCitizenListFilters()
		{
			InitializeComponent();

			Catalogs.LoadDTInstitutions();
			Catalogs.LoadDTInstitutionCategories();

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

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
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

			DialogResult = DialogResult.OK;
		}

		private void FCitizenListFilters_Shown(object sender, EventArgs e)
		{
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
	}
}
