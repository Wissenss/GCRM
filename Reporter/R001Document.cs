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
	public enum TR001Order
	{
		CitizenName,
		CitizenBirthday,
	}

	public class R001DocumentModel
	{
		public TPoliticalParty? PoliticalParty;
		public TSex? Sex;
		public TCitizenTitle? CitizenTitle;
		public TSocietySector? SocietySector;
		
		public TInstitution? Institution;
		public TInstitutionCategory? InstitutionCategory;

		public int? BirthdayYear;
		public int? BirthdayMonth;
		public int? BirthdayDay;

		public TR001Order Order = TR001Order.CitizenName;

		public List<TCitizen> CitizenList = new List<TCitizen>();
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
			switch (Model.Order)
			{
				case TR001Order.CitizenName:
					Model.CitizenList = Model.CitizenList.OrderBy(m => m.Name).ToList(); break;
				case TR001Order.CitizenBirthday:
					Model.CitizenList = Model.CitizenList.OrderBy(m => Int32.Parse($"{m.Birthday.Month:D2}{m.Birthday.Day:D2}")).ToList(); break;
				default: break;
			}

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

			string str_birthday_year = "Año de nacimiento: Cualquiera";
			string str_birthday_month = "Mes de nacimiento: Cualquiera";
			string str_birthday_day = "Día de nacimiento: Cualquiera";
			
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

				if (Model.BirthdayYear != null)
				{
					str_birthday_year = $"Año de nacimiento: {Model.BirthdayYear}";
					column.Item().PaddingLeft(1).Text(str_birthday_year).FontSize(filter_font_size);
				}

				if (Model.BirthdayMonth != null)
				{
					str_birthday_month = $"Mes de nacimiento: {DateTimeFormatInfo.CurrentInfo.MonthNames[(int)Model.BirthdayMonth - 1]}";
					column.Item().PaddingLeft(1).Text(str_birthday_month).FontSize(filter_font_size);
				}

				if (Model.BirthdayDay != null)
				{
					str_birthday_day = $"Día de nacimiento: {Model.BirthdayDay}";
					column.Item().PaddingLeft(1).Text(str_birthday_day).FontSize(filter_font_size);
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
					columns.ConstantColumn(50);
				});

				table.Header(header =>
				{
					float header_font_size = 8;

					header.Cell().Element(CellStyle).Text("Ciudadano").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Contacto").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Cumpleaños").FontSize(header_font_size).SemiBold().AlignCenter();

					static IContainer CellStyle(IContainer container)
					{
						return container.BorderBottom(0.3F).BorderTop(0.1f).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten4).Padding(0.5f);
					}
				});

				foreach (var citizen in Model.CitizenList)
				{
					float row_font_size = 8;

					table.Cell().Element(CellStyle).Column(column =>
					{
						column.Item().Text($"{BConstants.GetCitizenBriefTitle(citizen.Title, citizen.Sex).ToUpper()} {citizen.FullName}").FontSize(row_font_size).SemiBold();
						column.Item().Text($"{citizen.Role.Name.ToUpper()} - {citizen.Institution.Name.ToUpper()}").FontSize(row_font_size);
					});

					string contact_str = "";

					if (citizen.Phone.Number.Length > 0)
						contact_str += $"{citizen.Phone.FullNumber.ToUpper()}\n";

					if (citizen.Phone2.Number.Length > 0)
						contact_str += $"{citizen.Phone2.FullNumber.ToUpper()}\n";

					if (citizen.Phone3.Number.Length > 0)
						contact_str += $"{citizen.Phone3.FullNumber.ToUpper()}\n";

					if (citizen.Cellphone.Length > 0)
						contact_str += $"CEL. {citizen.Cellphone.ToUpper()}";

					table.Cell().Element(CellStyle).Text(contact_str).FontSize(row_font_size);

					table.Cell().Element(CellStyle).Text(citizen.Birthday.ToString("d MMM").ToUpper()).FontSize(row_font_size).AlignCenter();

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

			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fileVersionInfo.ProductVersion;

			container.Row(row =>
			{
				row.RelativeItem().Element(e => e.AlignLeft().Text($"GCRM {version} - Generado por: {Session.User.Name}").FontSize(footer_font_size));
				row.RelativeItem().Element(e => e.AlignRight().Text($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}").FontSize(footer_font_size));
			});
		}
	}
}
