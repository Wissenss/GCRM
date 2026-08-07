namespace GCRM
{
	partial class FFixDuplicateRecords
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            BSearch = new Button();
            BCancel = new Button();
            LMethod = new Label();
            Method = new ComboBox();
            LEntity = new Label();
            Entity = new ComboBox();
            TabControlParameters = new TabControl();
            TabLevenshtein = new TabPage();
            LThreshold = new Label();
            Threshold = new NumericUpDown();
            TabControlParameters.SuspendLayout();
            TabLevenshtein.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Threshold).BeginInit();
            SuspendLayout();
            // 
            // BSearch
            // 
            BSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BSearch.Location = new Point(240, 162);
            BSearch.Name = "BSearch";
            BSearch.Size = new Size(75, 23);
            BSearch.TabIndex = 3;
            BSearch.Text = "&Buscar";
            BSearch.UseVisualStyleBackColor = true;
            BSearch.Click += BSearch_Click;
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(321, 162);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 4;
            BCancel.Text = "&Cerrar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // LMethod
            // 
            LMethod.AutoSize = true;
            LMethod.Location = new Point(12, 15);
            LMethod.Name = "LMethod";
            LMethod.Size = new Size(49, 15);
            LMethod.TabIndex = 4;
            LMethod.Text = "Método";
            // 
            // Method
            // 
            Method.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Method.DropDownStyle = ComboBoxStyle.DropDownList;
            Method.FormattingEnabled = true;
            Method.Location = new Point(74, 12);
            Method.Name = "Method";
            Method.Size = new Size(322, 23);
            Method.TabIndex = 0;
            // 
            // LEntity
            // 
            LEntity.AutoSize = true;
            LEntity.Location = new Point(12, 44);
            LEntity.Name = "LEntity";
            LEntity.Size = new Size(47, 15);
            LEntity.TabIndex = 3;
            LEntity.Text = "Entidad";
            // 
            // Entity
            // 
            Entity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Entity.DropDownStyle = ComboBoxStyle.DropDownList;
            Entity.FormattingEnabled = true;
            Entity.Location = new Point(74, 41);
            Entity.Name = "Entity";
            Entity.Size = new Size(322, 23);
            Entity.TabIndex = 1;
            // 
            // TabControlParameters
            // 
            TabControlParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControlParameters.Controls.Add(TabLevenshtein);
            TabControlParameters.Location = new Point(12, 80);
            TabControlParameters.Name = "TabControlParameters";
            TabControlParameters.SelectedIndex = 0;
            TabControlParameters.Size = new Size(388, 76);
            TabControlParameters.TabIndex = 2;
            // 
            // TabLevenshtein
            // 
            TabLevenshtein.Controls.Add(LThreshold);
            TabLevenshtein.Controls.Add(Threshold);
            TabLevenshtein.Location = new Point(4, 24);
            TabLevenshtein.Name = "TabLevenshtein";
            TabLevenshtein.Padding = new Padding(3);
            TabLevenshtein.Size = new Size(380, 48);
            TabLevenshtein.TabIndex = 0;
            TabLevenshtein.Text = "Parámetros";
            TabLevenshtein.UseVisualStyleBackColor = true;
            // 
            // LThreshold
            // 
            LThreshold.AutoSize = true;
            LThreshold.Location = new Point(6, 15);
            LThreshold.Name = "LThreshold";
            LThreshold.Size = new Size(100, 15);
            LThreshold.TabIndex = 0;
            LThreshold.Text = "Distancia máxima";
            // 
            // Threshold
            // 
            Threshold.Location = new Point(112, 13);
            Threshold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Threshold.Name = "Threshold";
            Threshold.Size = new Size(48, 23);
            Threshold.TabIndex = 0;
            Threshold.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // FFixDuplicateRecords
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 197);
            ControlBox = false;
            Controls.Add(TabControlParameters);
            Controls.Add(Entity);
            Controls.Add(LEntity);
            Controls.Add(Method);
            Controls.Add(LMethod);
            Controls.Add(BSearch);
            Controls.Add(BCancel);
            Name = "FFixDuplicateRecords";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Depurar Registros Duplicados";
            TabControlParameters.ResumeLayout(false);
            TabLevenshtein.ResumeLayout(false);
            TabLevenshtein.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Threshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BSearch;
		private Button BCancel;
		private Label LMethod;
		public ComboBox Method;
		private Label LEntity;
		public ComboBox Entity;
		private TabControl TabControlParameters;
		private TabPage TabLevenshtein;
		private Label LThreshold;
		public NumericUpDown Threshold;
	}
}
