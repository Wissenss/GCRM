using Business;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FCitizenCategoryData : Form
	{
		FAccessMode Mode;

		int Id;

		public FCitizenCategoryData()
		{
			InitializeComponent();
		}

		public void SetAccessMode(FAccessMode mode)
		{
			Mode = mode;

			TextBoxName.Enabled = mode != FAccessMode.Read;
			TextBoxDescription.Enabled = mode != FAccessMode.Read;

			BAccept.Visible = mode != FAccessMode.Read;
			BCancel.Text = mode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
		}

		public void SetId(int id)
		{
			Id = id;

			TCitizenCategory category;

			Error error = CitizensHandler.GetCitizenCategoryById(Id, out category);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			TextBoxName.Text = category.Name;
			TextBoxDescription.Text = category.Description;
		}

		public bool ValidateInput()
		{
			StringBuilder errores = new StringBuilder();

			if (TextBoxName.Text.Trim().Length == 0)
			{
				errores.AppendLine("Debe especificar el nombre de la categoría");
			}

			if (errores.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errores);
				return false;
			}

            // spell check - this is merely a warning, user may choose to ignore it
            if (Session.SpellCheck)
            {
                List<Control> toCheck = new List<Control>()
                {
                    TextBoxName,
                    TextBoxDescription
                };

                if (SpellUtilities.CheckInputWithDialog(toCheck) != DialogResult.OK)
                {
                    return false;
                }
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
				TCitizenCategory category = new TCitizenCategory()
				{
					Id = Id,
					Name = TextBoxName.Text.Trim(),
					Description = TextBoxDescription.Text.Trim(),
				};

				Error error = CitizensHandler.SaveCitizenCategory(category, Mode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}
			}

			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
