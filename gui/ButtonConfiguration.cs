using gui.MIDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public class ButtonConfiguration
    {
        public byte Index;
        public byte[] Sequence;

        public ButtonConfiguration(byte index, params byte[] sequence)
        {
            Index = index;
            Sequence = sequence;
        }

        public IMidiCommand? ParseCommand()
        {
            if (Sequence.Length == 0)
                return null;

            IMidiCommand? res = null;
            res = MidiProgramChange.FromSequence(Sequence);
            if (res != null)
                return res;
            res = MidiControlChange.FromSequence(Sequence);
            if (res != null)
                return res;

            if(Sequence.Length == 1)
            {
                switch(Sequence[0])
                {
                    case 0xFA:
                        return MidiStaticSingleByte.Start();
                    case 0xFB:
                        return MidiStaticSingleByte.Continue();
                    case 0xFC:
                        return MidiStaticSingleByte.Stop();
                }
            }

            return MidiOtherCommand.FromSequence(Sequence)!;
        }

        public override string ToString()
        {
            string name = $"{(char)(65 + Index)}";
            if (Sequence.Length == 0)
                return name;

            string cmd;
            IMidiCommand? midicmd = ParseCommand();
            switch (midicmd!.GetMidiCommandType())
            {
                case MidiCommandType.ControlChange:
                    cmd = $"CC {((MidiControlChange) midicmd).Channel+1} {((MidiControlChange)midicmd).ControllerNumber+1} {((MidiControlChange)midicmd).Value+1}";
                    break;
                case MidiCommandType.ProgramChange:
                    cmd = $"PC {((MidiProgramChange)midicmd).Channel+1} {((MidiProgramChange)midicmd).ProgramNumber+1}";
                    break;
                case MidiCommandType.Start:
                    cmd = "start";
                    break;
                case MidiCommandType.Stop:
                    cmd = "stop";
                    break;
                case MidiCommandType.Continue:
                    cmd = "continue";
                    break;
                case MidiCommandType.Other:
                    cmd = $"[{RenderHexSequence(Sequence)}]";
                    break;
                default:
                    throw new NotImplementedException();
            }
            return $"{name} {cmd}";
        }

        private static string RenderHexSequence(params byte[] sequence)
        {
            List<string> elements = new List<string>();
            StringBuilder str = new StringBuilder();
            foreach (byte b in sequence)
                elements.Add(String.Format("{0:x2}", b));
            return String.Join(" ", elements);
        }
    }
}
