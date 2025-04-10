using System.Diagnostics;
using DyDrums.Models;

namespace DyDrums.Services
{
    public class EEPROMManager
    {
        private readonly SerialManager serialManager;

        public EEPROMManager(SerialManager serialManager)
        {
            this.serialManager = serialManager;
        }

        public static List<PadConfig> ParseSysex(List<byte[]> sysexMessages)
        {
            var padMap = new Dictionary<int, PadConfig>();

            foreach (var message in sysexMessages)
            {
                if (message.Length < 7 || message[0] != 0xF0 || message[^1] != 0xF7)
                {
                    Debug.WriteLine("[IGNORADO] Mensagem malformada ou fora do padrão.");
                    continue;
                }

                int pin = message[3];
                int param = message[4];
                int value = message[5];

                if (pin < 0 || pin > 14)
                {
                    Debug.WriteLine($"[AVISO] Pino fora do intervalo esperado: {pin}");
                    continue;
                }

                if (!padMap.ContainsKey(pin))
                    padMap[pin] = new PadConfig { Pin = pin };

                var pad = padMap[pin];

                switch (param)
                {
                    case 0x00: pad.Note = value; break;
                    case 0x01: pad.Threshold = value; break;
                    case 0x02: pad.ScanTime = value; break;
                    case 0x03: pad.MaskTime = value; break;
                    case 0x04: pad.Retrigger = value; break;
                    case 0x05: pad.Curve = value; break;
                    case 0x06: pad.Xtalk = value; break;
                    case 0x07: pad.XtalkGroup = value; break;
                    case 0x08: pad.CurveForm = value; break;
                    case 0x0D: pad.Type = value; break;
                    case 0x0E: pad.Channel = value; break;
                    case 0x0F: pad.Gain = value; break;
                    default:
                        Debug.WriteLine($"[AVISO] Parâmetro desconhecido: {param}");
                        break;
                }
            }

            Debug.WriteLine("[DEBUG] ParseSysex finalizado com sucesso.");
            return padMap.Values.ToList();
        }

        public void SendPadToEEPROM(PadConfig pad)
        {
            serialManager.SendSysExToArduino(pad.Pin, 0x00, pad.Note);
            serialManager.SendSysExToArduino(pad.Pin, 0x01, pad.Threshold);
            serialManager.SendSysExToArduino(pad.Pin, 0x02, pad.ScanTime);
            serialManager.SendSysExToArduino(pad.Pin, 0x03, pad.MaskTime);
            serialManager.SendSysExToArduino(pad.Pin, 0x04, pad.Retrigger);
            serialManager.SendSysExToArduino(pad.Pin, 0x05, pad.Curve);
            serialManager.SendSysExToArduino(pad.Pin, 0x06, pad.Xtalk);
            serialManager.SendSysExToArduino(pad.Pin, 0x07, pad.XtalkGroup);
            serialManager.SendSysExToArduino(pad.Pin, 0x08, pad.CurveForm);
            serialManager.SendSysExToArduino(pad.Pin, 0x09, pad.Gain);
            serialManager.SendSysExToArduino(pad.Pin, 0x0D, pad.Type);
            serialManager.SendSysExToArduino(pad.Pin, 0x0E, pad.Channel);
        }
    }
}
