using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analysis_genetics1
{
    class FinalDataCleaner
    {
        // Eliminates 'oc-score-1' - my first, flawed attempt at scoring objective comprehension -
        // which had actually included two subjective comprehension scores (the answers about the likelihood expressed as 'likely', 'unlikely', etc)
        // and had scored them correctly if users answered in accordance with common numeric interpretations of those words (e.g. 'unlikely' must 
        // be between 1% and 49%). However, after discussion with colleagues and reflecting that there is no objective answer to whether a
        // cystic fibrosis risk of 25% is 'likely' or 'unlikely', this approach was scrapped. This discussion and the decision to scrap
        // this way of computing objective comprehension took place prior to statistical hypothesis testing.
        //
        // Also removes several blank columns, as well as Prolific IDs for privacy purposes.
        //
        internal void Clean(string infile, string outfile)
        {
            string[] columnsToEliminate = { "prolific-id", "oc-score-1", "Q177_First_Click", "Q177_Last_Click", "Q177_Page_Submit", "Q177_Click_Count", "consent-mistake" };
            HashSet<int> columnsIdsToEliminate = new HashSet<int>();

            using (StreamReader sr = new StreamReader(Globals.DataPath + infile))
            using (StreamWriter sw = new StreamWriter(Globals.DataPath + outfile))
            {
                // Write header and get columns to eliminate
                string[] headerTokens = sr.ReadLine().Split('\t');
                for (int i = 0; i < headerTokens.Length; i++)
                {
                    string t = headerTokens[i];

                    if (t == "oc-score-2")
                    {
                        sw.Write("oc-score\t");
                    }
                    else if (columnsToEliminate.Contains(t))
                    {
                        columnsIdsToEliminate.Add(i);
                    }
                    else
                    {
                        sw.Write(t);
                        if (i != headerTokens.Length - 1) sw.Write('\t');
                    }
                }
                sw.WriteLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "") continue;
                    string[] tokens = line.Split('\t');
                    for (int i = 0; i < tokens.Length; i++)
                    {
                        if (!columnsIdsToEliminate.Contains(i))
                        {
                            sw.Write(tokens[i]);
                            if (i != headerTokens.Length - 1) sw.Write('\t');
                        }
                    }
                    sw.WriteLine();
                }
            }

        }


    }
}
