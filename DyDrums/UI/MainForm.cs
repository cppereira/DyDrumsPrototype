using System;
using System.IO.Ports;
using DyDrums.Midi;
using DyDrums.Serial;
using DyDrums.Services;
using DyDrums.Models;
using NAudio.Midi;
using System.Diagnostics;
using System.Text.Json;
using static DyDrums.UI.MainForm;

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
        private List<PadConfig> allPads;
        private EEPROMService eepromService;

        public static MainForm Instance { get; private set; }

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


            midiManager.MidiMessageReceived += OnMidiMessageReceived;
            serialManager.MidiMessageReceived += OnMidiMessageReceived;
            //Chama o método que atualiza a lista de portas COM disponíveis
            AtualizarListaDePortas();
            //Chama o método que atualiza a lista de dispositivos MIDI disponíveis
            ListarDispositivosMidi();
            //Conecta o evento do checkbox
            ConnectCheckBox.CheckedChanged += ConnectCheckBox_CheckedChanged;
            var pads = configManager.LoadFromFile();
            //MessageBox.Show($"[DEBUG] {pads.Count} pads carregados do JSON.");
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

            // Selecionar a última porta COM disponível
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

        private void SaveConfig()
        {
            var currentConfigs = padManager.GetAllConfigs();

            configManager.SaveToFile(currentConfigs);
            MessageBox.Show("Configurações salvas com sucesso!", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            RefreshPadsTable();
        }
    }
}
