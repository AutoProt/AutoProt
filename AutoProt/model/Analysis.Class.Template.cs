using System;
using System.Collections.Generic;
using MSFileReaderLib;

namespace AutoProt
{
    public abstract class AnalysisTemplate : IDisposable
    {
        //public string baseName { get; private set; }
        //public ResultItems results;
        protected bool disposed = false;

        public AnalysisTemplate()//, int offset = 0)
        {
            //this.baseName = baseName;
            //this.offset = offset;
            //this.methodName = methodName;
            //this.returnVariables = returnVariables;//not needed, should be implicit from the length of the string arrays
            //this.scanType = scanType;//add check that a valid scanType has been entered.
        }

        public virtual ResultItems Analyze(RawFileName rawfile, SettingsForAnalysis settingName, UIsettings settings)
        {
            return GetResultItems(settings);
        }
        public List<Tuple<string, Type>> GetResultList(UIsettings settingName)
        {
            ResultItems results = GetResultItems(settingName);
            List<Tuple<string, Type>> nameType = new List<Tuple<string, Type>>();
            for (int i = 0; i < results.Count; i++)
            {
                nameType.Add(new Tuple<string, Type>(results.Names[i], results.Types[i]));
            }
            return nameType;
        }
        protected virtual ResultItems GetResultItems(UIsettings settingName)
        {
            ResultItems results = new ResultItems();
            return results;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //if (client != null)
                    //{
                    //    client.Dispose();
                    //}
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
