using Business;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace Reporter
{

	public class R004DocumentModel
	{
		public TInstitutionCategory? Category;
		public TSocietySector? SocietySector; 

		public List<TInstitution> Institutions = new List<TInstitution>();
	}

	public class R004Document : IDocument
	{
		R004DocumentModel Model;

		public R004Document(R004DocumentModel model)
		{
			QuestPDF.Settings.License = LicenseType.Community;

			Model = model;
		}

		public DocumentMetadata GetMetadata()
		{
			DocumentMetadata metadata = new DocumentMetadata();

			metadata.Title = "R004_CatalogoInstituciones";
			metadata.Author = "GCRM";

			return metadata;
		}

		public void Compose(IDocumentContainer container)
		{
			container.Page(page =>
			{
				page.Margin(15);

				page.Header().Element(ComposeHeader);
				page.Content().Element(ComposeContent);
				page.Footer().Element(ComposeFooter);
			});
		}

		void ComposeHeader(IContainer container)
		{
			container.Row(row =>
			{
				row.RelativeItem().Column(column =>
				{
					column.Item()
							.PaddingBottom(5)
							.Text($"004 - Catálogo de instituciones")
							.FontSize(15).SemiBold().FontColor(Colors.Black);

					column.Item().BorderTop(1).BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(5).Element(ComposeHeaderDetail);
				});
			});
		}

		void ComposeHeaderDetail(IContainer container)
		{
			string str_sector = "Sector: Cualquiera";
			string str_category = "Categoría: Cualquiera";

			float filter_font_size = 9;

			container.Column(column =>
			{
				if (Model.SocietySector != null)
				{
					str_sector = $"Sector: {BConstants.GetSocietySectorName((TSocietySector)Model.SocietySector)}";
					column.Item().PaddingLeft(1).Text(str_sector).FontSize(filter_font_size);
				}

				if (Model.Category != null)
				{
					str_category = $"Categoría: {Model.Category.Name}";
					column.Item().PaddingLeft(1).Text(str_category).FontSize(filter_font_size);
				}
			});
		}

		void ComposeContent(IContainer container)
		{
			container
				.PaddingVertical(5)
				.AlignLeft()
				.AlignTop()
				.Column(column =>
				{
					column.Item().Element(ComposeTable);
				});
		}

		void ComposeTable(IContainer container)
		{
			container.Table(table =>
			{
				table.ColumnsDefinition(columns =>
				{
					columns.RelativeColumn();
					columns.ConstantColumn(120);
					columns.ConstantColumn(60);
				});

				table.Header(header =>
				{
					float header_font_size = 8;

					header.Cell().Element(CellStyle).Text("Institución").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Categoría").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Sector").FontSize(header_font_size).SemiBold();

					static IContainer CellStyle(IContainer container)
					{
						return container.BorderBottom(0.3F).BorderTop(0.1f).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten4).Padding(0.5f);
					}
				});

				foreach (var institution in Model.Institutions)
				{
					float row_font_size = 8;

					table.Cell().Element(CellStyle).Column(column =>
					{
						column.Item().Text($"{institution.Name}").FontSize(row_font_size).SemiBold();
						
						if (institution.Description.Trim().Length > 0)
							column.Item().Text($"{institution.Description}").FontSize(row_font_size * 0.7f).Italic();
					});

					table.Cell().Element(CellStyle).Text(institution.Category.Name).FontSize(row_font_size);
					table.Cell().Element(CellStyle).Text(BConstants.GetSocietySectorName(institution.Sector)).FontSize(row_font_size);

					static IContainer CellStyle(IContainer container)
					{
						return container.BorderBottom(0.1f).BorderColor(Colors.Grey.Lighten2).Padding(0.5f).PaddingBottom(1.5f).PaddingTop(1.5f);
					}
				}
			});
		}

		void ComposeFooter(IContainer container)
		{
			float footer_font_size = 6;

			string version = BConstants.GetProductVersion();

			container.Row(row =>
			{
				row.RelativeItem().Element(e => e.AlignLeft().Text($"GCRM {version} - Generado por: {Session.User.Name}").FontSize(footer_font_size));
				row.RelativeItem().Element(e => e.AlignRight().Text($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}").FontSize(footer_font_size));
			});
		}
	}
}
