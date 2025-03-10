using Business;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GCRM
{
	public partial class FCitizenNetworkMemberData : Form
	{
		TCitizenNetworkMember Member = new TCitizenNetworkMember();
		TCitizenNetworkMember ParentMember = new TCitizenNetworkMember();

		DataTable DTRoles;

		FAccessMode Mode;

		public FCitizenNetworkMemberData(DataTable dtRoles)
		{
			InitializeComponent();

			DTRoles = dtRoles;

			ComboBoxRoles.DataSource = DTRoles;
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

		public void SetMember(TCitizenNetworkMember member, TCitizenNetworkMember parent_member)
		{
			Member = member;
			ParentMember = parent_member;

			TextBoxName.Text = Member.Citizen.FullName;
			ComboBoxRoles.SelectedValue = Member.Role.Id;
		}

		public TCitizenNetworkMember GetMember()
		{
			Member.Role = GetSelectedRole();

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
					TextBoxName.Text = Member.Citizen.FullName;
				}
			}
		}

		private TCitizenNetworkRole GetSelectedRole()
		{
			foreach (DataRow row in DTRoles.Rows)
			{
				if ((int)row["id"] == (int)ComboBoxRoles.SelectedValue)
				{
					return new TCitizenNetworkRole()
					{
						Id = (int)row["id"],
						Name = (string)row["name"],
						Level = (int)row["level"]
					};
				}
			}

			return null;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (Member.Citizen == null || TextBoxName.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar el ciudadano.");
			}

			if (ComboBoxRoles.SelectedValue == null)
			{
				errors.AppendLine("Debe especificar el rol del miembro");
			}
			else if ((int)ComboBoxRoles.SelectedValue == 0)
			{
				errors.AppendLine("Debe especificar el rol del miembro");
			}
			else if (Member.ParentMemberId != 0)
			{
				foreach (DataRow row in DTRoles.Rows)
				{
					if ((int)row["id"] == (int)ComboBoxRoles.SelectedValue)
					{
						if ((int)row["level"] <= ParentMember.Role.Level)
						{
							errors.AppendLine($"No se puede tener un miembro con rol {row["name"]} debajo de otro con rol {ParentMember.Role.Name}");
						}

						break;
					}
				}
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors.ToString());
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

			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
