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
			ComboBoxUser = new ComboBox();
			CheckBoxFilterUser = new CheckBox();
			ComboBoxType = new ComboBox();
			CheckBoxFilterType = new CheckBox();
			CheckBoxFilterDate = new CheckBox();
			DateTo = new DateTimePicker();
			LDateFrom = new Label();
			DateFrom = new DateTimePicker();
			LDateTo = new Label();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(219, 117);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 4;
			BAccept.Text = "&Aplicar";
			BAccept.UseVisualStyleBackColor = true;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(300, 117);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 5;
			BCancel.Text = "&Cerrar";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// ComboBoxUser
			// 
			ComboBoxUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxUser.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxUser.Enabled = false;
			ComboBoxUser.FormattingEnabled = true;
			ComboBoxUser.Location = new Point(84, 12);
			ComboBoxUser.Name = "ComboBoxUser";
			ComboBoxUser.Size = new Size(291, 23);
			ComboBoxUser.TabIndex = 7;
			// 
			// CheckBoxFilterUser
			// 
			CheckBoxFilterUser.AutoSize = true;
			CheckBoxFilterUser.Location = new Point(12, 14);
			CheckBoxFilterUser.Name = "CheckBoxFilterUser";
			CheckBoxFilterUser.Size = new Size(66, 19);
			CheckBoxFilterUser.TabIndex = 6;
			CheckBoxFilterUser.Text = "Usuario";
			CheckBoxFilterUser.UseVisualStyleBackColor = true;
			// 
			// ComboBoxType
			// 
			ComboBoxType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxType.Enabled = false;
			ComboBoxType.FormattingEnabled = true;
			ComboBoxType.Location = new Point(84, 41);
			ComboBoxType.Name = "ComboBoxType";
			ComboBoxType.Size = new Size(291, 23);
			ComboBoxType.TabIndex = 9;
			// 
			// CheckBoxFilterType
			// 
			CheckBoxFilterType.AutoSize = true;
			CheckBoxFilterType.Location = new Point(12, 43);
			CheckBoxFilterType.Name = "CheckBoxFilterType";
			CheckBoxFilterType.Size = new Size(63, 19);
			CheckBoxFilterType.TabIndex = 8;
			CheckBoxFilterType.Text = "Acción";
			CheckBoxFilterType.UseVisualStyleBackColor = true;
			// 
			// CheckBoxFilterDate
			// 
			CheckBoxFilterDate.AutoSize = true;
			CheckBoxFilterDate.Location = new Point(12, 74);
			CheckBoxFilterDate.Name = "CheckBoxFilterDate";
			CheckBoxFilterDate.Size = new Size(57, 19);
			CheckBoxFilterDate.TabIndex = 10;
			CheckBoxFilterDate.Text = "Fecha";
			CheckBoxFilterDate.UseVisualStyleBackColor = true;
			// 
			// DateTo
			// 
			DateTo.Enabled = false;
			DateTo.Format = DateTimePickerFormat.Short;
			DateTo.Location = new Point(262, 70);
			DateTo.Name = "DateTo";
			DateTo.Size = new Size(113, 23);
			DateTo.TabIndex = 11;
			// 
			// LDateFrom
			// 
			LDateFrom.AutoSize = true;
			LDateFrom.Enabled = false;
			LDateFrom.Location = new Point(84, 75);
			LDateFrom.Name = "LDateFrom";
			LDateFrom.Size = new Size(34, 15);
			LDateFrom.TabIndex = 12;
			LDateFrom.Text = "entre";
			// 
			// DateFrom
			// 
			DateFrom.Enabled = false;
			DateFrom.Format = DateTimePickerFormat.Short;
			DateFrom.Location = new Point(124, 70);
			DateFrom.Name = "DateFrom";
			DateFrom.Size = new Size(113, 23);
			DateFrom.TabIndex = 13;
			// 
			// LDateTo
			// 
			LDateTo.AutoSize = true;
			LDateTo.Enabled = false;
			LDateTo.Location = new Point(243, 75);
			LDateTo.Name = "LDateTo";
			LDateTo.Size = new Size(13, 15);
			LDateTo.TabIndex = 14;
			LDateTo.Text = "y";
			// 
			// FEventLogFilters
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(387, 152);
			ControlBox = false;
			Controls.Add(LDateTo);
			Controls.Add(DateFrom);
			Controls.Add(LDateFrom);
			Controls.Add(DateTo);
			Controls.Add(CheckBoxFilterDate);
			Controls.Add(ComboBoxType);
			Controls.Add(CheckBoxFilterType);
			Controls.Add(ComboBoxUser);
			Controls.Add(CheckBoxFilterUser);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Name = "FEventLogFilters";
			Text = "Filtros";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BAccept;
		private Button BCancel;
		private ComboBox ComboBoxUser;
		private CheckBox CheckBoxFilterUser;
		private ComboBox ComboBoxType;
		private CheckBox CheckBoxFilterType;
		private CheckBox CheckBoxFilterDate;
		private DateTimePicker DateTo;
		private Label LDateFrom;
		private DateTimePicker DateFrom;
		private Label LDateTo;
	}
}