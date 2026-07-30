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
    public class R005DocumentModel
    {
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
                .Text("Miembros").FontSize(Colors.Black).Bold().FontSize(10);

                c.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(2).Row(r =>
                {
                    r.RelativeItem().Text("Nombre").FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(150).Text("Cargo").FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(50).Text("Activo").AlignCenter().FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(50).Text("Inicio").FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(50).Text("Fin").FontSize(10).FontColor(Colors.Black);
                });

                foreach (var item in Model.Citizens)
                {
                    foreach (var role in new List<TInstitutionRole> { item.Role, item.Role2, item.Role3 })
                    {
                        if (role.InstitutionId == Model.Institution.Id || role.InstitutionTemplateId == Model.Institution.Id)
                        {
                            c.Item()
                            .PaddingTop(2)
                            .Row(r =>
                            {
                                int size = 10;

                                r.RelativeItem().Text(item.FullNameWithFirstCapitals).FontSize(size).FontColor(Colors.Black).Light();
                                r.ConstantItem(150).Text(role.Name).FontSize(size).FontColor(Colors.Black).Light();
                                r.ConstantItem(50).Text("Sí").AlignCenter().FontSize(size).FontColor(Colors.Black).Light();
                                r.ConstantItem(50).Text("-").FontSize(size).FontColor(Colors.Black).Light();
                                r.ConstantItem(50).Text("-").FontSize(size).FontColor(Colors.Black).Light();

                            });
                        }
                    }
                }
            });
        }

        void ComposeFooter(IContainer container)
        {
            DocumentUtilities.ComposeReportFooter(container);
        }
    }
}
