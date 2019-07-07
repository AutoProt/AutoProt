using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AutoProt
{
    public partial class Form1 : Form
    {

        private ViewModelMain viewmodel;

        public Form1()
        {
            try
            {
                InitializeComponent();
                viewmodel = new ViewModelMain();
                LoadMorpheusChoices();
                SetBindings();
                tabControl1.TabPages["Debug"].Dispose();
                viewmodel.logList.ListChanged += HandleLogUpdate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nStacktrace:" + ex.StackTrace);
            }

            
        }
        
        
        private void SetBindings()
        {
            //just to have a name
            SettingsForAnalysis analysisSettings;
            CodeName codename;

            //Datagridview binding with some settings to make it faster
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridView.RowHeadersVisible = false;
            dataGridView.DataSource = viewmodel.ResultTable;
            dataGridView.RowHeadersVisible = true;


            dgvUser.DataSource = viewmodel.uisettings.UserList;
            dgvUser.Columns[0].HeaderText = "User";
            dgvUser.Columns[1].HeaderText = "Email";
            dgvSample.DataSource = viewmodel.uisettings.SamplesList;
            dgvLC.DataSource = viewmodel.uisettings.LcList;
            dgvMS.DataSource = viewmodel.uisettings.MsList;

            //TextBoxes
            txtBxStorageFile.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Storagefile), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxWatchFolder0.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Monitorfolder1), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxWatchFolder1.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Monitorfolder2), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxWatchFolder2.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Monitorfolder3), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxWatchFolder3.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Monitorfolder4), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxWatchFolder4.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Monitorfolder5), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxFastLocal.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Fastlocaldrive), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxMailServer.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Mailserveradress), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxMailPort.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Mailportname), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxMailUser.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Mailusername), false, DataSourceUpdateMode.OnPropertyChanged);
            //txtBxMailPass.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Mailpassword), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxSqlServerAddress.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Sqlserveradress), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxSqlServerDatabase.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Sqldatabase), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxSqlServerUser.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Sqlusername), false, DataSourceUpdateMode.OnPropertyChanged);
            //txtBxSqlServerPass.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Sqlpassword), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxSqlServerTable.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Sqltable), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxCodePattern.DataBindings.Add("Text", viewmodel.uisettings.codeNames, nameof(codename.Pattern), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBoxRawFileNamingTest.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.RawFileTestName), false, DataSourceUpdateMode.OnPropertyChanged);
            


            //CheckBoxes
            chkBxStorageFile.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.UseStorageFile), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxLocalFolder.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.Chkfastlocaldrive), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxCodeName.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.UseCodeName), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxEmail.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.UseEmail), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxStorageSql.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.UseSql), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxShowAdvanced.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.UseAdvancedSettings), false, DataSourceUpdateMode.OnPropertyChanged);
            //ListBoxes
            lstBxCodeToAnalysis.DataSource = viewmodel.uisettings.codeNames;
            lstBxCodeToAnalysis.DisplayMember = "Name";
            lstBxCodeToAnalysis.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedCodeNameList), false, DataSourceUpdateMode.OnPropertyChanged);

            //lstBxName2email.DataSource = viewmodel.uisettings.emails;

            lstBxWorkflows.DataSource = viewmodel.workflows;
            lstBxWorkflows.DisplayMember = "Name";
            lstBxWorkflows.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedWorkflow), false, DataSourceUpdateMode.OnPropertyChanged);
            txtbxSettingName.DataBindings.Add("Text", viewmodel.workflows, nameof(analysisSettings.Name), false, DataSourceUpdateMode.OnPropertyChanged);

            lstBxRawFiles.DataSource = viewmodel.uisettings.rawFiles;
            
            log.DataSource = viewmodel.logList;
            
            //for some reason, this doesn't work
            //cmbBxAnalysisSettingsAutomatic.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedWorkflowAutomaticDefault), false, DataSourceUpdateMode.OnPropertyChanged);

            lstBxFixedModificationsAll.DataSource = viewmodel.uisettings.modificationList1;
            lstBxVariableModificationsAll.DataSource = viewmodel.uisettings.modificationList2;

            //lstBxFixedModificationsSelected.DataSource = viewmodel.uisettings.analysisSettings.fixedModifications;
            lstBxFixedModificationsSelected.DataSource = viewmodel.fixedMods;
            lstBxVariableModificationsSelected.DataSource = viewmodel.variableMods;

            chkBxEnableMorpheus.DataBindings.Add("Checked", viewmodel.workflows, nameof(analysisSettings.UseMorpheusAnalysis), false, DataSourceUpdateMode.OnPropertyChanged);

            numMinimumAssumedPrecursorChargeState.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.minimumAssumedPrecursorChargeState), false, DataSourceUpdateMode.OnPropertyChanged);
            numMaximumAssumedPrecursorChargeState.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.maximumAssumedPrecursorChargeState), false, DataSourceUpdateMode.OnPropertyChanged);
            chkAbsoluteThreshold.DataBindings.Add("Checked", viewmodel.workflows, nameof(analysisSettings.chkAbsoluteThreshold), false, DataSourceUpdateMode.OnPropertyChanged);
            txtAbsoluteThreshold.DataBindings.Add("Text", viewmodel.workflows, nameof(analysisSettings.txtAbsoluteThreshold), false, DataSourceUpdateMode.OnPropertyChanged);
            chkRelativeThreshold.DataBindings.Add("Checked", viewmodel.workflows, nameof(analysisSettings.chkRelativeThreshold), false, DataSourceUpdateMode.OnPropertyChanged);
            txtRelativeThresholdPercent.DataBindings.Add("Text", viewmodel.workflows, nameof(analysisSettings.txtRelativeThreshold), false, DataSourceUpdateMode.OnPropertyChanged);
            chkMaxNumPeaks.DataBindings.Add("Checked", viewmodel.workflows, nameof(analysisSettings.chkMaxNumPeaks), false, DataSourceUpdateMode.OnPropertyChanged);
            numMaxPeaks.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.maximumNumberOfPeaks), false, DataSourceUpdateMode.OnPropertyChanged);
            
            chkAssignChargeStates.DataBindings.Add("Checked", viewmodel.workflows, "assignChargeStates", false, DataSourceUpdateMode.OnPropertyChanged);
            chkDeisotope.DataBindings.Add("Checked", viewmodel.workflows, "deisotope", false, DataSourceUpdateMode.OnPropertyChanged);
            txtFastaFile.DataBindings.Add("Text", viewmodel.workflows, "proteomeDatabaseFilepath", false, DataSourceUpdateMode.OnPropertyChanged);
            chkOnTheFlyDecoys.DataBindings.Add("Checked", viewmodel.workflows, "onTheFlyDecoys", false, DataSourceUpdateMode.OnPropertyChanged);
            numMaxMissedCleavages.DataBindings.Add("Value", viewmodel.workflows, "maximumMissedCleavages", false, DataSourceUpdateMode.OnPropertyChanged);
            numMaxVariableModIsoforms.DataBindings.Add("Value", viewmodel.workflows, "maximumVariableModificationIsoforms", false, DataSourceUpdateMode.OnPropertyChanged);
            chkPrecursorMonoisotopicPeakCorrection.DataBindings.Add("Checked", viewmodel.workflows, "precursorMonoisotopicPeakCorrection", false, DataSourceUpdateMode.OnPropertyChanged);
            numMinPrecursorMonoPeakOffset.DataBindings.Add("Value", viewmodel.workflows, "minimumPrecursorMonoisotopicPeakOffset", false, DataSourceUpdateMode.OnPropertyChanged);
            numMaxPrecursorMonoPeakOffset.DataBindings.Add("Value", viewmodel.workflows, "maximumPrecursorMonoisotopicPeakOffset", false, DataSourceUpdateMode.OnPropertyChanged);
            numMaximumFalseDiscoveryRatePercent.DataBindings.Add("Value", viewmodel.workflows, "maximumFalseDiscoveryRatePercent", false, DataSourceUpdateMode.OnPropertyChanged);
            chkConsiderModifiedUnique.DataBindings.Add("Checked", viewmodel.workflows, "considerModifiedFormsAsUniquePeptides", false, DataSourceUpdateMode.OnPropertyChanged);
            numMaxThreads.DataBindings.Add("Value", viewmodel.workflows, "maximumThreads", false, DataSourceUpdateMode.OnPropertyChanged);
            chkMinimizeMemoryUsage.DataBindings.Add("Checked", viewmodel.workflows, "minimizeMemoryUsage", false, DataSourceUpdateMode.OnPropertyChanged);
            numPrecursorMassTolerance.DataBindings.Add("Value", viewmodel.workflows, "precursorMassToleranceValue", false, DataSourceUpdateMode.OnPropertyChanged);
            numProductMassTolerance.DataBindings.Add("Value", viewmodel.workflows, "productMassToleranceValue", false, DataSourceUpdateMode.OnPropertyChanged);

            
            cboProtease.DataSource = viewmodel.uisettings.proteaseList;
            cboProtease.DataBindings.Add("SelectedIndex", viewmodel.workflows, nameof(analysisSettings.protease), false, DataSourceUpdateMode.OnPropertyChanged);
            cboInitiatorMethionineBehavior.DataSource = viewmodel.uisettings.initiatorMethionine;
            cboInitiatorMethionineBehavior.DataBindings.Add("SelectedIndex", viewmodel.workflows, nameof(analysisSettings.initiatorMethionineBehavior), false, DataSourceUpdateMode.OnPropertyChanged);
            cboPrecursorMassToleranceUnits.DataSource = viewmodel.uisettings.massToleranceUnitsPrecursor;
            cboPrecursorMassToleranceUnits.DataBindings.Add("SelectedIndex", viewmodel.workflows, nameof(analysisSettings.precursorMassToleranceUnitsIndex), false, DataSourceUpdateMode.OnPropertyChanged);
            cboPrecursorMassType.DataSource = viewmodel.uisettings.massTypePrecursor;
            cboPrecursorMassType.DataBindings.Add("SelectedIndex", viewmodel.workflows, nameof(analysisSettings.precursorMassTypeIndex), false, DataSourceUpdateMode.OnPropertyChanged);
            cboProductMassToleranceUnits.DataSource = viewmodel.uisettings.massToleranceUnitsProduct;
            cboProductMassToleranceUnits.DataBindings.Add("SelectedIndex", viewmodel.workflows, nameof(analysisSettings.productMassToleranceUnitsIndex), false, DataSourceUpdateMode.OnPropertyChanged);
            cboProductMassType.DataSource = viewmodel.uisettings.massTypeProduct;
            cboProductMassType.DataBindings.Add("SelectedIndex", viewmodel.workflows, nameof(analysisSettings.productMassTypeIndex), false, DataSourceUpdateMode.OnPropertyChanged);


            //informationKey bindings
            InformationKey informationKey;
            lstBxInterpretation.DataSource = viewmodel.uisettings.informationKey;
            lstBxInterpretation.DisplayMember = "Name";
            lstBxInterpretation.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedInformationKey), false, DataSourceUpdateMode.OnPropertyChanged);

            txtBxRIName.DataBindings.Add("Text", viewmodel.uisettings.informationKey, nameof(informationKey.Name), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxRIMessage.DataBindings.Add("Text", viewmodel.uisettings.informationKey, nameof(informationKey.Message), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxRICompareValue1.DataBindings.Add("Text", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonText1), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxRICompareValue2.DataBindings.Add("Text", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonText2), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxRICompareValue3.DataBindings.Add("Text", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonText3), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxRICompareValue4.DataBindings.Add("Text", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonText4), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxRICompareValue5.DataBindings.Add("Text", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonText5), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxRIComparer1.DataSource = viewmodel.uisettings.CompareSymbols;
            cmbBxRIComparer2.DataSource = viewmodel.uisettings.CompareSymbols;
            cmbBxRIComparer3.DataSource = viewmodel.uisettings.CompareSymbols;
            cmbBxRIComparer4.DataSource = viewmodel.uisettings.CompareSymbols;
            cmbBxRIComparer5.DataSource = viewmodel.uisettings.CompareSymbols;
            cmbBxRIComparer1.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonIndex1), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxRIComparer2.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonIndex2), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxRIComparer3.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonIndex3), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxRIComparer4.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonIndex4), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxRIComparer5.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ComparisonIndex5), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxResultItem1.DataSource = viewmodel.uisettings.ResultNames;
            cmbBxResultItem2.DataSource = viewmodel.uisettings.ResultNames;
            cmbBxResultItem3.DataSource = viewmodel.uisettings.ResultNames;
            cmbBxResultItem4.DataSource = viewmodel.uisettings.ResultNames;
            cmbBxResultItem5.DataSource = viewmodel.uisettings.ResultNames;
            cmbBxResultItem1.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ResultItemIndex1), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxResultItem2.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ResultItemIndex2), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxResultItem3.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ResultItemIndex3), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxResultItem4.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ResultItemIndex4), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbBxResultItem5.DataBindings.Add("SelectedIndex", viewmodel.uisettings.informationKey, nameof(informationKey.ResultItemIndex5), false, DataSourceUpdateMode.OnPropertyChanged);


            //ComboBoxes
            cmbBxAutomatedDefault.DataSource = viewmodel.automaticAnalysis;
            //cmbBxAutomatedDefault.BindingContext = new BindingContext();
            cmbBxAutomatedDefault.DisplayMember = "Name";
            cmbBxAutomatedDefault.ValueMember = "Name";
            cmbBxAutomatedDefault.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedWorkflowAutomaticDefault), false, DataSourceUpdateMode.OnPropertyChanged);

            cmbBxAnalysisSettingsManual.DataSource = viewmodel.manualAnalysis;
            //cmbBxAnalysisSettingsManual.BindingContext = new BindingContext();
            cmbBxAnalysisSettingsManual.DisplayMember = "Name";
            cmbBxAnalysisSettingsManual.ValueMember = "Name";
            cmbBxAnalysisSettingsManual.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedWorkflowManual), false, DataSourceUpdateMode.OnPropertyChanged);

            
            cmbBxCodeName.DataSource = viewmodel.codeNameAnalysis;
            //cmbBxCodeName.BindingContext = new BindingContext();
            cmbBxCodeName.DisplayMember = "Name";
            cmbBxCodeName.ValueMember = "Name";
            //cmbBxCodeName.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedWorkflowCodeName), false, DataSourceUpdateMode.OnPropertyChanged);

            //external tool bindings
            ExternalResultParseSetting externalResultParseSetting;
            chkBxExternal1Enable.DataBindings.Add("Checked", viewmodel.workflows, nameof(analysisSettings.UseExternal1Analysis), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxExternal1Executable.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Executable), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxExternal1Arguments.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.Arguments), false, DataSourceUpdateMode.OnPropertyChanged);
            numExternalTimeout.DataBindings.Add("Value", viewmodel.uisettings, nameof(viewmodel.uisettings.Timeout), false, DataSourceUpdateMode.OnPropertyChanged);
            lstBxExternal1.DataSource = viewmodel.uisettings.ExternalResults;
            lstBxExternal1.DisplayMember = nameof(externalResultParseSetting.Displayname);
            txtBxExternal1ResultFile.DataBindings.Add("Text", viewmodel.uisettings.ExternalResults, nameof(externalResultParseSetting.ResultFile), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxExternal1ResultName.DataBindings.Add("Text", viewmodel.uisettings.ExternalResults, nameof(externalResultParseSetting.Resultname), false, DataSourceUpdateMode.OnPropertyChanged);
            rdBtnExternal1Row.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.AsRow), false, DataSourceUpdateMode.OnPropertyChanged);
            rdBtnExternal1SplitTab.DataBindings.Add("Checked", viewmodel.uisettings, nameof(viewmodel.uisettings.UseTabExternalTool1), false, DataSourceUpdateMode.OnPropertyChanged);
            

            // base tool bindings
            chkBxEnableBaseAnalysis.DataBindings.Add("Checked", viewmodel.workflows, nameof(analysisSettings.UseBaseAnalysis), false, DataSourceUpdateMode.OnPropertyChanged);
            numBaseSNthreshold.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.StoNthreshold), false, DataSourceUpdateMode.OnPropertyChanged);
            numBaseIonThreshold.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.IonThreshold), false, DataSourceUpdateMode.OnPropertyChanged);
            numBaseMassTolerance.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.BaseMassTolerance), false, DataSourceUpdateMode.OnPropertyChanged);
            numBaseAdductPercentile.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.BaseAdductPercentile), false, DataSourceUpdateMode.OnPropertyChanged);
            numBasePolymerPercentile.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.BasePolymerPercentile), false, DataSourceUpdateMode.OnPropertyChanged);
            numBaseThresholdFluctuationsPercent.DataBindings.Add("Value", viewmodel.workflows, nameof(analysisSettings.baseMaxFluctuationsPercent), false, DataSourceUpdateMode.OnPropertyChanged);
            Adduct adduct;
            lstBxBaseAdducts.DataSource = viewmodel.adducts;
            lstBxBaseAdducts.DisplayMember = nameof(adduct.Name);
            txtBxBaseAdductsMZ.DataBindings.Add("Text", viewmodel.adducts, nameof(adduct.Mass), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBaseAdductsMZ.DataBindings.Add("ReadOnly", viewmodel.adducts, nameof(adduct.ReadOnly), false, DataSourceUpdateMode.OnPropertyChanged);
            lblBaseAdductFixed.DataBindings.Add("Visible", viewmodel.adducts, nameof(adduct.ReadOnly), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxBaseAdductEnabled.DataBindings.Add("Checked", viewmodel.adducts, nameof(adduct.Enabled), false, DataSourceUpdateMode.OnPropertyChanged);
            StatusLogItem statusLogItem;
            lstBxBaseStatusLogItems.DataSource = viewmodel.uisettings.statusLogItems;
            lstBxBaseStatusLogItems.DisplayMember = nameof(statusLogItem.Name);
            lstBxBaseStatusLogItems.DataBindings.Add("SelectedIndex", viewmodel.uisettings, nameof(viewmodel.uisettings.SelectedBaseStatusLog), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxBaseStatusLogCalcMin.DataBindings.Add("Checked", viewmodel.uisettings.statusLogItems, nameof(statusLogItem.CalculateMin), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxBaseStatusLogCalcMax.DataBindings.Add("Checked", viewmodel.uisettings.statusLogItems, nameof(statusLogItem.CalculateMax), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxBaseStatusLogCalcMedian.DataBindings.Add("Checked", viewmodel.uisettings.statusLogItems, nameof(statusLogItem.CalculateMedian), false, DataSourceUpdateMode.OnPropertyChanged);
            chkBxBaseStatusLogCalcIQR.DataBindings.Add("Checked", viewmodel.uisettings.statusLogItems, nameof(statusLogItem.CalculateIQR), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBaseStatusLogNewItems.DataBindings.Add("Text", viewmodel.uisettings, nameof(viewmodel.uisettings.StatusLogNewItems), false, DataSourceUpdateMode.OnPropertyChanged);
            
            
            Polymer polymer;
            lstBxBasePolymers.DataSource = viewmodel.polymers;
            lstBxBasePolymers.DisplayMember = nameof(polymer.Name);
            txtBxBasePolymerName.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Name), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerMz0.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Mz0), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerZ0.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Z0), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerMz1.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Mz1), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerZ1.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Z1), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerMz2.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Mz2), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerZ2.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Z2), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerMz3.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Mz3), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerZ3.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Z3), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerMz4.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Mz4), false, DataSourceUpdateMode.OnPropertyChanged);
            txtBxBasePolymerZ4.DataBindings.Add("Text", viewmodel.polymers, nameof(polymer.Z4), false, DataSourceUpdateMode.OnPropertyChanged);

            //set passwords - consider to have another way of showing errors.
            try
            {
                if (!viewmodel.uisettings.Mailpassword.Equals(String.Empty))
                {
                    txtBxMailPass.Text = Crypto.DecryptString(viewmodel.uisettings.Mailpassword, "secretMailPass");
                }
                else
                {
                    txtBxMailPass.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Problems with mail server password, resetting");
                txtBxMailPass.Text = "";
                viewmodel.uisettings.Mailpassword = "";
            }
            try
            {
                if (!viewmodel.uisettings.Sqlpassword.Equals(String.Empty))
                {
                    txtBxSqlServerPass.Text = Crypto.DecryptString(viewmodel.uisettings.Sqlpassword, "secretSqlPass");
                }
                else
                {
                    txtBxSqlServerPass.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Problems with SQL server password, resetting");
                txtBxSqlServerPass.Text = "";
                viewmodel.uisettings.Sqlpassword = "";
            }
            toolStripStatusLabel1.Text = viewmodel.logList.LastOrDefault();
        }
        

        private void LoadMorpheusChoices()
        {
            viewmodel.Reset();
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxStorageSql.Checked)
            {
                pnlStorageSql.Visible = true;
            }
            else
            {
                pnlStorageSql.Visible = false;
            }
        }
        private void addRawFilesBtn_Click(object sender, EventArgs e)
        {
            viewmodel.AddRawFiles();
        }

        private void Analyze_Click(object sender, EventArgs e)
        {
            viewmodel.AnalyzeAllRawfiles();
        }
        private void btnNewSettings_Click(object sender, EventArgs e)
        {
            viewmodel.NewWorkflow();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            viewmodel.Save();
        }


        private void btnDeleteSettings_Click(object sender, EventArgs e)
        {
            viewmodel.DeleteWorkflow();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                viewmodel.Save();
            }
            Application.Exit();
        }
        private void btnRemoveRawFiles_Click(object sender, EventArgs e)
        {
            viewmodel.RemoveRawFilesFromList(lstBxRawFiles.SelectedItems.Cast<RawFileName>().ToList());
        }
        private void WatchToggle(Button button,int watchIndex)
        {
            bool watchSuccess = viewmodel.StartWatching(watchIndex);
            if (watchSuccess)
            {
                button.Text = "Stop watch";
            }
            else
            {
                button.Text = "Start watch";
            }
        }

        private void btnBrowseFastLocal_Click(object sender, EventArgs e)
        {
            viewmodel.uisettings.Fastlocaldrive = viewmodel.WatchBrowse();
        }
        private void btnWatchBrowse0_Click(object sender, EventArgs e)
        {
            viewmodel.uisettings.Monitorfolder1 = viewmodel.WatchBrowse();
        }
        private void btnWatchBrowse1_Click(object sender, EventArgs e)
        {
            viewmodel.uisettings.Monitorfolder2 = viewmodel.WatchBrowse();
        }
        private void btnWatchBrowse2_Click(object sender, EventArgs e)
        {
            viewmodel.uisettings.Monitorfolder3 = viewmodel.WatchBrowse();
        }
        private void btnWatchBrowse3_Click(object sender, EventArgs e)
        {
            viewmodel.uisettings.Monitorfolder4 = viewmodel.WatchBrowse();
        }
        private void btnWatchBrowse4_Click(object sender, EventArgs e)
        {
            viewmodel.uisettings.Monitorfolder5 = viewmodel.WatchBrowse();
        }
        private void btnWatch0_Click(object sender, EventArgs e)
        {
            WatchToggle(btnWatch0, 0);
        }
        private void btnWatch1_Click(object sender, EventArgs e)
        {
            WatchToggle(btnWatch1, 1);
        }
        private void btnWatch2_Click(object sender, EventArgs e)
        {
            WatchToggle(btnWatch2, 2);
        }

        private void btnWatch3_Click(object sender, EventArgs e)
        {
            WatchToggle(btnWatch3, 3);
        }

        private void btnWatch4_Click(object sender, EventArgs e)
        {
            WatchToggle(btnWatch4, 4);
        }

        private void btnAddAnalysisCode_Click(object sender, EventArgs e)
        {
            viewmodel.CodeNameAdd(cmbBxCodeName.SelectedIndex);//tried with binding but problems with halted initialization of workflows on other tabpage
        }

        private void btnDeleteAnalysisCode_Click(object sender, EventArgs e)
        {
            viewmodel.CodeNameDelete();
        }

        private void chkBxCodeName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxCodeName.Checked)
            {
                pnlCodeNam.Visible = true;
                cmbBxAutomatedDefault.Visible = false;
                lblAutomatedSelectWorkflow.Visible = false;
                //chkBxCodeNameChangeVisibility(true);
            }
            else
            {
                pnlCodeNam.Visible = false;
                cmbBxAutomatedDefault.Visible = true;
                lblAutomatedSelectWorkflow.Visible = true;
                //chkBxCodeNameChangeVisibility(false);
            }
            
        }
        private void chkBxCodeNameChangeVisibility(bool status)
        {
            lblCodeName.Visible = status;
            txtBxCodePattern.Visible = status;
            btnAddAnalysisCode.Visible = status;
            btnDeleteAnalysisCode.Visible = status;
            lblCodeNameToAnalysis.Visible = status;
            lstBxCodeToAnalysis.Visible = status;
        }

        private void chkBxLocalFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxLocalFolder.Checked)
            {
                chkBxLocalFolderChangeVisibility(true);
            }
            else
            {
                chkBxLocalFolderChangeVisibility(false);
            }
        }
        private void chkBxLocalFolderChangeVisibility(bool status)
        {
            txtBxFastLocal.Visible = status;
            btnBrowseFastLocal.Visible = status;
        }

        private void btnSqlServerTestConnection_Click(object sender, EventArgs e)
        {
            viewmodel.CheckSqlConnection();
        }

        private void btnCreateSqlTable_Click(object sender, EventArgs e)
        {
            viewmodel.CreateSqlTable();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = viewmodel.GetWorkflows();
        }

        private void btnFixedModificationAdd_Click(object sender, EventArgs e)
        {
            viewmodel.AddFixedMod(lstBxFixedModificationsAll.SelectedIndex);
        }

        private void btnFixedModificationRemove_Click(object sender, EventArgs e)
        {
            viewmodel.RemoveFixedMod(lstBxFixedModificationsSelected.SelectedIndex);
        }

        private void btnVariableModificationAdd_Click(object sender, EventArgs e)
        {
            viewmodel.AddVariableMod(lstBxVariableModificationsAll.SelectedIndex);
        }

        private void btnVariableModificationRemove_Click(object sender, EventArgs e)
        {
            viewmodel.RemoveVariableMod(lstBxVariableModificationsSelected.SelectedIndex);
        }



        private void btnCodeNameUp_Click(object sender, EventArgs e)
        {
            viewmodel.CodeNameUp();
        }

        private void btnCodeNameDown_Click(object sender, EventArgs e)
        {
            viewmodel.CodeNameDown();
        }

        private void btnCodeNameCheck_Click(object sender, EventArgs e)
        {
            viewmodel.CodeNameCheck(txtBxCodeNameCheck.Text);
        }

        private void chkBxStorageFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxStorageFile.Checked)
            {
                pnlStorageFile.Visible = true;
            }
            else
            {
                pnlStorageFile.Visible = false;
            }
        }
        
        private void BrowseStorageFile_Click(object sender, EventArgs e)
        {
             viewmodel.BrowseStorageFile();
        }


        //problems here?
        private void cmbBxCodeName_SelectedIndexChanged(object sender, EventArgs e)
        {
                viewmodel.CodeNameUpdate(cmbBxCodeName.SelectedIndex);
        }

        private void chkBxEnableMorpheus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxEnableMorpheus.Checked)
            {
                pnlMorpheus.Visible = true;
            }
            else
            {
                pnlMorpheus.Visible = false;
            }
        }

        private void chkBxEnableBaseAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxEnableBaseAnalysis.Checked)
            {
                pnlBaseParameters.Visible = true;
            }
            else
            {
                pnlBaseParameters.Visible = false;
            }
        }
        private void btnAddInterpretationKey_Click(object sender, EventArgs e)
        {
            viewmodel.AddInformationKey();
        }

        private void btnRemoveInterpretationKey_Click(object sender, EventArgs e)
        {
            viewmodel.RemoveInformationKey();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = viewmodel.GetUIsettings();
        }

        private void btnCreateNewColumnsSqlTable_Click(object sender, EventArgs e)
        {
            viewmodel.CreateNewSqlColumns();
        }

        private void txtBxMailPass_TextChanged(object sender, EventArgs e)
        {
            viewmodel.uisettings.Mailpassword = Crypto.EncryptString(txtBxMailPass.Text,"secretMailPass");
        }

        private void txtBxSqlServerPass_TextChanged(object sender, EventArgs e)
        {
            viewmodel.uisettings.Sqlpassword = Crypto.EncryptString(txtBxSqlServerPass.Text, "secretSqlPass");
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && dgvUser.CurrentCell.Value != null)
            {
                dgvUser.CurrentCell = dgvUser[e.ColumnIndex, e.RowIndex];
                dgvUser.BeginEdit(true);
                ((TextBox)dgvUser.EditingControl).SelectionStart = dgvUser.CurrentCell.Value.ToString().Length;
            }
        }
        private void dgvSample_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && dgvSample.CurrentCell.Value != null)
            {
                dgvSample.CurrentCell = dgvSample[e.ColumnIndex, e.RowIndex];
                dgvSample.BeginEdit(true);
                ((TextBox)dgvSample.EditingControl).SelectionStart = dgvSample.CurrentCell.Value.ToString().Length;
            }
        }
        private void dgvLC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && dgvLC.CurrentCell.Value != null)
            {
                dgvLC.CurrentCell = dgvLC[e.ColumnIndex, e.RowIndex];
                dgvLC.BeginEdit(true);
                ((TextBox)dgvLC.EditingControl).SelectionStart = dgvLC.CurrentCell.Value.ToString().Length;
            }
        }
        private void dgvMS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && dgvMS.CurrentCell.Value != null)
            {
                dgvMS.CurrentCell = dgvMS[e.ColumnIndex, e.RowIndex];
                dgvMS.BeginEdit(true);
                ((TextBox)dgvMS.EditingControl).SelectionStart = dgvMS.CurrentCell.Value.ToString().Length;
            }
        }
        private void dgvUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                int rowIndex = int.MaxValue;
                foreach (DataGridViewRow currow in dgvUser.SelectedRows)
                {
                    if (rowIndex > currow.Index)
                    {
                        rowIndex = currow.Index;
                    }
                }
                viewmodel.PasteDataToGridview(1, rowIndex);                
            }
        }
        private void dgvSample_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                int rowIndex = int.MaxValue;
                foreach (DataGridViewRow currow in dgvSample.SelectedRows)
                {
                    if (rowIndex > currow.Index)
                    {
                        rowIndex = currow.Index;
                    }
                }
                viewmodel.PasteDataToGridview(2, rowIndex);
            }
        }
        private void dgvLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                int rowIndex = int.MaxValue;
                foreach (DataGridViewRow currow in dgvLC.SelectedRows)
                {
                    if (rowIndex > currow.Index)
                    {
                        rowIndex = currow.Index;
                    }
                }
                viewmodel.PasteDataToGridview(3, rowIndex);
            }
        }
        private void dgvMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                int rowIndex = int.MaxValue;
                foreach (DataGridViewRow currow in dgvMS.SelectedRows)
                {
                    if (rowIndex > currow.Index)
                    {
                        rowIndex = currow.Index;
                    }
                }
                viewmodel.PasteDataToGridview(4, rowIndex);
            }
        }

        private void btnTestRawFileCategories_Click(object sender, EventArgs e)
        {
            viewmodel.TryParseRawFile();
        }

        private void chkBxEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxEmail.Checked)
            {
                mailPanel.Visible = true;
            }
            else
            {
                mailPanel.Visible = false;
            }
        }

        private void HandleLogUpdate(object sender, ListChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = viewmodel.logList.LastOrDefault();
        }
        

        private void btnExternal1Remove_Click(object sender, EventArgs e)
        {
            viewmodel.External1ResultDelete(lstBxExternal1.SelectedIndex);
        }

        private void chkAbsoluteThreshold_CheckedChanged(object sender, EventArgs e)
        {

            if (chkAbsoluteThreshold.Checked)
            {
                txtAbsoluteThreshold.Enabled = true;
            }
            else
            {
                txtAbsoluteThreshold.Enabled = false;
            }

        }

        private void chkRelativeThreshold_CheckedChanged(object sender, EventArgs e)
        {

            if (chkRelativeThreshold.Checked)
            {
                txtRelativeThresholdPercent.Enabled = true;
                label15.Enabled = true;
            }
            else
            {
                txtRelativeThresholdPercent.Enabled = false;
                label15.Enabled = false;
            }

        }

        private void chkMaxNumPeaks_CheckedChanged(object sender, EventArgs e)
        {

            if (chkMaxNumPeaks.Checked)
            {
                numMaxPeaks.Enabled = true;
            }
            else
            {
                numMaxPeaks.Enabled = false;
            }

        }

        private void chkMonoisotopicPeakCorrection_CheckedChanged(object sender, EventArgs e)
        {

            if (chkPrecursorMonoisotopicPeakCorrection.Checked)
            {
                numMinPrecursorMonoPeakOffset.Enabled = true;
                label25.Enabled = true;
                numMaxPrecursorMonoPeakOffset.Enabled = true;
            }
            else
            {
                numMinPrecursorMonoPeakOffset.Enabled = false;
                label25.Enabled = false;
                numMaxPrecursorMonoPeakOffset.Enabled = false;
            }

        }


        private void btnBrowseFasta_Click(object sender, EventArgs e)
        {
            viewmodel.BrowseFasta();
        }

        private void btnBaseAdductReset_Click(object sender, EventArgs e)
        {
            viewmodel.BaseAdductReset();
        }

        private void btnBasePolymerReset_Click(object sender, EventArgs e)
        {
            viewmodel.BasePolymerReset();
        }
        

        private void btnExternal1New_Click(object sender, EventArgs e)
        {
            viewmodel.External1ResultNew();
        }

        private void chkBxShowAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxShowAdvanced.Checked)
            {
                grpBxAdvancedExternalTool1.Visible = true;
                grpBxAdvancedStatusLog.Visible = true;
                grpBxFullMStargets.Visible = true;
                grpBxMorpheusPrecursor.Visible = true;
                grpBxMorpheusMS2Filtering.Visible = true;
                grpBxMorpheusMS2Analysis.Visible = true;
            }
            else
            {
                grpBxAdvancedExternalTool1.Visible = false;
                grpBxAdvancedStatusLog.Visible = false;
                grpBxFullMStargets.Visible = false;
                grpBxMorpheusPrecursor.Visible = false;
                grpBxMorpheusMS2Filtering.Visible = false;
                grpBxMorpheusMS2Analysis.Visible = false;
            }
        }

        private void btnExternal1Browse_Click(object sender, EventArgs e)
        {
            viewmodel.BrowseExternalExecutable();
        }

        private void btnBaseStatusLogRemove_Click(object sender, EventArgs e)
        {
            viewmodel.BaseStatusRemove();
        }

        private void btnBaseStatusLogAdd_Click(object sender, EventArgs e)
        {
            viewmodel.BaseStatusLogAdd();
        }

        private void rdBtnExternal1Row_CheckedChanged(object sender, EventArgs e)
        {
            rdBtnExternal1Column.Checked = !rdBtnExternal1Row.Checked;
        }

        private void rdBtnExternal1SplitTab_CheckedChanged(object sender, EventArgs e)
        {
            rdBtnExternal1SplitSemicolon.Checked = !rdBtnExternal1SplitTab.Checked;
        }

        private void btnExternal1Remove_Click_1(object sender, EventArgs e)
        {
            viewmodel.External1ResultDelete(lstBxExternal1.SelectedIndex);
        }
    }


}
