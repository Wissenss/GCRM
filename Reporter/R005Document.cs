using GCRM.Domain;
using GCRM.Shared;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter
{
    public class R005DocumentRequest
    {
        public int InstitutionId;
        public bool IncludeChildInstitutionsInCitizenListing;
    }

    public class R005DocumentModel
    {
        public R005DocumentRequest Request;
        public TInstitution Institution;
        public List<TCitizen> Citizens;
    }

    public class R005Document : IDocument
    {
        R005DocumentModel Model;

        public R005Document(R005DocumentModel model)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            Model = model;
        }

        public DocumentMetadata GetMetadata()
        {
            DocumentMetadata metadata = new DocumentMetadata();

            metadata.Title = "R005_Institucion";
            metadata.Author = "GCRM";

            return metadata;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(15);
                page.Size(PageSizes.A4);

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
                        .Text(t =>
                        {
                            int size = 15;
                            Color color = Colors.Black;

                            t.Span($"R005 - {Model.Institution.Name}").FontColor(color).FontSize(size);

                            if (string.IsNullOrEmpty(Model.Institution.Acronym) == false)
                            {
                                t.Span($" ({Model.Institution.Acronym})").FontColor(color).FontSize(size);
                            }
                        });

                    column.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(5);

                    int size = 10;

                    column.Item().Text(t =>
                    {
                        t.Span($"Sector: ").Bold().FontSize(size);
                        t.Span(BConstants.GetSocietySectorName(Model.Institution.Sector)).FontSize(size);
                    });

                    column.Item().Text(t =>
                    {
                        t.Span($"Categoría: ").Bold().FontSize(size);
                        t.Span(Model.Institution.Category.Name).FontSize(size);
                    });

                    column.Item().Text(t =>
                    {
                        t.Span($"Descripción: ").Bold().FontSize(size);
                        t.Span(Model.Institution.Category.Name).FontSize(size);
                    });

                    column.Item().Text(t =>
                    {
                        t.Span($"Dirección: ").Bold().FontSize(size);
                        t.Span(Model.Institution.Address.GetFullAddress()).FontSize(size);
                    });

                    column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(5);

                }); 
            });
        }

        void ComposeContent(IContainer container)
        {
            container.Column(c =>
            {
                c.Item()
                .BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingBottom(5).PaddingTop(30)
                .Text("Miembros de la institución").FontSize(Colors.Black).Bold().FontSize(10);

                c.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(2).Row(r =>
                {
                    r.RelativeItem().Text("Nombre").FontSize(10).FontColor(Colors.Black).Bold();
                    r.ConstantItem(200).Text("Cargo").FontSize(10).FontColor(Colors.Black).Bold();
                    r.ConstantItem(50).Text("Activo").AlignCenter().FontSize(10).FontColor(Colors.Black).Bold();
                    r.ConstantItem(70).Text("Inicio").FontSize(10).FontColor(Colors.Black).Bold();
                    r.ConstantItem(70).Text("Fin").FontSize(10).FontColor(Colors.Black).Bold();
                });

                int lastInstitutionId = -1;

                foreach (var item in Model.Citizens)
                {
                    if (Model.Request.IncludeChildInstitutionsInCitizenListing == false && item.InstitutionRole.Institution.Id != Model.Institution.Id)
                    {
                        continue;
                    }

                    if (lastInstitutionId != item.InstitutionRole.Institution.Id)
                    {
                        lastInstitutionId = item.InstitutionRole.Institution.Id;

                        c.Item()
                        .BorderBottom(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .Background(Colors.Grey.Lighten4)
                        .Row(r =>
                        {
                            r.RelativeItem()
                            .PaddingVertical(2)
                            .Text(item.InstitutionRole.Institution.Name).FontSize(10).FontColor(Colors.Black);
                        });
                    }

                    c.Item()
                    .PaddingTop(2)
                    .Row(r =>
                    {
                        int size = 10;

                        string started_at = item.InstitutionRole.IsStartDefined ? item.InstitutionRole.StartedAt.ToString("dd/MM/yyyy") : "-";
                        string ended_at = item.InstitutionRole.IsEndDefined ? item.InstitutionRole.EndedAt.ToString("dd/MM/yyyy") : "-";

                        r.RelativeItem().Text(item.FullNameWithFirstCapitals).FontSize(size).FontColor(Colors.Black);
                        r.ConstantItem(200).Text(item.InstitutionRole.DisplayName).FontSize(size).FontColor(Colors.Black);
                        r.ConstantItem(50).Text(item.InstitutionRole.IsActive ? "Sí" : "No").AlignCenter().FontSize(size).FontColor(Colors.Black);
                        r.ConstantItem(70).Text(started_at).FontSize(size).FontColor(Colors.Black);
                        r.ConstantItem(70).Text(ended_at).FontSize(size).FontColor(Colors.Black);

                    });
                }
            });
        }

        void ComposeFooter(IContainer container)
        {
            DocumentUtilities.ComposeReportFooter(container);
        }
    }
}
