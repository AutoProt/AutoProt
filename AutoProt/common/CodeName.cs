using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace AutoProt
{
    public class CodeName : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _pattern;
        private string _workflowName;
        private string _name;


        public CodeName(string patternRegularExpression,string workflowName)
        {
            this._pattern = patternRegularExpression;
            WorkflowName = workflowName;
        }
        private Regex RegularExpression { get { return new Regex(this.Pattern); } }

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                if (_pattern != value)
                {
                    _pattern = value;
                    OnPropertyChanged();
                    Name = _pattern + " => " + _workflowName;
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
        public string WorkflowName
        {
            get { return _workflowName; }
            set
            {
                if (_workflowName != value)
                {
                    _workflowName = value;
                    OnPropertyChanged();
                    Name = _pattern + " => " + _workflowName;
                }
            }
        }

        public bool IsMatch(string filename)
        {
            return RegularExpression.IsMatch(filename);
        }


     
        private void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}