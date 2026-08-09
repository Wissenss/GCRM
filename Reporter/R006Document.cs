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
    public class R006DocumentModel
    {
        public TCitizen Citizen;
    }

    public class R006Document : IDocument
    {
        R006DocumentModel Model;

        public R006Document(R006DocumentModel model)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            Model = model;
        }

        public DocumentMetadata GetMetadata()
        {
            DocumentMetadata metadata = new DocumentMetadata();

            metadata.Title = "R006_Ciudadano";
            metadata.Author = "GCRM";

            return metadata;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
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

                            t.Span($"R006 - {BConstants.GetCitizenBriefTitle(Model.Citizen.Title, Model.Citizen.Sex)} {Model.Citizen.FullNameWithFirstCapitals}").FontColor(color).FontSize(size);
                        });

                    column.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(5);

                    int text_size = 10;

                    column.Item().Text(t =>
                    {
                        t.Span($"Categoría: ").Bold().FontSize(text_size);
                        t.Span(Model.Citizen.Category.Name).FontSize(text_size);
                    });

                    column.Item().Text(t =>
                    {
                        t.Span($"Sexo: ").Bold().FontSize(text_size);
                        t.Span(BConstants.GetSexName(Model.Citizen.Sex)).FontSize(text_size);
                    });

                    column.Item().Text(t =>
                    {
                        t.Span($"CURP: ").Bold().FontSize(text_size);
                        t.Span(Model.Citizen.CURP).FontSize(text_size);
                    });

                    column.Item().Text(t =>
                    {
                        t.Span($"Cumpleaños: ").Bold().FontSize(text_size);
                        t.Span(Model.Citizen.DisplayBirthday).FontSize(text_size);
                    });

                    column.Item().Text(t =>
                    {
                        t.Span($"Dirección: ").Bold().FontSize(text_size);
                        t.Span(Model.Citizen.Address.GetFullAddress()).FontSize(text_size);
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
                .Text("Contactos").FontSize(Colors.Black).Bold().FontSize(10);

                c.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(2).Row(r =>
                {
                    r.ConstantItem(150).Text("Tipo").FontSize(10).FontColor(Colors.Black);
                    r.RelativeItem().Text("Número").FontSize(10).FontColor(Colors.Black);
                });

                foreach (var pair in new List<(string Type, string Number)>
                {
                    ("Teléfono", Model.Citizen.Phone.FullNumberWithPrefix),
                    ("Teléfono 2", Model.Citizen.Phone2.FullNumberWithPrefix),
                    ("Teléfono 3", Model.Citizen.Phone3.FullNumberWithPrefix),
                    ("Celular", Model.Citizen.Cellphone.FullNumber),
                    ("Email", Model.Citizen.Email),
                })
                {
                    if (string.IsNullOrEmpty(pair.Number))
                        continue;

                    c.Item()
                    .PaddingTop(2)
                    .Row(r =>
                    {
                        int size = 10;

                        r.ConstantItem(150).Text(pair.Type).FontSize(size).FontColor(Colors.Black).Light();
                        r.RelativeItem().Text(pair.Number).FontSize(size).FontColor(Colors.Black).Light();
                    });
                }

                c.Item()
                .BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingBottom(5).PaddingTop(20)
                .Text("Cargos").FontSize(Colors.Black).Bold().FontSize(10);

                c.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingVertical(2).Row(r =>
                {
                    r.RelativeItem().Text("Institución").FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(150).Text("Cargo").FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(50).Text("Activo").AlignCenter().FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(70).Text("Inicio").FontSize(10).FontColor(Colors.Black);
                    r.ConstantItem(70).Text("Fin").FontSize(10).FontColor(Colors.Black);
                });

                foreach (TCitizenInstitutionRole institution_role in new List<TCitizenInstitutionRole>
                {
                    Model.Citizen.InstitutionRole,
                    Model.Citizen.InstitutionRole2,
                    Model.Citizen.InstitutionRole3,
                })
                {
                    if (institution_role.Institution.Id == 0)
                        continue;

                    c.Item()
                    .PaddingTop(2)
                    .Row(r =>
                    {
                        int size = 10;

                        string started_at = institution_role.IsStartDefined ? institution_role.StartedAt.ToString("dd/MM/yyyy") : "-";
                        string ended_at = institution_role.IsEndDefined ? institution_role.EndedAt.ToString("dd/MM/yyyy") : "-";

                        r.RelativeItem().Text(institution_role.Institution.Name).FontSize(size).FontColor(Colors.Black).Light();
                        r.ConstantItem(150).Text(institution_role.DisplayName).FontSize(size).FontColor(Colors.Black).Light();
                        r.ConstantItem(50).Text(institution_role.IsActive ? "Sí" : "No").AlignCenter().FontSize(size).FontColor(Colors.Black).Light();
                        r.ConstantItem(70).Text(started_at).FontSize(size).FontColor(Colors.Black).Light();
                        r.ConstantItem(70).Text(ended_at).FontSize(size).FontColor(Colors.Black).Light();
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
