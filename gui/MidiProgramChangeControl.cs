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
    public partial class MidiProgramChangeControl : UserControl, IMidiCommandProvider
    {
        public MidiProgramChangeControl(MidiProgramChange? command)
        {
            InitializeComponent();

            if (command == null)
                return;

            numericUpDown1.Value = command.Value.Channel;
            numericUpDown2.Value = command.Value.ProgramNumber;
        }

        public bool CanGetMidiCommand()
        {
            return true;
        }

        public IMidiCommand GetMidiCommand()
        {
            return new MidiProgramChange()
            {
                Channel = (int)numericUpDown1.Value,
                ProgramNumber = (int)numericUpDown2.Value
            };
        }
    }
}
