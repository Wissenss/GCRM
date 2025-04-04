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
	public partial class FInstitutionTemplateRoleData : Form
	{
		public int Id = 0;

		public FInstitutionTemplateRoleData()
		{
			InitializeComponent();
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
