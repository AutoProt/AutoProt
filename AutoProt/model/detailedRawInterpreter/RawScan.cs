using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProt
{
    public class RawScan
    {
        public int ScanNumber { get; private set; }
        public string ScanFilter { get; private set; }
        public string[] TrailerExtraKeys { get; private set; }
        public string[] TrailerExtraValues { get; private set; }
        public double Tic { get; private set; }
        public double[,] Data { get; private set; }
        public double Precursormz { get; private set; }
        public double BasePeakMass { get; private set; }

        public RawScan(int scanNumber, string scanFilter, double tic, string[] trailerKeys, string[] trailerValues, double[,] data, double precursorMz,double basePeakMass)
        {
            this.ScanNumber = scanNumber;
            this.ScanFilter = scanFilter;
            this.TrailerExtraKeys = trailerKeys;
            this.TrailerExtraValues = trailerValues;
            this.Tic = tic;
            this.Data = data;
            this.Precursormz = precursorMz;
            this.BasePeakMass = basePeakMass;
        }
        //can write this better, use a bool toggle to only trigger parsing once
        public bool IsMS2()
        {
            bool returnvalue = false;
            if (ScanFilter != null)
            {
                if (ScanFilter.Contains(" ms2 "))
                {
                    returnvalue = true;
                }
            }
            return returnvalue;
        }
    }
}
