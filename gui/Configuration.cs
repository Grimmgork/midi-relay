using gui.MIDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public class Configuration
    {
        public byte ControlChannel;
        public ButtonConfig[] Buttons;
    }

    public class ButtonConfig
    {
        public IMidiCommand Up;
        public IMidiCommand Down;
    }
}
