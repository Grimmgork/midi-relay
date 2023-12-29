using gui.MIDI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class MidiControlChangeControl : UserControl, IMidiCommandProvider
    {
        public MidiControlChangeControl(MidiControlChange? command)
        {
            InitializeComponent();
            if (command == null)
                return;

            numericUpDown1.Value = command!.Value.Channel;
            numericUpDown2.Value = command!.Value.ControllerNumber;
            numericUpDown3.Value = command!.Value.Value;
        }

        public bool CanGetMidiCommand()
        {
            return true;
        }

        public IMidiCommand GetMidiCommand()
        {
            return new MidiControlChange()
            {
                Channel = (int)numericUpDown1.Value,
                ControllerNumber = (int)numericUpDown2.Value,
                Value = (int)numericUpDown3.Value
            };
        }

        private void ControlChangeControl_Load(object sender, EventArgs e)
        {

        }
    }
}
