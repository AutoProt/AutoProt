using MSFileReaderLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;
using System.Diagnostics;

namespace AutoProt
{
    
    public class AnalysisBase : AnalysisTemplate
    {
        protected IXRawfile5 raw = (IXRawfile5)new MSFileReader_XRawfile();

        public AnalysisBase()
        {
        }
        protected override ResultItems GetResultItems(UIsettings settingName)
        {
            ResultItems results = new ResultItems();

            results.Add("RawFile", typeof(string));

            results.Add("User", typeof(string));
            results.Add("MS instrument", typeof(string));
            results.Add("MS instrument number", typeof(string));
            results.Add("LC instrument", typeof(string));
            results.Add("LC instrument number", typeof(string));
            results.Add("Sample type", typeof(string));
            results.Add("Sample type details", typeof(string));
            results.Add("File name convention followed", typeof(string));
            
            results.Add("LCMS start", typeof(DateTime));
            results.Add("MS start", typeof(DateTime));
            results.Add("LCMS end", typeof(DateTime));
            results.Add("MS time in minutes", typeof(double));
            results.Add("LC time in minutes", typeof(double));

            results.Add("File size (MiB)", typeof(double));
            results.Add("Storage space left (GiB)", typeof(double));

            results.Add("MS count",typeof(int));
            results.Add("MS2 count", typeof(int));
            results.Add("MS TIC", typeof(double));
            results.Add("MS TIC (high percentile)", typeof(double));
            results.Add("MS2 TIC", typeof(double));
            results.Add("MS signal to noise", typeof(double));
            results.Add("MS2 signal to noise", typeof(double));
            results.Add("MS ion count", typeof(double));
            results.Add("MS2 ion count", typeof(double));
            results.Add("MS2 topN", typeof(double));
            results.Add("Large injection time fluctuations", typeof(double));

            results.Add("CTCD or PrOSA minimum", typeof(double));
            results.Add("CTCD or PrOSA maximum", typeof(double));
            results.Add("Lock mass correction maximum absolute (ppm)", typeof(double));

            results.Add("MS2 count above ion threshold", typeof(int));
            results.Add("MS2 count above ion threshold percentage", typeof(double));
            results.Add("MS2 precursor isolation width TIC", typeof(double));
            results.Add("MS2TIC / MS2 precursor isolation width TIC", typeof(double));
            results.Add("MS2 scans with precursor as BP percentage", typeof(double));
            results.Add("MS2 scans XIC above precursor percentage", typeof(double));

            results.Add("MS2 with charge 2 in percent", typeof(double));
            results.Add("MS2 with charge 3 in percent", typeof(double));
            results.Add("MS2 with charge 4 or higher in percent", typeof(double));

            foreach (int day in new int[] { 1, 7, 30, 90 })
            {
                results.Add("Last " + day.ToString() + " day(s) LCMS usage percent", typeof(double));
                results.Add("Last " + day.ToString() + " day(s) MS usage percent", typeof(double));
                results.Add("Last " + day.ToString() + " day(s) MS excl QC usage percent", typeof(double));
            }

            results.Add("Polymer01", typeof(double));
            results.Add("Polymer02", typeof(double));
            results.Add("Polymer03", typeof(double));
            results.Add("Polymer04", typeof(double));
            results.Add("Polymer05", typeof(double));
            results.Add("AdductNa", typeof(double));
            results.Add("AdductCa", typeof(double));
            results.Add("AdductFe", typeof(double));
            results.Add("AdductK", typeof(double));
            results.Add("AdductFA", typeof(double));
            results.Add("AdductNH3", typeof(double));
            results.Add("AdductACN", typeof(double));
            results.Add("Precursor 5 percent mass quantile", typeof(double));
            results.Add("Precursor 95 percent mass quantile", typeof(double));
            results.Add("Warning log", typeof(string));
            results.Add("Analysis tool version", typeof(string));

            foreach (StatusLogItem item in settingName.statusLogItems)
            {
                if (item.CalculateMedian)
                {
                    results.Add(item.Name, typeof(double));
                }
                if (item.CalculateMin)
                {
                    results.Add(item.Name + " min", typeof(double));
                }
                if (item.CalculateMax)
                {
                    results.Add(item.Name + " max", typeof(double));
                }
                if (item.CalculateIQR)
                {
                    results.Add(item.Name + " IQR", typeof(double));
                }
            }
        
            return results;
        }

        

        public override ResultItems Analyze(RawFileName rawfile, SettingsForAnalysis settingName, UIsettings fixedSettings)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            ResultItems results = GetResultItems(fixedSettings);
            //MsScanParameters msScanParameters = new MsScanParameters(settingName);
            
            //progress.Report("[" + rawfile.FullName + "] Start at " + stopwatch.Elapsed.TotalMinutes.ToString("0.00") + " minutes");
            
            results.SetValue("RawFile", rawfile.BaseName);
            results.SetValue("User", rawfile.User);
            results.SetValue("MS instrument", rawfile.MsInstrument);
            results.SetValue("MS instrument number", rawfile.MsInstrumentDetails);
            results.SetValue("LC instrument", rawfile.LcInstrument);
            results.SetValue("LC instrument number", rawfile.LcInstrumentDetails);
            results.SetValue("Sample type", rawfile.SampleType);
            results.SetValue("Sample type details", rawfile.SampleTypeDetails);
            results.SetValue("File name convention followed", (!rawfile.SomethingWrongWithFileName).ToString()); // shitty hack, should be bool
            results.SetValue("File size (MiB)", rawfile.FileSizeMiB, 1);
            results.SetValue("Storage space left (GiB)", rawfile.SpaceLeftGiB, 1);

            if (settingName.UseBaseAnalysis)
            {
                StatusLog statusLog;
                using (RawFileProcessing rawfileResults = new RawFileProcessing(raw, rawfile.FullName, settingName))
                {
                    rawfile.SetDates(rawfileResults._filecreation, rawfileResults._msStart, rawfileResults._msEnd);
                    statusLog = rawfileResults.statusLog;
                    results.SetValue("Warning log", rawfileResults.WarningMessage);

                    results.SetValue("MS count", rawfileResults.MsCount, 0);
                    results.SetValue("MS TIC", rawfileResults.MsTic, 0);
                    results.SetValue("MS TIC (high percentile)", rawfileResults.MsTicHigh, 0);
                    results.SetValue("MS signal to noise", rawfileResults.MsS2N, 2);
                    results.SetValue("MS ion count", rawfileResults.MsIonCount, 0);

                    results.SetValue("CTCD or PrOSA minimum", rawfileResults.CtcdMin, 3);
                    results.SetValue("CTCD or PrOSA maximum", rawfileResults.CtcdMax, 3);
                    results.SetValue("Lock mass correction maximum absolute (ppm)", rawfileResults.LockMassCorrectionMaxAbsolute, 2);


                    results.SetValue("Large injection time fluctuations", rawfileResults.LargeFluctuations, 1); //set as parameter from usrcontrol
                    results.SetValue("Polymer01", rawfileResults.Polymer1, 1);
                    results.SetValue("Polymer02", rawfileResults.Polymer2, 1);
                    results.SetValue("Polymer03", rawfileResults.Polymer3, 1);
                    results.SetValue("Polymer04", rawfileResults.Polymer4, 1);
                    results.SetValue("Polymer05", rawfileResults.Polymer5, 1);
                    results.SetValue("AdductNa", rawfileResults.AdductNa, 1);
                    results.SetValue("AdductCa", rawfileResults.AdductCa, 1);
                    results.SetValue("AdductFe", rawfileResults.AdductFe, 1);
                    results.SetValue("AdductK", rawfileResults.AdductK, 1);
                    results.SetValue("AdductFA", rawfileResults.AdductFA, 1);
                    results.SetValue("AdductNH3", rawfileResults.AdductNH3, 1);
                    results.SetValue("AdductACN", rawfileResults.AdductACN, 1);
                    results.SetValue("Precursor 5 percent mass quantile", rawfileResults.PrecursorMass5percent, 1);
                    results.SetValue("Precursor 95 percent mass quantile",rawfileResults.PrecursorMass95percent, 1);
                    results.SetValue("MS2 topN",rawfileResults.TopN, 2);
                    results.SetValue("MS2 count",rawfileResults.Ms2Count, 0);
                    results.SetValue("MS2 TIC", rawfileResults.Ms2Tic , 0);
                    results.SetValue("MS2 signal to noise", rawfileResults.Ms2S2N, 2);
                    results.SetValue("MS2 ion count",rawfileResults.Ms2IonCount, 0);
                    results.SetValue("MS2 precursor isolation width TIC", rawfileResults.Ms2IsolationWindowTic, 0);
                    results.SetValue("MS2TIC / MS2 precursor isolation width TIC", rawfileResults.Ms2IsolationWindowTicRelative, 3);
                    results.SetValue("MS2 count above ion threshold", rawfileResults.Ms2ScansAboveIonThreshold, 0);
                    results.SetValue("MS2 with charge 2 in percent", rawfileResults.Ms2charge2, 2);
                    results.SetValue("MS2 with charge 3 in percent", rawfileResults.Ms2charge3, 2);
                    results.SetValue("MS2 with charge 4 or higher in percent", rawfileResults.Ms2charge4orMore, 2);
                    results.SetValue("MS2 scans XIC above precursor percentage", rawfileResults.Ms2ScansAbovePrecursorPercent, 2);
                    results.SetValue("MS2 count above ion threshold percentage", rawfileResults.Ms2ScansAboveIonThresholdPercent, 1);
                    results.SetValue("MS2 scans with precursor as BP percentage", rawfileResults.Ms2ScansWithPrecursorBasePeakPercent, 2);
                }

                results.SetValue("LCMS start", rawfile.GetDates(0));
                results.SetValue("MS start", rawfile.GetDates(1));
                results.SetValue("LCMS end", rawfile.GetDates(2));
                results.SetValue("MS time in minutes", rawfile.MsTime, 2);
                results.SetValue("LC time in minutes", rawfile.LcTime, 2);

                Dictionary<int,Tuple<double,double,double>> usage = rawfile.GetUsagePercent();
                foreach (int day in usage.Keys)
                {
                    results.SetValue("Last " + day.ToString() + " day(s) LCMS usage percent", usage[day].Item1, 1);
                    results.SetValue("Last " + day.ToString() + " day(s) MS usage percent", usage[day].Item2, 1);
                    results.SetValue("Last " + day.ToString() + " day(s) MS excl QC usage percent", usage[day].Item3, 1);
                }


                //status log entries

                foreach (StatusLogItem item in fixedSettings.statusLogItems)
                {
                    if (item.CalculateMedian)
                    {
                        results.SetValue(item.Name, statusLog.GetMedianOf(item.Name));
                    }
                    if (item.CalculateMin)
                    {
                        results.SetValue(item.Name + " min", statusLog.GetMinOf(item.Name));
                    }
                    if (item.CalculateMax)
                    {
                        results.SetValue(item.Name + " max", statusLog.GetMaxOf(item.Name));
                    }
                    if (item.CalculateIQR)
                    {
                        results.SetValue(item.Name + " IQR", statusLog.GetIqrOf(item.Name));
                    }
                }
            }

            results.SetValue("Analysis tool version", "0.0.1.21");
            return results;
        }


        


        
    }
}