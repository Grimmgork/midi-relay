using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public class Settings
    {
        public string? SerialPort { get; set; }
        public string? Target { get; set; }
        public byte ControlChannel { get; set; }
    }
}
