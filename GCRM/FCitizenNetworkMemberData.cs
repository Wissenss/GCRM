using Business;
using System.Data;

namespace GCRM
{
	public partial class FCitizenNetworkMemberData : Form
	{
		TCitizenNetworkMember Member = new TCitizenNetworkMember();

		FAccessMode Mode;

		public FCitizenNetworkMemberData(DataTable dtRoles)
		{
			InitializeComponent();

			ComboBoxRoles.DataSource = dtRoles;
			ComboBoxRoles.ValueMember = "id";
			ComboBoxRoles.DisplayMember = "name";
		}

		public void SetMode(FAccessMode mode)
		{
			Mode = mode;

			TextBoxName.Enabled = Mode != FAccessMode.Read;
			BSelectCitizen.Enabled = Mode != FAccessMode.Read;
			ComboBoxRoles.Enabled = Mode != FAccessMode.Read;

			BAccept.Visible = Mode != FAccessMode.Read;
		}

		public void SetMember(TCitizenNetworkMember member)
		{
			Member = member;

			TextBoxName.Text = Member.Citizen.GetFullName();
			ComboBoxRoles.SelectedValue = Member.Role.Id;
		}

		public TCitizenNetworkMember GetMember()
		{
			Member.Role.Id = (int)ComboBoxRoles.SelectedValue;
			Member.Role.Name = ComboBoxRoles.Text;

			return Member;
		}

		private void BSelectCitizen_Click(object sender, EventArgs e)
		{
			using (FCitizenList citizen_list_dlg = new FCitizenList())
			{
				citizen_list_dlg.SetMode(FAccessMode.Select);

				if (citizen_list_dlg.ShowDialog() == DialogResult.OK)
				{
					Member.Citizen = citizen_list_dlg.GetSelectedCitizen();
					TextBoxName.Text = Member.Citizen.GetFullName();
				}
			}
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

			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
