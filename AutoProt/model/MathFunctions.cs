using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProt
{
    public static class MathFunctions
    {
        private static double Median(List<double> xs)
        {
            double median;
            if (xs.Count > 0)
            {
                xs.Sort();
                double mid = (xs.Count - 1) / 2.0;
                median = (xs[(int)(mid)] + xs[(int)(mid + 0.5)]) / 2;
            }
            else
            {
                median = -1.0;
            }
            return (median);
        }
        public static double Median(List<int> xs)
        {
            double median;
            if (xs.Count > 0)
            {
                xs.Sort();
                double mid = (xs.Count - 1) / 2.0;
                median = (xs[(int)(mid)] + xs[(int)(mid + 0.5)]) / 2;
            }
            else
            {
                median = -1;
            }
            return (median);
        }
        //what if list is empty? Function seems flawed, why is each element sorted? Is it the right direction? /CK
        public static double[] GetPercentile(List<double[]> xs, int percentile)// could have percentile as variable.
        {
            int listsize = xs.Count;
            int arraySize = xs[0].Length;
            int percentileIndex = Convert.ToInt32(listsize * percentile / 100);
            double[] tempArray = new double[listsize];
            double[] resultArray = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < listsize; j++)
                {
                    tempArray[j] = xs[j][i];
                }
                Array.Sort(tempArray);
                resultArray[i] = tempArray[percentileIndex];
            }
            return resultArray;
        }
        public static double GetPercentile(List<double> xs, int percentile)// could have percentile as variable.
        {
            double percentileValue;
            if (xs.Count > 0 && percentile <= 100 && percentile >= 0)
            {
                int percentileIndex = Convert.ToInt32(xs.Count * percentile / 100);
                xs.Sort();
                percentileValue = xs[percentileIndex];
            }
            else
            {
                percentileValue = 0.0;
            }
            return (percentileValue);


        }
        public static double StandardDeviation(IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }
        public static double Mode(List<double> x)
        {
            return HalfSampleMode(x);
        }
        private static double HalfSampleMode(List<double> x)
        {
            string errorCode = "";
            double modeResult = 0.0;
            List<double> y = x.OrderBy(s => s).ToList();

            int ymin = 0;
            int ymax = y.Count - 1;
            int range = ymax - ymin;

            List<int> minIndex = new List<int>();
            while (range >= 3)
            {
                range = (ymax - ymin) / 2;
                double minValue = double.MaxValue;
                for (int i = ymin; i <= ymax - range; i++)
                {
                    double curdiff = y[i + range] - y[i];
                    if (minValue > curdiff)
                    {
                        minValue = curdiff;
                        minIndex.Clear();
                        minIndex.Add(i);
                    }
                    else if (minValue == curdiff)
                    {
                        minIndex.Add(i);
                    }
                }
                ymin = (int)Median(minIndex);
                ymax = ymin + range;
                minIndex.Clear();
                errorCode = errorCode + "i: " + ymin.ToString() + " k: " + range.ToString() + "\n";
            }
            if (range == 2)
            {
                double difference = 2.0 * y[ymin + 1] - y[ymin] - y[ymax];
                if (difference < 0.0)
                {
                    modeResult = (y[ymin + 1] + y[ymin]) / 2.0;
                }
                else if (difference == 0.0)
                {
                    modeResult = y[ymin + 1];
                }
                else
                {
                    modeResult = (y[ymin + 1] + y[ymax]) / 2.0;
                }
            }
            else if (range == 1)
            {
                modeResult = (y[ymin] + y[ymax]) / 2.0;
            }
            else if (range == 0)
            {
                modeResult = y[ymin];
            }
            return modeResult;
        }
    }
}
