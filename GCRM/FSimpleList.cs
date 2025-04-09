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
	public partial class FSimpleList : Form
	{
		public DataSet DSSimpleList;
		public DataTable DTSimpleList;

		public FSimpleList()
		{
			InitializeComponent();

			DSSimpleList = new DataSet();
			DTSimpleList = new DataTable("DTSimpleList");
			
			DataGridSimpleList.DataSource = DSSimpleList;
		}
	}
}
