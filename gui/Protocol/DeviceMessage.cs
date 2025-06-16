using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.Protocol
{
    public class DeviceMessage
    {
        public readonly byte Command;
        public readonly byte[] Content;
        public int Length => Content.Length;

        public DeviceMessage(byte command, params byte[] content)
        {
            Command = command;
            Content = content;
        }
    }
}
