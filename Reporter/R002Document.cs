using Business;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Reporter
{
	public class R002DocumentModel
	{
		public TCitizenNetwork Network;
	}

	public class R002Document : IDocument
	{
		R002DocumentModel Model;

		public R002Document(R002DocumentModel model)
		{
			QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

			Model = model;
		}

		public void Compose(IDocumentContainer container)
		{
			container.Page(page =>
			{
				page.Size(PageSizes.A5.Landscape());
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
				row.ConstantItem(80).Column(column =>
				{
					column.Item()
						.Padding(1f)
						.MaxHeight(60)
						.Image("C:\\Users\\Leo\\Dev\\GCRM\\Reporter\\Assets\\ComisionOrganizadoraNacional.jpg").FitArea();
				});

				row.RelativeItem().Column(column =>
				{
					column.Item()
						.PaddingBottom(2)
						.Text("FORMATO DE RECOLECCIÓN DE FIRMAS DE APOYO MILITANTES")
						.AlignCenter()
						.FontSize(12).SemiBold().FontColor(Colors.Black);

					column.Item()
						.PaddingBottom(8)
						.Text("PROCESO DE ELECCIÓN DEL COMITÉ EJECUTIVO NACIONAL 2024-2027")
						.AlignCenter()
						.FontSize(10).FontColor(Colors.Black);

					column.Item()
						.PaddingBottom(5)
						.Element(container =>
						{
							container.Row(row =>
							{
								row.RelativeItem().Text("ASPIRANTE: ________________________________________").FontSize(8);
								row.ConstantItem(200).Text("ENTIDAD FEDERATIVA: ___________________").FontSize(8);
							});
						});
				});

				row.ConstantItem(80).Padding(10).Column(column =>
				{
					column.Item().Padding(1f).Text(Model.Network.Name).FontSize(8);
					column.Item().Padding(1f).Text("HOJA: __/__").FontSize(8);
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
					columns.ConstantColumn(20);
					columns.RelativeColumn();
					columns.RelativeColumn();
					columns.RelativeColumn();
					columns.RelativeColumn();
					columns.RelativeColumn();
				});

				table.Header(header =>
				{
					float header_font_size = 8;

					string header_text = @"
						En atención a los artículos 11, numeral 1, inciso b); y 53, numeral 2 inciso d) fracc. III de los Estatutos Generales y 39 del Reglamento del Comité Ejecutivo Nacional, CON MY FIRMA MANIFIESTO MI APOYO a la o el aspirante arriba mencionado para que obtenga el registro como candidato(a) a la Presidencia del Comité Ejecutivo Nacional en la elección interna a celebrarse el 10 de noviembre de 2024. Las y los aspirantes deberán recolectar las firmas en este formato, sin tachaduras, enmendaduras ni adhesiones de otros(s) documentos(s). La alteración al formato, invalidará los apoyos registrados.
					";

					header.Cell().ColumnSpan(6).Element(CellStyleAddenda).Text(header_text).FontSize(5).Justify();

					header.Cell().Element(CellStyle).Text("No.").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Apellido paterno").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Apellido materno").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Nombre(s)").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Clave de elector INE").FontSize(header_font_size).SemiBold();
					header.Cell().Element(CellStyle).Text("Firma").FontSize(header_font_size).SemiBold();

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

					float row_font_size = 8;
					float row_min_height = 27;

					table.Cell().MinHeight(row_min_height).Element(CellStyleNo).Text((i + 1).ToString()).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.PaternalName).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.MaternalName).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text(member.Citizen.Name).FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text("").FontSize(row_font_size);
					table.Cell().MinHeight(row_min_height).Element(CellStyle).Text("").FontSize(row_font_size);

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
		}
	}
}
