using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoProt
{
    public class Adduct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _mass;
        private bool _readonly;
        private bool _enabled;

        public Adduct(string name, double mz, bool enabled = true, bool readOnly = true)
        {
            this.Name = name;
            this.Mass = mz.ToString();
            this._readonly = readOnly;
            this._enabled = enabled;
        }
        
        public bool ReadOnly
        {
            get { return _readonly; }
            set
            {
                if (_readonly != value)
                {
                    _readonly = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public double MzValue
        {
            get { return Convert.ToDouble(_mass); }
        }
        public string Mass
        {
            get { return _mass; }
            set
            {
                if (_mass != value)
                {
                    _mass = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
        
    }
}
