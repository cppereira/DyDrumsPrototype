using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DyDrums.Models;


namespace DyDrums.Services
{
    public class EEPROMService
    {
        private static Dictionary<int, PadConfig> padConfigsInProgress = new Dictionary<int, PadConfig>();
        private static Dictionary<int, PadConfig> padCache = new();
        


        public static List<PadConfig> ParseSysex(List<byte[]> sysexMessages)
        {
            var padMap = new Dictionary<int, PadConfig>();

            foreach (var message in sysexMessages)
            {
                if (message.Length != 7 || message[0] != 0xF0 || message[^1] != 0xF7)
                {
                    //Debug.WriteLine("[IGNORADO] Mensagem malformada ou fora do padrão.");
                    continue;
                }

                int pin = message[3];
                int param = message[4];
                int value = message[5];

                bool debugInvalido = false;

                if (pin < 0 || pin >= 14)
                {
                    if (debugInvalido)
                        //Debug.WriteLine($"[AVISO] Ignorado: pin {pin} inválido.");
                    continue;
                }

                if (!padMap.ContainsKey(pin))
                    padMap[pin] = new PadConfig { Pin = pin };

                var pad = padMap[pin];

                switch (param)
                {
                    case 0: pad.Note = value; break;
                    case 1: pad.Threshold = value; break;
                    case 2: pad.ScanTime = value; break;
                    case 3: pad.MaskTime = value; break;
                    case 4: pad.Retrigger = value; break;
                    case 5: pad.Curve = value; break;
                    case 6: pad.Xtalk = value; break;
                    case 7: pad.XtalkGroup = value; break;
                    case 8: pad.CurveForm = value; break;
                    case 9: pad.Gain = value; break;
                    case 10:
                        // DUAL sensor - ignorado por enquanto
                        break;
                    case 13: pad.Type = value; break;
                    case 14: pad.Channel = value; break;
                    default:
                        //Debug.WriteLine($"[AVISO] Parâmetro desconhecido: {param}");
                        break;
                }
            }

            //Debug.WriteLine("[DEBUG] ParseSysex finalizado com sucesso.");
            return padMap.Values.ToList();
        }
    }
}
