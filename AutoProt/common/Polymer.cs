using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoProt
{
    public class Polymer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name = "";
        private string _mz0, _mz1, _mz2, _mz3, _mz4;
        private string _z0, _z1, _z2, _z3, _z4;

        public Polymer(string name,
            double mz0, double mz1, double mz2, double mz3, double mz4,
            int z0, int z1, int z2, int z3, int z4)
        {
            this.Name = name;
            this.Mz0 = mz0.ToString();
            this.Mz1 = mz1.ToString();
            this.Mz2 = mz2.ToString();
            this.Mz3 = mz3.ToString();
            this.Mz4 = mz4.ToString();
            this.Z0 = z0.ToString();
            this.Z1 = z1.ToString();
            this.Z2 = z2.ToString();
            this.Z3 = z3.ToString();
            this.Z4 = z4.ToString();
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
        /*
        public double[] MzDouble
        {
            get { return _mz.Select(x => Convert.ToDouble(x)).ToArray(); }
        }
        public int[] ZInt
        {
            get { return _z.Select(x => Convert.ToInt32(x)).ToArray(); }
        }
        */
        
        public string Mz0
        {
            get { return _mz0; }
            set
            {
                if (_mz0 != value)
                {
                    _mz0 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Z0
        {
            get { return _z0; }
            set
            {
                if (_z0 != value)
                {
                    _z0 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mz1
        {
            get { return _mz1; }
            set
            {
                if (_mz1 != value)
                {
                    _mz1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Z1
        {
            get { return _z1; }
            set
            {
                if (_z1 != value)
                {
                    _z1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mz2
        {
            get { return _mz2; }
            set
            {
                if (_mz2 != value)
                {
                    _mz2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Z2
        {
            get { return _z2; }
            set
            {
                if (_z2 != value)
                {
                    _z2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mz3
        {
            get { return _mz3; }
            set
            {
                if (_mz3 != value)
                {
                    _mz3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Z3
        {
            get { return _z3; }
            set
            {
                if (_z3 != value)
                {
                    _z3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mz4
        {
            get { return _mz4; }
            set
            {
                if (_mz4 != value)
                {
                    _mz4 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Z4
        {
            get { return _z4; }
            set
            {
                if (_z4 != value)
                {
                    _z4 = value;
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
