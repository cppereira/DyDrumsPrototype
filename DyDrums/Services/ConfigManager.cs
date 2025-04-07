using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DyDrums.Models;

namespace DyDrums.Services
{
    public class ConfigManager
    {
        private readonly string filePath = "Configs/pads.json";

        public ConfigManager()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var configDir = Path.Combine(basePath, "Configs");

            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir); // Sim, isso evita mais drama
            }

            filePath = Path.Combine(configDir, "pads.json");
            
        }
        public string GetFilePath()
        {
            return filePath;
        }

        public List<PadConfig> LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                Debug.WriteLine("[DEBUG] Arquivo JSON não encontrado.");
                return new List<PadConfig>();
            }

            var json = File.ReadAllText(filePath);
            var pads = JsonSerializer.Deserialize<List<PadConfig>>(json) ?? new List<PadConfig>();
            //Debug.WriteLine($"[DEBUG] {pads.Count} pads carregados do JSON.");
            return pads;
        }
        public void SaveToFile(List<PadConfig> configs)
        {
            var json = JsonSerializer.Serialize(configs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            //Debug.WriteLine("[DEBUG] Configurações salvas em JSON com sucesso.");
        }

    }
}


