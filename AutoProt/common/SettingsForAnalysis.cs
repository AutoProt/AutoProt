using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morpheus;
using System.Windows.Forms;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.IO;
using System.Globalization;

namespace AutoProt
{
    public class SettingsForAnalysis : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Modification> fixedModifications { get; private set; }
        public List<Modification> variableModifications { get; private set; }
        private int _protease = 12;
        private int _initiatorMethionineBehavior = 2;
        private int _precursorMassToleranceUnitsIndex=1;//ppm or Da
        private int _productMassToleranceUnitsIndex=1;
        private int _precursorMassTypeIndex=0;//monoisotopic etc
        private int _productMassTypeIndex=0;

        private string _name;

        private int _minimumAssumedPrecursorChargeState = 2;
        private int _maximumAssumedPrecursorChargeState = 4;
        private bool _chkAbsoluteThreshold;
        private string _txtAbsoluteThreshold = "10";
        private bool _chkRelativeThreshold;
        private string _txtRelativeThreshold = "1";
        private bool _chkMaxNumPeaks = true;
        private int _maximumNumberOfPeaks = 400;
        private bool _assignChargeStates = true;
        private bool _deisotope;
        private string _proteomeDatabaseFilepath = "";
        private bool _onTheFlyDecoys = true;
        private int _maximumMissedCleavages = 2;
        private int _maximumVariableModificationIsoforms = 1024;
        private bool _precursorMonoisotopicPeakCorrection;
        private int _minimumPrecursorMonoisotopicPeakOffset = -3;
        private int _maximumPrecursorMonoisotopicPeakOffset = 1;
        private double _maximumFalseDiscoveryRatePercent = 1.0;
        private bool _considerModifiedFormsAsUniquePeptides;
        private int _maximumThreads = Environment.ProcessorCount;
        private bool _minimizeMemoryUsage;
        private double _precursorMassToleranceValue = 5.0;
        private double _productMassToleranceValue = 10.0;
        [JsonIgnore]
        private readonly Protease[] _proteases;

        // booleans to trigger analysis
        private bool _useMorpheusAnalysis = true;
        private bool _useBaseAnalysis = true;
        private bool _useExternal1Analysis = true;

        // base program parameters
        public List<Adduct> Adducts { get; private set; }
        public List<Polymer> Polymers { get; private set; }
        private double _snthreshold = 5.0;
        private double _ionThreshold = 50000.0;
        private double _baseMassTolerance = 5.0;
        private double _baseAdductPercentile = 80;
        private double _basePolymerPercentile = 99;
        private double _fluctuations = 0.2;

        
        // Status log stuff
        

        public SettingsForAnalysis(string name)
        {
            this.Name = name;
            this.fixedModifications = new List<Modification>();
            this.variableModifications = new List<Modification>();
            

            this.Adducts = new List<Adduct>();
            this.Polymers = new List<Polymer>();

            ProteaseDictionary proteases = null;
            try
            {
                proteases = ProteaseDictionary.Instance;
                _proteases = proteases.Values.ToArray();
            }
            catch
            {
                //MessageBox.Show("Your proteases file (" + Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "Morpheus\\proteases.tsv") + ") is likely corrupt. Please correct it. Program will now exit.");
                //Application.Exit();
            }

        }
        public void ResetAdducts()
        {
            List<Adduct> defaults = new List<Adduct>();
            defaults.Add(new Adduct("AdductNH3", 17.026549, true));
            defaults.Add(new Adduct("AdductNa", 21.981943, true));
            defaults.Add(new Adduct("AdductFA", 32.026213, true));
            defaults.Add(new Adduct("AdductCa", 37.946941, true));
            defaults.Add(new Adduct("AdductK", 37.955882, true));
            defaults.Add(new Adduct("AdductACN", 41.026547, true));
            defaults.Add(new Adduct("AdductFe", 52.911464, true));
            defaults.Add(new Adduct("Adduct1", 0.0, false, false));
            defaults.Add(new Adduct("Adduct2", 0.0, false, false));
            defaults.Add(new Adduct("Adduct3", 0.0, false, false));
            Adducts = defaults;
            OnPropertyChanged("Adducts");
        }
        public void ResetPolymers()
        {
            List<Polymer> defaults = new List<Polymer>();
            defaults.Add(new Polymer("Polymer1", 327.20135, 371.227565, 459.279995, 591.35864, 767.4635, 1, 1, 1, 1, 1 ));
            defaults.Add(new Polymer("Polymer2", 309.24242, 353.268635, 441.321065, 573.39971, 749.50457, 1, 1, 1, 1, 1 ));
            defaults.Add(new Polymer("Polymer3", 339.25299, 383.279205, 471.331635, 603.41028, 779.51514, 1, 1, 1, 1, 1 ));
            defaults.Add(new Polymer("Polymer4", 381.29753, 425.323745, 513.376175, 645.45482, 821.55968, 1, 1, 1, 1, 1 ));
            defaults.Add(new Polymer("Polymer5", 367.28188, 411.308095, 499.360525, 631.43917, 807.54403, 1, 1, 1, 1, 1 ));
            Polymers = defaults;
            OnPropertyChanged("Polymers");
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

        public override string ToString()
        {
            return _name;
        }

        public Protease CurrentProtease
        {
            get { return _proteases[protease]; }
        }

        public int protease
        {
            get { return _protease; }
            set
            {
                if (_protease != value)
                {
                    _protease = value;
                    OnPropertyChanged();
                }
            }
        }
        public int initiatorMethionineBehavior
        {
            get { return _initiatorMethionineBehavior; }
            set
            {
                if (_initiatorMethionineBehavior != value)
                {
                    _initiatorMethionineBehavior = value;
                    OnPropertyChanged();
                }
            }
        }

        public InitiatorMethionineBehavior initiatorMethionine
        {
            get { return (InitiatorMethionineBehavior) _initiatorMethionineBehavior; }
        }
        public int precursorMassToleranceUnitsIndex
        {
            get { return _precursorMassToleranceUnitsIndex; }
            set
            {
                if (_precursorMassToleranceUnitsIndex != value)
                {
                    _precursorMassToleranceUnitsIndex = value;
                    OnPropertyChanged();
                }
            }
        }
        public int productMassToleranceUnitsIndex
        {
            get { return _productMassToleranceUnitsIndex; }
            set
            {
                if (_productMassToleranceUnitsIndex != value)
                {
                    _productMassToleranceUnitsIndex = value;
                    OnPropertyChanged();
                }
            }
        }
        public int precursorMassTypeIndex
        {
            get { return _precursorMassTypeIndex; }
            set
            {
                if (_precursorMassTypeIndex != value)
                {
                    _precursorMassTypeIndex = value;
                    OnPropertyChanged();
                }
            }
        }
        public int productMassTypeIndex
        {
            get { return _productMassTypeIndex; }
            set
            {
                if (_productMassTypeIndex != value)
                {
                    _productMassTypeIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public int minimumAssumedPrecursorChargeState
        {
            get { return _minimumAssumedPrecursorChargeState; }
            set
            {
                if (_minimumAssumedPrecursorChargeState != value)
                {
                    _minimumAssumedPrecursorChargeState = value;
                    OnPropertyChanged();
                }
            }
        }
        public int maximumAssumedPrecursorChargeState
        {
            get { return _maximumAssumedPrecursorChargeState; }
            set
            {
                if (_maximumAssumedPrecursorChargeState != value)
                {
                    _maximumAssumedPrecursorChargeState = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool chkAbsoluteThreshold
        {
            get { return _chkAbsoluteThreshold; }
            set
            {
                if (_chkAbsoluteThreshold != value)
                {
                    _chkAbsoluteThreshold = value;
                    OnPropertyChanged();
                }
            }
        }
        public string txtAbsoluteThreshold
        {
            get { return _txtAbsoluteThreshold; }
            set
            {
                if (_txtAbsoluteThreshold != value)
                {
                    _txtAbsoluteThreshold = value;
                    OnPropertyChanged();
                }
            }
        }
        public double absoluteThreshold
        {
            get { return Convert.ToDouble(_txtAbsoluteThreshold); }
        }
        public bool chkRelativeThreshold
        {
            get { return _chkRelativeThreshold; }
            set
            {
                if (_chkRelativeThreshold != value)
                {
                    _chkRelativeThreshold = value;
                    OnPropertyChanged();
                }
            }
        }
        public string txtRelativeThreshold
        {
            get { return _txtRelativeThreshold; }
            set
            {
                if (_txtRelativeThreshold != value)
                {
                    _txtRelativeThreshold = value;
                    OnPropertyChanged();
                }
            }
        }

        public double relativeThresholdPercent
        {
            get { return Convert.ToDouble(_txtRelativeThreshold); }
        }
        public bool chkMaxNumPeaks
        {
            get { return _chkMaxNumPeaks; }
            set
            {
                if (_chkMaxNumPeaks != value)
                {
                    _chkMaxNumPeaks = value;
                    OnPropertyChanged();
                }
            }
        }
        public int maximumNumberOfPeaks
        {
            get { return _maximumNumberOfPeaks; }
            set
            {
                if (_maximumNumberOfPeaks != value)
                {
                    _maximumNumberOfPeaks = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool assignChargeStates
        {
            get { return _assignChargeStates; }
            set
            {
                if (_assignChargeStates != value)
                {
                    _assignChargeStates = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool deisotope
        {
            get { return _deisotope; }
            set
            {
                if (_deisotope != value)
                {
                    _deisotope = value;
                    OnPropertyChanged();
                }
            }
        }
        public string proteomeDatabaseFilepath
        {
            get { return _proteomeDatabaseFilepath; }
            set
            {
                if (_proteomeDatabaseFilepath != value)
                {
                    _proteomeDatabaseFilepath = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool onTheFlyDecoys
        {
            get { return _onTheFlyDecoys; }
            set
            {
                if (_onTheFlyDecoys != value)
                {
                    _onTheFlyDecoys = value;
                    OnPropertyChanged();
                }
            }
        }
        public int maximumMissedCleavages
        {
            get { return _maximumMissedCleavages; }
            set
            {
                if (_maximumMissedCleavages != value)
                {
                    _maximumMissedCleavages = value;
                    OnPropertyChanged();
                }
            }
        }
        public int maximumVariableModificationIsoforms
        {
            get { return _maximumVariableModificationIsoforms; }
            set
            {
                if (_maximumVariableModificationIsoforms != value)
                {
                    _maximumVariableModificationIsoforms = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool precursorMonoisotopicPeakCorrection
        {
            get { return _precursorMonoisotopicPeakCorrection; }
            set
            {
                if (_precursorMonoisotopicPeakCorrection != value)
                {
                    _precursorMonoisotopicPeakCorrection = value;
                    OnPropertyChanged();
                }
            }
        }
        public int minimumPrecursorMonoisotopicPeakOffset
        {
            get { return _minimumPrecursorMonoisotopicPeakOffset; }
            set
            {
                if (_minimumPrecursorMonoisotopicPeakOffset != value)
                {
                    _minimumPrecursorMonoisotopicPeakOffset = value;
                    OnPropertyChanged();
                }
            }
        }
        public int maximumPrecursorMonoisotopicPeakOffset
        {
            get { return _maximumPrecursorMonoisotopicPeakOffset; }
            set
            {
                if (_maximumPrecursorMonoisotopicPeakOffset != value)
                {
                    _maximumPrecursorMonoisotopicPeakOffset = value;
                    OnPropertyChanged();
                }
            }
        }
        public double maximumFalseDiscoveryRatePercent
        {
            get { return _maximumFalseDiscoveryRatePercent; }
            set
            {
                if (_maximumFalseDiscoveryRatePercent != value)
                {
                    _maximumFalseDiscoveryRatePercent = value;
                    OnPropertyChanged();
                }
            }
        }
        public double baseMaxFluctuationsPercent
        {
            get { return _fluctuations; }
            set
            {
                if (_fluctuations != value)
                {
                    _fluctuations = value;
                    OnPropertyChanged();
                }
            }
        }

        

        public double maximumFalseDiscoveryRate
        {
            get { return Convert.ToDouble(_maximumFalseDiscoveryRatePercent/100); }
        }
        public bool considerModifiedFormsAsUniquePeptides
        {
            get { return _considerModifiedFormsAsUniquePeptides; }
            set
            {
                if (_considerModifiedFormsAsUniquePeptides != value)
                {
                    _considerModifiedFormsAsUniquePeptides = value;
                    OnPropertyChanged();
                }
            }
        }
        public int maximumThreads
        {
            get { return _maximumThreads; }
            set
            {
                if (_maximumThreads != value)
                {
                    _maximumThreads = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool minimizeMemoryUsage
        {
            get { return _minimizeMemoryUsage; }
            set
            {
                if (_minimizeMemoryUsage != value)
                {
                    _minimizeMemoryUsage = value;
                    OnPropertyChanged();
                }
            }
        }

        public double precursorMassToleranceValue
        {
            get { return _precursorMassToleranceValue; }
            set
            {
                if (_precursorMassToleranceValue != value)
                {
                    _precursorMassToleranceValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public double StoNthreshold
        {
            get { return _snthreshold; }
            set
            {
                if (_snthreshold != value)
                {
                    _snthreshold = value;
                    OnPropertyChanged();
                }
            }
        }
        public double IonThreshold
        {
            get { return _ionThreshold; }
            set
            {
                if (_ionThreshold != value)
                {
                    _ionThreshold = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseMorpheusAnalysis
        {
            get { return _useMorpheusAnalysis; }
            set
            {
                if (_useMorpheusAnalysis != value)
                {
                    _useMorpheusAnalysis = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseBaseAnalysis
        {
            get { return _useBaseAnalysis; }
            set
            {
                if (_useBaseAnalysis != value)
                {
                    _useBaseAnalysis = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool UseExternal1Analysis
        {
            get { return _useExternal1Analysis; }
            set
            {
                if (_useExternal1Analysis != value)
                {
                    _useExternal1Analysis = value;
                    OnPropertyChanged();
                }
            }
        }

        public MassTolerance precursorMassTolerance
        {
            get { return new MassTolerance(_precursorMassToleranceValue, (MassToleranceUnits)precursorMassToleranceUnitsIndex); }
        }
        public MassType precursorMassType
        {
            get { return (MassType) precursorMassTypeIndex; }
        }
        public double productMassToleranceValue
        {
            get { return _productMassToleranceValue; }
            set
            {
                if (_productMassToleranceValue != value)
                {
                    _productMassToleranceValue = value;
                    OnPropertyChanged();
                }
            }
        }
        public MassTolerance productMassTolerance
        {
            get { return new MassTolerance(_productMassToleranceValue, (MassToleranceUnits)productMassToleranceUnitsIndex); }
        }
        //public MassTolerance productMassTolerance;//should just be a return value from function
        public MassType productMassType
        {
            get { return (MassType)productMassTypeIndex; }
        }
        
        public double BaseMassTolerance
        {
            get { return _baseMassTolerance; }
            set
            {
                if (_baseMassTolerance != value)
                {
                    _baseMassTolerance = value;
                    OnPropertyChanged();
                }
            }
        }
        public double BasePolymerPercentile
        {
            get { return _basePolymerPercentile; }
            set
            {
                if (_basePolymerPercentile != value)
                {
                    _basePolymerPercentile = value;
                    OnPropertyChanged();
                }
            }
        }
        public double BaseAdductPercentile
        {
            get { return _baseAdductPercentile; }
            set
            {
                if (_baseAdductPercentile != value)
                {
                    _baseAdductPercentile = value;
                    OnPropertyChanged();
                }
            }
        }

        public SettingsForAnalysis Clone()
        {
            return JsonConvert.DeserializeObject<SettingsForAnalysis>(JsonConvert.SerializeObject(this));
        }

        private void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public string GetHash()
        {
            return CreateMD5(JsonConvert.SerializeObject(this));
        }
        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

    }
}