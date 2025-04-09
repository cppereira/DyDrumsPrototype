namespace DyDrums.Models
{
    public class PadConfig
    {
        public int Pin { get; set; }
        public int Type { get; set; } // Novo
        public string Name { get; set; } = "";
        public int Note { get; set; }
        public int Threshold { get; set; }
        public int ScanTime { get; set; }
        public int MaskTime { get; set; }
        public int Retrigger { get; set; }
        public int Curve { get; set; }
        public int CurveForm { get; set; }
        public int Xtalk { get; set; } // Novo
        public int XtalkGroup { get; set; } // Novo        
        public int Channel { get; set; } // Novo
        public int Gain { get; set; }

        public override string ToString()
        {
            return $"{Note};{Threshold};{ScanTime};{MaskTime};{Retrigger};{Curve};{CurveForm};{Gain}";
        }

        public static PadConfig FromString(string line, int id)
        {
            var parts = line.Split(';');
            return new PadConfig
            {
                Pin = id,
                Note = int.Parse(parts[0]),
                Threshold = int.Parse(parts[1]),
                ScanTime = int.Parse(parts[2]),
                MaskTime = int.Parse(parts[3]),
                Retrigger = int.Parse(parts[4]),
                Curve = int.Parse(parts[5]),
                CurveForm = int.Parse(parts[6]),
                Gain = int.Parse(parts[7]),
            };
        }

        public PadConfig()
        {
            Pin = -1; // ou 0, ou algum valor padrão que grite “INICIALIZADO ERRADO”
        }
        public PadConfig(int id)
        {
            Pin = id;
        }

        public PadConfig Clone()
        {
            return new PadConfig
            {
                Pin = this.Pin,
                Name = this.Name,
                Type = this.Type,
                Note = this.Note,
                Threshold = this.Threshold,
                ScanTime = this.ScanTime,
                MaskTime = this.MaskTime,
                Retrigger = this.Retrigger,
                Curve = this.Curve,
                CurveForm = this.CurveForm,
                Gain = this.Gain,
                Xtalk = this.Xtalk,
                XtalkGroup = this.XtalkGroup,
                Channel = this.Channel
            };
        }

    }
}
