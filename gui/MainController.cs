using gui.Midi;
using gui.Model;
using gui.Protocol;
using System.IO.Ports;
using System.Text.Json;
using System.Xml.Linq;

namespace gui
{
    public class MainController
    {
        private MainModel model;
        private string settingsFile;
        private JsonSerializerOptions serializerOptions = new JsonSerializerOptions() { 
            PropertyNameCaseInsensitive = true 
        };

        private Settings settings = new Settings();

        public MainController(MainModel model, string settingsFile)
        {
            this.model = model;
            this.settingsFile = settingsFile;
        }

        public void Initialize()
        {
            model.Ports = SerialPort.GetPortNames();

            model.Targets = FetchAvailableTargets().ToArray();
            if (model.Targets.Length == 0)
            {
                throw new Exception("No target.json file found in ./targets folder");
            }

            settings = LoadSettingsFromFile(settingsFile, new Settings()
            {
                ControlChannel = 0,
                Target = model.Targets.First(),
                SerialPort = model.Ports.First()
            });

            model.Device.ControlChannel = settings.ControlChannel;
            if (settings.Target != null && model.Targets.Contains(settings.Target))
            {
                SelectTarget(settings.Target);
            }
            else
            {
                SelectTarget(model.Targets.First());
            }
        }

        public void SaveSettings()
        {
            if (model.SelectedTarget == null)
                throw new InvalidOperationException();

            File.WriteAllText(settingsFile, JsonSerializer.Serialize(settings, serializerOptions));
        }

        public string? GetNameOfCommand(IMidiCommand command)
        {
            if (command is MidiProgramChange programChange)
            {
                TargetProgramChangeItem? item = model.ProgramChangeDictionary.FirstOrDefault(i => i.ProgramNumber == programChange.ProgramNumber);
                return item?.Name;
            }

            return null;
        }

        private static Settings LoadSettingsFromFile(string settingsFile, Settings fallback, JsonSerializerOptions? serializerOptions = null)
        {
            if (!File.Exists(settingsFile))
                return fallback;

            // load config
            string settingsText = File.ReadAllText(settingsFile);
            Settings settings = JsonSerializer.Deserialize<Settings>(settingsText, serializerOptions) ?? throw new Exception("Invalid content of settings.json");
            return settings;
        }

        private static IEnumerable<string> FetchAvailableTargets()
        {
            if (!Directory.Exists("ressources/targets"))
                return new string[] {};

            return Directory.GetFiles("ressources/targets").Where(path => path.EndsWith(".json")).Select(name => Path.GetFileNameWithoutExtension(name));
        }

        public void SelectTarget(string target)
        {
            if (!model.Targets.Contains(target))
                throw new InvalidOperationException();

            string targetFileText = File.ReadAllText($"ressources/targets/{target}.json");
            TargetProgramChangeItem[] items = new TargetProgramChangeItem[] { };
            items = JsonSerializer.Deserialize<TargetProgramChangeItem[]>(targetFileText, serializerOptions) ?? throw new Exception($"Invalid content of {target}.json file");

            model.ProgramChangeDictionary.Clear();
            foreach (TargetProgramChangeItem item in items)
            {
                model.ProgramChangeDictionary.Add(item);
            }

            model.SelectedTarget = target;
            settings.Target = model.SelectedTarget;
            SaveSettings();
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

            settings.ControlChannel = model.Device.ControlChannel;
            SaveSettings();
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
                model.Exception = null;
                model.State = ApplicationState.Busy;
                work.Invoke();
                model.State = ApplicationState.Done;
            }
            catch (Exception ex)
            {
                model.State = ApplicationState.Error;
                model.Exception = ex;
#if (DEBUG)
                // throw;
#endif
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
            model.Device.ControlChannel = settings.ControlChannel;
            model.Device.Buttons = new ButtonConfigurationModel[] { };
            model.SelectedButton = null;
            model.SelectedPort = null;

            using (DeviceProtocol connection = DeviceProtocol.Connect(portName))
            {
                sequences = connection.ReadAllButtonSequences();
            }

            settings.SerialPort = portName;
            SaveSettings();

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
                        buttons.Add(new ButtonConfigurationModel(i, programChange.Value.ProgramNumber));
                        model.Device.ControlChannel = programChange.Value.ControlChannel;
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
            IEnumerable<string> portsToSearch = model.Ports;
            if (!string.IsNullOrEmpty(settings.SerialPort))
            {
                portsToSearch = portsToSearch.Where(i => i != settings.SerialPort).Prepend(settings.SerialPort);
            }

            foreach (string portName in portsToSearch)
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
