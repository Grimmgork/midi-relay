using gui.MIDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public interface IMidiCommandProvider
    {
        public bool CanGetMidiCommand();
        public IMidiCommand GetMidiCommand();
    }
}
