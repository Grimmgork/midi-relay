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
            commandTypeComboBox.Items.Add(MidiCommandType.Other);

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

            groupBox1.Controls.Clear();
            groupBox1.Controls.Add((UserControl)SelectedCommandProvider);
        }

        private IMidiCommandProvider GetMidiCommandProvider(MidiCommandType type, IMidiCommand? command)
        {
            switch (type)
            {
                case MidiCommandType.ControlChange:
                    return new MidiControlChangeControl((MidiControlChange?)command);
                case MidiCommandType.ProgramChange:
                    return new MidiProgramChangeControl((MidiProgramChange?)command);
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
