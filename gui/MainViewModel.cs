using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gui.Midi;

namespace gui
{
    public enum ApplicationState
    {
        Done,
        Busy,
        Error
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private string? _selectedPort;
        private DeviceConfigurationModel _config = new DeviceConfigurationModel();
        private ApplicationState _state;
        private string? _errorMessage;
        private string[] _ports = new string[] { };
        private ButtonConfigurationModel? _selectedButton;

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
                return _config;
            }
            set
            {
                _config = value;
                OnPropertyChanged(nameof(Device));
            }
        }
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


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
