namespace DyDrums.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            imageList1 = new ImageList(components);
            groupBox3 = new GroupBox();
            PadsTable = new DataGridView();
            PadName = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            Threshold = new DataGridViewTextBoxColumn();
            ScanTime = new DataGridViewTextBoxColumn();
            MaskTime = new DataGridViewTextBoxColumn();
            Retrigger = new DataGridViewTextBoxColumn();
            Curve = new DataGridViewTextBoxColumn();
            CurveForm = new DataGridViewTextBoxColumn();
            MidiDevicesComboBox = new ComboBox();
            MidiDeviceLabel = new Label();
            ConnectCheckBox = new CheckBox();
            COMPortsComboBox = new ComboBox();
            COMPortLabel = new Label();
            MidiDevicesScanButton = new Button();
            groupBox2 = new GroupBox();
            COMPortsScanButton = new Button();
            HiHatProgressBarLabel = new Label();
            groupBox4 = new GroupBox();
            MidiMonitorTextBox = new RichTextBox();
            label1 = new Label();
            HHCVerticalProgressBar = new DyDrums.Services.VerticalProgressBar();
            PadConfigDownloadButton = new Button();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PadsTable).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "refresh2.png");
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(PadsTable);
            groupBox3.Location = new Point(271, 135);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(644, 509);
            groupBox3.TabIndex = 59;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pads";
            // 
            // PadsTable
            // 
            PadsTable.AllowUserToOrderColumns = true;
            PadsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PadsTable.Columns.AddRange(new DataGridViewColumn[] { PadName, Note, Threshold, ScanTime, MaskTime, Retrigger, Curve, CurveForm });
            PadsTable.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            PadsTable.DefaultCellStyle = dataGridViewCellStyle3;
            PadsTable.Enabled = false;
            PadsTable.Location = new Point(21, 28);
            PadsTable.MultiSelect = false;
            PadsTable.Name = "PadsTable";
            PadsTable.RowTemplate.Resizable = DataGridViewTriState.False;
            PadsTable.ScrollBars = ScrollBars.Vertical;
            PadsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PadsTable.Size = new Size(610, 462);
            PadsTable.TabIndex = 29;
            // 
            // PadName
            // 
            PadName.HeaderText = "Nome";
            PadName.Name = "PadName";
            PadName.Resizable = DataGridViewTriState.False;
            PadName.SortMode = DataGridViewColumnSortMode.NotSortable;
            PadName.Width = 70;
            // 
            // Note
            // 
            Note.HeaderText = "Nota";
            Note.Name = "Note";
            Note.Resizable = DataGridViewTriState.False;
            Note.SortMode = DataGridViewColumnSortMode.NotSortable;
            Note.Width = 50;
            // 
            // Threshold
            // 
            Threshold.HeaderText = "Threshold";
            Threshold.Name = "Threshold";
            Threshold.Resizable = DataGridViewTriState.False;
            Threshold.SortMode = DataGridViewColumnSortMode.NotSortable;
            Threshold.Width = 70;
            // 
            // ScanTime
            // 
            ScanTime.HeaderText = "ScanTime";
            ScanTime.Name = "ScanTime";
            ScanTime.Resizable = DataGridViewTriState.False;
            ScanTime.SortMode = DataGridViewColumnSortMode.NotSortable;
            ScanTime.Width = 70;
            // 
            // MaskTime
            // 
            MaskTime.HeaderText = "MaskTime";
            MaskTime.Name = "MaskTime";
            MaskTime.Resizable = DataGridViewTriState.False;
            MaskTime.SortMode = DataGridViewColumnSortMode.NotSortable;
            MaskTime.Width = 70;
            // 
            // Retrigger
            // 
            Retrigger.HeaderText = "Retrigger";
            Retrigger.Name = "Retrigger";
            Retrigger.Resizable = DataGridViewTriState.False;
            Retrigger.SortMode = DataGridViewColumnSortMode.NotSortable;
            Retrigger.Width = 70;
            // 
            // Curve
            // 
            Curve.HeaderText = "Curve";
            Curve.Name = "Curve";
            Curve.Width = 70;
            // 
            // CurveForm
            // 
            CurveForm.HeaderText = "CurveForm";
            CurveForm.Name = "CurveForm";
            CurveForm.Resizable = DataGridViewTriState.False;
            CurveForm.SortMode = DataGridViewColumnSortMode.NotSortable;
            CurveForm.Width = 80;
            // 
            // MidiDevicesComboBox
            // 
            MidiDevicesComboBox.FormattingEnabled = true;
            MidiDevicesComboBox.Location = new Point(362, 23);
            MidiDevicesComboBox.Name = "MidiDevicesComboBox";
            MidiDevicesComboBox.Size = new Size(125, 23);
            MidiDevicesComboBox.TabIndex = 31;
            // 
            // MidiDeviceLabel
            // 
            MidiDeviceLabel.AutoSize = true;
            MidiDeviceLabel.Location = new Point(260, 26);
            MidiDeviceLabel.Name = "MidiDeviceLabel";
            MidiDeviceLabel.Size = new Size(96, 15);
            MidiDeviceLabel.TabIndex = 30;
            MidiDeviceLabel.Text = "Dispositivo MIDI:";
            // 
            // ConnectCheckBox
            // 
            ConnectCheckBox.AutoSize = true;
            ConnectCheckBox.Location = new Point(533, 27);
            ConnectCheckBox.Name = "ConnectCheckBox";
            ConnectCheckBox.Size = new Size(81, 19);
            ConnectCheckBox.TabIndex = 48;
            ConnectCheckBox.Text = "Connectar";
            ConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // COMPortsComboBox
            // 
            COMPortsComboBox.FormattingEnabled = true;
            COMPortsComboBox.Location = new Point(88, 24);
            COMPortsComboBox.Name = "COMPortsComboBox";
            COMPortsComboBox.Size = new Size(128, 23);
            COMPortsComboBox.TabIndex = 5;
            // 
            // COMPortLabel
            // 
            COMPortLabel.AutoSize = true;
            COMPortLabel.Location = new Point(8, 28);
            COMPortLabel.Name = "COMPortLabel";
            COMPortLabel.Size = new Size(74, 15);
            COMPortLabel.TabIndex = 8;
            COMPortLabel.Text = "Portas COM:";
            // 
            // MidiDevicesScanButton
            // 
            MidiDevicesScanButton.BackColor = Color.Transparent;
            MidiDevicesScanButton.Cursor = Cursors.Hand;
            MidiDevicesScanButton.ImageAlign = ContentAlignment.MiddleRight;
            MidiDevicesScanButton.ImageIndex = 0;
            MidiDevicesScanButton.ImageList = imageList1;
            MidiDevicesScanButton.Location = new Point(490, 21);
            MidiDevicesScanButton.Margin = new Padding(0);
            MidiDevicesScanButton.Name = "MidiDevicesScanButton";
            MidiDevicesScanButton.Size = new Size(24, 24);
            MidiDevicesScanButton.TabIndex = 49;
            MidiDevicesScanButton.UseVisualStyleBackColor = false;
            MidiDevicesScanButton.Click += MidiDevicesScanButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(COMPortsScanButton);
            groupBox2.Controls.Add(MidiDevicesScanButton);
            groupBox2.Controls.Add(COMPortLabel);
            groupBox2.Controls.Add(COMPortsComboBox);
            groupBox2.Controls.Add(ConnectCheckBox);
            groupBox2.Controls.Add(MidiDeviceLabel);
            groupBox2.Controls.Add(MidiDevicesComboBox);
            groupBox2.Location = new Point(271, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(644, 65);
            groupBox2.TabIndex = 58;
            groupBox2.TabStop = false;
            groupBox2.Text = "Conexão";
            // 
            // COMPortsScanButton
            // 
            COMPortsScanButton.Cursor = Cursors.Hand;
            COMPortsScanButton.ImageAlign = ContentAlignment.MiddleRight;
            COMPortsScanButton.ImageIndex = 0;
            COMPortsScanButton.ImageList = imageList1;
            COMPortsScanButton.Location = new Point(219, 23);
            COMPortsScanButton.Margin = new Padding(0);
            COMPortsScanButton.Name = "COMPortsScanButton";
            COMPortsScanButton.Size = new Size(24, 24);
            COMPortsScanButton.TabIndex = 50;
            COMPortsScanButton.UseVisualStyleBackColor = true;
            COMPortsScanButton.Click += COMPortsScanButton_Click;
            // 
            // HiHatProgressBarLabel
            // 
            HiHatProgressBarLabel.AutoSize = true;
            HiHatProgressBarLabel.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HiHatProgressBarLabel.Location = new Point(223, 15);
            HiHatProgressBarLabel.Name = "HiHatProgressBarLabel";
            HiHatProgressBarLabel.Size = new Size(33, 13);
            HiHatProgressBarLabel.TabIndex = 32;
            HiHatProgressBarLabel.Text = "HHC:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(MidiMonitorTextBox);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(HHCVerticalProgressBar);
            groupBox4.Controls.Add(HiHatProgressBarLabel);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(9, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(256, 632);
            groupBox4.TabIndex = 60;
            groupBox4.TabStop = false;
            groupBox4.Text = "Monitor";
            // 
            // MidiMonitorTextBox
            // 
            MidiMonitorTextBox.Enabled = false;
            MidiMonitorTextBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MidiMonitorTextBox.Location = new Point(6, 41);
            MidiMonitorTextBox.Name = "MidiMonitorTextBox";
            MidiMonitorTextBox.ScrollBars = RichTextBoxScrollBars.None;
            MidiMonitorTextBox.Size = new Size(218, 585);
            MidiMonitorTextBox.TabIndex = 37;
            MidiMonitorTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 15);
            label1.Name = "label1";
            label1.Size = new Size(94, 13);
            label1.TabIndex = 36;
            label1.Text = "Mensagens MIDI:";
            // 
            // HHCVerticalProgressBar
            // 
            HHCVerticalProgressBar.Location = new Point(230, 39);
            HHCVerticalProgressBar.Name = "HHCVerticalProgressBar";
            HHCVerticalProgressBar.Size = new Size(19, 587);
            HHCVerticalProgressBar.TabIndex = 35;
            // 
            // PadConfigDownloadButton
            // 
            PadConfigDownloadButton.Enabled = false;
            PadConfigDownloadButton.Location = new Point(271, 86);
            PadConfigDownloadButton.Name = "PadConfigDownloadButton";
            PadConfigDownloadButton.Size = new Size(172, 36);
            PadConfigDownloadButton.TabIndex = 61;
            PadConfigDownloadButton.Text = "Ler dados do Arduino";
            PadConfigDownloadButton.UseVisualStyleBackColor = true;
            PadConfigDownloadButton.Click += PadConfigDownloadButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 673);
            Controls.Add(PadConfigDownloadButton);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "DyDrums";
            Load += MainForm_Load;
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PadsTable).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList1;
        private GroupBox groupBox3;
        public DataGridView PadsTable;
        private ComboBox MidiDevicesComboBox;
        private Label MidiDeviceLabel;
        private CheckBox ConnectCheckBox;
        private ComboBox COMPortsComboBox;
        private Label COMPortLabel;
        private Button MidiDevicesScanButton;
        private GroupBox groupBox2;
        private Label HiHatProgressBarLabel;
        private GroupBox groupBox4;
        private Button COMPortsScanButton;
        private Services.VerticalProgressBar HHCVerticalProgressBar;
        private Label label1;
        private DataGridViewTextBoxColumn PadName;
        private DataGridViewTextBoxColumn Note;
        private DataGridViewTextBoxColumn Threshold;
        private DataGridViewTextBoxColumn ScanTime;
        private DataGridViewTextBoxColumn MaskTime;
        private DataGridViewTextBoxColumn Retrigger;
        private DataGridViewTextBoxColumn Curve;
        private DataGridViewTextBoxColumn CurveForm;
        private RichTextBox MidiMonitorTextBox;
        private Button PadConfigDownloadButton;
    }
}
