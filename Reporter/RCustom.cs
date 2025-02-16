using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Reporter
{
	public abstract class RCustom
	{
		public IDocument RDocument;

		public abstract Error PrepareReport();

		public void GeneratePdfAndShow()
		{
			PrepareReport();

			RDocument.GeneratePdfAndShow();
		}

		public void GeneratePDFWithNameAndShow(string name)
		{
			PrepareReport();

			string file_path = Path.Join(Path.GetTempPath(), name);

			RDocument.GeneratePdf(file_path);

			using var process = new Process
			{
				StartInfo = new ProcessStartInfo(file_path)
				{
					UseShellExecute = true
				}
			};
		}
	}
}
