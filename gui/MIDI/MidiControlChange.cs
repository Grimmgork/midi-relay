using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.Midi
{
    public class MidiControlChange : IMidiCommand
    {
        public readonly byte ControlChannel;
        public readonly byte ControllerNumber;
        public readonly byte Value;

        public MidiControlChange(byte channel, byte controllerNumber, byte value)
        {
            if (channel > 15)
                throw new Exception("channel must not be larger than 15");

            if (controllerNumber > 127)
                throw new Exception("controllerNumber must not be larger than 127");

            if (value > 127)
                throw new Exception("value must not be larger than 127");

            ControlChannel = channel;
            ControllerNumber = controllerNumber;
            Value = value;
        }

        public byte[] ToSequence()
        {
            return new byte[] { (byte)(176 + ControlChannel), ControllerNumber, Value };
        }

        public static MidiControlChange? FromSequence(byte[] sequence)
        {
            if (sequence.Length != 3)
                return null;

            if (sequence[0] < 176 || sequence[0] > 176 + 15)
                return null;

            if (sequence[1] > 127)
                return null;

            if (sequence[2] > 127)
                return null;

            return new MidiControlChange((byte)(sequence[0] - 176), sequence[1], sequence[3]);
        }
    }
}
