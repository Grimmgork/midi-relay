using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.MIDI
{
    public enum MidiCommandType
    {
        ControlChange,
        ProgramChange,
        Other
    }

    public interface IMidiCommand
    {
        MidiCommandType GetMidiCommandType();
        bool IsValid();
        byte[] GetSequence();
    }
}
