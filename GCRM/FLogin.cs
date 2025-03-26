using Business;
using Business.Business;
using Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FLogin : Form
	{
		public FLogin()
		{
			InitializeComponent();
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			using (new CursorWait())
			{
				string username = TextBoxUser.Text.Trim();
				string password = TextBoxPassword.Text.Trim();

				Error error = Session.Login(username, password);

				if (error == Error.LoginInvalid)
				{
					LStatus.Text = "Usuario o contraseña incorrectos";
					LStatus.ForeColor = Color.Red;
					return;
				}
				else if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				Hide();

				FMain main_form = new FMain();

				main_form.Show();
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void TextBoxUser_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BAccept_Click(this, null);
			}
		}

		private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BAccept_Click(this, null);
			}
		}
	}
}
