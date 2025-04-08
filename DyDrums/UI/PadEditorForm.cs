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
using DyDrums.Models;
using static DyDrums.UI.PadEditorForm;

namespace DyDrums.UI
{

    public partial class PadEditorForm : Form
    {
        private PadConfig pad;
        public PadEditorForm(PadConfig padToEdit)
        {
            InitializeComponent();
            this.pad = padToEdit;


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
            PadEditorPadNameTextBox.Text = pad.Name;

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
                .FirstOrDefault(item => item.Value == pad.Note);

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
                .FirstOrDefault(item => item.Value == pad.Type);

            //Preenche o valor correto de Threshold
            PadEditorThresholdTrackBar.Value = pad.Threshold;
            PadEditorThresholdTextBox.Text = pad.Threshold.ToString();

            //Preenche o valor correto de ScanTime
            PadEditorScanTimeTrackBar.Value = pad.ScanTime;
            PadEditorScanTimeTextBox.Text = pad.Threshold.ToString();

            //Preenche o valor correto de MaskTime
            PadEditorMaskTimeTrackBar.Value = pad.MaskTime;
            PadEditorMaskTimeTextBox.Text = pad.MaskTime.ToString();

            //Preenche o valor correto de Retrigger
            PadEditorRetriggerTrackBar.Value = pad.Retrigger;
            PadEditorRetriggerTextBox.Text = pad.Retrigger.ToString();

            //Preenche o valor correto de CurveForm
            PadEditorCurveFormTrackBar.Value = pad.CurveForm;
            PadEditorCurveFormTextBox.Text = pad.CurveForm.ToString();

            //Preenche o valor correto de Gain
            PadEditorGainTextBox.Text = pad.Gain.ToString();

            //Preenche o valor correto de Curve
            PadEditorCurveComboBox.Items.AddRange(new[]
            {
                new ComboItem { Value = 0, Text = "Linear" },
                new ComboItem { Value = 1, Text = "Exponencial" },
                new ComboItem { Value = 2, Text = "Logarítmica" },
                new ComboItem { Value = 3, Text = "Sigma" },
                new ComboItem { Value = 4, Text = "Flat" }
            });
            PadEditorCurveComboBox.SelectedItem = PadEditorCurveComboBox.Items
                .Cast<ComboItem>()
                .FirstOrDefault(item => item.Value == pad.Type);
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
            pad.Name = PadEditorPadNameTextBox.Text;
            pad.Type = PadEditorSensorTypeComboBox.SelectedIndex;
            pad.Note = PadEditorMidiNoteComboBox.SelectedIndex;
            pad.Threshold = Int32.Parse(PadEditorThresholdTextBox.Text);
            pad.ScanTime = PadEditorScanTimeTrackBar.Value;
            pad.MaskTime = PadEditorMaskTimeTrackBar.Value;
            pad.Retrigger = PadEditorRetriggerTrackBar.Value;
            pad.Curve = PadEditorCurveComboBox.SelectedIndex;
            pad.CurveForm = PadEditorCurveComboBox.SelectedIndex;            
            pad.Xtalk = Int32.Parse(PadEditorXTalkTextBox.Text);
            pad.XtalkGroup = Convert.ToInt32(Math.Round(PadEditorXTalkGroupNumericUpDown.Value));
            pad.Channel = Convert.ToInt32(Math.Round(PadEditorChannelNumericUpDown.Value));
            pad.Gain = Int32.Parse(PadEditorGainTextBox.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        public class ComboItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public override string ToString() => Text; // Mostra o texto no ComboBox
        }

        
    }
}
