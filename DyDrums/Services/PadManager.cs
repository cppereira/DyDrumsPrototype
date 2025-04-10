using DyDrums.Models;
using DyDrums.UI;

namespace DyDrums.Services
{
    public class PadManager
    {
        public Dictionary<int, PadConfig> Pads { get; set; } = new();
        private readonly List<PadConfig> padConfigs = new();
        private static List<byte[]> receivedMessages = new();
        private readonly ConfigManager configManager = new ConfigManager();
        private PadManager? padManager;

        public void LoadConfigs(List<PadConfig> configs)
        {
            padConfigs.Clear();
            padConfigs.AddRange(configs);
            MainForm.Instance.RefreshPadsTable();
        }

        public List<PadConfig> GetAllConfigs()
        {
            return padConfigs;
        }

        private bool alreadyProcessed = false;


        public void ResetSysexProcessing()
        {
            alreadyProcessed = false;
        }
        public void ProcessSysex(List<byte[]> messages, DataGridView grid)
        {
            receivedMessages.AddRange(messages);

            // Verifica se a última mensagem indica o fim da transmissão
            if (alreadyProcessed || !receivedMessages.Any(m => IsEndMessage(m)))
            {
                return;
            }

            alreadyProcessed = true;

            var pads = EEPROMManager.ParseSysex(receivedMessages);

            // Remove pads inválidos ou fantasmas
            pads = pads
                .Where(p => p != null && p.Pin >= 0 && p.Pin < 15)
                .ToList();

            // Tenta manter os nomes antigos, se houver
            var existingPads = configManager.LoadFromFile();
            foreach (var pad in pads)
            {
                var match = existingPads.FirstOrDefault(p => p.Pin == pad.Pin);
                if (match != null)
                {
                    pad.Name = match.Name;
                }
            }

            //Salva as configs no JSON
            configManager.SaveToFile(pads);

            //Atualiza o PadManager
            LoadConfigs(pads);

            //Força o refresh na Tabela com os novos valores
            MainForm.Instance.Invoke(() =>
            {
                MainForm.Instance.ReloadGridFromJson();
            });

            receivedMessages.Clear();
        }


        bool IsEndMessage(byte[] message)
        {
            return message.Length >= 6 && message[1] == 0x77 && message[2] == 0x02 &&
                   message[3] == 0x7F && message[4] == 0x7F && message[5] == 0x7F;
        }

        public PadConfig? GetPadByIndex(int index)
        {
            if (index >= 0 && index < padConfigs.Count)
                return padConfigs[index];

            return null; // Se você for do tipo cauteloso
        }

    }
}
