using System.Collections.ObjectModel;
using System.ComponentModel;

namespace gui.Model
{
    public class DeviceConfigurationModel : INotifyPropertyChanged, ICloneable
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

        private ButtonConfigurationModel[] _buttons = new ButtonConfigurationModel[] { };
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

        public object Clone()
        {
            ButtonConfigurationModel[] buttons = new ButtonConfigurationModel[_buttons.Length];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = (ButtonConfigurationModel)_buttons[i].Clone();
            }

            return new DeviceConfigurationModel()
            {
                ControlChannel = _controlChannel,
                Buttons = buttons
            };
        }
    }
}
