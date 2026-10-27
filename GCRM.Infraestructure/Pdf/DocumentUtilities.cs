
using System.Diagnostics;
using System.Reflection;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Reporter
{
    public static class DocumentUtilities
    {
        public static void ComposeReportFooter(IContainer container, string username)
        {
            float footer_font_size = 6;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.FileVersion;

            container.Row(row =>
            {
                row.RelativeItem().Element(e => e.AlignLeft().Text($"GCRM {version} - Generado por: {username}").FontSize(footer_font_size));
                row.RelativeItem().Element(e => e.AlignRight().Text($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}").FontSize(footer_font_size));
            });
        }
    }
}
