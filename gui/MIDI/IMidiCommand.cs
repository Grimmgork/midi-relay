﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.Midi
{
    public interface IMidiCommand
    {
        public byte[] ToSequence();

        public int GetHashCode();
    }
}
