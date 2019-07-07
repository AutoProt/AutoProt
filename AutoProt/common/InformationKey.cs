using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoProt
{
    public class InformationKey : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name = "New Name";

        
        private int _resultItemIndex1 = 0;
        private int _resultItemIndex2 = 0;
        private int _resultItemIndex3 = 0;
        private int _resultItemIndex4 = 0;
        private int _resultItemIndex5 = 0;

        private int _comparisonIndex1 = 0;
        private int _comparisonIndex2 = 0;
        private int _comparisonIndex3 = 0;
        private int _comparisonIndex4 = 0;
        private int _comparisonIndex5 = 0;

        private string _comparisonText1 = "";
        private string _comparisonText2 = "";
        private string _comparisonText3 = "";
        private string _comparisonText4 = "";
        private string _comparisonText5 = "";

        private string _message = "";

        public InformationKey()
        {
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
        public int ResultItemIndex1
        {
            get { return _resultItemIndex1; }
            set
            {
                if (_resultItemIndex1 != value)
                {
                    _resultItemIndex1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ResultItemIndex2
        {
            get { return _resultItemIndex2; }
            set
            {
                if (_resultItemIndex2 != value)
                {
                    _resultItemIndex2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ResultItemIndex3
        {
            get { return _resultItemIndex3; }
            set
            {
                if (_resultItemIndex3 != value)
                {
                    _resultItemIndex3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ResultItemIndex4
        {
            get { return _resultItemIndex4; }
            set
            {
                if (_resultItemIndex4 != value)
                {
                    _resultItemIndex4 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ResultItemIndex5
        {
            get { return _resultItemIndex5; }
            set
            {
                if (_resultItemIndex5 != value)
                {
                    _resultItemIndex5 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ComparisonIndex1
        {
            get { return _comparisonIndex1; }
            set
            {
                if (_comparisonIndex1 != value)
                {
                    _comparisonIndex1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ComparisonIndex2
        {
            get { return _comparisonIndex2; }
            set
            {
                if (_comparisonIndex2 != value)
                {
                    _comparisonIndex2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ComparisonIndex3
        {
            get { return _comparisonIndex3; }
            set
            {
                if (_comparisonIndex3 != value)
                {
                    _comparisonIndex3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ComparisonIndex4
        {
            get { return _comparisonIndex4; }
            set
            {
                if (_comparisonIndex4 != value)
                {
                    _comparisonIndex4 = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ComparisonIndex5
        {
            get { return _comparisonIndex5; }
            set
            {
                if (_comparisonIndex5 != value)
                {
                    _comparisonIndex5 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ComparisonText1
        {
            get { return _comparisonText1; }
            set
            {
                if (_comparisonText1 != value)
                {
                    _comparisonText1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ComparisonText2
        {
            get { return _comparisonText2; }
            set
            {
                if (_comparisonText2 != value)
                {
                    _comparisonText2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ComparisonText3
        {
            get { return _comparisonText3; }
            set
            {
                if (_comparisonText3 != value)
                {
                    _comparisonText3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ComparisonText4
        {
            get { return _comparisonText4; }
            set
            {
                if (_comparisonText4 != value)
                {
                    _comparisonText4 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ComparisonText5
        {
            get { return _comparisonText5; }
            set
            {
                if (_comparisonText5 != value)
                {
                    _comparisonText5 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
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
