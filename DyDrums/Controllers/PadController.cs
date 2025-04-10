using DyDrums.Services;

public class PadController
{
    private readonly PadManager padManager;
    private readonly EEPROMManager eepromService;
    private readonly ConfigManager configManager;

    public PadController(PadManager padManager, EEPROMManager eepromService, ConfigManager configManager)
    {
        this.padManager = padManager;
        this.eepromService = eepromService;
        this.configManager = configManager;
    }

    //public List<PadConfig> CarregarPads()
    //{
    //    return configManager.LoadFromFile();
    //}

    //public void SalvarPads(List<PadConfig> pads)
    //{
    //    configManager.SaveToFile(pads);
    //}

    //public void AtualizarPadNaLista(PadConfig atualizado)
    //{
    //    padManager.AtualizarPadNaLista(atualizado); // já existe
    //}

    //public void EnviarPadParaEEPROM(PadConfig pad)
    //{
    //    eepromService.SendPadToEEPROM(pad); // já existe
    //}

    //public void CarregarPadsNaTabela(DataGridView tabela)
    //{
    //    padManager.CarregarNaTabela(tabela); // já existe
    //}

    //public void AplicarPadsNaTabela(DataGridView tabela, List<PadConfig> pads)
    //{
    //    padManager.AplicarNaTabela(tabela, pads); // já existe
    //}

    //public PadConfig? ObterPadPorLinha(int linha)
    //{
    //    return padManager.ObterPorLinha(linha); // já existe
    //}

    //public void AtualizarValorCelula(PadConfig pad, string coluna, string valor)
    //{
    //    padManager.AtualizarValorCelula(pad, coluna, valor); // já existe
    //}
}
