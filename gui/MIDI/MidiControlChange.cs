using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.MIDI
{
    public struct MidiControlChange : IMidiCommand
    {
        public int Channel;
        public int ControllerNumber;
        public int Value;

        public static MidiControlChange? FromSequence(params byte[] sequence)
        {
            if (sequence.Length != 3)
                return null;

            MidiControlChange res = new MidiControlChange();
            res.Channel = sequence[0] - 176;
            res.ControllerNumber = sequence[1];
            res.Value = sequence[2];
            if (!res.IsValid())
                return null;

            return res;
        }

        public MidiCommandType GetMidiCommandType()
        {
            return MidiCommandType.ControlChange;
        }

        public byte[] GetSequence()
        {
            return new byte[] { (byte)(176 + Channel), (byte)ControllerNumber, (byte)Value };
        }

        public bool IsValid()
        {
            if (Channel < 0 || Channel > 15)
                return false;
            if (ControllerNumber < 0 || ControllerNumber > 127)
                return false;
            if (Value < 0 || Value > 127)
                return false;
            return true;
        }
    }
}
