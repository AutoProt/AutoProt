using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using Serilog;
using Serilog.Sinks.File;
using System.Threading;

namespace AutoProt
{



    public partial class ViewModelMain  //IClonable
    {
        //settings
        private readonly FileMonitor watcher;
        public UIsettings uisettings; //view will bind directly to here
        private Analysis model;
        public BindingList<string> logList;
        private BindingList<SettingsForAnalysis> workflowList;
        public BindingSource workflows;
        public BindingSource variableMods;
        public BindingSource fixedMods;
        public BindingSource manualAnalysis;
        public BindingSource automaticAnalysis;
        public BindingSource codeNameAnalysis;
        public BindingSource adducts;
        public BindingSource polymers;
        public BindingSource external1Results;
        public DataTable ResultTable { get; private set; }

        public ViewModelMain()
        {

            //only for binding
            SettingsForAnalysis settingsForAnalysis;
            //this.workflows = new BindingList<Workflow>();
            //workflows = new BindingSource();
            workflowList = new BindingList<SettingsForAnalysis>();
            //workflows.DataSource = workflowList;

            Load();


            this.model = new Analysis();

            //initialize the log
            var logsink = new LogListSink();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                //.WriteTo.File("F://log.txt", shared: true)
                .WriteTo.Sink(logsink)
                .CreateLogger();

            //this.log = new BindingList<string>();
            this.logList = logsink.LogEvents;

            workflows = new BindingSource
            {
                DataSource = workflowList,
            };
            manualAnalysis = new BindingSource
            {
                DataSource = workflowList,
            };
            automaticAnalysis = new BindingSource
            {
                DataSource = workflowList,
            };
            variableMods = new BindingSource
            {
                DataSource = workflows,
                DataMember = nameof(settingsForAnalysis.variableModifications)
            };
            codeNameAnalysis = new BindingSource
            {
                DataSource = workflowList,
            };

            fixedMods = new BindingSource
            {
                DataSource = workflows,
                DataMember = nameof(settingsForAnalysis.fixedModifications)
            };

            adducts = new BindingSource
            {
                DataSource = workflows,
                DataMember = nameof(settingsForAnalysis.Adducts)
            };

            polymers = new BindingSource
            {
                DataSource = workflows,
                DataMember = nameof(settingsForAnalysis.Polymers)
            };
            
            ResultTable = new DataTable();
            ResultTable.Columns.AddRange(model.GetDataColumn(uisettings));

            uisettings.ResultNames = model.GetColumnNames(uisettings);
            uisettings.SelectedCodeNameList = -1;//hack to not trigger cmbBxCodeName_SelectedIndexChanged on anything important. Should be solved by fix in bindings?
                                                 //IProgress<string> log = GetProgressItem();

            this.watcher = new FileMonitor();
            Log.Information("Managed to start! :)");
        }

        public void BaseAdductReset()
        {
            workflowList[uisettings.SelectedWorkflow].ResetAdducts();
        }
        public void BasePolymerReset()
        {
            workflowList[uisettings.SelectedWorkflow].ResetPolymers();
        }
        public void BaseStatusLogAdd()
        {
            if (!String.IsNullOrWhiteSpace(uisettings.StatusLogNewItems))
            {
                string[] lines = uisettings.StatusLogNewItems.Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.None
                    );
                foreach (string line in lines)
                {
                    uisettings.statusLogItems.Add(new StatusLogItem(line));
                }
            }
            uisettings.StatusLogNewItems = "";
        }
        public void BaseStatusRemove()
        {
            int index = uisettings.SelectedBaseStatusLog;
            if (index >= 0 && uisettings.statusLogItems.Count > index)
            {
                uisettings.statusLogItems.RemoveAt(index);
            }
        }

        public bool StartWatcher(int watchIndex, IProgress<DataRow> resultRow)
        {
            bool watcherStarted = false;
            if (this.watcher.IsWatching(watchIndex))
            {
                this.watcher.Stop(watchIndex);
            }
            else
            {

                if (!this.watcher.AnyWatching())
                {
                    this.watcher.NewFilelist();


                    // This TaskScheduler captures SynchronizationContext.Current.
                    TaskScheduler taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
                    // Start a new task (this uses the default TaskScheduler, 
                    // so it will run on a ThreadPool thread).
                    Task.Run(() => DequeueFile(resultRow, taskScheduler));
                    Log.Information("Started background processing thread with fixed parameters");
                }
                //start appropriate folder
                switch (watchIndex)
                {
                    case 0:
                        this.watcher.Start(watchIndex, uisettings.Monitorfolder1);
                        break;
                    case 1:
                        this.watcher.Start(watchIndex, uisettings.Monitorfolder2);
                        break;
                    case 2:
                        this.watcher.Start(watchIndex, uisettings.Monitorfolder3);
                        break;
                    case 3:
                        this.watcher.Start(watchIndex, uisettings.Monitorfolder4);
                        break;
                    case 4:
                        this.watcher.Start(watchIndex, uisettings.Monitorfolder5);
                        break;
                }

                if (this.watcher.IsWatching(watchIndex))
                {
                    //currentButton.Text = "Stop watch";//returns true
                    watcherStarted = true;
                }
            }
            return watcherStarted;
        }
        //probably don't need this function
        public string CheckCodeName(string rawfile, List<SettingsForAnalysis> analyses, UIsettings uisettings)
        {
            return ParseAnalysisSettings(rawfile, analyses, uisettings).Name;
        }

        private void DequeueFile(IProgress<DataRow> resultRow, TaskScheduler taskScheduler)
        {
            //List<string> parsedFileList = new List<string>();
            //Dictionary<string, int> waitList = new Dictionary<string, int>();
            foreach (string fileNameFullPath in this.watcher.GetFile())
            {
                // if not on waitList or parsedList, add it with count 0
                //if (!parsedFileList.Contains(fileNameFullPath) && !waitList.ContainsKey(fileNameFullPath))
                if (watcher.GetCounter(fileNameFullPath) == 0)
                {
                    //waitList.Add(fileNameFullPath, 1);
                    Log.Information("[" + fileNameFullPath + "] New file found!");
                }
                if (!model.IsAccessible(fileNameFullPath))
                {
                    if (watcher.GetCounter(fileNameFullPath) > 1000)
                    {
                        Log.Error("[" + fileNameFullPath + "] Giving up, file seems not to be available");
                    }
                    else
                    {
                        if (watcher.GetCounter(fileNameFullPath) == 0)
                        {
                            Log.Information("[" + fileNameFullPath + "] Tried to analyze file but couldn't, putting on retry-list");
                        }
                        if (!watcher.TryIncreaseCounterAndRequeue(fileNameFullPath))
                        {
                            Log.Error("[" + fileNameFullPath + "] Removed from retry-list due to internal problems");//should never be hit
                        }
                        Task.Delay(15000).Wait(); //added delay to prevent looking for the same file very quickly again.
                        //Thread.Sleep(15000); //added delay to prevent looking for the same file very quickly again.
                    }
                }
                else
                {
                    // start analysis, disregarding how it goes, add to parsedfilelist and waitlist
                    // if analysis successful, notify
                    // if unsuccessful, catch exceptions to avoid stalling and notify
                    Log.Information("[" + fileNameFullPath + "] Analysis workflow successfully starting after " + watcher.GetCounter(fileNameFullPath) + " attempts");
                    try
                    {
                        //Getting a deep copy of settings from correct thread
                        Task<Tuple<UIsettings,List<SettingsForAnalysis>>> CloningSettings = Task<Tuple<UIsettings, List<SettingsForAnalysis>>>.Factory.StartNew(() =>
                        {
                            UIsettings settings = uisettings.Clone();
                            List<SettingsForAnalysis> settingsForAnalysis = new List<SettingsForAnalysis>();
                            foreach (SettingsForAnalysis existingSettings in workflowList)
                            {
                                settingsForAnalysis.Add(existingSettings.Clone());
                            }
                            return new Tuple<UIsettings, List<SettingsForAnalysis>>(settings, settingsForAnalysis);
                        },
                          CancellationToken.None,
                          TaskCreationOptions.None,
                          taskScheduler);
                        CloningSettings.Wait();
                        UIsettings fixedUIsettings = CloningSettings.Result.Item1;
                        List<SettingsForAnalysis> fixedsSettingsForAnalyses = CloningSettings.Result.Item2;

                        if (fixedUIsettings.Chkfastlocaldrive)
                        {
                            string newFile = Path.GetFileName(fileNameFullPath);
                            string newFileFullPath = fixedUIsettings.Fastlocaldrive + "\\" + newFile;
                            File.Copy(fileNameFullPath, newFileFullPath, true);
                            File.SetCreationTime(newFileFullPath, File.GetCreationTime(fileNameFullPath));
                            RawFileName rawfile = new RawFileName(newFileFullPath);
                            rawfile.UpdateSpaceLeft(fileNameFullPath);
                            SettingsForAnalysis newSettings = ParseAnalysisSettings(rawfile.BaseName, fixedsSettingsForAnalyses, fixedUIsettings);
                            Log.Information("[" + newFileFullPath + "] Copied file to temporary location, main analysis starting using: " + newSettings.Name);
                            model.Analyze(rawfile, fixedUIsettings, newSettings, resultRow);
                            File.Delete(newFileFullPath);
                            Log.Information("[" + newFileFullPath + "] Copied file deleted");
                        }
                        else
                        {
                            RawFileName rawfile = new RawFileName(fileNameFullPath);
                            SettingsForAnalysis newSettings = ParseAnalysisSettings(rawfile.BaseName, fixedsSettingsForAnalyses, fixedUIsettings);
                            Log.Information("[" + fileNameFullPath + "] Main analysis starting using: " + newSettings.Name);
                            model.Analyze(rawfile, fixedUIsettings, newSettings, resultRow);

                        }
                        Log.Information("[" + fileNameFullPath + "] Done, ready for next file");
                    }
                    catch (Exception e)
                    {
                        Log.Fatal("[" + fileNameFullPath + "] FAILED ANALYSIS! Error: " + e.Message);
                    }
                }


            }
        }

        //this can be made more elegant so no string matching is required.
        private SettingsForAnalysis ParseAnalysisSettings(string rawfile, List<SettingsForAnalysis> analyses, UIsettings uisettings)
        {
            SettingsForAnalysis returnSettings = null;
            if (uisettings.UseCodeName)
            {

                for (int i = 0; i < uisettings.codeNames.Count; i++)
                {
                    if (uisettings.codeNames[i].IsMatch(rawfile))
                    {
                        foreach (SettingsForAnalysis settingsForAnalysis in analyses)
                        {
                            if (settingsForAnalysis.Name == uisettings.codeNames[i].WorkflowName)
                            {
                                returnSettings = settingsForAnalysis;
                            }
                        }
                        i = uisettings.codeNames.Count;
                    }
                }
            }
            else
            {
                returnSettings = analyses[uisettings.SelectedWorkflowAutomaticDefault];
            }
            return returnSettings;
        }



        private void Load()
        {
            string fileName;

            //fileName = Path.Combine(Application.UserAppDataPath, "appSettings3.json");
            fileName = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");

            if (File.Exists(fileName))
            {
                uisettings = Newtonsoft.Json.JsonConvert.DeserializeObject<UIsettings>(File.ReadAllText(fileName));
            }
            else
            {
                uisettings = new UIsettings();
            }




            //fileName = Path.Combine(Application.UserAppDataPath, "workflows.json");
            fileName = Path.Combine(Directory.GetCurrentDirectory(), "workflows.json");
            if (File.Exists(fileName))
            {
                List<SettingsForAnalysis> newWorkflowList =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<List<SettingsForAnalysis>>(File.ReadAllText(fileName));
                foreach (SettingsForAnalysis workflowItem in newWorkflowList)
                {
                    workflowList.Add(workflowItem);
                }
            }
            if (workflowList.Count == 0)
            {
                workflowList.Add(new SettingsForAnalysis("Default"));
            }
            if (uisettings.codeNames.Count == 0)
            {
                uisettings.codeNames.Add(new CodeName(".*", "Default"));
            }
            if (uisettings.informationKey.Count == 0)
            {
                uisettings.informationKey.Add(new InformationKey());
                //could also be the button add call?
            }
        }

        public void AddFixedMod(int fixedModificationIndex)
        {
            if (uisettings.SelectedWorkflow > -1)
            {
                SettingsForAnalysis currentSettings = workflowList[uisettings.SelectedWorkflow];
                if (currentSettings != null)
                {
                    string newMod = uisettings.modificationList1[fixedModificationIndex].ToString();
                    bool found = currentSettings.fixedModifications.Any(x => x.ToString().Equals(newMod));
                    if (!found)
                    {
                        fixedMods.Add(uisettings.modificationList1[fixedModificationIndex]);
                    }
                }
            }
        }
        public void AddVariableMod(int variableModificationIndex)
        {
            if (uisettings.SelectedWorkflow > -1)
            {
                SettingsForAnalysis currentSettings = workflowList[uisettings.SelectedWorkflow];
                if (currentSettings != null)
                {
                    string newMod = uisettings.modificationList2[variableModificationIndex].ToString();
                    bool found = currentSettings.variableModifications.Any(x => x.ToString().Equals(newMod));
                    if (!found)
                    {
                        variableMods.Add(uisettings.modificationList2[variableModificationIndex]);
                    }
                }
            }
        }
        public void RemoveFixedMod(int index)
        {
            if (index > -1)
            {
                /*
                SettingsForAnalysis currentSettings = (SettingsForAnalysis)workflows.Current;
                if (currentSettings != null)
                {
                    currentSettings.fixedModifications.RemoveAt(index);
                }
                */
                fixedMods.RemoveAt(index);
            }
            
        }
        public void RemoveVariableMod(int index)
        {
            if (index > -1)
            {
                /*
                SettingsForAnalysis currentSettings = (SettingsForAnalysis)workflows.Current;
                if (currentSettings != null)
                {
                    currentSettings.variableModifications.RemoveAt(index);
                }
                */
                variableMods.RemoveAt(index);
            }
        }

        public void Reset()
        {
            /*
            SettingsForAnalysis newSettings = new SettingsForAnalysis("Default");


            string settings_filepath = Path.Combine(Application.UserAppDataPath, "settings.tsv");



            if (File.Exists(settings_filepath))
            {
                try
                {
                    using (StreamReader settings = new StreamReader(settings_filepath))
                    {
                        while (settings.Peek() != -1)
                        {
                            string line = settings.ReadLine();
                            string[] fields = line.Split('\t');
                            string name = fields[0];
                            string value = fields[1];
                            string[] value_fields;

                            switch (name)
                            {
                                case "Minimum Assumed Precursor Charge State":
                                    newSettings.minimumAssumedPrecursorChargeState = int.Parse(value);
                                    break;
                                case "Maximum Assumed Precursor Charge State":
                                    newSettings.maximumAssumedPrecursorChargeState = int.Parse(value);
                                    break;
                                case "Absolute MS/MS Peak Threshold":
                                    value_fields = value.Split(',');
                                    newSettings.chkAbsoluteThreshold = bool.Parse(value_fields[0]);
                                    newSettings.txtAbsoluteThreshold = value_fields[1];
                                    break;
                                case "Relative MS/MS Peak Threshold (%)":
                                    value_fields = value.Split(',');
                                    newSettings.chkRelativeThreshold = bool.Parse(value_fields[0]);
                                    newSettings.txtRelativeThreshold = value_fields[1];
                                    break;
                                case "Maximum Number of MS/MS Peaks":
                                    value_fields = value.Split(',');
                                    newSettings.chkMaxNumPeaks = bool.Parse(value_fields[0]);
                                    newSettings.maximumNumberOfPeaks = int.Parse(value_fields[1]);
                                    break;
                                case "Assign Charge States":
                                    newSettings.assignChargeStates = bool.Parse(value);
                                    break;
                                case "De-isotope":
                                    newSettings.deisotope = bool.Parse(value);
                                    break;
                                case "Protease":
                                    newSettings.protease = int.Parse(value);
                                    break;
                                case "Maximum Missed Cleavages":
                                    newSettings.maximumMissedCleavages = int.Parse(value);
                                    break;
                                case "Initiator Methionine Behavior":
                                    newSettings.initiatorMethionineBehavior = (int)Enum.Parse(typeof(InitiatorMethionineBehavior), value, true);
                                    break;
                                case "Maximum Variable Modification Isoforms per Peptide":
                                    newSettings.maximumVariableModificationIsoforms = int.Parse(value);
                                    break;
                                case "Precursor Mass Tolerance":
                                    newSettings.precursorMassToleranceValue = double.Parse(value, CultureInfo.InvariantCulture);
                                    break;
                                case "Precursor Mass Tolerance Units":
                                    newSettings.precursorMassToleranceUnitsIndex = (int)Enum.Parse(typeof(MassToleranceUnits), value, true);
                                    break;
                                case "Precursor Mass Type":
                                    newSettings.precursorMassTypeIndex = (int)Enum.Parse(typeof(MassType), value, true);
                                    break;
                                case "Precursor Monoisotopic Peak Correction":
                                    if (newSettings.precursorMassTypeIndex == (int)MassType.Monoisotopic)
                                    {
                                        newSettings.precursorMonoisotopicPeakCorrection = bool.Parse(value);
                                    }
                                    break;
                                case "Minimum Precursor Offset":
                                    newSettings.minimumPrecursorMonoisotopicPeakOffset = int.Parse(value);
                                    break;
                                case "Maximum Precursor Offset":
                                    newSettings.maximumPrecursorMonoisotopicPeakOffset = int.Parse(value);
                                    break;
                                case "Product Mass Tolerance":
                                    newSettings.productMassToleranceValue = double.Parse(value, CultureInfo.InvariantCulture);
                                    break;
                                case "Product Mass Tolerance Units":
                                    newSettings.productMassToleranceUnitsIndex = (int)Enum.Parse(typeof(MassToleranceUnits), value, true);
                                    break;
                                case "Product Mass Type":
                                    newSettings.productMassTypeIndex = (int)Enum.Parse(typeof(MassType), value, true);
                                    break;
                                case "Maximum FDR (%)":
                                    newSettings.maximumFalseDiscoveryRatePercent = double.Parse(value, CultureInfo.InvariantCulture);
                                    break;
                                case "Consider Modified Forms as Unique Peptides":
                                    newSettings.considerModifiedFormsAsUniquePeptides = bool.Parse(value);
                                    break;
                                case "Maximum Threads":
                                    if (int.Parse(value) > Environment.ProcessorCount)
                                    {
                                        newSettings.maximumThreads = Environment.ProcessorCount;
                                    }
                                    else
                                    {
                                        newSettings.maximumThreads = int.Parse(value);
                                    }
                                    break;
                                case "Minimize Memory Usage":
                                    newSettings.minimizeMemoryUsage = bool.Parse(value);
                                    break;
                            }
                        }
                    }
                    return;
                }
                catch
                {
                    MessageBox.Show("Your settings file (" + settings_filepath + ") is likely corrupt. Defaults will be used.");
                }
            }
            this.uisettings.analysisSettings = newSettings;

            */
        }



        public string GetUIsettings()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(uisettings, Formatting.Indented);
        }
        public string GetWorkflows()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(workflows.Current,Formatting.Indented);
        }


        public void AddRawFiles()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Raw files(*.raw)|*.raw",
                CheckFileExists = true,
                Multiselect = true
            };

            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string file in fileDialog.FileNames)
                {
                    RawFileName newfile = new RawFileName(file);
                    if (newfile != null)
                    {
                        uisettings.rawFiles.Add(newfile);
                    }
                    
                    
                }
            }
        }
        public void AnalyzeAllRawfiles()
        {
            bool goodToGo = IsGoodToGo();
            if (goodToGo)
            {
                AnalysisLoop();
            }
        }
        private async void AnalysisLoop()
        {
            UIsettings fixedUIsettings = uisettings.Clone();
            SettingsForAnalysis fixSettingsForAnalysis = workflowList[uisettings.SelectedWorkflowManual].Clone();

            RawFileName[] newlist = new RawFileName[uisettings.rawFiles.Count];
            uisettings.rawFiles.CopyTo(newlist, 0);
            Progress<DataRow> resultRow = GetResultRow();
            //foreach (RawFileName rawfile in fixedUIsettings.rawFiles)
            foreach (RawFileName rawfile in newlist)
            {
                await Task.Run(() => model.Analyze(rawfile, fixedUIsettings, fixSettingsForAnalysis, resultRow));
            }
        }

        private bool IsGoodToGo()
        {
            if (!IsUIsettingsOK())
            {
                return false;
            }
            foreach (SettingsForAnalysis newSetting in workflowList)
            {
                if (!IsSettingsForAnalysisOK(newSetting))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsUIsettingsOK()
        {
            /*
             * Checks:
             * storage file is defined if specified
             * if searching, is everything defined incl. database
             * all codename workflows exists
             * if monitoring, is folder valid
             * if local temp storage, does it exists
             * if mail, can we connect
             * if sql, can we connect
             * selected workflow is not -1
            */
            if (uisettings == null)
            {
                MessageBox.Show("Something critical is wrong with the settings, try resetting everything", "Failed to start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (uisettings.UseCodeName)
            {
                List<string> settingsNames = workflowList.Select(x => x.Name).ToList();
                foreach (string workflowname in uisettings.codeNames.Select(x => x.WorkflowName))
                {
                    if (!settingsNames.Contains(workflowname))
                    {
                        MessageBox.Show("Use of code names enabled but " + workflowname + " do not match any workflows. Please fix this!", "Failed to start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            if (uisettings.UseStorageFile)
            {
                if (!IsValidFile(uisettings.Storagefile))
                {
                    MessageBox.Show("Something is wrong with the local storage file", "Failed to start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            if (uisettings.Chkfastlocaldrive)
            {
                if (!IsValidPath(uisettings.Fastlocaldrive))
                {
                    MessageBox.Show("Use of local storage is specified but no valid path is assigned", "Failed to start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            if (uisettings.UseEmail)
            {
                if (!model.CheckEmailServerConnection(uisettings.Mailserveradress, uisettings.Mailportname,
                    uisettings.Mailusername, uisettings.Mailpassword))
                {
                    MessageBox.Show("Mail enabled but failed to connect to server. Fix problem or disable mail notifications",
                        "Failed to start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            if (uisettings.UseSql)
            {
                if (!model.CheckSqlConnection(uisettings.Sqlserveradress, uisettings.Sqldatabase,
                    uisettings.Sqltable, uisettings.Sqlusername, uisettings.Sqlpassword))
                {
                    MessageBox.Show("SQL enabled but failed to connect. Fix problem or disable SQL storage",
                        "Failed to start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            return true;
        }
        private bool IsSettingsForAnalysisOK(SettingsForAnalysis newSettingsForAnalysis)
        {   
            /*
             * Checks:
             * storage file is defined if specified
             * if searching, is everything defined incl. database
             * all codename workflows exists
             * if monitoring, is folder valid
             * if local temp storage, does it exists
             * if mail, can we connect
             * if sql, can we connect
             * selected workflow is not -1
            */
            if (newSettingsForAnalysis == null)
            {
                MessageBox.Show("Something critical is wrong with the settings, try resetting everything", "Failed to start", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (newSettingsForAnalysis.UseMorpheusAnalysis)
            {
                if (!IsValidFile(newSettingsForAnalysis.proteomeDatabaseFilepath))
                {
                    MessageBox.Show("Something is wrong with the protein database file","Failed to start",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return false;
                }
            }
            return true;
        }

        private bool IsValidFile(string path)
        {
            if (path == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidPath(string path)
        {
            return true;
        }



        public void RemoveRawFilesFromList(List<RawFileName> selectedRawfiles)
        {
            foreach (RawFileName rawfile in selectedRawfiles)
            {
                uisettings.rawFiles.Remove(rawfile);
            }
        }
        public void CreateSqlTable()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to create a new table on the MySQL server?", "New table?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Progress<string> log = GetProgressItem();
                model.CreateSqlTable(uisettings.Sqlserveradress, uisettings.Sqldatabase, uisettings.Sqltable, uisettings.Sqlusername, uisettings.Sqlpassword, uisettings);
            }
        }
        public void CreateNewSqlColumns()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to update columns in the table on the MySQL server?", "Update columns?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Progress<string> log = GetProgressItem();
                model.CreateNewSqlColumns(uisettings.Sqlserveradress, uisettings.Sqldatabase, uisettings.Sqltable, uisettings.Sqlusername, uisettings.Sqlpassword, uisettings);
            }
        }
        public void CheckSqlConnection()
        {
            //Progress<string> log = GetProgressItem();
            if (model.CheckSqlConnection(uisettings.Sqlserveradress, uisettings.Sqldatabase, uisettings.Sqltable, uisettings.Sqlusername, uisettings.Sqlpassword))
            {
                MessageBox.Show("SQL connection successful!");
            }//consider handling different form of failures.
            
        }
        public string WatchBrowse()
        {
            string folderName;
            FolderBrowserDialog dialogbox = new FolderBrowserDialog();
            if (dialogbox.ShowDialog() == DialogResult.OK)
            {
                folderName = dialogbox.SelectedPath;
            }
            else
            {
                folderName = "";
            }
            return folderName;
        }
        

        public void NewWorkflow()
        {
            SettingsForAnalysis newSettings;
            if (uisettings.SelectedWorkflow < 0)
            {
                newSettings = new SettingsForAnalysis("");
            }
            else
            {
                newSettings = workflowList[uisettings.SelectedWorkflow].Clone();
            }
            int i = 1;
            bool flag = true;
            List<string> names = new List<string>();
            foreach (SettingsForAnalysis oneSetting in workflowList)
            {
                names.Add(oneSetting.Name);
            }
            while (flag)
            {
                string newName = "New " + i;
                if (!names.Contains(newName))
                {
                    newSettings.Name = newName;
                    workflowList.Add(newSettings);
                    flag = false;
                }
                i++;
            }
        }

        public void DeleteWorkflow()
        {
            if (workflowList.Count > 1 && uisettings.SelectedWorkflow > -1)
            {
                if (MessageBox.Show("Do you want to delete: " + workflowList[uisettings.SelectedWorkflow].Name,
                        "Delete Entry?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    workflowList.Remove(workflowList[uisettings.SelectedWorkflow]);
                    uisettings.SelectedWorkflow = 0;
                }
            }
        }

        public void AddInformationKey()
        {
            InformationKey newSettings = new InformationKey();
            int i = 1;
            bool flag = true;
            List<string> names = new List<string>();
            foreach (InformationKey oneSetting in uisettings.informationKey)
            {
                names.Add(oneSetting.Name);
            }
            while (flag)
            {
                string newName = "New " + i;
                if (!names.Contains(newName))
                {
                    newSettings.Name = newName;
                    uisettings.informationKey.Add(newSettings);
                    flag = false;
                }
                i++;
            }
        }
        public void RemoveInformationKey()
        {
            if (uisettings.informationKey.Count > 1 && uisettings.SelectedInformationKey > -1)
            {
                if (MessageBox.Show("Do you want to delete: " + uisettings.informationKey[uisettings.SelectedInformationKey].Name,
                        "Delete Entry?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    uisettings.informationKey.Remove(uisettings.informationKey[uisettings.SelectedInformationKey]);
                    uisettings.SelectedInformationKey = 0;
                }
            }
        }
        public void Save()
        {
            //uisettings
            
            string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
            //string settingsFilePath = Path.Combine(Application.UserAppDataPath, "appSettings3.json");
            string json = JsonConvert.SerializeObject(uisettings, Formatting.Indented);
            using (TextWriter writer = new StreamWriter(settingsFilePath))
            {
                writer.Write(json);
            }

            //workflows
            //settingsFilePath = Path.Combine(Application.UserAppDataPath, "workflows.json");
            settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "workflows.json");
            json = JsonConvert.SerializeObject(workflowList, Formatting.Indented);
            using (TextWriter writer = new StreamWriter(settingsFilePath))
            {
                writer.Write(json);
            }
        }
        public bool StartWatching(int watchIndex)
        {
//            List<SettingsForAnalysis> clonedSettings = new List<SettingsForAnalysis>();
//            foreach (SettingsForAnalysis existingSettings in workflowList)
//            {
//                clonedSettings.Add(existingSettings.Clone());
//            }
            //Progress<string> progress = GetProgressItem();
            Progress<DataRow> resultRow = GetResultRow();
//            UIsettings newUIsettings = uisettings.Clone();
            bool watcherStarted;
            if (IsGoodToGo())
            {
                watcherStarted =
                    StartWatcher(watchIndex, resultRow);
            }
            else
            {
                watcherStarted = false;
            }
            return watcherStarted;
        }

        public void CodeNameDelete()
        {
            int removeIndex = uisettings.SelectedCodeNameList;
            if (removeIndex > -1)
            {
                uisettings.codeNames.RemoveAt(removeIndex);
            }
        }

        public void CodeNameCheck(string filename)
        {
            if (filename.Length > 0)
            {
                /*
                List<string> matches = new List<string>();
                foreach (CodeName codeName in uisettings.codeNames)
                {
                    if (codeName.IsMatch(filename))
                    {
                        matches.Add(codeName.WorkflowName);
                    }
                }
                if (matches.Count > 1)
                {
                    MessageBox.Show("This workflow will be used: " + matches[0] + "\nAll these were found: " + String.Join(";", matches));
                }
                else if (matches.Count == 1)
                {
                    MessageBox.Show("This workflow will be used: " + matches[0]);
                }
                else
                {
                    MessageBox.Show("No matches found");
                }
                */
                string matches = CheckCodeName(filename, workflowList.ToList(), uisettings);
                MessageBox.Show("This workflow will be used: " + matches);
            }
        }

            /*
            public void CodeNameUpdate(int writeIndex)
            {
                if (writeIndex > -1)
                {
                    //uisettings.codeNames[writeIndex].Pattern = uisettings.CodePattern;
                    //uisettings.codeNames[writeIndex].WorkflowName = workflows.Current.ToString();
                }
            }

            public void CodeNameChange(int readIndex)
            {
                if (readIndex > -1)
                {
                    uisettings.CodePattern = ((CodeName)uisettings.codeNames[readIndex]).Pattern;
                    bool matchFound = false;
                    for (int i = 0; i < workflows.Count; i++)
                    {
                        string settingName = workflows[i].ToString();
                        if (settingName == ((CodeName)uisettings.codeNames[readIndex]).WorkflowName)
                        {
                            workflows.Position = i;
                            i = workflows.Count;
                            matchFound = true;
                        }
                    }
                    if (!matchFound)
                    {
                        workflows.Position = 0;
                    }
                }
            }

            public void CodeNameAdd()
            {
                if (uisettings.CodePattern.Length > 0)
                {
                    bool isNew = true;
                    foreach (CodeName existingCodeName in uisettings.codeNames)
                    {
                        if (existingCodeName.Pattern == uisettings.CodePattern)
                        {
                            isNew = false;
                        }
                    }
                    if (isNew)
                    {
                        uisettings.codeNames.Add(new CodeName(uisettings.CodePattern,workflows.Position.ToString()));
                    }
                    else
                    {
                        MessageBox.Show("Error: pattern already exists");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Need to enter a code name");
                }

            }*/
            //public void CodeNameUpdate(int selectedWorkflow)
            public void CodeNameUpdate(int selectedWorkflow)
        {
            int codeNameIndex = uisettings.SelectedCodeNameList;
            //string currentCodeName = workflows[uisettings.code].Name;
            string currentCodeName = workflowList[selectedWorkflow].Name;
            //string currentCodeName = ((SettingsForAnalysis)codeNameAnalysis.Current).Name;
            if (codeNameIndex > -1)
            {
               uisettings.codeNames[codeNameIndex].WorkflowName = currentCodeName;
            }
        }


        public void CodeNameAdd(int selectedWorkflow)
        {
            //string currentCodeName = workflows[uisettings.SelectedWorkflowAutomaticDefault].Name;
            string currentCodeName = workflowList[selectedWorkflow].Name;
            int i = 1;
            bool flag = true;
            List<string> patterns = uisettings.codeNames.Select(x => x.Pattern).ToList();
            while (flag)
            {
                string newPattern = "X" + i;
                if (!patterns.Contains(newPattern))
                {
                    uisettings.codeNames.Add(new CodeName(newPattern, currentCodeName));
                    flag = false;
                }
                i++;
            }

        }

        public void CodeNameDown()
        {
            int index = uisettings.SelectedCodeNameList;
            if (index >= 0 && uisettings.codeNames.Count > (index+1))
            {
                CodeName temp = uisettings.codeNames[index];
                uisettings.codeNames[index] = uisettings.codeNames[index + 1];
                uisettings.codeNames[index + 1] = temp;
                uisettings.SelectedCodeNameList++;
            }
        }
        public void CodeNameUp()
        {
            int index = uisettings.SelectedCodeNameList;
            if (index > 0 && uisettings.codeNames.Count > index)
            {
                CodeName temp = uisettings.codeNames[index];
                uisettings.codeNames[index] = uisettings.codeNames[index - 1];
                uisettings.codeNames[index - 1] = temp;
                uisettings.SelectedCodeNameList--;
            }
        }

        public void BrowseStorageFile()
        {
            uisettings.Storagefile = SaveFile("Tab separated file|*.txt");
        }

        public void BrowseExternalExecutable()
        {
            string filename =
                    OpenFile("Executable|*.exe|Any|*.*");
                uisettings.Executable = filename;
        }


        public void BrowseFasta()
        {
            if (uisettings.SelectedWorkflow > -1)
            {
                string filename =
                    OpenFile("FASTA proteome database files|*.fa;*.FA;*.faa;*.FAA;*.fas;*.FAS;*.fasta;*.FASTA;*" +
                             ".fsa;*.FSA|UniProt XML proteome database files|*.xml;*.XML");
                workflowList[uisettings.SelectedWorkflow].proteomeDatabaseFilepath = filename;
            }
        }
        //private help functions
        private string SaveFile(string filter = null)
        {
            string filename = "";
            using (SaveFileDialog ofdFasta = new SaveFileDialog())
            {
                if (filter != null)
                {
                    ofdFasta.Filter = filter;
                }
                if (ofdFasta.ShowDialog() == DialogResult.OK)
                {
                    filename = ofdFasta.FileName;
                }
            }
            return filename;
        }
        private string OpenFile(string filter = null)
        {
            string filename = "";
            using (OpenFileDialog ofdFasta = new OpenFileDialog())
            {
                if (filter != null)
                {
                    ofdFasta.Filter = filter;
                }
                if (ofdFasta.ShowDialog() == DialogResult.OK)
                {
                    filename = ofdFasta.FileName;
                }
            }
            return filename;
        }
        /*
        private Progress<string> GetProgressItem()
        {
            Progress<string> progress = new Progress<string>(logItem =>
            {
                if (log.Count > 500)
                {
                    log.RemoveAt(0);
                }
                log.Add(AddDate(logItem));
                
            });
            return progress;
        }*/
        private Progress<DataRow> GetResultRow()
        {
            Progress<DataRow> resultRow = new Progress<DataRow>(dataRow =>
            {
                //ResultTable.Merge(dataTable);
                ResultTable.ImportRow(dataRow);
            });
            return resultRow;
        }
        private string AddDate(string text)
        {
            string datePatt = @"yyyy-MM-dd HH:mm:ss";
            string curTime = DateTime.Now.ToString(datePatt);
            string newtext = "[" + curTime + " ] " + text;
            return newtext;
        }

        public void PasteDataToGridview(int tableIndex, int startRow)
        {
            string clipboard = Clipboard.GetData(DataFormats.Text) as string;
            char[] rowSplitter = { '\r', '\n' };
            string[] rowsInClipboard = clipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in rowsInClipboard)
            {
                FileNameCategoryRow newrow = new FileNameCategoryRow();
                if (newrow.TrySet(line))
                {
                    switch (tableIndex)
                    {
                        case 1:
                            if (uisettings.UserList.Count > startRow)
                            {
                                uisettings.UserList[startRow] = newrow;
                            }
                            else
                            {
                                uisettings.UserList.Add(newrow);
                            }
                            break;
                        case 2:
                            if (uisettings.SamplesList.Count > startRow)
                            {
                                uisettings.SamplesList[startRow] = newrow;
                            }
                            else
                            {
                                uisettings.SamplesList.Add(newrow);
                            }
                            break;
                        case 3:
                            if (uisettings.LcList.Count > startRow)
                            {
                                uisettings.LcList[startRow] = newrow;
                            }
                            else
                            {
                                uisettings.LcList.Add(newrow);
                            }
                            break;
                        case 4:
                            if (uisettings.MsList.Count > startRow)
                            {
                                uisettings.MsList[startRow] = newrow;
                            }
                            else
                            {
                                uisettings.MsList.Add(newrow);
                            }
                            break;
                    }
                    startRow++;
                }
            }
        }
        public void External1ResultNew()
        {
            uisettings.ExternalResults.Add(new ExternalResultParseSetting("FileName", "ResultColumnOrRow"));
        }

        public void External1ResultDelete(int removeIndex)
        {
            if (removeIndex > -1)
            {
                uisettings.ExternalResults.RemoveAt(removeIndex);
            }
        }



        public void TryParseRawFile()
        {
            MessageBox.Show(model.TryParseRawFile(uisettings));
        }


    }
}
