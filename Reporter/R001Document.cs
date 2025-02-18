using Business;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace Reporter
{
	public class R001DocumentModel
	{
		public TPoliticalParty? PoliticalParty;
		public TSex? Sex;
		public TCitizenTitle? CitizenTitle;
		public TSocietySector? SocietySector;
		
		public TInstitution? Institution;
		public TInstitutionCategory? InstitutionCategory;

		public List<TCitizen> CitizenList;
	}

	public class R001Document : IDocument
	{
		R001DocumentModel Model;

		public R001Document(R001DocumentModel model)
		{
			QuestPDF.Settings.License = LicenseType.Community;

			Model = model;
		}

		public DocumentMetadata GetMetadata()
		{
			DocumentMetadata metadata = new DocumentMetadata();

			metadata.Title = "R001_CatalogoCiudadanos";
			metadata.Author = "GCRM";

			return metadata;
		}

		public void Compose(IDocumentContainer container)
		{
			container.Page(page =>
			{
				page.Margin(20);
				
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
							.Text($"001 - Catálogo de ciudadanos")
							.FontSize(15).SemiBold().FontColor(Colors.Black);

					column.Item().BorderTop(1).BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(5).Element(ComposeHeaderDetail);
						
				});
			});
		}

		void ComposeHeaderDetail(IContainer container)
		{
			string str_political_party = "Partido: Cualquiera";
			string str_sex = "Sexo: Cualquiera";
			string str_citizen_title = "Título: Cualquiera";
			string str_institution = "Institución: Cualquiera";
			string str_sector = "Sector: Cualquiera";
			string str_category = "Categoría: Cualquiera";
			
			float filter_font_size = 9;

			container.Column(column =>
			{
				if (Model.PoliticalParty != null)
				{
					str_political_party = $"Partido: {BConstants.GetPoliticalPartyOfficialName((TPoliticalParty)Model.PoliticalParty)}";
					column.Item().PaddingLeft(1).Text(str_political_party).FontSize(filter_font_size);
				}

				if (Model.Sex != null)
				{ 
					str_sex = $"Sexo: {BConstants.GetSexName((TSex)Model.Sex)}";
					column.Item().PaddingLeft(1).Text(str_sex).FontSize(filter_font_size);
				}

				if (Model.CitizenTitle != null)
				{
					str_citizen_title = $"Título: {BConstants.GetCitizenFullTitle((TCitizenTitle)Model.CitizenTitle)}";
					column.Item().PaddingLeft(1).Text(str_citizen_title).FontSize(filter_font_size);
				}

				if (Model.Institution != null)
				{
					str_institution = $"Institución: {Model.Institution.Name}";
					column.Item().PaddingLeft(1).Text(str_institution).FontSize(filter_font_size);
				}

				if (Model.SocietySector != null)
				{
					str_sector = $"Sector: {BConstants.GetSocietySectorName((TSocietySector)Model.SocietySector)}";
					column.Item().PaddingLeft(1).Text(str_sector).FontSize(filter_font_size);
				}

				if (Model.InstitutionCategory != null)
				{
					str_category = $"Categoría: {Model.InstitutionCategory.Name}";
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
					columns.ConstantColumn(50);
					columns.ConstantColumn(120);
					columns.RelativeColumn();
					columns.RelativeColumn();
					columns.RelativeColumn();
					columns.ConstantColumn(50); 
				});

				table.Header(header =>
				{
					float header_font_size = 8;

					header.Cell().Element(CellStyle).Text("Título").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Nombre").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Institución").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Teléfono").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Celular").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Nacimiento").FontSize(header_font_size).SemiBold();
						
					static IContainer CellStyle(IContainer container)
					{
						return container.BorderBottom(0.3F).BorderTop(0.1f).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten4).Padding(0.5f);
					}
				});

				foreach (var citizen in Model.CitizenList)
				{
					float row_font_size = 8;

					table.Cell().Element(CellStyle).Text(BConstants.GetCitizenBriefTitle(citizen.Title)).FontSize(row_font_size);
					table.Cell().Element(CellStyle).Text($"{citizen.Name} {citizen.PaternalName} {citizen.MaternalName}").FontSize(row_font_size);
					table.Cell().Element(CellStyle).Text(citizen.Institution.Name).FontSize(row_font_size);

					if (citizen.PhoneExtension.Trim().Length > 0)
						table.Cell().Element(CellStyle).Text($"{citizen.Phone} Ext. {citizen.PhoneExtension}").FontSize(row_font_size);
					else
						table.Cell().Element(CellStyle).Text($"{citizen.Phone}").FontSize(row_font_size);

					table.Cell().Element(CellStyle).Text(citizen.Cellphone).FontSize(row_font_size);
					table.Cell().Element(CellStyle).Text(citizen.Birthday.ToString("dd/MM/yyyy")).FontSize(row_font_size);

					static IContainer CellStyle(IContainer container)
					{
						return container.BorderBottom(0.1f).BorderColor(Colors.Grey.Lighten2).Padding(0.5f);
					}
				}
			});
		}

		void ComposeFooter(IContainer container)
		{
			float footer_font_size = 6;

			container.Row(row =>
			{
				row.RelativeItem().Element(e => e.AlignLeft().Text($"GCRM - Generado por: {Session.User.Name}").FontSize(footer_font_size));
				row.RelativeItem().Element(e => e.AlignRight().Text($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}").FontSize(footer_font_size));
			});
			//container.AlignRight().Text().FontSize(6);
			//container.AlignCenter().Text(x =>
			//{
			//	x.CurrentPageNumber();
			//	x.Span(" / ");
			//	x.TotalPages();
			//});
		}
	}
}
