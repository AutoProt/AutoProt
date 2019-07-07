using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace AutoProt
{
    public class AnalysisExternal1 : AnalysisTemplate
    {
        public AnalysisExternal1()
        {

        }
        protected override ResultItems GetResultItems(UIsettings settingName)
        {
            ResultItems results = new ResultItems();

            foreach (ExternalResultParseSetting item in settingName.ExternalResults)
            {
                results.Add(item.Resultname, typeof(double));
            }
            /*
            results.Add("MedianMS1IsolationInterference", typeof(double));
            results.Add("MedianPeakWidthAt10Percent(s)", typeof(double));
            results.Add("MedianPeakWidthAtHalfMax(s)", typeof(double));
            results.Add("MedianAsymmetryFactor", typeof(double));
            results.Add("ColumnCapacity", typeof(double));
            */
            return results;
        }
        public override ResultItems Analyze(RawFileName rawfile, SettingsForAnalysis settingName, UIsettings fixedSettings)
        {
            ResultItems results = GetResultItems(fixedSettings);
            List<double> resultlist = new List<double>();
            if (settingName.UseExternal1Analysis)
            {
                Log.Information("Started external1");
                string filename = rawfile.FullName;//"f:/temp2/20190114_QE99_Evo1_DBJ_E7_LFQprot_QC4_HELA_PAC_250ng_7500_01.raw";

                //get list of files and column/row names
                List<string> resultfiles = new List<string>();
                List<string> resultnames = new List<string>();
                foreach (ExternalResultParseSetting settings in fixedSettings.ExternalResults)
                {
                    string resultfile = settings.ResultFile;
                    resultfile = resultfile.Replace("{FILE}", rawfile.FullName);
                    resultfiles.Add(resultfile);
                    resultnames.Add(settings.Resultname);
                }

                
                //maybe add option to delete resultfile?
                try
                {
                    string arguments = fixedSettings.Arguments;
                    arguments = arguments.Replace("{FILE}", rawfile.FullName);
                    resultlist = ExecuteProgram.GetResultsFromExternalProgram(
                        fixedSettings.Executable, //raw.exe
                         arguments, //"parse -x -f " + filename
                        resultfiles.ToArray(),
                        resultnames.ToArray(),
                        fixedSettings.Timeout,
                        fixedSettings.ExternalToolSepChar,
                        !fixedSettings.AsRow);

                    if (resultlist.Count != fixedSettings.ExternalResults.Count)
                    {
                        resultlist.Clear();
                        for (int i = 0; i < fixedSettings.ExternalResults.Count; i++)
                        {
                            resultlist.Add(0.0);
                        }
                        Log.Error("External1 result was not parsed correctly (are headers correct?)");
                    }


                    Log.Information("Finished external1");
                }
                catch
                {
                    //something went wrong, adding 0s as filler and reporting error
                    Log.Error("External1 failed");
                    for (int i = 0; i < fixedSettings.ExternalResults.Count; i++)
                    {
                        resultlist.Add(0.0);
                    }
                }
            }
            else
            {
                //no analysis requested, adding 0s as filler
                for (int i = 0; i < fixedSettings.ExternalResults.Count; i++)
                {
                    resultlist.Add(0.0);
                }
            }
            //set results
            for (int i = 0; i < fixedSettings.ExternalResults.Count; i++)
            {
                results.SetValue(fixedSettings.ExternalResults[i].Resultname, resultlist[i]);
            }
            return results;
        }
    }
}
