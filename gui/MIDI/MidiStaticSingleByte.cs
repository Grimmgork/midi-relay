using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.MIDI
{
    internal class MidiStaticSingleByte : IMidiCommand
    {
        MidiCommandType commandType;
        byte template;

        private MidiStaticSingleByte(byte template, MidiCommandType type)
        {
            commandType = type;
            this.template = template;
        }

        public MidiCommandType GetMidiCommandType()
        {
            return commandType;
        }

        public byte[] GetSequence()
        {
            return new byte[] { template };
        }

        public bool IsValid()
        {
            return true;
        }

        public static MidiStaticSingleByte Start()
        {
            return new MidiStaticSingleByte(0xFA, MidiCommandType.Start);
        }

        public static MidiStaticSingleByte Stop()
        {
            return new MidiStaticSingleByte(0xFC, MidiCommandType.Stop);
        }

        public static MidiStaticSingleByte Continue()
        {
            return new MidiStaticSingleByte(0xFB, MidiCommandType.Continue);
        }
    }
}
