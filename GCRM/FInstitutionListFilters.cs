using Business;
using System.Data;
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
		public bool FilterAttentionRequired;
		public int AttentionRequired;

		DataTable DTAttentionRequired;

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

			DTAttentionRequired = new DataTable("DTAttentionRequired");
			DTAttentionRequired.Columns.Add("value", typeof(int));
			DTAttentionRequired.Columns.Add("text", typeof(string));

			DataRow r1 = DTAttentionRequired.NewRow();
			r1["value"] = 1;
			r1["text"] = "Requiere atención";
			DTAttentionRequired.Rows.Add(r1);

			DataRow r2 = DTAttentionRequired.NewRow();
			r2["value"] = 2;
			r2["text"] = "No requiere atención";
			DTAttentionRequired.Rows.Add(r2);

			ComboBoxAttentionRequired.DataSource = DTAttentionRequired;
			ComboBoxAttentionRequired.ValueMember = "value";
			ComboBoxAttentionRequired.DisplayMember = "text";
			ComboBoxAttentionRequired.SelectedValue = 1;
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

			FilterAttentionRequired = CheckBoxFilterAttentionRequired.Checked;
			AttentionRequired = (int)ComboBoxAttentionRequired.SelectedValue;

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

		private void CheckBoxFilterAttentionRequired_CheckedChanged(object sender, EventArgs e)
		{
			ComboBoxAttentionRequired.Enabled = CheckBoxFilterAttentionRequired.Checked;
		}
	}
}
