using System;
using System.Collections.Generic;

namespace AutoProt
{
    /// <summary>
    /// 
    /// </summary>
    public class Ms2Scan : MsScanAbstract
    {
        public double Ms2XicAboveThreshold { get; private set; }
        public double PrecursorMass{ get; private set; }
        public double IsolationWindowTic { get; private set; }
        public double IsolationWindowTicRelative { get; private set; }
        public int IsPrecursorBasePeak { get; private set; } = 0;
        
        public Ms2Scan(RawScan rawScan, double signalToNoiseThreshold, RawScan previousFullMS) : base(rawScan, signalToNoiseThreshold)
        {
            SetPrecursorMass(rawScan.Precursormz);
            CalculateSignalPartAbove(rawScan.Data, rawScan.Precursormz, IsolationWindow);//parameter here to shift outside precursor window?
            CalculateTICisolationWindow(previousFullMS, rawScan.Precursormz, IsolationWindow);
            IsPrecursorBP(rawScan.Precursormz, rawScan.BasePeakMass);
        }
        private void SetPrecursorMass(double precursormz)
        {
            this.PrecursorMass = this.ChargeState * (precursormz - 1.007276466879);
        }
        private void IsPrecursorBP(double precursormz, double basePeakMass)
        {
            if (basePeakMass > (precursormz - IsolationWindow/2) && basePeakMass < (precursormz + IsolationWindow/2))
            {
                this.IsPrecursorBasePeak = 1;
            }
        }
        private void CalculateTICisolationWindow(RawScan previousFullMS, double precursormz, double window)
        {
            double intensitySum = 0.0;
            double relativeIntensity = 0.0;
            if (previousFullMS != null)
            {
                double[,] msscan = previousFullMS.Data;
                int msscanLength = msscan.GetLength(1);
                double lowerbound = precursormz - window / 2;
                double upperbound = precursormz + window / 2;
                for (int i = 0; i < msscanLength; i++)
                {
                    if (msscan[0, i] > lowerbound && msscan[0, i] < upperbound)
                    {
                        intensitySum += msscan[1, i];
                    }
                }
                if (intensitySum > 0)
                {
                    relativeIntensity = this.Tic / intensitySum;
                }
            }
            this.IsolationWindowTic = intensitySum;
            this.IsolationWindowTicRelative = relativeIntensity;
        }
        private void CalculateSignalPartAbove(double[,] msscan, double precursor, double isolationWindow)
        {
            double mzThreshold = precursor + isolationWindow * 2;
            double aboveIntensity = 0.0;
            int lowerbound = msscan.GetLowerBound(1);
            int upperbound = msscan.GetUpperBound(1);
            for (int i = lowerbound; i <= upperbound; i++)
            {
                if (mzThreshold < msscan[0, i])
                {
                    aboveIntensity += msscan[1, i];
                }
            }
            this.Ms2XicAboveThreshold = aboveIntensity / this.Tic * 100;
        }

    }
}
