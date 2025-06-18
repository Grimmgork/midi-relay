using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui.Midi;
using gui.Model;

namespace gui
{
    public enum ApplicationState
    {
        Done,
        Busy,
        Error
    }

    public class MainModel : INotifyPropertyChanged
    {
        private string? _selectedPort;
        private DeviceConfigurationModel _device = new DeviceConfigurationModel();
        private ApplicationState _state;
        private string? _errorMessage;
        private string[] _ports = new string[] {};
        private string[] _targets = new string[] {};
        private ButtonConfigurationModel? _selectedButton;
        private string? _selectedTarget;
        private List<TargetProgramChangeItem> _programChangeItems = new List<TargetProgramChangeItem>();
        private Exception? exception;

        public Exception? Exception
        {
            get
            {
                return exception;
            }
            set
            {
                exception = value;
                OnPropertyChanged(nameof(Exception));
            }
        }

        public ICollection<TargetProgramChangeItem> ProgramChangeDictionary
        {
            get
            {
                return _programChangeItems;
            }
        }

        public ButtonConfigurationModel? SelectedButton
        {
            get
            {
                return _selectedButton;
            }
            set
            {
                _selectedButton = value;
                OnPropertyChanged(nameof(SelectedButton));
            }
        }
        
        public string? SelectedPort
        {
            get
            {
                return _selectedPort;
            }
            set
            {
                _selectedPort = value;
                OnPropertyChanged(nameof(SelectedPort));
            }
        }

        public string? SelectedTarget
        {
            get
            {
                return _selectedTarget;
            }
            set
            {
                _selectedTarget = value;
                OnPropertyChanged(nameof(SelectedTarget));
            }
        }

        public string? ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        
        public ApplicationState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        public DeviceConfigurationModel Device
        {
            get
            {
                return _device;
            }
            //set
            //{
            //    _device = value;
            //    OnPropertyChanged(nameof(Device));
            //}
        }

        public DeviceConfigurationModel OriginalDevice = new DeviceConfigurationModel();

        public string[] Ports
        {
            get
            {
                return _ports;
            }
            set
            {
                _ports = value;
                OnPropertyChanged(nameof(Ports));
            }
        }

        public string[] Targets
        {
            get
            {
                return _targets;
            }
            set
            {
                _targets = value;
                OnPropertyChanged(nameof(Targets));
            }
        }

        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
