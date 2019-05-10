using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analysis_genetics1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////Step 0: Get mappings from Qualtrics ChoiceText output to Qualtrics Numeric output;
            // it's not always what you would expect!

            //QualtricsMapping qm = new QualtricsMapping();
            //qm.BuildMapping("Results_Numeric_February 1, 2019_10.50.csv", "Results_ChoiceText_February 1, 2019_10.50.csv", 178);

            //// Step 1: Read in Results_v1.tsv.txt and generate Results_v2_ForCoding.tsv.txt
            //// (which we will manually copy-paste into an xlsx file) so that correct/incorrect
            //// answers to free-text objective comprehension questions can be coded in a blinded manner. (Done!)
            //
            //Dataset1 dataset1 = new Dataset1("Results_v1.tsv.txt");
            //dataset1.WriteDataset2ForCoding("Results_v2_ForCoding.tsv.txt");

            //// Step 2: Manually code answers to objective comprehension questions 
            //// (using lax criteria) in Results_v2_forCoding.xlsx ;
            //// copy results manually to Results_v3_Coded.tsv.txt. (Done!)

            //// Step 3: Create tidy data file that 
            // (1) combines original data with the data we just coded; and
            // (2) adds the following derived measures:
            // - scores on objective comprehension questions;
            // - total objective comprehension score;
            // - total communication efficacy score;
            // - total subjective numeracy score (remembering to reverse-code item 7);
            // - 3 codes indicating which question came first in the counterbalancing:
            //   * 'status' before 'child' (yes (1) or no (0));
            //   * 'status' before 'compare' (yes (1) or no (0));
            //   * 'child' before 'compare' (yes (1) or no (0)).

            //Dataset4 dataset4 = new Dataset4();
            //dataset4.WriteCombinedFile("Results_v1.tsv.txt", "Results_v3_Coded.tsv.txt", "Results_v4_Combined.tsv.txt");
            //dataset4.LoadCombinedFile("Results_v4_Combined.tsv.txt");
            //dataset4.WriteTidyDataset5("Results_v5_Tidy.tsv.txt", qm);

            //// Step 4: Do sanity checks

            //Dataset1 dataset1 = new Dataset1("Results_v1.tsv.txt");
            //Dataset5 dataset5 = new Dataset5("Results_v5_Tidy.tsv.txt");
            //dataset5.DoSanityChecks(dataset1, "sanitycheck_results.out.txt");

            //// Step 5: Produce final, cleaned-up tiny data file.
            //
            // Eliminates 'oc-score-1' - my first, flawed attempt at scoring objective comprehension -
            // which had actually included two subjective comprehension scores (the answers about the likelihood expressed as 'likely', 'unlikely', etc)
            // and had scored them correctly if users answered in accordance with common numeric interpretations of those words (e.g. 'unlikely' must 
            // be between 1% and 49%). However, after discussion with colleagues and reflecting that there is no objective answer to whether a
            // cystic fibrosis risk of 25% is 'likely' or 'unlikely', this approach was scrapped. This discussion and the decision to scrap
            // this way of computing objective comprehension took place prior to statistical hypothesis testing.
            //
            // oc-score-2 has been renamed to oc-score.
            // Various blank columns cleaned.

            FinalDataCleaner cleaner = new FinalDataCleaner();
            cleaner.Clean("Results_v5_Tidy.tsv.txt", "Results_TidyClean.tsv.txt");
        }
        
    }
}
