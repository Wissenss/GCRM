using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GCRM.PurelyemailUtilities;

namespace GCRM
{
	public partial class FEmailData : Form
	{
		FAccessMode Mode;

		public FEmailData()
		{
			InitializeComponent();
		}

		public void SetAccessMode(FAccessMode mode) 
		{
			Mode = mode;

			TextBoxName.Enabled = Mode != FAccessMode.Read;

			BAccept.Visible = Mode != FAccessMode.Read;
		}

		public async void SetAccount(string account)
		{
			using (new CursorWait())
			{
				TGetUserResponse info = await PurelyemailUtilities.GetUser(account);

				if (info == null)
				{
					return;
				}

				Text = $"Email";
				TextBoxName.Text = account;
			}
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

				HttpStatusCode status = await PurelyemailUtilities.CreateUser(user);

				if (status != HttpStatusCode.OK)
				{
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}
	}
}
