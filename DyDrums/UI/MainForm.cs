using System.IO.Ports;
using DyDrums.Midi;
using DyDrums.Models;
using DyDrums.Serial;
using DyDrums.Services;
using NAudio.Midi;

namespace DyDrums.UI
{
    public partial class MainForm : Form
    {

        // Contante para o HHC, depois implementar para pegar ele do arquivo ou da EEPROM...
        private const int HHCNote = 4;

        private readonly SerialManager serialManager = new();
        private readonly MidiManager midiManager = new();
        private readonly PadManager padManager = new PadManager();
        private readonly ConfigManager configManager = new();
        private static List<byte[]> receivedMessages = new();
        private List<PadConfig>? allPads;
        private EEPROMService eepromService;
        private List<PadConfig> originalConfigs = new();

        public static MainForm? Instance { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            midiManager.Initialize();
            padManager = new PadManager();
            eepromService = new EEPROMService(serialManager);
            Instance = this;
        }

        private void MainForm_Load(object? sender, EventArgs? e)
        {
            ConnectCheckBox.Appearance = Appearance.Button;
            ConnectCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            ConnectCheckBox.FlatStyle = FlatStyle.Standard;
            ConnectCheckBox.Size = new Size(100, 40);

            PadsTable.CellEndEdit += PadsTable_CellEndEdit;
            //PadsTable.CellValueChanged += PadsTable_CellValueChanged;


            midiManager.MidiMessageReceived += OnMidiMessageReceived;
            serialManager.MidiMessageReceived += OnMidiMessageReceived;
            //Chama o método que atualiza a lista de portas COM disponíveis
            AtualizarListaDePortas();
            //Chama o método que atualiza a lista de dispositivos MIDI disponíveis
            ListarDispositivosMidi();
            //Conecta o evento do checkbox
            ConnectCheckBox.CheckedChanged += ConnectCheckBox_CheckedChanged;
            var pads = configManager.LoadFromFile();

            originalConfigs = pads.Select(p => p.Clone()).ToList();

            padManager.LoadConfigs(pads);
            PadsTable.CellDoubleClick += PadsTable_CellDoubleClick;
            allPads = padManager.GetAllConfigs();
            RefreshPadsTable();

        }

        //################### GROUP BOX DE CONEXÃO ####################################
        private void AtualizarListaDePortas()
        {
            COMPortsComboBox.Items.Clear();
            string[] portas = SerialPort.GetPortNames();

            Array.Sort(portas); // Ordena alfabeticamente (ex: COM1, COM2, COM3...)
            foreach (string porta in portas)
            {
                COMPortsComboBox.Items.Add(porta);
            }

            // Selecionar a última porta COM disponível (normalmente onde já está o Arduino
            if (portas.Length > 0)
            {
                COMPortsComboBox.SelectedItem = portas[^1]; // última porta
            }
        }

        private void COMPortsScanButton_Click(object? sender, EventArgs? e)
        {
            AtualizarListaDePortas();

        }

        private void ListarDispositivosMidi()
        {
            MidiDevicesComboBox.Items.Clear();

            int totalDevices = MidiOut.NumberOfDevices;

            for (int i = 0; i < totalDevices; i++)
            {
                string deviceName = MidiOut.DeviceInfo(i).ProductName;
                MidiDevicesComboBox.Items.Add(deviceName);
            }

            // Selecionar o último dispositivo MIDI disponível
            if (MidiDevicesComboBox.Items.Count > 0)
            {
                MidiDevicesComboBox.SelectedIndex = MidiDevicesComboBox.Items.Count - 1;
            }
        }

        private void MidiDevicesScanButton_Click(object? sender, EventArgs? e)
        {
            ListarDispositivosMidi();
        }

        private void ConnectCheckBox_CheckedChanged(object? sender, EventArgs? e)
        {

            try
            {
                if (ConnectCheckBox.Checked)
                {
                    //Garantir que a tabela seja carrega em uma possível reconexão
                    var pads = configManager.LoadFromFile();
                    padManager.LoadConfigs(pads);
                    RefreshPadsTable();


                    ConnectCheckBox.Text = "Desconectar";
                    // Obter porta selecionada
                    string selectedPort = COMPortsComboBox.SelectedItem?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(selectedPort))
                        serialManager.Connect(selectedPort);
                    else
                        throw new Exception("Nenhuma porta COM selecionada.");

                    // Obter dispositivo MIDI selecionado
                    string selectedMidiDevice = MidiDevicesComboBox.SelectedItem?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(selectedMidiDevice))
                        midiManager.Connect(selectedMidiDevice);
                    else
                        throw new Exception("Nenhum dispositivo MIDI selecionado.");


                    // Desabilita/Habilita combobox
                    COMPortsComboBox.Enabled = false;
                    COMPortsScanButton.Enabled = false;
                    MidiDevicesComboBox.Enabled = false;
                    MidiDevicesScanButton.Enabled = false;
                    MidiMonitorTextBox.Enabled = true;
                    PadConfigDownloadButton.Enabled = true;
                    HHCVerticalProgressBar.Enabled = true;
                    PadsTable.Enabled = true;
                    PadsTableRefreshButton.Enabled = true;
                    MidiMonitorClearButton.Enabled = true;
                }
                else
                {
                    ConnectCheckBox.Text = "Conectar";
                    serialManager.Disconnect();
                    midiManager.Disconnect();

                    // Habilita/Desabilita combobox
                    COMPortsComboBox.Enabled = true;
                    COMPortsScanButton.Enabled = true;
                    MidiDevicesComboBox.Enabled = true;
                    MidiDevicesScanButton.Enabled = true;
                    MidiMonitorTextBox.Enabled = false;
                    PadConfigDownloadButton.Enabled = false;
                    HHCVerticalProgressBar.Enabled = false;
                    HHCVerticalProgressBar.Value = 0;
                    MidiMonitorTextBox.Clear();
                    PadsTable.Enabled = false;
                    PadsTableRefreshButton.Enabled = false;
                    MidiMonitorClearButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConnectCheckBox.Checked = false;
            }
        }
        //######################## FIM GROUP BOX DE CONEXÃO ###############################

        private void PadConfigDownloadButton_Click(object? sender, EventArgs? e)
        {
            padManager.ResetSysexProcessing();
            serialManager.Handshake();
        }


        public void ReloadGridFromJson()
        {
            var pads = configManager.LoadFromFile();
            padManager.LoadConfigs(pads);
            RefreshPadsTable();
        }

        public void RefreshPadsTable()
        {
            PadsTable.Rows.Clear();
            var configs = padManager.GetAllConfigs();
            foreach (var config in configs)
            {
                if (string.IsNullOrWhiteSpace(config.Name)) continue;
                PadsTable.Rows.Add(
                    config.Type,
                    config.Name,
                    config.Note,
                    config.Threshold,
                    config.ScanTime,
                    config.MaskTime,
                    config.Retrigger,
                    config.Curve,
                    config.CurveForm,
                    config.Xtalk,
                    config.XtalkGroup,
                    config.Channel,
                    config.Gain
                );
            }
        }

        // Conecte esse método ao evento que recebe os dados MIDI
        private void OnMidiMessageReceived(int channel, int note, int velocity)
        {
            Invoke(() =>
            {
                string timestamp = DateTime.Now.ToString("ss,fff");
                string formatted = string.Format("[{0}] => Canal: {1,-2} | Nota: {2,-3} | Velocity: {3,-3}", timestamp, channel, note, velocity);
                MidiMonitorTextBox.AppendText(formatted + Environment.NewLine);
                MidiMonitorTextBox.SelectionStart = MidiMonitorTextBox.Text.Length;
                MidiMonitorTextBox.ScrollToCaret();
                Application.DoEvents();

                // Envia para o MIDI
                midiManager.SendNoteOn(note, velocity, 0);
                Task.Run(async () =>
                {
                    await Task.Delay(5);
                    midiManager.PlayNoteSafe(note, velocity, 20, channel);
                });

                // Atualiza barra de Hi-Hat (nota 4 por padrão)
                if (note == 4)
                {
                    HHCVerticalProgressBar.Value = Math.Min(velocity, HHCVerticalProgressBar.Maximum);
                }
            });
        }


        private void PadsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var pad = allPads[e.RowIndex];
                var editorForm = new PadEditorForm(pad, eepromService);


                if (editorForm.ShowDialog() == DialogResult.OK)
                {
                    // O pad já foi alterado por referência
                    configManager.SaveToFile(allPads);
                    RefreshPadsTable();
                }
            }
        }

        private void MidiMonitorClearButton_Click(object sender, EventArgs e)
        {
            MidiMonitorTextBox?.Clear();
        }

        private void PadsTableRefreshButton_Click(object sender, EventArgs e)
        {
            var pads = configManager.LoadFromFile();
            padManager.LoadConfigs(pads);
            RefreshPadsTable();
        }


        private void PadsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var pad = allPads[e.RowIndex];
            var columnName = PadsTable.Columns[e.ColumnIndex].Name;
            var cell = PadsTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var newValue = cell.Value?.ToString()?.Trim();

            try
            {
                bool changed = false;

                switch (columnName)
                {
                    case "Type":
                        if (int.TryParse(newValue, out var type) && pad.Type != type)
                        {
                            pad.Type = type;
                            changed = true;
                        }
                        break;

                    case "PadName":
                        if (pad.Name != newValue)
                        {
                            pad.Name = newValue ?? "";
                            changed = true;
                        }
                        break;

                    case "Note":
                        if (int.TryParse(newValue, out var note) && pad.Note != note)
                        {
                            pad.Note = note;
                            changed = true;
                        }
                        break;
                    case "Threshold":
                        if (int.TryParse(newValue, out var threshold) && pad.Threshold != threshold)
                        {
                            pad.Threshold = threshold;
                            changed = true;
                        }
                        break;
                    case "ScanTime":
                        if (int.TryParse(newValue, out var scanTime) && pad.ScanTime != scanTime)
                        {
                            pad.Threshold = scanTime;
                            changed = true;
                        }
                        break;
                    case "MaskTime":
                        if (int.TryParse(newValue, out var maskTime) && pad.MaskTime != maskTime)
                        {
                            pad.MaskTime = maskTime;
                            changed = true;
                        }
                        break;
                    case "Retrigger":
                        if (int.TryParse(newValue, out var retrigger) && pad.Retrigger != retrigger)
                        {
                            pad.Retrigger = retrigger;
                            changed = true;
                        }
                        break;
                    case "Curve":
                        if (int.TryParse(newValue, out var curve) && pad.Curve != curve)
                        {
                            pad.Curve = curve;
                            changed = true;
                        }
                        break;
                    case "CurveForm":
                        if (int.TryParse(newValue, out var curveForm) && pad.CurveForm != curveForm)
                        {
                            pad.CurveForm = curveForm;
                            changed = true;
                        }
                        break;
                    case "XTalk":
                        if (int.TryParse(newValue, out var xtalk) && pad.Xtalk != xtalk)
                        {
                            pad.Xtalk = xtalk;
                            changed = true;
                        }
                        break;
                    case "XtalkGroup":
                        if (int.TryParse(newValue, out var xtalkGroup) && pad.XtalkGroup != xtalkGroup)
                        {
                            pad.XtalkGroup = xtalkGroup;
                            changed = true;
                        }
                        break;
                    case "Channel":
                        if (int.TryParse(newValue, out var channel) && pad.Channel != channel)
                        {
                            pad.Channel = channel;
                            changed = true;
                        }
                        break;
                    case "Gain":
                        if (int.TryParse(newValue, out var gain) && pad.Gain != gain)
                        {
                            pad.Gain = gain;
                            changed = true;
                        }
                        break;
                }

                if (changed)
                {
                    configManager.SaveToFile(allPads);
                    eepromService.SendPadToEEPROM(pad);
                    cell.Style.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar célula: " + ex.Message);
            }
        }
    }
}
