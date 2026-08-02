namespace GCRM
{
    partial class FDocumentViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StatusStrip = new StatusStrip();
            SLLeftFiller = new ToolStripStatusLabel();
            TSSBPrevious = new ToolStripSplitButton();
            SLPageNumber = new ToolStripStatusLabel();
            TSSBNext = new ToolStripSplitButton();
            SLRightFiller = new ToolStripStatusLabel();
            PicturePanel = new Panel();
            PrintPreviewControl = new PrintPreviewControl();
            ToolStrip = new ToolStrip();
            BSave = new ToolStripButton();
            BPrint = new ToolStripButton();
            BZoomIn = new ToolStripButton();
            BZoomOut = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BPageOrientation = new ToolStripButton();
            SaveFileDialog = new SaveFileDialog();
            PrintDialog = new PrintDialog();
            StatusStrip.SuspendLayout();
            PicturePanel.SuspendLayout();
            ToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { SLLeftFiller, TSSBPrevious, SLPageNumber, TSSBNext, SLRightFiller });
            StatusStrip.Location = new Point(0, 580);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(556, 22);
            StatusStrip.TabIndex = 1;
            StatusStrip.Text = "statusStrip1";
            // 
            // SLLeftFiller
            // 
            SLLeftFiller.Name = "SLLeftFiller";
            SLLeftFiller.Size = new Size(243, 17);
            SLLeftFiller.Spring = true;
            // 
            // TSSBPrevious
            // 
            TSSBPrevious.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSSBPrevious.DropDownButtonWidth = 0;
            TSSBPrevious.Image = Properties.Resources.Fatcow_Farm_Fresh_Bullet_arrow_left_16;
            TSSBPrevious.ImageTransparentColor = Color.Magenta;
            TSSBPrevious.Name = "TSSBPrevious";
            TSSBPrevious.Size = new Size(21, 20);
            TSSBPrevious.Text = "toolStripSplitButton2";
            TSSBPrevious.Click += TSSBPrevious_Click;
            // 
            // SLPageNumber
            // 
            SLPageNumber.Name = "SLPageNumber";
            SLPageNumber.Size = new Size(13, 17);
            SLPageNumber.Text = "0";
            // 
            // TSSBNext
            // 
            TSSBNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSSBNext.DropDownButtonWidth = 0;
            TSSBNext.Image = Properties.Resources.Fatcow_Farm_Fresh_Bullet_arrow_right_16;
            TSSBNext.ImageTransparentColor = Color.Magenta;
            TSSBNext.Name = "TSSBNext";
            TSSBNext.Size = new Size(21, 20);
            TSSBNext.Text = "toolStripSplitButton1";
            TSSBNext.Click += TSSBNext_Click;
            // 
            // SLRightFiller
            // 
            SLRightFiller.Name = "SLRightFiller";
            SLRightFiller.Size = new Size(243, 17);
            SLRightFiller.Spring = true;
            // 
            // PicturePanel
            // 
            PicturePanel.AutoScroll = true;
            PicturePanel.BackColor = SystemColors.ButtonFace;
            PicturePanel.Controls.Add(PrintPreviewControl);
            PicturePanel.Dock = DockStyle.Fill;
            PicturePanel.Location = new Point(0, 27);
            PicturePanel.Name = "PicturePanel";
            PicturePanel.Size = new Size(556, 553);
            PicturePanel.TabIndex = 2;
            // 
            // PrintPreviewControl
            // 
            PrintPreviewControl.Dock = DockStyle.Fill;
            PrintPreviewControl.Location = new Point(0, 0);
            PrintPreviewControl.Name = "PrintPreviewControl";
            PrintPreviewControl.Size = new Size(556, 553);
            PrintPreviewControl.TabIndex = 1;
            // 
            // ToolStrip
            // 
            ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            ToolStrip.Items.AddRange(new ToolStripItem[] { BSave, BPrint, BZoomIn, BZoomOut, toolStripSeparator1, BPageOrientation });
            ToolStrip.Location = new Point(0, 0);
            ToolStrip.Name = "ToolStrip";
            ToolStrip.Padding = new Padding(5, 2, 1, 2);
            ToolStrip.Size = new Size(556, 27);
            ToolStrip.TabIndex = 3;
            ToolStrip.Text = "toolStrip1";
            // 
            // BSave
            // 
            BSave.Image = Properties.Resources.Fatcow_Farm_Fresh_Diskette_16;
            BSave.ImageTransparentColor = Color.Magenta;
            BSave.Name = "BSave";
            BSave.Size = new Size(69, 20);
            BSave.Text = "Guardar";
            BSave.Click += BSave_Click;
            // 
            // BPrint
            // 
            BPrint.Image = Properties.Resources.Fatcow_Farm_Fresh_Printer_16;
            BPrint.ImageTransparentColor = Color.Magenta;
            BPrint.Name = "BPrint";
            BPrint.Size = new Size(73, 20);
            BPrint.Text = "Imprimir";
            BPrint.Click += BPrint_Click;
            // 
            // BZoomIn
            // 
            BZoomIn.Alignment = ToolStripItemAlignment.Right;
            BZoomIn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BZoomIn.Image = Properties.Resources.Fatcow_Farm_Fresh_Zoom_in_16;
            BZoomIn.ImageTransparentColor = Color.Magenta;
            BZoomIn.Name = "BZoomIn";
            BZoomIn.Size = new Size(23, 20);
            BZoomIn.Text = "toolStripButton1";
            BZoomIn.Click += BZoomIn_Click;
            // 
            // BZoomOut
            // 
            BZoomOut.Alignment = ToolStripItemAlignment.Right;
            BZoomOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BZoomOut.Image = Properties.Resources.Fatcow_Farm_Fresh_Zoom_out_16;
            BZoomOut.ImageTransparentColor = Color.Magenta;
            BZoomOut.Name = "BZoomOut";
            BZoomOut.Size = new Size(23, 20);
            BZoomOut.Text = "toolStripButton2";
            BZoomOut.Click += BZoomOut_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 23);
            // 
            // BPageOrientation
            // 
            BPageOrientation.Image = Properties.Resources.Fatcow_Farm_Fresh_Page_orientation_16;
            BPageOrientation.ImageTransparentColor = Color.Magenta;
            BPageOrientation.Name = "BPageOrientation";
            BPageOrientation.Size = new Size(82, 20);
            BPageOrientation.Text = "Horizontal";
            BPageOrientation.Click += BPageOrientation_Click;
            // 
            // PrintDialog
            // 
            PrintDialog.UseEXDialog = true;
            // 
            // FDocumentViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 602);
            Controls.Add(PicturePanel);
            Controls.Add(ToolStrip);
            Controls.Add(StatusStrip);
            MinimizeBox = false;
            Name = "FDocumentViewer";
            ShowIcon = false;
            Text = "FDocumentViewer";
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            PicturePanel.ResumeLayout(false);
            ToolStrip.ResumeLayout(false);
            ToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel SLLeftFiller;
        private ToolStripSplitButton TSSBPrevious;
        private ToolStripStatusLabel SLPageNumber;
        private ToolStripSplitButton TSSBNext;
        private ToolStripStatusLabel SLRightFiller;
        private Panel PicturePanel;
        private ToolStrip ToolStrip;
        private ToolStripButton BSave;
        private SaveFileDialog SaveFileDialog;
        private ToolStripButton BPrint;
        private PrintDialog PrintDialog;
        private PrintPreviewControl PrintPreviewControl;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton BZoomIn;
        private ToolStripButton BZoomOut;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton BPageOrientation;
    }
}