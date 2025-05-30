namespace GCRM
{
	partial class FCitizenRelationshipListFilters
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
			BAccept = new Button();
			BCancel = new Button();
			FilterUser = new CheckBox();
			User = new ComboBox();
			Citizen = new ComboBox();
			FilterCitizen = new CheckBox();
			RelatedTo = new ComboBox();
			FilterRelatedTo = new CheckBox();
			FilterMinAffinity = new CheckBox();
			MinAffinity = new NumericUpDown();
			MaxAffinity = new NumericUpDown();
			FilterMaxAffinity = new CheckBox();
			FilterRelationshipRole = new CheckBox();
			RelationshipRole = new ComboBox();
			MaxPriority = new NumericUpDown();
			FilterMaxPriority = new CheckBox();
			MinPriority = new NumericUpDown();
			FilterMinPriority = new CheckBox();
			((System.ComponentModel.ISupportInitialize)MinAffinity).BeginInit();
			((System.ComponentModel.ISupportInitialize)MaxAffinity).BeginInit();
			((System.ComponentModel.ISupportInitialize)MaxPriority).BeginInit();
			((System.ComponentModel.ISupportInitialize)MinPriority).BeginInit();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(195, 257);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 4;
			BAccept.Text = "&Aplicar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(276, 257);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 5;
			BCancel.Text = "&Cerrar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// FilterUser
			// 
			FilterUser.AutoSize = true;
			FilterUser.Location = new Point(12, 12);
			FilterUser.Name = "FilterUser";
			FilterUser.Size = new Size(66, 19);
			FilterUser.TabIndex = 6;
			FilterUser.Text = "Usuario";
			FilterUser.UseVisualStyleBackColor = true;
			FilterUser.CheckedChanged += FilterUser_CheckedChanged;
			// 
			// User
			// 
			User.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			User.Enabled = false;
			User.FormattingEnabled = true;
			User.Location = new Point(120, 10);
			User.Name = "User";
			User.Size = new Size(231, 23);
			User.TabIndex = 7;
			// 
			// Citizen
			// 
			Citizen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			Citizen.Enabled = false;
			Citizen.FormattingEnabled = true;
			Citizen.Location = new Point(120, 39);
			Citizen.Name = "Citizen";
			Citizen.Size = new Size(231, 23);
			Citizen.TabIndex = 9;
			// 
			// FilterCitizen
			// 
			FilterCitizen.AutoSize = true;
			FilterCitizen.Location = new Point(12, 41);
			FilterCitizen.Name = "FilterCitizen";
			FilterCitizen.Size = new Size(84, 19);
			FilterCitizen.TabIndex = 8;
			FilterCitizen.Text = "Ciudadano";
			FilterCitizen.UseVisualStyleBackColor = true;
			FilterCitizen.CheckedChanged += FilterCitizen_CheckedChanged;
			// 
			// RelatedTo
			// 
			RelatedTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			RelatedTo.Enabled = false;
			RelatedTo.FormattingEnabled = true;
			RelatedTo.Location = new Point(120, 68);
			RelatedTo.Name = "RelatedTo";
			RelatedTo.Size = new Size(231, 23);
			RelatedTo.TabIndex = 11;
			// 
			// FilterRelatedTo
			// 
			FilterRelatedTo.AutoSize = true;
			FilterRelatedTo.Location = new Point(12, 70);
			FilterRelatedTo.Name = "FilterRelatedTo";
			FilterRelatedTo.Size = new Size(94, 19);
			FilterRelatedTo.TabIndex = 10;
			FilterRelatedTo.Text = "Relación con";
			FilterRelatedTo.UseVisualStyleBackColor = true;
			FilterRelatedTo.CheckedChanged += FilterRelatedTo_CheckedChanged;
			// 
			// FilterMinAffinity
			// 
			FilterMinAffinity.AutoSize = true;
			FilterMinAffinity.Location = new Point(12, 127);
			FilterMinAffinity.Name = "FilterMinAffinity";
			FilterMinAffinity.Size = new Size(98, 19);
			FilterMinAffinity.TabIndex = 12;
			FilterMinAffinity.Text = "Min. Afinidad";
			FilterMinAffinity.UseVisualStyleBackColor = true;
			FilterMinAffinity.CheckedChanged += FilterMinAffinity_CheckedChanged;
			// 
			// MinAffinity
			// 
			MinAffinity.Enabled = false;
			MinAffinity.Location = new Point(120, 126);
			MinAffinity.Name = "MinAffinity";
			MinAffinity.Size = new Size(231, 23);
			MinAffinity.TabIndex = 13;
			// 
			// MaxAffinity
			// 
			MaxAffinity.Enabled = false;
			MaxAffinity.Location = new Point(120, 155);
			MaxAffinity.Name = "MaxAffinity";
			MaxAffinity.Size = new Size(231, 23);
			MaxAffinity.TabIndex = 15;
			// 
			// FilterMaxAffinity
			// 
			FilterMaxAffinity.AutoSize = true;
			FilterMaxAffinity.Location = new Point(12, 156);
			FilterMaxAffinity.Name = "FilterMaxAffinity";
			FilterMaxAffinity.Size = new Size(99, 19);
			FilterMaxAffinity.TabIndex = 14;
			FilterMaxAffinity.Text = "Max. Afinidad";
			FilterMaxAffinity.UseVisualStyleBackColor = true;
			FilterMaxAffinity.CheckedChanged += FilterMaxAffinity_CheckedChanged;
			// 
			// FilterRelationshipRole
			// 
			FilterRelationshipRole.AutoSize = true;
			FilterRelationshipRole.Location = new Point(12, 99);
			FilterRelationshipRole.Name = "FilterRelationshipRole";
			FilterRelationshipRole.Size = new Size(66, 19);
			FilterRelationshipRole.TabIndex = 16;
			FilterRelationshipRole.Text = "Vínculo";
			FilterRelationshipRole.UseVisualStyleBackColor = true;
			FilterRelationshipRole.CheckedChanged += FilterRelationshipRole_CheckedChanged;
			// 
			// RelationshipRole
			// 
			RelationshipRole.Enabled = false;
			RelationshipRole.FormattingEnabled = true;
			RelationshipRole.Location = new Point(120, 97);
			RelationshipRole.Name = "RelationshipRole";
			RelationshipRole.Size = new Size(231, 23);
			RelationshipRole.TabIndex = 17;
			// 
			// MaxPriority
			// 
			MaxPriority.Enabled = false;
			MaxPriority.Location = new Point(120, 213);
			MaxPriority.Name = "MaxPriority";
			MaxPriority.Size = new Size(231, 23);
			MaxPriority.TabIndex = 21;
			// 
			// FilterMaxPriority
			// 
			FilterMaxPriority.AutoSize = true;
			FilterMaxPriority.Location = new Point(12, 214);
			FilterMaxPriority.Name = "FilterMaxPriority";
			FilterMaxPriority.Size = new Size(102, 19);
			FilterMaxPriority.TabIndex = 20;
			FilterMaxPriority.Text = "Max. Prioridad";
			FilterMaxPriority.UseVisualStyleBackColor = true;
			FilterMaxPriority.CheckedChanged += FilterMaxPriority_CheckedChanged;
			// 
			// MinPriority
			// 
			MinPriority.Enabled = false;
			MinPriority.Location = new Point(120, 184);
			MinPriority.Name = "MinPriority";
			MinPriority.Size = new Size(231, 23);
			MinPriority.TabIndex = 19;
			// 
			// FilterMinPriority
			// 
			FilterMinPriority.AutoSize = true;
			FilterMinPriority.Location = new Point(12, 185);
			FilterMinPriority.Name = "FilterMinPriority";
			FilterMinPriority.Size = new Size(101, 19);
			FilterMinPriority.TabIndex = 18;
			FilterMinPriority.Text = "Min. Prioridad";
			FilterMinPriority.UseVisualStyleBackColor = true;
			FilterMinPriority.CheckedChanged += FilterMinPriority_CheckedChanged;
			// 
			// FCitizenRelationshipListFilters
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(363, 292);
			ControlBox = false;
			Controls.Add(MaxPriority);
			Controls.Add(FilterMaxPriority);
			Controls.Add(MinPriority);
			Controls.Add(FilterMinPriority);
			Controls.Add(RelationshipRole);
			Controls.Add(FilterRelationshipRole);
			Controls.Add(MaxAffinity);
			Controls.Add(FilterMaxAffinity);
			Controls.Add(MinAffinity);
			Controls.Add(FilterMinAffinity);
			Controls.Add(RelatedTo);
			Controls.Add(FilterRelatedTo);
			Controls.Add(Citizen);
			Controls.Add(FilterCitizen);
			Controls.Add(User);
			Controls.Add(FilterUser);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Name = "FCitizenRelationshipListFilters";
			Text = "Filtros";
			((System.ComponentModel.ISupportInitialize)MinAffinity).EndInit();
			((System.ComponentModel.ISupportInitialize)MaxAffinity).EndInit();
			((System.ComponentModel.ISupportInitialize)MaxPriority).EndInit();
			((System.ComponentModel.ISupportInitialize)MinPriority).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BAccept;
		private Button BCancel;
		public CheckBox FilterUser;
		public ComboBox User;
		public ComboBox Citizen;
		public CheckBox FilterCitizen;
		public ComboBox RelatedTo;
		public CheckBox FilterRelatedTo;
		public CheckBox FilterMinAffinity;
		public NumericUpDown MinAffinity;
		public NumericUpDown MaxAffinity;
		public CheckBox FilterMaxAffinity;
		public CheckBox FilterRelationshipRole;
		public ComboBox RelationshipRole;
		public NumericUpDown MaxPriority;
		public CheckBox FilterMaxPriority;
		public NumericUpDown MinPriority;
		public CheckBox FilterMinPriority;
	}
}