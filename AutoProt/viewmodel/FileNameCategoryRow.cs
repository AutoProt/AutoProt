using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoProt
{
    public class FileNameCategoryRow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _level1 = "";
        private string _level2 = "";
        private string _regex = "";
        private string _ccemail = "";

        public string Level1 { get => _level1; set { _level1 = value; OnPropertyChanged(); } }
        public string Level2 { get => _level2; set { _level2 = value; OnPropertyChanged(); } }
        public string CCemail { get => _ccemail; set { _ccemail = value; OnPropertyChanged(); } }
        public string Pattern { get => _regex; set { _regex = value; OnPropertyChanged(); } }

        public FileNameCategoryRow()
        {
        }
        private void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
        public bool TrySet(string tabsep)
        {
            bool success = false;
            string[] splitString = tabsep.Split('\t');
            if (splitString.Length == 4)
            {
                _level1 = splitString[0];
                _level2 = splitString[1];
                _ccemail = splitString[2];
                _regex = splitString[3];
                success = true;
            }
            return success;
        }
    }
}
