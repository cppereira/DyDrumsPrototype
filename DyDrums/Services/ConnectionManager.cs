using System.IO.Ports;
using NAudio.Midi;

namespace DyDrums.Services
{
    public static class ConnectionManager
    {
        public static string[] ObterPortasCOMDisponiveis()
        {
            return SerialPort.GetPortNames();
        }

        public static List<string> ObterDispositivosMidi()
        {
            var dispositivos = new List<string>();
            for (int i = 0; i < MidiOut.NumberOfDevices; i++)
            {
                dispositivos.Add(MidiOut.DeviceInfo(i).ProductName);
            }
            return dispositivos;
        }
    }
}
