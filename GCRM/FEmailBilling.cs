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
	public partial class FEmailBilling : Form
	{
		public FEmailBilling()
		{
			InitializeComponent();
		}

		public async void UpdateInfo()
		{
			using (new CursorWait())
			{
				PurelyemailUtilities.TCheckAccountCreditResponse response = await PurelyemailUtilities.CheckAccountCredit();

				if (response.successful == false)
				{
					PurelyemailUtilities.ShowPurelymailResponseErrorDialog(response);
					LCredit.Text = "desconocido";
					return;
				}

				LCredit.Text = $"{response.result.dCredit:C}";
			}
		}

		private void FEmailBilling_Load(object sender, EventArgs e)
		{
			UpdateInfo();
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
