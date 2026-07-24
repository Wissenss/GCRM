namespace GCRM
{
    partial class FBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBackup));
            Output = new TextBox();
            BCancel = new Button();
            ProgressBar = new ProgressBar();
            BGenerar = new Button();
            SaveFileDialog = new SaveFileDialog();
            SuspendLayout();
            // 
            // Output
            // 
            Output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Output.BackColor = SystemColors.Control;
            Output.Enabled = false;
            Output.HideSelection = false;
            Output.Location = new Point(12, 41);
            Output.Multiline = true;
            Output.Name = "Output";
            Output.ReadOnly = true;
            Output.Size = new Size(410, 64);
            Output.TabIndex = 2;
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(347, 111);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 1;
            BCancel.Text = "&Cerrar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // ProgressBar
            // 
            ProgressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProgressBar.Location = new Point(12, 12);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(410, 23);
            ProgressBar.TabIndex = 3;
            // 
            // BGenerar
            // 
            BGenerar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BGenerar.Location = new Point(266, 111);
            BGenerar.Name = "BGenerar";
            BGenerar.Size = new Size(75, 23);
            BGenerar.TabIndex = 0;
            BGenerar.Text = "&Generar";
            BGenerar.UseVisualStyleBackColor = true;
            BGenerar.Click += BGenerar_Click;
            // 
            // FBackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 146);
            ControlBox = false;
            Controls.Add(BGenerar);
            Controls.Add(ProgressBar);
            Controls.Add(BCancel);
            Controls.Add(Output);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FBackup";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Respaldo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox Output;
        private Button BCancel;
        private ProgressBar ProgressBar;
        private Button BGenerar;
        private SaveFileDialog SaveFileDialog;
    }
}