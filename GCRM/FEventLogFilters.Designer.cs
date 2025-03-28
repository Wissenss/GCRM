namespace GCRM
{
	partial class FEventLogFilters
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
			User = new ComboBox();
			FilterUser = new CheckBox();
			ActionType = new ComboBox();
			FilterActionType = new CheckBox();
			FilterDate = new CheckBox();
			DateTo = new DateTimePicker();
			DateFrom = new DateTimePicker();
			LDateTo = new Label();
			EntityType = new ComboBox();
			FilterEntityType = new CheckBox();
			FilterEntityId = new CheckBox();
			EntityId = new NumericUpDown();
			((System.ComponentModel.ISupportInitialize)EntityId).BeginInit();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(219, 163);
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
			BCancel.Location = new Point(300, 163);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 5;
			BCancel.Text = "&Cerrar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// User
			// 
			User.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			User.DropDownStyle = ComboBoxStyle.DropDownList;
			User.Enabled = false;
			User.FormattingEnabled = true;
			User.Location = new Point(97, 12);
			User.Name = "User";
			User.Size = new Size(278, 23);
			User.TabIndex = 7;
			// 
			// FilterUser
			// 
			FilterUser.AutoSize = true;
			FilterUser.Location = new Point(12, 14);
			FilterUser.Name = "FilterUser";
			FilterUser.Size = new Size(66, 19);
			FilterUser.TabIndex = 6;
			FilterUser.Text = "Usuario";
			FilterUser.UseVisualStyleBackColor = true;
			FilterUser.CheckedChanged += FilterUser_CheckedChanged;
			// 
			// ActionType
			// 
			ActionType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ActionType.DropDownStyle = ComboBoxStyle.DropDownList;
			ActionType.Enabled = false;
			ActionType.FormattingEnabled = true;
			ActionType.Location = new Point(97, 41);
			ActionType.Name = "ActionType";
			ActionType.Size = new Size(278, 23);
			ActionType.TabIndex = 9;
			// 
			// FilterActionType
			// 
			FilterActionType.AutoSize = true;
			FilterActionType.Location = new Point(12, 43);
			FilterActionType.Name = "FilterActionType";
			FilterActionType.Size = new Size(63, 19);
			FilterActionType.TabIndex = 8;
			FilterActionType.Text = "Acción";
			FilterActionType.UseVisualStyleBackColor = true;
			FilterActionType.CheckedChanged += CheckBoxFilterType_CheckedChanged;
			// 
			// FilterDate
			// 
			FilterDate.AutoSize = true;
			FilterDate.Location = new Point(12, 72);
			FilterDate.Name = "FilterDate";
			FilterDate.Size = new Size(57, 19);
			FilterDate.TabIndex = 10;
			FilterDate.Text = "Fecha";
			FilterDate.UseVisualStyleBackColor = true;
			FilterDate.CheckedChanged += FilterDate_CheckedChanged;
			// 
			// DateTo
			// 
			DateTo.Enabled = false;
			DateTo.Format = DateTimePickerFormat.Short;
			DateTo.Location = new Point(255, 70);
			DateTo.Name = "DateTo";
			DateTo.Size = new Size(120, 23);
			DateTo.TabIndex = 11;
			// 
			// DateFrom
			// 
			DateFrom.Enabled = false;
			DateFrom.Format = DateTimePickerFormat.Short;
			DateFrom.Location = new Point(97, 70);
			DateFrom.Name = "DateFrom";
			DateFrom.Size = new Size(120, 23);
			DateFrom.TabIndex = 13;
			// 
			// LDateTo
			// 
			LDateTo.AutoSize = true;
			LDateTo.Enabled = false;
			LDateTo.Location = new Point(228, 73);
			LDateTo.Name = "LDateTo";
			LDateTo.Size = new Size(16, 15);
			LDateTo.TabIndex = 14;
			LDateTo.Text = "al";
			// 
			// EntityType
			// 
			EntityType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			EntityType.DropDownStyle = ComboBoxStyle.DropDownList;
			EntityType.Enabled = false;
			EntityType.FormattingEnabled = true;
			EntityType.Location = new Point(97, 99);
			EntityType.Name = "EntityType";
			EntityType.Size = new Size(278, 23);
			EntityType.TabIndex = 16;
			// 
			// FilterEntityType
			// 
			FilterEntityType.AutoSize = true;
			FilterEntityType.Location = new Point(12, 101);
			FilterEntityType.Name = "FilterEntityType";
			FilterEntityType.Size = new Size(66, 19);
			FilterEntityType.TabIndex = 15;
			FilterEntityType.Text = "Entidad";
			FilterEntityType.UseVisualStyleBackColor = true;
			FilterEntityType.CheckedChanged += FilterEntityType_CheckedChanged;
			// 
			// FilterEntityId
			// 
			FilterEntityId.AutoSize = true;
			FilterEntityId.Location = new Point(12, 129);
			FilterEntityId.Name = "FilterEntityId";
			FilterEntityId.Size = new Size(79, 19);
			FilterEntityId.TabIndex = 17;
			FilterEntityId.Text = "Entidad Id";
			FilterEntityId.UseVisualStyleBackColor = true;
			FilterEntityId.CheckedChanged += FilterEntityId_CheckedChanged;
			// 
			// EntityId
			// 
			EntityId.Enabled = false;
			EntityId.Location = new Point(97, 128);
			EntityId.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
			EntityId.Name = "EntityId";
			EntityId.Size = new Size(278, 23);
			EntityId.TabIndex = 18;
			// 
			// FEventLogFilters
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(387, 198);
			ControlBox = false;
			Controls.Add(EntityId);
			Controls.Add(FilterEntityId);
			Controls.Add(EntityType);
			Controls.Add(FilterEntityType);
			Controls.Add(LDateTo);
			Controls.Add(DateFrom);
			Controls.Add(DateTo);
			Controls.Add(FilterDate);
			Controls.Add(ActionType);
			Controls.Add(FilterActionType);
			Controls.Add(User);
			Controls.Add(FilterUser);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Name = "FEventLogFilters";
			Text = "Filtros";
			((System.ComponentModel.ISupportInitialize)EntityId).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BAccept;
		private Button BCancel;
		private Label LDateTo;
		public ComboBox User;
		public CheckBox FilterUser;
		public ComboBox ActionType;
		public CheckBox FilterActionType;
		public CheckBox FilterDate;
		public DateTimePicker DateTo;
		public DateTimePicker DateFrom;
		public ComboBox EntityType;
		public CheckBox FilterEntityType;
		public CheckBox FilterEntityId;
		public NumericUpDown EntityId;
	}
}