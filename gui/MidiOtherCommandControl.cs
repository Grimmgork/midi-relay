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
    public partial class MidiOtherCommandControl : UserControl, IMidiCommandProvider
    {
        public MidiOtherCommandControl(IMidiCommand? command)
        {
            InitializeComponent();
            if (command != null)
                textBox1.Text = BytesToHex(command.GetSequence());
        }

        public bool CanGetMidiCommand()
        {
            try
            {
                HexToBytes(textBox1.Text);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        private static byte[] HexToBytes(string text)
        {
            return new byte[] { };
        }

        private static string BytesToHex(params byte[] sequence)
        {
            StringBuilder builder = new StringBuilder();
            foreach(byte b in sequence)
                builder.AppendFormat("{0:X2} ", b);

            return builder.ToString();
        }

        public IMidiCommand GetMidiCommand()
        {
            return MidiOtherCommand.FromSequence(HexToBytes(textBox1.Text))!;
        }
    }
}
