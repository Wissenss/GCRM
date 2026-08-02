using DocumentFormat.OpenXml.Bibliography;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
    public partial class FDocumentViewer : Form
    {
        private IDocument Document;
        private IEnumerable<byte[]> Images;
        private int PageIndex = 0;

        public PrintDocument PrintDocument;
        public PageSettings PrintSettings = new PageSettings()
        {
            Landscape = false,
            Margins = new Margins(0, 0, 0, 0),
            PaperSize = new PaperSize("A4", 827, 1169)
        };

        public FDocumentViewer()
        {
            InitializeComponent();
        }

        public void LoadDocument(IDocument document)
        {
            using (new CursorWait())
            {
                Document = document;

                Images = document.GenerateImages(new ImageGenerationSettings()
                {
                    ImageFormat = ImageFormat.Png,
                    ImageCompressionQuality = ImageCompressionQuality.Best,
                    RasterDpi = DocumentSettings.DefaultRasterDpi * 8
                });

                Text = Document.GetMetadata().Title;

                PrintDocument = CreatePrintDocument();

                PageIndex = 0;
                PrintPreviewControl.StartPage = PageIndex;
                SLPageNumber.Text = $"{PageIndex + 1} / {Images.Count()}";
                TSSBPrevious.Enabled = PageIndex > 0 && Images.Count() > 0;
                TSSBNext.Enabled = PageIndex < Images.Count() - 1 && Images.Count() > 0;

                PrintPreviewControl.Document = PrintDocument;
            }
        }

        private void SetCurrentPage(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex >= Images.Count())
                return;

            PageIndex = pageIndex;
            PrintPreviewControl.StartPage = PageIndex;

            SLPageNumber.Text = $"{PageIndex + 1} / {Images.Count()}";
            TSSBPrevious.Enabled = PageIndex > 0 && Images.Count() > 0;
            TSSBNext.Enabled = PageIndex < Images.Count() - 1 && Images.Count() > 0;
        }

        private System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                {
                    return (System.Drawing.Image)img.Clone(); // we clone it so the image does not get disposed when the using block ends
                }
            }
        }

        private void TSSBPrevious_Click(object sender, EventArgs e)
        {
            SetCurrentPage(PageIndex - 1);
        }

        private void TSSBNext_Click(object sender, EventArgs e)
        {
            SetCurrentPage(PageIndex + 1);
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            SaveFileDialog.FileName = $"{Document.GetMetadata().Title}.pdf";

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (new CursorWait())
                {
                    Document.GeneratePdf(SaveFileDialog.FileName);
                }
            }
        }

        private PrintDocument CreatePrintDocument()
        {
            PrintDocument printDocument = new PrintDocument();
            //printDocument.PrintController = new PreviewPrintController();
            printDocument.BeginPrint += new PrintEventHandler(OnPrintDocument_BeginPrint);
            printDocument.PrintPage += new PrintPageEventHandler(OnPrintDocument_PrintPage);
            printDocument.DefaultPageSettings = PrintSettings;
            return printDocument;
        }

        private void BPrint_Click(object sender, EventArgs e)
        {
            PrintDialog.UseEXDialog = false;
            PrintDialog.Document = PrintDocument;

            if (PrintDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDialog.Document.Print();
            }
        }

        int currentPrintPageIndex = 0;

        private void OnPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            currentPrintPageIndex = 0;
        }

        // Helper method to scale the image proportionally to fit the page margins
        private Rectangle CalculateFitRatio(System.Drawing.Image img, Rectangle targetArea)
        {
            double ratioX = (double)targetArea.Width / img.Width;
            double ratioY = (double)targetArea.Height / img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            // If the image is smaller than the page, you can cap ratio at 1.0 
            // if you don't want it to stretch/pixelate.
            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            // Center the image inside the printable margin boundary
            int posX = targetArea.X + ((targetArea.Width - newWidth) / 2);
            int posY = targetArea.Y + ((targetArea.Height - newHeight) / 2);

            return new Rectangle(posX, posY, newWidth, newHeight);
        }

        private void OnPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Image img = ByteArrayToImage(Images.ElementAt(currentPrintPageIndex));

            Rectangle printableArea = e.MarginBounds;

            Rectangle destinationRect = CalculateFitRatio(img, printableArea);

            e.Graphics.DrawImage(img, destinationRect);

            currentPrintPageIndex++;

            e.HasMorePages = currentPrintPageIndex < Images.Count(); // while HasMorePages is true, PrintPage event will fire again until no more pages are left
        }

        private void BZoomOut_Click(object sender, EventArgs e)
        {
            PrintPreviewControl.Zoom = PrintPreviewControl.Zoom - 0.1f;
        }

        private void BZoomIn_Click(object sender, EventArgs e)
        {
            PrintPreviewControl.Zoom = PrintPreviewControl.Zoom + 0.1f;
        }

        private void BPageOrientation_Click(object sender, EventArgs e)
        {
            PrintSettings.Landscape = !PrintSettings.Landscape;
            BPageOrientation.Text = PrintSettings.Landscape ? "Vertical" : "Horizontal";
            PrintPreviewControl.InvalidatePreview();
        }
    }
}
