using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reporter
{
	public class R007DocumentModel
	{
		public List<TUser> Users = new List<TUser>();
		public List<TUserGroup> UserGroups = new List<TUserGroup>();
		public List<TEventLogType> EventTypes = new List<TEventLogType>();
		public DateTime DateFrom;
		public DateTime DateTo;
		public List<TEventLog> Logs = new List<TEventLog>();
	}

	public class R007Document : IDocument
	{
		static readonly Color[] SeriesColors = new[]
		{
			Colors.Blue.Lighten1,
			Colors.Green.Lighten1,
			Colors.Orange.Lighten1,
			Colors.Purple.Lighten1,
			Colors.Red.Lighten1,
			Colors.Teal.Lighten1,
			Colors.Yellow.Lighten1,
			Colors.Brown.Lighten1,
			Colors.Cyan.Lighten1,
			Colors.Lime.Lighten1,
			Colors.Pink.Lighten1,
			Colors.Indigo.Lighten1,
			Colors.DeepPurple.Lighten1,
			Colors.LightBlue.Lighten1,
			Colors.LightGreen.Lighten1,
			Colors.Amber.Lighten1,
			Colors.DeepOrange.Lighten1,
			Colors.BlueGrey.Lighten1,
		};

		R007DocumentModel Model;

		public R007Document(R007DocumentModel model)
		{
			QuestPDF.Settings.License = LicenseType.Community;
			Model = model;
		}

		public DocumentMetadata GetMetadata()
		{
			DocumentMetadata metadata = new DocumentMetadata();

			metadata.Title = "R007_ActividadUsuarios";
			metadata.Author = "GCRM";

			return metadata;
		}

		public void Compose(IDocumentContainer container)
		{
			container.Page(page =>
			{
				page.Size(PageSizes.A4.Landscape());
				page.Margin(15);
				page.PageColor(Colors.White);

				page.Header().Element(ComposeHeader);
				page.Content().Element(ComposeContent);
				page.Footer().Element(ComposeFooter);
			});
		}

		void ComposeHeader(IContainer container)
		{
			container.Column(column =>
			{
				column.Item()
					.PaddingBottom(5)
					.Text("R007 - Actividad de los usuarios")
					.FontSize(15).SemiBold().FontColor(Colors.Black);

				column.Item().BorderTop(1).BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(5).Element(ComposeHeaderDetail);
			});
		}

		// the header repeats on every page, so a filter summary must stay a couple of lines long no matter
		// how many users or events were selected
		static string FormatFilterList(IEnumerable<string> names, int max_names = 6)
		{
			List<string> list = names.ToList();

			if (list.Count == 0)
				return "Cualquiera";

			if (list.Count <= max_names)
				return string.Join(", ", list);

			return $"{string.Join(", ", list.Take(max_names))} y {list.Count - max_names} más";
		}

		void ComposeHeaderDetail(IContainer container)
		{
			float filter_font_size = 9;

			container.Row(row =>
			{
				row.RelativeItem().Column(column =>
				{
					if (Model.UserGroups.Count > 0)
					{
						column.Item().PaddingLeft(1).Text($"Grupos: {FormatFilterList(Model.UserGroups.Select(g => g.Name))}").FontSize(filter_font_size);
						column.Item().PaddingLeft(1).Text($"Usuarios: {Model.Users.Count} dentro de los grupos").FontSize(filter_font_size);
					}
					else
					{
						column.Item().PaddingLeft(1).Text($"Usuarios: {FormatFilterList(Model.Users.Select(u => u.Name))}").FontSize(filter_font_size);
					}
				});

				row.RelativeItem().Column(column =>
				{
					string str_events = $"Eventos: {FormatFilterList(Model.EventTypes.Select(BConstants.GetEventLogTypeName))}";

					column.Item().PaddingLeft(1).Text(str_events).FontSize(filter_font_size);

					string str_period = $"Periodo: {Model.DateFrom:dd/MM/yyyy} al {Model.DateTo:dd/MM/yyyy}";

					column.Item().PaddingLeft(1).Text(str_period).FontSize(filter_font_size);
				});
			});
		}

		void ComposeContent(IContainer container)
		{
			container.PaddingTop(5).Column(column =>
			{
				column.Item()
					.BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingBottom(5).PaddingTop(15)
					.Text("Actividad por evento").FontSize(10).Bold().FontColor(Colors.Black);

				column.Item().PaddingTop(5).Element(ComposeChart);

				column.Item()
					.BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingBottom(5).PaddingTop(20)
					.Text("Eventos por usuario").FontSize(10).Bold().FontColor(Colors.Black);

				column.Item().PaddingTop(5).Element(ComposeUserTable);
			});
		}

		void ComposeChart(IContainer container)
		{
			List<TEventLogType> series_types = Model.EventTypes.Count > 0
				? Model.EventTypes
				: Model.Logs.Select(l => l.Type).Distinct().OrderBy(t => t).ToList();

			if (series_types.Count == 0)
			{
				container.Text("Sin datos para el periodo y filtros seleccionados.").FontSize(9).Italic();
				return;
			}

			int total_days = Math.Max(1, (Model.DateTo.Date - Model.DateFrom.Date).Days + 1);

			// every width below is relative, so the chart can never overflow the page; we still cap the
			// number of buckets so that individual bars stay wide enough to be visible
			int max_buckets = Math.Clamp(400 / series_types.Count, 6, 60);

			int bucket_days = Math.Max(1, (int)Math.Ceiling(total_days / (double)max_buckets));

			List<(DateTime Start, DateTime End)> buckets = new List<(DateTime, DateTime)>();

			for (DateTime start = Model.DateFrom.Date; start <= Model.DateTo.Date; start = start.AddDays(bucket_days))
				buckets.Add((start, start.AddDays(bucket_days)));

			Dictionary<(int Bucket, TEventLogType Type), int> counts = new Dictionary<(int, TEventLogType), int>();

			foreach (TEventLog log in Model.Logs)
			{
				int bucket_index = (log.DateTime.Date - Model.DateFrom.Date).Days / bucket_days;

				if (bucket_index < 0 || bucket_index >= buckets.Count)
					continue;

				var key = (bucket_index, log.Type);

				counts.TryGetValue(key, out int current);
				counts[key] = current + 1;
			}

			int max_count = Math.Max(1, counts.Count > 0 ? counts.Values.Max() : 1);

			const float chart_height = 110;
			const int legend_columns = 4;

			string label_format = bucket_days == 1 ? "dd/MM" : "dd/MM/yy";

			int label_step = Math.Max(1, (int)Math.Ceiling(buckets.Count / 20.0));

			container.Column(column =>
			{
				// the legend is laid out in fixed-size chunks so a long list of events wraps instead of
				// pushing the row past the page width
				for (int chunk_start = 0; chunk_start < series_types.Count; chunk_start += legend_columns)
				{
					int chunk = chunk_start;

					column.Item().PaddingBottom(2).Row(row =>
					{
						for (int slot = 0; slot < legend_columns; slot++)
						{
							int type_index = chunk + slot;

							if (type_index >= series_types.Count)
							{
								row.RelativeItem();
								continue;
							}

							TEventLogType type = series_types[type_index];
							Color color = SeriesColors[type_index % SeriesColors.Length];

							row.RelativeItem().Row(legend_row =>
							{
								legend_row.ConstantItem(8).Height(8).Background(color);
								legend_row.RelativeItem().PaddingLeft(3).Text(BConstants.GetEventLogTypeName(type)).FontSize(7);
							});
						}
					});
				}

				column.Item().PaddingTop(5).Row(row =>
				{
					for (int bucket_index = 0; bucket_index < buckets.Count; bucket_index++)
					{
						int index = bucket_index;
						DateTime bucket_start = buckets[index].Start;

						row.RelativeItem().PaddingRight(1).Column(bucket_column =>
						{
							bucket_column.Item().Height(chart_height).Row(bars_row =>
							{
								for (int type_index = 0; type_index < series_types.Count; type_index++)
								{
									TEventLogType type = series_types[type_index];
									Color color = SeriesColors[type_index % SeriesColors.Length];

									counts.TryGetValue((index, type), out int count);

									float bar_height = count == 0 ? 0 : Math.Max(1, chart_height * count / max_count);

									bars_row.RelativeItem().AlignBottom().Height(bar_height).Background(color);
								}
							});

							bucket_column.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingTop(2);

							if (index % label_step == 0)
								bucket_column.Item().Text(bucket_start.ToString(label_format)).FontSize(6);
						});
					}
				});
			});
		}

		void ComposeUserTable(IContainer container)
		{
			List<TUser> users = Model.Users.Count > 0
				? Model.Users.OrderBy(u => u.Name).ToList()
				: Model.Logs.Select(l => l.User).GroupBy(u => u.Id).Select(g => g.First()).OrderBy(u => u.Name).ToList();

			List<TEventLogType> event_types = Model.EventTypes.Count > 0
				? Model.EventTypes
				: Model.Logs.Select(l => l.Type).Distinct().OrderBy(t => t).ToList();

			Dictionary<(int UserId, TEventLogType Type), int> counts = Model.Logs
				.GroupBy(l => (l.User.Id, l.Type))
				.ToDictionary(g => g.Key, g => g.Count());

			container.Table(table =>
			{
				table.ColumnsDefinition(columns =>
				{
					columns.RelativeColumn(2);

					foreach (TEventLogType _ in event_types)
						columns.RelativeColumn();

					columns.RelativeColumn();
				});

				table.Header(header =>
				{
					float header_font_size = 7;

					header.Cell().Element(CellStyle).Text("Usuario").FontSize(8).SemiBold();

					foreach (TEventLogType type in event_types)
						header.Cell().Element(CellStyle).Text(BConstants.GetEventLogTypeName(type)).FontSize(header_font_size).SemiBold().AlignCenter();

					header.Cell().Element(CellStyle).Text("Total").FontSize(8).SemiBold().AlignCenter();

					static IContainer CellStyle(IContainer container)
					{
						return container.BorderBottom(0.3f).BorderTop(0.1f).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten4).Padding(2);
					}
				});

				int[] type_totals = new int[event_types.Count];
				int grand_total = 0;

				foreach (TUser user in users)
				{
					float row_font_size = 8;

					table.Cell().Element(CellStyle).Text(user.Name).FontSize(row_font_size);

					int user_total = 0;

					for (int i = 0; i < event_types.Count; i++)
					{
						counts.TryGetValue((user.Id, event_types[i]), out int count);

						table.Cell().Element(CellStyle).Text(count.ToString()).FontSize(row_font_size).AlignCenter();

						type_totals[i] += count;
						user_total += count;
					}

					table.Cell().Element(CellStyle).Text(user_total.ToString()).FontSize(row_font_size).AlignCenter().SemiBold();

					grand_total += user_total;

					static IContainer CellStyle(IContainer container)
					{
						return container.BorderBottom(0.1f).BorderColor(Colors.Grey.Lighten2).Padding(2);
					}
				}

				table.Cell().Element(TotalCellStyle).Text("Total").FontSize(8).SemiBold();

				foreach (int type_total in type_totals)
					table.Cell().Element(TotalCellStyle).Text(type_total.ToString()).FontSize(8).SemiBold().AlignCenter();

				table.Cell().Element(TotalCellStyle).Text(grand_total.ToString()).FontSize(8).SemiBold().AlignCenter();

				static IContainer TotalCellStyle(IContainer container)
				{
					return container.BorderTop(0.5f).BorderColor(Colors.Grey.Darken1).Background(Colors.Grey.Lighten3).Padding(2);
				}
			});
		}

		void ComposeFooter(IContainer container)
		{
			DocumentUtilities.ComposeReportFooter(container);
		}
	}
}
