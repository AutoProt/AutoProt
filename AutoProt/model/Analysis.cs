using MSFileReaderLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Serilog;

namespace AutoProt
{
    public class Analysis
    {
        //public DataTable ResultTable { get; private set; }
        protected IXRawfile5 raw = (IXRawfile5)new MSFileReader_XRawfile();

        public Analysis()
        {
        }
        /*
        public bool TrySettingNewSettings(List<SettingsForAnalysis> newSettings, UIsettings uIsettings)
        {
            var timeout = TimeSpan.FromMilliseconds(500);
            bool lockTaken = false;
            bool success = false;
            try
            {
                Monitor.TryEnter(settingLock, timeout, ref lockTaken);
                if (lockTaken)
                {
                    this.newSettings = newSettings;
                    this.newUIsettings = uIsettings;
                    updateNeeded = true;
                    success = true;
                }
            }
            catch
            {
                success = false;
            }
            finally
            {
                // Ensure that the lock is released.
                if (lockTaken)
                {
                    Monitor.Exit(settingLock);
                }
            }
            if (success)
            {
                Log.Information("Queued update of analysis settings");
            }
            else
            {
                Log.Warning("Failed queuing update of analysis settings");
            }
            return success;
        }
        */        
        public DataColumn[] GetDataColumn(UIsettings settingName)
        {
            List<Tuple<string, Type>> colNames = GetDataTable(settingName);
            DataColumn[] columns = new DataColumn[colNames.Count];
            for (int i = 0; i<colNames.Count;i++)
            {
                columns[i] = new DataColumn(colNames[i].Item1, colNames[i].Item2);
            }
            return columns;
        }
        public string[] GetColumnNames(UIsettings settingName)
        {
            List<Tuple<string, Type>> colNames = GetDataTable(settingName);
            string[] columns = new string[colNames.Count];
            for (int i = 0; i < colNames.Count; i++)
            {
                columns[i] = colNames[i].Item1;
            }
            return columns;
        }

        public bool CheckSqlConnection(string server, string database, string table, string uid, string password)
        {
            bool success = false;
            using (SQL newsql = new SQL(server, database, table, uid, password))
            {
                success = newsql.TestConnection();
            }
            return success;
        }

        public void CreateSqlTable(string server, string database, string table, string uid, string password, UIsettings settings)
        {
            List<Tuple<string, Type>> types = GetDataTable(settings);
            using (SQL newsql = new SQL(server, database, table, uid, password))
            {
                newsql.CreateTable(table, types);
            }
        }
        public void CreateNewSqlColumns(string server, string database, string table, string uid, string password, UIsettings settings)
        {
            List<Tuple<string, Type>> types = GetDataTable(settings);
            using (SQL newsql = new SQL(server, database, table, uid, password))
            {
                newsql.AddColumnsToTable(table, types);
            }
        }

        public bool CheckEmailServerConnection(string host, string port, string username, string password)
        {
            using (EmailSystem emailSystem = new EmailSystem(host, port, username, password))
            {
                return emailSystem.Enabled;
            }
        }

        public string TryParseRawFile(UIsettings uisettings)
        {
            RawFileName rawfile = new RawFileName(uisettings.RawFileTestName);
            rawfile.SetCategories(uisettings.UserList, uisettings.LcList, uisettings.MsList, uisettings.SamplesList);
            return rawfile.ReadCategories();
        }
        /*
        private void GetPossibleUpdateOfSettings(ref List<SettingsForAnalysis> list, ref UIsettings uisettings)
        {
            var timeout = TimeSpan.FromMilliseconds(500);
            bool lockTaken = false;
            bool success = false;
            int i = 5; //no of times to try
            while (success & i > 0)
            {
                try
                {
                    Monitor.TryEnter(settingLock, timeout, ref lockTaken);
                    if (lockTaken)
                    {
                        if (updateNeeded & newSettings.Count > 0)
                        {
                            list = this.newSettings;
                            this.newSettings = new List<SettingsForAnalysis>();
                            uisettings = this.newUIsettings;
                            this.newUIsettings = new UIsettings();
                        }
                        success = true;
                        updateNeeded = false;
                    }
                }
                catch
                {
                    success = false;
                }
                finally
                {
                    // Ensure that the lock is released.
                    if (lockTaken)
                    {
                        Monitor.Exit(settingLock);
                    }
                }
            }
            if (success)
            {
                Log.Information("Updated analysis settings");
            }
            else
            {
                Log.Warning("Failed update of analysis settings (this shouldn't happen) - try to stop the monitoring and start it again");
            }
        }
        */
        private List<Tuple<string, Type>> GetDataTable(UIsettings settingName)
        {
            List<Tuple<string, Type>> colNames = new List<Tuple<string, Type>>();
            using (AnalysisTemplate curMethod = new AnalysisMorpheus())
            {
                colNames.AddRange(curMethod.GetResultList(settingName));
            }
            using (AnalysisTemplate curMethod = new AnalysisBase())
            {
                colNames.AddRange(curMethod.GetResultList(settingName));
            }
            using (AnalysisTemplate curMethod = new AnalysisExternal1())
            {
                colNames.AddRange(curMethod.GetResultList(settingName));
            }
            return colNames;
        }

        //add log here
        public void Analyze(RawFileName rawfile, UIsettings fixedSettings, SettingsForAnalysis fixedSettingsForAnalysis, IProgress<DataRow> resultRow)
        {
            if (IsFileLocked(rawfile.FullName))
            {
                Log.Error("[" + rawfile.FullName + "] CRITICAL problem: file locked by another process! Skipping file");
            }
            else if (IsNotRawfile(rawfile.FullName))
            {
                Log.Error("[" + rawfile.FullName + "] CRITICAL problem: raw file corrupt! Skipping file");
            }
            else
            {
                Log.Information("[" + rawfile.FullName + "] Main analysis started");
                rawfile.SetCategories(fixedSettings.UserList, fixedSettings.LcList, fixedSettings.MsList, fixedSettings.SamplesList);
                SetRawFileHistory(rawfile, fixedSettings);//This is a mess with the class lines
                if (rawfile.SomethingWrongWithFileName)
                {
                    Log.Warning("[" + rawfile.FullName + "] Please check file naming convention: parse rules and filename do not align.");
                }
                using (ResultItems results = new ResultItems())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    MainAnalysisThreadedTask(rawfile, fixedSettingsForAnalysis, fixedSettings, results);
                    Log.Information("[" + rawfile.FullName + "] Main analysis finished in " + stopwatch.Elapsed.TotalMinutes.ToString("0.00") + " minutes");
                    DoEmailResults(rawfile, fixedSettings, results);
                    DoSqlUpdateResults(rawfile, fixedSettings, results);
                    DoSaveResultsToFile(fixedSettings, results);
                    AddResultRowToDataTable(results.Names, results.Results, results.Types, fixedSettings, resultRow);
                }
            }
        }

        public bool IsAccessible(string fileNameFullPath)
        {
            bool success;
            if (IsFileLocked(fileNameFullPath) || IsNotRawfile(fileNameFullPath))
            {
                success = false;
            }
            else
            {
                success = true;
            }
            return success;
        }

        private static void SetRawFileHistory(RawFileName rawfile, UIsettings fixedSettings)
        {
            if (fixedSettings.UseSql)
            {

                List<double> totalusagetime = new List<double>();
                List<double> totalmstime = new List<double>();
                List<double> totalnonqcmstime = new List<double>();
                using (SQL newsql = new SQL(fixedSettings.Sqlserveradress, fixedSettings.Sqldatabase, fixedSettings.Sqltable, fixedSettings.Sqlusername, fixedSettings.Sqlpassword))
                {
                    newsql.GetTime(rawfile.daysToGoBack, rawfile.MsInstrument, rawfile.MsInstrumentDetails, out totalusagetime, out totalmstime, out totalnonqcmstime);
                }
                rawfile.SetUsageTimes(totalusagetime, totalmstime, totalnonqcmstime);
            }
        }

        private void DoSaveResultsToFile(UIsettings fixedSettings, ResultItems results)
        {
            if (fixedSettings.UseStorageFile)
            {
                string filePath = Path.GetDirectoryName(fixedSettings.Storagefile);
                if (!Directory.Exists(filePath))
                {
                    Log.Error("[" + fixedSettings.Storagefile + "] Something is wrong with the file destination, skipping saving of results");
                }
                else if (!File.Exists(fixedSettings.Storagefile))
                {
                    Log.Information("[" + fixedSettings.Storagefile + "] Creating file and writing results");
                    using (StreamWriter fileStream = new StreamWriter(fixedSettings.Storagefile))
                    {
                        fileStream.WriteLine(String.Join("\t", results.Names));
                        fileStream.WriteLine(String.Join("\t", results.Results));
                    }
                }
                else if (IsFileLocked(fixedSettings.Storagefile))
                {
                    Log.Information("[" + fixedSettings.Storagefile + "] File is busy, skipping saving of results");
                }
                else
                {
                    Log.Information("[" + fixedSettings.Storagefile + "] Appending results to file");
                    using (StreamWriter fileStream = new StreamWriter(fixedSettings.Storagefile, true))
                    {
                        fileStream.WriteLine(String.Join("\t", results.Results));
                    }
                }
            }
        }

        private static void DoSqlUpdateResults(RawFileName rawfile, UIsettings fixedSettings, ResultItems results)
        {
            if (fixedSettings.UseSql)
            {
                Log.Information("[" + rawfile.FullName + "] Uploading results to database");
                using (SQL newsql = new SQL(fixedSettings.Sqlserveradress, fixedSettings.Sqldatabase, fixedSettings.Sqltable, fixedSettings.Sqlusername, fixedSettings.Sqlpassword))
                {
                    newsql.Insert(results.Names, results.ResultsWithMaxLength(255));
                }
            }
        }
        
        private static void DoEmailResults(RawFileName rawfile, UIsettings fixedSettings, ResultItems results)
        {
            
            if (fixedSettings.UseEmail)
            {
                using (EmailSystem emailSystem = new EmailSystem(fixedSettings.Mailserveradress, fixedSettings.Mailportname, fixedSettings.Mailusername, fixedSettings.Mailpassword))
                {
                    if (emailSystem.Enabled)
                    {
                        
                        if (!emailSystem.CheckEmailAdress(rawfile.UserEmail,rawfile.User))
                        {
                            Log.Error("[" + rawfile.FullName + "] " + "Email can't be sent, email >" + rawfile.UserEmail + "< not correct for user: " + rawfile.User);
                        }
                        else
                        {
                            StringBuilder messageContent = new StringBuilder("");
                            string[] compareSymbols = fixedSettings.CompareSymbols;
                            foreach (InformationKey ik in fixedSettings.informationKey)
                            {
                                bool addMessage;
                                if (ik.Message != "")
                                {
                                    addMessage = CustomCompare(ik.Name, ik.ComparisonText1, results.Types[ik.ResultItemIndex1], results.Results[ik.ResultItemIndex1], compareSymbols[ik.ComparisonIndex1]);
                                    addMessage = addMessage && CustomCompare(ik.Name, ik.ComparisonText2, results.Types[ik.ResultItemIndex2], results.Results[ik.ResultItemIndex2], compareSymbols[ik.ComparisonIndex2]);
                                    addMessage = addMessage && CustomCompare(ik.Name, ik.ComparisonText3, results.Types[ik.ResultItemIndex3], results.Results[ik.ResultItemIndex3], compareSymbols[ik.ComparisonIndex3]);
                                    addMessage = addMessage && CustomCompare(ik.Name, ik.ComparisonText4, results.Types[ik.ResultItemIndex4], results.Results[ik.ResultItemIndex4], compareSymbols[ik.ComparisonIndex4]);
                                    addMessage = addMessage && CustomCompare(ik.Name, ik.ComparisonText5, results.Types[ik.ResultItemIndex5], results.Results[ik.ResultItemIndex5], compareSymbols[ik.ComparisonIndex5]);
                                    if (addMessage)
                                    {
                                        messageContent.Append(ik.Name);
                                        messageContent.Append(": ");
                                        messageContent.Append(ik.Message);
                                        messageContent.Append("<br />");
                                    }
                                }
                            }
                            StringBuilder bodyContent = new StringBuilder("<table>");
                            for (int i = 0; i < results.Count; i++)
                            {
                                bodyContent.Append("<tr><td>");
                                bodyContent.Append(results.Names[i]);
                                bodyContent.Append("</td><td>");
                                bodyContent.Append(results.Results[i]);
                                bodyContent.Append("</td></tr>");
                            }
                            bodyContent.Append("</table>");
                            string mailresult = emailSystem.SendMail(rawfile.UserEmail, rawfile.User, rawfile.BaseName, bodyContent.ToString(), messageContent.ToString(),rawfile.CcEmails);
                            Log.Information("[" + rawfile.FullName + "] " + "UseEmail system reported " + mailresult);
                        }
                    }
                    else
                    {
                        Log.Error("[" + rawfile.FullName + "] " + "UseEmail system couldn't initialize, is the server configured correctly?");
                    }

                }
            }
        }

        private static bool CustomCompare(string methodName, string comparisonText, Type resultType, string resultString, string mySymbol)
        {
            bool addMessage = false;
            if (comparisonText != "")
            {
                if (resultType.Equals(typeof(double)) || resultType.Equals(typeof(int)))//quick hack, would be nice to only do one type at a time?
                //if (resultType.Equals(typeof(double)))
                {
                    try
                    {
                        double compareValue = Convert.ToDouble(comparisonText);
                        double resultValue = Convert.ToDouble(resultString);
                        switch (mySymbol)
                        {
                            case ">":
                                if (resultValue > compareValue)
                                {
                                    addMessage = true;
                                }
                                else
                                {
                                    addMessage = false;
                                }
                                break;
                            case ">=":
                                if (resultValue >= compareValue)
                                {
                                    addMessage = true;
                                }
                                else
                                {
                                    addMessage = false;
                                }
                                break;
                            case "==":
                                if (resultValue == compareValue)
                                {
                                    addMessage = true;
                                }
                                else
                                {
                                    addMessage = false;
                                }
                                break;
                            case "<=":
                                if (resultValue <= compareValue)
                                {
                                    addMessage = true;
                                }
                                else
                                {
                                    addMessage = false;
                                }
                                break;
                            case "<":
                                if (resultValue < compareValue)
                                {
                                    addMessage = true;
                                }
                                else
                                {
                                    addMessage = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Problem encountered with " + methodName + "'s result interpretation line 1. Error:" + ex.Message);
                    }
                }
            }
            else
            {
                addMessage = true;
            }

            return addMessage;
        }

        private static void MainAnalysisThreadedTask(RawFileName rawfile, SettingsForAnalysis fixedSettingsForAnalysis, UIsettings fixedSettings, ResultItems results)
        {
            //ResultItems results = new ResultItems();
  
            //this can now be done threaded

            List<Task<ResultItems>> taskList = new List<Task<ResultItems>>();
            taskList.Add(Task.Run(() =>
            {
                ResultItems results1 = new ResultItems();
                using (AnalysisTemplate curMethod = new AnalysisMorpheus())
                {
                    results1 = curMethod.Analyze(rawfile, fixedSettingsForAnalysis, fixedSettings);
                }
                GC.Collect();//ugly but this solves problem with memory not released
                return results1;
            }));
            taskList.Add(Task.Run(() =>
            {
                ResultItems results2 = new ResultItems();
                using (AnalysisTemplate curMethod = new AnalysisBase())
                {
                    results2 = curMethod.Analyze(rawfile, fixedSettingsForAnalysis, fixedSettings);
                }
                return results2;
            }));
            taskList.Add(Task.Run(() =>
            {
                ResultItems results3 = new ResultItems();
                using (AnalysisTemplate curMethod = new AnalysisExternal1())
                {
                    results3 = curMethod.Analyze(rawfile, fixedSettingsForAnalysis, fixedSettings);
                }
                return results3;
            }));

            Task.WaitAll(taskList.ToArray());
            foreach (Task<ResultItems> resultTask in taskList)
            {
                results.Add(resultTask.Result);
            }

            //return results;
        }

        

        

        private bool IsFileLocked(string fileName)
        {
            
            FileStream stream = null;
            try
            {
                FileInfo fInfo = new FileInfo(fileName);
                stream = fInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
        private bool IsNotRawfile(string fileName)
        {
            bool returnvar = false;
            
            try
            {
                //IXRawfile5 raw = (IXRawfile5) new MSFileReader_XRawfile();
                RawFileName rawfile = new RawFileName(fileName);
                raw.Open(rawfile.FullName);
				raw.SetCurrentController(0, 1);
				int lastScanNumber = -1;
                raw.GetLastSpectrumNumber(ref lastScanNumber);
				if (lastScanNumber < 10) {
					returnvar = true;
				}
                if (raw != null)
                    raw.Close();
            }
            catch//can add specific exception here
            {
                return true;
            }
            finally
            {
                //if (raw != null)
                //    raw.Close();
            }
            return returnvar;
        }
        /*
        public Dictionary<AnalysisTemplate,string> GetFixedSettings(string analysisMethod)
        {
            //add check to see if still in UI thread, get settings as value type with deepcopy
            Dictionary<AnalysisTemplate, string> fixedSettings = new Dictionary<AnalysisTemplate, string>(methods.Count);
            foreach (AnalysisTemplate curMethod in methods)
            {
                fixedSettings.Add(curMethod,curMethod.GetSettings(analysisMethod));
            }
            return fixedSettings;
        }
        */
        private void AddResultRowToDataTable(List<string> names, List<string> values, List<Type> types, UIsettings setttings, IProgress<DataRow> resultRow) //RawFileName rawfile, Dictionary<string, ResultItem> results)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(GetDataColumn(setttings));
            DataRow row = dt.NewRow();
            for (int i = 0; i < names.Count; i++)
            {   
                if (types[i] == typeof(DateTime))
                {
                    DateTime newTime = new DateTime();
                    if (DateTime.TryParseExact(values[i], @"yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.AssumeUniversal, out newTime))
                    {
                        row[names[i]] = newTime;
                    }
                    else
                    {
                        row[names[i]] = DateTime.MinValue;
                    }
                }
                else
                {
                    row[names[i]] = values[i];
                }
            }
            dt.Rows.Add(row);
            resultRow.Report(row);
        }
    }
}

