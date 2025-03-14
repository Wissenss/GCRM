using Business.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FEmailList : Form
	{
		DataSet DSEmails;
		DataTable DTEmails;

		FEmailData EmailDataDlg;

		public FEmailList()
		{
			InitializeComponent();

			// create the dataset
			DSEmails = new DataSet("DSEmails");

			DTEmails = new DataTable("DTEmails");
			DTEmails.Columns.Add("account", typeof(string));
			DTEmails.Columns.Add("domain", typeof(string));

			DSEmails.Tables.Add(DTEmails);

			// create the emails datagrid
			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridEmails, "colAccount", "Cuenta", "account", true, display_index++, 20, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridEmails, "colDomain", "Dominio", "domain", true, display_index++, 20, 20, DataGridViewAutoSizeColumnMode.Fill);

			// bind dg and table
			DataGridEmails.DataSource = DSEmails;
			DataGridEmails.DataMember = "DTEmails";

			// create the data dlg
			EmailDataDlg = new FEmailData();
		}

		private void BWebmail_Click(object sender, EventArgs e)
		{
			Utilities.OpenUrl("https://purelymail.com/user/login");
		}

		private async void LoadList()
		{
			using (new CursorWait())
			{
				List<string> users_list = await PurelyemailUtilities.ListUser();

				if (users_list == null)
					return;

				DTEmails.BeginLoadData();
				DTEmails.Clear();

				foreach (string user in users_list)
				{
					DataRow row = DTEmails.NewRow();

					row["account"] = user;
					row["domain"] = user.Split('@')[1];

					DTEmails.Rows.Add(row);
				}

				DTEmails.EndLoadData();
			}
		}

		private void FEmailList_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private string GetSelectedAccount()
		{
			if (DataGridEmails.SelectedRows.Count == 0)
			{
				return null;
			}

			DataGridViewRow row = DataGridEmails.SelectedRows[0];

			string account = (string)row.Cells["colAccount"].Value;

			return account;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FEmailData email_data_dlg = new FEmailData())
			{
				if (email_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			// TODO: probably this wont ever make sense
		}

		private async void BRead_Click(object sender, EventArgs e)
		{
			string account = GetSelectedAccount();

			if (account == null)
				return;

			EmailDataDlg.SetAccessMode(FAccessMode.Read);

			EmailDataDlg.Text = $"Email - Consulta";
			EmailDataDlg.TextBoxName.Text = account.Split('@')[0];
			EmailDataDlg.ComboBoxDomains.Text = account.Split('@')[1];

			EmailDataDlg.ShowDialog();
		}

		private void BBilling_Click(object sender, EventArgs e)
		{
			using (FEmailBilling email_billing_dlg = new FEmailBilling())
			{
				email_billing_dlg.ShowDialog();
			}
		}
	}
}
