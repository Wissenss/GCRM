using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCRM.Domain;

namespace GCRM
{
	public partial class FCitizenNetworkRoleData : Form
	{
		private TCitizenNetworkRole Role;

		FAccessMode Mode = FAccessMode.Read;

		public FCitizenNetworkRoleData()
		{
			InitializeComponent();
		}

		public void SetMode(FAccessMode mode)
		{
			Mode = mode;

			TextBoxName.Enabled = mode != FAccessMode.Read;
			TextBoxDescription.Enabled = mode != FAccessMode.Read;
			NumericLevel.Enabled = mode != FAccessMode.Read;

			BAccept.Visible = mode != FAccessMode.Read;
		}

		public void SetRole(TCitizenNetworkRole role)
		{
			Role = role;

			TextBoxName.Text = role.Name;
			TextBoxDescription.Text = role.Description;	
			NumericLevel.Value = role.Level;

			if (Mode == FAccessMode.Create)
			{
				Text = $"Rol - Nuevo";
			}
			else
			{
				Text = $"Rol - {Role.Name}";
			}
		}

		public TCitizenNetworkRole GetRole()
		{
			Role.Name = TextBoxName.Text.Trim();
			Role.Description = TextBoxDescription.Text.Trim();
			Role.Level = (int)NumericLevel.Value;

			return Role;
		}

		private bool ValidateInput()
		{
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
