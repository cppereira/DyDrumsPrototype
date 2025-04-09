using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DyDrums.Midi;
using DyDrums.Models;
using DyDrums.Services;
using static DyDrums.UI.PadEditorForm;

namespace DyDrums.UI
{

    public partial class PadEditorForm : Form
    {

        private readonly EEPROMService _eepromService;
        private MidiManager midiManager;
        private PadConfig originalPad;
        private PadConfig pad;
        private bool preenchendoCampos = false;


        public PadEditorForm(PadConfig padToEdit, EEPROMService eepromService)
        {
            InitializeComponent();
            this.originalPad = padToEdit;
            PreencherCampos(originalPad);
            this.midiManager = midiManager;
            _eepromService = eepromService;


            PadEditorMidiNoteComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            PadEditorMidiNoteComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            PadEditorMidiNoteComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            PadEditorMidiNoteComboBox.Validating += (s, e) =>
            {
                if (int.TryParse(PadEditorMidiNoteComboBox.Text, out int noteValue))
                {
                    var item = PadEditorMidiNoteComboBox.Items
                        .Cast<ComboItem>()
                        .FirstOrDefault(i => i.Value == noteValue);

                    if (item != null)
                    {
                        PadEditorMidiNoteComboBox.SelectedItem = item;
                    }
                    else
                    {
                        // Adiciona dinamicamente se quiser, ou ignora
                        PadEditorMidiNoteComboBox.SelectedItem = new ComboItem
                        {
                            Value = noteValue,
                            Text = GetNoteName(noteValue) + $" ({noteValue})"
                        };
                    }
                }
            };


            //Preenche o TextBox com o nome do PAD
            PadEditorPadNameTextBox.Text = originalPad.Name;

            //Preenche o ComboBox de notas com notas de 0 a 99
            for (int i = 0; i <= 99; i++)
            {
                PadEditorMidiNoteComboBox.Items.Add(new ComboItem
                {
                    Value = i,
                    Text = GetNoteName(i)
                });
            }
            PadEditorMidiNoteComboBox.SelectedItem = PadEditorMidiNoteComboBox.Items
                .Cast<ComboItem>()
                .FirstOrDefault(item => item.Value == originalPad.Note);

            //Preenche o ComboBox Type com os tipos de sensor.
            PadEditorSensorTypeComboBox.Items.AddRange(new[]
            {
                new ComboItem { Value = 0, Text = "Piezo" },
                new ComboItem { Value = 1, Text = "Switch" },
                new ComboItem { Value = 2, Text = "HHC" },
                new ComboItem { Value = 3, Text = "Desabilitado" }
            });
            PadEditorSensorTypeComboBox.SelectedItem = PadEditorSensorTypeComboBox.Items
                .Cast<ComboItem>()
                .FirstOrDefault(item => item.Value == originalPad.Type);

            //Preenche o valor correto de Threshold
            PadEditorThresholdTrackBar.Value = originalPad.Threshold;
            PadEditorThresholdTextBox.Text = originalPad.Threshold.ToString();

            //Preenche o valor correto de ScanTime
            PadEditorScanTimeTrackBar.Value = originalPad.ScanTime;
            PadEditorScanTimeTextBox.Text = originalPad.Threshold.ToString();

            //Preenche o valor correto de MaskTime
            PadEditorMaskTimeTrackBar.Value = originalPad.MaskTime;
            PadEditorMaskTimeTextBox.Text = originalPad.MaskTime.ToString();

            //Preenche o valor correto de Retrigger
            PadEditorRetriggerTrackBar.Value = originalPad.Retrigger;
            PadEditorRetriggerTextBox.Text = originalPad.Retrigger.ToString();

            //Preenche o valor correto de CurveForm
            PadEditorCurveFormTrackBar.Value = originalPad.CurveForm;
            PadEditorCurveFormTextBox.Text = originalPad.CurveForm.ToString();

            //Preenche o valor correto de Gain
            PadEditorGainTextBox.Text = originalPad.Gain.ToString();

            //Preenche o valor correto de Curve
            PadEditorCurveComboBox.Items.AddRange(new[]
            {
                new ComboItem { Value = 0, Text = "Linear" },
                new ComboItem { Value = 1, Text = "Exponencial" },
                new ComboItem { Value = 2, Text = "Logarítmica" },
                new ComboItem { Value = 3, Text = "Sigmoide" },
                new ComboItem { Value = 4, Text = "Flat" }
            });
            PadEditorCurveComboBox.SelectedItem = PadEditorCurveComboBox.Items
                .Cast<ComboItem>()
                .FirstOrDefault(item => item.Value == originalPad.Curve);
        }

        public PadEditorForm(PadConfig pad)
        {
            this.pad = pad;
        }

        public static string GetNoteName(int midiNote)
        {
            string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            int octave = (midiNote / 12) - 1;
            int noteIndex = midiNote % 12;
            return $"{noteNames[noteIndex]}{octave} ({midiNote})";
        }

        private void PadEditorSaveButton_Click(object sender, EventArgs e)
        {
            originalPad.Name = PadEditorPadNameTextBox.Text;
            originalPad.Type = PadEditorSensorTypeComboBox.SelectedIndex;
            originalPad.Note = PadEditorMidiNoteComboBox.SelectedIndex;
            originalPad.Threshold = PadEditorThresholdTrackBar.Value;
            originalPad.ScanTime = PadEditorScanTimeTrackBar.Value;
            originalPad.MaskTime = PadEditorMaskTimeTrackBar.Value;
            originalPad.Retrigger = PadEditorRetriggerTrackBar.Value;
            originalPad.Curve = PadEditorCurveComboBox.SelectedIndex;
            originalPad.CurveForm = PadEditorCurveFormTrackBar.Value;
            originalPad.Gain = PadEditorGainTrackBar.Value;
            originalPad.Xtalk = int.TryParse(PadEditorXTalkTextBox.Text, out var xtalk) ? xtalk : 0;
            originalPad.XtalkGroup = (int)PadEditorXTalkGroupNumericUpDown.Value;
            originalPad.Channel = (int)PadEditorChannelNumericUpDown.Value;

            _eepromService.SendPadToEEPROM(originalPad);

            DialogResult = DialogResult.OK;
            Close();

        }


        public class ComboItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public override string ToString() => Text; // Mostra o texto no ComboBox
        }


        private void PreencherCampos(PadConfig pad)
        {
            preenchendoCampos = true;
            PadEditorPadNameTextBox.Text = pad.Name;

            PadEditorSensorTypeComboBox.SelectedValue = pad.Type;

            PadEditorMidiNoteComboBox.SelectedValue = pad.Note;

            PadEditorThresholdTextBox.Text = pad.Threshold.ToString();
            PadEditorScanTimeTextBox.Text = pad.ScanTime.ToString();
            PadEditorMaskTimeTextBox.Text = pad.MaskTime.ToString();
            PadEditorRetriggerTextBox.Text = pad.Retrigger.ToString();

            PadEditorCurveComboBox.SelectedValue = pad.Curve;

            PadEditorCurveFormTextBox.Text = pad.CurveForm.ToString();
            PadEditorGainTextBox.Text = pad.Gain.ToString();
            PadEditorXTalkTextBox.Text = pad.Xtalk.ToString();

            PadEditorXTalkGroupNumericUpDown.Value = pad.XtalkGroup;
            PadEditorChannelNumericUpDown.Value = pad.Channel;
            preenchendoCampos = false;
        }

        public PadConfig GetUpdatedPad()
        {
            return originalPad;
        }

        public PadConfig GetEditedPad()
        {
            return originalPad;
        }

        private void PadEditorThresholdTrackBar_Scroll(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorThresholdTextBox.Text = PadEditorThresholdTrackBar.Value.ToString();
        }

        private void PadEditorScanTimeTrackBar_Scroll(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorScanTimeTextBox.Text = PadEditorScanTimeTrackBar.Value.ToString();
        }

        private void PadEditorMaskTimeTrackBar_Scroll(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorMaskTimeTextBox.Text = PadEditorMaskTimeTrackBar.Value.ToString();
        }

        private void PadEditorRetriggerTrackBar_Scroll(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorRetriggerTextBox.Text = PadEditorRetriggerTrackBar.Value.ToString();
        }

        private void PadEditorCurveFormTrackBar_Scroll(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorCurveFormTextBox.Text = PadEditorCurveFormTrackBar.Value.ToString();
        }

        private void PadEditorGainTrackBar_Scroll(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorGainTextBox.Text = PadEditorGainTrackBar.Value.ToString();
        }

        private void PadEditorXTalkTrackBar_Scroll(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorXTalkTextBox.Text = PadEditorXTalkTrackBar.Value.ToString();
        }

        //##################################################################################
        private void PadEditorThresholdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorThresholdTrackBar.Value = Int32.Parse(PadEditorThresholdTextBox.Text);
        }

        private void PadEditorScanTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorScanTimeTrackBar.Value = Int32.Parse(PadEditorScanTimeTextBox.Text);
        }

        private void PadEditorMaskTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorMaskTimeTrackBar.Value = Int32.Parse(PadEditorMaskTimeTextBox.Text);
        }

        private void PadEditorRetriggerTextBox_TextChanged(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorRetriggerTrackBar.Value = Int32.Parse(PadEditorRetriggerTextBox.Text);
        }

        private void PadEditorCurveFormTextBox_TextChanged(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorCurveFormTrackBar.Value = Int32.Parse(PadEditorCurveFormTextBox.Text);
        }

        private void PadEditorGainTextBox_TextChanged(object sender, EventArgs e)
        {
            if (preenchendoCampos) return;
            PadEditorGainTrackBar.Value = Int32.Parse(PadEditorGainTextBox.Text);
        }




        private void PadEditorCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
