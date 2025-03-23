using Business;


namespace GCRM
{
	public partial class FInstitutionListFilters : Form
	{
		public bool FilterCategory;
		public TInstitutionCategory Category;
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
			Category = new TInstitutionCategory()
			{
				Id = (int)ComboBoxCategory.SelectedValue,
				Name = (string)ComboBoxCategory.Text,
			};
			FilterSector = CheckBoxFilterSector.Checked;
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
