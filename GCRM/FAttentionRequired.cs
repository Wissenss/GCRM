using System.Text;

namespace GCRM
{
	public partial class FAttentionRequired : Form
	{
		public FAttentionRequired()
		{
			InitializeComponent();
		}

		public string Reason => TextBoxReason.Text.Trim();

		private bool ValidateInput()
		{
			StringBuilder errores = new StringBuilder();

			if (Reason.Length == 0)
			{
				errores.AppendLine("Debe especificar el motivo por el cual se requiere atención");
			}

			if (errores.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errores);
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
