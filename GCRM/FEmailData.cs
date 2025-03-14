using Business;
using System.Net;
using System.Text;
using static GCRM.PurelyemailUtilities;

namespace GCRM
{
	public partial class FEmailData : Form
	{
		FAccessMode Mode;

		public FEmailData()
		{
			InitializeComponent();

			LoadDomains();
		}

		private async void LoadDomains()
		{
			TListDomainResponse response = await PurelyemailUtilities.ListDomain();

			if (response.successful == false)
			{
				PurelyemailUtilities.ShowPurelymailResponseErrorDialog(response);
				return;
			}

			ComboBoxDomains.Items.Clear();

			foreach (TDomain domain in response.result.domains)
			{
				ComboBoxDomains.Items.Add(domain.name);
			}

			ComboBoxDomains.SelectedIndex = 0;
		}

		public void SetAccessMode(FAccessMode mode)
		{
			Mode = mode;

			TextBoxName.Enabled = Mode != FAccessMode.Read;
			ComboBoxDomains.Enabled = Mode != FAccessMode.Read;

			BAccept.Visible = Mode != FAccessMode.Read;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (TextBoxName.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar la dirección del e-mail");
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			return true;
		}

		private async void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
			{
				return;
			}

			using (new CursorWait())
			{
				string user = TextBoxName.Text.Trim();
				string domain = ComboBoxDomains.Text.Trim();
				string password = TextBoxPassword.Text.Trim();
				bool allow_password_reset = AllowPasswordReset.Checked;

				TCreateUserResponse response = await PurelyemailUtilities.CreateUser(user, domain, password, allow_password_reset);

				if (response.successful == false)
				{
					PurelyemailUtilities.ShowPurelymailResponseErrorDialog(response);
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void UpdateFullEmailString()
		{
			LFullEmail.Text = $"{TextBoxName.Text.Trim()}@{ComboBoxDomains.Text.Trim()}";
		}

		private void TextBoxName_TextChanged(object sender, EventArgs e)
		{
			UpdateFullEmailString();
		}

		private void ComboBoxDomains_TextChanged(object sender, EventArgs e)
		{
			UpdateFullEmailString();
		}
	}
}
