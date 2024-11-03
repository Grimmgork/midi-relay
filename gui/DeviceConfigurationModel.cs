using System.ComponentModel;

namespace gui
{
    public class DeviceConfigurationModel : INotifyPropertyChanged
    {
        private byte _controlChannel = 0;
        public byte ControlChannel
        {
            get
            {
                return _controlChannel;
            }
            set
            {
                _controlChannel = value;
                OnPropertyChanged(nameof(ControlChannel));
            }
        }

        private ButtonConfigurationModel[] _buttons = new ButtonConfigurationModel[] {};
        public ButtonConfigurationModel[] Buttons
        {
            get
            {
                return _buttons;
            }
            set
            {
                _buttons = value;
                OnPropertyChanged(nameof(Buttons));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
