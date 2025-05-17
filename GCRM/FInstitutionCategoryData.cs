using Business;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FInstitutionCategoryData : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;
		int Id;

		public FInstitutionCategoryData()
		{
			InitializeComponent();
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxDescription.Enabled = AccessMode != FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
		}

		public void SetId(int id)
		{
			using (new CursorWait())
			{
				Id = id;

				TInstitutionCategory institution_category;

				Error error = InstitutionsHandler.GetInstitutionCategoryById(id, out institution_category);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				TextBoxName.Text = institution_category.Name;
				TextBoxDescription.Text = institution_category.Description;
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
				errors.Append("Debe especificar el nombre de la categoría");
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

			using (new CursorWait())
			{
				TInstitutionCategory institution_category = new TInstitutionCategory()
				{
					Id = Id,
					Name = TextBoxName.Text,
					Description = TextBoxDescription.Text,
				};

				Error error = InstitutionsHandler.SaveInstitutionCategory(institution_category, AccessMode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);

					return;
				}

				DialogResult = DialogResult.OK;
			}
		}
	}
}
