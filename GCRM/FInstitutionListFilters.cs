using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FInstitutionListFilters : Form
	{
		public bool FilterCategory;
		public int CategoryId;
		public string CategoryName;
		public bool FilterSector;
		public TSocietySector Sector;

		public FInstitutionListFilters()
		{
			InitializeComponent();

			Catalogs.LoadDTInstitutionCategories();

			ComboBoxCategory.DataSource = Catalogs.DTInstitutionCategories;
			ComboBoxCategory.ValueMember = "id";
			ComboBoxCategory.DisplayMember = "name";

			ComboBoxSector.DataSource = Catalogs.DTSocietySector;
			ComboBoxSector.ValueMember = "value";
			ComboBoxSector.DisplayMember = "text";
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private bool ValidateInput()
		{
			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
			{
				return;
			}

			FilterCategory = CheckBoxFilterCategory.Checked;
			if (ComboBoxCategory.SelectedValue != null)
				CategoryId = (int)ComboBoxCategory.SelectedValue;
			CategoryName = ComboBoxCategory.Text;

			FilterSector = CheckBoxFilterSector.Checked;
			if (ComboBoxSector.SelectedValue != null)
				Sector = (TSocietySector)ComboBoxSector.SelectedValue;

			DialogResult = DialogResult.OK;
		}

		private void CheckBoxFilterCategory_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxCategory.Enabled = CheckBoxFilterCategory.Checked;
		}

		private void CheckBoxFilterSector_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxSector.Enabled = CheckBoxFilterSector.Checked;
		}
	}
}
