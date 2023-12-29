using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.MIDI
{
    public struct MidiProgramChange : IMidiCommand
    {
        public int Channel;
        public int ProgramNumber;

        public static MidiProgramChange? FromSequence(params byte[] sequence)
        {
            if (sequence.Length != 2)
                return null;

            MidiProgramChange res = new MidiProgramChange();
            res.Channel = sequence[0] - 192;
            res.ProgramNumber = sequence[1];
            if (!res.IsValid())
                return null;

            return res;
        }

        public MidiCommandType GetMidiCommandType()
        {
            return MidiCommandType.ProgramChange;
        }

        public byte[] GetSequence()
        {
            return new byte[] { (byte)(192 + Channel), (byte)(ProgramNumber) };
        }

        public bool IsValid()
        {
            if (Channel < 0 || Channel > 15)
                return false;
            if (ProgramNumber < 0 || ProgramNumber > 127)
                return false;
            return true;
        }
    }
}
