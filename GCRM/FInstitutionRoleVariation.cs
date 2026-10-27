using Business;
using System;
using System.Text;
using System.Windows.Forms;
using GCRM.Domain;

namespace GCRM
{
	public partial class FInstitutionRoleVariation : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;

		public FInstitutionRoleVariation()
		{
			InitializeComponent();
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
		}

		public void SetValues(string name = "")
		{
			TextBoxName.Text = name;

			Text = $"Variante - {name}";
		}

		public void GetValues(out string name)
		{
			name = TextBoxName.Text.Trim();
		}

		public TInstitutionRoleVariation GetValues()
		{
			return new TInstitutionRoleVariation()
			{
				Name = TextBoxName.Text.Trim()
			};
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (TextBoxName.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar el nombre de la variante");
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

            // spell check - this is merely a warning, user may choose to ignore it
            if (Session.SpellCheck)
            {
                List<Control> toCheck = new List<Control>()
                {
                    TextBoxName,
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

			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
