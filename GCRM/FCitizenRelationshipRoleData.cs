using Business;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FCitizenRelationshipRoleData : Form
	{
		private FAccessMode Mode;
		private int Id;

		public FCitizenRelationshipRoleData()
		{
			InitializeComponent();
		}

		public void SetMode(FAccessMode mode)
		{
			Mode = mode;

			TBName.Enabled = Mode != FAccessMode.Read;

			BAccept.Visible = Mode != FAccessMode.Read;
			BCancel.Text = Mode == FAccessMode.Read ? "&Cerrar" : "&Cancelar";
		}

		public void SetId(int id)
		{
			using (new CursorWait())
			{
				Id = id;

				Error error = CitizensHandler.GetCitizenRelationshipRoleById(Id, out TCitizenRelationshipRole role);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				TBName.Text = role.Name;
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private bool Validate()
		{
			StringBuilder errors = new StringBuilder();

			if (TBName.Text.Trim().Length == 0)
				errors.Append("Debe especificar el nombre de la relación ciudadana");

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (Validate() == false)
				return;

			TCitizenRelationshipRole role = new TCitizenRelationshipRole();

			role.Id = Id;
			role.Name = TBName.Text.Trim();

			Error error = CitizensHandler.SaveCitizenRelationshipRole(role, Mode == FAccessMode.Update);
		
			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			DialogResult = DialogResult.OK;
		}
	}
}
