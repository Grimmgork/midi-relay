using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public class ButtonConfigurationModel : INotifyPropertyChanged, ICloneable
    {
        public int Index { get; private set; }

        private bool _enabled;
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged(nameof(Enabled));
                }
            }
        }

        private byte _programNumber;
        public byte ProgramNumber
        {
            get
            {
                return _programNumber;
            }
            set
            {
                if (_programNumber != value)
                {
                    _programNumber = value;
                    OnPropertyChanged(nameof(ProgramNumber));
                }
            }
        }

        public ButtonConfigurationModel(int index)
        {
            Index = index;
        }

        public ButtonConfigurationModel(int index, byte programNumber)
        {
            Index = index;
            Enabled = true;
            ProgramNumber = programNumber;
        }

        public ButtonConfigurationModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return new ButtonConfigurationModel(Index)
            {
                Enabled = _enabled,
                ProgramNumber = _programNumber
            };
        }
    }
}
