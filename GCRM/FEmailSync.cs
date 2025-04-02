using Business;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GCRM
{
	public partial class FEmailSync : Form
	{
		HttpClient VCardClient;

		public FEmailSync()
		{
			InitializeComponent();

			VCardClient = new HttpClient();
		}

		// this function encodes a TCitizen to a vcard 3.0 sting
		private string EncodeCititcenAsVCard()
		{
			StringBuilder vcard = new StringBuilder();

			vcard.AppendLine("BEGIN:VCARD");
			vcard.Append("VERSION:3.0");

			vcard.AppendLine("END:VCARD");

			return vcard.ToString();
		}

		private bool ValidateInput()
		{
			return true;
		}

		private async Task<HttpResponseMessage> SendPropfindAsync(HttpClient client, string url)
		{
			HttpRequestMessage request = new HttpRequestMessage();

			url = url.TrimStart('/');

			request.Method = new HttpMethod("PROPFIND");
			request.Content = new StringContent("");
			request.RequestUri = new Uri(client.BaseAddress + url);

			return await VCardClient.SendAsync(request);
		}

		public async void BSync_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
			{
				return;
			}
			string card_dav_url = TextBoxCardDavURL.Text.Trim();
			string username = TextBoxUsername.Text.Trim();
			string password = TextBoxPassword.Text.Trim();

			try
			{
				using (FLoading loading_dlg = new FLoading())
				{
					loading_dlg.Show();

					loading_dlg.Text = $"{username} - Autenticando cuenta...";

					// setup http client
					VCardClient = new HttpClient();
					VCardClient.BaseAddress = new Uri(card_dav_url);
					VCardClient.DefaultRequestHeaders.Clear();
					string auth_header = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
					VCardClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", auth_header);

					// test for correct auth
					HttpResponseMessage response = await SendPropfindAsync(VCardClient, "");

					response.EnsureSuccessStatusCode();

					// retrieve existing contacts
					loading_dlg.Text = $"{username} - Obteniendo contactos del servidor CardDav...";

					response = await SendPropfindAsync(VCardClient, "/default/");

					response.EnsureSuccessStatusCode();

					XmlDocument document = new XmlDocument();

					document.LoadXml(await response.Content.ReadAsStringAsync());
					
					XmlNodeList document_hrefs = document.GetElementsByTagName("href");

					List<string> existing_resources = new List<string>();

					for(int i = 1; i < document_hrefs.Count; i++)
					{
						string resource = document_hrefs.Item(i).InnerText;

						if (resource.Split('/').Last().StartsWith("gcrm"))
						{
							existing_resources.Add(resource);
						}
					}
					
					// query the citizen list
					loading_dlg.Text = $"{username} - Obteniendo listado de ciudadanos...";

					List<TCitizen> citizens;

					Error error = CitizensHandler.GetCitizens(out citizens);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}

					// create / edit vcards for each citizen
					for (int i = 0; i < citizens.Count; i++)
					{
						loading_dlg.Text = $"{username} - Sincronizando contactos... ({i + 1}/{citizens.Count})...";
						
						TCitizen citizen = citizens[i];

						TUser created_by_user = new TUser() { Name = "desconocido" };

						error = UsersHandler.GetUserById(citizen.Author.Id, out created_by_user);

						if (error != 0)
						{
							Utilities.ShowErrorDialog(error);
							return;
						}

						string uid = $"gcrm{citizen.Id}";
						string citizen_vcf_name = $"{uid}.vcf";
						string resource = $"{card_dav_url.TrimEnd('/')}/default/{citizen_vcf_name}";

						if (existing_resources.Contains(resource))
						{
							existing_resources.Remove(resource);
						}

						StringBuilder vcard = new StringBuilder();

						vcard.AppendLine($"BEGIN:VCARD");
						vcard.AppendLine($"VERSION:3.0");
						vcard.AppendLine($"N:{citizen.MaternalName};{citizen.Name};{citizen.PaternalName};{BConstants.GetCitizenBriefTitle(citizen.Title, citizen.Sex)}");
						vcard.AppendLine($"FN:{citizen.FullNameWithFirstCapitals}");
						vcard.AppendLine($"EMAIL:{citizen.Email}");
						vcard.AppendLine($"BDAY:{citizen.Birthday.ToString("yyyyMMdd")}");
						vcard.AppendLine($"TEL;TYPE=WORK:{citizen.FullPhone}");
						vcard.AppendLine($"TEL;TYPE=CELL:{citizen.Cellphone}");
						vcard.AppendLine($"NOTE:Alta: {created_by_user.Name}");
						vcard.AppendLine($"UID:{uid}");
						vcard.AppendLine($"ORG:{citizen.Institution.Name}");
						vcard.AppendLine($"TITLE:{citizen.Role.Name}");
						vcard.AppendLine($"REV:{citizen.EditDate}");
						vcard.AppendLine($"CATEGORIES:{citizen.Category.Name},{citizen.Institution.Category.Name}");

						vcard.AppendLine($"END:VCARD");

						HttpContent content = new StringContent(vcard.ToString(), Encoding.UTF8);

						content.Headers.ContentType = new MediaTypeHeaderValue("text/vcard");

						response = await VCardClient.PutAsync($"default/{citizen_vcf_name}", content);

						response.EnsureSuccessStatusCode();
					}

					// clear deleted citizens
					for (int i = 0; i < existing_resources.Count(); i++)
					{
						string citizen_vcf_name = existing_resources[i].Split('/').Last();

						loading_dlg.Text = $"{username} - Eliminando contactos desconocidos... ({i + 1}/{existing_resources.Count()})...";

						response = await VCardClient.DeleteAsync($"default/{citizen_vcf_name}");

						response.EnsureSuccessStatusCode();
					}
				}
			}
			catch (Exception ex)
			{
				Utilities.ShowExceptionDialog(ex);
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
