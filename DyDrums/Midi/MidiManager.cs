using NAudio.Midi;

namespace DyDrums.Midi
{
    public class MidiManager
    {

        public event Action<int, int, int>? MidiMessageReceived;
        public void Initialize() { /* inicializa MIDI */ }
        public void SendNote(int note, int velocity) { /* envia nota */ }

        private MidiOut? midiOut;

        public static MidiManager Instance { get; internal set; }

        public MidiManager()
        {
            Instance = this;
        }

        public List<string> GetOutputDevices()
        {
            var devices = new List<string>();
            for (int i = 0; i < MidiOut.NumberOfDevices; i++)
            {
                devices.Add(MidiOut.DeviceInfo(i).ProductName);
            }
            return devices;
        }

        public bool Connect(string deviceName)
        {
            for (int i = 0; i < MidiOut.NumberOfDevices; i++)
            {
                if (MidiOut.DeviceInfo(i).ProductName == deviceName)
                {
                    Disconnect(); // fecha se já houver conexão
                    midiOut = new MidiOut(i);
                    return true;
                }
            }
            return false;


        }

        public void Disconnect()
        {
            midiOut?.Dispose();
            midiOut = null;
        }

        public void SendNoteOn(int note, int velocity, int channel = 0)
        {
            if (midiOut == null) return;
            int midiChannel = channel & 0x0F;
            int message = 0x90 | midiChannel | note << 8 | velocity << 16;
            midiOut.Send(message);
        }

        public void SendNoteOff(int note, int velocity = 0, int channel = 0)
        {
            if (midiOut == null) return;
            int midiChannel = channel & 0x0F;
            int message = 0x80 | midiChannel | note << 8 | velocity << 16;
            midiOut.Send(message);
        }

        public async void PlayNoteSafe(int note, int velocity, int durationMs = 10, int channel = 0)
        {
            SendNoteOn((byte)note, (byte)velocity, (byte)channel);
            await Task.Delay(durationMs);
            SendNoteOff((byte)note, (byte)channel);
        }

        public void HandleIncomingMidiMessage(int status, int data1, int data2)
        {
            // Chame o evento para notificar o MainForm (ou quem estiver inscrito)
            MidiMessageReceived?.Invoke(status, data1, data2);
        }

        public void SendControlChange(int channel, int controller, int value)
        {
            if (midiOut != null)
            {
                byte status = (byte)(0xB0 | channel - 1); // CC message
                int midiMessage = status | controller << 8 | value << 16;
                midiOut.Send(midiMessage);
            }
        }
    }
}