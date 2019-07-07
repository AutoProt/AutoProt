using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace AutoProt
{
    public class StatusLog
    {
        private Dictionary<string,int> _names;
        private List<List<string>> Values; //outer list is rows or names, inner is number of entries
        private bool _intialized = false;
        private HashSet<double> _statuslogIndex; //used to only make one entry per status log with multiple add tries of same log
        private double[] _median;
        private double[] _min;
        private double[] _max;
        private double[] _iqr;
        private bool[] _calculatedMedMinMax;

        public StatusLog()
        {
            Values = new List<List<string>>();
        }
        public void Add(double statuslogIndex, string[] statusKeys,string[] statusValues)
        {
            if (!_intialized)
            {
                _intialized = true;
                _statuslogIndex = new HashSet<double>();
                _names = new Dictionary<string, int>(statusKeys.Length);
                _median = new double[statusKeys.Length];
                _min = new double[statusKeys.Length];
                _max = new double[statusKeys.Length];
                _iqr = new double[statusKeys.Length];
                _calculatedMedMinMax = new bool[statusKeys.Length];
                for (int i = 0; i < statusKeys.Length; i++)
                {
                    if (!_names.ContainsKey(statusKeys[i]))//workaround as multiple entries have the same name in some Thermo raw file logs!
                    {
                        _names.Add(statusKeys[i], i);
                    }
                    List<string> newList = new List<string>();
                    Values.Add(newList);
                }
            }
            if (!_statuslogIndex.Contains(statuslogIndex))
            {
                _statuslogIndex.Add(statuslogIndex);
                for (int i = 0; i < statusKeys.Length; i++)
                {
                    Values[i].Add(statusValues[i]);
                }
            }
        }
        
        public double GetMedianOf(string Name)
        {
            if (_intialized && _names.Keys.Contains(Name))
            {
                int currentIndex = _names[Name];
                if (!_calculatedMedMinMax[currentIndex])
                {
                    CalculateMedianMinMax(currentIndex);
                }
                return _median[currentIndex];
            }
            return 0.0;
        }
        public double GetMaxOf(string Name)
        {
            if (_intialized && _names.Keys.Contains(Name))
            {
                int currentIndex = _names[Name];
                if (!_calculatedMedMinMax[currentIndex])
                {
                    CalculateMedianMinMax(currentIndex);
                }
                return _max[currentIndex];
            }
            return 0.0;
        }
        public double GetMinOf(string Name)
        {
            if (_intialized && _names.Keys.Contains(Name))
            {
                int currentIndex = _names[Name];
                if (!_calculatedMedMinMax[currentIndex])
                {
                    CalculateMedianMinMax(currentIndex);
                }
                return _min[currentIndex];
            }
            return 0.0;
        }
        public double GetIqrOf(string Name)
        {
            if (_intialized && _names.Keys.Contains(Name))
            {
                int currentIndex = _names[Name];
                if (!_calculatedMedMinMax[currentIndex])
                {
                    CalculateMedianMinMax(currentIndex);
                }
                return _iqr[currentIndex];
            }
            return 0.0;
        }
        private void CalculateMedianMinMax (int currentIndex)
        {
            if (_intialized)
            {
                List<double> newList = new List<double>();
                for (int i = 0; i < Values[currentIndex].Count; i++)
                {
                    double newDouble = 0.0;
                    if (Double.TryParse(Values[currentIndex][i], out newDouble))
                    {
                        newList.Add(newDouble);
                    }
                }
                _median[currentIndex] = Statistics.Median(newList);
                _min[currentIndex] = newList.Min();
                _max[currentIndex] = newList.Max();
                _iqr[currentIndex] = Statistics.InterquartileRange(newList);
                _calculatedMedMinMax[currentIndex] = true;
            }
        }
    }
}
