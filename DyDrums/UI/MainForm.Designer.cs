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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ScanTimeTrackBar = new TrackBar();
            PadNameTextBox = new TextBox();
            PadNameLabel = new Label();
            MidiNoteNumericUpDown = new NumericUpDown();
            MidiNoteLabel = new Label();
            ThresholdTrackbar = new TrackBar();
            ThresholdTrackBarLabel = new Label();
            ThresholdTextBox = new TextBox();
            MaskTimeTrackBar = new TrackBar();
            MaskTimeTrackBarBLabel = new Label();
            MaskTimeTextBox = new TextBox();
            ScanTimeTrackBarLabel = new Label();
            ScanTimeTextBox = new TextBox();
            RetriggerTrackBar = new TrackBar();
            RetriggerTrackBarLabel = new Label();
            RetriggerTextBox = new TextBox();
            imageList1 = new ImageList(components);
            PadConfigDownloadButton = new Button();
            groupBox1 = new GroupBox();
            PadConfigUploadButton = new Button();
            CurveFormTextBox = new TextBox();
            CurveFormTrackBar = new TrackBar();
            CurveComboBox = new ComboBox();
            GainTextBox = new TextBox();
            GainTrackBar = new TrackBar();
            GainTrackBarLabel = new Label();
            CurveFormTrackBarLabel = new Label();
            CurveTrackBarLabel = new Label();
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
            Gain = new DataGridViewTextBoxColumn();
            MidiDevicesComboBox = new ComboBox();
            MidiDeviceLabel = new Label();
            ConnectCheckBox = new CheckBox();
            COMPortsComboBox = new ComboBox();
            COMPortLabel = new Label();
            MidiDevicesScanButton = new Button();
            groupBox2 = new GroupBox();
            COMPortsScanButton = new Button();
            HHCProgressBar = new ProgressBar();
            HiHatProgressBarLabel = new Label();
            MidiMonitorLabel = new Label();
            MidiMonitorClearButton = new Button();
            MidiMonitorTextBox = new RichTextBox();
            groupBox4 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)ScanTimeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidiNoteNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThresholdTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaskTimeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RetriggerTrackBar).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CurveFormTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GainTrackBar).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PadsTable).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // ScanTimeTrackBar
            // 
            ScanTimeTrackBar.Cursor = Cursors.Hand;
            ScanTimeTrackBar.Enabled = false;
            ScanTimeTrackBar.Location = new Point(112, 252);
            ScanTimeTrackBar.Maximum = 127;
            ScanTimeTrackBar.Name = "ScanTimeTrackBar";
            ScanTimeTrackBar.Size = new Size(130, 45);
            ScanTimeTrackBar.TabIndex = 21;
            // 
            // PadNameTextBox
            // 
            PadNameTextBox.Enabled = false;
            PadNameTextBox.Location = new Point(112, 112);
            PadNameTextBox.Name = "PadNameTextBox";
            PadNameTextBox.Size = new Size(188, 23);
            PadNameTextBox.TabIndex = 11;
            // 
            // PadNameLabel
            // 
            PadNameLabel.AutoSize = true;
            PadNameLabel.Location = new Point(20, 112);
            PadNameLabel.Name = "PadNameLabel";
            PadNameLabel.Size = new Size(65, 15);
            PadNameLabel.TabIndex = 12;
            PadNameLabel.Text = "Pad Name:";
            // 
            // MidiNoteNumericUpDown
            // 
            MidiNoteNumericUpDown.Enabled = false;
            MidiNoteNumericUpDown.Location = new Point(112, 157);
            MidiNoteNumericUpDown.Name = "MidiNoteNumericUpDown";
            MidiNoteNumericUpDown.Size = new Size(188, 23);
            MidiNoteNumericUpDown.TabIndex = 13;
            // 
            // MidiNoteLabel
            // 
            MidiNoteLabel.AutoSize = true;
            MidiNoteLabel.Location = new Point(20, 159);
            MidiNoteLabel.Name = "MidiNoteLabel";
            MidiNoteLabel.Size = new Size(64, 15);
            MidiNoteLabel.TabIndex = 14;
            MidiNoteLabel.Text = "Nota MIDI:";
            // 
            // ThresholdTrackbar
            // 
            ThresholdTrackbar.Cursor = Cursors.Hand;
            ThresholdTrackbar.Enabled = false;
            ThresholdTrackbar.Location = new Point(110, 200);
            ThresholdTrackbar.Maximum = 127;
            ThresholdTrackbar.Name = "ThresholdTrackbar";
            ThresholdTrackbar.Size = new Size(130, 45);
            ThresholdTrackbar.TabIndex = 15;
            // 
            // ThresholdTrackBarLabel
            // 
            ThresholdTrackBarLabel.AutoSize = true;
            ThresholdTrackBarLabel.Location = new Point(20, 207);
            ThresholdTrackBarLabel.Name = "ThresholdTrackBarLabel";
            ThresholdTrackBarLabel.Size = new Size(63, 15);
            ThresholdTrackBarLabel.TabIndex = 16;
            ThresholdTrackBarLabel.Text = "Threshold:";
            // 
            // ThresholdTextBox
            // 
            ThresholdTextBox.Enabled = false;
            ThresholdTextBox.Location = new Point(266, 200);
            ThresholdTextBox.MaxLength = 127;
            ThresholdTextBox.Name = "ThresholdTextBox";
            ThresholdTextBox.Size = new Size(36, 23);
            ThresholdTextBox.TabIndex = 17;
            ThresholdTextBox.Text = "0";
            // 
            // MaskTimeTrackBar
            // 
            MaskTimeTrackBar.Cursor = Cursors.Hand;
            MaskTimeTrackBar.Enabled = false;
            MaskTimeTrackBar.Location = new Point(112, 307);
            MaskTimeTrackBar.Maximum = 127;
            MaskTimeTrackBar.Name = "MaskTimeTrackBar";
            MaskTimeTrackBar.Size = new Size(130, 45);
            MaskTimeTrackBar.TabIndex = 18;
            // 
            // MaskTimeTrackBarBLabel
            // 
            MaskTimeTrackBarBLabel.AutoSize = true;
            MaskTimeTrackBarBLabel.Location = new Point(20, 311);
            MaskTimeTrackBarBLabel.Name = "MaskTimeTrackBarBLabel";
            MaskTimeTrackBarBLabel.Size = new Size(65, 15);
            MaskTimeTrackBarBLabel.TabIndex = 19;
            MaskTimeTrackBarBLabel.Text = "MaskTime:";
            // 
            // MaskTimeTextBox
            // 
            MaskTimeTextBox.Enabled = false;
            MaskTimeTextBox.Location = new Point(266, 307);
            MaskTimeTextBox.MaxLength = 127;
            MaskTimeTextBox.Name = "MaskTimeTextBox";
            MaskTimeTextBox.Size = new Size(36, 23);
            MaskTimeTextBox.TabIndex = 20;
            MaskTimeTextBox.Text = "0";
            // 
            // ScanTimeTrackBarLabel
            // 
            ScanTimeTrackBarLabel.AutoSize = true;
            ScanTimeTrackBarLabel.Location = new Point(20, 258);
            ScanTimeTrackBarLabel.Name = "ScanTimeTrackBarLabel";
            ScanTimeTrackBarLabel.Size = new Size(62, 15);
            ScanTimeTrackBarLabel.TabIndex = 22;
            ScanTimeTrackBarLabel.Text = "ScanTime:";
            // 
            // ScanTimeTextBox
            // 
            ScanTimeTextBox.Enabled = false;
            ScanTimeTextBox.Location = new Point(266, 252);
            ScanTimeTextBox.MaxLength = 127;
            ScanTimeTextBox.Name = "ScanTimeTextBox";
            ScanTimeTextBox.Size = new Size(36, 23);
            ScanTimeTextBox.TabIndex = 23;
            ScanTimeTextBox.Text = "0";
            // 
            // RetriggerTrackBar
            // 
            RetriggerTrackBar.Cursor = Cursors.Hand;
            RetriggerTrackBar.Enabled = false;
            RetriggerTrackBar.Location = new Point(112, 366);
            RetriggerTrackBar.Maximum = 127;
            RetriggerTrackBar.Name = "RetriggerTrackBar";
            RetriggerTrackBar.Size = new Size(130, 45);
            RetriggerTrackBar.TabIndex = 24;
            // 
            // RetriggerTrackBarLabel
            // 
            RetriggerTrackBarLabel.AutoSize = true;
            RetriggerTrackBarLabel.Location = new Point(20, 369);
            RetriggerTrackBarLabel.Name = "RetriggerTrackBarLabel";
            RetriggerTrackBarLabel.Size = new Size(58, 15);
            RetriggerTrackBarLabel.TabIndex = 25;
            RetriggerTrackBarLabel.Text = "Retrigger:";
            // 
            // RetriggerTextBox
            // 
            RetriggerTextBox.Enabled = false;
            RetriggerTextBox.Location = new Point(266, 366);
            RetriggerTextBox.MaxLength = 127;
            RetriggerTextBox.Name = "RetriggerTextBox";
            RetriggerTextBox.Size = new Size(36, 23);
            RetriggerTextBox.TabIndex = 26;
            RetriggerTextBox.Text = "0";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "refresh2.png");
            // 
            // PadConfigDownloadButton
            // 
            PadConfigDownloadButton.Location = new Point(170, 31);
            PadConfigDownloadButton.Name = "PadConfigDownloadButton";
            PadConfigDownloadButton.Size = new Size(110, 36);
            PadConfigDownloadButton.TabIndex = 48;
            PadConfigDownloadButton.Text = "Download";
            PadConfigDownloadButton.UseVisualStyleBackColor = true;
            PadConfigDownloadButton.Click += PadConfigDownloadButton_Click;
            this.PadConfigDownloadButton.Click += new System.EventHandler(this.PadConfigDownloadButton_Click);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(PadConfigDownloadButton);
            groupBox1.Controls.Add(ScanTimeTrackBar);
            groupBox1.Controls.Add(PadNameTextBox);
            groupBox1.Controls.Add(PadConfigUploadButton);
            groupBox1.Controls.Add(PadNameLabel);
            groupBox1.Controls.Add(CurveFormTextBox);
            groupBox1.Controls.Add(MidiNoteNumericUpDown);
            groupBox1.Controls.Add(CurveFormTrackBar);
            groupBox1.Controls.Add(MidiNoteLabel);
            groupBox1.Controls.Add(CurveComboBox);
            groupBox1.Controls.Add(ThresholdTrackbar);
            groupBox1.Controls.Add(GainTextBox);
            groupBox1.Controls.Add(ThresholdTrackBarLabel);
            groupBox1.Controls.Add(GainTrackBar);
            groupBox1.Controls.Add(ThresholdTextBox);
            groupBox1.Controls.Add(GainTrackBarLabel);
            groupBox1.Controls.Add(MaskTimeTrackBar);
            groupBox1.Controls.Add(CurveFormTrackBarLabel);
            groupBox1.Controls.Add(MaskTimeTrackBarBLabel);
            groupBox1.Controls.Add(CurveTrackBarLabel);
            groupBox1.Controls.Add(MaskTimeTextBox);
            groupBox1.Controls.Add(ScanTimeTrackBarLabel);
            groupBox1.Controls.Add(ScanTimeTextBox);
            groupBox1.Controls.Add(RetriggerTrackBar);
            groupBox1.Controls.Add(RetriggerTrackBarLabel);
            groupBox1.Controls.Add(RetriggerTextBox);
            groupBox1.Location = new Point(709, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 577);
            groupBox1.TabIndex = 57;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurações do Pad";
            // 
            // PadConfigUploadButton
            // 
            PadConfigUploadButton.Enabled = false;
            PadConfigUploadButton.Location = new Point(42, 31);
            PadConfigUploadButton.Name = "PadConfigUploadButton";
            PadConfigUploadButton.Size = new Size(110, 36);
            PadConfigUploadButton.TabIndex = 47;
            PadConfigUploadButton.Text = "Upload";
            PadConfigUploadButton.UseVisualStyleBackColor = true;
            PadConfigUploadButton.Click += PadConfigUploadButton_Click;
            // 
            // CurveFormTextBox
            // 
            CurveFormTextBox.Enabled = false;
            CurveFormTextBox.Location = new Point(266, 473);
            CurveFormTextBox.MaxLength = 99;
            CurveFormTextBox.Name = "CurveFormTextBox";
            CurveFormTextBox.Size = new Size(36, 23);
            CurveFormTextBox.TabIndex = 46;
            CurveFormTextBox.Text = "0";
            // 
            // CurveFormTrackBar
            // 
            CurveFormTrackBar.Cursor = Cursors.Hand;
            CurveFormTrackBar.Enabled = false;
            CurveFormTrackBar.Location = new Point(110, 465);
            CurveFormTrackBar.Maximum = 127;
            CurveFormTrackBar.Name = "CurveFormTrackBar";
            CurveFormTrackBar.Size = new Size(130, 45);
            CurveFormTrackBar.TabIndex = 45;
            // 
            // CurveComboBox
            // 
            CurveComboBox.Enabled = false;
            CurveComboBox.FormattingEnabled = true;
            CurveComboBox.ItemHeight = 15;
            CurveComboBox.Location = new Point(112, 416);
            CurveComboBox.Name = "CurveComboBox";
            CurveComboBox.Size = new Size(188, 23);
            CurveComboBox.TabIndex = 43;
            // 
            // GainTextBox
            // 
            GainTextBox.Enabled = false;
            GainTextBox.Location = new Point(266, 515);
            GainTextBox.MaxLength = 99;
            GainTextBox.Name = "GainTextBox";
            GainTextBox.Size = new Size(36, 23);
            GainTextBox.TabIndex = 42;
            GainTextBox.Text = "0";
            // 
            // GainTrackBar
            // 
            GainTrackBar.Cursor = Cursors.Hand;
            GainTrackBar.Enabled = false;
            GainTrackBar.Location = new Point(112, 513);
            GainTrackBar.Maximum = 127;
            GainTrackBar.Name = "GainTrackBar";
            GainTrackBar.Size = new Size(130, 45);
            GainTrackBar.TabIndex = 39;
            // 
            // GainTrackBarLabel
            // 
            GainTrackBarLabel.AutoSize = true;
            GainTrackBarLabel.Location = new Point(20, 523);
            GainTrackBarLabel.Name = "GainTrackBarLabel";
            GainTrackBarLabel.Size = new Size(34, 15);
            GainTrackBarLabel.TabIndex = 36;
            GainTrackBarLabel.Text = "Gain:";
            // 
            // CurveFormTrackBarLabel
            // 
            CurveFormTrackBarLabel.AutoSize = true;
            CurveFormTrackBarLabel.Location = new Point(20, 475);
            CurveFormTrackBarLabel.Name = "CurveFormTrackBarLabel";
            CurveFormTrackBarLabel.Size = new Size(69, 15);
            CurveFormTrackBarLabel.TabIndex = 35;
            CurveFormTrackBarLabel.Text = "CurveForm:";
            // 
            // CurveTrackBarLabel
            // 
            CurveTrackBarLabel.AutoSize = true;
            CurveTrackBarLabel.Location = new Point(20, 423);
            CurveTrackBarLabel.Name = "CurveTrackBarLabel";
            CurveTrackBarLabel.Size = new Size(41, 15);
            CurveTrackBarLabel.TabIndex = 34;
            CurveTrackBarLabel.Text = "Curve:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(PadsTable);
            groupBox3.Location = new Point(9, 57);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(692, 348);
            groupBox3.TabIndex = 59;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pads";
            // 
            // PadsTable
            // 
            PadsTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            PadsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            PadsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PadsTable.Columns.AddRange(new DataGridViewColumn[] { PadName, Note, Threshold, ScanTime, MaskTime, Retrigger, Curve, CurveForm, Gain });
            PadsTable.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            PadsTable.DefaultCellStyle = dataGridViewCellStyle2;
            PadsTable.Location = new Point(21, 28);
            PadsTable.MultiSelect = false;
            PadsTable.Name = "PadsTable";
            PadsTable.RowTemplate.Resizable = DataGridViewTriState.False;
            PadsTable.ScrollBars = ScrollBars.Vertical;
            PadsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PadsTable.Size = new Size(652, 300);
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
            Curve.Resizable = DataGridViewTriState.False;
            Curve.SortMode = DataGridViewColumnSortMode.NotSortable;
            Curve.Width = 70;
            // 
            // CurveForm
            // 
            CurveForm.HeaderText = "CurveForm";
            CurveForm.Name = "CurveForm";
            CurveForm.Resizable = DataGridViewTriState.False;
            CurveForm.SortMode = DataGridViewColumnSortMode.NotSortable;
            CurveForm.Width = 70;
            // 
            // Gain
            // 
            Gain.HeaderText = "Gain";
            Gain.Name = "Gain";
            Gain.Resizable = DataGridViewTriState.False;
            Gain.SortMode = DataGridViewColumnSortMode.NotSortable;
            Gain.Width = 50;
            // 
            // MidiDevicesComboBox
            // 
            MidiDevicesComboBox.FormattingEnabled = true;
            MidiDevicesComboBox.Location = new Point(364, 14);
            MidiDevicesComboBox.Name = "MidiDevicesComboBox";
            MidiDevicesComboBox.Size = new Size(128, 23);
            MidiDevicesComboBox.TabIndex = 31;
            // 
            // MidiDeviceLabel
            // 
            MidiDeviceLabel.AutoSize = true;
            MidiDeviceLabel.Location = new Point(267, 19);
            MidiDeviceLabel.Name = "MidiDeviceLabel";
            MidiDeviceLabel.Size = new Size(96, 15);
            MidiDeviceLabel.TabIndex = 30;
            MidiDeviceLabel.Text = "Dispositivo MIDI:";
            // 
            // ConnectCheckBox
            // 
            ConnectCheckBox.AutoSize = true;
            ConnectCheckBox.Location = new Point(598, 18);
            ConnectCheckBox.Name = "ConnectCheckBox";
            ConnectCheckBox.Size = new Size(81, 19);
            ConnectCheckBox.TabIndex = 48;
            ConnectCheckBox.Text = "Connectar";
            ConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // COMPortsComboBox
            // 
            COMPortsComboBox.FormattingEnabled = true;
            COMPortsComboBox.Location = new Point(77, 15);
            COMPortsComboBox.Name = "COMPortsComboBox";
            COMPortsComboBox.Size = new Size(128, 23);
            COMPortsComboBox.TabIndex = 5;
            // 
            // COMPortLabel
            // 
            COMPortLabel.AutoSize = true;
            COMPortLabel.Location = new Point(8, 18);
            COMPortLabel.Name = "COMPortLabel";
            COMPortLabel.Size = new Size(63, 15);
            COMPortLabel.TabIndex = 8;
            COMPortLabel.Text = "Serial Port:";
            // 
            // MidiDevicesScanButton
            // 
            MidiDevicesScanButton.BackColor = Color.Transparent;
            MidiDevicesScanButton.Cursor = Cursors.Hand;
            MidiDevicesScanButton.ImageAlign = ContentAlignment.MiddleRight;
            MidiDevicesScanButton.ImageIndex = 0;
            MidiDevicesScanButton.ImageList = imageList1;
            MidiDevicesScanButton.Location = new Point(495, 13);
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
            groupBox2.Location = new Point(9, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(692, 45);
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
            COMPortsScanButton.Location = new Point(210, 14);
            COMPortsScanButton.Margin = new Padding(0);
            COMPortsScanButton.Name = "COMPortsScanButton";
            COMPortsScanButton.Size = new Size(24, 24);
            COMPortsScanButton.TabIndex = 50;
            COMPortsScanButton.UseVisualStyleBackColor = true;
            COMPortsScanButton.Click += COMPortsScanButton_Click;
            // 
            // HHCProgressBar
            // 
            HHCProgressBar.BackColor = Color.White;
            HHCProgressBar.Enabled = false;
            HHCProgressBar.ForeColor = SystemColors.HotTrack;
            HHCProgressBar.Location = new Point(432, 44);
            HHCProgressBar.Maximum = 127;
            HHCProgressBar.Name = "HHCProgressBar";
            HHCProgressBar.Size = new Size(242, 20);
            HHCProgressBar.Style = ProgressBarStyle.Continuous;
            HHCProgressBar.TabIndex = 33;
            // 
            // HiHatProgressBarLabel
            // 
            HiHatProgressBarLabel.AutoSize = true;
            HiHatProgressBarLabel.Location = new Point(429, 23);
            HiHatProgressBarLabel.Name = "HiHatProgressBarLabel";
            HiHatProgressBarLabel.Size = new Size(82, 15);
            HiHatProgressBarLabel.TabIndex = 32;
            HiHatProgressBarLabel.Text = "HHC Monitor:";
            // 
            // MidiMonitorLabel
            // 
            MidiMonitorLabel.AutoSize = true;
            MidiMonitorLabel.Location = new Point(18, 21);
            MidiMonitorLabel.Name = "MidiMonitorLabel";
            MidiMonitorLabel.Size = new Size(81, 15);
            MidiMonitorLabel.TabIndex = 27;
            MidiMonitorLabel.Text = "Monitor MIDI:";
            // 
            // MidiMonitorClearButton
            // 
            MidiMonitorClearButton.Enabled = false;
            MidiMonitorClearButton.Location = new Point(94, 18);
            MidiMonitorClearButton.Name = "MidiMonitorClearButton";
            MidiMonitorClearButton.Size = new Size(62, 21);
            MidiMonitorClearButton.TabIndex = 3;
            MidiMonitorClearButton.Text = "Limpar";
            MidiMonitorClearButton.UseVisualStyleBackColor = true;
            MidiMonitorClearButton.Click += MidiMonitorClearButton_Click;
            // 
            // MidiMonitorTextBox
            // 
            MidiMonitorTextBox.Enabled = false;
            MidiMonitorTextBox.Location = new Point(21, 44);
            MidiMonitorTextBox.Name = "MidiMonitorTextBox";
            MidiMonitorTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            MidiMonitorTextBox.Size = new Size(394, 119);
            MidiMonitorTextBox.TabIndex = 7;
            MidiMonitorTextBox.Text = "";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(MidiMonitorTextBox);
            groupBox4.Controls.Add(MidiMonitorClearButton);
            groupBox4.Controls.Add(MidiMonitorLabel);
            groupBox4.Controls.Add(HiHatProgressBarLabel);
            groupBox4.Controls.Add(HHCProgressBar);
            groupBox4.Location = new Point(9, 408);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(692, 179);
            groupBox4.TabIndex = 60;
            groupBox4.TabStop = false;
            groupBox4.Text = "Monitor";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 598);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "DyDrums";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)ScanTimeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidiNoteNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThresholdTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaskTimeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)RetriggerTrackBar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CurveFormTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)GainTrackBar).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PadsTable).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TrackBar ScanTimeTrackBar;
        private TextBox PadNameTextBox;
        private Label PadNameLabel;
        private NumericUpDown MidiNoteNumericUpDown;
        private Label MidiNoteLabel;
        private TrackBar ThresholdTrackbar;
        private Label ThresholdTrackBarLabel;
        private TextBox ThresholdTextBox;
        private TrackBar MaskTimeTrackBar;
        private Label MaskTimeTrackBarBLabel;
        private TextBox MaskTimeTextBox;
        private Label ScanTimeTrackBarLabel;
        private TextBox ScanTimeTextBox;
        private TrackBar RetriggerTrackBar;
        private Label RetriggerTrackBarLabel;
        private TextBox RetriggerTextBox;
        private ImageList imageList1;
        private Button PadConfigDownloadButton;
        private GroupBox groupBox1;
        private Button PadConfigUploadButton;
        private TextBox CurveFormTextBox;
        private TrackBar CurveFormTrackBar;
        private ComboBox CurveComboBox;
        private TextBox GainTextBox;
        private TrackBar GainTrackBar;
        private Label GainTrackBarLabel;
        private Label CurveFormTrackBarLabel;
        private Label CurveTrackBarLabel;
        private GroupBox groupBox3;
        public DataGridView PadsTable;
        private DataGridViewTextBoxColumn PadName;
        private DataGridViewTextBoxColumn Note;
        private DataGridViewTextBoxColumn Threshold;
        private DataGridViewTextBoxColumn ScanTime;
        private DataGridViewTextBoxColumn MaskTime;
        private DataGridViewTextBoxColumn Retrigger;
        private DataGridViewTextBoxColumn Curve;
        private DataGridViewTextBoxColumn CurveForm;
        private DataGridViewTextBoxColumn Gain;
        private ComboBox MidiDevicesComboBox;
        private Label MidiDeviceLabel;
        private CheckBox ConnectCheckBox;
        private ComboBox COMPortsComboBox;
        private Label COMPortLabel;
        private Button MidiDevicesScanButton;
        private GroupBox groupBox2;
        private ProgressBar HHCProgressBar;
        private Label HiHatProgressBarLabel;
        private Label MidiMonitorLabel;
        private Button MidiMonitorClearButton;
        private RichTextBox MidiMonitorTextBox;
        private GroupBox groupBox4;
        private Button COMPortsScanButton;
    }
}
