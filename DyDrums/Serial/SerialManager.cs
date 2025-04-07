using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DyDrums.Midi;
using System.Diagnostics;
using DyDrums.Services;
using DyDrums.UI;


namespace DyDrums.Serial
{
   public class SerialManager
    {
        private static SerialPort? serialPort;
        private static List<byte> currentSysex = new();
        private static List<byte[]> fullSysexMessages = new();
        private static PadManager padManager = new PadManager();
        private readonly MainForm mainForm;

        public event EventHandler<byte[]>? DataReceived;

        public bool IsConnected => serialPort != null && serialPort.IsOpen;

        

        public static void Initialize(string portName)
        {
            serialPort = new SerialPort(portName, 115200);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        public static void Send(byte[] data)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                //Debug.WriteLine("SysEx enviado pro Arduino.");
                serialPort.Write(data, 0, data.Length);
            }
        }

        public void Connect(string portName, int baudRate = 115200)
        {
            if (IsConnected) Disconnect();

            serialPort = new SerialPort(portName, baudRate);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        public void Disconnect()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.DataReceived -= SerialPort_DataReceived;

                if (serialPort.IsOpen)
                    serialPort.Close();
                serialPort.Dispose();                
            }
        }

        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Debug.WriteLine("Dados recebidos!");

            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    while (serialPort.BytesToRead > 0)
                    {

                        int b = serialPort.ReadByte();
                        //Debug.WriteLine($"Byte recebido: {b:X2} ({b})");

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

                            // Repasse pro PadManager
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
                    }
                }
                else
                {
                    Console.WriteLine("[INFO] Porta serial não está aberta, pulando leitura.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO] Falha na leitura da porta serial: {ex.Message}");
            }
        }

        
        public void Handshake()
        {
            const int totalPads = 15;

            // Parâmetros que você quer pedir
            byte[] parameters = new byte[]
            {
                0x00, // NOTE
                0x01, // THRESHOLD
                0x02, // SCANTIME
                0x03, // MASKTIME
                0x04, // RETRIGGER
                0x05, // CURVE
                0x08, // CURVEFORM
                0x09  // GAIN
              // Adicione mais aqui se quiser, tipo XTALK etc
            };

            for (int pad = 0; pad < totalPads; pad++)
            {
                foreach (byte param in parameters)
                {
                    byte[] sysex = BuildSysExRequest((byte)pad, param);
                    serialPort.Write(sysex, 0, sysex.Length);
                    Thread.Sleep(5); // 🫠 Deixa o Arduino respirar entre os tapas
                }
            }

            // Fim da transmissão (opcional mas recomendado se o Arduino espera)
            byte[] endMessage = new byte[] { 0xF0, 0x77, 0x02, 0x7F, 0x7F, 0x7F, 0xF7 };
            serialPort.Write(endMessage, 0, endMessage.Length);
        }


        private byte[] BuildSysExRequest(byte pad, byte param)
        {
            return new byte[]
            {
        0xF0, 0x77, 0x02, pad, param, 0x00, 0xF7
            };
        }
    }

}
