using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace gui.Midi
{
    public class MidiProgramChange : IMidiCommand
    {
        public readonly byte ControlChannel;
        public readonly byte ProgramNumber;

        public MidiProgramChange(byte channel, byte programNumber)
        {
            if (channel > 15)
                throw new Exception("channel must not be larger than 15");

            if (programNumber > 127)
                throw new Exception("programNumber must not be larger than 127");

            ControlChannel = channel;
            ProgramNumber = programNumber;
        }

        public byte[] ToSequence()
        {
            return new byte[] { (byte)(192 + ControlChannel), ProgramNumber };
        }

        public static MidiProgramChange? FromSequence(byte[] sequence)
        {
            if (sequence.Length != 2)
                return null;

            if (sequence[0] < 192 || sequence[0] > 192 + 15)
                return null;

            if (sequence[1] > 127)
                return null;

            return new MidiProgramChange((byte)(sequence[0] - 192), sequence[1]);
        }
    }
}
