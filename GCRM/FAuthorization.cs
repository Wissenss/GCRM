using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;

namespace GCRM
{
	public partial class FAuthorization : Form
	{
		public List<TUserPermission> RequieredPermissions = new List<TUserPermission>();

		public FAuthorization()
		{
			InitializeComponent();
		}

		private void FAuthorization_Load(object sender, EventArgs e)
		{
			ListBoxAuthorizatinActions.Items.Clear();

			foreach (TUserPermission permission in RequieredPermissions)
			{
				ListBoxAuthorizatinActions.Items.Add(permission.Name);
			}

			TextBoxUser.Focus();
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private Error AuthorizeActions()
		{
			string username = TextBoxUser.Text.Trim();
			string password = TextBoxPassword.Text.Trim();

			TUser user;

			Error error = UsersHandler.GetUserByUsername(username, out user);

			if (error == Error.UserNotFound)
			{
				return Error.LoginInvalid;
			}

			string hash = UsersHandler.GetPasswordHash(username, password);

			if (hash.Equals(user.PasswordHash) == false)
			{
				return Error.LoginInvalid;
			}

			// check the username has all requiered permissions

			foreach (var permission in RequieredPermissions)
			{
				if (user.HasPermission(permission.Name) == false)
				{
					return Error.UserUnauthorized;
				}
			}

			return 0;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			Error error = AuthorizeActions();

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);

				DialogResult = DialogResult.Abort;

				return;
			}

			DialogResult = DialogResult.OK;
		}
	}
}
