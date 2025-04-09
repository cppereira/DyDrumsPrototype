using System.Diagnostics;
using System.IO.Ports;
using DyDrums.Midi;
using DyDrums.Services;
using DyDrums.UI;

namespace DyDrums.Serial
{
    public class SerialManager
    {
        public event Action<int, int, int>? MidiMessageReceived;

        private static SerialPort? serialPort;
        private static List<byte> currentSysex = new();
        private static List<byte[]> fullSysexMessages = new();
        private static PadManager padManager = new();

        public bool IsConnected => serialPort != null && serialPort.IsOpen;

        public void Connect(string portName, int baudRate = 115200)
        {
            try
            {
                if (serialPort != null)
                {
                    serialPort.DataReceived -= SerialPort_DataReceived;
                    if (serialPort.IsOpen)
                        serialPort.Close();

                    serialPort.Dispose();
                    serialPort = null;
                }

                serialPort = new SerialPort(portName, baudRate);
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();

                Debug.WriteLine($"[SerialManager] Porta {portName} conectada com sucesso.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine($"[SerialManager] Porta {portName} está em uso: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SerialManager] Erro ao abrir porta {portName}: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            if (serialPort != null)
            {
                try
                {
                    serialPort.DataReceived -= SerialPort_DataReceived;

                    if (serialPort.IsOpen)
                        serialPort.Close();

                    serialPort.Dispose();
                    serialPort = null;

                    Debug.WriteLine("[SerialManager] Porta desconectada.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[SerialManager] Erro ao desconectar: {ex.Message}");
                }
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen) return;

            try
            {
                while (serialPort.BytesToRead > 0)
                {
                    int b = serialPort.ReadByte();

                    if (b == 0xF0)
                    {
                        currentSysex.Clear();
                        currentSysex.Add((byte)b);
                    }
                    else if (b == 0xF7)
                    {
                        currentSysex.Add((byte)b);
                        fullSysexMessages.Add(currentSysex.ToArray());
                        currentSysex.Clear();

                        MainForm.Instance.BeginInvoke(new Action(() =>
                        {
                            padManager.ProcessSysex(fullSysexMessages, MainForm.Instance.PadsTable);
                            fullSysexMessages.Clear();
                        }));
                    }
                    else if (currentSysex.Count > 0)
                    {
                        currentSysex.Add((byte)b);
                    }
                    else
                    {
                        if (serialPort.BytesToRead >= 2)
                        {
                            int channel = (b & 0x0F) + 1;
                            int data1 = serialPort.ReadByte();
                            int data2 = serialPort.ReadByte();

                            if (data1 == 4)
                            {
                                MidiManager.Instance.SendControlChange(channel, 4, data2);


                                MainForm.Instance?.Invoke(() =>
                                {
                                    if (MainForm.Instance.HHCVerticalProgressBar != null)
                                    {
                                        int max = MainForm.Instance.HHCVerticalProgressBar.Maximum;
                                        int invertedValue = max - data2;
                                        MainForm.Instance.HHCVerticalProgressBar.Value = Math.Max(MainForm.Instance.HHCVerticalProgressBar.Minimum, invertedValue);
                                    }
                                }); ;
                            }
                            else
                            {
                                MidiMessageReceived?.Invoke(channel, data1, data2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SerialManager] Erro na leitura: {ex.Message}");
            }
        }

        public void Handshake()
        {
            const int totalPads = 15;

            if (serialPort == null || !EnsurePortOpen())
            {
                Debug.WriteLine("SerialPort não está pronta para handshake.");
                return;
            }

            byte[] parameters = new byte[]
            {
                0x00, 0x01, 0x02, 0x03,
                0x04, 0x05, 0x06, 0x07,
                0x08, 0x0D, 0x0E, 0x0F
            };

            try
            {
                for (int pad = 0; pad < totalPads; pad++)
                {
                    foreach (byte param in parameters)
                    {
                        if (!serialPort.IsOpen) return;
                        byte[] sysex = BuildSysExRequest((byte)pad, param);
                        serialPort.Write(sysex, 0, sysex.Length);
                        Thread.Sleep(5);
                    }
                }

                byte[] endMessage = new byte[] { 0xF0, 0x77, 0x02, 0x7F, 0x7F, 0x7F, 0xF7 };
                serialPort.Write(endMessage, 0, endMessage.Length);

                Debug.WriteLine("[HANDSHAKE] Handshake concluído.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[HANDSHAKE] Erro: " + ex.Message);
            }
        }

        private byte[] BuildSysExRequest(byte pad, byte param)
        {
            return new byte[] { 0xF0, 0x77, 0x02, pad, param, 0x00, 0xF7 };
        }

        public void SendSysExToArduino(int pin, int param, int value)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                byte[] message = new byte[]
                {
                    0xF0, 0x77, 0x04, (byte)pin, (byte)param, (byte)value, 0xF7
                };

                serialPort.Write(message, 0, message.Length);
            }
            else
            {
                Debug.WriteLine("[SerialManager] Porta não está aberta.");
            }
        }

        private bool EnsurePortOpen()
        {
            if (serialPort == null) return false;

            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    Debug.WriteLine("[SerialManager] Porta aberta dinamicamente.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[SerialManager] Falha ao abrir: " + ex.Message);
                    return false;
                }
            }

            return true;
        }
    }
}