using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using BrightIdeasSoftware;
using Business;
using Business.Business;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Wordprocessing;

namespace GCRM
{
	public static class Utilities
	{
		public static int TrimOnRange(int lowest_value, int highest_value, int value)
		{
			value = Math.Max(value, lowest_value);
			value = Math.Min(value, highest_value);

			return value;
		}

		public static void ShowErrorDialog(Business.Error error)
		{
			MessageBox.Show(Errors.GetErrorDescription(error), $"Error {(int)error:D5}: {error.ToString()}", MessageBoxButtons.OK);
		}

		public static void ShowErrorDialog(string error, string title = "Error")
		{
			MessageBox.Show(error, title, MessageBoxButtons.OK);
		}

		public static void ShowValidationErrorDialog(string errors, string title = "Se encontraron los siguientes problemas: ")
		{
			MessageBox.Show(errors, title, MessageBoxButtons.OK);
		}

		public static void ShowValidationErrorDialog(StringBuilder errors, string title = "Se encontraron los siguientes problemas: ")
		{
			ShowValidationErrorDialog(errors.ToString(), title);
		}

		public static void ShowExceptionDialog(Exception ex)
		{
			MessageBox.Show(ex.Message, "Ocurrió excepción", MessageBoxButtons.OK);
		}

		public static DialogResult ShowDeleteConfirmDialog(string message)
		{
			DialogResult result = MessageBox.Show(
				message,
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning
			);

			return result;
		}

		public static void OpenUrl(string url)
		{
			try
			{
				Process.Start(url);
			}
			catch
			{
				// hack because of this: https://github.com/dotnet/corefx/issues/10361
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					url = url.Replace("&", "^&");
					Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					Process.Start("xdg-open", url);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					Process.Start("open", url);
				}
				else
				{
					throw;
				}
			}
		}

		public static string GetProductVersion()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fileVersionInfo.ProductVersion;

			return version;
		}
	}

	public static class DataGridUtilities
	{
		public static void AddColumn(DataGridView data_grid, string col_name, string header_text, string data_property_name, bool visible = true, int display_index = 0, int width = 100, int min_width = 100, DataGridViewAutoSizeColumnMode auto_size_mode = DataGridViewAutoSizeColumnMode.None)
		{
			DataGridViewColumn column = new DataGridViewColumn();

			// cell template
			DataGridViewCell cell = new DataGridViewTextBoxCell();
			column.CellTemplate = cell;

			// customaizable values
			column.Name = col_name;
			column.DataPropertyName = data_property_name;
			column.HeaderText = header_text;
			column.DefaultCellStyle = data_grid.DefaultCellStyle;
			column.Width = width;
			column.MinimumWidth = min_width;
			column.SortMode = DataGridViewColumnSortMode.Automatic;
			column.AutoSizeMode = auto_size_mode;
			column.Visible = visible;
			column.DisplayIndex = display_index;

			// defaults
			column.Resizable = DataGridViewTriState.True;
			column.DividerWidth = 1;
			column.FillWeight = auto_size_mode == DataGridViewAutoSizeColumnMode.Fill ? 100 : 1;
			column.Frozen = false;

			data_grid.Columns.Add(column);
		}

		public static int GetSelectedId(DataGridView data_grid, string field = "colId")
		{
			if (data_grid.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = data_grid.SelectedRows[0];

			int id = (int)row.Cells[field].Value;

			return id;
		}
	}

	public static class ExcelUtilities
	{
		public static void SetWorksheetHeaderCell(IXLWorksheet worksheet, int row, int col, string value, XLColor color = null, int width = 20)
		{
			// set the value
			worksheet.Cell(row, col).Value = value;

			// set the width
			worksheet.Column(col).Width = width;

			// set the background color
			if (color != null)
			{
				worksheet.Cell(row, col).Style.Fill.BackgroundColor = color;
			}

			// set the font style
			worksheet.Cell(row, col).Style.Font.Bold = true;

			// set the borders
			worksheet.Cell(row, col).Style.Border.RightBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.TopBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.RightBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.LeftBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.TopBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.BottomBorderColor = XLColor.Black;
		}

		public static void SetWorksheetCell(IXLWorksheet worksheet, int row, int col, string value, string number_format = null)
		{
			// set the value
			worksheet.Cell(row, col).Value = value;

			if (number_format != null)
			{
				worksheet.Cell(row, col).Style.NumberFormat.Format = number_format;
			}

			// set the borders
			worksheet.Cell(row, col).Style.Border.RightBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.TopBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
			worksheet.Cell(row, col).Style.Border.RightBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.LeftBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.TopBorderColor = XLColor.Black;
			worksheet.Cell(row, col).Style.Border.BottomBorderColor = XLColor.Black;
		}
	}

	public static class TreeViewUtilities
	{
		public static IEnumerable<TreeNode> CollectTreeNodes(TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				yield return node;

				foreach (var child in CollectTreeNodes(node.Nodes))
					yield return child;
			}
		}

		public static void ExpandToLevel(TreeNodeCollection nodes, int level)
		{
			if (level > 0)
			{
				foreach (TreeNode node in nodes)
				{
					node.Expand();
					ExpandToLevel(node.Nodes, level - 1);
				}
			}
		}
	}

	public static class ObjectTreeViewUtilities
	{
		public static void ExpandToLevel<T>(TreeListView treeListView, List<T> objects, int level)
		{
			if (level > 0)
			{
				foreach (object node in objects)
				{
					treeListView.Expand(node);
					ExpandToLevel(treeListView, objects, level - 1);
				}
			}
		}
	}

	public static class PurelyemailUtilities
	{
		public class TResponse
		{
			public string type { get; set; } = "";
			public string code { get; set; }
			public string message { get; set; }

			public bool successful
			{
				get
				{
					return type == "success";
				}
			}
		}

		public static HttpClient Client;

		static PurelyemailUtilities()
		{
			Client = new HttpClient();

			string email_api_key = SettingsHandler.GetSetting("Email.API.Key", "pm-live-eace83da-880e-449f-ab8e-f31b1e25c728");

			Client.BaseAddress = new Uri("https://purelymail.com/");
			Client.DefaultRequestHeaders.Add("Purelymail-Api-Token", email_api_key);
		}

		#region https://purelymail.com/api/v0/listUser
		class TListUsersResponse : TResponse
		{
			public TListUsersReponseResult result { get; set; }
		}

		class TListUsersReponseResult
		{
			public List<string> users { get; set; }
		}

		public static async Task<List<string>> ListUser()
		{
			var response = await Client.PostAsync("/api/v0/listUser", new StringContent("{}", Encoding.UTF8, "application/json"));

			if (response.IsSuccessStatusCode == false)
			{
				Utilities.ShowErrorDialog($"Purelymail API responded with code: {response.StatusCode}");
				return null;
			}

			string raw_json = await response.Content.ReadAsStringAsync();

			TListUsersResponse? json = JsonSerializer.Deserialize<TListUsersResponse>(raw_json);

			if (json == null)
				return null;

			return json.result.users;
		}
		#endregion

		#region https://purelymail.com/api/v0/createUser
		public class TCreateUserRequest()
		{
			public string userName { get; set; }
			public string domainName { get; set; }
			public string password { get; set; }
			public bool enablePasswordReset { get; set; }
			public string recoverEmail { get; set; }
			public string recoveryEmailDescription { get; set; }
			public string recoveryPhone { get; set; }
			public string recoveryPhoneDescription { get; set; }
			public bool enableSearchIndexing { get; set; }
			public bool sendWelcomeEmail { get; set; }
		}

		public class TCreateUserResponse : TResponse
		{

		}

		public static async Task<TCreateUserResponse> CreateUser(string user, string domain, string password, bool allow_password_reset)
		{
			TCreateUserRequest json = new TCreateUserRequest()
			{
				userName = user,
				domainName = domain,
				password = password,
				recoverEmail = "lmerino@purelymail.com",
				recoveryEmailDescription = "email del administrador",
				recoveryPhone = "",
				recoveryPhoneDescription = "",
				enablePasswordReset = allow_password_reset,
				enableSearchIndexing = false,
				sendWelcomeEmail = false
			};

			string raw_json = JsonSerializer.Serialize(json);

			var raw_response = await Client.PostAsync("/api/v0/createUser", new StringContent(raw_json, Encoding.UTF8, "application/json"));

			raw_response.EnsureSuccessStatusCode();

			raw_json = await raw_response.Content.ReadAsStringAsync();

			TCreateUserResponse response = JsonSerializer.Deserialize<TCreateUserResponse>(raw_json);

			return response;
		}
		#endregion

		#region https://purelymail.com/api/v0/getUser

		class TGetUserRequest()
		{
			public string UserName { get; set; }
		}

		public class TGetUserResponse()
		{
			public TGetUserResponseResult Result { get; set; }
		}

		public class TGetUserResponseResult()
		{
			public bool EnableSearchIndexing { get; set; }
			public bool RecoveryEnabled { get; set; }
			public bool RequireTwoFactorAuthentication { get; set; }
			public bool EnableSpamFiltering { get; set; }
		}

		public static async Task<TGetUserResponse> GetUser(string user)
		{
			TGetUserRequest? json = new TGetUserRequest()
			{
				UserName = user,
			};

			string raw_json = JsonSerializer.Serialize(json);

			var response = await Client.PostAsync("/api/v0/getUser", new StringContent(raw_json, Encoding.UTF8, "application/json"));

			if (response.IsSuccessStatusCode == false)
			{
				Utilities.ShowErrorDialog($"Purelymail API responded with code: {response.StatusCode}");
				return null;
			}

			TGetUserResponse info = JsonSerializer.Deserialize<TGetUserResponse>(raw_json);

			return info;
		}
		#endregion

		#region https://purelymail.com/api/v0/listDomain

		class TListDomainRequest
		{
			public bool includeShared { get; set; }
		}

		public class TListDomainResponse : TResponse
		{
			public TListDomainResponseResult result { get; set; }
		}

		public class TListDomainResponseResult 
		{
			public List<TDomain> domains { get; set; }
		}

		public class TDomain
		{
			public string name { get; set; }
			public bool allowAccountReset { get; set; }
			public bool symbolicSubaddressing { get; set; }
			public bool isShared { get; set; }

			public TDNSSummary dNSSummary { get; set; }
		}

		public class TDNSSummary
		{
			public bool passesMx { get; set; }
			public bool passesSpf { get; set; }
			public bool passesDkim { get; set; }
			public bool passesDmarc { get; set; }
		}

		public static async Task<TListDomainResponse> ListDomain()
		{
			TListDomainRequest request = new TListDomainRequest()
			{
				includeShared = true,
			};

			string raw_json = JsonSerializer.Serialize(request);

			HttpResponseMessage raw_response = await Client.PostAsync("/api/v0/listDomains", new StringContent(raw_json, Encoding.UTF8, "application/json"));

			raw_response.EnsureSuccessStatusCode();

			raw_json = await raw_response.Content.ReadAsStringAsync();

			TListDomainResponse response = JsonSerializer.Deserialize<TListDomainResponse>(raw_json);

			return response;
		}

		#endregion

		#region https://purelymail.com/api/v0/checkAccountCredit 
		public class TCheckAccountCreditResponse : TResponse
		{
			public TCheckAccountCreditResponseResult result { get; set; }
		}

		public class TCheckAccountCreditResponseResult
		{
			public string credit { get; set; }
			public double dCredit
			{
				get
				{
					return Double.Parse(credit);
				}
			}
		}

		public static async Task<TCheckAccountCreditResponse> CheckAccountCredit()
		{
			HttpResponseMessage raw_response = await Client.PostAsync("/api/v0/checkAccountCredit", new StringContent("{}", Encoding.UTF8, "application/json"));

			raw_response.EnsureSuccessStatusCode();

			string raw_json = await raw_response.Content.ReadAsStringAsync();

			TCheckAccountCreditResponse response = JsonSerializer.Deserialize<TCheckAccountCreditResponse>(raw_json);

			return response;
		}

		#endregion

		public static void ShowPurelymailResponseErrorDialog(TResponse response)
		{
			Utilities.ShowErrorDialog(response.message, response.code);
		}
	}

	public static class SevenZipUtilities
	{
		private static string zip_exe;

		static SevenZipUtilities()
		{
			zip_exe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs\\7za.exe");	
		}

		public static async Task<string> UnzipFile(string zip_file, string output_directory)
		{
			if (Directory.Exists(output_directory) == false)
				Directory.CreateDirectory(output_directory);

			ProcessStartInfo start_info = new ProcessStartInfo()
			{
				FileName = zip_exe,
				Arguments = $"x \"{zip_file}\" -o\"{output_directory}\" -y",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true,
			};

			Process process = new Process()
			{
				StartInfo = start_info,
			};

			process.Start();
			process.WaitForExitAsync();

			return "";
		}
	}

  public static class  GithubUtilities
  {
		public class GithubAsset
		{
			public string url { get; set; }
			public int id { get; set; }
			public string node_id { get; set; }
			public string name { get; set; }
			public object label { get; set; }
			public GithubUploader uploader { get; set; }
			public string content_type { get; set; }
			public string state { get; set; }
			public int size { get; set; }
			public int download_count { get; set; }
			public DateTime created_at { get; set; }
			public DateTime updated_at { get; set; }
			public string browser_download_url { get; set; }
		}

		public class GithubAuthor
		{
			public string login { get; set; }
			public int id { get; set; }
			public string node_id { get; set; }
			public string avatar_url { get; set; }
			public string gravatar_id { get; set; }
			public string url { get; set; }
			public string html_url { get; set; }
			public string followers_url { get; set; }
			public string following_url { get; set; }
			public string gists_url { get; set; }
			public string starred_url { get; set; }
			public string subscriptions_url { get; set; }
			public string organizations_url { get; set; }
			public string repos_url { get; set; }
			public string events_url { get; set; }
			public string received_events_url { get; set; }
			public string type { get; set; }
			public string user_view_type { get; set; }
			public bool site_admin { get; set; }
		}

		public class GithubRelease
		{
			public string url { get; set; }
			public string assets_url { get; set; }
			public string upload_url { get; set; }
			public string html_url { get; set; }
			public int id { get; set; }
			public GithubAuthor author { get; set; }
			public string node_id { get; set; }
			public string tag_name { get; set; }
			public string target_commitish { get; set; }
			public string name { get; set; }
			public bool draft { get; set; }
			public bool prerelease { get; set; }
			public DateTime created_at { get; set; }
			public DateTime published_at { get; set; }
			public List<GithubAsset> assets { get; set; }
			public string tarball_url { get; set; }
			public string zipball_url { get; set; }
			public string body { get; set; }
		}

		public class GithubUploader
		{
			public string login { get; set; }
			public int id { get; set; }
			public string node_id { get; set; }
			public string avatar_url { get; set; }
			public string gravatar_id { get; set; }
			public string url { get; set; }
			public string html_url { get; set; }
			public string followers_url { get; set; }
			public string following_url { get; set; }
			public string gists_url { get; set; }
			public string starred_url { get; set; }
			public string subscriptions_url { get; set; }
			public string organizations_url { get; set; }
			public string repos_url { get; set; }
			public string events_url { get; set; }
			public string received_events_url { get; set; }
			public string type { get; set; }
			public string user_view_type { get; set; }
			public bool site_admin { get; set; }
		}
	
		public static async Task<GithubRelease> GetLatestRelease()
		{
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.UserAgent.ParseAdd($"GCRM/{Utilities.GetProductVersion()}");

				var response = await client.GetAsync("https://api.github.com/repos/Wissenss/GCRM/releases/latest");

				response.EnsureSuccessStatusCode();

				string raw_json = await response.Content.ReadAsStringAsync();

				GithubRelease release = JsonSerializer.Deserialize<GithubRelease>(raw_json);

				return release;
			}
		}

		public static async Task<string> DownloadLatestRelease(TOperatingSystem os, string output_file)
		{
			GithubRelease release = await GetLatestRelease();
			GithubAsset asset = null;

			if (os == TOperatingSystem.WindowsX64)
				asset = release.assets.Find(a => a.name.EndsWith("x64.7z"));

			if (os == TOperatingSystem.WindowsX86)
				asset = release.assets.Find(a => a.name.EndsWith("x86.7z"));

			if (asset == null)
				throw new Exception("No known version found for the target operating system.");

			if (Directory.Exists(Path.GetDirectoryName(output_file)) == false)
				Directory.CreateDirectory(Path.GetDirectoryName(output_file));

			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.UserAgent.ParseAdd($"GCRM/{Utilities.GetProductVersion()}");

				using (var s = await client.GetStreamAsync(asset.browser_download_url))
				{
					using (var fs = new FileStream(output_file, FileMode.Create))
					{
						await s.CopyToAsync(fs);
					}
				}
			}
			
			return "";
		}
	}
}
