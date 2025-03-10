using Business;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Diagnostics;
using System.Reflection;

namespace Reporter
{
	public class R003DocumentModel
	{
		public TCitizenNetwork Network;
	}

	public class R003Document : IDocument
	{
		R003DocumentModel Model;

		public R003Document(R003DocumentModel model)
		{
			QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

			Model = model;
		}

		public void Compose(IDocumentContainer container)
		{
			container.Page(page =>
			{
				page.Size(PageSizes.A5.Portrait());
				page.Margin(15);

				// watermark
				page.Background()
				.AlignCenter()
				.AlignMiddle()
				.Text(Model.Network.Name)
				.FontSize(50)
				.FontColor(Colors.Grey.Lighten4);

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
						.PaddingBottom(2)
						.Text(Model.Network.Name)
						.AlignCenter()
						.FontSize(10).SemiBold().FontColor(Colors.Black);

					column.Item()
						.PaddingBottom(8)
						.Text(Model.Network.Description)
						.AlignCenter()
						.FontSize(8).FontColor(Colors.Black);
				});
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
					columns.ConstantColumn(20); // no
					columns.RelativeColumn(); // ap pat
					columns.RelativeColumn(); // ap mat
					columns.RelativeColumn(); // nombre
					columns.RelativeColumn(); // clave elec
					columns.RelativeColumn(); // ocr
					columns.ConstantColumn(32); // seccion
					columns.ConstantColumn(60); // contac
				});

				table.Header(header =>
				{
					float header_font_size = 7;

					header.Cell().Element(CellStyle).Text("No.").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Apellido paterno").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Apellido materno").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Nombre(s)").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Clave de elector").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("OCR").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Sección").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Contacto").FontSize(header_font_size).SemiBold();

					static IContainer CellStyle(IContainer container)
					{
						return container
						.BorderBottom(0.3F).BorderLeft(0.1f).BorderRight(0.1f).BorderTop(0.1f).BorderColor(Colors.Grey.Lighten1)
						.Background(Colors.Grey.Lighten4)
						.Padding(0.5f)
						.PaddingLeft(1f);
					}

					static IContainer CellStyleAddenda(IContainer container)
					{
						return CellStyle(container).Padding(0f);
					}
				});

				for (int i = 0; i < Math.Max(Model.Network.Members.Count, 10); i++)
				{
					TCitizenNetworkMember member;

					if (i < Model.Network.Members.Count)
						member = Model.Network.Members[i];
					else
						member = new TCitizenNetworkMember();

					float row_font_size = 7;
					float row_min_height = 10; // 27

					table.Cell().MinHeight(row_min_height).Element(CellStyleNo).Text((i + 1).ToString()).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.PaternalName).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.MaternalName).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.Name).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.VoterCode).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.VoterOCR).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.VoterSection).FontSize(row_font_size);

					string contact_str = "";

					if (member.Citizen.Cellphone != null && member.Citizen.Cellphone.Trim().Length > 0)
						contact_str += $"Cel. {member.Citizen.Cellphone}\n";
					if (member.Citizen.Cellphone != null && member.Citizen.Phone.Trim().Length > 0)
						contact_str += $"Tel. {member.Citizen.Phone}";

					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(contact_str).FontSize(row_font_size * 0.7f);


					static IContainer CellStyle(IContainer container)
					{
						return container
							.BorderBottom(0.1f).BorderLeft(0.1f).BorderRight(0.1f).BorderColor(Colors.Grey.Lighten2)
							.Padding(1f)
							.AlignMiddle();
					}

					static IContainer CellStyleNo(IContainer container)
					{
						return CellStyle(container).AlignRight().PaddingRight(2);
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
