namespace AutoProt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Workflows = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.Morpheus = new System.Windows.Forms.TabPage();
            this.chkBxEnableMorpheus = new System.Windows.Forms.CheckBox();
            this.pnlMorpheus = new System.Windows.Forms.Panel();
            this.btnVariableModificationRemove = new System.Windows.Forms.Button();
            this.grpBxMorpheusPrecursor = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numMinimumAssumedPrecursorChargeState = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numMaximumAssumedPrecursorChargeState = new System.Windows.Forms.NumericUpDown();
            this.btnVariableModificationAdd = new System.Windows.Forms.Button();
            this.cboPrecursorMassToleranceUnits = new System.Windows.Forms.ComboBox();
            this.lstBxVariableModificationsSelected = new System.Windows.Forms.ListBox();
            this.numPrecursorMassTolerance = new System.Windows.Forms.NumericUpDown();
            this.lstBxVariableModificationsAll = new System.Windows.Forms.ListBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btnFixedModificationRemove = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.btnFixedModificationAdd = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.lstBxFixedModificationsSelected = new System.Windows.Forms.ListBox();
            this.cboPrecursorMassType = new System.Windows.Forms.ComboBox();
            this.lstBxFixedModificationsAll = new System.Windows.Forms.ListBox();
            this.label33 = new System.Windows.Forms.Label();
            this.chkMinimizeMemoryUsage = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.grpBxMorpheusMS2Analysis = new System.Windows.Forms.GroupBox();
            this.chkDeisotope = new System.Windows.Forms.CheckBox();
            this.chkAssignChargeStates = new System.Windows.Forms.CheckBox();
            this.numMaximumFalseDiscoveryRatePercent = new System.Windows.Forms.NumericUpDown();
            this.cboProductMassToleranceUnits = new System.Windows.Forms.ComboBox();
            this.grpBxMorpheusMS2Filtering = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtRelativeThresholdPercent = new System.Windows.Forms.TextBox();
            this.txtAbsoluteThreshold = new System.Windows.Forms.TextBox();
            this.chkMaxNumPeaks = new System.Windows.Forms.CheckBox();
            this.numMaxPeaks = new System.Windows.Forms.NumericUpDown();
            this.chkRelativeThreshold = new System.Windows.Forms.CheckBox();
            this.chkAbsoluteThreshold = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtFastaFile = new System.Windows.Forms.TextBox();
            this.numProductMassTolerance = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.numMaxThreads = new System.Windows.Forms.NumericUpDown();
            this.cboProductMassType = new System.Windows.Forms.ComboBox();
            this.btnBrowseFasta = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.numMaxVariableModIsoforms = new System.Windows.Forms.NumericUpDown();
            this.cboProtease = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.chkPrecursorMonoisotopicPeakCorrection = new System.Windows.Forms.CheckBox();
            this.chkConsiderModifiedUnique = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.chkOnTheFlyDecoys = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cboInitiatorMethionineBehavior = new System.Windows.Forms.ComboBox();
            this.numMaxPrecursorMonoPeakOffset = new System.Windows.Forms.NumericUpDown();
            this.numMinPrecursorMonoPeakOffset = new System.Windows.Forms.NumericUpDown();
            this.numMaxMissedCleavages = new System.Windows.Forms.NumericUpDown();
            this.Base = new System.Windows.Forms.TabPage();
            this.chkBxEnableBaseAnalysis = new System.Windows.Forms.CheckBox();
            this.pnlBaseParameters = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.numBaseThresholdFluctuationsPercent = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.grpBxFullMStargets = new System.Windows.Forms.GroupBox();
            this.numBasePolymerPercentile = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.numBaseAdductPercentile = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnBaseAdductReset = new System.Windows.Forms.Button();
            this.lblBaseAdductFixed = new System.Windows.Forms.Label();
            this.chkBxBaseAdductEnabled = new System.Windows.Forms.CheckBox();
            this.label69 = new System.Windows.Forms.Label();
            this.lstBxBaseAdducts = new System.Windows.Forms.ListBox();
            this.txtBxBaseAdductsMZ = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnBasePolymerReset = new System.Windows.Forms.Button();
            this.txtBxBasePolymerZ3 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerMz4 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerZ4 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerMz3 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerZ2 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerMz2 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerZ1 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerMz1 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.txtBxBasePolymerZ0 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.txtBxBasePolymerMz0 = new System.Windows.Forms.TextBox();
            this.txtBxBasePolymerName = new System.Windows.Forms.TextBox();
            this.lstBxBasePolymers = new System.Windows.Forms.ListBox();
            this.numBaseMassTolerance = new System.Windows.Forms.NumericUpDown();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.numBaseIonThreshold = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numBaseSNthreshold = new System.Windows.Forms.NumericUpDown();
            this.External = new System.Windows.Forms.TabPage();
            this.chkBxExternal1Enable = new System.Windows.Forms.CheckBox();
            this.lstBxWorkflows = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDeleteSettings = new System.Windows.Forms.Button();
            this.txtbxSettingName = new System.Windows.Forms.TextBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnNewSettings = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.AdvancedSettings = new System.Windows.Forms.TabPage();
            this.grpBxAdvancedStatusLog = new System.Windows.Forms.GroupBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.btnBaseStatusLogRemove = new System.Windows.Forms.Button();
            this.txtBxBaseStatusLogNewItems = new System.Windows.Forms.TextBox();
            this.btnBaseStatusLogAdd = new System.Windows.Forms.Button();
            this.chkBxBaseStatusLogCalcIQR = new System.Windows.Forms.CheckBox();
            this.chkBxBaseStatusLogCalcMedian = new System.Windows.Forms.CheckBox();
            this.chkBxBaseStatusLogCalcMax = new System.Windows.Forms.CheckBox();
            this.chkBxBaseStatusLogCalcMin = new System.Windows.Forms.CheckBox();
            this.lstBxBaseStatusLogItems = new System.Windows.Forms.ListBox();
            this.chkBxShowAdvanced = new System.Windows.Forms.CheckBox();
            this.grpBxAdvancedExternalTool1 = new System.Windows.Forms.GroupBox();
            this.label84 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.txtBxExternal1ResultName = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdBtnExternal1SplitTab = new System.Windows.Forms.RadioButton();
            this.rdBtnExternal1SplitSemicolon = new System.Windows.Forms.RadioButton();
            this.rdBtnExternal1Column = new System.Windows.Forms.RadioButton();
            this.rdBtnExternal1Row = new System.Windows.Forms.RadioButton();
            this.lstBxExternal1 = new System.Windows.Forms.ListBox();
            this.btnExternal1Remove = new System.Windows.Forms.Button();
            this.txtBxExternal1ResultFile = new System.Windows.Forms.TextBox();
            this.btnExternal1New = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.numExternalTimeout = new System.Windows.Forms.NumericUpDown();
            this.txtBxExternal1Arguments = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.txtBxExternal1Executable = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnExternal1Browse = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.ManualAnalysis = new System.Windows.Forms.TabPage();
            this.lstBxRawFiles = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBxAnalysisSettingsManual = new System.Windows.Forms.ComboBox();
            this.Analyze = new System.Windows.Forms.Button();
            this.btnRemoveRawFiles = new System.Windows.Forms.Button();
            this.addRawFilesBtn = new System.Windows.Forms.Button();
            this.AutomatedAnalysis = new System.Windows.Forms.TabPage();
            this.cmbBxAutomatedDefault = new System.Windows.Forms.ComboBox();
            this.lblAutomatedSelectWorkflow = new System.Windows.Forms.Label();
            this.pnlCodeNam = new System.Windows.Forms.Panel();
            this.lstBxCodeToAnalysis = new System.Windows.Forms.ListBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtBxCodePattern = new System.Windows.Forms.TextBox();
            this.btnCodeNameCheck = new System.Windows.Forms.Button();
            this.btnAddAnalysisCode = new System.Windows.Forms.Button();
            this.txtBxCodeNameCheck = new System.Windows.Forms.TextBox();
            this.lblCodeName = new System.Windows.Forms.Label();
            this.btnCodeNameDown = new System.Windows.Forms.Button();
            this.btnDeleteAnalysisCode = new System.Windows.Forms.Button();
            this.btnCodeNameUp = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lblCodeNameToAnalysis = new System.Windows.Forms.Label();
            this.cmbBxCodeName = new System.Windows.Forms.ComboBox();
            this.btnBrowseFastLocal = new System.Windows.Forms.Button();
            this.chkBxCodeName = new System.Windows.Forms.CheckBox();
            this.txtBxFastLocal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnWatch1 = new System.Windows.Forms.Button();
            this.btnWatchBrowse1 = new System.Windows.Forms.Button();
            this.txtBxWatchFolder0 = new System.Windows.Forms.TextBox();
            this.txtBxWatchFolder2 = new System.Windows.Forms.TextBox();
            this.chkBxLocalFolder = new System.Windows.Forms.CheckBox();
            this.txtBxWatchFolder1 = new System.Windows.Forms.TextBox();
            this.btnWatchBrowse0 = new System.Windows.Forms.Button();
            this.btnWatchBrowse2 = new System.Windows.Forms.Button();
            this.btnWatch4 = new System.Windows.Forms.Button();
            this.btnWatch0 = new System.Windows.Forms.Button();
            this.btnWatch2 = new System.Windows.Forms.Button();
            this.btnWatchBrowse4 = new System.Windows.Forms.Button();
            this.txtBxWatchFolder3 = new System.Windows.Forms.TextBox();
            this.txtBxWatchFolder4 = new System.Windows.Forms.TextBox();
            this.btnWatchBrowse3 = new System.Windows.Forms.Button();
            this.btnWatch3 = new System.Windows.Forms.Button();
            this.ResultOverview = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.FileNameParseRules = new System.Windows.Forms.TabPage();
            this.btnTestRawFileCategories = new System.Windows.Forms.Button();
            this.txtBoxRawFileNamingTest = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.dgvMS = new System.Windows.Forms.DataGridView();
            this.dgvSample = new System.Windows.Forms.DataGridView();
            this.dgvLC = new System.Windows.Forms.DataGridView();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.EmailAndStorage = new System.Windows.Forms.TabPage();
            this.chkBxEmail = new System.Windows.Forms.CheckBox();
            this.mailPanel = new System.Windows.Forms.Panel();
            this.txtBxMailServer = new System.Windows.Forms.TextBox();
            this.txtBxMailPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxMailUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxMailPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBxStorageFile = new System.Windows.Forms.CheckBox();
            this.pnlStorageFile = new System.Windows.Forms.Panel();
            this.label38 = new System.Windows.Forms.Label();
            this.btnStorageFile = new System.Windows.Forms.Button();
            this.txtBxStorageFile = new System.Windows.Forms.TextBox();
            this.chkBxStorageSql = new System.Windows.Forms.CheckBox();
            this.pnlStorageSql = new System.Windows.Forms.Panel();
            this.txtBxSqlServerTable = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreateNewColumnsSqlTable = new System.Windows.Forms.Button();
            this.btnSqlServerTestConnection = new System.Windows.Forms.Button();
            this.btnCreateSqlTable = new System.Windows.Forms.Button();
            this.txtBxSqlServerAddress = new System.Windows.Forms.TextBox();
            this.txtBxSqlServerDatabase = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBxSqlServerUser = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBxSqlServerPass = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ResultInterpretation = new System.Windows.Forms.TabPage();
            this.label61 = new System.Windows.Forms.Label();
            this.txtBxRIName = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.txtBxRIMessage = new System.Windows.Forms.TextBox();
            this.txtBxRICompareValue5 = new System.Windows.Forms.TextBox();
            this.cmbBxRIComparer5 = new System.Windows.Forms.ComboBox();
            this.cmbBxResultItem5 = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtBxRICompareValue4 = new System.Windows.Forms.TextBox();
            this.cmbBxRIComparer4 = new System.Windows.Forms.ComboBox();
            this.cmbBxResultItem4 = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.txtBxRICompareValue3 = new System.Windows.Forms.TextBox();
            this.cmbBxRIComparer3 = new System.Windows.Forms.ComboBox();
            this.cmbBxResultItem3 = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.txtBxRICompareValue2 = new System.Windows.Forms.TextBox();
            this.cmbBxRIComparer2 = new System.Windows.Forms.ComboBox();
            this.cmbBxResultItem2 = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtBxRICompareValue1 = new System.Windows.Forms.TextBox();
            this.cmbBxRIComparer1 = new System.Windows.Forms.ComboBox();
            this.cmbBxResultItem1 = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.btnRemoveInterpretationKey = new System.Windows.Forms.Button();
            this.btnAddInterpretationKey = new System.Windows.Forms.Button();
            this.lstBxInterpretation = new System.Windows.Forms.ListBox();
            this.LogView = new System.Windows.Forms.TabPage();
            this.log = new System.Windows.Forms.ListBox();
            this.Debug = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.Workflows.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.Morpheus.SuspendLayout();
            this.pnlMorpheus.SuspendLayout();
            this.grpBxMorpheusPrecursor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumAssumedPrecursorChargeState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumAssumedPrecursorChargeState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecursorMassTolerance)).BeginInit();
            this.grpBxMorpheusMS2Analysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumFalseDiscoveryRatePercent)).BeginInit();
            this.grpBxMorpheusMS2Filtering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPeaks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductMassTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxVariableModIsoforms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPrecursorMonoPeakOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPrecursorMonoPeakOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMissedCleavages)).BeginInit();
            this.Base.SuspendLayout();
            this.pnlBaseParameters.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseThresholdFluctuationsPercent)).BeginInit();
            this.grpBxFullMStargets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePolymerPercentile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseAdductPercentile)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseMassTolerance)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseIonThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseSNthreshold)).BeginInit();
            this.External.SuspendLayout();
            this.AdvancedSettings.SuspendLayout();
            this.grpBxAdvancedStatusLog.SuspendLayout();
            this.grpBxAdvancedExternalTool1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExternalTimeout)).BeginInit();
            this.ManualAnalysis.SuspendLayout();
            this.AutomatedAnalysis.SuspendLayout();
            this.pnlCodeNam.SuspendLayout();
            this.ResultOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.FileNameParseRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.EmailAndStorage.SuspendLayout();
            this.mailPanel.SuspendLayout();
            this.pnlStorageFile.SuspendLayout();
            this.pnlStorageSql.SuspendLayout();
            this.ResultInterpretation.SuspendLayout();
            this.LogView.SuspendLayout();
            this.Debug.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Workflows);
            this.tabControl1.Controls.Add(this.AdvancedSettings);
            this.tabControl1.Controls.Add(this.ManualAnalysis);
            this.tabControl1.Controls.Add(this.AutomatedAnalysis);
            this.tabControl1.Controls.Add(this.ResultOverview);
            this.tabControl1.Controls.Add(this.FileNameParseRules);
            this.tabControl1.Controls.Add(this.EmailAndStorage);
            this.tabControl1.Controls.Add(this.ResultInterpretation);
            this.tabControl1.Controls.Add(this.LogView);
            this.tabControl1.Controls.Add(this.Debug);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(1165, 669);
            this.tabControl1.TabIndex = 0;
            // 
            // Workflows
            // 
            this.Workflows.Controls.Add(this.tabControl3);
            this.Workflows.Controls.Add(this.lstBxWorkflows);
            this.Workflows.Controls.Add(this.label8);
            this.Workflows.Controls.Add(this.btnDeleteSettings);
            this.Workflows.Controls.Add(this.txtbxSettingName);
            this.Workflows.Controls.Add(this.btnSaveSettings);
            this.Workflows.Controls.Add(this.btnNewSettings);
            this.Workflows.Controls.Add(this.label10);
            this.Workflows.Location = new System.Drawing.Point(4, 22);
            this.Workflows.Name = "Workflows";
            this.Workflows.Size = new System.Drawing.Size(1157, 643);
            this.Workflows.TabIndex = 3;
            this.Workflows.Text = "Workflows";
            this.Workflows.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl3.Controls.Add(this.Morpheus);
            this.tabControl3.Controls.Add(this.Base);
            this.tabControl3.Controls.Add(this.External);
            this.tabControl3.Location = new System.Drawing.Point(258, 52);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.Size = new System.Drawing.Size(894, 576);
            this.tabControl3.TabIndex = 16;
            // 
            // Morpheus
            // 
            this.Morpheus.Controls.Add(this.chkBxEnableMorpheus);
            this.Morpheus.Controls.Add(this.pnlMorpheus);
            this.Morpheus.Location = new System.Drawing.Point(4, 22);
            this.Morpheus.Name = "Morpheus";
            this.Morpheus.Padding = new System.Windows.Forms.Padding(3);
            this.Morpheus.Size = new System.Drawing.Size(886, 550);
            this.Morpheus.TabIndex = 1;
            this.Morpheus.Text = "Morpheus";
            this.Morpheus.UseVisualStyleBackColor = true;
            // 
            // chkBxEnableMorpheus
            // 
            this.chkBxEnableMorpheus.AutoSize = true;
            this.chkBxEnableMorpheus.Checked = true;
            this.chkBxEnableMorpheus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxEnableMorpheus.Location = new System.Drawing.Point(6, 4);
            this.chkBxEnableMorpheus.Name = "chkBxEnableMorpheus";
            this.chkBxEnableMorpheus.Size = new System.Drawing.Size(108, 17);
            this.chkBxEnableMorpheus.TabIndex = 5;
            this.chkBxEnableMorpheus.Text = "Enable searching";
            this.chkBxEnableMorpheus.UseVisualStyleBackColor = true;
            this.chkBxEnableMorpheus.CheckedChanged += new System.EventHandler(this.chkBxEnableMorpheus_CheckedChanged);
            // 
            // pnlMorpheus
            // 
            this.pnlMorpheus.Controls.Add(this.btnVariableModificationRemove);
            this.pnlMorpheus.Controls.Add(this.grpBxMorpheusPrecursor);
            this.pnlMorpheus.Controls.Add(this.btnVariableModificationAdd);
            this.pnlMorpheus.Controls.Add(this.cboPrecursorMassToleranceUnits);
            this.pnlMorpheus.Controls.Add(this.lstBxVariableModificationsSelected);
            this.pnlMorpheus.Controls.Add(this.numPrecursorMassTolerance);
            this.pnlMorpheus.Controls.Add(this.lstBxVariableModificationsAll);
            this.pnlMorpheus.Controls.Add(this.label36);
            this.pnlMorpheus.Controls.Add(this.btnFixedModificationRemove);
            this.pnlMorpheus.Controls.Add(this.label35);
            this.pnlMorpheus.Controls.Add(this.btnFixedModificationAdd);
            this.pnlMorpheus.Controls.Add(this.label34);
            this.pnlMorpheus.Controls.Add(this.lstBxFixedModificationsSelected);
            this.pnlMorpheus.Controls.Add(this.cboPrecursorMassType);
            this.pnlMorpheus.Controls.Add(this.lstBxFixedModificationsAll);
            this.pnlMorpheus.Controls.Add(this.label33);
            this.pnlMorpheus.Controls.Add(this.chkMinimizeMemoryUsage);
            this.pnlMorpheus.Controls.Add(this.label32);
            this.pnlMorpheus.Controls.Add(this.grpBxMorpheusMS2Analysis);
            this.pnlMorpheus.Controls.Add(this.numMaximumFalseDiscoveryRatePercent);
            this.pnlMorpheus.Controls.Add(this.cboProductMassToleranceUnits);
            this.pnlMorpheus.Controls.Add(this.grpBxMorpheusMS2Filtering);
            this.pnlMorpheus.Controls.Add(this.label31);
            this.pnlMorpheus.Controls.Add(this.txtFastaFile);
            this.pnlMorpheus.Controls.Add(this.numProductMassTolerance);
            this.pnlMorpheus.Controls.Add(this.label22);
            this.pnlMorpheus.Controls.Add(this.label30);
            this.pnlMorpheus.Controls.Add(this.numMaxThreads);
            this.pnlMorpheus.Controls.Add(this.cboProductMassType);
            this.pnlMorpheus.Controls.Add(this.btnBrowseFasta);
            this.pnlMorpheus.Controls.Add(this.label29);
            this.pnlMorpheus.Controls.Add(this.label23);
            this.pnlMorpheus.Controls.Add(this.numMaxVariableModIsoforms);
            this.pnlMorpheus.Controls.Add(this.cboProtease);
            this.pnlMorpheus.Controls.Add(this.label28);
            this.pnlMorpheus.Controls.Add(this.chkPrecursorMonoisotopicPeakCorrection);
            this.pnlMorpheus.Controls.Add(this.chkConsiderModifiedUnique);
            this.pnlMorpheus.Controls.Add(this.label24);
            this.pnlMorpheus.Controls.Add(this.label27);
            this.pnlMorpheus.Controls.Add(this.label25);
            this.pnlMorpheus.Controls.Add(this.chkOnTheFlyDecoys);
            this.pnlMorpheus.Controls.Add(this.label26);
            this.pnlMorpheus.Controls.Add(this.cboInitiatorMethionineBehavior);
            this.pnlMorpheus.Controls.Add(this.numMaxPrecursorMonoPeakOffset);
            this.pnlMorpheus.Controls.Add(this.numMinPrecursorMonoPeakOffset);
            this.pnlMorpheus.Controls.Add(this.numMaxMissedCleavages);
            this.pnlMorpheus.Location = new System.Drawing.Point(6, 23);
            this.pnlMorpheus.Name = "pnlMorpheus";
            this.pnlMorpheus.Size = new System.Drawing.Size(736, 524);
            this.pnlMorpheus.TabIndex = 4;
            // 
            // btnVariableModificationRemove
            // 
            this.btnVariableModificationRemove.Location = new System.Drawing.Point(534, 386);
            this.btnVariableModificationRemove.Name = "btnVariableModificationRemove";
            this.btnVariableModificationRemove.Size = new System.Drawing.Size(22, 23);
            this.btnVariableModificationRemove.TabIndex = 97;
            this.btnVariableModificationRemove.Text = "<";
            this.btnVariableModificationRemove.UseVisualStyleBackColor = true;
            this.btnVariableModificationRemove.Click += new System.EventHandler(this.btnVariableModificationRemove_Click);
            // 
            // grpBxMorpheusPrecursor
            // 
            this.grpBxMorpheusPrecursor.Controls.Add(this.label13);
            this.grpBxMorpheusPrecursor.Controls.Add(this.numMinimumAssumedPrecursorChargeState);
            this.grpBxMorpheusPrecursor.Controls.Add(this.label17);
            this.grpBxMorpheusPrecursor.Controls.Add(this.numMaximumAssumedPrecursorChargeState);
            this.grpBxMorpheusPrecursor.Location = new System.Drawing.Point(3, 3);
            this.grpBxMorpheusPrecursor.Name = "grpBxMorpheusPrecursor";
            this.grpBxMorpheusPrecursor.Size = new System.Drawing.Size(186, 103);
            this.grpBxMorpheusPrecursor.TabIndex = 86;
            this.grpBxMorpheusPrecursor.TabStop = false;
            this.grpBxMorpheusPrecursor.Text = "Assumed Precursor Charge States (Unknowns Only)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Maximum";
            // 
            // numMinimumAssumedPrecursorChargeState
            // 
            this.numMinimumAssumedPrecursorChargeState.Location = new System.Drawing.Point(63, 35);
            this.numMinimumAssumedPrecursorChargeState.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numMinimumAssumedPrecursorChargeState.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinimumAssumedPrecursorChargeState.Name = "numMinimumAssumedPrecursorChargeState";
            this.numMinimumAssumedPrecursorChargeState.Size = new System.Drawing.Size(52, 20);
            this.numMinimumAssumedPrecursorChargeState.TabIndex = 1;
            this.numMinimumAssumedPrecursorChargeState.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Minimum";
            // 
            // numMaximumAssumedPrecursorChargeState
            // 
            this.numMaximumAssumedPrecursorChargeState.Location = new System.Drawing.Point(63, 65);
            this.numMaximumAssumedPrecursorChargeState.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numMaximumAssumedPrecursorChargeState.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaximumAssumedPrecursorChargeState.Name = "numMaximumAssumedPrecursorChargeState";
            this.numMaximumAssumedPrecursorChargeState.Size = new System.Drawing.Size(52, 20);
            this.numMaximumAssumedPrecursorChargeState.TabIndex = 3;
            this.numMaximumAssumedPrecursorChargeState.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btnVariableModificationAdd
            // 
            this.btnVariableModificationAdd.Location = new System.Drawing.Point(534, 344);
            this.btnVariableModificationAdd.Name = "btnVariableModificationAdd";
            this.btnVariableModificationAdd.Size = new System.Drawing.Size(22, 23);
            this.btnVariableModificationAdd.TabIndex = 96;
            this.btnVariableModificationAdd.Text = ">";
            this.btnVariableModificationAdd.UseVisualStyleBackColor = true;
            this.btnVariableModificationAdd.Click += new System.EventHandler(this.btnVariableModificationAdd_Click);
            // 
            // cboPrecursorMassToleranceUnits
            // 
            this.cboPrecursorMassToleranceUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrecursorMassToleranceUnits.FormattingEnabled = true;
            this.cboPrecursorMassToleranceUnits.Location = new System.Drawing.Point(100, 254);
            this.cboPrecursorMassToleranceUnits.Name = "cboPrecursorMassToleranceUnits";
            this.cboPrecursorMassToleranceUnits.Size = new System.Drawing.Size(59, 21);
            this.cboPrecursorMassToleranceUnits.TabIndex = 69;
            // 
            // lstBxVariableModificationsSelected
            // 
            this.lstBxVariableModificationsSelected.FormattingEnabled = true;
            this.lstBxVariableModificationsSelected.Location = new System.Drawing.Point(562, 309);
            this.lstBxVariableModificationsSelected.Name = "lstBxVariableModificationsSelected";
            this.lstBxVariableModificationsSelected.Size = new System.Drawing.Size(147, 134);
            this.lstBxVariableModificationsSelected.TabIndex = 95;
            // 
            // numPrecursorMassTolerance
            // 
            this.numPrecursorMassTolerance.DecimalPlaces = 3;
            this.numPrecursorMassTolerance.Location = new System.Drawing.Point(20, 255);
            this.numPrecursorMassTolerance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPrecursorMassTolerance.Name = "numPrecursorMassTolerance";
            this.numPrecursorMassTolerance.Size = new System.Drawing.Size(74, 20);
            this.numPrecursorMassTolerance.TabIndex = 68;
            this.numPrecursorMassTolerance.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lstBxVariableModificationsAll
            // 
            this.lstBxVariableModificationsAll.FormattingEnabled = true;
            this.lstBxVariableModificationsAll.Location = new System.Drawing.Point(381, 309);
            this.lstBxVariableModificationsAll.Name = "lstBxVariableModificationsAll";
            this.lstBxVariableModificationsAll.Size = new System.Drawing.Size(147, 134);
            this.lstBxVariableModificationsAll.TabIndex = 94;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(7, 239);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(131, 13);
            this.label36.TabIndex = 66;
            this.label36.Text = "Precursor Mass Tolerance";
            // 
            // btnFixedModificationRemove
            // 
            this.btnFixedModificationRemove.Location = new System.Drawing.Point(159, 386);
            this.btnFixedModificationRemove.Name = "btnFixedModificationRemove";
            this.btnFixedModificationRemove.Size = new System.Drawing.Size(22, 23);
            this.btnFixedModificationRemove.TabIndex = 93;
            this.btnFixedModificationRemove.Text = "<";
            this.btnFixedModificationRemove.UseVisualStyleBackColor = true;
            this.btnFixedModificationRemove.Click += new System.EventHandler(this.btnFixedModificationRemove_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(7, 257);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(13, 13);
            this.label35.TabIndex = 67;
            this.label35.Text = "±";
            // 
            // btnFixedModificationAdd
            // 
            this.btnFixedModificationAdd.Location = new System.Drawing.Point(159, 344);
            this.btnFixedModificationAdd.Name = "btnFixedModificationAdd";
            this.btnFixedModificationAdd.Size = new System.Drawing.Size(22, 23);
            this.btnFixedModificationAdd.TabIndex = 92;
            this.btnFixedModificationAdd.Text = ">";
            this.btnFixedModificationAdd.UseVisualStyleBackColor = true;
            this.btnFixedModificationAdd.Click += new System.EventHandler(this.btnFixedModificationAdd_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(3, 461);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(251, 13);
            this.label34.TabIndex = 64;
            this.label34.Text = "Maximum Variable Modification Isoforms per Peptide";
            // 
            // lstBxFixedModificationsSelected
            // 
            this.lstBxFixedModificationsSelected.FormattingEnabled = true;
            this.lstBxFixedModificationsSelected.Location = new System.Drawing.Point(187, 309);
            this.lstBxFixedModificationsSelected.Name = "lstBxFixedModificationsSelected";
            this.lstBxFixedModificationsSelected.Size = new System.Drawing.Size(147, 134);
            this.lstBxFixedModificationsSelected.TabIndex = 91;
            // 
            // cboPrecursorMassType
            // 
            this.cboPrecursorMassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrecursorMassType.FormattingEnabled = true;
            this.cboPrecursorMassType.Location = new System.Drawing.Point(165, 254);
            this.cboPrecursorMassType.Name = "cboPrecursorMassType";
            this.cboPrecursorMassType.Size = new System.Drawing.Size(106, 21);
            this.cboPrecursorMassType.TabIndex = 70;
            // 
            // lstBxFixedModificationsAll
            // 
            this.lstBxFixedModificationsAll.FormattingEnabled = true;
            this.lstBxFixedModificationsAll.Location = new System.Drawing.Point(6, 309);
            this.lstBxFixedModificationsAll.Name = "lstBxFixedModificationsAll";
            this.lstBxFixedModificationsAll.Size = new System.Drawing.Size(147, 134);
            this.lstBxFixedModificationsAll.TabIndex = 90;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(476, 489);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(15, 13);
            this.label33.TabIndex = 82;
            this.label33.Text = "%";
            // 
            // chkMinimizeMemoryUsage
            // 
            this.chkMinimizeMemoryUsage.AutoSize = true;
            this.chkMinimizeMemoryUsage.Location = new System.Drawing.Point(216, 493);
            this.chkMinimizeMemoryUsage.Name = "chkMinimizeMemoryUsage";
            this.chkMinimizeMemoryUsage.Size = new System.Drawing.Size(140, 17);
            this.chkMinimizeMemoryUsage.TabIndex = 89;
            this.chkMinimizeMemoryUsage.Text = "Minimize Memory Usage";
            this.chkMinimizeMemoryUsage.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(297, 239);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(123, 13);
            this.label32.TabIndex = 75;
            this.label32.Text = "Product Mass Tolerance";
            // 
            // grpBxMorpheusMS2Analysis
            // 
            this.grpBxMorpheusMS2Analysis.Controls.Add(this.chkDeisotope);
            this.grpBxMorpheusMS2Analysis.Controls.Add(this.chkAssignChargeStates);
            this.grpBxMorpheusMS2Analysis.Location = new System.Drawing.Point(493, 3);
            this.grpBxMorpheusMS2Analysis.Name = "grpBxMorpheusMS2Analysis";
            this.grpBxMorpheusMS2Analysis.Size = new System.Drawing.Size(198, 103);
            this.grpBxMorpheusMS2Analysis.TabIndex = 88;
            this.grpBxMorpheusMS2Analysis.TabStop = false;
            this.grpBxMorpheusMS2Analysis.Text = "MS/MS Analysis";
            // 
            // chkDeisotope
            // 
            this.chkDeisotope.AutoSize = true;
            this.chkDeisotope.Enabled = false;
            this.chkDeisotope.Location = new System.Drawing.Point(10, 65);
            this.chkDeisotope.Name = "chkDeisotope";
            this.chkDeisotope.Size = new System.Drawing.Size(77, 17);
            this.chkDeisotope.TabIndex = 1;
            this.chkDeisotope.Text = "De-isotope";
            this.chkDeisotope.UseVisualStyleBackColor = true;
            // 
            // chkAssignChargeStates
            // 
            this.chkAssignChargeStates.AutoSize = true;
            this.chkAssignChargeStates.Checked = true;
            this.chkAssignChargeStates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAssignChargeStates.Location = new System.Drawing.Point(10, 33);
            this.chkAssignChargeStates.Name = "chkAssignChargeStates";
            this.chkAssignChargeStates.Size = new System.Drawing.Size(127, 17);
            this.chkAssignChargeStates.TabIndex = 0;
            this.chkAssignChargeStates.Text = "Assign Charge States";
            this.chkAssignChargeStates.UseVisualStyleBackColor = true;
            // 
            // numMaximumFalseDiscoveryRatePercent
            // 
            this.numMaximumFalseDiscoveryRatePercent.DecimalPlaces = 2;
            this.numMaximumFalseDiscoveryRatePercent.Location = new System.Drawing.Point(497, 487);
            this.numMaximumFalseDiscoveryRatePercent.Name = "numMaximumFalseDiscoveryRatePercent";
            this.numMaximumFalseDiscoveryRatePercent.Size = new System.Drawing.Size(54, 20);
            this.numMaximumFalseDiscoveryRatePercent.TabIndex = 81;
            this.numMaximumFalseDiscoveryRatePercent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboProductMassToleranceUnits
            // 
            this.cboProductMassToleranceUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductMassToleranceUnits.FormattingEnabled = true;
            this.cboProductMassToleranceUnits.Location = new System.Drawing.Point(390, 254);
            this.cboProductMassToleranceUnits.Name = "cboProductMassToleranceUnits";
            this.cboProductMassToleranceUnits.Size = new System.Drawing.Size(59, 21);
            this.cboProductMassToleranceUnits.TabIndex = 78;
            // 
            // grpBxMorpheusMS2Filtering
            // 
            this.grpBxMorpheusMS2Filtering.Controls.Add(this.label19);
            this.grpBxMorpheusMS2Filtering.Controls.Add(this.txtRelativeThresholdPercent);
            this.grpBxMorpheusMS2Filtering.Controls.Add(this.txtAbsoluteThreshold);
            this.grpBxMorpheusMS2Filtering.Controls.Add(this.chkMaxNumPeaks);
            this.grpBxMorpheusMS2Filtering.Controls.Add(this.numMaxPeaks);
            this.grpBxMorpheusMS2Filtering.Controls.Add(this.chkRelativeThreshold);
            this.grpBxMorpheusMS2Filtering.Controls.Add(this.chkAbsoluteThreshold);
            this.grpBxMorpheusMS2Filtering.Location = new System.Drawing.Point(195, 3);
            this.grpBxMorpheusMS2Filtering.Name = "grpBxMorpheusMS2Filtering";
            this.grpBxMorpheusMS2Filtering.Size = new System.Drawing.Size(292, 103);
            this.grpBxMorpheusMS2Filtering.TabIndex = 87;
            this.grpBxMorpheusMS2Filtering.TabStop = false;
            this.grpBxMorpheusMS2Filtering.Text = "MS/MS Peak Filtering";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Location = new System.Drawing.Point(236, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "%";
            // 
            // txtRelativeThresholdPercent
            // 
            this.txtRelativeThresholdPercent.Enabled = false;
            this.txtRelativeThresholdPercent.Location = new System.Drawing.Point(171, 44);
            this.txtRelativeThresholdPercent.Name = "txtRelativeThresholdPercent";
            this.txtRelativeThresholdPercent.Size = new System.Drawing.Size(65, 20);
            this.txtRelativeThresholdPercent.TabIndex = 3;
            this.txtRelativeThresholdPercent.Text = "1";
            // 
            // txtAbsoluteThreshold
            // 
            this.txtAbsoluteThreshold.Enabled = false;
            this.txtAbsoluteThreshold.Location = new System.Drawing.Point(171, 18);
            this.txtAbsoluteThreshold.Name = "txtAbsoluteThreshold";
            this.txtAbsoluteThreshold.Size = new System.Drawing.Size(80, 20);
            this.txtAbsoluteThreshold.TabIndex = 1;
            this.txtAbsoluteThreshold.Text = "1";
            // 
            // chkMaxNumPeaks
            // 
            this.chkMaxNumPeaks.AutoSize = true;
            this.chkMaxNumPeaks.Checked = true;
            this.chkMaxNumPeaks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMaxNumPeaks.Location = new System.Drawing.Point(10, 74);
            this.chkMaxNumPeaks.Name = "chkMaxNumPeaks";
            this.chkMaxNumPeaks.Size = new System.Drawing.Size(155, 17);
            this.chkMaxNumPeaks.TabIndex = 5;
            this.chkMaxNumPeaks.Text = "Maximum Number of Peaks";
            this.chkMaxNumPeaks.UseVisualStyleBackColor = true;
            this.chkMaxNumPeaks.CheckedChanged += new System.EventHandler(this.chkMaxNumPeaks_CheckedChanged);
            // 
            // numMaxPeaks
            // 
            this.numMaxPeaks.Location = new System.Drawing.Point(171, 71);
            this.numMaxPeaks.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxPeaks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxPeaks.Name = "numMaxPeaks";
            this.numMaxPeaks.Size = new System.Drawing.Size(65, 20);
            this.numMaxPeaks.TabIndex = 6;
            this.numMaxPeaks.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // chkRelativeThreshold
            // 
            this.chkRelativeThreshold.AutoSize = true;
            this.chkRelativeThreshold.Location = new System.Drawing.Point(10, 48);
            this.chkRelativeThreshold.Name = "chkRelativeThreshold";
            this.chkRelativeThreshold.Size = new System.Drawing.Size(115, 17);
            this.chkRelativeThreshold.TabIndex = 2;
            this.chkRelativeThreshold.Text = "Relative Threshold";
            this.chkRelativeThreshold.UseVisualStyleBackColor = true;
            this.chkRelativeThreshold.CheckedChanged += new System.EventHandler(this.chkRelativeThreshold_CheckedChanged);
            // 
            // chkAbsoluteThreshold
            // 
            this.chkAbsoluteThreshold.AutoSize = true;
            this.chkAbsoluteThreshold.Location = new System.Drawing.Point(10, 22);
            this.chkAbsoluteThreshold.Name = "chkAbsoluteThreshold";
            this.chkAbsoluteThreshold.Size = new System.Drawing.Size(117, 17);
            this.chkAbsoluteThreshold.TabIndex = 0;
            this.chkAbsoluteThreshold.Text = "Absolute Threshold";
            this.chkAbsoluteThreshold.UseVisualStyleBackColor = true;
            this.chkAbsoluteThreshold.CheckedChanged += new System.EventHandler(this.chkAbsoluteThreshold_CheckedChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(402, 489);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(76, 13);
            this.label31.TabIndex = 80;
            this.label31.Text = "Maximum FDR";
            // 
            // txtFastaFile
            // 
            this.txtFastaFile.Location = new System.Drawing.Point(3, 135);
            this.txtFastaFile.Name = "txtFastaFile";
            this.txtFastaFile.Size = new System.Drawing.Size(607, 20);
            this.txtFastaFile.TabIndex = 51;
            // 
            // numProductMassTolerance
            // 
            this.numProductMassTolerance.DecimalPlaces = 3;
            this.numProductMassTolerance.Location = new System.Drawing.Point(310, 255);
            this.numProductMassTolerance.Name = "numProductMassTolerance";
            this.numProductMassTolerance.Size = new System.Drawing.Size(74, 20);
            this.numProductMassTolerance.TabIndex = 77;
            this.numProductMassTolerance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(0, 119);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(198, 13);
            this.label22.TabIndex = 50;
            this.label22.Text = "Proteome Database (.fasta, UniProt .xml)";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(297, 257);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 76;
            this.label30.Text = "±";
            // 
            // numMaxThreads
            // 
            this.numMaxThreads.Location = new System.Drawing.Point(102, 492);
            this.numMaxThreads.Name = "numMaxThreads";
            this.numMaxThreads.Size = new System.Drawing.Size(51, 20);
            this.numMaxThreads.TabIndex = 85;
            this.numMaxThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboProductMassType
            // 
            this.cboProductMassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductMassType.FormattingEnabled = true;
            this.cboProductMassType.Location = new System.Drawing.Point(455, 254);
            this.cboProductMassType.Name = "cboProductMassType";
            this.cboProductMassType.Size = new System.Drawing.Size(106, 21);
            this.cboProductMassType.TabIndex = 79;
            // 
            // btnBrowseFasta
            // 
            this.btnBrowseFasta.Location = new System.Drawing.Point(616, 133);
            this.btnBrowseFasta.Name = "btnBrowseFasta";
            this.btnBrowseFasta.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFasta.TabIndex = 52;
            this.btnBrowseFasta.Text = "Browse";
            this.btnBrowseFasta.UseVisualStyleBackColor = true;
            this.btnBrowseFasta.Click += new System.EventHandler(this.btnBrowseFasta_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(378, 294);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(110, 13);
            this.label29.TabIndex = 62;
            this.label29.Text = "Variable Modifications";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 494);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 13);
            this.label23.TabIndex = 84;
            this.label23.Text = "Maximum Threads";
            // 
            // numMaxVariableModIsoforms
            // 
            this.numMaxVariableModIsoforms.Location = new System.Drawing.Point(260, 459);
            this.numMaxVariableModIsoforms.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMaxVariableModIsoforms.Name = "numMaxVariableModIsoforms";
            this.numMaxVariableModIsoforms.Size = new System.Drawing.Size(82, 20);
            this.numMaxVariableModIsoforms.TabIndex = 65;
            this.numMaxVariableModIsoforms.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // cboProtease
            // 
            this.cboProtease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProtease.FormattingEnabled = true;
            this.cboProtease.Location = new System.Drawing.Point(6, 206);
            this.cboProtease.Name = "cboProtease";
            this.cboProtease.Size = new System.Drawing.Size(186, 21);
            this.cboProtease.TabIndex = 55;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 294);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(97, 13);
            this.label28.TabIndex = 60;
            this.label28.Text = "Fixed Modifications";
            // 
            // chkPrecursorMonoisotopicPeakCorrection
            // 
            this.chkPrecursorMonoisotopicPeakCorrection.AutoSize = true;
            this.chkPrecursorMonoisotopicPeakCorrection.Location = new System.Drawing.Point(345, 457);
            this.chkPrecursorMonoisotopicPeakCorrection.Name = "chkPrecursorMonoisotopicPeakCorrection";
            this.chkPrecursorMonoisotopicPeakCorrection.Size = new System.Drawing.Size(216, 17);
            this.chkPrecursorMonoisotopicPeakCorrection.TabIndex = 71;
            this.chkPrecursorMonoisotopicPeakCorrection.Text = "Precursor Monoisotopic Peak Correction";
            this.chkPrecursorMonoisotopicPeakCorrection.UseVisualStyleBackColor = true;
            this.chkPrecursorMonoisotopicPeakCorrection.CheckedChanged += new System.EventHandler(this.chkMonoisotopicPeakCorrection_CheckedChanged);
            // 
            // chkConsiderModifiedUnique
            // 
            this.chkConsiderModifiedUnique.AutoSize = true;
            this.chkConsiderModifiedUnique.Location = new System.Drawing.Point(581, 480);
            this.chkConsiderModifiedUnique.Name = "chkConsiderModifiedUnique";
            this.chkConsiderModifiedUnique.Size = new System.Drawing.Size(141, 30);
            this.chkConsiderModifiedUnique.TabIndex = 83;
            this.chkConsiderModifiedUnique.Text = "Consider Modified Forms\r\nas Unique Peptides";
            this.chkConsiderModifiedUnique.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 190);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 13);
            this.label24.TabIndex = 54;
            this.label24.Text = "Protease";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(378, 190);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(141, 13);
            this.label27.TabIndex = 58;
            this.label27.Text = "Initiator Methionine Behavior";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Enabled = false;
            this.label25.Location = new System.Drawing.Point(629, 458);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 73;
            this.label25.Text = "to";
            // 
            // chkOnTheFlyDecoys
            // 
            this.chkOnTheFlyDecoys.AutoSize = true;
            this.chkOnTheFlyDecoys.Checked = true;
            this.chkOnTheFlyDecoys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnTheFlyDecoys.Location = new System.Drawing.Point(6, 162);
            this.chkOnTheFlyDecoys.Name = "chkOnTheFlyDecoys";
            this.chkOnTheFlyDecoys.Size = new System.Drawing.Size(231, 17);
            this.chkOnTheFlyDecoys.TabIndex = 53;
            this.chkOnTheFlyDecoys.Text = "Create Target–Decoy Database On The Fly";
            this.chkOnTheFlyDecoys.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(213, 189);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(140, 13);
            this.label26.TabIndex = 56;
            this.label26.Text = "Maximum Missed Cleavages";
            // 
            // cboInitiatorMethionineBehavior
            // 
            this.cboInitiatorMethionineBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInitiatorMethionineBehavior.FormattingEnabled = true;
            this.cboInitiatorMethionineBehavior.Location = new System.Drawing.Point(381, 206);
            this.cboInitiatorMethionineBehavior.Name = "cboInitiatorMethionineBehavior";
            this.cboInitiatorMethionineBehavior.Size = new System.Drawing.Size(138, 21);
            this.cboInitiatorMethionineBehavior.TabIndex = 59;
            // 
            // numMaxPrecursorMonoPeakOffset
            // 
            this.numMaxPrecursorMonoPeakOffset.Enabled = false;
            this.numMaxPrecursorMonoPeakOffset.Location = new System.Drawing.Point(651, 456);
            this.numMaxPrecursorMonoPeakOffset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxPrecursorMonoPeakOffset.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numMaxPrecursorMonoPeakOffset.Name = "numMaxPrecursorMonoPeakOffset";
            this.numMaxPrecursorMonoPeakOffset.Size = new System.Drawing.Size(54, 20);
            this.numMaxPrecursorMonoPeakOffset.TabIndex = 74;
            this.numMaxPrecursorMonoPeakOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMinPrecursorMonoPeakOffset
            // 
            this.numMinPrecursorMonoPeakOffset.Enabled = false;
            this.numMinPrecursorMonoPeakOffset.Location = new System.Drawing.Point(569, 456);
            this.numMinPrecursorMonoPeakOffset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMinPrecursorMonoPeakOffset.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numMinPrecursorMonoPeakOffset.Name = "numMinPrecursorMonoPeakOffset";
            this.numMinPrecursorMonoPeakOffset.Size = new System.Drawing.Size(54, 20);
            this.numMinPrecursorMonoPeakOffset.TabIndex = 72;
            this.numMinPrecursorMonoPeakOffset.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            // 
            // numMaxMissedCleavages
            // 
            this.numMaxMissedCleavages.Location = new System.Drawing.Point(216, 206);
            this.numMaxMissedCleavages.Name = "numMaxMissedCleavages";
            this.numMaxMissedCleavages.Size = new System.Drawing.Size(46, 20);
            this.numMaxMissedCleavages.TabIndex = 57;
            this.numMaxMissedCleavages.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Base
            // 
            this.Base.Controls.Add(this.chkBxEnableBaseAnalysis);
            this.Base.Controls.Add(this.pnlBaseParameters);
            this.Base.Location = new System.Drawing.Point(4, 22);
            this.Base.Name = "Base";
            this.Base.Padding = new System.Windows.Forms.Padding(3);
            this.Base.Size = new System.Drawing.Size(886, 550);
            this.Base.TabIndex = 0;
            this.Base.Text = "Base";
            this.Base.UseVisualStyleBackColor = true;
            // 
            // chkBxEnableBaseAnalysis
            // 
            this.chkBxEnableBaseAnalysis.AutoSize = true;
            this.chkBxEnableBaseAnalysis.Checked = true;
            this.chkBxEnableBaseAnalysis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxEnableBaseAnalysis.Location = new System.Drawing.Point(7, 4);
            this.chkBxEnableBaseAnalysis.Name = "chkBxEnableBaseAnalysis";
            this.chkBxEnableBaseAnalysis.Size = new System.Drawing.Size(166, 17);
            this.chkBxEnableBaseAnalysis.TabIndex = 5;
            this.chkBxEnableBaseAnalysis.Text = "Enable additional calculations";
            this.chkBxEnableBaseAnalysis.UseVisualStyleBackColor = true;
            this.chkBxEnableBaseAnalysis.CheckedChanged += new System.EventHandler(this.chkBxEnableBaseAnalysis_CheckedChanged);
            // 
            // pnlBaseParameters
            // 
            this.pnlBaseParameters.Controls.Add(this.groupBox10);
            this.pnlBaseParameters.Controls.Add(this.grpBxFullMStargets);
            this.pnlBaseParameters.Controls.Add(this.groupBox6);
            this.pnlBaseParameters.Controls.Add(this.groupBox1);
            this.pnlBaseParameters.Location = new System.Drawing.Point(0, 25);
            this.pnlBaseParameters.Name = "pnlBaseParameters";
            this.pnlBaseParameters.Size = new System.Drawing.Size(880, 529);
            this.pnlBaseParameters.TabIndex = 4;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.numBaseThresholdFluctuationsPercent);
            this.groupBox10.Controls.Add(this.label70);
            this.groupBox10.Location = new System.Drawing.Point(528, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(349, 56);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "For calculating #fluctuations";
            // 
            // numBaseThresholdFluctuationsPercent
            // 
            this.numBaseThresholdFluctuationsPercent.DecimalPlaces = 1;
            this.numBaseThresholdFluctuationsPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numBaseThresholdFluctuationsPercent.Location = new System.Drawing.Point(6, 23);
            this.numBaseThresholdFluctuationsPercent.Name = "numBaseThresholdFluctuationsPercent";
            this.numBaseThresholdFluctuationsPercent.Size = new System.Drawing.Size(74, 20);
            this.numBaseThresholdFluctuationsPercent.TabIndex = 2;
            this.numBaseThresholdFluctuationsPercent.Tag = "";
            this.numBaseThresholdFluctuationsPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBaseThresholdFluctuationsPercent.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(86, 25);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(235, 13);
            this.label70.TabIndex = 3;
            this.label70.Text = "Percentage threshold for full MS TIC fluctuations";
            // 
            // grpBxFullMStargets
            // 
            this.grpBxFullMStargets.Controls.Add(this.numBasePolymerPercentile);
            this.grpBxFullMStargets.Controls.Add(this.label72);
            this.grpBxFullMStargets.Controls.Add(this.numBaseAdductPercentile);
            this.grpBxFullMStargets.Controls.Add(this.label71);
            this.grpBxFullMStargets.Controls.Add(this.groupBox9);
            this.grpBxFullMStargets.Controls.Add(this.groupBox8);
            this.grpBxFullMStargets.Controls.Add(this.numBaseMassTolerance);
            this.grpBxFullMStargets.Controls.Add(this.label65);
            this.grpBxFullMStargets.Controls.Add(this.label64);
            this.grpBxFullMStargets.Location = new System.Drawing.Point(7, 65);
            this.grpBxFullMStargets.Name = "grpBxFullMStargets";
            this.grpBxFullMStargets.Size = new System.Drawing.Size(870, 268);
            this.grpBxFullMStargets.TabIndex = 5;
            this.grpBxFullMStargets.TabStop = false;
            this.grpBxFullMStargets.Text = "Full MS targets (attempt at polymer quantification and adducts)";
            // 
            // numBasePolymerPercentile
            // 
            this.numBasePolymerPercentile.DecimalPlaces = 1;
            this.numBasePolymerPercentile.Location = new System.Drawing.Point(521, 23);
            this.numBasePolymerPercentile.Name = "numBasePolymerPercentile";
            this.numBasePolymerPercentile.Size = new System.Drawing.Size(74, 20);
            this.numBasePolymerPercentile.TabIndex = 76;
            this.numBasePolymerPercentile.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(434, 25);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(84, 13);
            this.label72.TabIndex = 75;
            this.label72.Text = "Polymer quantile";
            // 
            // numBaseAdductPercentile
            // 
            this.numBaseAdductPercentile.DecimalPlaces = 1;
            this.numBaseAdductPercentile.Location = new System.Drawing.Point(315, 23);
            this.numBaseAdductPercentile.Name = "numBaseAdductPercentile";
            this.numBaseAdductPercentile.Size = new System.Drawing.Size(74, 20);
            this.numBaseAdductPercentile.TabIndex = 74;
            this.numBaseAdductPercentile.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(228, 25);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(81, 13);
            this.label71.TabIndex = 73;
            this.label71.Text = "Adduct quantile";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnBaseAdductReset);
            this.groupBox9.Controls.Add(this.lblBaseAdductFixed);
            this.groupBox9.Controls.Add(this.chkBxBaseAdductEnabled);
            this.groupBox9.Controls.Add(this.label69);
            this.groupBox9.Controls.Add(this.lstBxBaseAdducts);
            this.groupBox9.Controls.Add(this.txtBxBaseAdductsMZ);
            this.groupBox9.Location = new System.Drawing.Point(9, 49);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(359, 206);
            this.groupBox9.TabIndex = 72;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Adducts";
            // 
            // btnBaseAdductReset
            // 
            this.btnBaseAdductReset.Location = new System.Drawing.Point(215, 150);
            this.btnBaseAdductReset.Name = "btnBaseAdductReset";
            this.btnBaseAdductReset.Size = new System.Drawing.Size(75, 23);
            this.btnBaseAdductReset.TabIndex = 22;
            this.btnBaseAdductReset.Text = "Reset";
            this.btnBaseAdductReset.UseVisualStyleBackColor = true;
            this.btnBaseAdductReset.Click += new System.EventHandler(this.btnBaseAdductReset_Click);
            // 
            // lblBaseAdductFixed
            // 
            this.lblBaseAdductFixed.AutoSize = true;
            this.lblBaseAdductFixed.Location = new System.Drawing.Point(190, 80);
            this.lblBaseAdductFixed.Name = "lblBaseAdductFixed";
            this.lblBaseAdductFixed.Size = new System.Drawing.Size(127, 13);
            this.lblBaseAdductFixed.TabIndex = 21;
            this.lblBaseAdductFixed.Text = "This adduct is hardcoded";
            // 
            // chkBxBaseAdductEnabled
            // 
            this.chkBxBaseAdductEnabled.AutoSize = true;
            this.chkBxBaseAdductEnabled.Location = new System.Drawing.Point(191, 19);
            this.chkBxBaseAdductEnabled.Name = "chkBxBaseAdductEnabled";
            this.chkBxBaseAdductEnabled.Size = new System.Drawing.Size(116, 17);
            this.chkBxBaseAdductEnabled.TabIndex = 20;
            this.chkBxBaseAdductEnabled.Text = "Include this adduct";
            this.chkBxBaseAdductEnabled.UseVisualStyleBackColor = true;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(187, 41);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(32, 13);
            this.label69.TabIndex = 19;
            this.label69.Text = "Mass";
            // 
            // lstBxBaseAdducts
            // 
            this.lstBxBaseAdducts.FormattingEnabled = true;
            this.lstBxBaseAdducts.Location = new System.Drawing.Point(15, 19);
            this.lstBxBaseAdducts.Name = "lstBxBaseAdducts";
            this.lstBxBaseAdducts.Size = new System.Drawing.Size(169, 173);
            this.lstBxBaseAdducts.TabIndex = 15;
            // 
            // txtBxBaseAdductsMZ
            // 
            this.txtBxBaseAdductsMZ.Location = new System.Drawing.Point(190, 57);
            this.txtBxBaseAdductsMZ.Name = "txtBxBaseAdductsMZ";
            this.txtBxBaseAdductsMZ.ReadOnly = true;
            this.txtBxBaseAdductsMZ.Size = new System.Drawing.Size(100, 20);
            this.txtBxBaseAdductsMZ.TabIndex = 17;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnBasePolymerReset);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerZ3);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerMz4);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerZ4);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerMz3);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerZ2);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerMz2);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerZ1);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerMz1);
            this.groupBox8.Controls.Add(this.label68);
            this.groupBox8.Controls.Add(this.label67);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerZ0);
            this.groupBox8.Controls.Add(this.label66);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerMz0);
            this.groupBox8.Controls.Add(this.txtBxBasePolymerName);
            this.groupBox8.Controls.Add(this.lstBxBasePolymers);
            this.groupBox8.Location = new System.Drawing.Point(380, 49);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(484, 206);
            this.groupBox8.TabIndex = 71;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Full MS targets (attempt at polymers)";
            // 
            // btnBasePolymerReset
            // 
            this.btnBasePolymerReset.Location = new System.Drawing.Point(220, 160);
            this.btnBasePolymerReset.Name = "btnBasePolymerReset";
            this.btnBasePolymerReset.Size = new System.Drawing.Size(75, 23);
            this.btnBasePolymerReset.TabIndex = 23;
            this.btnBasePolymerReset.Text = "Reset";
            this.btnBasePolymerReset.UseVisualStyleBackColor = true;
            this.btnBasePolymerReset.Click += new System.EventHandler(this.btnBasePolymerReset_Click);
            // 
            // txtBxBasePolymerZ3
            // 
            this.txtBxBasePolymerZ3.Location = new System.Drawing.Point(436, 96);
            this.txtBxBasePolymerZ3.Name = "txtBxBasePolymerZ3";
            this.txtBxBasePolymerZ3.Size = new System.Drawing.Size(34, 20);
            this.txtBxBasePolymerZ3.TabIndex = 14;
            // 
            // txtBxBasePolymerMz4
            // 
            this.txtBxBasePolymerMz4.Location = new System.Drawing.Point(330, 119);
            this.txtBxBasePolymerMz4.Name = "txtBxBasePolymerMz4";
            this.txtBxBasePolymerMz4.Size = new System.Drawing.Size(100, 20);
            this.txtBxBasePolymerMz4.TabIndex = 14;
            // 
            // txtBxBasePolymerZ4
            // 
            this.txtBxBasePolymerZ4.Location = new System.Drawing.Point(436, 119);
            this.txtBxBasePolymerZ4.Name = "txtBxBasePolymerZ4";
            this.txtBxBasePolymerZ4.Size = new System.Drawing.Size(34, 20);
            this.txtBxBasePolymerZ4.TabIndex = 12;
            // 
            // txtBxBasePolymerMz3
            // 
            this.txtBxBasePolymerMz3.Location = new System.Drawing.Point(330, 96);
            this.txtBxBasePolymerMz3.Name = "txtBxBasePolymerMz3";
            this.txtBxBasePolymerMz3.Size = new System.Drawing.Size(100, 20);
            this.txtBxBasePolymerMz3.TabIndex = 11;
            // 
            // txtBxBasePolymerZ2
            // 
            this.txtBxBasePolymerZ2.Location = new System.Drawing.Point(436, 73);
            this.txtBxBasePolymerZ2.Name = "txtBxBasePolymerZ2";
            this.txtBxBasePolymerZ2.Size = new System.Drawing.Size(34, 20);
            this.txtBxBasePolymerZ2.TabIndex = 10;
            // 
            // txtBxBasePolymerMz2
            // 
            this.txtBxBasePolymerMz2.Location = new System.Drawing.Point(330, 73);
            this.txtBxBasePolymerMz2.Name = "txtBxBasePolymerMz2";
            this.txtBxBasePolymerMz2.Size = new System.Drawing.Size(100, 20);
            this.txtBxBasePolymerMz2.TabIndex = 9;
            // 
            // txtBxBasePolymerZ1
            // 
            this.txtBxBasePolymerZ1.Location = new System.Drawing.Point(436, 50);
            this.txtBxBasePolymerZ1.Name = "txtBxBasePolymerZ1";
            this.txtBxBasePolymerZ1.Size = new System.Drawing.Size(34, 20);
            this.txtBxBasePolymerZ1.TabIndex = 8;
            // 
            // txtBxBasePolymerMz1
            // 
            this.txtBxBasePolymerMz1.Location = new System.Drawing.Point(330, 50);
            this.txtBxBasePolymerMz1.Name = "txtBxBasePolymerMz1";
            this.txtBxBasePolymerMz1.Size = new System.Drawing.Size(100, 20);
            this.txtBxBasePolymerMz1.TabIndex = 7;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(433, 11);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(12, 13);
            this.label68.TabIndex = 6;
            this.label68.Text = "z";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(327, 11);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(25, 13);
            this.label67.TabIndex = 5;
            this.label67.Text = "m/z";
            // 
            // txtBxBasePolymerZ0
            // 
            this.txtBxBasePolymerZ0.Location = new System.Drawing.Point(436, 27);
            this.txtBxBasePolymerZ0.Name = "txtBxBasePolymerZ0";
            this.txtBxBasePolymerZ0.Size = new System.Drawing.Size(34, 20);
            this.txtBxBasePolymerZ0.TabIndex = 3;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(194, 11);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(35, 13);
            this.label66.TabIndex = 4;
            this.label66.Text = "Name";
            // 
            // txtBxBasePolymerMz0
            // 
            this.txtBxBasePolymerMz0.Location = new System.Drawing.Point(330, 27);
            this.txtBxBasePolymerMz0.Name = "txtBxBasePolymerMz0";
            this.txtBxBasePolymerMz0.Size = new System.Drawing.Size(100, 20);
            this.txtBxBasePolymerMz0.TabIndex = 2;
            // 
            // txtBxBasePolymerName
            // 
            this.txtBxBasePolymerName.Location = new System.Drawing.Point(197, 27);
            this.txtBxBasePolymerName.Name = "txtBxBasePolymerName";
            this.txtBxBasePolymerName.Size = new System.Drawing.Size(127, 20);
            this.txtBxBasePolymerName.TabIndex = 1;
            // 
            // lstBxBasePolymers
            // 
            this.lstBxBasePolymers.FormattingEnabled = true;
            this.lstBxBasePolymers.Location = new System.Drawing.Point(15, 19);
            this.lstBxBasePolymers.Name = "lstBxBasePolymers";
            this.lstBxBasePolymers.Size = new System.Drawing.Size(169, 173);
            this.lstBxBasePolymers.TabIndex = 0;
            // 
            // numBaseMassTolerance
            // 
            this.numBaseMassTolerance.DecimalPlaces = 3;
            this.numBaseMassTolerance.Location = new System.Drawing.Point(101, 23);
            this.numBaseMassTolerance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBaseMassTolerance.Name = "numBaseMassTolerance";
            this.numBaseMassTolerance.Size = new System.Drawing.Size(74, 20);
            this.numBaseMassTolerance.TabIndex = 70;
            this.numBaseMassTolerance.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(88, 25);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(13, 13);
            this.label65.TabIndex = 69;
            this.label65.Text = "±";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(6, 25);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(79, 13);
            this.label64.TabIndex = 1;
            this.label64.Text = "Mass tolerance";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.numBaseIonThreshold);
            this.groupBox6.Location = new System.Drawing.Point(283, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(239, 56);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "For calculating #MS2 above threshold";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(86, 25);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(146, 13);
            this.label39.TabIndex = 3;
            this.label39.Text = "Ion threshold for MS2 spectra";
            // 
            // numBaseIonThreshold
            // 
            this.numBaseIonThreshold.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBaseIonThreshold.Location = new System.Drawing.Point(6, 23);
            this.numBaseIonThreshold.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBaseIonThreshold.Name = "numBaseIonThreshold";
            this.numBaseIonThreshold.Size = new System.Drawing.Size(74, 20);
            this.numBaseIonThreshold.TabIndex = 2;
            this.numBaseIonThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBaseIonThreshold.ThousandsSeparator = true;
            this.numBaseIonThreshold.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numBaseSNthreshold);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "For calculating average signal-to-noise";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Signal-to-noise minimum threshold";
            // 
            // numBaseSNthreshold
            // 
            this.numBaseSNthreshold.DecimalPlaces = 2;
            this.numBaseSNthreshold.Location = new System.Drawing.Point(6, 23);
            this.numBaseSNthreshold.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBaseSNthreshold.Name = "numBaseSNthreshold";
            this.numBaseSNthreshold.Size = new System.Drawing.Size(74, 20);
            this.numBaseSNthreshold.TabIndex = 0;
            this.numBaseSNthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBaseSNthreshold.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // External
            // 
            this.External.Controls.Add(this.chkBxExternal1Enable);
            this.External.Location = new System.Drawing.Point(4, 22);
            this.External.Name = "External";
            this.External.Size = new System.Drawing.Size(886, 550);
            this.External.TabIndex = 2;
            this.External.Text = "External Tools";
            this.External.UseVisualStyleBackColor = true;
            // 
            // chkBxExternal1Enable
            // 
            this.chkBxExternal1Enable.AutoSize = true;
            this.chkBxExternal1Enable.Checked = true;
            this.chkBxExternal1Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxExternal1Enable.Location = new System.Drawing.Point(14, 13);
            this.chkBxExternal1Enable.Name = "chkBxExternal1Enable";
            this.chkBxExternal1Enable.Size = new System.Drawing.Size(284, 17);
            this.chkBxExternal1Enable.TabIndex = 0;
            this.chkBxExternal1Enable.Text = "Enable tool 1 (see Advanced settings for configuration)";
            this.chkBxExternal1Enable.UseVisualStyleBackColor = true;
            // 
            // lstBxWorkflows
            // 
            this.lstBxWorkflows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBxWorkflows.FormattingEnabled = true;
            this.lstBxWorkflows.Location = new System.Drawing.Point(13, 52);
            this.lstBxWorkflows.Name = "lstBxWorkflows";
            this.lstBxWorkflows.Size = new System.Drawing.Size(237, 576);
            this.lstBxWorkflows.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Settings";
            // 
            // btnDeleteSettings
            // 
            this.btnDeleteSettings.Location = new System.Drawing.Point(94, 23);
            this.btnDeleteSettings.Name = "btnDeleteSettings";
            this.btnDeleteSettings.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSettings.TabIndex = 13;
            this.btnDeleteSettings.Text = "Delete";
            this.btnDeleteSettings.UseVisualStyleBackColor = true;
            this.btnDeleteSettings.Click += new System.EventHandler(this.btnDeleteSettings_Click);
            // 
            // txtbxSettingName
            // 
            this.txtbxSettingName.Location = new System.Drawing.Point(258, 26);
            this.txtbxSettingName.Name = "txtbxSettingName";
            this.txtbxSettingName.Size = new System.Drawing.Size(244, 20);
            this.txtbxSettingName.TabIndex = 15;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(175, 23);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnNewSettings
            // 
            this.btnNewSettings.Location = new System.Drawing.Point(13, 23);
            this.btnNewSettings.Name = "btnNewSettings";
            this.btnNewSettings.Size = new System.Drawing.Size(75, 23);
            this.btnNewSettings.TabIndex = 1;
            this.btnNewSettings.Text = "New";
            this.btnNewSettings.UseVisualStyleBackColor = true;
            this.btnNewSettings.Click += new System.EventHandler(this.btnNewSettings_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Workflows";
            // 
            // AdvancedSettings
            // 
            this.AdvancedSettings.Controls.Add(this.grpBxAdvancedStatusLog);
            this.AdvancedSettings.Controls.Add(this.chkBxShowAdvanced);
            this.AdvancedSettings.Controls.Add(this.grpBxAdvancedExternalTool1);
            this.AdvancedSettings.Location = new System.Drawing.Point(4, 22);
            this.AdvancedSettings.Name = "AdvancedSettings";
            this.AdvancedSettings.Size = new System.Drawing.Size(1157, 643);
            this.AdvancedSettings.TabIndex = 10;
            this.AdvancedSettings.Text = "Advanced settings";
            this.AdvancedSettings.UseVisualStyleBackColor = true;
            // 
            // grpBxAdvancedStatusLog
            // 
            this.grpBxAdvancedStatusLog.Controls.Add(this.label78);
            this.grpBxAdvancedStatusLog.Controls.Add(this.label79);
            this.grpBxAdvancedStatusLog.Controls.Add(this.label80);
            this.grpBxAdvancedStatusLog.Controls.Add(this.label76);
            this.grpBxAdvancedStatusLog.Controls.Add(this.label75);
            this.grpBxAdvancedStatusLog.Controls.Add(this.label74);
            this.grpBxAdvancedStatusLog.Controls.Add(this.label73);
            this.grpBxAdvancedStatusLog.Controls.Add(this.btnBaseStatusLogRemove);
            this.grpBxAdvancedStatusLog.Controls.Add(this.txtBxBaseStatusLogNewItems);
            this.grpBxAdvancedStatusLog.Controls.Add(this.btnBaseStatusLogAdd);
            this.grpBxAdvancedStatusLog.Controls.Add(this.chkBxBaseStatusLogCalcIQR);
            this.grpBxAdvancedStatusLog.Controls.Add(this.chkBxBaseStatusLogCalcMedian);
            this.grpBxAdvancedStatusLog.Controls.Add(this.chkBxBaseStatusLogCalcMax);
            this.grpBxAdvancedStatusLog.Controls.Add(this.chkBxBaseStatusLogCalcMin);
            this.grpBxAdvancedStatusLog.Controls.Add(this.lstBxBaseStatusLogItems);
            this.grpBxAdvancedStatusLog.Location = new System.Drawing.Point(8, 332);
            this.grpBxAdvancedStatusLog.Name = "grpBxAdvancedStatusLog";
            this.grpBxAdvancedStatusLog.Size = new System.Drawing.Size(1101, 288);
            this.grpBxAdvancedStatusLog.TabIndex = 23;
            this.grpBxAdvancedStatusLog.TabStop = false;
            this.grpBxAdvancedStatusLog.Text = "Parsing of status log entries (need a restart if these settings are changed)";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(901, 182);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(72, 13);
            this.label78.TabIndex = 50;
            this.label78.Text = "changes here";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(907, 169);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(61, 13);
            this.label79.TabIndex = 49;
            this.label79.Text = "if you make";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(899, 156);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(77, 13);
            this.label80.TabIndex = 48;
            this.label80.Text = "Need a restart ";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(369, 156);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(72, 13);
            this.label76.TabIndex = 47;
            this.label76.Text = "changes here";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(375, 143);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(61, 13);
            this.label75.TabIndex = 46;
            this.label75.Text = "if you make";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(367, 130);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(77, 13);
            this.label74.TabIndex = 45;
            this.label74.Text = "Need a restart ";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(363, 82);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(76, 13);
            this.label73.TabIndex = 44;
            this.label73.Text = "--------------------->";
            // 
            // btnBaseStatusLogRemove
            // 
            this.btnBaseStatusLogRemove.Location = new System.Drawing.Point(812, 176);
            this.btnBaseStatusLogRemove.Name = "btnBaseStatusLogRemove";
            this.btnBaseStatusLogRemove.Size = new System.Drawing.Size(75, 23);
            this.btnBaseStatusLogRemove.TabIndex = 43;
            this.btnBaseStatusLogRemove.Text = "Remove";
            this.btnBaseStatusLogRemove.UseVisualStyleBackColor = true;
            this.btnBaseStatusLogRemove.Click += new System.EventHandler(this.btnBaseStatusLogRemove_Click);
            // 
            // txtBxBaseStatusLogNewItems
            // 
            this.txtBxBaseStatusLogNewItems.Location = new System.Drawing.Point(16, 29);
            this.txtBxBaseStatusLogNewItems.Multiline = true;
            this.txtBxBaseStatusLogNewItems.Name = "txtBxBaseStatusLogNewItems";
            this.txtBxBaseStatusLogNewItems.Size = new System.Drawing.Size(344, 170);
            this.txtBxBaseStatusLogNewItems.TabIndex = 42;
            this.txtBxBaseStatusLogNewItems.Text = "Enter the status log items here";
            // 
            // btnBaseStatusLogAdd
            // 
            this.btnBaseStatusLogAdd.Location = new System.Drawing.Point(366, 102);
            this.btnBaseStatusLogAdd.Name = "btnBaseStatusLogAdd";
            this.btnBaseStatusLogAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBaseStatusLogAdd.TabIndex = 41;
            this.btnBaseStatusLogAdd.Text = "Add items";
            this.btnBaseStatusLogAdd.UseVisualStyleBackColor = true;
            this.btnBaseStatusLogAdd.Click += new System.EventHandler(this.btnBaseStatusLogAdd_Click);
            // 
            // chkBxBaseStatusLogCalcIQR
            // 
            this.chkBxBaseStatusLogCalcIQR.AutoSize = true;
            this.chkBxBaseStatusLogCalcIQR.Location = new System.Drawing.Point(812, 102);
            this.chkBxBaseStatusLogCalcIQR.Name = "chkBxBaseStatusLogCalcIQR";
            this.chkBxBaseStatusLogCalcIQR.Size = new System.Drawing.Size(188, 17);
            this.chkBxBaseStatusLogCalcIQR.TabIndex = 40;
            this.chkBxBaseStatusLogCalcIQR.Text = "Calculate inter-quartile-range (IQR)";
            this.chkBxBaseStatusLogCalcIQR.UseVisualStyleBackColor = true;
            // 
            // chkBxBaseStatusLogCalcMedian
            // 
            this.chkBxBaseStatusLogCalcMedian.AutoSize = true;
            this.chkBxBaseStatusLogCalcMedian.Location = new System.Drawing.Point(812, 79);
            this.chkBxBaseStatusLogCalcMedian.Name = "chkBxBaseStatusLogCalcMedian";
            this.chkBxBaseStatusLogCalcMedian.Size = new System.Drawing.Size(107, 17);
            this.chkBxBaseStatusLogCalcMedian.TabIndex = 39;
            this.chkBxBaseStatusLogCalcMedian.Text = "Calculate median";
            this.chkBxBaseStatusLogCalcMedian.UseVisualStyleBackColor = true;
            // 
            // chkBxBaseStatusLogCalcMax
            // 
            this.chkBxBaseStatusLogCalcMax.AutoSize = true;
            this.chkBxBaseStatusLogCalcMax.Location = new System.Drawing.Point(812, 56);
            this.chkBxBaseStatusLogCalcMax.Name = "chkBxBaseStatusLogCalcMax";
            this.chkBxBaseStatusLogCalcMax.Size = new System.Drawing.Size(92, 17);
            this.chkBxBaseStatusLogCalcMax.TabIndex = 38;
            this.chkBxBaseStatusLogCalcMax.Text = "Calculate max";
            this.chkBxBaseStatusLogCalcMax.UseVisualStyleBackColor = true;
            // 
            // chkBxBaseStatusLogCalcMin
            // 
            this.chkBxBaseStatusLogCalcMin.AutoSize = true;
            this.chkBxBaseStatusLogCalcMin.Location = new System.Drawing.Point(812, 33);
            this.chkBxBaseStatusLogCalcMin.Name = "chkBxBaseStatusLogCalcMin";
            this.chkBxBaseStatusLogCalcMin.Size = new System.Drawing.Size(89, 17);
            this.chkBxBaseStatusLogCalcMin.TabIndex = 37;
            this.chkBxBaseStatusLogCalcMin.Text = "Calculate min";
            this.chkBxBaseStatusLogCalcMin.UseVisualStyleBackColor = true;
            // 
            // lstBxBaseStatusLogItems
            // 
            this.lstBxBaseStatusLogItems.FormattingEnabled = true;
            this.lstBxBaseStatusLogItems.Location = new System.Drawing.Point(447, 29);
            this.lstBxBaseStatusLogItems.Name = "lstBxBaseStatusLogItems";
            this.lstBxBaseStatusLogItems.Size = new System.Drawing.Size(359, 173);
            this.lstBxBaseStatusLogItems.TabIndex = 36;
            // 
            // chkBxShowAdvanced
            // 
            this.chkBxShowAdvanced.AutoSize = true;
            this.chkBxShowAdvanced.Location = new System.Drawing.Point(8, 12);
            this.chkBxShowAdvanced.Name = "chkBxShowAdvanced";
            this.chkBxShowAdvanced.Size = new System.Drawing.Size(143, 17);
            this.chkBxShowAdvanced.TabIndex = 22;
            this.chkBxShowAdvanced.Text = "Show advanced settings";
            this.chkBxShowAdvanced.UseVisualStyleBackColor = true;
            this.chkBxShowAdvanced.CheckedChanged += new System.EventHandler(this.chkBxShowAdvanced_CheckedChanged);
            // 
            // grpBxAdvancedExternalTool1
            // 
            this.grpBxAdvancedExternalTool1.Controls.Add(this.label84);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.groupBox12);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.label85);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.label86);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.numExternalTimeout);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.txtBxExternal1Arguments);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.label62);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.txtBxExternal1Executable);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.label21);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.btnExternal1Browse);
            this.grpBxAdvancedExternalTool1.Controls.Add(this.label20);
            this.grpBxAdvancedExternalTool1.Location = new System.Drawing.Point(8, 35);
            this.grpBxAdvancedExternalTool1.Name = "grpBxAdvancedExternalTool1";
            this.grpBxAdvancedExternalTool1.Size = new System.Drawing.Size(1101, 291);
            this.grpBxAdvancedExternalTool1.TabIndex = 21;
            this.grpBxAdvancedExternalTool1.TabStop = false;
            this.grpBxAdvancedExternalTool1.Text = "External tool1 settings (need a restart if these settings are changed)";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(739, 52);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(72, 13);
            this.label84.TabIndex = 53;
            this.label84.Text = "changes here";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.groupBox2);
            this.groupBox12.Controls.Add(this.label81);
            this.groupBox12.Controls.Add(this.groupBox5);
            this.groupBox12.Controls.Add(this.label77);
            this.groupBox12.Controls.Add(this.label82);
            this.groupBox12.Controls.Add(this.label83);
            this.groupBox12.Controls.Add(this.txtBxExternal1ResultName);
            this.groupBox12.Controls.Add(this.lstBxExternal1);
            this.groupBox12.Controls.Add(this.btnExternal1Remove);
            this.groupBox12.Controls.Add(this.txtBxExternal1ResultFile);
            this.groupBox12.Controls.Add(this.btnExternal1New);
            this.groupBox12.Controls.Add(this.label53);
            this.groupBox12.Location = new System.Drawing.Point(6, 84);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(1089, 182);
            this.groupBox12.TabIndex = 21;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Parsing of results (need a restart if these settings are changed)";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(611, 145);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(72, 13);
            this.label81.TabIndex = 50;
            this.label81.Text = "changes here";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(349, 67);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(107, 13);
            this.label77.TabIndex = 21;
            this.label77.Text = "Row or column name";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(617, 132);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(61, 13);
            this.label82.TabIndex = 49;
            this.label82.Text = "if you make";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(609, 119);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(77, 13);
            this.label83.TabIndex = 48;
            this.label83.Text = "Need a restart ";
            // 
            // txtBxExternal1ResultName
            // 
            this.txtBxExternal1ResultName.Location = new System.Drawing.Point(462, 63);
            this.txtBxExternal1ResultName.Name = "txtBxExternal1ResultName";
            this.txtBxExternal1ResultName.Size = new System.Drawing.Size(216, 20);
            this.txtBxExternal1ResultName.TabIndex = 15;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdBtnExternal1Column);
            this.groupBox5.Controls.Add(this.rdBtnExternal1Row);
            this.groupBox5.Location = new System.Drawing.Point(727, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(186, 87);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "How to parse the result file";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdBtnExternal1SplitTab);
            this.groupBox2.Controls.Add(this.rdBtnExternal1SplitSemicolon);
            this.groupBox2.Location = new System.Drawing.Point(929, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 87);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Split character";
            // 
            // rdBtnExternal1SplitTab
            // 
            this.rdBtnExternal1SplitTab.AutoSize = true;
            this.rdBtnExternal1SplitTab.Checked = true;
            this.rdBtnExternal1SplitTab.Location = new System.Drawing.Point(21, 27);
            this.rdBtnExternal1SplitTab.Name = "rdBtnExternal1SplitTab";
            this.rdBtnExternal1SplitTab.Size = new System.Drawing.Size(44, 17);
            this.rdBtnExternal1SplitTab.TabIndex = 20;
            this.rdBtnExternal1SplitTab.TabStop = true;
            this.rdBtnExternal1SplitTab.Text = "Tab";
            this.rdBtnExternal1SplitTab.UseVisualStyleBackColor = true;
            this.rdBtnExternal1SplitTab.CheckedChanged += new System.EventHandler(this.rdBtnExternal1SplitTab_CheckedChanged);
            // 
            // rdBtnExternal1SplitSemicolon
            // 
            this.rdBtnExternal1SplitSemicolon.AutoSize = true;
            this.rdBtnExternal1SplitSemicolon.Location = new System.Drawing.Point(21, 51);
            this.rdBtnExternal1SplitSemicolon.Name = "rdBtnExternal1SplitSemicolon";
            this.rdBtnExternal1SplitSemicolon.Size = new System.Drawing.Size(28, 17);
            this.rdBtnExternal1SplitSemicolon.TabIndex = 21;
            this.rdBtnExternal1SplitSemicolon.TabStop = true;
            this.rdBtnExternal1SplitSemicolon.Text = ";";
            this.rdBtnExternal1SplitSemicolon.UseVisualStyleBackColor = true;
            // 
            // rdBtnExternal1Column
            // 
            this.rdBtnExternal1Column.AutoSize = true;
            this.rdBtnExternal1Column.Location = new System.Drawing.Point(72, 50);
            this.rdBtnExternal1Column.Name = "rdBtnExternal1Column";
            this.rdBtnExternal1Column.Size = new System.Drawing.Size(65, 17);
            this.rdBtnExternal1Column.TabIndex = 18;
            this.rdBtnExternal1Column.Text = "Columns";
            this.rdBtnExternal1Column.UseVisualStyleBackColor = true;
            // 
            // rdBtnExternal1Row
            // 
            this.rdBtnExternal1Row.AutoSize = true;
            this.rdBtnExternal1Row.Checked = true;
            this.rdBtnExternal1Row.Location = new System.Drawing.Point(72, 27);
            this.rdBtnExternal1Row.Name = "rdBtnExternal1Row";
            this.rdBtnExternal1Row.Size = new System.Drawing.Size(52, 17);
            this.rdBtnExternal1Row.TabIndex = 19;
            this.rdBtnExternal1Row.TabStop = true;
            this.rdBtnExternal1Row.Text = "Rows";
            this.rdBtnExternal1Row.UseVisualStyleBackColor = true;
            this.rdBtnExternal1Row.CheckedChanged += new System.EventHandler(this.rdBtnExternal1Row_CheckedChanged);
            // 
            // lstBxExternal1
            // 
            this.lstBxExternal1.FormattingEnabled = true;
            this.lstBxExternal1.Location = new System.Drawing.Point(12, 24);
            this.lstBxExternal1.Name = "lstBxExternal1";
            this.lstBxExternal1.Size = new System.Drawing.Size(331, 121);
            this.lstBxExternal1.TabIndex = 5;
            // 
            // btnExternal1Remove
            // 
            this.btnExternal1Remove.Location = new System.Drawing.Point(92, 154);
            this.btnExternal1Remove.Name = "btnExternal1Remove";
            this.btnExternal1Remove.Size = new System.Drawing.Size(75, 23);
            this.btnExternal1Remove.TabIndex = 7;
            this.btnExternal1Remove.Text = "Remove";
            this.btnExternal1Remove.UseVisualStyleBackColor = true;
            this.btnExternal1Remove.Click += new System.EventHandler(this.btnExternal1Remove_Click_1);
            // 
            // txtBxExternal1ResultFile
            // 
            this.txtBxExternal1ResultFile.Location = new System.Drawing.Point(408, 26);
            this.txtBxExternal1ResultFile.Name = "txtBxExternal1ResultFile";
            this.txtBxExternal1ResultFile.Size = new System.Drawing.Size(270, 20);
            this.txtBxExternal1ResultFile.TabIndex = 11;
            // 
            // btnExternal1New
            // 
            this.btnExternal1New.Location = new System.Drawing.Point(12, 154);
            this.btnExternal1New.Name = "btnExternal1New";
            this.btnExternal1New.Size = new System.Drawing.Size(75, 23);
            this.btnExternal1New.TabIndex = 6;
            this.btnExternal1New.Text = "New";
            this.btnExternal1New.UseVisualStyleBackColor = true;
            this.btnExternal1New.Click += new System.EventHandler(this.btnExternal1New_Click);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(349, 29);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(53, 13);
            this.label53.TabIndex = 3;
            this.label53.Text = "Result file";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(745, 39);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(61, 13);
            this.label85.TabIndex = 52;
            this.label85.Text = "if you make";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(737, 26);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(77, 13);
            this.label86.TabIndex = 51;
            this.label86.Text = "Need a restart ";
            // 
            // numExternalTimeout
            // 
            this.numExternalTimeout.Location = new System.Drawing.Point(586, 15);
            this.numExternalTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numExternalTimeout.Name = "numExternalTimeout";
            this.numExternalTimeout.Size = new System.Drawing.Size(78, 20);
            this.numExternalTimeout.TabIndex = 17;
            // 
            // txtBxExternal1Arguments
            // 
            this.txtBxExternal1Arguments.Location = new System.Drawing.Point(75, 48);
            this.txtBxExternal1Arguments.Name = "txtBxExternal1Arguments";
            this.txtBxExternal1Arguments.Size = new System.Drawing.Size(332, 20);
            this.txtBxExternal1Arguments.TabIndex = 9;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(512, 19);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(59, 13);
            this.label62.TabIndex = 16;
            this.label62.Text = "Timeout (s)";
            // 
            // txtBxExternal1Executable
            // 
            this.txtBxExternal1Executable.Location = new System.Drawing.Point(75, 17);
            this.txtBxExternal1Executable.Name = "txtBxExternal1Executable";
            this.txtBxExternal1Executable.Size = new System.Drawing.Size(332, 20);
            this.txtBxExternal1Executable.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Arguments";
            // 
            // btnExternal1Browse
            // 
            this.btnExternal1Browse.Location = new System.Drawing.Point(413, 15);
            this.btnExternal1Browse.Name = "btnExternal1Browse";
            this.btnExternal1Browse.Size = new System.Drawing.Size(75, 23);
            this.btnExternal1Browse.TabIndex = 10;
            this.btnExternal1Browse.Text = "Browse";
            this.btnExternal1Browse.UseVisualStyleBackColor = true;
            this.btnExternal1Browse.Click += new System.EventHandler(this.btnExternal1Browse_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Executable";
            // 
            // ManualAnalysis
            // 
            this.ManualAnalysis.Controls.Add(this.lstBxRawFiles);
            this.ManualAnalysis.Controls.Add(this.label11);
            this.ManualAnalysis.Controls.Add(this.cmbBxAnalysisSettingsManual);
            this.ManualAnalysis.Controls.Add(this.Analyze);
            this.ManualAnalysis.Controls.Add(this.btnRemoveRawFiles);
            this.ManualAnalysis.Controls.Add(this.addRawFilesBtn);
            this.ManualAnalysis.Location = new System.Drawing.Point(4, 22);
            this.ManualAnalysis.Name = "ManualAnalysis";
            this.ManualAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.ManualAnalysis.Size = new System.Drawing.Size(1157, 643);
            this.ManualAnalysis.TabIndex = 0;
            this.ManualAnalysis.Text = "Manual analysis";
            this.ManualAnalysis.UseVisualStyleBackColor = true;
            // 
            // lstBxRawFiles
            // 
            this.lstBxRawFiles.FormattingEnabled = true;
            this.lstBxRawFiles.Location = new System.Drawing.Point(7, 89);
            this.lstBxRawFiles.Name = "lstBxRawFiles";
            this.lstBxRawFiles.Size = new System.Drawing.Size(515, 264);
            this.lstBxRawFiles.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(203, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Analysis workflow:";
            // 
            // cmbBxAnalysisSettingsManual
            // 
            this.cmbBxAnalysisSettingsManual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxAnalysisSettingsManual.FormattingEnabled = true;
            this.cmbBxAnalysisSettingsManual.Location = new System.Drawing.Point(298, 36);
            this.cmbBxAnalysisSettingsManual.Name = "cmbBxAnalysisSettingsManual";
            this.cmbBxAnalysisSettingsManual.Size = new System.Drawing.Size(121, 21);
            this.cmbBxAnalysisSettingsManual.TabIndex = 7;
            // 
            // Analyze
            // 
            this.Analyze.Location = new System.Drawing.Point(447, 34);
            this.Analyze.Name = "Analyze";
            this.Analyze.Size = new System.Drawing.Size(75, 23);
            this.Analyze.TabIndex = 3;
            this.Analyze.Text = "Analyze";
            this.Analyze.UseVisualStyleBackColor = true;
            this.Analyze.Click += new System.EventHandler(this.Analyze_Click);
            // 
            // btnRemoveRawFiles
            // 
            this.btnRemoveRawFiles.Location = new System.Drawing.Point(88, 34);
            this.btnRemoveRawFiles.Name = "btnRemoveRawFiles";
            this.btnRemoveRawFiles.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRawFiles.TabIndex = 2;
            this.btnRemoveRawFiles.Text = "Remove";
            this.btnRemoveRawFiles.UseVisualStyleBackColor = true;
            this.btnRemoveRawFiles.Click += new System.EventHandler(this.btnRemoveRawFiles_Click);
            // 
            // addRawFilesBtn
            // 
            this.addRawFilesBtn.Location = new System.Drawing.Point(7, 34);
            this.addRawFilesBtn.Name = "addRawFilesBtn";
            this.addRawFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.addRawFilesBtn.TabIndex = 1;
            this.addRawFilesBtn.Text = "Add files";
            this.addRawFilesBtn.UseVisualStyleBackColor = true;
            this.addRawFilesBtn.Click += new System.EventHandler(this.addRawFilesBtn_Click);
            // 
            // AutomatedAnalysis
            // 
            this.AutomatedAnalysis.Controls.Add(this.cmbBxAutomatedDefault);
            this.AutomatedAnalysis.Controls.Add(this.lblAutomatedSelectWorkflow);
            this.AutomatedAnalysis.Controls.Add(this.pnlCodeNam);
            this.AutomatedAnalysis.Controls.Add(this.btnBrowseFastLocal);
            this.AutomatedAnalysis.Controls.Add(this.chkBxCodeName);
            this.AutomatedAnalysis.Controls.Add(this.txtBxFastLocal);
            this.AutomatedAnalysis.Controls.Add(this.label6);
            this.AutomatedAnalysis.Controls.Add(this.btnWatch1);
            this.AutomatedAnalysis.Controls.Add(this.btnWatchBrowse1);
            this.AutomatedAnalysis.Controls.Add(this.txtBxWatchFolder0);
            this.AutomatedAnalysis.Controls.Add(this.txtBxWatchFolder2);
            this.AutomatedAnalysis.Controls.Add(this.chkBxLocalFolder);
            this.AutomatedAnalysis.Controls.Add(this.txtBxWatchFolder1);
            this.AutomatedAnalysis.Controls.Add(this.btnWatchBrowse0);
            this.AutomatedAnalysis.Controls.Add(this.btnWatchBrowse2);
            this.AutomatedAnalysis.Controls.Add(this.btnWatch4);
            this.AutomatedAnalysis.Controls.Add(this.btnWatch0);
            this.AutomatedAnalysis.Controls.Add(this.btnWatch2);
            this.AutomatedAnalysis.Controls.Add(this.btnWatchBrowse4);
            this.AutomatedAnalysis.Controls.Add(this.txtBxWatchFolder3);
            this.AutomatedAnalysis.Controls.Add(this.txtBxWatchFolder4);
            this.AutomatedAnalysis.Controls.Add(this.btnWatchBrowse3);
            this.AutomatedAnalysis.Controls.Add(this.btnWatch3);
            this.AutomatedAnalysis.Location = new System.Drawing.Point(4, 22);
            this.AutomatedAnalysis.Name = "AutomatedAnalysis";
            this.AutomatedAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.AutomatedAnalysis.Size = new System.Drawing.Size(1157, 643);
            this.AutomatedAnalysis.TabIndex = 1;
            this.AutomatedAnalysis.Text = "Automated analysis";
            this.AutomatedAnalysis.UseVisualStyleBackColor = true;
            // 
            // cmbBxAutomatedDefault
            // 
            this.cmbBxAutomatedDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxAutomatedDefault.FormattingEnabled = true;
            this.cmbBxAutomatedDefault.Location = new System.Drawing.Point(197, 157);
            this.cmbBxAutomatedDefault.Name = "cmbBxAutomatedDefault";
            this.cmbBxAutomatedDefault.Size = new System.Drawing.Size(178, 21);
            this.cmbBxAutomatedDefault.TabIndex = 70;
            // 
            // lblAutomatedSelectWorkflow
            // 
            this.lblAutomatedSelectWorkflow.AutoSize = true;
            this.lblAutomatedSelectWorkflow.Location = new System.Drawing.Point(13, 160);
            this.lblAutomatedSelectWorkflow.Name = "lblAutomatedSelectWorkflow";
            this.lblAutomatedSelectWorkflow.Size = new System.Drawing.Size(85, 13);
            this.lblAutomatedSelectWorkflow.TabIndex = 69;
            this.lblAutomatedSelectWorkflow.Text = "Select workflow:";
            // 
            // pnlCodeNam
            // 
            this.pnlCodeNam.Controls.Add(this.lstBxCodeToAnalysis);
            this.pnlCodeNam.Controls.Add(this.label37);
            this.pnlCodeNam.Controls.Add(this.txtBxCodePattern);
            this.pnlCodeNam.Controls.Add(this.btnCodeNameCheck);
            this.pnlCodeNam.Controls.Add(this.btnAddAnalysisCode);
            this.pnlCodeNam.Controls.Add(this.txtBxCodeNameCheck);
            this.pnlCodeNam.Controls.Add(this.lblCodeName);
            this.pnlCodeNam.Controls.Add(this.btnCodeNameDown);
            this.pnlCodeNam.Controls.Add(this.btnDeleteAnalysisCode);
            this.pnlCodeNam.Controls.Add(this.btnCodeNameUp);
            this.pnlCodeNam.Controls.Add(this.label18);
            this.pnlCodeNam.Controls.Add(this.lblCodeNameToAnalysis);
            this.pnlCodeNam.Controls.Add(this.cmbBxCodeName);
            this.pnlCodeNam.Location = new System.Drawing.Point(13, 275);
            this.pnlCodeNam.Name = "pnlCodeNam";
            this.pnlCodeNam.Size = new System.Drawing.Size(422, 207);
            this.pnlCodeNam.TabIndex = 67;
            // 
            // lstBxCodeToAnalysis
            // 
            this.lstBxCodeToAnalysis.FormattingEnabled = true;
            this.lstBxCodeToAnalysis.Location = new System.Drawing.Point(3, 18);
            this.lstBxCodeToAnalysis.Name = "lstBxCodeToAnalysis";
            this.lstBxCodeToAnalysis.Size = new System.Drawing.Size(156, 95);
            this.lstBxCodeToAnalysis.TabIndex = 41;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(3, 153);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(172, 13);
            this.label37.TabIndex = 66;
            this.label37.Text = "Checking tool (paste raw file name)";
            // 
            // txtBxCodePattern
            // 
            this.txtBxCodePattern.Location = new System.Drawing.Point(165, 17);
            this.txtBxCodePattern.Name = "txtBxCodePattern";
            this.txtBxCodePattern.Size = new System.Drawing.Size(75, 20);
            this.txtBxCodePattern.TabIndex = 40;
            // 
            // btnCodeNameCheck
            // 
            this.btnCodeNameCheck.Location = new System.Drawing.Point(323, 168);
            this.btnCodeNameCheck.Name = "btnCodeNameCheck";
            this.btnCodeNameCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCodeNameCheck.TabIndex = 65;
            this.btnCodeNameCheck.Text = "Check";
            this.btnCodeNameCheck.UseVisualStyleBackColor = true;
            this.btnCodeNameCheck.Click += new System.EventHandler(this.btnCodeNameCheck_Click);
            // 
            // btnAddAnalysisCode
            // 
            this.btnAddAnalysisCode.Location = new System.Drawing.Point(3, 119);
            this.btnAddAnalysisCode.Name = "btnAddAnalysisCode";
            this.btnAddAnalysisCode.Size = new System.Drawing.Size(75, 23);
            this.btnAddAnalysisCode.TabIndex = 38;
            this.btnAddAnalysisCode.Text = "New";
            this.btnAddAnalysisCode.UseVisualStyleBackColor = true;
            this.btnAddAnalysisCode.Click += new System.EventHandler(this.btnAddAnalysisCode_Click);
            // 
            // txtBxCodeNameCheck
            // 
            this.txtBxCodeNameCheck.Location = new System.Drawing.Point(3, 172);
            this.txtBxCodeNameCheck.Name = "txtBxCodeNameCheck";
            this.txtBxCodeNameCheck.Size = new System.Drawing.Size(313, 20);
            this.txtBxCodeNameCheck.TabIndex = 64;
            // 
            // lblCodeName
            // 
            this.lblCodeName.AutoSize = true;
            this.lblCodeName.Location = new System.Drawing.Point(162, 1);
            this.lblCodeName.Name = "lblCodeName";
            this.lblCodeName.Size = new System.Drawing.Size(81, 13);
            this.lblCodeName.TabIndex = 39;
            this.lblCodeName.Text = "Raw file pattern";
            // 
            // btnCodeNameDown
            // 
            this.btnCodeNameDown.Location = new System.Drawing.Point(165, 73);
            this.btnCodeNameDown.Name = "btnCodeNameDown";
            this.btnCodeNameDown.Size = new System.Drawing.Size(75, 23);
            this.btnCodeNameDown.TabIndex = 63;
            this.btnCodeNameDown.Text = "Down";
            this.btnCodeNameDown.UseVisualStyleBackColor = true;
            this.btnCodeNameDown.Click += new System.EventHandler(this.btnCodeNameDown_Click);
            // 
            // btnDeleteAnalysisCode
            // 
            this.btnDeleteAnalysisCode.Location = new System.Drawing.Point(84, 119);
            this.btnDeleteAnalysisCode.Name = "btnDeleteAnalysisCode";
            this.btnDeleteAnalysisCode.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAnalysisCode.TabIndex = 37;
            this.btnDeleteAnalysisCode.Text = "Delete";
            this.btnDeleteAnalysisCode.UseVisualStyleBackColor = true;
            this.btnDeleteAnalysisCode.Click += new System.EventHandler(this.btnDeleteAnalysisCode_Click);
            // 
            // btnCodeNameUp
            // 
            this.btnCodeNameUp.Location = new System.Drawing.Point(165, 44);
            this.btnCodeNameUp.Name = "btnCodeNameUp";
            this.btnCodeNameUp.Size = new System.Drawing.Size(75, 23);
            this.btnCodeNameUp.TabIndex = 62;
            this.btnCodeNameUp.Text = "Up";
            this.btnCodeNameUp.UseVisualStyleBackColor = true;
            this.btnCodeNameUp.Click += new System.EventHandler(this.btnCodeNameUp_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(254, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Analysis setting";
            // 
            // lblCodeNameToAnalysis
            // 
            this.lblCodeNameToAnalysis.AutoSize = true;
            this.lblCodeNameToAnalysis.Location = new System.Drawing.Point(0, 2);
            this.lblCodeNameToAnalysis.Name = "lblCodeNameToAnalysis";
            this.lblCodeNameToAnalysis.Size = new System.Drawing.Size(147, 13);
            this.lblCodeNameToAnalysis.TabIndex = 61;
            this.lblCodeNameToAnalysis.Text = "Code name -> analysis setting";
            // 
            // cmbBxCodeName
            // 
            this.cmbBxCodeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxCodeName.FormattingEnabled = true;
            this.cmbBxCodeName.Location = new System.Drawing.Point(257, 16);
            this.cmbBxCodeName.Name = "cmbBxCodeName";
            this.cmbBxCodeName.Size = new System.Drawing.Size(155, 21);
            this.cmbBxCodeName.TabIndex = 43;
            this.cmbBxCodeName.SelectedIndexChanged += new System.EventHandler(this.cmbBxCodeName_SelectedIndexChanged);
            // 
            // btnBrowseFastLocal
            // 
            this.btnBrowseFastLocal.Location = new System.Drawing.Point(300, 215);
            this.btnBrowseFastLocal.Name = "btnBrowseFastLocal";
            this.btnBrowseFastLocal.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFastLocal.TabIndex = 48;
            this.btnBrowseFastLocal.Text = "Browse";
            this.btnBrowseFastLocal.UseVisualStyleBackColor = true;
            this.btnBrowseFastLocal.Click += new System.EventHandler(this.btnBrowseFastLocal_Click);
            // 
            // chkBxCodeName
            // 
            this.chkBxCodeName.AutoSize = true;
            this.chkBxCodeName.Checked = true;
            this.chkBxCodeName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxCodeName.Location = new System.Drawing.Point(11, 252);
            this.chkBxCodeName.Name = "chkBxCodeName";
            this.chkBxCodeName.Size = new System.Drawing.Size(239, 17);
            this.chkBxCodeName.TabIndex = 60;
            this.chkBxCodeName.Text = "Use code name to choose analysis workflow.";
            this.chkBxCodeName.UseVisualStyleBackColor = true;
            this.chkBxCodeName.CheckedChanged += new System.EventHandler(this.chkBxCodeName_CheckedChanged);
            // 
            // txtBxFastLocal
            // 
            this.txtBxFastLocal.Location = new System.Drawing.Point(11, 218);
            this.txtBxFastLocal.Name = "txtBxFastLocal";
            this.txtBxFastLocal.Size = new System.Drawing.Size(281, 20);
            this.txtBxFastLocal.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Folders to watch";
            // 
            // btnWatch1
            // 
            this.btnWatch1.Location = new System.Drawing.Point(381, 52);
            this.btnWatch1.Name = "btnWatch1";
            this.btnWatch1.Size = new System.Drawing.Size(75, 23);
            this.btnWatch1.TabIndex = 49;
            this.btnWatch1.Text = "Start watch";
            this.btnWatch1.UseVisualStyleBackColor = true;
            this.btnWatch1.Click += new System.EventHandler(this.btnWatch1_Click);
            // 
            // btnWatchBrowse1
            // 
            this.btnWatchBrowse1.Location = new System.Drawing.Point(300, 52);
            this.btnWatchBrowse1.Name = "btnWatchBrowse1";
            this.btnWatchBrowse1.Size = new System.Drawing.Size(75, 23);
            this.btnWatchBrowse1.TabIndex = 45;
            this.btnWatchBrowse1.Text = "Browse";
            this.btnWatchBrowse1.UseVisualStyleBackColor = true;
            this.btnWatchBrowse1.Click += new System.EventHandler(this.btnWatchBrowse1_Click);
            // 
            // txtBxWatchFolder0
            // 
            this.txtBxWatchFolder0.Location = new System.Drawing.Point(11, 28);
            this.txtBxWatchFolder0.Name = "txtBxWatchFolder0";
            this.txtBxWatchFolder0.Size = new System.Drawing.Size(281, 20);
            this.txtBxWatchFolder0.TabIndex = 16;
            // 
            // txtBxWatchFolder2
            // 
            this.txtBxWatchFolder2.Location = new System.Drawing.Point(11, 78);
            this.txtBxWatchFolder2.Name = "txtBxWatchFolder2";
            this.txtBxWatchFolder2.Size = new System.Drawing.Size(281, 20);
            this.txtBxWatchFolder2.TabIndex = 50;
            // 
            // chkBxLocalFolder
            // 
            this.chkBxLocalFolder.AutoSize = true;
            this.chkBxLocalFolder.Checked = true;
            this.chkBxLocalFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxLocalFolder.Location = new System.Drawing.Point(11, 195);
            this.chkBxLocalFolder.Name = "chkBxLocalFolder";
            this.chkBxLocalFolder.Size = new System.Drawing.Size(332, 17);
            this.chkBxLocalFolder.TabIndex = 59;
            this.chkBxLocalFolder.Text = "Fast local folder for processing (recommended for network drives)";
            this.chkBxLocalFolder.UseVisualStyleBackColor = true;
            this.chkBxLocalFolder.CheckedChanged += new System.EventHandler(this.chkBxLocalFolder_CheckedChanged);
            // 
            // txtBxWatchFolder1
            // 
            this.txtBxWatchFolder1.Location = new System.Drawing.Point(11, 53);
            this.txtBxWatchFolder1.Name = "txtBxWatchFolder1";
            this.txtBxWatchFolder1.Size = new System.Drawing.Size(281, 20);
            this.txtBxWatchFolder1.TabIndex = 44;
            // 
            // btnWatchBrowse0
            // 
            this.btnWatchBrowse0.Location = new System.Drawing.Point(300, 27);
            this.btnWatchBrowse0.Name = "btnWatchBrowse0";
            this.btnWatchBrowse0.Size = new System.Drawing.Size(75, 23);
            this.btnWatchBrowse0.TabIndex = 21;
            this.btnWatchBrowse0.Text = "Browse";
            this.btnWatchBrowse0.UseVisualStyleBackColor = true;
            this.btnWatchBrowse0.Click += new System.EventHandler(this.btnWatchBrowse0_Click);
            // 
            // btnWatchBrowse2
            // 
            this.btnWatchBrowse2.Location = new System.Drawing.Point(300, 77);
            this.btnWatchBrowse2.Name = "btnWatchBrowse2";
            this.btnWatchBrowse2.Size = new System.Drawing.Size(75, 23);
            this.btnWatchBrowse2.TabIndex = 51;
            this.btnWatchBrowse2.Text = "Browse";
            this.btnWatchBrowse2.UseVisualStyleBackColor = true;
            this.btnWatchBrowse2.Click += new System.EventHandler(this.btnWatchBrowse2_Click);
            // 
            // btnWatch4
            // 
            this.btnWatch4.Location = new System.Drawing.Point(381, 127);
            this.btnWatch4.Name = "btnWatch4";
            this.btnWatch4.Size = new System.Drawing.Size(75, 23);
            this.btnWatch4.TabIndex = 58;
            this.btnWatch4.Text = "Start watch";
            this.btnWatch4.UseVisualStyleBackColor = true;
            this.btnWatch4.Click += new System.EventHandler(this.btnWatch4_Click);
            // 
            // btnWatch0
            // 
            this.btnWatch0.Location = new System.Drawing.Point(381, 27);
            this.btnWatch0.Name = "btnWatch0";
            this.btnWatch0.Size = new System.Drawing.Size(75, 23);
            this.btnWatch0.TabIndex = 22;
            this.btnWatch0.Text = "Start watch";
            this.btnWatch0.UseVisualStyleBackColor = true;
            this.btnWatch0.Click += new System.EventHandler(this.btnWatch0_Click);
            // 
            // btnWatch2
            // 
            this.btnWatch2.Location = new System.Drawing.Point(381, 77);
            this.btnWatch2.Name = "btnWatch2";
            this.btnWatch2.Size = new System.Drawing.Size(75, 23);
            this.btnWatch2.TabIndex = 52;
            this.btnWatch2.Text = "Start watch";
            this.btnWatch2.UseVisualStyleBackColor = true;
            this.btnWatch2.Click += new System.EventHandler(this.btnWatch2_Click);
            // 
            // btnWatchBrowse4
            // 
            this.btnWatchBrowse4.Location = new System.Drawing.Point(300, 127);
            this.btnWatchBrowse4.Name = "btnWatchBrowse4";
            this.btnWatchBrowse4.Size = new System.Drawing.Size(75, 23);
            this.btnWatchBrowse4.TabIndex = 57;
            this.btnWatchBrowse4.Text = "Browse";
            this.btnWatchBrowse4.UseVisualStyleBackColor = true;
            this.btnWatchBrowse4.Click += new System.EventHandler(this.btnWatchBrowse4_Click);
            // 
            // txtBxWatchFolder3
            // 
            this.txtBxWatchFolder3.Location = new System.Drawing.Point(11, 103);
            this.txtBxWatchFolder3.Name = "txtBxWatchFolder3";
            this.txtBxWatchFolder3.Size = new System.Drawing.Size(281, 20);
            this.txtBxWatchFolder3.TabIndex = 53;
            // 
            // txtBxWatchFolder4
            // 
            this.txtBxWatchFolder4.Location = new System.Drawing.Point(11, 128);
            this.txtBxWatchFolder4.Name = "txtBxWatchFolder4";
            this.txtBxWatchFolder4.Size = new System.Drawing.Size(281, 20);
            this.txtBxWatchFolder4.TabIndex = 56;
            // 
            // btnWatchBrowse3
            // 
            this.btnWatchBrowse3.Location = new System.Drawing.Point(300, 102);
            this.btnWatchBrowse3.Name = "btnWatchBrowse3";
            this.btnWatchBrowse3.Size = new System.Drawing.Size(75, 23);
            this.btnWatchBrowse3.TabIndex = 54;
            this.btnWatchBrowse3.Text = "Browse";
            this.btnWatchBrowse3.UseVisualStyleBackColor = true;
            this.btnWatchBrowse3.Click += new System.EventHandler(this.btnWatchBrowse3_Click);
            // 
            // btnWatch3
            // 
            this.btnWatch3.Location = new System.Drawing.Point(381, 102);
            this.btnWatch3.Name = "btnWatch3";
            this.btnWatch3.Size = new System.Drawing.Size(75, 23);
            this.btnWatch3.TabIndex = 55;
            this.btnWatch3.Text = "Start watch";
            this.btnWatch3.UseVisualStyleBackColor = true;
            this.btnWatch3.Click += new System.EventHandler(this.btnWatch3_Click);
            // 
            // ResultOverview
            // 
            this.ResultOverview.Controls.Add(this.dataGridView);
            this.ResultOverview.Location = new System.Drawing.Point(4, 22);
            this.ResultOverview.Name = "ResultOverview";
            this.ResultOverview.Size = new System.Drawing.Size(1157, 643);
            this.ResultOverview.TabIndex = 5;
            this.ResultOverview.Text = "Result overview";
            this.ResultOverview.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(1151, 637);
            this.dataGridView.TabIndex = 4;
            // 
            // FileNameParseRules
            // 
            this.FileNameParseRules.Controls.Add(this.btnTestRawFileCategories);
            this.FileNameParseRules.Controls.Add(this.txtBoxRawFileNamingTest);
            this.FileNameParseRules.Controls.Add(this.label49);
            this.FileNameParseRules.Controls.Add(this.label45);
            this.FileNameParseRules.Controls.Add(this.label44);
            this.FileNameParseRules.Controls.Add(this.dgvMS);
            this.FileNameParseRules.Controls.Add(this.dgvSample);
            this.FileNameParseRules.Controls.Add(this.dgvLC);
            this.FileNameParseRules.Controls.Add(this.dgvUser);
            this.FileNameParseRules.Controls.Add(this.label5);
            this.FileNameParseRules.Location = new System.Drawing.Point(4, 22);
            this.FileNameParseRules.Name = "FileNameParseRules";
            this.FileNameParseRules.Size = new System.Drawing.Size(1157, 643);
            this.FileNameParseRules.TabIndex = 6;
            this.FileNameParseRules.Text = "File name parse rules";
            this.FileNameParseRules.UseVisualStyleBackColor = true;
            // 
            // btnTestRawFileCategories
            // 
            this.btnTestRawFileCategories.Location = new System.Drawing.Point(632, 599);
            this.btnTestRawFileCategories.Name = "btnTestRawFileCategories";
            this.btnTestRawFileCategories.Size = new System.Drawing.Size(75, 23);
            this.btnTestRawFileCategories.TabIndex = 45;
            this.btnTestRawFileCategories.Text = "Test naming";
            this.btnTestRawFileCategories.UseVisualStyleBackColor = true;
            this.btnTestRawFileCategories.Click += new System.EventHandler(this.btnTestRawFileCategories_Click);
            // 
            // txtBoxRawFileNamingTest
            // 
            this.txtBoxRawFileNamingTest.Location = new System.Drawing.Point(208, 599);
            this.txtBoxRawFileNamingTest.Name = "txtBoxRawFileNamingTest";
            this.txtBoxRawFileNamingTest.Size = new System.Drawing.Size(417, 20);
            this.txtBoxRawFileNamingTest.TabIndex = 44;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(478, 316);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(79, 13);
            this.label49.TabIndex = 43;
            this.label49.Text = "MS instruments";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(8, 316);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(70, 13);
            this.label45.TabIndex = 42;
            this.label45.Text = "Sample types";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(478, 27);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(76, 13);
            this.label44.TabIndex = 41;
            this.label44.Text = "LC instruments";
            // 
            // dgvMS
            // 
            this.dgvMS.AllowUserToResizeColumns = false;
            this.dgvMS.AllowUserToResizeRows = false;
            this.dgvMS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMS.GridColor = System.Drawing.SystemColors.Control;
            this.dgvMS.Location = new System.Drawing.Point(481, 332);
            this.dgvMS.Name = "dgvMS";
            this.dgvMS.RowHeadersVisible = false;
            this.dgvMS.RowTemplate.Height = 18;
            this.dgvMS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMS.ShowCellErrors = false;
            this.dgvMS.ShowCellToolTips = false;
            this.dgvMS.ShowRowErrors = false;
            this.dgvMS.Size = new System.Drawing.Size(422, 250);
            this.dgvMS.TabIndex = 40;
            this.dgvMS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMS_CellContentClick);
            this.dgvMS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMS_KeyDown);
            // 
            // dgvSample
            // 
            this.dgvSample.AllowUserToResizeColumns = false;
            this.dgvSample.AllowUserToResizeRows = false;
            this.dgvSample.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSample.GridColor = System.Drawing.SystemColors.Control;
            this.dgvSample.Location = new System.Drawing.Point(8, 332);
            this.dgvSample.Name = "dgvSample";
            this.dgvSample.RowHeadersVisible = false;
            this.dgvSample.RowTemplate.Height = 18;
            this.dgvSample.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSample.ShowCellErrors = false;
            this.dgvSample.ShowCellToolTips = false;
            this.dgvSample.ShowRowErrors = false;
            this.dgvSample.Size = new System.Drawing.Size(422, 250);
            this.dgvSample.TabIndex = 39;
            this.dgvSample.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSample_CellContentClick);
            this.dgvSample.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSample_KeyDown);
            // 
            // dgvLC
            // 
            this.dgvLC.AllowUserToResizeColumns = false;
            this.dgvLC.AllowUserToResizeRows = false;
            this.dgvLC.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLC.GridColor = System.Drawing.SystemColors.Control;
            this.dgvLC.Location = new System.Drawing.Point(481, 43);
            this.dgvLC.Name = "dgvLC";
            this.dgvLC.RowHeadersVisible = false;
            this.dgvLC.RowTemplate.Height = 18;
            this.dgvLC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLC.ShowCellErrors = false;
            this.dgvLC.ShowCellToolTips = false;
            this.dgvLC.ShowRowErrors = false;
            this.dgvLC.Size = new System.Drawing.Size(422, 250);
            this.dgvLC.TabIndex = 38;
            this.dgvLC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLC_CellContentClick);
            this.dgvLC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLC_KeyDown);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToResizeColumns = false;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.GridColor = System.Drawing.SystemColors.Control;
            this.dgvUser.Location = new System.Drawing.Point(8, 43);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowTemplate.Height = 18;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.ShowCellErrors = false;
            this.dgvUser.ShowCellToolTips = false;
            this.dgvUser.ShowRowErrors = false;
            this.dgvUser.Size = new System.Drawing.Size(422, 250);
            this.dgvUser.TabIndex = 37;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellContentClick);
            this.dgvUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUser_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name and emails";
            // 
            // EmailAndStorage
            // 
            this.EmailAndStorage.Controls.Add(this.chkBxEmail);
            this.EmailAndStorage.Controls.Add(this.mailPanel);
            this.EmailAndStorage.Controls.Add(this.chkBxStorageFile);
            this.EmailAndStorage.Controls.Add(this.pnlStorageFile);
            this.EmailAndStorage.Controls.Add(this.chkBxStorageSql);
            this.EmailAndStorage.Controls.Add(this.pnlStorageSql);
            this.EmailAndStorage.Location = new System.Drawing.Point(4, 22);
            this.EmailAndStorage.Name = "EmailAndStorage";
            this.EmailAndStorage.Size = new System.Drawing.Size(1157, 643);
            this.EmailAndStorage.TabIndex = 4;
            this.EmailAndStorage.Text = "Email and storage";
            this.EmailAndStorage.UseVisualStyleBackColor = true;
            // 
            // chkBxEmail
            // 
            this.chkBxEmail.AutoSize = true;
            this.chkBxEmail.Checked = true;
            this.chkBxEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxEmail.Location = new System.Drawing.Point(23, 111);
            this.chkBxEmail.Name = "chkBxEmail";
            this.chkBxEmail.Size = new System.Drawing.Size(151, 17);
            this.chkBxEmail.TabIndex = 17;
            this.chkBxEmail.Text = "Email notifications enabled";
            this.chkBxEmail.UseVisualStyleBackColor = true;
            this.chkBxEmail.CheckedChanged += new System.EventHandler(this.chkBxEmail_CheckedChanged);
            // 
            // mailPanel
            // 
            this.mailPanel.Controls.Add(this.txtBxMailServer);
            this.mailPanel.Controls.Add(this.txtBxMailPort);
            this.mailPanel.Controls.Add(this.label4);
            this.mailPanel.Controls.Add(this.txtBxMailUser);
            this.mailPanel.Controls.Add(this.label2);
            this.mailPanel.Controls.Add(this.txtBxMailPass);
            this.mailPanel.Controls.Add(this.label1);
            this.mailPanel.Controls.Add(this.label3);
            this.mailPanel.Location = new System.Drawing.Point(18, 119);
            this.mailPanel.Name = "mailPanel";
            this.mailPanel.Size = new System.Drawing.Size(164, 266);
            this.mailPanel.TabIndex = 16;
            // 
            // txtBxMailServer
            // 
            this.txtBxMailServer.Location = new System.Drawing.Point(12, 28);
            this.txtBxMailServer.Name = "txtBxMailServer";
            this.txtBxMailServer.Size = new System.Drawing.Size(135, 20);
            this.txtBxMailServer.TabIndex = 1;
            // 
            // txtBxMailPort
            // 
            this.txtBxMailPort.Location = new System.Drawing.Point(12, 67);
            this.txtBxMailPort.Name = "txtBxMailPort";
            this.txtBxMailPort.Size = new System.Drawing.Size(135, 20);
            this.txtBxMailPort.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port";
            // 
            // txtBxMailUser
            // 
            this.txtBxMailUser.Location = new System.Drawing.Point(12, 108);
            this.txtBxMailUser.Name = "txtBxMailUser";
            this.txtBxMailUser.Size = new System.Drawing.Size(135, 20);
            this.txtBxMailUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User name";
            // 
            // txtBxMailPass
            // 
            this.txtBxMailPass.Location = new System.Drawing.Point(12, 150);
            this.txtBxMailPass.Name = "txtBxMailPass";
            this.txtBxMailPass.PasswordChar = '*';
            this.txtBxMailPass.Size = new System.Drawing.Size(135, 20);
            this.txtBxMailPass.TabIndex = 4;
            this.txtBxMailPass.TextChanged += new System.EventHandler(this.txtBxMailPass_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail server address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // chkBxStorageFile
            // 
            this.chkBxStorageFile.AutoSize = true;
            this.chkBxStorageFile.Location = new System.Drawing.Point(23, 3);
            this.chkBxStorageFile.Name = "chkBxStorageFile";
            this.chkBxStorageFile.Size = new System.Drawing.Size(152, 17);
            this.chkBxStorageFile.TabIndex = 0;
            this.chkBxStorageFile.Text = "Simple file storage enabled";
            this.chkBxStorageFile.UseVisualStyleBackColor = true;
            this.chkBxStorageFile.CheckedChanged += new System.EventHandler(this.chkBxStorageFile_CheckedChanged);
            // 
            // pnlStorageFile
            // 
            this.pnlStorageFile.Controls.Add(this.label38);
            this.pnlStorageFile.Controls.Add(this.btnStorageFile);
            this.pnlStorageFile.Controls.Add(this.txtBxStorageFile);
            this.pnlStorageFile.Location = new System.Drawing.Point(9, 15);
            this.pnlStorageFile.Name = "pnlStorageFile";
            this.pnlStorageFile.Size = new System.Drawing.Size(603, 90);
            this.pnlStorageFile.TabIndex = 15;
            this.pnlStorageFile.Visible = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(14, 12);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(129, 13);
            this.label38.TabIndex = 2;
            this.label38.Text = "Specify file to save results";
            // 
            // btnStorageFile
            // 
            this.btnStorageFile.Location = new System.Drawing.Point(437, 27);
            this.btnStorageFile.Name = "btnStorageFile";
            this.btnStorageFile.Size = new System.Drawing.Size(75, 23);
            this.btnStorageFile.TabIndex = 1;
            this.btnStorageFile.Text = "Browse";
            this.btnStorageFile.UseVisualStyleBackColor = true;
            this.btnStorageFile.Click += new System.EventHandler(this.BrowseStorageFile_Click);
            // 
            // txtBxStorageFile
            // 
            this.txtBxStorageFile.Location = new System.Drawing.Point(14, 30);
            this.txtBxStorageFile.Name = "txtBxStorageFile";
            this.txtBxStorageFile.Size = new System.Drawing.Size(417, 20);
            this.txtBxStorageFile.TabIndex = 0;
            // 
            // chkBxStorageSql
            // 
            this.chkBxStorageSql.AutoSize = true;
            this.chkBxStorageSql.Location = new System.Drawing.Point(312, 111);
            this.chkBxStorageSql.Name = "chkBxStorageSql";
            this.chkBxStorageSql.Size = new System.Drawing.Size(151, 17);
            this.chkBxStorageSql.TabIndex = 14;
            this.chkBxStorageSql.Text = "Database storage enabled";
            this.chkBxStorageSql.UseVisualStyleBackColor = true;
            this.chkBxStorageSql.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // pnlStorageSql
            // 
            this.pnlStorageSql.Controls.Add(this.txtBxSqlServerTable);
            this.pnlStorageSql.Controls.Add(this.label7);
            this.pnlStorageSql.Controls.Add(this.btnCreateNewColumnsSqlTable);
            this.pnlStorageSql.Controls.Add(this.btnSqlServerTestConnection);
            this.pnlStorageSql.Controls.Add(this.btnCreateSqlTable);
            this.pnlStorageSql.Controls.Add(this.txtBxSqlServerAddress);
            this.pnlStorageSql.Controls.Add(this.txtBxSqlServerDatabase);
            this.pnlStorageSql.Controls.Add(this.label12);
            this.pnlStorageSql.Controls.Add(this.txtBxSqlServerUser);
            this.pnlStorageSql.Controls.Add(this.label14);
            this.pnlStorageSql.Controls.Add(this.txtBxSqlServerPass);
            this.pnlStorageSql.Controls.Add(this.label15);
            this.pnlStorageSql.Controls.Add(this.label16);
            this.pnlStorageSql.Location = new System.Drawing.Point(297, 122);
            this.pnlStorageSql.Name = "pnlStorageSql";
            this.pnlStorageSql.Size = new System.Drawing.Size(187, 321);
            this.pnlStorageSql.TabIndex = 13;
            this.pnlStorageSql.Visible = false;
            // 
            // txtBxSqlServerTable
            // 
            this.txtBxSqlServerTable.Location = new System.Drawing.Point(12, 110);
            this.txtBxSqlServerTable.Name = "txtBxSqlServerTable";
            this.txtBxSqlServerTable.Size = new System.Drawing.Size(98, 20);
            this.txtBxSqlServerTable.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Table";
            // 
            // btnCreateNewColumnsSqlTable
            // 
            this.btnCreateNewColumnsSqlTable.Location = new System.Drawing.Point(12, 286);
            this.btnCreateNewColumnsSqlTable.Name = "btnCreateNewColumnsSqlTable";
            this.btnCreateNewColumnsSqlTable.Size = new System.Drawing.Size(98, 23);
            this.btnCreateNewColumnsSqlTable.TabIndex = 17;
            this.btnCreateNewColumnsSqlTable.Text = "Update Columns";
            this.btnCreateNewColumnsSqlTable.UseVisualStyleBackColor = true;
            this.btnCreateNewColumnsSqlTable.Click += new System.EventHandler(this.btnCreateNewColumnsSqlTable_Click);
            // 
            // btnSqlServerTestConnection
            // 
            this.btnSqlServerTestConnection.Location = new System.Drawing.Point(12, 228);
            this.btnSqlServerTestConnection.Name = "btnSqlServerTestConnection";
            this.btnSqlServerTestConnection.Size = new System.Drawing.Size(98, 23);
            this.btnSqlServerTestConnection.TabIndex = 13;
            this.btnSqlServerTestConnection.Text = "Test Connection";
            this.btnSqlServerTestConnection.UseVisualStyleBackColor = true;
            this.btnSqlServerTestConnection.Click += new System.EventHandler(this.btnSqlServerTestConnection_Click);
            // 
            // btnCreateSqlTable
            // 
            this.btnCreateSqlTable.Location = new System.Drawing.Point(12, 257);
            this.btnCreateSqlTable.Name = "btnCreateSqlTable";
            this.btnCreateSqlTable.Size = new System.Drawing.Size(98, 23);
            this.btnCreateSqlTable.TabIndex = 12;
            this.btnCreateSqlTable.Text = "Create new table";
            this.btnCreateSqlTable.UseVisualStyleBackColor = true;
            this.btnCreateSqlTable.Click += new System.EventHandler(this.btnCreateSqlTable_Click);
            // 
            // txtBxSqlServerAddress
            // 
            this.txtBxSqlServerAddress.Location = new System.Drawing.Point(12, 28);
            this.txtBxSqlServerAddress.Name = "txtBxSqlServerAddress";
            this.txtBxSqlServerAddress.Size = new System.Drawing.Size(98, 20);
            this.txtBxSqlServerAddress.TabIndex = 3;
            // 
            // txtBxSqlServerDatabase
            // 
            this.txtBxSqlServerDatabase.Location = new System.Drawing.Point(12, 69);
            this.txtBxSqlServerDatabase.Name = "txtBxSqlServerDatabase";
            this.txtBxSqlServerDatabase.Size = new System.Drawing.Size(98, 20);
            this.txtBxSqlServerDatabase.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Database";
            // 
            // txtBxSqlServerUser
            // 
            this.txtBxSqlServerUser.Location = new System.Drawing.Point(12, 151);
            this.txtBxSqlServerUser.Name = "txtBxSqlServerUser";
            this.txtBxSqlServerUser.Size = new System.Drawing.Size(98, 20);
            this.txtBxSqlServerUser.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "User name";
            // 
            // txtBxSqlServerPass
            // 
            this.txtBxSqlServerPass.Location = new System.Drawing.Point(12, 192);
            this.txtBxSqlServerPass.Name = "txtBxSqlServerPass";
            this.txtBxSqlServerPass.PasswordChar = '*';
            this.txtBxSqlServerPass.Size = new System.Drawing.Size(98, 20);
            this.txtBxSqlServerPass.TabIndex = 5;
            this.txtBxSqlServerPass.TextChanged += new System.EventHandler(this.txtBxSqlServerPass_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "SQL server address";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Password";
            // 
            // ResultInterpretation
            // 
            this.ResultInterpretation.Controls.Add(this.label61);
            this.ResultInterpretation.Controls.Add(this.txtBxRIName);
            this.ResultInterpretation.Controls.Add(this.label57);
            this.ResultInterpretation.Controls.Add(this.label58);
            this.ResultInterpretation.Controls.Add(this.label59);
            this.ResultInterpretation.Controls.Add(this.label60);
            this.ResultInterpretation.Controls.Add(this.txtBxRIMessage);
            this.ResultInterpretation.Controls.Add(this.txtBxRICompareValue5);
            this.ResultInterpretation.Controls.Add(this.cmbBxRIComparer5);
            this.ResultInterpretation.Controls.Add(this.cmbBxResultItem5);
            this.ResultInterpretation.Controls.Add(this.label54);
            this.ResultInterpretation.Controls.Add(this.label55);
            this.ResultInterpretation.Controls.Add(this.label56);
            this.ResultInterpretation.Controls.Add(this.txtBxRICompareValue4);
            this.ResultInterpretation.Controls.Add(this.cmbBxRIComparer4);
            this.ResultInterpretation.Controls.Add(this.cmbBxResultItem4);
            this.ResultInterpretation.Controls.Add(this.label50);
            this.ResultInterpretation.Controls.Add(this.label51);
            this.ResultInterpretation.Controls.Add(this.label52);
            this.ResultInterpretation.Controls.Add(this.txtBxRICompareValue3);
            this.ResultInterpretation.Controls.Add(this.cmbBxRIComparer3);
            this.ResultInterpretation.Controls.Add(this.cmbBxResultItem3);
            this.ResultInterpretation.Controls.Add(this.label46);
            this.ResultInterpretation.Controls.Add(this.label47);
            this.ResultInterpretation.Controls.Add(this.label48);
            this.ResultInterpretation.Controls.Add(this.txtBxRICompareValue2);
            this.ResultInterpretation.Controls.Add(this.cmbBxRIComparer2);
            this.ResultInterpretation.Controls.Add(this.cmbBxResultItem2);
            this.ResultInterpretation.Controls.Add(this.label43);
            this.ResultInterpretation.Controls.Add(this.label42);
            this.ResultInterpretation.Controls.Add(this.label41);
            this.ResultInterpretation.Controls.Add(this.txtBxRICompareValue1);
            this.ResultInterpretation.Controls.Add(this.cmbBxRIComparer1);
            this.ResultInterpretation.Controls.Add(this.cmbBxResultItem1);
            this.ResultInterpretation.Controls.Add(this.label40);
            this.ResultInterpretation.Controls.Add(this.btnRemoveInterpretationKey);
            this.ResultInterpretation.Controls.Add(this.btnAddInterpretationKey);
            this.ResultInterpretation.Controls.Add(this.lstBxInterpretation);
            this.ResultInterpretation.Location = new System.Drawing.Point(4, 22);
            this.ResultInterpretation.Name = "ResultInterpretation";
            this.ResultInterpretation.Size = new System.Drawing.Size(1157, 643);
            this.ResultInterpretation.TabIndex = 9;
            this.ResultInterpretation.Text = "Result interpretation";
            this.ResultInterpretation.UseVisualStyleBackColor = true;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(269, 55);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(58, 13);
            this.label61.TabIndex = 52;
            this.label61.Text = "Rule name";
            // 
            // txtBxRIName
            // 
            this.txtBxRIName.Location = new System.Drawing.Point(333, 51);
            this.txtBxRIName.Name = "txtBxRIName";
            this.txtBxRIName.Size = new System.Drawing.Size(213, 20);
            this.txtBxRIName.TabIndex = 51;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(270, 96);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(50, 13);
            this.label57.TabIndex = 50;
            this.label57.Text = "Message";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(796, 289);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(28, 13);
            this.label58.TabIndex = 49;
            this.label58.Text = "than";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(715, 289);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(14, 13);
            this.label59.TabIndex = 48;
            this.label59.Text = "is";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(269, 289);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(33, 13);
            this.label60.TabIndex = 47;
            this.label60.Text = "and if";
            // 
            // txtBxRIMessage
            // 
            this.txtBxRIMessage.Location = new System.Drawing.Point(333, 93);
            this.txtBxRIMessage.Name = "txtBxRIMessage";
            this.txtBxRIMessage.Size = new System.Drawing.Size(628, 20);
            this.txtBxRIMessage.TabIndex = 46;
            // 
            // txtBxRICompareValue5
            // 
            this.txtBxRICompareValue5.Location = new System.Drawing.Point(830, 285);
            this.txtBxRICompareValue5.Name = "txtBxRICompareValue5";
            this.txtBxRICompareValue5.Size = new System.Drawing.Size(131, 20);
            this.txtBxRICompareValue5.TabIndex = 45;
            // 
            // cmbBxRIComparer5
            // 
            this.cmbBxRIComparer5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRIComparer5.FormattingEnabled = true;
            this.cmbBxRIComparer5.Location = new System.Drawing.Point(735, 285);
            this.cmbBxRIComparer5.Name = "cmbBxRIComparer5";
            this.cmbBxRIComparer5.Size = new System.Drawing.Size(55, 21);
            this.cmbBxRIComparer5.TabIndex = 44;
            // 
            // cmbBxResultItem5
            // 
            this.cmbBxResultItem5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxResultItem5.FormattingEnabled = true;
            this.cmbBxResultItem5.Location = new System.Drawing.Point(308, 285);
            this.cmbBxResultItem5.Name = "cmbBxResultItem5";
            this.cmbBxResultItem5.Size = new System.Drawing.Size(401, 21);
            this.cmbBxResultItem5.TabIndex = 43;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(796, 259);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(28, 13);
            this.label54.TabIndex = 41;
            this.label54.Text = "than";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(715, 259);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(14, 13);
            this.label55.TabIndex = 40;
            this.label55.Text = "is";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(269, 259);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(33, 13);
            this.label56.TabIndex = 39;
            this.label56.Text = "and if";
            // 
            // txtBxRICompareValue4
            // 
            this.txtBxRICompareValue4.Location = new System.Drawing.Point(830, 255);
            this.txtBxRICompareValue4.Name = "txtBxRICompareValue4";
            this.txtBxRICompareValue4.Size = new System.Drawing.Size(131, 20);
            this.txtBxRICompareValue4.TabIndex = 37;
            // 
            // cmbBxRIComparer4
            // 
            this.cmbBxRIComparer4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRIComparer4.FormattingEnabled = true;
            this.cmbBxRIComparer4.Location = new System.Drawing.Point(735, 255);
            this.cmbBxRIComparer4.Name = "cmbBxRIComparer4";
            this.cmbBxRIComparer4.Size = new System.Drawing.Size(55, 21);
            this.cmbBxRIComparer4.TabIndex = 36;
            // 
            // cmbBxResultItem4
            // 
            this.cmbBxResultItem4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxResultItem4.FormattingEnabled = true;
            this.cmbBxResultItem4.Location = new System.Drawing.Point(308, 255);
            this.cmbBxResultItem4.Name = "cmbBxResultItem4";
            this.cmbBxResultItem4.Size = new System.Drawing.Size(401, 21);
            this.cmbBxResultItem4.TabIndex = 35;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(796, 229);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(28, 13);
            this.label50.TabIndex = 33;
            this.label50.Text = "than";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(715, 229);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(14, 13);
            this.label51.TabIndex = 32;
            this.label51.Text = "is";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(269, 229);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(33, 13);
            this.label52.TabIndex = 31;
            this.label52.Text = "and if";
            // 
            // txtBxRICompareValue3
            // 
            this.txtBxRICompareValue3.Location = new System.Drawing.Point(830, 225);
            this.txtBxRICompareValue3.Name = "txtBxRICompareValue3";
            this.txtBxRICompareValue3.Size = new System.Drawing.Size(131, 20);
            this.txtBxRICompareValue3.TabIndex = 29;
            // 
            // cmbBxRIComparer3
            // 
            this.cmbBxRIComparer3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRIComparer3.FormattingEnabled = true;
            this.cmbBxRIComparer3.Location = new System.Drawing.Point(735, 225);
            this.cmbBxRIComparer3.Name = "cmbBxRIComparer3";
            this.cmbBxRIComparer3.Size = new System.Drawing.Size(55, 21);
            this.cmbBxRIComparer3.TabIndex = 28;
            // 
            // cmbBxResultItem3
            // 
            this.cmbBxResultItem3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxResultItem3.FormattingEnabled = true;
            this.cmbBxResultItem3.Location = new System.Drawing.Point(308, 225);
            this.cmbBxResultItem3.Name = "cmbBxResultItem3";
            this.cmbBxResultItem3.Size = new System.Drawing.Size(401, 21);
            this.cmbBxResultItem3.TabIndex = 27;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(796, 199);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(28, 13);
            this.label46.TabIndex = 25;
            this.label46.Text = "than";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(715, 199);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(14, 13);
            this.label47.TabIndex = 24;
            this.label47.Text = "is";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(269, 199);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(33, 13);
            this.label48.TabIndex = 23;
            this.label48.Text = "and if";
            // 
            // txtBxRICompareValue2
            // 
            this.txtBxRICompareValue2.Location = new System.Drawing.Point(830, 195);
            this.txtBxRICompareValue2.Name = "txtBxRICompareValue2";
            this.txtBxRICompareValue2.Size = new System.Drawing.Size(131, 20);
            this.txtBxRICompareValue2.TabIndex = 21;
            // 
            // cmbBxRIComparer2
            // 
            this.cmbBxRIComparer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRIComparer2.FormattingEnabled = true;
            this.cmbBxRIComparer2.Location = new System.Drawing.Point(735, 195);
            this.cmbBxRIComparer2.Name = "cmbBxRIComparer2";
            this.cmbBxRIComparer2.Size = new System.Drawing.Size(55, 21);
            this.cmbBxRIComparer2.TabIndex = 20;
            // 
            // cmbBxResultItem2
            // 
            this.cmbBxResultItem2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxResultItem2.FormattingEnabled = true;
            this.cmbBxResultItem2.Location = new System.Drawing.Point(308, 195);
            this.cmbBxResultItem2.Name = "cmbBxResultItem2";
            this.cmbBxResultItem2.Size = new System.Drawing.Size(401, 21);
            this.cmbBxResultItem2.TabIndex = 19;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(796, 170);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(28, 13);
            this.label43.TabIndex = 17;
            this.label43.Text = "than";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(715, 170);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(14, 13);
            this.label42.TabIndex = 16;
            this.label42.Text = "is";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(269, 170);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(13, 13);
            this.label41.TabIndex = 15;
            this.label41.Text = "If";
            // 
            // txtBxRICompareValue1
            // 
            this.txtBxRICompareValue1.Location = new System.Drawing.Point(830, 167);
            this.txtBxRICompareValue1.Name = "txtBxRICompareValue1";
            this.txtBxRICompareValue1.Size = new System.Drawing.Size(131, 20);
            this.txtBxRICompareValue1.TabIndex = 13;
            // 
            // cmbBxRIComparer1
            // 
            this.cmbBxRIComparer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxRIComparer1.FormattingEnabled = true;
            this.cmbBxRIComparer1.Location = new System.Drawing.Point(735, 167);
            this.cmbBxRIComparer1.Name = "cmbBxRIComparer1";
            this.cmbBxRIComparer1.Size = new System.Drawing.Size(55, 21);
            this.cmbBxRIComparer1.TabIndex = 12;
            // 
            // cmbBxResultItem1
            // 
            this.cmbBxResultItem1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxResultItem1.FormattingEnabled = true;
            this.cmbBxResultItem1.Location = new System.Drawing.Point(308, 167);
            this.cmbBxResultItem1.Name = "cmbBxResultItem1";
            this.cmbBxResultItem1.Size = new System.Drawing.Size(401, 21);
            this.cmbBxResultItem1.TabIndex = 11;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(8, 10);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(101, 13);
            this.label40.TabIndex = 10;
            this.label40.Text = "Result interpretation";
            // 
            // btnRemoveInterpretationKey
            // 
            this.btnRemoveInterpretationKey.Location = new System.Drawing.Point(91, 26);
            this.btnRemoveInterpretationKey.Name = "btnRemoveInterpretationKey";
            this.btnRemoveInterpretationKey.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveInterpretationKey.TabIndex = 2;
            this.btnRemoveInterpretationKey.Text = "Remove";
            this.btnRemoveInterpretationKey.UseVisualStyleBackColor = true;
            this.btnRemoveInterpretationKey.Click += new System.EventHandler(this.btnRemoveInterpretationKey_Click);
            // 
            // btnAddInterpretationKey
            // 
            this.btnAddInterpretationKey.Location = new System.Drawing.Point(9, 26);
            this.btnAddInterpretationKey.Name = "btnAddInterpretationKey";
            this.btnAddInterpretationKey.Size = new System.Drawing.Size(75, 23);
            this.btnAddInterpretationKey.TabIndex = 1;
            this.btnAddInterpretationKey.Text = "Add";
            this.btnAddInterpretationKey.UseVisualStyleBackColor = true;
            this.btnAddInterpretationKey.Click += new System.EventHandler(this.btnAddInterpretationKey_Click);
            // 
            // lstBxInterpretation
            // 
            this.lstBxInterpretation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBxInterpretation.FormattingEnabled = true;
            this.lstBxInterpretation.Location = new System.Drawing.Point(8, 55);
            this.lstBxInterpretation.Name = "lstBxInterpretation";
            this.lstBxInterpretation.Size = new System.Drawing.Size(237, 576);
            this.lstBxInterpretation.TabIndex = 0;
            // 
            // LogView
            // 
            this.LogView.Controls.Add(this.log);
            this.LogView.Location = new System.Drawing.Point(4, 22);
            this.LogView.Name = "LogView";
            this.LogView.Size = new System.Drawing.Size(1157, 643);
            this.LogView.TabIndex = 7;
            this.LogView.Text = "Log";
            this.LogView.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(3, 32);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(1149, 602);
            this.log.TabIndex = 1;
            // 
            // Debug
            // 
            this.Debug.Controls.Add(this.button3);
            this.Debug.Controls.Add(this.button2);
            this.Debug.Controls.Add(this.button1);
            this.Debug.Controls.Add(this.textBox1);
            this.Debug.Location = new System.Drawing.Point(4, 22);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(1157, 643);
            this.Debug.TabIndex = 2;
            this.Debug.Text = "Debug";
            this.Debug.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(313, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 68);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(504, 368);
            this.textBox1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 672);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1168, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1168, 694);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "AutoProt version 0.0.1.21";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.Workflows.ResumeLayout(false);
            this.Workflows.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.Morpheus.ResumeLayout(false);
            this.Morpheus.PerformLayout();
            this.pnlMorpheus.ResumeLayout(false);
            this.pnlMorpheus.PerformLayout();
            this.grpBxMorpheusPrecursor.ResumeLayout(false);
            this.grpBxMorpheusPrecursor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumAssumedPrecursorChargeState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumAssumedPrecursorChargeState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecursorMassTolerance)).EndInit();
            this.grpBxMorpheusMS2Analysis.ResumeLayout(false);
            this.grpBxMorpheusMS2Analysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumFalseDiscoveryRatePercent)).EndInit();
            this.grpBxMorpheusMS2Filtering.ResumeLayout(false);
            this.grpBxMorpheusMS2Filtering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPeaks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductMassTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxVariableModIsoforms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPrecursorMonoPeakOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPrecursorMonoPeakOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMissedCleavages)).EndInit();
            this.Base.ResumeLayout(false);
            this.Base.PerformLayout();
            this.pnlBaseParameters.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseThresholdFluctuationsPercent)).EndInit();
            this.grpBxFullMStargets.ResumeLayout(false);
            this.grpBxFullMStargets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePolymerPercentile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseAdductPercentile)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseMassTolerance)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseIonThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseSNthreshold)).EndInit();
            this.External.ResumeLayout(false);
            this.External.PerformLayout();
            this.AdvancedSettings.ResumeLayout(false);
            this.AdvancedSettings.PerformLayout();
            this.grpBxAdvancedStatusLog.ResumeLayout(false);
            this.grpBxAdvancedStatusLog.PerformLayout();
            this.grpBxAdvancedExternalTool1.ResumeLayout(false);
            this.grpBxAdvancedExternalTool1.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExternalTimeout)).EndInit();
            this.ManualAnalysis.ResumeLayout(false);
            this.ManualAnalysis.PerformLayout();
            this.AutomatedAnalysis.ResumeLayout(false);
            this.AutomatedAnalysis.PerformLayout();
            this.pnlCodeNam.ResumeLayout(false);
            this.pnlCodeNam.PerformLayout();
            this.ResultOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.FileNameParseRules.ResumeLayout(false);
            this.FileNameParseRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.EmailAndStorage.ResumeLayout(false);
            this.EmailAndStorage.PerformLayout();
            this.mailPanel.ResumeLayout(false);
            this.mailPanel.PerformLayout();
            this.pnlStorageFile.ResumeLayout(false);
            this.pnlStorageFile.PerformLayout();
            this.pnlStorageSql.ResumeLayout(false);
            this.pnlStorageSql.PerformLayout();
            this.ResultInterpretation.ResumeLayout(false);
            this.ResultInterpretation.PerformLayout();
            this.LogView.ResumeLayout(false);
            this.Debug.ResumeLayout(false);
            this.Debug.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        
        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ManualAnalysis;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button Analyze;
        private System.Windows.Forms.Button btnRemoveRawFiles;
        private System.Windows.Forms.Button addRawFilesBtn;
        private System.Windows.Forms.TabPage AutomatedAnalysis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBxStorageSql;
        private System.Windows.Forms.Panel pnlStorageSql;
        private System.Windows.Forms.Button btnSqlServerTestConnection;
        private System.Windows.Forms.Button btnCreateSqlTable;
        private System.Windows.Forms.TextBox txtBxSqlServerAddress;
        private System.Windows.Forms.TextBox txtBxSqlServerDatabase;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBxSqlServerUser;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBxSqlServerPass;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBxWatchFolder0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreateNewColumnsSqlTable;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnNewSettings;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnWatchBrowse0;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDeleteSettings;
        private System.Windows.Forms.TextBox txtbxSettingName;
        private System.Windows.Forms.ListBox lstBxWorkflows;
        private System.Windows.Forms.ComboBox cmbBxAnalysisSettingsManual;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnWatch0;
        private System.Windows.Forms.Button btnDeleteAnalysisCode;
        private System.Windows.Forms.Button btnAddAnalysisCode;
        private System.Windows.Forms.TextBox txtBxCodePattern;
        private System.Windows.Forms.ListBox lstBxCodeToAnalysis;
        private System.Windows.Forms.Label lblCodeName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbBxCodeName;
        private System.Windows.Forms.Button btnWatchBrowse1;
        private System.Windows.Forms.TextBox txtBxWatchFolder1;
        private System.Windows.Forms.Button btnBrowseFastLocal;
        private System.Windows.Forms.TextBox txtBxFastLocal;
        private System.Windows.Forms.Button btnWatch1;
        private System.Windows.Forms.Button btnWatch4;
        private System.Windows.Forms.Button btnWatchBrowse4;
        private System.Windows.Forms.TextBox txtBxWatchFolder4;
        private System.Windows.Forms.Button btnWatch3;
        private System.Windows.Forms.Button btnWatchBrowse3;
        private System.Windows.Forms.TextBox txtBxWatchFolder3;
        private System.Windows.Forms.Button btnWatch2;
        private System.Windows.Forms.Button btnWatchBrowse2;
        private System.Windows.Forms.TextBox txtBxWatchFolder2;
        private System.Windows.Forms.Label lblCodeNameToAnalysis;
        private System.Windows.Forms.CheckBox chkBxCodeName;
        private System.Windows.Forms.CheckBox chkBxLocalFolder;
        private System.Windows.Forms.TextBox txtBxSqlServerTable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstBxRawFiles;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage Base;
        private System.Windows.Forms.TabPage Morpheus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numBaseSNthreshold;
        private System.Windows.Forms.CheckBox chkMinimizeMemoryUsage;
        private System.Windows.Forms.GroupBox grpBxMorpheusMS2Analysis;
        private System.Windows.Forms.CheckBox chkDeisotope;
        private System.Windows.Forms.CheckBox chkAssignChargeStates;
        private System.Windows.Forms.GroupBox grpBxMorpheusPrecursor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numMinimumAssumedPrecursorChargeState;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numMaximumAssumedPrecursorChargeState;
        private System.Windows.Forms.GroupBox grpBxMorpheusMS2Filtering;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtRelativeThresholdPercent;
        private System.Windows.Forms.TextBox txtAbsoluteThreshold;
        private System.Windows.Forms.CheckBox chkMaxNumPeaks;
        private System.Windows.Forms.NumericUpDown numMaxPeaks;
        private System.Windows.Forms.CheckBox chkRelativeThreshold;
        private System.Windows.Forms.CheckBox chkAbsoluteThreshold;
        private System.Windows.Forms.TextBox txtFastaFile;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numMaxThreads;
        private System.Windows.Forms.Button btnBrowseFasta;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboProtease;
        private System.Windows.Forms.CheckBox chkPrecursorMonoisotopicPeakCorrection;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numMaxPrecursorMonoPeakOffset;
        private System.Windows.Forms.NumericUpDown numMaxMissedCleavages;
        private System.Windows.Forms.NumericUpDown numMinPrecursorMonoPeakOffset;
        private System.Windows.Forms.ComboBox cboInitiatorMethionineBehavior;
        private System.Windows.Forms.CheckBox chkOnTheFlyDecoys;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chkConsiderModifiedUnique;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown numMaxVariableModIsoforms;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboProductMassType;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown numProductMassTolerance;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cboProductMassToleranceUnits;
        private System.Windows.Forms.NumericUpDown numMaximumFalseDiscoveryRatePercent;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cboPrecursorMassType;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown numPrecursorMassTolerance;
        private System.Windows.Forms.ComboBox cboPrecursorMassToleranceUnits;
        private System.Windows.Forms.TabPage Debug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnVariableModificationRemove;
        private System.Windows.Forms.Button btnVariableModificationAdd;
        private System.Windows.Forms.ListBox lstBxVariableModificationsSelected;
        private System.Windows.Forms.ListBox lstBxVariableModificationsAll;
        private System.Windows.Forms.Button btnFixedModificationRemove;
        private System.Windows.Forms.Button btnFixedModificationAdd;
        private System.Windows.Forms.ListBox lstBxFixedModificationsSelected;
        private System.Windows.Forms.ListBox lstBxFixedModificationsAll;
        private System.Windows.Forms.TabPage Workflows;
        private System.Windows.Forms.TabPage ResultOverview;
        private System.Windows.Forms.TabPage FileNameParseRules;
        private System.Windows.Forms.TabPage EmailAndStorage;
        private System.Windows.Forms.TabPage LogView;
        private System.Windows.Forms.Button btnCodeNameDown;
        private System.Windows.Forms.Button btnCodeNameUp;
        private System.Windows.Forms.Button btnCodeNameCheck;
        private System.Windows.Forms.TextBox txtBxCodeNameCheck;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.CheckBox chkBxStorageFile;
        private System.Windows.Forms.Panel pnlStorageFile;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btnStorageFile;
        private System.Windows.Forms.TextBox txtBxStorageFile;
        private System.Windows.Forms.CheckBox chkBxEnableMorpheus;
        private System.Windows.Forms.Panel pnlMorpheus;
        private System.Windows.Forms.CheckBox chkBxEnableBaseAnalysis;
        private System.Windows.Forms.Panel pnlBaseParameters;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown numBaseIonThreshold;
        private System.Windows.Forms.Panel pnlCodeNam;
        private System.Windows.Forms.Label lblAutomatedSelectWorkflow;
        private System.Windows.Forms.TabPage ResultInterpretation;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox txtBxRIMessage;
        private System.Windows.Forms.TextBox txtBxRICompareValue5;
        private System.Windows.Forms.ComboBox cmbBxRIComparer5;
        private System.Windows.Forms.ComboBox cmbBxResultItem5;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtBxRICompareValue4;
        private System.Windows.Forms.ComboBox cmbBxRIComparer4;
        private System.Windows.Forms.ComboBox cmbBxResultItem4;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtBxRICompareValue3;
        private System.Windows.Forms.ComboBox cmbBxRIComparer3;
        private System.Windows.Forms.ComboBox cmbBxResultItem3;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtBxRICompareValue2;
        private System.Windows.Forms.ComboBox cmbBxRIComparer2;
        private System.Windows.Forms.ComboBox cmbBxResultItem2;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtBxRICompareValue1;
        private System.Windows.Forms.ComboBox cmbBxRIComparer1;
        private System.Windows.Forms.ComboBox cmbBxResultItem1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button btnRemoveInterpretationKey;
        private System.Windows.Forms.Button btnAddInterpretationKey;
        private System.Windows.Forms.ListBox lstBxInterpretation;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox txtBxRIName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbBxAutomatedDefault;
        private System.Windows.Forms.CheckBox chkBxEmail;
        private System.Windows.Forms.Panel mailPanel;
        private System.Windows.Forms.TextBox txtBxMailServer;
        private System.Windows.Forms.TextBox txtBxMailPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxMailUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxMailPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.DataGridView dgvMS;
        private System.Windows.Forms.DataGridView dgvSample;
        private System.Windows.Forms.DataGridView dgvLC;
        private System.Windows.Forms.Button btnTestRawFileCategories;
        private System.Windows.Forms.TextBox txtBoxRawFileNamingTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage External;
        private System.Windows.Forms.CheckBox chkBxExternal1Enable;
        private System.Windows.Forms.GroupBox grpBxFullMStargets;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtBxBasePolymerZ3;
        private System.Windows.Forms.TextBox txtBxBasePolymerMz4;
        private System.Windows.Forms.TextBox txtBxBasePolymerZ4;
        private System.Windows.Forms.TextBox txtBxBasePolymerMz3;
        private System.Windows.Forms.TextBox txtBxBasePolymerZ2;
        private System.Windows.Forms.TextBox txtBxBasePolymerMz2;
        private System.Windows.Forms.TextBox txtBxBasePolymerZ1;
        private System.Windows.Forms.TextBox txtBxBasePolymerMz1;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtBxBasePolymerZ0;
        private System.Windows.Forms.TextBox txtBxBasePolymerMz0;
        private System.Windows.Forms.ListBox lstBxBasePolymers;
        private System.Windows.Forms.NumericUpDown numBaseMassTolerance;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.ListBox lstBxBaseAdducts;
        private System.Windows.Forms.TextBox txtBxBaseAdductsMZ;
        private System.Windows.Forms.NumericUpDown numBasePolymerPercentile;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.NumericUpDown numBaseAdductPercentile;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.CheckBox chkBxBaseAdductEnabled;
        private System.Windows.Forms.Label lblBaseAdductFixed;
        private System.Windows.Forms.Button btnBaseAdductReset;
        private System.Windows.Forms.Button btnBasePolymerReset;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.NumericUpDown numBaseThresholdFluctuationsPercent;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox txtBxBasePolymerName;
        private System.Windows.Forms.TabPage AdvancedSettings;
        private System.Windows.Forms.GroupBox grpBxAdvancedExternalTool1;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox txtBxExternal1ResultName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdBtnExternal1Column;
        private System.Windows.Forms.RadioButton rdBtnExternal1Row;
        private System.Windows.Forms.ListBox lstBxExternal1;
        private System.Windows.Forms.Button btnExternal1Remove;
        private System.Windows.Forms.TextBox txtBxExternal1ResultFile;
        private System.Windows.Forms.Button btnExternal1New;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.NumericUpDown numExternalTimeout;
        private System.Windows.Forms.TextBox txtBxExternal1Arguments;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox txtBxExternal1Executable;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnExternal1Browse;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox grpBxAdvancedStatusLog;
        private System.Windows.Forms.CheckBox chkBxShowAdvanced;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button btnBaseStatusLogRemove;
        private System.Windows.Forms.TextBox txtBxBaseStatusLogNewItems;
        private System.Windows.Forms.Button btnBaseStatusLogAdd;
        private System.Windows.Forms.CheckBox chkBxBaseStatusLogCalcIQR;
        private System.Windows.Forms.CheckBox chkBxBaseStatusLogCalcMedian;
        private System.Windows.Forms.CheckBox chkBxBaseStatusLogCalcMax;
        private System.Windows.Forms.CheckBox chkBxBaseStatusLogCalcMin;
        private System.Windows.Forms.ListBox lstBxBaseStatusLogItems;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.RadioButton rdBtnExternal1SplitSemicolon;
        private System.Windows.Forms.RadioButton rdBtnExternal1SplitTab;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

