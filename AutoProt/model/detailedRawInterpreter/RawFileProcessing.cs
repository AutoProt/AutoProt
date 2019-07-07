using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using MSFileReaderLib;
using System.IO;
using MathNet.Numerics.Statistics;
using System.Diagnostics;
using Serilog;

namespace AutoProt
{
    public class RawFileProcessing : IDisposable
    {
        public int MsCount { get; private set; }
        public int Ms2Count { get; private set; }
        public double MsTic { get; private set; }
        public double MsTicHigh { get; private set; }
        public double Ms2Tic { get; private set; }
        public double MsS2N { get; private set; }
        public double Ms2S2N { get; private set; }
        public double MsIonCount { get; private set; }
        public double Ms2IonCount { get; private set; }
        public double LargeFluctuations { get; private set; }
        public double Polymer1 { get; private set; }
        public double Polymer2 { get; private set; }
        public double Polymer3 { get; private set; }
        public double Polymer4 { get; private set; }
        public double Polymer5 { get; private set; }
        public double AdductNa { get; private set; }
        public double AdductCa { get; private set; }
        public double AdductFe { get; private set; }
        public double AdductK { get; private set; }
        public double AdductFA { get; private set; }
        public double AdductNH3 { get; private set; }
        public double AdductACN { get; private set; }
        public double PrecursorMass5percent { get; private set; }
        public double PrecursorMass95percent { get; private set; }
        public double TopN { get; private set; }
        public double Ms2IsolationWindowTic { get; private set; }
        public double Ms2IsolationWindowTicRelative { get; private set; }
        public int Ms2ScansAboveIonThreshold { get; private set; }
        public double Ms2ScansAboveIonThresholdPercent { get; private set; }
        public double Ms2ScansAbovePrecursorPercent { get; private set; }
        public double Ms2ScansWithPrecursorBasePeakPercent { get; private set; }
        public double Ms2charge2 { get; private set; }
        public double Ms2charge3 { get; private set; }
        public double Ms2charge4orMore { get; private set; }

        public double CtcdMax, CtcdMin, LockMassCorrectionMaxAbsolute;
        
        private bool disposed = false;
        public DateTime _msStart = new DateTime();
        public DateTime _msEnd = new DateTime();
        public DateTime _filecreation = new DateTime();
        private List<MsScan> msScanList = new List<MsScan>();
        private List<Ms2Scan> ms2ScanList = new List<Ms2Scan>();
        public StatusLog statusLog = new StatusLog();
        public string WarningMessage = "";

        public RawFileProcessing(IXRawfile5 raw, string rawFileName, SettingsForAnalysis settingName)
        {
            //open rawfile (add error check)
            raw.Open(rawFileName);
            raw.SetCurrentController(0, 1);
            raw.GetCreationDate(ref _msStart);
            double endtime = 0.0;
            raw.GetEndTime(ref endtime);
            _msEnd = _msStart.AddMinutes(endtime);
            _filecreation = File.GetCreationTime(rawFileName);
            raw.GetWarningMessage(ref WarningMessage);

            ProcessScans(raw, settingName);

            raw.Close();
            ReduceToMetaVariables(settingName);
        }

        private void ReduceToMetaVariables(SettingsForAnalysis settingName)
        {
            this.MsCount = msScanList.Count;
            List<double> msticlist = msScanList.Select(x => x.Tic).ToList();
            this.MsTic = Statistics.Median(msticlist);
            this.MsTicHigh = Statistics.Percentile(msticlist, 90);
            this.MsS2N = Statistics.Median(msScanList.Select(x => x.SignalToNoise));
            this.MsIonCount = Statistics.Median(msScanList.Select(x => x.IonCountFromRawOvFtT));
            this.LargeFluctuations = GetLargeInjectionTimeShifts(msScanList, settingName.baseMaxFluctuationsPercent / 100);//read from settings
            this.Polymer1 = Statistics.Percentile(msScanList.Select(x => x.Polymer[0]), 99) / 1000000.0;
            this.Polymer2 = Statistics.Percentile(msScanList.Select(x => x.Polymer[1]), 99) / 1000000.0;
            this.Polymer3 = Statistics.Percentile(msScanList.Select(x => x.Polymer[2]), 99) / 1000000.0;
            this.Polymer4 = Statistics.Percentile(msScanList.Select(x => x.Polymer[3]), 99) / 1000000.0;
            this.Polymer5 = Statistics.Percentile(msScanList.Select(x => x.Polymer[4]), 99) / 1000000.0;
            this.AdductNa = Statistics.Percentile(msScanList.Select(x => x.Adduct[1]), 80);
            this.AdductCa = Statistics.Percentile(msScanList.Select(x => x.Adduct[3]), 80);
            this.AdductFe = Statistics.Percentile(msScanList.Select(x => x.Adduct[6]), 80);
            this.AdductK = Statistics.Percentile(msScanList.Select(x => x.Adduct[4]), 80);
            this.AdductFA = Statistics.Percentile(msScanList.Select(x => x.Adduct[2]), 80);
            this.AdductNH3 = Statistics.Percentile(msScanList.Select(x => x.Adduct[0]), 80);
            this.AdductACN = Statistics.Percentile(msScanList.Select(x => x.Adduct[5]), 80);
            this.TopN = msScanList.Select(x => x.ScanNumber).Zip(msScanList.Select(x => x.ScanNumber).Skip(1), (x, y) => y - x).Average();
            this.Ms2Count = ms2ScanList.Count;
            this.Ms2Tic = Statistics.Median(ms2ScanList.Select(x => x.Tic));
            this.Ms2S2N = Statistics.Median(ms2ScanList.Select(x => x.SignalToNoise));
            this.Ms2IonCount = Statistics.Median(ms2ScanList.Select(x => x.IonCountFromRawOvFtT));
            this.Ms2IsolationWindowTic = Statistics.Median(ms2ScanList.Select(x => x.IsolationWindowTic));
            this.Ms2IsolationWindowTicRelative = Statistics.Median(ms2ScanList.Select(x => x.IsolationWindowTicRelative));
            this.Ms2ScansAboveIonThreshold = GetNoMS2scansAboveIonThreshold(ms2ScanList, settingName.IonThreshold);
            Tuple<double,double,double> ms2charges = GetMS2PrecursorChargeStateDistribution(ms2ScanList);
            this.Ms2charge2 = ms2charges.Item1;
            this.Ms2charge3 = ms2charges.Item2;
            this.Ms2charge4orMore = ms2charges.Item3;
            this.Ms2ScansAbovePrecursorPercent = ms2ScanList.Select(x => x.Ms2XicAboveThreshold).Average();
            this.Ms2ScansAboveIonThresholdPercent = Ms2ScansAboveIonThreshold / Convert.ToDouble(ms2ScanList.Count) * 100.0;
            this.Ms2ScansWithPrecursorBasePeakPercent = ms2ScanList.Select(x => x.IsPrecursorBasePeak).Sum() * 100.0 / Convert.ToDouble(ms2ScanList.Count);

            this.PrecursorMass5percent = Statistics.Percentile(ms2ScanList.Select(x => x.PrecursorMass), 5);
            this.PrecursorMass95percent = Statistics.Percentile(ms2ScanList.Select(x => x.PrecursorMass), 95);
            
            this.CtcdMin = msScanList.Select(x => x.Ctcd).Min();
            this.CtcdMax = msScanList.Select(x => x.Ctcd).Max();
            this.LockMassCorrectionMaxAbsolute = msScanList.Select(x => x.LockMassCorr).MaximumAbsolute();

        }
        /// <summary>
        /// Read and parse all spectra, spawns a task.
        /// </summary>
        /// <param name="raw">Raw file</param>
        /// <param name="msScanParameters">Parameters</param>
        private void ProcessScans(IXRawfile5 raw, SettingsForAnalysis msScanParameters)
        {
            BlockingCollection<RawScan> rawScanQueue = new BlockingCollection<RawScan>();
            List<Task<Tuple<List<MsScan>, List<Ms2Scan>>>> parseTaskList = new List<Task<Tuple<List<MsScan>, List<Ms2Scan>>>>();
            for (int i = 0; i < 1; i++)//option here to increase threading if computations get more complicated - note possible problem with unsorted spectra?
            {
                parseTaskList.Add(Task.Run(() =>
                {
                    return ParseSpectra(rawScanQueue, msScanParameters);
                }));
            }
            ReadRawFile(raw, rawScanQueue);
            Task.WaitAll(parseTaskList.ToArray());
            
            foreach (Task<Tuple<List<MsScan>, List<Ms2Scan>>> resultTask in parseTaskList)
            {
                this.msScanList.AddRange(resultTask.Result.Item1);
                this.ms2ScanList.AddRange(resultTask.Result.Item2);
            }
        }
        
        /// <summary>
        /// Reads raw data. Puts spectra into a thread safe queue. Closes queue when done. Parses the rawfile-log into the statusLog object
        /// </summary>
        /// <param name="raw">Raw file</param>
        /// <param name="rawScanQueue">Thread safe queue</param>
        private void ReadRawFile(IXRawfile5 raw, BlockingCollection<RawScan> rawScanQueue)
        {
            int firstScanNumber = -1;
            raw.GetFirstSpectrumNumber(ref firstScanNumber);
            int lastScanNumber = -1;
            raw.GetLastSpectrumNumber(ref lastScanNumber);
            
            for (int scanNumber = firstScanNumber; scanNumber <= lastScanNumber; scanNumber++)
            {
                string scanFilter = null;
                raw.GetFilterForScanNum(scanNumber, ref scanFilter);

                //read scan header into key/value arrays
                object keyRef = null;
                object valueRef = null;
                int indexRef = 0;
                raw.GetTrailerExtraForScanNum(scanNumber, ref keyRef, ref valueRef, ref indexRef);
                string[] trailerKeys = (string[])keyRef;
                string[] trailerValues = (string[])valueRef;
                
                //read tic and base peak mass using dummy variables
                double tic = 0.0;
                int int1 = 0;
                int int2 = 0;
                int int3 = 0;
                double double1 = 0.0;
                double double2 = 0.0;
                double double3 = 0.0;
                double basePeakMass = 0.0;
                double double5 = 0.0;
                double double6 = 0.0;
                raw.GetScanHeaderInfoForScanNum(scanNumber, ref int1, ref double1, ref double2, ref double3, ref tic, ref basePeakMass, ref double5, ref int2, ref int3, ref double6);

                //read data (mz,int,...) using dummy variables
                object labels_obj = null;
                object flags_obj = null;
                raw.GetLabelData(ref labels_obj, ref flags_obj, ref scanNumber);
                double[,] data = (double[,])labels_obj;

                //read precursorMz
                double precursorMz = 0.0;
                raw.GetPrecursorMassForScanNum(scanNumber, 2, ref precursorMz);
                
                RawScan rawScan = new RawScan(scanNumber, scanFilter, tic, trailerKeys, trailerValues, data, precursorMz, basePeakMass);
                rawScanQueue.Add(rawScan);

                //read status log
                double rtLog = 0.0;
                object statuslogKeys = null;
                object statuslogValues = null;
                int statuslogN = 0;
                raw.GetStatusLogForScanNum(scanNumber, ref rtLog, ref statuslogKeys, ref statuslogValues, ref statuslogN);
                statusLog.Add(rtLog, (string[])statuslogKeys, (string[])statuslogValues);
            }
            rawScanQueue.CompleteAdding();
            Log.Information("Read all spectra in base module");
        }
        // Relies on assumption that the rawscans are sorted, i.e. the currentFullMS is set for each ms2 scan
        private Tuple<List<MsScan>, List<Ms2Scan>> ParseSpectra(BlockingCollection<RawScan> rawScanQueue, SettingsForAnalysis fixedSettings)
        {
            List<Tuple<int, double, int>> polymerTargetList = ExtractPolymers(fixedSettings.Polymers);
            List<MsScan> msScanList = new List<MsScan>(1000);
            List<Ms2Scan> ms2ScanList = new List<Ms2Scan>(1000);
            RawScan currentFullMS = null;
            
            foreach (RawScan rawScan in rawScanQueue.GetConsumingEnumerable())
            {
                if (rawScan.IsMS2())
                {
                    ms2ScanList.Add(new Ms2Scan(rawScan, fixedSettings.StoNthreshold, currentFullMS));
                }
                else
                {
                    currentFullMS = rawScan;
                    msScanList.Add(new MsScan(rawScan, fixedSettings.StoNthreshold, polymerTargetList, fixedSettings.Polymers.Count, fixedSettings.Adducts, fixedSettings.BaseMassTolerance));
                }
            }
            return new Tuple<List<MsScan>, List<Ms2Scan>>(msScanList, ms2ScanList);
        }

        private static List<Tuple<int, double, int>> ExtractPolymers(List<Polymer> polymers)
        {
            List<Tuple<int, double, int>> targetList = new List<Tuple<int, double, int>>();
            int polymerIndex = 0;
            foreach (Polymer polymer in polymers)
            {
                targetList.Add(new Tuple<int, double, int>(polymerIndex, Convert.ToDouble(polymer.Mz0), Convert.ToInt32(polymer.Z0)));
                targetList.Add(new Tuple<int, double, int>(polymerIndex, Convert.ToDouble(polymer.Mz1), Convert.ToInt32(polymer.Z1)));
                targetList.Add(new Tuple<int, double, int>(polymerIndex, Convert.ToDouble(polymer.Mz2), Convert.ToInt32(polymer.Z2)));
                targetList.Add(new Tuple<int, double, int>(polymerIndex, Convert.ToDouble(polymer.Mz3), Convert.ToInt32(polymer.Z3)));
                targetList.Add(new Tuple<int, double, int>(polymerIndex, Convert.ToDouble(polymer.Mz4), Convert.ToInt32(polymer.Z4)));
                polymerIndex++;
            }

            return targetList;
        }

        private double GetLargeInjectionTimeShifts(List<MsScan> scans, double relativeShiftThreshold)
        {
            int counter = 0;
            int quarter = (int)scans.Count / 4;
            int threequarter = (int)scans.Count / 4 * 3;
            for (int i = quarter; i < threequarter; i++)
            {
                if (Math.Abs(scans[i].InjectionTime - scans[i+1].InjectionTime) / scans[i].InjectionTime > relativeShiftThreshold)
                {
                    counter++;
                }
            }
            double fractionAbove = (double) counter / (threequarter - quarter) * 100;
            return fractionAbove;
        }

        private int GetNoMS2scansAboveIonThreshold(List<Ms2Scan> scans, double ionThreshold)
        {
            int counter = 0;
            for (int i = 1; i < scans.Count(); i++)
            {
                if (scans[i].IonCountFromRawOvFtT > ionThreshold)
                {
                    counter++;
                }
            }
            return counter;
        }
        private void GetOptimalGradient(List<MsScan> scans, double retentionTimeIntervals, out string optimalGradient)
        {
            //TODO, Calculate optimal gradient (how?)
            List<Tuple<double, double>> temp = new List<Tuple<double, double>>
            {
                new Tuple<double, double>(1, 1)
            };
            optimalGradient = "";
        }
        private Tuple<double,double,double> GetMS2PrecursorChargeStateDistribution(List<Ms2Scan> scans)
        {
            int[] chargeDistribution = new int[] { 0, 0, 0 };
            for (int i = 0; i < scans.Count(); i++)//or i = 1?
            {
                if (scans[i].ChargeState == 2)
                    chargeDistribution[0]++;
                else if (scans[i].ChargeState == 3)
                    chargeDistribution[1]++;
                else if (scans[i].ChargeState >= 4)
                    chargeDistribution[2]++;
            }
            double[] doubleChargeDistribution = new double[3];
            for (int i = 0; i < chargeDistribution.Length; i++)
            {
                doubleChargeDistribution[i] = Convert.ToDouble(chargeDistribution[i]) / Convert.ToDouble(scans.Count()) * 100.0;
            }
            return new Tuple<double,double,double>(doubleChargeDistribution[0], doubleChargeDistribution[1], doubleChargeDistribution[2]);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // ADD STUFF
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
