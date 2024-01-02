using gui.MIDI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class UpdateCommandDialog : Form
    {
        public IMidiCommand? AppliedCommand;

        public IMidiCommandProvider SelectedCommandProvider;

        public UpdateCommandDialog(IMidiCommand? command)
        {
            InitializeComponent();
            commandTypeComboBox.Items.Add(MidiCommandType.ControlChange);
            commandTypeComboBox.Items.Add(MidiCommandType.ProgramChange);
            commandTypeComboBox.Items.Add(MidiCommandType.Start);
            commandTypeComboBox.Items.Add(MidiCommandType.Stop);
            commandTypeComboBox.Items.Add(MidiCommandType.Continue);

            AppliedCommand = command;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedCommandProvider.CanGetMidiCommand())
                AppliedCommand = SelectedCommandProvider.GetMidiCommand();
            else
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MidiCommandType type = (MidiCommandType)commandTypeComboBox.SelectedItem;

            if (AppliedCommand != null && AppliedCommand.GetMidiCommandType() == type)
                SelectedCommandProvider = GetMidiCommandProvider(type, AppliedCommand);
            else
                SelectedCommandProvider = GetMidiCommandProvider(type, null);

            UserControl control = (UserControl)SelectedCommandProvider;
            control.Location = new Point(5, 30);

            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(control);
        }

        private IMidiCommandProvider GetMidiCommandProvider(MidiCommandType type, IMidiCommand? command)
        {
            switch (type)
            {
                case MidiCommandType.ControlChange:
                    return new MidiControlChangeControl((MidiControlChange?)command);
                case MidiCommandType.ProgramChange:
                    return new MidiProgramChangeControl((MidiProgramChange?)command);
                case MidiCommandType.Start:
                    return new MidiStaticCommandControl(MidiStaticSingleByte.Start());
                case MidiCommandType.Stop:
                    return new MidiStaticCommandControl(MidiStaticSingleByte.Stop());
                case MidiCommandType.Continue:
                    return new MidiStaticCommandControl(MidiStaticSingleByte.Continue());
                case MidiCommandType.Other:
                    return new MidiOtherCommandControl(command);
                default:
                    throw new NotImplementedException();
            }
        }

        private void UpdateCommandDialog_Load(object sender, EventArgs e)
        {
            if(AppliedCommand == null)
                commandTypeComboBox.SelectedIndex = 0;
            else
                commandTypeComboBox.SelectedItem = AppliedCommand.GetMidiCommandType();
        }
    }
}
