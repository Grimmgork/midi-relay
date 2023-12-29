using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace gui.MIDI
{
    public struct MidiOtherCommand : IMidiCommand
    {
        public byte[] Sequence;

        public static MidiOtherCommand? FromSequence(params byte[] sequence)
        {
            return new MidiOtherCommand() { Sequence = sequence };
        }

        public MidiCommandType GetMidiCommandType()
        {
            return MidiCommandType.Other;
        }

        public byte[] GetSequence()
        {
            return Sequence;
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
