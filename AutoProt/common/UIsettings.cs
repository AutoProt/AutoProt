using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Morpheus;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AutoProt
{
    public class UIsettings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _storagefile = "";
        private string _monitorfolder1 = "";
        private string _monitorfolder2 = "";
        private string _monitorfolder3 = "";
        private string _monitorfolder4 = "";
        private string _monitorfolder5 = "";
        private string _fastlocaldrive = "";
        private string _sqlserveradress = "";
        private string _sqldatabase = "";
        private string _sqltable = "";
        private string _sqlusername = "";
        private string _sqlpassword = "";
        private string _mailserveradress = "";
        private string _mailportname = "";
        private string _mailusername = "";
        private string _mailpassword = "";
        private string _codeWorkflowName = "";
        private string _codeName = "";
        private string _rawFileTestName = "";
        private bool _useStorageFile;
        private bool _chkfastlocaldrive;
        private bool _useCodeName;
        private bool _useEmail;
        private bool _useSql;
        private bool _useAdvancedSettings;
        
        private int _selectedCodeNameList;
        private int _selectedWorkflow;
        private int _selectedWorkflowManual;
        private int _selectedWorkflowAutomaticDefault;
        [JsonIgnore]
        public BindingList<RawFileName> rawFiles;
        public BindingList<CodeName> codeNames;
        public BindingList<FileNameCategoryRow> UserList;
        public BindingList<FileNameCategoryRow> SamplesList;
        public BindingList<FileNameCategoryRow> LcList;
        public BindingList<FileNameCategoryRow> MsList;

        [JsonIgnore]
        public Modification[] modificationList1;
        [JsonIgnore]
        public Modification[] modificationList2;

        //cboMorpheus
        [JsonIgnore]
        public Protease[] proteaseList;
        [JsonIgnore]
        public InitiatorMethionineBehavior[] initiatorMethionine;
        [JsonIgnore]
        public MassToleranceUnits[] massToleranceUnitsPrecursor;
        [JsonIgnore]
        public MassToleranceUnits[] massToleranceUnitsProduct;
        [JsonIgnore]
        public MassType[] massTypePrecursor;
        [JsonIgnore]
        public MassType[] massTypeProduct;

        //baseStatusLog
        public BindingList<StatusLogItem> statusLogItems;
        private string _statusLogNewItems = "";
        private int _selectedBaseStatusLog;

        //ResultInterpretation
        public BindingList<InformationKey> informationKey;
        private string[] _resultItems;
        private int _selectedInformationKey;

        // execute program parameters
        public BindingList<ExternalResultParseSetting> ExternalResults { get; private set; }
        private string _executable;
        private string _arguments;
        private int _timeout;
        private bool _asRow = true;
        private bool _useTabExternalTool1;

        public UIsettings()//SettingsForAnalysis analysisSettings)
        {
            //this.analysisSettings = analysisSettings;
            this.informationKey = new BindingList<InformationKey>();
            this.rawFiles = new BindingList<RawFileName>();
            this.codeNames = new BindingList<CodeName>();

            this.UserList = new BindingList<FileNameCategoryRow>();
            this.SamplesList = new BindingList<FileNameCategoryRow>();
            this.LcList = new BindingList<FileNameCategoryRow>();
            this.MsList = new BindingList<FileNameCategoryRow>();

            this.statusLogItems = new BindingList<StatusLogItem>();

            this.ExternalResults = new BindingList<ExternalResultParseSetting>();

            //this.emails = new BindingList<string>();
            //this.proteaseList = new BindingList<Protease>();
            //this.proteaseList.Clear();

            this.initiatorMethionine = (InitiatorMethionineBehavior[]) Enum.GetValues(typeof(InitiatorMethionineBehavior));
            this.massToleranceUnitsPrecursor = (MassToleranceUnits[]) Enum.GetValues(typeof(MassToleranceUnits));
            this.massToleranceUnitsProduct = (MassToleranceUnits[]) Enum.GetValues(typeof(MassToleranceUnits));
            this.massTypePrecursor = (MassType[]) Enum.GetValues(typeof(MassType));
            this.massTypeProduct = (MassType[]) Enum.GetValues(typeof(MassType));
            
            
            ProteaseDictionary proteases = null;
            try
            {
                proteases = ProteaseDictionary.Instance;
                //foreach (Protease protease in proteases.Values)
                //{
                //    proteaseList.Add(protease);
                //}
                proteaseList = proteases.Values.ToArray();
            }
            catch
            {
                //MessageBox.Show("Your proteases file (" + Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "Morpheus\\proteases.tsv") + ") is likely corrupt. Please correct it. Program will now exit.");
                //Application.Exit();
            }

            ModificationDictionary modifications = null;
            
            try
            {
                modifications = ModificationDictionary.Instance;
                this.modificationList1 = new Modification[modifications.Count];
                this.modificationList2 = new Modification[modifications.Count];
                int i = 0;
                foreach (Modification modification in modifications.Values)
                {
                    modificationList1[i] = modification;
                    modificationList2[i] = modification;
                    i++;
                }
            }
            catch
            {
                //MessageBox.Show("Your modifications file (" + Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "modifications.tsv") + ") is likely corrupt. Please correct it.");
            }
            
        }
        [JsonIgnore]
        public string[] ResultNames
        {
            get
            {
                if (_resultItems != null)
                {
                    return (string[])_resultItems.Clone();
                } else
                {
                    return null;
                }
                
            }
            set
            {
                if (_resultItems != value)
                {
                    _resultItems = value;
                    OnPropertyChanged();
                }
            }
        }
        [JsonIgnore]
        public string StatusLogNewItems
        {
            get { return _statusLogNewItems; }
            set
            {
                if (_statusLogNewItems != value)
                {
                    _statusLogNewItems = value;
                    OnPropertyChanged();
                }
            }
        }
        public string[] CompareSymbols
        {
            get
            {
                string[] ComparisonText = new string[5]
                {
                    "<",
                    "<=",
                    "==",
                    ">=",
                    ">"
                };
                return ComparisonText;
            }
        }
        public int SelectedWorkflow
        {
            get { return _selectedWorkflow; }
            set
            {
                if (_selectedWorkflow != value)
                {
                    _selectedWorkflow = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedInformationKey
        {
            get { return _selectedInformationKey; }
            set
            {
                if (_selectedInformationKey != value)
                {
                    _selectedInformationKey = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedWorkflowManual
        {
            get { return _selectedWorkflowManual; }
            set
            {
                if (_selectedWorkflowManual != value)
                {
                    _selectedWorkflowManual = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedBaseStatusLog
        {
            get { return _selectedBaseStatusLog; }
            set
            {
                if (_selectedBaseStatusLog != value)
                {
                    _selectedBaseStatusLog = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedWorkflowAutomaticDefault
        {
            get { return _selectedWorkflowAutomaticDefault; }
            set
            {
                if (_selectedWorkflowAutomaticDefault != value)
                {
                    _selectedWorkflowAutomaticDefault = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedCodeNameList
        {
            get { return _selectedCodeNameList; }
            set
            {
                if (_selectedCodeNameList != value)
                {
                    _selectedCodeNameList = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Storagefile
        {
            get { return _storagefile; }
            set
            {
                if (_storagefile != value)
                {
                    _storagefile = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Monitorfolder1
        {
            get { return _monitorfolder1; }
            set
            {
                if (_monitorfolder1 != value)
                {
                    _monitorfolder1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Monitorfolder2
        {
            get { return _monitorfolder2; }
            set
            {
                if (_monitorfolder2 != value)
                {
                    _monitorfolder2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Monitorfolder3
        {
            get { return _monitorfolder3; }
            set
            {
                if (_monitorfolder3 != value)
                {
                    _monitorfolder3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Monitorfolder4
        {
            get { return _monitorfolder4; }
            set
            {
                if (_monitorfolder4 != value)
                {
                    _monitorfolder4 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Monitorfolder5
        {
            get { return _monitorfolder5; }
            set
            {
                if (_monitorfolder5 != value)
                {
                    _monitorfolder5 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Fastlocaldrive
        {
            get { return _fastlocaldrive; }
            set
            {
                if (_fastlocaldrive != value)
                {
                    _fastlocaldrive = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Sqlserveradress
        {
            get { return _sqlserveradress; }
            set
            {
                if (_sqlserveradress != value)
                {
                    _sqlserveradress = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Sqldatabase
        {
            get { return _sqldatabase; }
            set
            {
                if (_sqldatabase != value)
                {
                    _sqldatabase = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Sqltable
        {
            get { return _sqltable; }
            set
            {
                if (_sqltable != value)
                {
                    _sqltable = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Sqlusername
        {
            get { return _sqlusername; }
            set
            {
                if (_sqlusername != value)
                {
                    _sqlusername = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Sqlpassword
        {
            get { return _sqlpassword; }
            set
            {
                if (_sqlpassword != value)
                {
                    _sqlpassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CodePattern
        {
            get { return _codeName; }
            set
            {
                if (_codeName != value)
                {
                    _codeName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CodeWorkflowName
        {
            get { return _codeWorkflowName; }
            set
            {
                if (_codeWorkflowName != value)
                {
                    _codeWorkflowName = value;
                    OnPropertyChanged();
                }
            }
        }
        [JsonIgnore]
        public string RawFileTestName
        {
            get { return _rawFileTestName; }
            set
            {
                if (_rawFileTestName != value)
                {
                    _rawFileTestName = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool UseStorageFile
        {
            get { return _useStorageFile; }
            set
            {
                if (_useStorageFile != value)
                {
                    _useStorageFile = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Chkfastlocaldrive
        {
            get { return _chkfastlocaldrive; }
            set
            {
                if (_chkfastlocaldrive != value)
                {
                    _chkfastlocaldrive = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseCodeName
        {
            get { return _useCodeName; }
            set
            {
                if (_useCodeName != value)
                {
                    _useCodeName = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseEmail
        {
            get { return _useEmail; }
            set
            {
                if (_useEmail != value)
                {
                    _useEmail = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseSql
        {
            get { return _useSql; }
            set
            {
                if (_useSql != value)
                {
                    _useSql = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mailserveradress
        {
            get { return _mailserveradress; }
            set
            {
                if (_mailserveradress != value)
                {
                    _mailserveradress = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mailportname
        {
            get { return _mailportname; }
            set
            {
                if (_mailportname != value)
                {
                    _mailportname = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mailusername
        {
            get { return _mailusername; }
            set
            {
                if (_mailusername != value)
                {
                    _mailusername = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mailpassword
        {
            get { return _mailpassword; }
            set
            {
                if (_mailpassword != value)
                {
                    _mailpassword = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Executable
        {
            get { return _executable; }
            set
            {
                if (_executable != value)
                {
                    _executable = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Arguments
        {
            get { return _arguments; }
            set
            {
                if (_arguments != value)
                {
                    _arguments = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Timeout
        {
            get { return _timeout; }
            set
            {
                if (_timeout != value)
                {
                    _timeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool AsRow
        {
            get { return _asRow; }
            set
            {
                if (_asRow != value)
                {
                    _asRow = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseAdvancedSettings
        {
            get { return _useAdvancedSettings; }
            set
            {
                if (_useAdvancedSettings != value)
                {
                    _useAdvancedSettings = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseTabExternalTool1
        {
            get { return _useTabExternalTool1; }
            set
            {
                if (_useTabExternalTool1 != value)
                {
                    _useTabExternalTool1 = value;
                    OnPropertyChanged();
                }
            }
        }
        //should probably use enum instead
        public char ExternalToolSepChar
        {
            get
            {
                if (_useTabExternalTool1)
                {
                    return '\t';
                }
                else
                {
                    return ';';
                }
            }
        }


        public UIsettings Clone()
        {
            return JsonConvert.DeserializeObject<UIsettings>(JsonConvert.SerializeObject(this));
        }
        
        private void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }

}
