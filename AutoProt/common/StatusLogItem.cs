using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoProt
{
    public class StatusLogItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private bool _calculateMin, _calculateMax, _calculateMedian, _calculateIQR;

        public StatusLogItem(string name)
        {
            _name = name;
        }
        

        public string Name
        {
            get { return _name; }
        }
        public bool CalculateMin
        {
            get { return _calculateMin; }
            set
            {
                if (_calculateMin != value)
                {
                    _calculateMin = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool CalculateMax
        {
            get { return _calculateMax; }
            set
            {
                if (_calculateMax != value)
                {
                    _calculateMax = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool CalculateMedian
        {
            get { return _calculateMedian; }
            set
            {
                if (_calculateMedian != value)
                {
                    _calculateMedian = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool CalculateIQR
        {
            get { return _calculateIQR; }
            set
            {
                if (_calculateIQR != value)
                {
                    _calculateIQR = value;
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
