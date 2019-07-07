using MSFileReaderLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Morpheus;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AutoProt
{
    public class AnalysisMorpheus : AnalysisTemplate
    {

        public AnalysisMorpheus()
        {
            //this.usrControl = new UsrCtrlMorpheus();
        }
        protected override ResultItems GetResultItems(UIsettings settingName)
        {
            ResultItems results = new ResultItems();
            results.Add("Protein groups", typeof(int));
            results.Add("Unique peptides", typeof(int));
            results.Add("Peptide spectrum matches", typeof(int));
            results.Add("ID rate percent", typeof(double));
            results.Add("Repeated sequencing percent", typeof(double));
            results.Add("Average Morpheus score", typeof(double));
            results.Add("Average mass error in ppm", typeof(double));
            results.Add("Mode mass error in ppm", typeof(double));
            results.Add("Average peptide length", typeof(double));
            results.Add("Average missed cleavages percent", typeof(double));
            results.Add("BSA sequence coverage", typeof(double));
            results.Add("Mycoplasma abundance", typeof(double));
            results.Add("Trypsin abundance", typeof(double));
            results.Add("LysC abundance", typeof(double));
            results.Add("Modifications", typeof(string));
            results.Add("Analysis fasta file", typeof(string));
            results.Add("Analysis enzyme", typeof(string));
            results.Add("Analysis precursor mass accuracy", typeof(double));
            results.Add("Analysis fragment mass accuracy", typeof(double));
            results.Add("Analysis settings encoded", typeof(string));
            return results;
        }
        
        public override ResultItems Analyze(RawFileName rawfile, SettingsForAnalysis settings, UIsettings fixedSettings)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            ResultItems results = GetResultItems(fixedSettings);
            if (settings.UseMorpheusAnalysis)
            {
                string data_filepath = rawfile.FullName;
                //usrControl.SaveSettings(settingName);
                //usrControl.SetCurrentSettings(settingName);
                //= usrControl.GetCurrentSettings(settingName);
                //MorpheusSettings settings = new MorpheusSettings();
                //settings = JsonConvert.DeserializeObject<MorpheusSettings>(jsonSettings);


                FileStream proteome_database = null;
                PeptideSpectrumMatch.SetPrecursorMassType(settings.precursorMassType);
                AminoAcidPolymer.SetProductMassType(settings.productMassType);
                proteome_database = new FileStream(settings.proteomeDatabaseFilepath, FileMode.Open, FileAccess.Read,
                    FileShare.Read);

                //int target_proteins;
                //int decoy_proteins;
                //int on_the_fly_decoy_proteins;
                //int total_proteins = ProteomeDatabaseReader.CountProteins(proteome_database, settings.onTheFlyDecoys,
                //    out target_proteins, out decoy_proteins, out on_the_fly_decoy_proteins);
                //double decoys_over_targets_protein_ratio =
                //    (double) (decoy_proteins + on_the_fly_decoy_proteins) / target_proteins;

                //progress.Report("[" + rawfile.FullName + "] Stop 1, DB read " + stopwatch.Elapsed.TotalSeconds.ToString("0.000") + " seconds");



                int num_target_peptides = 0;
                int num_decoy_peptides = 0;
                double decoys_over_targets_peptide_ratio = double.NaN;
                
                /*
                string fixed_modifications = null;
                foreach (Modification fixed_modification in settings.fixedModifications)
                {
                    fixed_modifications += fixed_modification.ToString() + ", ";
                }
                if (fixed_modifications != null)
                {
                    fixed_modifications = fixed_modifications.Substring(0, fixed_modifications.Length - 2);
                }
                else
                {
                    fixed_modifications = "none";
                }
                string variable_modifications = null;
                foreach (Modification variable_modification in currentVariableModifications)
                {
                    variable_modifications += variable_modification.ToString() + ", ";
                }
                if (variable_modifications != null)
                {
                    variable_modifications = variable_modifications.Substring(0, variable_modifications.Length - 2);
                }
                else
                {
                    variable_modifications = "none";
                }
                */
                /*
                int total_spectra = 0;
                List<PeptideSpectrumMatch> aggregate_psms = null;

                SortedList<string, HashSet<string>> parents = null;
                Dictionary<string, int> num_spectra = null;
                Dictionary<string, List<PeptideSpectrumMatch>> grouped_aggregate_psms = null;
                */
                Dictionary<string, Modification> known_variable_modifications = new Dictionary<string, Modification>();
                List<Modification> unknown_variable_modifications = new List<Modification>();
                foreach (Modification variable_modification in settings.variableModifications)
                {
                    if (variable_modification.Known)
                    {
                        known_variable_modifications.Add(variable_modification.Description, variable_modification);
                    }
                    else
                    {
                        unknown_variable_modifications.Add(variable_modification);
                    }
                }
                if (Path.GetExtension(settings.proteomeDatabaseFilepath).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
                {
                    List<Modification> currentVariableModifications = ProteomeDatabaseReader.ReadUniProtXmlModifications(settings.proteomeDatabaseFilepath).Values.ToList();
                    foreach (Modification variable_modification in currentVariableModifications)
                    {
                        if (variable_modification.Known)
                        {
                            known_variable_modifications.Add(variable_modification.Description, variable_modification);
                        }
                        else
                        {
                            unknown_variable_modifications.Add(variable_modification);
                        }
                    }
                }
                TandemMassSpectra spectra = new TandemMassSpectra();

                spectra.Load(data_filepath, settings.minimumAssumedPrecursorChargeState,
                    settings.maximumAssumedPrecursorChargeState,
                    settings.absoluteThreshold, settings.relativeThresholdPercent, settings.maximumNumberOfPeaks,
                    settings.assignChargeStates, settings.deisotope, settings.productMassTolerance,
                    settings.maximumThreads);

                //progress.Report("[" + rawfile.FullName + "] Stop 2, spectra read " + stopwatch.Elapsed.TotalSeconds.ToString("0.000") + " seconds");

                PeptideSpectrumMatch[] psms = null;
                if (spectra.Count > 0)
                {
                    int max_spectrum_number = 0;
                    foreach (TandemMassSpectrum spectrum in spectra)
                    {
                        if (spectrum.SpectrumNumber > max_spectrum_number)
                        {
                            max_spectrum_number = spectrum.SpectrumNumber;
                        }
                    }

                    psms = new PeptideSpectrumMatch[max_spectrum_number];

                    spectra.Sort(TandemMassSpectrum.AscendingPrecursorMassComparison);
                }

                Dictionary<string, bool> peptides_observed = null;
                if (!settings.minimizeMemoryUsage)
                {
                    peptides_observed = new Dictionary<string, bool>();
                }

                num_target_peptides = 0;
                num_decoy_peptides = 0;

#if NON_MULTITHREADED
                    int proteins = 0;
                    int old_progress = 0;
                    foreach(Protein protein in ProteomeDatabaseReader.ReadProteins(proteome_database, onTheFlyDecoys, known_variable_modifications))
                    {
                        foreach(Peptide peptide in protein.Digest(protease, maximumMissedCleavages, initiatorMethionineBehavior, null, null))
                        {
                            if(peptide.Target)
                            {
                                num_target_peptides++;
                            }
                            else
                            {
                                num_decoy_peptides++;
                            }

                            if(!minimizeMemoryUsage)
                            {
                                // This block of code is to ensure that (1) we don't re-search the same base leucine peptide sequence more than we need to, 
                                // and (2) that we are maximally conservative by calling PSMs decoy whenever possible.
                                // If we haven't already seen this base leucine peptide sequence, add it to the dictionary with a value indicating whether it was decoy or not.
                                // Then perform the search as usual.
                                // If we have already seen it and it was decoy or this time it is target, we don't need to search it again, skip the peptide.
                                // Otherwise, update the dictionary to reflect that we have now seen it as a decoy and perform the search.
                                bool observed_as_decoy = false;
                                if(!peptides_observed.TryGetValue(peptide.BaseLeucineSequence, out observed_as_decoy))
                                {
                                    peptides_observed.Add(peptide.BaseLeucineSequence, peptide.Decoy);
                                }
                                else
                                {
                                    if(observed_as_decoy || peptide.Target)
                                    {
                                        // if the peptide has no known mods we have already searched all its isoforms, skip it
                                        if(peptide.KnownModifications == null || peptide.KnownModifications.Count == 0)
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        peptides_observed[peptide.BaseLeucineSequence] = true;
                                    }
                                }
                            }

                            peptide.SetFixedModifications(fixedModifications);
                            foreach(Peptide modified_peptide in peptide.GetVariablyModifiedPeptides(unknown_variable_modifications, maximumVariableModificationIsoforms))
                            {
                                foreach(TandemMassSpectrum spectrum in precursorMonoisotopicPeakCorrection ?
                                    spectra.GetTandemMassSpectraInMassRange(precursorMassType == MassType.Average ? modified_peptide.AverageMass : modified_peptide.MonoisotopicMass, precursorMassTolerance, minimumPrecursorMonoisotopicPeakOffset, maximumPrecursorMonoisotopicPeakOffset) :
                                    spectra.GetTandemMassSpectraInMassRange(precursorMassType == MassType.Average ? modified_peptide.AverageMass : modified_peptide.MonoisotopicMass, precursorMassTolerance))
                                {
                                    PeptideSpectrumMatch psm =
new PeptideSpectrumMatch(spectrum, modified_peptide, productMassTolerance);
                                    PeptideSpectrumMatch current_best_psm = psms[spectrum.SpectrumNumber - 1];
                                    if(current_best_psm == null || PeptideSpectrumMatch.DescendingMorpheusScoreComparison(psm, current_best_psm) < 0)
                                    {
                                        psms[spectrum.SpectrumNumber - 1] = psm;
                                    }
                                }
                            }
                        }

                        proteins++;
                        int new_progress = (int)((double)proteins / total_proteins * 100);
                        if(new_progress > old_progress)
                        {
                            OnUpdateProgress(new ProgressEventArgs(new_progress));
                            old_progress = new_progress;
                        }
                    }
#else

                List<Protein> customProteins = new List<Protein>(4)
                {
                    new Protein(
                    "MKWVTFISLLLLFSSAYSRGVFRRDTHKSEIAHRFKDLGEEHFKGLVLIAFSQYLQQCPFDEHVKLVNELTEFAKTCVADESHAGCEKSLHTLFGDELCKVASLRETYGDMADCCEKQEPERNECFLSHKDDSPDLPKLKPDPNTLCDEFKADEKKFWGKYLYEIARRHPYFYAPELLYYANKYNGVFQECCQAEDKGACLLPKIETMREKVLASSARQRLRCASIQKFGERALKAWSVARLSQKFPKAEFVEVTKLVTDLTKVHKECCHGDLLECADDRADLAKYICDNQDTISSKLKECCDKPLLEKSHCIAEVEKDAIPENLPPLTADFAEDKDVCKNYQEAKDAFLGSFLYEYSRRHPEYAVSVLLRLAKEYEATLEECCAKDDPHACYSTVFDKLKHLVDEPQNLIKQNCDQFEKLGEYGFQNALIVRYTRKVPQVSTPTLVEVSRSLGKVGTRCCTKPESERMPCTEDYLSLILNRLCVLHEKTPVSEKVTKCCTESLVNRRPCFSALTPDETYVPKAFDEKLFTFHADICTLPDTEKQIKKQTALVELLKHKPKATEEQLKTVMENFVAFVDKCCAADDKEACFAVEGPKLVVSTQTALA",
                    "X1BSA"),
                    new Protein(
                    "FPTDDDDKIVGGYTCAANSIPYQVSLNSGSHFCGGSLINSQWVVSAAHCYKSRIQVRLGEHNIDVLEGNEQFINAAKIITHPNFNGNTLDNDIMLIKLSSPATLNSRVATVSLPRSCAAAGTECLISGWGNTKSSGSSYPSLLQCLKAPVLSDSSCKSSYPGQITGNMICVGFLEGGKDSCQGDSGGPVVCNGQLQGIVSWGYGCAQKNKPGVYTKVCNYVNWIQQTIAAN",
                    "X1Trypsin"),
                    new Protein(
                    "MKRICGSLLLLGLSISAALAAPASRPAAFDYANLSSVDKVALRTMPAVDVAKAKAEDLQRDKRGDIPRFALAIDVDMTPQNSGAWEYTADGQFAVWRQRVRSEKALSLNFGFTDYYMPAGGRLLVYPATQAPAGDRGLISQYDASNNNSARQLWTAVVPGAEAVIEAVIPRDKVGEFKLRLTKVNHDYVGFGPLARRLAAASGEKGVSGSCNIDVVCPEGDGRRDIIRAVGAYSKSGTLACTGSLVNNTANDRKMYFLTAHHCGMGTASTAASIVVYWNYQNSTCRAPNTPASGANGDGSMSQTQSGSTVKATYATSDFTLLELNNAANPAFNLFWAGWDRRDQNYPGAIAIHHPNVAEKRISNSTSPTSFVAWGGGAGTTHLNVQWQPSGGVTEPGSSGSPIYSPEKRVLGQLHGGPSSCSATGTNRSDQYGRVFTSWTGGGAAASRLSDWLDPASTGAQFIDGLDSGGGTPNTPPVANFTSTTSGLTATFTDSSTDSDGSIASRSWNFGDGSTSTATNPSKTYAAAGTYTVTLTVTDNGGATNTKTGSVTVSGGPGAQTYTNDTDVAIPDNATVESPITVSGRTGNGSATTPIQVTIYHTYKSDLKVDLVAPDGTVYNLHNRTGGSAHNIIQTFTKDLSSEAAQRAPGSCG",
                    "X1LysC"),
                    new Protein(
                    "MLKKLKNFILFSSIFSPIAFAISCSNTGVVKQEDVSVSQGQWDKSITFGVSEAWLNKKKGGEKVNKEVINTFLENFKKEFNKLKNANDKTKNFDDVDFKVTPIQDFTVLLNNLSTDNPELDFGINASGKLVEFLKNNPGIITPALETTTNSFVFDKEKDKFYVDGTDSDPLVKIAKEINKIFVETPYASWTDENHKWNGNVYQSVYDPTVQANFYRGMIWIKGNDETLAKIKKAWNDKDWNTFRNFGILHGKDNSFSKFKLEETILKNHFQNKFTTLNEDRSAHPNAYKQKSADTLGTLDDFHIAFSEEGSFAWTHNKSATKPFETKANEKMEALIVTNPIPYDVGVFRKSVNQLEQNLIVQTFINLAKNKQDTYGPLLGYNGYKKIDNFQKEIVEVYEKAIK",
                    "X1Mycoplasma")
                };


                object progress_lock = new object();
                //int proteins = 0;
                //int old_progress = 0;
                ParallelOptions parallel_options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = settings.maximumThreads
                };
                //Parallel.ForEach(ProteomeDatabaseReader.ReadProteins(proteome_database, settings.onTheFlyDecoys, known_variable_modifications), parallel_options, protein =>
                //Parallel.ForEach(customProteins, parallel_options, protein =>

                Parallel.ForEach(
                    ReadProteinsAndList(proteome_database, settings.onTheFlyDecoys, known_variable_modifications,
                        customProteins), parallel_options, protein =>
                        //foreach(Protein protein in ReadProteinsAndList(proteome_database, settings.onTheFlyDecoys, known_variable_modifications, customProteins))
                    {
                        SearchProtein(settings, ref num_target_peptides, ref num_decoy_peptides,
                            unknown_variable_modifications, spectra, psms, peptides_observed, protein);

                        /*lock(progress_lock)
                        {
                            proteins++;
                            int new_progress = (int)((double)proteins / total_proteins * 100);
                            if(new_progress > old_progress)
                            {
                                OnUpdateProgress(new ProgressEventArgs(new_progress));
                                old_progress = new_progress;
                            }
                        }*/
                    }
                ); //uncomment this for parallel.foreach
#endif
                // Add a few proteins that we like.
                //progress.Report("[" + rawfile.FullName + "] Stop 3, Search done " + stopwatch.Elapsed.TotalSeconds.ToString("0.000") + " seconds");


                //OnUpdateStatus(new StatusEventArgs("Performing post-search analyses..."));
                //OnReportTaskWithoutProgress(EventArgs.Empty);
                //OnUpdateProgress(new ProgressEventArgs(0));

                //log.WriteLine((num_target_peptides + num_decoy_peptides).ToString("N0") + " total (" + num_target_peptides.ToString("N0") + " target + " + num_decoy_peptides.ToString("N0") + " decoy) non-unique peptides");
                decoys_over_targets_peptide_ratio = (double) num_decoy_peptides / num_target_peptides;

                //log.WriteLine(spectra.Count.ToString("N0") + " MS/MS spectra");

                List<PeptideSpectrumMatch> psms_no_nulls;
                if (psms != null)
                {
                    psms_no_nulls = new List<PeptideSpectrumMatch>(psms.Length);
                    foreach (PeptideSpectrumMatch psm in psms)
                    {
                        if (psm != null)
                        {
                            psms_no_nulls.Add(psm);
                        }
                    }

                    /*  if(dataFilepaths.Count > 1)
                      {
                          aggregate_psms.AddRange(psms_no_nulls);
                          if(parents.Count > 0)
                          {
                              grouped_aggregate_psms.Add(data_filepath, psms_no_nulls);
                          }
                      }*/
                }
                else
                {
                    psms_no_nulls = new List<PeptideSpectrumMatch>(0);
                }

                List<PeptideSpectrumMatch> sorted_psms = new List<PeptideSpectrumMatch>(psms_no_nulls);
                sorted_psms.Sort(PeptideSpectrumMatch.DescendingMorpheusScoreComparison);

                IEnumerable<IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch>> psms_with_fdr =
                    FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(sorted_psms, decoys_over_targets_peptide_ratio);
                //Exporters.WriteToTabDelimitedTextFile(psms_with_fdr, Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(data_filepath) + ".PSMs.tsv"));
                double psm_score_threshold = double.NegativeInfinity;
                int target_psms = sorted_psms.Count;
                int decoy_psms = 0;
                double psm_fdr = double.NaN;
                if (decoys_over_targets_peptide_ratio == 0.0)
                {
                    //    log.WriteLine(sorted_psms.Count.ToString("N0") + " PSMs (unknown FDR)");
                }
                else
                {
                    FalseDiscoveryRate.DetermineMaximumIdentifications(psms_with_fdr, false,
                        settings.maximumFalseDiscoveryRate, out psm_score_threshold, out target_psms, out decoy_psms,
                        out psm_fdr);
                    //    log.WriteLine(target_psms.ToString("N0") + " target (" + decoy_psms.ToString("N0") + " decoy) PSMs at " + psm_fdr.ToString("0.000%") + " PSM FDR (" + psm_score_threshold.ToString("0.000") + " Morpheus score threshold)");
                }
                /*
                Exporters.WritePsmsToPepXmlFile(Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(data_filepath) + ".pep.xml"),
                    data_filepath,
                    minimumAssumedPrecursorChargeState, maximumAssumedPrecursorChargeState,
                    absoluteThreshold, relativeThresholdPercent, maximumNumberOfPeaks,
                    assignChargeStates, deisotope,
                    proteomeDatabaseFilepath, onTheFlyDecoys, onTheFlyDecoys ? proteins / 2 : proteins,
                    protease, maximumMissedCleavages, initiatorMethionineBehavior,
                    fixedModifications, fixed_modifications, variableModifications, variable_modifications, maximumVariableModificationIsoforms,
                    precursorMassTolerance, precursorMassType,
                    precursorMonoisotopicPeakCorrection, minimumPrecursorMonoisotopicPeakOffset, maximumPrecursorMonoisotopicPeakOffset,
                    productMassTolerance, productMassType,
                    maximumFalseDiscoveryRate, considerModifiedFormsAsUniquePeptides,
                    maximumThreads, minimizeMemoryUsage,
                    outputFolder,
                    psms_with_fdr);
                */
                Dictionary<string, PeptideSpectrumMatch> peptides = new Dictionary<string, PeptideSpectrumMatch>();

                foreach (PeptideSpectrumMatch psm in sorted_psms)
                {
                    if (!peptides.ContainsKey(settings.considerModifiedFormsAsUniquePeptides
                        ? psm.Peptide.LeucineSequence
                        : psm.Peptide.BaseLeucineSequence))
                    {
                        peptides.Add(
                            settings.considerModifiedFormsAsUniquePeptides
                                ? psm.Peptide.LeucineSequence
                                : psm.Peptide.BaseLeucineSequence, psm);
                    }
                }

                List<PeptideSpectrumMatch> sorted_peptides = new List<PeptideSpectrumMatch>(peptides.Values);
                sorted_peptides.Sort(PeptideSpectrumMatch.DescendingMorpheusScoreComparison);

                IEnumerable<IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch>> peptides_with_fdr =
                    FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(sorted_peptides, decoys_over_targets_peptide_ratio);
                //Exporters.WriteToTabDelimitedTextFile(peptides_with_fdr, Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(data_filepath) + ".unique_peptides.tsv"));
                double peptide_score_threshold = double.NegativeInfinity;
                int target_peptides = sorted_peptides.Count;
                int decoy_peptides = 0;
                double peptide_fdr = double.NaN;

                if (decoys_over_targets_peptide_ratio == 0.0)
                {
                    //log.WriteLine(sorted_peptides.Count.ToString("N0") + " unique peptides (unknown FDR)");
                }
                else
                {
                    FalseDiscoveryRate.DetermineMaximumIdentifications(peptides_with_fdr, false,
                        settings.maximumFalseDiscoveryRate, out peptide_score_threshold, out target_peptides,
                        out decoy_peptides, out peptide_fdr);
                    //    log.WriteLine(target_peptides.ToString("N0") + " unique target (" + decoy_peptides.ToString("N0") + " decoy) peptides at " + peptide_fdr.ToString("0.000%") + " unique peptide FDR (" + peptide_score_threshold.ToString("0.000") + " Morpheus score threshold)");
                }



                //problem here...reads protein file again
                //List<ProteinGroup> protein_groups = ProteinGroup.ApplyProteinParsimony(sorted_psms, peptide_score_threshold, proteome_database, settings.onTheFlyDecoys, known_variable_modifications, 
                //settings.protease, settings.maximumMissedCleavages, settings.initiatorMethionineBehavior, settings.maximumThreads);

                //public static List<ProteinGroup> ApplyProteinParsimony(IEnumerable<PeptideSpectrumMatch> peptideSpectrumMatches, double morpheusScoreThreshold, FileStream proteinFastaDatabase, 
                //bool onTheFlyDecoys, IDictionary<string, Modification> knownVariableModifications, Protease protease, int maximumMissedCleavages, InitiatorMethionineBehavior initiatorMethionineBehavior, int maximumThreads)


                List<ProteinGroup> protein_groups = ApplyProteinParsimony(settings, proteome_database,
                    known_variable_modifications, customProteins, parallel_options, sorted_psms,
                    peptide_score_threshold);








                IEnumerable<IdentificationWithFalseDiscoveryRate<ProteinGroup>> protein_groups_with_fdr =
                    FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(protein_groups, 1.0);//decoys_over_targets_protein_ratio);
                //Exporters.WriteToTabDelimitedTextFile(protein_groups_with_fdr, Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(data_filepath) + ".protein_groups.tsv"));
                double protein_group_score_threshold = double.NegativeInfinity;
                int target_protein_groups = protein_groups.Count;
                int decoy_protein_groups = 0;
                double protein_group_fdr = double.NaN;
                if (false)//decoys_over_targets_protein_ratio == 0.0)
                {
                    //log.WriteLine(protein_groups.Count.ToString("N0") + " protein groups (unknown FDR)");
                }
                else
                {
                    FalseDiscoveryRate.DetermineMaximumIdentifications(protein_groups_with_fdr, false,
                        settings.maximumFalseDiscoveryRate, out protein_group_score_threshold,
                        out target_protein_groups, out decoy_protein_groups, out protein_group_fdr);
                    //log.WriteLine(target_protein_groups.ToString("N0") + " target (" + decoy_protein_groups.ToString("N0") + " decoy) protein groups at " + protein_group_fdr.ToString("0.000%") + " protein group FDR (" + protein_group_score_threshold.ToString("0.000") + " summed Morpheus score threshold)");
                }
                /*
                DateTime stop = DateTime.Now;
                log.WriteLine((stop - start).TotalMinutes.ToString("0.00") + " minutes to analyze");
    
                log.Close();
    
                summary.Write(data_filepath + '\t');
                summary.Write(proteins.ToString() + '\t');
                summary.Write(spectra.Count.ToString() + '\t');
                summary.Write(psm_score_threshold.ToString("0.000") + '\t');
                summary.Write(target_psms.ToString() + '\t');
                summary.Write(decoy_psms.ToString() + '\t');
                summary.Write(psm_fdr.ToString("0.000%") + '\t');
                summary.Write(peptide_score_threshold.ToString("0.000") + '\t');
                summary.Write(target_peptides.ToString() + '\t');
                summary.Write(decoy_peptides.ToString() + '\t');
                summary.Write(peptide_fdr.ToString("0.000%") + '\t');
                summary.Write(protein_group_score_threshold.ToString("0.000") + '\t');
                summary.Write(target_protein_groups.ToString() + '\t');
                summary.Write(decoy_protein_groups.ToString() + '\t');
                summary.Write(protein_group_fdr.ToString("0.000%") + '\t');
                summary.WriteLine();
    
                OnFinishedFile(new FilepathEventArgs(data_filepath));
            }
    
            if(dataFilepaths.Count > 1)
            {
                OnUpdateStatus(new StatusEventArgs("Performing aggregate post-search analyses..."));
                OnReportTaskWithoutProgress(EventArgs.Empty);
                OnUpdateProgress(new ProgressEventArgs(0));
    
                overall_log.WriteLine((num_target_peptides + num_decoy_peptides).ToString("N0") + " total (" + num_target_peptides.ToString("N0") + " target + " + num_decoy_peptides.ToString("N0") + " decoy) non-unique peptides");
    
                HashSet<string> prefixes = new HashSet<string>();
                foreach(KeyValuePair<string, HashSet<string>> kvp in parents)
                {
                    DirectoryInfo directory_info = new DirectoryInfo(kvp.Key.Replace("*", null));
                    string prefix = directory_info.Name.Replace(@":\", null);
                    int id = 1;
                    while(prefixes.Contains(prefix))
                    {
                        id++;
                        prefix = directory_info.Name + '#' + id.ToString();
                    }
    
                    int semi_aggregate_spectra = 0;
                    List<PeptideSpectrumMatch> semi_aggregate_psms = new List<PeptideSpectrumMatch>();
                    foreach(string data_filepath in kvp.Value)
                    {
                        semi_aggregate_spectra += num_spectra[data_filepath];
                        semi_aggregate_psms.AddRange(grouped_aggregate_psms[data_filepath]);
                    }
    
                    overall_log.WriteLine(semi_aggregate_spectra.ToString("N0") + " MS/MS spectra in " + kvp.Key);
    
                    semi_aggregate_psms.Sort(PeptideSpectrumMatch.DescendingMorpheusScoreComparison);
    
                    IEnumerable<IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch>> semi_aggregate_psms_with_fdr = FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(semi_aggregate_psms, decoys_over_targets_peptide_ratio);
                    Exporters.WriteToTabDelimitedTextFile(semi_aggregate_psms_with_fdr, Path.Combine(outputFolder, prefix + ".PSMs.tsv"));
                    double semi_aggregate_psm_score_threshold;
                    int semi_aggregate_target_psms;
                    int semi_aggregate_decoy_psms;
                    double semi_aggregate_psm_fdr;
                    FalseDiscoveryRate.DetermineMaximumIdentifications(semi_aggregate_psms_with_fdr, false, maximumFalseDiscoveryRate, out semi_aggregate_psm_score_threshold, out semi_aggregate_target_psms, out semi_aggregate_decoy_psms, out semi_aggregate_psm_fdr);
                    overall_log.WriteLine(semi_aggregate_target_psms.ToString("N0") + " target (" + semi_aggregate_decoy_psms.ToString("N0") + " decoy) PSMs at " + semi_aggregate_psm_fdr.ToString("0.000%") + " PSM FDR (" + semi_aggregate_psm_score_threshold.ToString("0.000") + " Morpheus score threshold) in " + kvp.Key);
    
                    Dictionary<string, PeptideSpectrumMatch> semi_aggregate_peptides = new Dictionary<string, PeptideSpectrumMatch>();
    
                    foreach(PeptideSpectrumMatch psm in semi_aggregate_psms)
                    {
                        if(!semi_aggregate_peptides.ContainsKey(considerModifiedFormsAsUniquePeptides ? psm.Peptide.LeucineSequence : psm.Peptide.BaseLeucineSequence))
                        {
                            semi_aggregate_peptides.Add(considerModifiedFormsAsUniquePeptides ? psm.Peptide.LeucineSequence : psm.Peptide.BaseLeucineSequence, psm);
                        }
                    }
    
                    List<PeptideSpectrumMatch> semi_aggregate_sorted_peptides = new List<PeptideSpectrumMatch>(semi_aggregate_peptides.Values);
                    semi_aggregate_sorted_peptides.Sort(PeptideSpectrumMatch.DescendingMorpheusScoreComparison);
    
                    IEnumerable<IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch>> semi_aggregate_peptides_with_fdr = FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(semi_aggregate_sorted_peptides, decoys_over_targets_peptide_ratio);
                    Exporters.WriteToTabDelimitedTextFile(semi_aggregate_peptides_with_fdr, Path.Combine(outputFolder, prefix + ".unique_peptides.tsv"));
                    double semi_aggregate_peptide_score_threshold;
                    int semi_aggregate_target_peptides;
                    int semi_aggregate_decoy_peptides;
                    double semi_aggregate_peptide_fdr;
                    FalseDiscoveryRate.DetermineMaximumIdentifications(semi_aggregate_peptides_with_fdr, false, maximumFalseDiscoveryRate, out semi_aggregate_peptide_score_threshold, out semi_aggregate_target_peptides, out semi_aggregate_decoy_peptides, out semi_aggregate_peptide_fdr);
                    overall_log.WriteLine(semi_aggregate_target_peptides.ToString("N0") + " unique target (" + semi_aggregate_decoy_peptides.ToString("N0") + " decoy) peptides at " + semi_aggregate_peptide_fdr.ToString("0.000%") + " unique peptide FDR (" + semi_aggregate_peptide_score_threshold.ToString("0.000") + " Morpheus score threshold) in " + kvp.Key);
    
                    List<ProteinGroup> semi_aggregate_protein_groups = ProteinGroup.ApplyProteinParsimony(semi_aggregate_psms, semi_aggregate_peptide_score_threshold, proteome_database, onTheFlyDecoys, known_variable_modifications, protease, maximumMissedCleavages, initiatorMethionineBehavior, maximumThreads);
    
                    IEnumerable<IdentificationWithFalseDiscoveryRate<ProteinGroup>> semi_aggregate_protein_groups_with_fdr = FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(semi_aggregate_protein_groups, decoys_over_targets_protein_ratio);
                    Exporters.WriteToTabDelimitedTextFile(semi_aggregate_protein_groups_with_fdr, Path.Combine(outputFolder, prefix + ".protein_groups.tsv"));
                    double semi_aggregate_protein_group_score_threshold;
                    int semi_aggregate_target_protein_groups;
                    int semi_aggregate_decoy_protein_groups;
                    double semi_aggregate_protein_group_fdr;
                    FalseDiscoveryRate.DetermineMaximumIdentifications(semi_aggregate_protein_groups_with_fdr, false, maximumFalseDiscoveryRate, out semi_aggregate_protein_group_score_threshold, out semi_aggregate_target_protein_groups, out semi_aggregate_decoy_protein_groups, out semi_aggregate_protein_group_fdr);
                    overall_log.WriteLine(semi_aggregate_target_protein_groups.ToString("N0") + " target (" + semi_aggregate_decoy_protein_groups.ToString("N0") + " decoy) protein groups at " + semi_aggregate_protein_group_fdr.ToString("0.000%") + " protein group FDR (" + semi_aggregate_protein_group_score_threshold.ToString("0.000") + " summed Morpheus score threshold) in " + kvp.Key);
    
                    summary.Write(kvp.Key + '\t');
                    summary.Write(total_proteins.ToString() + '\t');
                    summary.Write(semi_aggregate_spectra.ToString() + '\t');
                    summary.Write(semi_aggregate_psm_score_threshold.ToString("0.000") + '\t');
                    summary.Write(semi_aggregate_target_psms.ToString() + '\t');
                    summary.Write(semi_aggregate_decoy_psms.ToString() + '\t');
                    summary.Write(semi_aggregate_psm_fdr.ToString("0.000%") + '\t');
                    summary.Write(semi_aggregate_peptide_score_threshold.ToString("0.000") + '\t');
                    summary.Write(semi_aggregate_target_peptides.ToString() + '\t');
                    summary.Write(semi_aggregate_decoy_peptides.ToString() + '\t');
                    summary.Write(semi_aggregate_peptide_fdr.ToString("0.000%") + '\t');
                    summary.Write(semi_aggregate_protein_group_score_threshold.ToString("0.000") + '\t');
                    summary.Write(semi_aggregate_target_protein_groups.ToString() + '\t');
                    summary.Write(semi_aggregate_decoy_protein_groups.ToString() + '\t');
                    summary.Write(semi_aggregate_protein_group_fdr.ToString("0.000%") + '\t');
                    summary.WriteLine();
                }
    
                overall_log.WriteLine(total_spectra.ToString("N0") + " MS/MS spectra");
    
                aggregate_psms.Sort(PeptideSpectrumMatch.DescendingMorpheusScoreComparison);
    
                IEnumerable<IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch>> aggregate_psms_with_fdr = FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(aggregate_psms, decoys_over_targets_peptide_ratio);
                Exporters.WriteToTabDelimitedTextFile(aggregate_psms_with_fdr, Path.Combine(outputFolder, "PSMs.tsv"));
                double aggregate_psm_score_threshold;
                int aggregate_target_psms;
                int aggregate_decoy_psms;
                double aggregate_psm_fdr;
                FalseDiscoveryRate.DetermineMaximumIdentifications(aggregate_psms_with_fdr, false, maximumFalseDiscoveryRate, out aggregate_psm_score_threshold, out aggregate_target_psms, out aggregate_decoy_psms, out aggregate_psm_fdr);
                overall_log.WriteLine(aggregate_target_psms.ToString("N0") + " target (" + aggregate_decoy_psms.ToString("N0") + " decoy) aggregate PSMs at " + aggregate_psm_fdr.ToString("0.000%") + " PSM FDR (" + aggregate_psm_score_threshold.ToString("0.000") + " Morpheus score threshold)");
    
                Dictionary<string, PeptideSpectrumMatch> aggregate_peptides = new Dictionary<string, PeptideSpectrumMatch>();
    
                foreach(PeptideSpectrumMatch psm in aggregate_psms)
                {
                    if(!aggregate_peptides.ContainsKey(considerModifiedFormsAsUniquePeptides ? psm.Peptide.LeucineSequence : psm.Peptide.BaseLeucineSequence))
                    {
                        aggregate_peptides.Add(considerModifiedFormsAsUniquePeptides ? psm.Peptide.LeucineSequence : psm.Peptide.BaseLeucineSequence, psm);
                    }
                }
    
                List<PeptideSpectrumMatch> aggregate_sorted_peptides = new List<PeptideSpectrumMatch>(aggregate_peptides.Values);
                aggregate_sorted_peptides.Sort(PeptideSpectrumMatch.DescendingMorpheusScoreComparison);
    
                IEnumerable<IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch>> aggregate_peptides_with_fdr = FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(aggregate_sorted_peptides, decoys_over_targets_peptide_ratio);
                Exporters.WriteToTabDelimitedTextFile(aggregate_peptides_with_fdr, Path.Combine(outputFolder, "unique_peptides.tsv"));
                double aggregate_peptide_score_threshold;
                int aggregate_target_peptides;
                int aggregate_decoy_peptides;
                double aggregate_peptide_fdr;
                FalseDiscoveryRate.DetermineMaximumIdentifications(aggregate_peptides_with_fdr, false, maximumFalseDiscoveryRate, out aggregate_peptide_score_threshold, out aggregate_target_peptides, out aggregate_decoy_peptides, out aggregate_peptide_fdr);
                overall_log.WriteLine(aggregate_target_peptides.ToString("N0") + " unique target (" + aggregate_decoy_peptides.ToString("N0") + " decoy) aggregate peptides at " + aggregate_peptide_fdr.ToString("0.000%") + " unique peptide FDR (" + aggregate_peptide_score_threshold.ToString("0.000") + " Morpheus score threshold)");
    
                List<ProteinGroup> aggregate_protein_groups = ProteinGroup.ApplyProteinParsimony(aggregate_psms, aggregate_peptide_score_threshold, proteome_database, onTheFlyDecoys, known_variable_modifications, protease, maximumMissedCleavages, initiatorMethionineBehavior, maximumThreads);
    
                IEnumerable<IdentificationWithFalseDiscoveryRate<ProteinGroup>> aggregate_protein_groups_with_fdr = FalseDiscoveryRate.DoFalseDiscoveryRateAnalysis(aggregate_protein_groups, decoys_over_targets_protein_ratio);
                Exporters.WriteToTabDelimitedTextFile(aggregate_protein_groups_with_fdr, Path.Combine(outputFolder, "protein_groups.tsv"));
                double aggregate_protein_group_score_threshold;
                int aggregate_target_protein_groups;
                int aggregate_decoy_protein_groups;
                double aggregate_protein_group_fdr;
                FalseDiscoveryRate.DetermineMaximumIdentifications(aggregate_protein_groups_with_fdr, false, maximumFalseDiscoveryRate, out aggregate_protein_group_score_threshold, out aggregate_target_protein_groups, out aggregate_decoy_protein_groups, out aggregate_protein_group_fdr);
                overall_log.WriteLine(aggregate_target_protein_groups.ToString("N0") + " target (" + aggregate_decoy_protein_groups.ToString("N0") + " decoy) aggregate protein groups at " + aggregate_protein_group_fdr.ToString("0.000%") + " protein group FDR (" + aggregate_protein_group_score_threshold.ToString("0.000") + " summed Morpheus score threshold)");
    
                DateTime overall_stop = DateTime.Now;
                overall_log.WriteLine((overall_stop - overall_start).TotalMinutes.ToString("0.00") + " minutes to analyze");
    
                overall_log.Close();
    
                summary.Write("AGGREGATE" + '\t');
                summary.Write(total_proteins.ToString() + '\t');
                summary.Write(total_spectra.ToString() + '\t');
                summary.Write(aggregate_psm_score_threshold.ToString("0.000") + '\t');
                summary.Write(aggregate_target_psms.ToString() + '\t');
                summary.Write(aggregate_decoy_psms.ToString() + '\t');
                summary.Write(aggregate_psm_fdr.ToString("0.000%") + '\t');
                summary.Write(aggregate_peptide_score_threshold.ToString("0.000") + '\t');
                summary.Write(aggregate_target_peptides.ToString() + '\t');
                summary.Write(aggregate_decoy_peptides.ToString() + '\t');
                summary.Write(aggregate_peptide_fdr.ToString("0.000%") + '\t');
                summary.Write(aggregate_protein_group_score_threshold.ToString("0.000") + '\t');
                summary.Write(aggregate_target_protein_groups.ToString() + '\t');
                summary.Write(aggregate_decoy_protein_groups.ToString() + '\t');
                summary.Write(aggregate_protein_group_fdr.ToString("0.000%") + '\t');
                summary.WriteLine();
            }
    */
                //progress.Report("[" + rawfile.FullName + "] Stop 4, most stuff calculated " + stopwatch.Elapsed.TotalSeconds.ToString("0.000") + " seconds");
                proteome_database.Close();
                proteome_database.Dispose();
                /*     summary.Close();
                 }
                 catch(Exception ex)
                 {
                     if(overall_log != null && overall_log.BaseStream != null && overall_log.BaseStream.CanWrite)
                     {
                         overall_log.WriteLine(ex.ToString());
                     }
                     if(log != null && log.BaseStream != null && log.BaseStream.CanWrite)
                     {
                         log.WriteLine(ex.ToString());
                     }
                     OnThrowException(new ExceptionEventArgs(ex));
                 }
                 finally
                 {
                     if(overall_log != null)
                     {
                         overall_log.Close();
                     }
                     if(summary != null)
                     {
                         summary.Close();
                     }
                     if(log != null)
                     {
                         log.Close();
                     }
                     if(proteome_database != null)
                     {
                         proteome_database.Close();
                     }
                 }*/




                //New addition of return variables
                int msmsCount = spectra.Count;
                Dictionary<string, double> customProteinsSeqCoverage = new Dictionary<string, double>(4)
                {
                    { "X1BSA", 0.0 },
                    { "X1Trypsin", 0.0 },
                    { "X1LysC", 0.0 },
                    { "X1Mycoplasma", 0.0 }
                };
                foreach (ProteinGroup curProteinGroup in protein_groups)
                {
                    foreach (Protein proteinEntry in curProteinGroup)
                    {
                        if (customProteinsSeqCoverage.ContainsKey(proteinEntry.Description))
                        {
                            customProteinsSeqCoverage[proteinEntry.Description] =
                                (proteinEntry.CalculateSequenceCoverage() * 100.0);
                        }
                    }
                }




                float repeatedSeq = FindRepeatedSequencing(settings.maximumFalseDiscoveryRate, psms_with_fdr);
                float idRate = (float) target_psms * 100 / spectra.Count;



                //calculations on identified peptides
                List<PeptideSpectrumMatch> peps = sorted_peptides
                    .Where(pep => pep.MorpheusScore > peptide_score_threshold && pep.Target).Select(pep => pep).ToList();

                double averageScore = 0;
                double averageMassErrorPpm = 0;
                double modeMassErrorPpm = 0;
                double sumMissedCleavage = 0;
                double totalObservations = 0;
                double averageMissedCleavage = 0;
                double averagePeptideLength = 0;
                string mods = "";
                if (peps.Count > 0)
                {
                    
                    /*
                    Parallel.Invoke(
                    () => averageScore = peps.Select(pep => pep.MorpheusScore).Average(),
                    () => averageMassErrorPpm = peps.Select(pep => pep.PrecursorMassErrorPpm).Average(),
                    () => modeMassErrorPpm = MathFunctions.Mode(peps.Select(pep => pep.PrecursorMassErrorPpm).ToList()),
                    () =>
                    {
                        List<Tuple<double, double>> missedCleavages =
                        peps.GroupBy(pep => pep.Peptide.MissedCleavages)
                            .Select(group => new Tuple<double, double>((double)group.Key, (double)group.Count()))
                            .ToList();

                        foreach (Tuple<double, double> item in missedCleavages)
                        {
                            sumMissedCleavage += item.Item1 * item.Item2;
                            totalObservations += item.Item2;
                        }
                        if (totalObservations > 0)
                        {
                            averageMissedCleavage = sumMissedCleavage / totalObservations * 100;
                        }
                    },
                    //use this
                    () =>
                    {
                        List<Tuple<string, int>> modListList2 = peps
                            .Where(pep => pep.Peptide.VariableModifications != null &&
                                          pep.Peptide.VariableModifications.Count > 0)
                            .Select(pep => pep.Peptide.VariableModifications.Values.Select(mod => mod.Description).ToList())
                            .ToList().SelectMany(x => x).GroupBy(pep => pep)
                            .Select(group => new Tuple<string, int>(group.Key, group.Count())).ToList();

                        StringBuilder modString = new StringBuilder();

                        foreach (Tuple<string, int> item in modListList2)
                        {
                            //mods += item.Item1 + ":" + item.Item2.ToString() + "[" +
                            //        string.Format("0.00",item.Item2 * 100.0 / target_psms) + "%];";
                            modString.Append(string.Format("{0}:{1}[{2:0.00}%]", item.Item1, item.Item2.ToString(), item.Item2 * 100.0 / target_psms));
                        }
                        mods = modString.ToString();
                    },
                    () => averagePeptideLength = peps.Select(pep => pep.Peptide.Length).Average());
                    */


                    
                    averageScore = peps.Select(pep => pep.MorpheusScore).Average();
                    averageMassErrorPpm = peps.Select(pep => pep.PrecursorMassErrorPpm).Average();
                    modeMassErrorPpm = MathFunctions.Mode(peps.Select(pep => pep.PrecursorMassErrorPpm).ToList());
                    List<Tuple<double, double>> missedCleavages =
                        peps.GroupBy(pep => pep.Peptide.MissedCleavages)
                            .Select(group => new Tuple<double, double>((double)group.Key, (double)group.Count()))
                            .ToList();
                    
                    foreach (Tuple<double, double> item in missedCleavages)
                    {
                        sumMissedCleavage += item.Item1 * item.Item2;
                        totalObservations += item.Item2;
                    }
                    if (totalObservations > 0)
                    {
                        averageMissedCleavage = sumMissedCleavage / totalObservations * 100;
                    }
                    //use this
                    List<Tuple<string, int>> modListList2 = peps
                        .Where(pep => pep.Peptide.VariableModifications != null &&
                                      pep.Peptide.VariableModifications.Count > 0)
                        .Select(pep => pep.Peptide.VariableModifications.Values.Select(mod => mod.Description).ToList())
                        .ToList().SelectMany(x => x).GroupBy(pep => pep)
                        .Select(group => new Tuple<string, int>(group.Key, group.Count())).ToList();

                    StringBuilder modString = new StringBuilder();

                    foreach (Tuple<string, int> item in modListList2)
                    {
                        //mods += item.Item1 + ":" + item.Item2.ToString() + "[" +
                        //        string.Format("0.00",item.Item2 * 100.0 / target_psms) + "%];";
                        modString.Append(string.Format("{0}:{1}[{2:0.00}%]", item.Item1, item.Item2.ToString(), item.Item2 * 100.0 / target_psms));
                    }
                    mods = modString.ToString();
                    averagePeptideLength = peps.Select(pep => pep.Peptide.Length).Average();
                    
                }
                //progress.Report("[" + rawfile.FullName + "] Stop 5, remaining stuff calculated " + stopwatch.Elapsed.TotalSeconds.ToString("0.000") + " seconds");
                /*
                New values that can be calculated here:
                 * Cutoff score peptide_score_threshold.ToString("0.000")
                 * Median score (maybe parameter?)
                 * Peak width and variability
                 * Peak capacity
                 * Something more with LC parameters, i.e. delay before elution starts, how evenly spread the peaks are
                 * Elution time 3 BSA peptides
                 * Precursor mass error
                 * Fragment mass error
                 * Missed cleavages
                 * Semitryptic cleavages
                 * Non-tryptic cleavages
                 * Most common modifications
                 * Trypsin amount
                 * Keratin amount
                 * Average peptide length
                 * Average peptide pI or Gravy?
                 
                 
    
                 * * 
                */

                //this.results["MS2 count"].SetValue((double)msmsCount);//this doens't work as another key already is present...
                results.SetValue("Peptide spectrum matches", target_psms, 0);
                results.SetValue("Protein groups", target_protein_groups, 0);
                results.SetValue("Unique peptides", target_peptides, 0);
                results.SetValue("ID rate percent", (double) idRate, 1);
                results.SetValue("BSA sequence coverage", customProteinsSeqCoverage["X1BSA"], 1);
                results.SetValue("Repeated sequencing percent", (double) repeatedSeq, 1);
                results.SetValue("Average Morpheus score", averageScore, 2);
                results.SetValue("Average mass error in ppm", averageMassErrorPpm, 2);
                results.SetValue("Mode mass error in ppm", modeMassErrorPpm, 2);
                results.SetValue("Average peptide length", averagePeptideLength, 2);
                results.SetValue("Average missed cleavages percent", averageMissedCleavage, 1);
                results.SetValue("Modifications", mods);

                results.SetValue("Mycoplasma abundance", customProteinsSeqCoverage["X1Mycoplasma"], 1);
                results.SetValue("Trypsin abundance", customProteinsSeqCoverage["X1Trypsin"], 1);
                results.SetValue("LysC abundance", customProteinsSeqCoverage["X1LysC"], 1);

                results.SetValue("Analysis fasta file", settings.proteomeDatabaseFilepath);
                results.SetValue("Analysis enzyme", settings.CurrentProtease.ToString());
                results.SetValue("Analysis precursor mass accuracy", settings.precursorMassToleranceValue);
                results.SetValue("Analysis fragment mass accuracy", settings.productMassToleranceValue);
                results.SetValue("Analysis settings encoded", settings.GetHash());

            }
            return results;
        }


        private List<ProteinGroup> ApplyProteinParsimony(SettingsForAnalysis settings, FileStream proteome_database, Dictionary<string, Modification> known_variable_modifications, List<Protein> customProteins, ParallelOptions parallel_options, List<PeptideSpectrumMatch> sorted_psms, double peptide_score_threshold)
        {


            // make a list of the all the distinct base leucine peptide sequences
            Dictionary<string, List<Protein>> peptide_proteins = new Dictionary<string, List<Protein>>();
            foreach (PeptideSpectrumMatch psm in sorted_psms)
            {
                if (psm.MorpheusScore >= peptide_score_threshold)
                {
                    if (!peptide_proteins.ContainsKey(psm.Peptide.BaseLeucineSequence))
                    {
                        peptide_proteins.Add(psm.Peptide.BaseLeucineSequence, new List<Protein>());
                    }
                }
            }

            // record all proteins that could have been the source of each peptide
            //ParallelOptions parallel_options = new ParallelOptions();
            //parallel_options.MaxDegreeOfParallelism = maximumThreads;
            Parallel.ForEach(ReadProteinsAndList(proteome_database, settings.onTheFlyDecoys, known_variable_modifications, customProteins), parallel_options, protein =>
            {
                foreach (Peptide peptide in protein.Digest(settings.CurrentProtease, settings.maximumMissedCleavages, settings.initiatorMethionine, null, null))
                {
                    lock (peptide_proteins)
                    {
                        List<Protein> proteins1;
                        if (peptide_proteins.TryGetValue(peptide.BaseLeucineSequence, out proteins1))
                        {
                            List<Peptide> peptides1;
                            if (!protein.IdentifiedPeptides.TryGetValue(peptide.BaseLeucineSequence, out peptides1))
                            {
                                peptides1 = new List<Peptide>
                                {
                                    peptide
                                };
                                protein.IdentifiedPeptides.Add(peptide.BaseLeucineSequence, peptides1);
                            }
                            else
                            {
                                peptides1.Add(peptide);
                            }
                            proteins1.Add(protein);
                        }
                    }
                }
            }
            );

            // create protein groups (initially with just one protein each) and assign PSMs to them
            Dictionary<string, ProteinGroup> proteins_by_description = new Dictionary<string, ProteinGroup>();
            foreach (PeptideSpectrumMatch psm in sorted_psms)
            {
                if (psm.MorpheusScore >= peptide_score_threshold)
                {
                    foreach (Protein protein in peptide_proteins[psm.Peptide.BaseLeucineSequence])
                    {

                        // check to make sure this protein's known modifications match the PSM's
                        bool known_modification_match = true;
                        if (psm.Peptide.VariableModifications != null && psm.Peptide.VariableModifications.Count > 0)
                        {
                            foreach (KeyValuePair<int, Modification> kvp in psm.Peptide.VariableModifications)
                            {
                                if (kvp.Value.Known)
                                {
                                    List<Modification> protein_modifications = null;
                                    if (protein.KnownModifications == null ||
                                        !protein.KnownModifications.TryGetValue(psm.Peptide.StartResidueNumber - 1 + kvp.Key, out protein_modifications) ||
                                        !protein_modifications.Contains(kvp.Value))
                                    {
                                        known_modification_match = false;
                                        break;
                                    }
                                }
                            }
                            if (!known_modification_match)
                            {
                                continue;
                            }
                        }


                        ProteinGroup protein_group;
                        if (!proteins_by_description.TryGetValue(protein.Description, out protein_group))
                        {
                            protein_group = new ProteinGroup
                            {
                                protein
                            };
                            protein_group.PeptideSpectrumMatches.Add(psm);
                            proteins_by_description.Add(protein.Description, protein_group);
                        }
                        else
                        {
                            protein_group.PeptideSpectrumMatches.Add(psm);
                        }
                    }
                }
            }

            List<ProteinGroup> protein_groups = new List<ProteinGroup>(proteins_by_description.Values);
            protein_groups.Sort(ProteinGroup.DescendingSummedMorpheusScoreProteinGroupComparison);

            // todo: remove shared peptides from lower-scoring protein group?

            // merge indistinguishable proteins (technically protein groups but they only contain a single protein thus far)
            for (int i = 0; i < protein_groups.Count - 1; i++)
            {
                ProteinGroup protein_group = protein_groups[i];

                int j = i + 1;
                while (j < protein_groups.Count)
                {
                    ProteinGroup lower_protein_group = protein_groups[j];

                    if (lower_protein_group.SummedMorpheusScore < protein_group.SummedMorpheusScore)
                    {
                        break;
                    }

                    if (lower_protein_group.BaseLeucinePeptideSequences.SetEquals(protein_group.BaseLeucinePeptideSequences))
                    {
                        protein_group.UnionWith(lower_protein_group);  // should only ever be one protein in the group to add
                        protein_groups.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            // remove subset and subsumable protein groups
            int k = protein_groups.Count - 1;
            while (k >= 1)
            {
                ProteinGroup protein_group = protein_groups[k];
                HashSet<string> protein_group_peptides = new HashSet<string>(protein_group.BaseLeucinePeptideSequences);

                for (int l = 0; l < k; l++)
                {
                    ProteinGroup higher_protein_group = protein_groups[l];

                    protein_group_peptides.ExceptWith(higher_protein_group.BaseLeucinePeptideSequences);
                    if (protein_group_peptides.Count == 0)
                    {
                        break;
                    }
                }

                if (protein_group_peptides.Count == 0)
                {
                    protein_groups.RemoveAt(k);
                }
                k--;
            }

            //return protein_groups;


            return protein_groups;
        }

        private static void SearchProtein(SettingsForAnalysis settings, ref int num_target_peptides, ref int num_decoy_peptides, List<Modification> unknown_variable_modifications, TandemMassSpectra spectra, PeptideSpectrumMatch[] psms, Dictionary<string, bool> peptides_observed, Protein protein)
        {
            foreach (Peptide peptide in protein.Digest(settings.CurrentProtease, settings.maximumMissedCleavages, settings.initiatorMethionine, null, null))
            {
                if (peptide.Target)
                {
                    Interlocked.Increment(ref num_target_peptides);
                }
                else
                {
                    Interlocked.Increment(ref num_decoy_peptides);
                }

                if (!settings.minimizeMemoryUsage)
                {
                    // This block of code is to ensure that (1) we don't re-search the same base leucine peptide sequence more than we need to, 
                    // and (2) that we are maximally conservative by calling PSMs decoy whenever possible.
                    // If we haven't already seen this base leucine peptide sequence, add it to the dictionary with a value indicating whether it was decoy or not.
                    // Then perform the search as usual.
                    // If we have already seen it and it was decoy or this time it is target, we don't need to search it again, skip the peptide.
                    // Otherwise, update the dictionary to reflect that we have now seen it as a decoy and perform the search.
                    lock (peptides_observed)
                    {
                        bool observed_as_decoy = false;
                        if (!peptides_observed.TryGetValue(peptide.BaseLeucineSequence, out observed_as_decoy))
                        {
                            peptides_observed.Add(peptide.BaseLeucineSequence, peptide.Decoy);
                        }
                        else
                        {
                            if (observed_as_decoy || peptide.Target)
                            {
                                // if the peptide has no known mods we have already searched all its isoforms, skip it
                                if (peptide.KnownModifications == null || peptide.KnownModifications.Count == 0)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                peptides_observed[peptide.BaseLeucineSequence] = true;
                            }
                        }
                    }
                }

                peptide.SetFixedModifications(settings.fixedModifications);
                foreach (Peptide modified_peptide in peptide.GetVariablyModifiedPeptides(unknown_variable_modifications, settings.maximumVariableModificationIsoforms))
                {
                    foreach (TandemMassSpectrum spectrum in settings.precursorMonoisotopicPeakCorrection ?
                        spectra.GetTandemMassSpectraInMassRange(settings.precursorMassType == MassType.Average ? modified_peptide.AverageMass : modified_peptide.MonoisotopicMass, settings.precursorMassTolerance, settings.minimumPrecursorMonoisotopicPeakOffset, settings.maximumPrecursorMonoisotopicPeakOffset) :
                        spectra.GetTandemMassSpectraInMassRange(settings.precursorMassType == MassType.Average ? modified_peptide.AverageMass : modified_peptide.MonoisotopicMass, settings.precursorMassTolerance))
                    {
                        PeptideSpectrumMatch psm = new PeptideSpectrumMatch(spectrum, modified_peptide, settings.productMassTolerance);
                        lock (psms)
                        {
                            PeptideSpectrumMatch current_best_psm = psms[spectrum.SpectrumNumber - 1];
                            if (current_best_psm == null || PeptideSpectrumMatch.DescendingMorpheusScoreComparison(psm, current_best_psm) < 0)
                            {
                                psms[spectrum.SpectrumNumber - 1] = psm;
                            }
                        }
                    }
                }
            }
        }
        private static float FindRepeatedSequencing(double maximumFalseDiscoveryRate, IEnumerable<IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch>> psms_with_fdr)
        {
            HashSet<string> pepIdWithCharge = new HashSet<string>();
            int seenMultiple = 0;
            foreach (IdentificationWithFalseDiscoveryRate<PeptideSpectrumMatch> loopPSM in psms_with_fdr)
            {
                if (loopPSM.QValue < maximumFalseDiscoveryRate)
                {
                    string teststr = loopPSM.Identification.Peptide.LeucineSequence + loopPSM.Identification.Spectrum.PrecursorCharge.ToString();
                    if (!pepIdWithCharge.Contains(teststr))
                    {
                        pepIdWithCharge.Add(teststr);
                    }
                    else
                    {
                        seenMultiple++;
                    }
                }
            }
            float repeatedSeq = (float)seenMultiple / pepIdWithCharge.Count * 100;
            return repeatedSeq;
        }
        private IEnumerable<Protein> ReadProteinsAndList(FileStream proteomeDatabase, bool onTheFlyDecoys, IDictionary<string, Modification> knownVariableModifications, List<Protein> additionalProteins)
        {
            foreach (Protein additionalProtein in additionalProteins)
            {
                yield return additionalProtein;
            }
            foreach (Protein additionalProtein in ProteomeDatabaseReader.ReadProteins( proteomeDatabase,  onTheFlyDecoys, knownVariableModifications))
            {
                yield return additionalProtein;
            }
        }
    }


       
   


}
