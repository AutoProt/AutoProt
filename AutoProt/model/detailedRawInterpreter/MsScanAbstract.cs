using System;

namespace AutoProt
{
    public abstract class MsScanAbstract
    {
        public double InjectionTime { get; private set; }
        public double IonCountFromRawOvFtT { get; private set; }
        public double Tic { get; private set; }
        public int ChargeState { get; private set; }
        public double SignalToNoise { get; private set; }
        public int ScanNumber { get; private set; }
        public double IsolationWindow { get; private set; }
        public double Ctcd = 0.0;
        public int LockMassNo = 0;
        public double LockMassCorr = 0.0;

        public MsScanAbstract(RawScan rawScan, double signalToNoiseThreshold)
        {
            ParseScanHeader(rawScan);
            SetSignalToNoiseAsAverageAboveThreshold(signalToNoiseThreshold, rawScan.Data);
        }
        protected void ParseScanHeader(RawScan rawScan)
        {
            double _injectionTime = 0.0;
            double _ionCountFromRawOvFtT = 0.0;
            double _isolationWidth = 0.0;
            int _chargeState = 0;

            double _ctcd = 0.0;
            int _lockMassNo = 0;
            double _lockMassCorr = 0.0;
            
            string[] theStringKeys = (string[])rawScan.TrailerExtraKeys;
            string[] theStringValues = (string[])rawScan.TrailerExtraValues;
            for (int i = 0; i < theStringKeys.Length; i++)
            {
                string trimmed = theStringKeys[i].Trim(new Char[] { ' ', '*', '.', ';', ':' });
                switch (trimmed)
                {
                    case "Ion Injection Time (ms)":
                        Double.TryParse(theStringValues[i], out _injectionTime);
                        break;
                    case "RawOvFtT":
                        Double.TryParse(theStringValues[i], out _ionCountFromRawOvFtT);
                        break;
                    case "Charge State":
                        Int32.TryParse(theStringValues[i], out _chargeState);
                        break;
                    case "MS2 Isolation Width":
                        Double.TryParse(theStringValues[i], out _isolationWidth);
                        break;
                    case "LM m/z-Correction (ppm)":
                        Double.TryParse(theStringValues[i], out _lockMassCorr);
                        break;
                    case "CTCD Comp":
                        Double.TryParse(theStringValues[i], out _ctcd);
                        break;
                    case "PrOSA Comp":
                        Double.TryParse(theStringValues[i], out _ctcd);
                        break;
                }
            }
            this.ScanNumber = rawScan.ScanNumber;
            this.InjectionTime = _injectionTime;
            this.IonCountFromRawOvFtT = _ionCountFromRawOvFtT;
            this.ChargeState = _chargeState;
            this.IsolationWindow = _isolationWidth;
            this.LockMassCorr = _lockMassCorr;
            this.LockMassNo = _lockMassNo;
            this.Ctcd = _ctcd;
            this.Tic = rawScan.Tic;
        }

        protected void SetSignalToNoiseAsAverageAboveThreshold(double signalToNoiseThreshold, double[,] msscan)
        {
            double summedSignalToNoise = 0;
            int peaksIncluded = 0;
            int lowerBound = msscan.GetLowerBound(1);
            int upperBound = msscan.GetUpperBound(1);
            for (int i = lowerBound; i <= upperBound; i++)
            {
                double peakSignalToNoise = msscan[1, i] / msscan[4, i];
                if (peakSignalToNoise > signalToNoiseThreshold)
                {
                    summedSignalToNoise += peakSignalToNoise;
                    peaksIncluded++;
                }
            }
            this.SignalToNoise = summedSignalToNoise / peaksIncluded;
        }
    }
}