using BrightIdeasSoftware;
using Business;
using Business.Business;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using GCRM.Domain.Enums;
using NLog;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using WeCantSpell.Hunspell;

namespace GCRM
{
    public static class Utilities
    {
        public static bool IsVowel(char c)
        {
            char c_without_diacritics = GetLetterWithoutDiacritics(c);

            return "aeiou".IndexOf(c_without_diacritics.ToString()) >= 0;
        }

        public static char GetLetterWithoutDiacritics(char c)
        {
            string character = c.ToString().ToLower();

            if ("aá".IndexOf(character) >= 0)
                return 'a';

            if ("eé".IndexOf(character) >= 0)
                return 'e';

            if ("ií".IndexOf(character) >= 0)
                return 'i';

            if ("oó".IndexOf(character) >= 0)
                return 'o';

            if ("uúü".IndexOf(character) >= 0)
                return 'u';

            return character.ToCharArray()[0];
        }

        public static string GetStringWithoutDiacritics(string input)
        {
            var result = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = GetLetterWithoutDiacritics(input[i]);
            }

            return new string(result);
        }

        public static int TrimOnRange(int lowest_value, int highest_value, int value)
        {
            value = Math.Max(value, lowest_value);
            value = Math.Min(value, highest_value);

            return value;
        }

        public static void ShowErrorDialog(GCRM.Domain.Enums.Error error)
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

        public static DialogResult ShowConfirmDialog(string message)
        {
            DialogResult result = MessageBox.Show(
                message,
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
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

    public static class SettingsUtilities
    {
        public class FormConfiguration
        {
            public int width { get; set; } = 200;

            public int height { get; set; } = 200;
        }

        public class TabControlConfiguration
        {
            public int selectedIndex { get; set; }
        }

        public class InstanceConfiguration 
        {
            // this are settings that are meant to control how the system behaves in each
            // specific installation, for example, if a specific feature is enabled or not, or if a specific behavior is enabled or not
            // mainly to control certain windows version who may not play well with certain features of the system

            public bool UseExternalPDFViewer { get; set; }
        }

        public static void SaveInstanceConfiguration(InstanceConfiguration setting)
        {
            SaveLocalPersistentSetting(setting, "instance_configuration");
        }

        public static InstanceConfiguration LoadInstanceConfiguration()
        {
            InstanceConfiguration setting = GetLocalPersistentSetting<InstanceConfiguration>("instance_configuration");
            
            if (setting == null)
                setting = new InstanceConfiguration();

            return setting;
        }

        private static string GetTempSettingFullPath(string path)
        {
            path = Path.Join(Path.GetTempPath(), "GCRM", "gcrm_temp_settings", $"{path}.xml");

            return path;
        }

        private static string GetLocalPersistentSettingFullPath(string path)
        {
            string app_data = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            path = Path.Join(app_data, "GCRM", "gcrm_persistent_settings", $"{path}.xml");
         
            return path;
        }

        public static void SaveXmlSetting<T>(T setting, string path)
        {
            string directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (var writer = new StreamWriter(path))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, setting);
            }
        }

        public static T ReadXmlSetting<T>(string path)
        {
            if (!File.Exists(path))
                return default(T);

            using (var reader = new StreamReader(path))
            {
                var serializer = new XmlSerializer(typeof(T));
                var setting = (T)serializer.Deserialize(reader);

                return setting;
            }
        }

        public static void SaveTempSetting<T>(T setting, string path)
        {
            path = GetTempSettingFullPath(path);

            SaveXmlSetting(setting, path);
        }

        public static T GetTempSetting<T>(string path)
        {
            path = GetTempSettingFullPath(path);

            return ReadXmlSetting<T>(path);
        }

        public static void SaveLocalPersistentSetting<T>(T setting, string path)
        {
            path = GetLocalPersistentSettingFullPath(path);
            SaveXmlSetting(setting, path);
        }

        public static T GetLocalPersistentSetting<T>(string path)
        {
            path = GetLocalPersistentSettingFullPath(path);
            return ReadXmlSetting<T>(path);
        }

        public static bool TempSettingExists(string path)
        {
            path = GetTempSettingFullPath(path);

            return File.Exists(path);
        }

        public static void LoadFormConfiguration(Form form, string path)
        {
            if (SettingsUtilities.TempSettingExists(path) == false)
                return;

            var setting = SettingsUtilities.GetTempSetting<FormConfiguration>(path);

            form.Width = setting.width;
            form.Height = setting.height;
        }

        public static void TryLoadFormConfiguration(Form form, string path)
        {
            try
            {
                LoadFormConfiguration(form, path);
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }
        }

        public static void SaveFormConfiguration(Form form, string path)
        {
            var setting = new FormConfiguration();

            setting.width = form.Width;
            setting.height = form.Height;

            if (form.WindowState != FormWindowState.Normal)
                return;

            SettingsUtilities.SaveTempSetting(setting, path);
        }

        public static void TrySaveFormConfiguration(Form form, string path)
        {
            try
            {
                SaveFormConfiguration(form, path);
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }
        }

        public static void LoadTabControlConfiguration(TabControl tab_control, string path)
        {
            if (SettingsUtilities.TempSettingExists(path) == false)
                return;

            var setting = SettingsUtilities.GetTempSetting<TabControlConfiguration>(path);

            tab_control.SelectedIndex = setting.selectedIndex;
        }

        public static void TryLoadTabControlConfiguration(TabControl tab_control, string path)
        {
            try
            {
                LoadTabControlConfiguration(tab_control, path);
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }
        }

        public static void SaveTabControlConfiguration(TabControl tab_control, string path)
        {
            var setting = new TabControlConfiguration();

            setting.selectedIndex = tab_control.SelectedIndex;

            SettingsUtilities.SaveTempSetting(setting, path);
        }

        public static void TrySaveTabControlConfiguration(TabControl tab_control, string path)
        {
            try
            {
                SaveTabControlConfiguration(tab_control, path);
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }
        }
    }

    public enum DataGridColumnType
    {
        TextBox,
        CheckBox
    }

    public static class DataGridUtilities
    {
        public class DataGridViewColumnConfiguration
        {
            public string Name { get; set; }
            public int DisplayIndex { get; set; }
            public int Width { get; set; }
            public bool Visible { get; set; }
        }

        public class DataGridViewConfiguration
        {
            public List<DataGridViewColumnConfiguration> columns { get; set; } = new List<DataGridViewColumnConfiguration>();
        }

        public static DataGridViewColumn AddColumn(DataGridView data_grid, string col_name, string header_text, string data_property_name, bool visible = true, int display_index = 0, int width = 100, int min_width = 20, DataGridViewAutoSizeColumnMode auto_size_mode = DataGridViewAutoSizeColumnMode.None, DataGridColumnType column_type = DataGridColumnType.TextBox)
        {
            DataGridViewColumn column = new DataGridViewColumn();

            // cell template
            DataGridViewCell cell = column_type == DataGridColumnType.CheckBox ? new DataGridViewCheckBoxCell() : new DataGridViewTextBoxCell();
            column.CellTemplate = cell;
            column.ReadOnly = column_type == DataGridColumnType.CheckBox;

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

            return column;
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

        public static void LoadConfiguration(DataGridView data_grid, string path)
        {
            if (SettingsUtilities.TempSettingExists(path) == false)
                return;

            var setting = SettingsUtilities.GetTempSetting<DataGridViewConfiguration>(path);

            foreach (var column in setting.columns)
            {
                foreach (DataGridViewColumn grid_column in data_grid.Columns)
                {
                    if (grid_column.Name == column.Name)
                    {
                        grid_column.DisplayIndex = column.DisplayIndex;
                        grid_column.Width = column.Width;
                        grid_column.Visible = column.Visible;

                        break;
                    }
                }
            }
        }

        public static void TryLoadConfiguration(DataGridView data_Grid, string path)
        {
            try
            {
                LoadConfiguration(data_Grid, path);
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }
        }

        public static void SaveConfiguration(DataGridView data_grid, string path)
        {
            var setting = new DataGridViewConfiguration();

            setting.columns.Clear();

            foreach (DataGridViewColumn column in data_grid.Columns)
            {
                setting.columns.Add(new DataGridViewColumnConfiguration()
                {
                    Name = column.Name,
                    DisplayIndex = column.DisplayIndex,
                    Width = column.Width,
                    Visible = column.Visible,
                });
            }

            SettingsUtilities.SaveTempSetting(setting, path);
        }

        public static void TrySaveConfiguration(DataGridView data_grid, string path)
        {
            try
            {
                SaveConfiguration(data_grid, path);
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }
        }

        public static string GetFilterCondititonForTextSearch(DataGridView data_grid, DataTable dt, string search)
        {
            string search_condition = " and ( false or ";

            foreach (DataGridViewColumn column in data_grid.Columns)
            {
                if (column.Visible)
                {
                    if (dt.Columns.Contains(column.DataPropertyName) == false)
                        continue;

                    if (dt.Columns[column.DataPropertyName].DataType == typeof(string))
                    {
                        search_condition += $"{column.DataPropertyName} like '%{search}%' or ";
                    }
                    else if (dt.Columns[column.DataPropertyName].DataType == typeof(int))
                    {
                        int number;

                        if (Int32.TryParse(search, out number))
                            search_condition += $"{column.DataPropertyName} = {number} or ";
                    }
                }
            }

            search_condition = search_condition.TrimEnd("or ".ToCharArray()) + ")";

            return search_condition;
        }

        public static void ExportToExcel(DataGridView dataGrid, string filePath, string title = "")
        {
            try
            {
                using (new CursorWait())
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(dataGrid.Name);

                    XLColor headersColor = XLColor.LightGray;
                    int colIndex = 1;
                    int rowIndex = 1;

                    if (string.IsNullOrEmpty(title) == false)
                    {
                        int visibleColumnCount = 0;

                        foreach (DataGridViewColumn column in dataGrid.Columns)
                        {
                            if (column.Visible)
                                visibleColumnCount++;
                        }

                        if (visibleColumnCount > 1)
                            worksheet.Range(rowIndex, 1, rowIndex, visibleColumnCount).Merge();

                        ExcelUtilities.SetWorksheetHeaderCell(worksheet, rowIndex, colIndex, title, headersColor);

                        rowIndex++;
                    }

                    // create the headers
                    foreach (DataGridViewColumn column in dataGrid.Columns)
                    {
                        if (column.Visible == false)
                            continue;

                        ExcelUtilities.SetWorksheetHeaderCell(worksheet, rowIndex, colIndex, column.HeaderText, headersColor, 50);

                        colIndex++;
                    }

                    rowIndex++;

                    // fill each row
                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.OwningColumn.Visible == false)
                                continue;

                            try
                            {
                                string textValue = "";

                                if (cell.Value is DBNull)
                                    textValue = "";
                                else
                                    textValue = cell.Value.ToString();

                                ExcelUtilities.SetWorksheetCell(worksheet, rowIndex, colIndex, textValue);
                            }
                            finally
                            {
                                colIndex++;
                            }
                        }

                        rowIndex++;
                    }

                    workbook.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }
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

    public static class GithubUtilities
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

    public static class ComboboxUtilities
    {
        public static void SetEnumDataSource<T>(ComboBox combobox)
        {
            combobox.DataSource = Enum.GetValues(typeof(T));
        }
    }

    public static class SpellUtilities
    {
        public class SpellCheckResult
        {
            public bool Correct { get; set; }
            public string Word { get; set; }
            public List<string> Suggestions { get; set; } = new List<string>();
        }

        private static bool loaded = false;
        private static WordList word_list;

        static SpellUtilities()
        {
            TryLoadWordList();
        }

        public static bool TryLoadWordList()
        {
            if (loaded) 
                return true;

            try
            {
                word_list = WordList.CreateFromFiles(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Dictionaries", "es_MX.dic"));
                loaded = true;
            }
            catch (Exception ex)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(ex, "Failed to load spell check word list");
            }

            return loaded;
        }

        public static SpellCheckResult CheckWord(string text)
        {
            if (!loaded) // if the dictionary did not load, we cannot spell check, so we say its all good... 
            {
                return new SpellCheckResult()
                {
                    Correct = true,
                    Word = text,
                    Suggestions = new List<string>()
                };
            }

            WeCantSpell.Hunspell.SpellCheckResult result = word_list.CheckDetails(text);

            return new SpellCheckResult
            {
                Correct = result.Correct,
                Word = text,
                Suggestions = result.Correct ? new List<string>() : word_list.Suggest(text).ToList()
            };
        }

        public static List<SpellCheckResult> CheckText(string text)
        {
            List<SpellCheckResult> errors = new List<SpellCheckResult>();

            // clean up special characters

            text = text.Replace('\n', ' ');
            text = text.Replace('\t', ' ');
            text = text.Replace('\r', ' ');
            text = text.Replace('\v', ' ');
            text = text.Replace('\f', ' ');
            text = text.Replace('\b', ' ');
            text = text.Replace('\a', ' ');
            text = text.Replace('\0', ' ');

            string[] words = text.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);             // TrimeEntires + RemoveEmptyEntries, ensure only whitespace substrings are not return at all

            foreach (string word in words)
            {
                SpellCheckResult r = CheckWord(word);

                if (r.Correct == false)
                    errors.Add(r);
            }

            return errors;
        }

        public static List<SpellCheckResult> CheckInput(System.Windows.Forms.Control input)
        {
            return CheckText(input.Text.Trim());
        }

        public static List<SpellCheckResult> CheckInput(List<System.Windows.Forms.Control> inputs)
        {
            List<SpellCheckResult> errors = new List<SpellCheckResult>();

            foreach (var input in inputs)
            {
                errors.AddRange(CheckInput(input));
            }
            
            return errors;
        }

        public static DialogResult CheckInputWithDialog(List<System.Windows.Forms.Control> inputs)
        {
            var spellErrors = CheckInput(inputs);

            if (spellErrors.Count > 0)
            {
                StringBuilder spellErrorsText = new StringBuilder();

                spellErrorsText.AppendLine("Se identificaron los siguientes errores ortográficos: ");
                spellErrorsText.AppendLine();

                foreach (var spellError in spellErrors)
                {
                    spellErrorsText.AppendLine($"Palabra: {spellError.Word}. Sugerencias: {string.Join(", ", spellError.Suggestions)}");
                }

                spellErrorsText.AppendLine();
                spellErrorsText.Append("¿Desea continuar de todas formas?");

                return Utilities.ShowConfirmDialog(spellErrorsText.ToString()) == DialogResult.Yes ? DialogResult.OK : DialogResult.Cancel;
            }

            return DialogResult.OK;
        }

        public static DialogResult CheckInputsWithDialog(params System.Windows.Forms.Control[] inputs)
        {
            return CheckInputWithDialog(inputs.ToList());
        }
    }
}
