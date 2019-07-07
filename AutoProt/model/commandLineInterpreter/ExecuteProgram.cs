using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AutoProt
{
    public static class ExecuteProgram
    {
        public static List<double> GetResultsFromExternalProgram(string executable, string arguments, string[] resultfiles, string[] names, int timeoutInSeconds, char splitChar, bool isColumns)
        {
            List<double> allResultValues = new List<double>();
            if (RunProcess(executable, arguments, timeoutInSeconds))
            {
                allResultValues = ParseAllResultFiles(resultfiles, names, splitChar, isColumns);
            }
            return allResultValues;
        }

        private static bool RunProcess(string executable, string arguments, int timeOut)
        {
            bool ran2completion;
            //Create a new process info structure.
            ProcessStartInfo pInfo = new ProcessStartInfo();
            //Set executable path and name and arguments
            pInfo.FileName = executable;
            pInfo.Arguments = arguments;
            //Control output
            pInfo.ErrorDialog = false;
            pInfo.UseShellExecute = false;
            pInfo.RedirectStandardOutput = false;
            pInfo.RedirectStandardError = false;

            Process p = Process.Start(pInfo);
            p.ErrorDataReceived += (sender, errorLine) => { if (errorLine.Data != null) Trace.WriteLine(errorLine.Data); };
            //p.OutputDataReceived += (sender, outputLine) => { if (outputLine.Data != null) Trace.WriteLine(outputLine.Data); };
            //p.BeginErrorReadLine();
            //p.BeginOutputReadLine();
            //Wait for the process to exit or time out.
            p.WaitForExit(timeOut * 1000);
            //Check to see if the process is still running.
            if (p.HasExited == false)
            {
                //Process is still running.
                //Test to see if the process is hung up.
                /*
                if (p.Responding)
                {
                    //Process was responding; close it.
                    p.Close();
                }
                else
                {
                    //Process was not responding; force the process to close.
                    p.Kill();
                }
                */
                // Skip any responding checks, just kill
                p.Kill();
                ran2completion = false;
            }
            else
            {
                ran2completion = true;
            }
            return ran2completion;
        }

        
        //Open an array of files with results, find specific columns and find numeric values.
        //If multiple exists: median is calculated; if none: NaN. Results are in order of file, columns.
        private static List<double> ParseAllResultFiles(string[] resultfiles, string[] names, char splitChar, bool indexesAreColumns)
        {
            List<double> results = new List<double>();
            //create internal result dictionary to avoid reading same file multiple time
            Dictionary<string, Dictionary<string,double>> file2name2result = new Dictionary<string, Dictionary<string,double>>();
            for (int i = 0; i < resultfiles.Length; i++)
            {
                if (!file2name2result.ContainsKey(resultfiles[i]))
                {
                    file2name2result.Add(resultfiles[i], new Dictionary<string, double>());
                    file2name2result[resultfiles[i]].Add(names[i], 0.0);
                }
                else
                {
                    file2name2result[resultfiles[i]].Add(names[i], 0.0);
                }
            }

            foreach (string file in file2name2result.Keys)
            {
                if (indexesAreColumns)
                {
                    ParseSingleFileByColumn(file, file2name2result[file], splitChar);
                }
                else
                {
                    ParseSingleFileByRow(file, file2name2result[file], splitChar);
                }
            }
            //go back to list format
            for (int i = 0; i < resultfiles.Length; i++)
            {
                results.Add(file2name2result[resultfiles[i]][names[i]]);
            }
            return results;
        }

        private static void ParseSingleFileByColumn(string resultfile, Dictionary<string,double> name2result, char splitChar)
        {
            using (StreamReader sr = File.OpenText(resultfile))
            {
                string s = String.Empty;
                bool headerFound = false;
                Dictionary<int, string> columnIndex2name = new Dictionary<int, string>();
                while ((s = sr.ReadLine()) != null)
                {
                    string[] resultcolumns = s.Split(splitChar);
                    if (headerFound)
                    {
                        foreach (int column in columnIndex2name.Keys)
                        {
                            if (Double.TryParse(resultcolumns[column], out double result))
                            {
                                name2result[columnIndex2name[column]] = result;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < resultcolumns.Length; i++)
                        {
                            if (name2result.ContainsKey(resultcolumns[i]))
                            {
                                columnIndex2name.Add(i, resultcolumns[i]);
                                headerFound = true;
                            }
                        }
                        
                    }
                }
            }
        }
        private static void ParseSingleFileByRow(string resultfile, Dictionary<string, double> name2result, char splitChar)
        {
            using (StreamReader sr = File.OpenText(resultfile))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] rowitems = s.Split(splitChar);
                    if (name2result.ContainsKey(rowitems[0]))
                    {
                        foreach (string rowitem in rowitems)
                        {
                            if (Double.TryParse(rowitem, out double result))
                            {
                                name2result[rowitems[0]] = result;
                            }
                        }
                    }
                }
            }
        }

        //Not used at the moment - idea was to have some summary statistic to handle rows/columns with multiple values i.e. count length, average, sum etc.
        private static List<double> SummarizeResults(int[] keysInFixedOrder, Dictionary<int, List<double>> resultsByRow)
        {
            List<double> summarizedResults = new List<double>();
            foreach (int key in keysInFixedOrder)
            {
                if (resultsByRow[key].Count == 0)
                {
                    summarizedResults.Add(Double.NaN);
                }
                else if (resultsByRow[key].Count == 1)
                {
                    summarizedResults.Add(resultsByRow[key][0]);
                }
                else
                {
                    summarizedResults.Add(resultsByRow[key].Count);//change to median
                }
            }
            return summarizedResults;
        }
    }
}
