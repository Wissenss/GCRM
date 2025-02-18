using Connection;
using System;
using System.Diagnostics;

namespace GCRMCLI
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string action = GetArg(args, 0);

			Console.WriteLine(action);	

			if (action.ToLower() == "backup")
			{
				string output_file = GetOption(args, "-f");

				CmdBackup(args, output_file);
			}
			else
			{
				CmdHelp();
			}
		}

		private static string GetArg(string[] args, int arg_pos, string _default = "")
		{
			if (args.Length > arg_pos)
			{
				return args[arg_pos];
			}

			return _default;
		}

		private static int FindArg(string[] args, string looking_for)
		{
			for (int i = 0; i<args.Count(); i++)
			{
				if (args[i] == looking_for)
				{
					return i;
				}
			}

			return -1;
		}

		private static string GetOption(string[] args, string option, string _default = "")
		{
			int option_pos = FindArg(args, option);

			if (option_pos != -1 && args.Count() > option_pos)
			{
				return args[option_pos + 1];
			}
			else
			{
				return _default;
			}
		}

		private static bool ConnectToDB()
		{
			Console.WriteLine("Connecting to postgress server...");
			Console.WriteLine("  host: ............ {0}", ConnectionSettings.Host);
			Console.WriteLine("  port: ............ {0}", ConnectionSettings.Port);
			Console.WriteLine("  database: ........ {0}", ConnectionSettings.Database);

			if (ConnectionSettings.TestSettings() == false)
			{
				Console.WriteLine("  CONNECTION FAILED!!!");
				return false;
			}

			Console.WriteLine("  connection succesful");
			return true;
		}

		private static void EnsurePgpassFile()
		{
			//string file_path = Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, $".pgpass");
			string file_path = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"postgresql\pgpass.conf");

			if (File.Exists(file_path) == false)
			{
				Console.WriteLine(".pgpass file does not exist, now creating...");

				if (Directory.Exists(Path.GetDirectoryName(file_path)) == false);
					Directory.CreateDirectory(Path.GetDirectoryName(file_path));

				using (StreamWriter writer = File.CreateText(file_path))
				{
					writer.WriteLine($"{ConnectionSettings.Host}:{ConnectionSettings.Port}:{ConnectionSettings.Database}:{ConnectionSettings.Username}:{ConnectionSettings.Password}");
				}

				Console.WriteLine($"File created at: {file_path}");
			}

			Console.WriteLine(".pgpass file exists!");
		}

		private static void CmdBackup(string[] args, string output_file)
		{
			if (output_file == "")
			{
				output_file = Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, $"backup_DATE.sql");
			}

			output_file = output_file.Replace("DATE", DateTime.Now.ToString("yyyyMMddhhmmss"));

			if (ConnectToDB() == false)
			{
				return;
			}

			Console.WriteLine("Starting backup...");

			EnsurePgpassFile();

			using (Process process = new Process())
			{
				process.StartInfo = new ProcessStartInfo()
				{
					FileName = "pg_dump",
					Arguments = $"-U {ConnectionSettings.Username} -w -d {ConnectionSettings.Database} -f {output_file}",
					UseShellExecute = false,
					RedirectStandardError = true,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
				};

				Console.WriteLine($"executing: {process.StartInfo.FileName} {process.StartInfo.Arguments}");

				process.Start();

				process.WaitForExit();

				Console.WriteLine($"exit code: {process.ExitCode} output: {process.StandardOutput.ReadToEnd()}");
			}

			Console.WriteLine("Backup finished!");
			Console.WriteLine("  output: .......... {0} ", output_file);
		}

		private static void CmdHelp()
		{
			Console.WriteLine("GCRMCLI utility, database mantainace and more for the GCRM application");

			Console.WriteLine("init");
			Console.WriteLine("initialize the database with a fresh schema");

			Console.WriteLine("update");
			Console.WriteLine("update the database schema to the latest version");

			Console.WriteLine("backup -f <output_file>");
			Console.WriteLine("create a backup of the database, internally calling pg_dump for the configured db");
			Console.WriteLine("parameters: ");
			Console.WriteLine("  <output_file>: specifiy the path path of the file. the text \"DATETIME\" will be replaced the current date and time if used.");

			Console.WriteLine("restore -f <input_file>");
			Console.WriteLine("loads the given <input_file> backup into the database (hopefully this wont be used)");
		}
	}
}