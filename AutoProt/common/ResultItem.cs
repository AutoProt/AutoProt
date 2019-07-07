using System;
using System.Collections.Generic;
using Serilog;

namespace AutoProt
{
    public class ResultItems : IDisposable
    {
        private bool disposed = false;
        public List<string> Names { get; private set; } = new List<string>();
        public List<Type> Types { get; private set; } = new List<Type>();
        public List<string> Results { get; private set; } = new List<string>();
        private Dictionary<string, int> resultDicIndex = new Dictionary<string, int>();
        public int Count => Names.Count;
        
        public ResultItems()
        {
        }

        public List<string> ResultsWithMaxLength(int maxlength)
        {
            List<string> resultsWithMaxLength = new List<string>(Results.Count);
            foreach (string item in Results)
            {
                if (item.Length <= maxlength)
                {
                    resultsWithMaxLength.Add(item);
                }
                else
                {
                    resultsWithMaxLength.Add(item.Substring(0, maxlength));
                }
            }
            return resultsWithMaxLength;
        }


        public void Add(string name, Type curType)
        {
            if (!resultDicIndex.ContainsKey(name))
            {
                resultDicIndex.Add(name, Names.Count);
                Names.Add(name);
                Types.Add(curType);
                if (curType.Equals(typeof(string)))
                {
                    Results.Add("");
                }
                else if (curType.Equals(typeof(int)))
                {
                    Results.Add("0");
                }
                else if (curType.Equals(typeof(double)))
                {
                    Results.Add("0.0");
                }
                else if (curType.Equals(typeof(DateTime)))
                {
                    Results.Add("");
                }
            }
        }
        public void Add(ResultItems newItems)
        {
            for (int i = 0; i < newItems.Names.Count; i++ )
            {
                if (!resultDicIndex.ContainsKey(newItems.Names[i]))
                {
                    resultDicIndex.Add(newItems.Names[i], Names.Count);
                    Names.Add(newItems.Names[i]);
                    Types.Add(newItems.Types[i]);
                    Results.Add(newItems.Results[i]);
                }
            }
        }

        

        public void SetValue(string name, object result, int digits)
        {
            if (resultDicIndex.ContainsKey(name))
            {
                if (!result.GetType().Equals(Types[resultDicIndex[name]]))
                {
                    Log.Error("Problem in ResultItem SetValue: " + name + " has type " +
                                    result.GetType().ToString() + ", expected " +
                                    Types[resultDicIndex[name]].ToString());
                }
                else
                {
                    if (typeof(double).Equals(result.GetType()))
                    {
                        Results[resultDicIndex[name]] = Math.Round((double) result, digits).ToString();
                    }
                    else
                    {
                        Results[resultDicIndex[name]] = result.ToString();
                    }
                }
            }
            else
            {
                Log.Error("Problem in ResultItem SetValue: " + name + " has not been defined!");
            }

        }
        public void SetValue(string name, object result)
        {
            if (resultDicIndex.ContainsKey(name))
            {
                if (Types[resultDicIndex[name]].Equals(typeof(DateTime)) && result.GetType().Equals(typeof(string)))
                {
                    Results[resultDicIndex[name]] = result.ToString();
                }
                else if (!result.GetType().Equals(Types[resultDicIndex[name]]))
                {
                    Log.Error("Problem in ResultItem SetValue. " + name + " has type " +
                                    result.GetType().ToString() + ", expected " +
                                    Types[resultDicIndex[name]].ToString());
                }
                else
                {
                    Results[resultDicIndex[name]] = result.ToString();
                }
            }
            else
            {
                Log.Error("Problem in ResultItem SetValue: " + name + " has not been defined!");
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
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
