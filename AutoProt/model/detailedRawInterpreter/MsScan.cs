using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoProt
{
    /// <summary>
    /// Derived full MS scan class, takes a raw scan and parses interesting information.
    /// </summary>
    public class MsScan : MsScanAbstract
    {
        // contains the polymer intensity for this scan
        public double[] Polymer { get; private set; }
        // contains the adduct intensity for this scan
        public double[] Adduct { get; private set; }

        public MsScan(RawScan rawScan, double signalToNoiseThreshold, List<Tuple<int, double, int>> polymerTargetList, int polymerCount, List<Adduct> adducts, double massError) : base(rawScan, signalToNoiseThreshold)
        {

            Tuple<double, int> maxMz = GetMaxIntensity(rawScan.Data);
            if (maxMz.Item2 > 0)
            {
                List<Tuple<int, double, int>> targetList = new List<Tuple<int, double, int>>();
                targetList.AddRange(polymerTargetList);
                int precursorIndex, adductIndex;
                ExtractAdducts(polymerCount, adducts, maxMz, targetList, out precursorIndex, out adductIndex);
                double[] targetIntensities = GetIntensityByMatching(rawScan, massError, targetList);
                SetPolymersAndAdducts(polymerCount, targetList, precursorIndex, adductIndex, targetIntensities);
            }
            else
            {
                this.Polymer = new double[polymerCount];
                this.Adduct = new double[adducts.Count];
            }
        }

        private void SetPolymersAndAdducts(int polymerCount, List<Tuple<int, double, int>> targetList, int precursorIndex, int adductIndex, double[] targetIntensities)
        {
            this.Polymer = new double[polymerCount];
            this.Adduct = new double[adductIndex - polymerCount];
            for (int i = 0; i < targetIntensities.Length; i++)
            {
                if (targetList[i].Item1 < polymerCount) //polymer
                {
                    Polymer[targetList[i].Item1] += targetIntensities[i];
                }
                else if (targetList[i].Item1 == polymerCount) //precursor
                {

                }
                else // adduct
                {
                    Adduct[targetList[i].Item1 - polymerCount - 1] += (100 * targetIntensities[i]) / (targetIntensities[precursorIndex]);
                }
            }
        }

        private static double[] GetIntensityByMatching(RawScan rawScan, double massError, List<Tuple<int, double, int>> targetList)
        {
            double[] targetIntensities = new double[targetList.Count];

            int sortedMzAscendingLength = targetList.Count;
            double[,] msscan = rawScan.Data;
            int msscanLength = msscan.GetLength(1);
            int t = 0;
            int o = 0;
            int charge = (int)(msscan[5, o] + 0.5);
            while (t < sortedMzAscendingLength && o < msscanLength)
            {
                int specificScan = o;
                double[] curscan = new double[] { msscan[0, specificScan], msscan[1, specificScan], msscan[2, specificScan], msscan[3, specificScan], msscan[4, specificScan], msscan[5, specificScan]  };
                double mass_difference = (msscan[0, o] - targetList[t].Item2) / targetList[t].Item2 * 1e6;
                if (Math.Abs(mass_difference) <= massError && targetList[t].Item3 == charge)
                {
                    if (msscan[1, o] > targetIntensities[t])
                    {
                        targetIntensities[t] = msscan[1, o];
                    }
                    t++;
                }
                else if (mass_difference < 0)
                {
                    o++;
                    if (o < msscanLength)
                    {
                        charge = (short)(msscan[5, o] + 0.5);
                    }
                }
                else if (mass_difference >= 0)
                {
                    t++;
                }
            }

            return targetIntensities;
        }

        private static void ExtractAdducts(int polymersCount, List<Adduct> adducts, Tuple<double, int> maxMz, List<Tuple<int, double, int>> targetList, out int precursorIndex, out int adductIndex)
        {
            precursorIndex = polymersCount;
            adductIndex = polymersCount;
            targetList.Add(new Tuple<int, double, int>(precursorIndex, maxMz.Item1, maxMz.Item2));
            foreach (Adduct adduct in adducts)
            {
                adductIndex++;
                if (adduct.MzValue > 0.0)
                {
                    targetList.Add(new Tuple<int, double, int>(adductIndex, adduct.MzValue / Convert.ToDouble(maxMz.Item2) + maxMz.Item1, maxMz.Item2));
                }
                
            }
            targetList.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            // This updates the precursorIndex to point to the precursor in the targetlist, not the index in the targetlist
            for (int i = 0; i < targetList.Count; i++)
            {
                if (targetList[i].Item1 == precursorIndex)
                {
                    precursorIndex = i;
                    break;
                }
            }
            
        }
        
      


        private Tuple<double,int> GetMaxIntensity(double[,] msscan)
        {
            double maxIntensity = 0.0;
            double atMaxMz = 0.0;
            int atMaxZ = 0;
            int msscanLength = msscan.GetLength(1);
            for (int i = 0; i < msscanLength; i++)
            {
                if (msscan[5, i] > 0 && msscan[1, i] > maxIntensity) // 5 is charge
                {
                    maxIntensity = msscan[1, i];
                    atMaxMz = msscan[0, i];
                    atMaxZ = Convert.ToInt32(msscan[5, i]);
                }
            }
            return new Tuple<double, int>(atMaxMz, atMaxZ);
        }


        
        

        
        

        

        

    }
}