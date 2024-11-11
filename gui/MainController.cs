using gui.Midi;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace gui
{
    public class MainController
    {
        MainViewModel model;
        public MainController(MainViewModel model)
        {
            this.model = model;
        }

        public void FetchPorts()
        {
            model.Ports = SerialPort.GetPortNames();
        }

        public void WriteConfigurationToDevice()
        {
            using (DeviceProtocol connection = DeviceProtocol.Connect(model.SelectedPort!))
            {
                byte i = 0;
                foreach (ButtonConfigurationModel button in model.Device.Buttons)
                {
                    if (button.Enabled)
                    {
                        IMidiCommand command = new MidiProgramChange(model.Device.ControlChannel, button.ProgramNumber);
                        connection.UpdateButtonSequence(i, command.ToSequence());
                    }
                    else
                    {
                        connection.UpdateButtonSequence(i);
                    }
                    i++;
                }
            }

            model.OriginalDevice = (DeviceConfigurationModel)model.Device.Clone();
        }

        public void SelectButton(int index)
        {
            if (index == -1)
                model.SelectedButton = null;
            else
                model.SelectedButton = model.Device.Buttons[index];
        }

        public void DoBusyWork(Action work)
        {
            try
            {
                model.State = ApplicationState.Busy;
                work.Invoke();
                model.State = ApplicationState.Done;
            }
            catch (Exception)
            {
                model.State = ApplicationState.Error;
            }
        }

        public void SelectDevice(string? portName)
        {
            if (portName == null)
            {
                model.SelectedPort = null;
                return;
            }
                
            IEnumerable<byte[]> sequences = Enumerable.Empty<byte[]>();
            model.Device.ControlChannel = 0;
            model.Device.Buttons = new ButtonConfigurationModel[] { };
            model.SelectedButton = null;
            model.SelectedPort = null;

            using (DeviceProtocol connection = DeviceProtocol.Connect(portName))
            {
                sequences = connection.ReadAllButtonSequences();
            }

            int i = 0;
            List<ButtonConfigurationModel> buttons = new List<ButtonConfigurationModel>();
            foreach (byte[] sequence in sequences)
            {
                if (sequence.Length == 0)
                {
                    buttons.Add(new ButtonConfigurationModel(i));
                }
                else
                {
                    MidiProgramChange? programChange = MidiProgramChange.FromSequence(sequence);
                    if (programChange == null)
                    {
                        buttons.Add(new ButtonConfigurationModel(i));
                    }
                    else
                    {
                        buttons.Add(new ButtonConfigurationModel(i, programChange.ProgramNumber));
                        model.Device.ControlChannel = programChange.ControlChannel;
                    }
                }
                i++;
            }
            model.SelectedPort = portName;
            model.Device.Buttons = buttons.ToArray();

            if (model.Device.Buttons.Length > 0)
                model.SelectedButton = model.Device.Buttons[0];

            model.OriginalDevice = (DeviceConfigurationModel) model.Device.Clone();
        }

        public void SearchForDevice()
        {
            model.SelectedPort = null;
            foreach (string portName in model.Ports)
            {
                try
                {
                    using (DeviceProtocol connection = DeviceProtocol.Connect(portName))
                    {
                        connection.Ping();
                    }

                    SelectDevice(portName);
                    return;
                }
                catch (Exception)
                {

                }
            }
        }

        public bool HasUnsavedChanges()
        {
            if (model.SelectedPort == null)
                return false;

            if (model.Device.ControlChannel != model.OriginalDevice.ControlChannel)
                return true;

            for (int i = 0; i < model.Device.Buttons.Length; i++)
            {
                if (model.Device.Buttons[i].Enabled != model.OriginalDevice.Buttons[i].Enabled)
                    return true;

                if (model.Device.Buttons[i].ProgramNumber != model.OriginalDevice.Buttons[i].ProgramNumber)
                    return true;
            }

            return false;
        }
    }
}
