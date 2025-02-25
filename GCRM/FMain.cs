using Business;
using Connection;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection;

namespace GCRM
{
	public partial class FMain : Form
	{
		public FMain()
		{
			InitializeComponent();

			LoadBirhdayList();
		}

		private void BUsers_Click(object sender, EventArgs e)
		{
			if (Session.HasPermission("Usuarios.Consultar"))
			{
				using (FUserList user_list_dlg = new FUserList())
				{
					user_list_dlg.ShowDialog();
				}
			}
			else
			{
				using (FUserData user_data_dlg = new FUserData())
				{
					user_data_dlg.SetAccessMode(FAccessMode.Update);
					user_data_dlg.SetId(Session.User.Id);

					if (user_data_dlg.ShowDialog() == DialogResult.OK)
					{
						//Session.Refresh();
					}
				}
			}
		}

		private void RefreshStatusStrip()
		{
			LToolStripUsername.Text = $"Usuario: {Session.User.Username}";
			LToolStripServer.Text = $"Servidor: {ConnectionSettings.Host}:{ConnectionSettings.Port} - {ConnectionSettings.Database}";

			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fileVersionInfo.ProductVersion;
			LToolstripVersion.Text = $"Versión: {version}";
		}

		private void LoadBirhdayList()
		{
			using (new CursorWait())
			{
				List<TCitizen> citizens_on_birthday;

				Error error = CitizensHandler.GetCitizensWhosBirhdayFallsOn(DateTime.Today, out citizens_on_birthday);

				if (error != 0)
				{
					return;
				}

				PictureBoxBirthdayList.Visible = citizens_on_birthday.Count > 0;
				LBirthdayList.Visible = citizens_on_birthday.Count > 0;

				ListBoxBirhdays.Items.Clear();

				foreach (TCitizen citizen in citizens_on_birthday)
				{
					ListBoxBirhdays.Items.Add($" - {citizen.Name} {citizen.PaternalName} {citizen.MaternalName}");
				}
			}
		}

		private void FMain_Load(object sender, EventArgs e)
		{
			RefreshStatusStrip();

			BUsers.Text = Session.HasPermission("Usuarios.Consultar") ? "&Usuarios" : "&Usuario";

			LoadPermissions();
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BCitizens.Visible = Session.HasPermission("Ciudadanos.Consultar");
				BInstitutions.Visible = Session.HasPermission("Instituciones.Consultar");
				BInstitutionCategories.Visible = Session.HasPermission("Instituciones.Categorias.Consultar");
			}
		}

		private void FMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void BConnection_Click(object sender, EventArgs e)
		{
			using (FConnection connection_dl = new FConnection())
			{
				if (Session.HasPermission("Conexion.Editar"))
				{
					connection_dl.SetAccessMode(FAccessMode.Update);
				}

				if (connection_dl.ShowDialog() == DialogResult.OK)
				{
					RefreshStatusStrip();
				}
			}
		}

		private void BInstitutionCategories_Click(object sender, EventArgs e)
		{
			using (FInstitutionCategoryList institution_categories_list_dl = new FInstitutionCategoryList())
			{
				institution_categories_list_dl.ShowDialog();
			}
		}

		private void BInstitutions_Click(object sender, EventArgs e)
		{
			using (FInstitutionList institution_list_dlg = new FInstitutionList())
			{
				institution_list_dlg.ShowDialog();
			}
		}

		private void BCitizens_Click(object sender, EventArgs e)
		{
			using (FCitizenList citizen_list_dlg = new FCitizenList())
			{
				citizen_list_dlg.ShowDialog();
			}
		}

		private void BAbout_Click(object sender, EventArgs e)
		{
			using (FAbout about_dlg = new FAbout())
			{
				about_dlg.ShowDialog();
			}
		}

		private void BCitizenNetworks_Click(object sender, EventArgs e)
		{
			using (FCitizenNetworkList citizen_network_list_dlg = new FCitizenNetworkList())
			{
				citizen_network_list_dlg.ShowDialog();
			}
		}
	}
}
