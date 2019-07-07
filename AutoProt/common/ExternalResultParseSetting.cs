using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoProt
{
    public class ExternalResultParseSetting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _resultfile;
        private string _resultname;
        private string _displayname;

        public ExternalResultParseSetting(string resultfile, string name)
        {
            this._resultfile = resultfile;
            this._resultname = name;
            Displayname = _resultfile + " => " + _resultname;
        }

        public string ResultFile
        {
            get { return _resultfile; }
            set
            {
                if (_resultfile != value)
                {
                    _resultfile = value;
                    Displayname = _resultfile + " => " + _resultname;
                    OnPropertyChanged();
                }
            }
        }

        public string Displayname
        {
            get { return _displayname; }
            set
            {
                if (_displayname != value)
                {
                    _displayname = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Resultname
        {
            get { return _resultname; }
            set
            {
                if (_resultname != value)
                {
                    _resultname = value;
                    Displayname = _resultfile + " => " + _resultname;
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
