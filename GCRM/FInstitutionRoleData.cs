using DocumentFormat.OpenXml.Bibliography;
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
	public partial class FInstitutionRoleData : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;

		public FInstitutionRoleData()
		{
			InitializeComponent();
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxDescription.Enabled = AccessMode != FAccessMode.Read;
		}

		public void SetValues(string name = "", string description = "")
		{
			TextBoxName.Text = name;
			TextBoxDescription.Text = description;

			Text = $"Cargo - {name}";
		}

		public void GetValues(out string name, out string description)
		{
			name = TextBoxName.Text;
			description = TextBoxDescription.Text;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (TextBoxName.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar el nombre del cargo");
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
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
