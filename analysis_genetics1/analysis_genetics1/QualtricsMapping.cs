using ChoETL;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace analysis_genetics1
{
    class QualtricsMapping
    {
        const string ImportLinePrefix = @"""{""""ImportId";

        // keys: 'variables', the column names of numericTsv (and choiceTextTsv, should be identical)
        // values: a dictionary of all the different number-to-choicetext mappings we observe
        Dictionary<string, Dictionary<int, string>> variablesToNumKeyedMappings = new Dictionary<string, Dictionary<int, string>>();

        // keys: 'variables', the column names of numericTsv (and choiceTextTsv, should be identical)
        // values: a dictionary of all the different choicetext-to-number mappings we observe
        Dictionary<string, Dictionary<string, int>> variablesToTextKeyedMappings = new Dictionary<string, Dictionary<string, int>>();

        public QualtricsMapping()
        {

        }

        public string GetChoiceTextCorrespondingToNumber(string variable, int number)
        {
            return variablesToNumKeyedMappings[variable][number];
        }

        public int GetNumberCorrespondingToChoiceText(string variable, string choiceText)
        {
            return variablesToTextKeyedMappings[variable][choiceText];
        }

        /// <summary>
        /// Build the mapping between Qualtrics numeric identifiers for questionnaire answers
        /// (in the CSV with 'Numeric' in the title), and the actual text the user selected
        /// (in the CSV with 'ChoiceText' in the title). The mapping isn't always obvious!
        /// </summary>
        public Dictionary<string, Dictionary<string, int>> BuildMapping(string numericCsv, string choiceTextCsv, int columnCount)
        {
            // Write a temporary ChoiceText CSV file that doesn't have extraneous newlines (as they mess up the
            // CSV reader...)
            string cleanedUpChoiceTextCsv = Globals.DataPath + Path.GetFileNameWithoutExtension(choiceTextCsv) + ".cleanedup.csv";
            WriteCleanedUpChoiceTextCsv(Globals.DataPath + choiceTextCsv, cleanedUpChoiceTextCsv);

            using (TextFieldParser numCsvParser = new TextFieldParser(Globals.DataPath + numericCsv))
            using (TextFieldParser textCsvParser = new TextFieldParser(cleanedUpChoiceTextCsv))
            using (StreamWriter sw = new StreamWriter(Globals.DataPath + "Qualtrics_Numeric_to_ChoiceText_Mapping.out.txt"))
            {
                numCsvParser.CommentTokens = new string[] { "#" };
                numCsvParser.SetDelimiters(new string[] { "," });
                numCsvParser.HasFieldsEnclosedInQuotes = true;
                textCsvParser.CommentTokens = new string[] { "#" };
                textCsvParser.SetDelimiters(new string[] { "," });
                textCsvParser.HasFieldsEnclosedInQuotes = true;

                // Get headers
                //
                string numericHeader = numCsvParser.ReadLine();
                string textHeader = textCsvParser.ReadLine();
                if (numericHeader != textHeader) SanityCheck.AssertFailed();
                string[] columnNames = Extensions.ParseLineAsCSV(numericHeader);
                if (columnNames.Length != columnCount) SanityCheck.AssertFailed();

                // Read data (skipping intervening lines)
                //
                bool inInterveningJunk = true;
                string numericLine = "";
                string textLine = "";
                while (!numCsvParser.EndOfData)
                {
                    
                    if (inInterveningJunk)
                    {
                        numericLine = numCsvParser.ReadLine();
                        textLine = textCsvParser.ReadLine();
                        if (numericLine.StartsWith(ImportLinePrefix)) inInterveningJunk = false;
                    }

                    if (!inInterveningJunk)
                    {
                        string[] numericTokens = numCsvParser.ReadFields();
                        string[] textTokens = textCsvParser.ReadFields();
                        if (numericTokens.Length != textTokens.Length) SanityCheck.AssertFailed();

                        for (int i = 0; i < columnCount; i++)
                        {
                            if (numericTokens[i] != textTokens[i] && !Regex.IsMatch(numericTokens[i], @"^[0-9],[0-9,]+"))
                            {
                                string variable = columnNames[i];
                                int number = int.Parse(numericTokens[i]);
                                string choiceText = textTokens[i];

                                if (!variablesToNumKeyedMappings.ContainsKey(variable)) variablesToNumKeyedMappings.Add(variable, new Dictionary<int, string>());

                                if (variablesToNumKeyedMappings[variable].ContainsKey(number))
                                {
                                    if (variablesToNumKeyedMappings[variable][number] != choiceText)
                                    {
                                        throw new Exception("WARNING: More than one choiceText for '" + variable + "' maps onto the value " + numericTokens[i] + "!");
                                    }
                                }
                                else
                                {
                                    variablesToNumKeyedMappings[variable].Add(number, choiceText);
                                }

                            }
                        }
                    }
                }

                // Once we have had a good look at the input files and built the mappings, let's write them to file
                foreach (var vm in variablesToNumKeyedMappings.OrderBy(x => x.Key))
                {
                    string variable = vm.Key;
                    Dictionary<int, string> numbersToChoiceText = vm.Value;

                    sw.WriteLine("*** " + vm.Key + " ***");
                    foreach (var kv in numbersToChoiceText.OrderBy(x => x.Key))
                    {
                        sw.WriteLine(kv.Key.ToString() + "\t" + kv.Value);
                    }
                    sw.WriteLine();
                }
            }


            // Finally, let's produce a dictionary identical to variablesToNumKeyedMappings,
            // but with keys and values switched in the inner dictionary

            foreach (var vm in variablesToNumKeyedMappings)
            {
                string variable = vm.Key;
                variablesToTextKeyedMappings.Add(variable, new Dictionary<string, int>());
                
                foreach (var kv in vm.Value)
                {
                    variablesToTextKeyedMappings[variable].Add(kv.Value, kv.Key);
                }
            }

            return variablesToTextKeyedMappings;
        }

        /// <summary>
        /// Newlines mess up our CSV reader. We are going to exploit the fact that every record of a CSV exported
        /// by Qualtrics begins in the same way in order to eliminate newlines that we don't want and keep ones we do.
        /// </summary>
        /// <param name="infile"></param>
        /// <param name="outfile"></param>
        private void WriteCleanedUpChoiceTextCsv(string infile, string outfile)
        {
            Regex reEndOfUnfinishedRecord = new Regex("Stop without completing,*$", RegexOptions.Compiled);
            Regex reEndOfFinishedRecord = new Regex("(Control|UCD),(Negative|Positive),.*$", RegexOptions.Compiled);

            using (StreamReader sr = new StreamReader(infile))
            using (StreamWriter sw = new StreamWriter(outfile))
            {
                // Copy first lines verbatim, until we get to the actual data
                while (!sr.EndOfStream)
                {
                    string headerLine = sr.ReadLine();
                    sw.WriteLine(headerLine);
                    if (headerLine.StartsWith(ImportLinePrefix))
                    {
                        break;
                    }
                }

                // Clean up any newlines in the actual data
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    sw.Write(line);
                    if (reEndOfUnfinishedRecord.IsMatch(line) || reEndOfFinishedRecord.IsMatch(line))
                    {
                        sw.WriteLine();
                    }
                }
            }

        }

    }
}
