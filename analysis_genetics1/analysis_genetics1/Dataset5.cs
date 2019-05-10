using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace analysis_genetics1
{
    class Dataset5
    {
        public List<Result5Row> Data = new List<Result5Row>();
        public List<string> Lines = new List<string>();
        public string Header = "";

        public Dataset5(string infile)
        {
            using (StreamReader sr = new StreamReader(Globals.DataPath + infile))
            {
                Header = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "") continue;

                    Lines.Add(line);
                    var row = new Result5Row('\t', line);
                    Data.Add(row);
                }
            }
        }

        public static Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                object value = prp.GetValue(atype, new object[] { });
                dict.Add(prp.Name, value);
            }
            return dict;
        }

        internal void DoSanityChecks(Dataset1 dataset1, string outfile)
        {

            using (StreamWriter sw = new StreamWriter(Globals.DataPath + outfile))
            {
                if (dataset1.Lines.Count != Lines.Count || dataset1.Data.Count != Data.Count || Data.Count != Lines.Count)
                {
                    throw new Exception("Mismatch in baseline dataset characteristics");
                }

                // 1 - Ensure that all fields of dataset 1 are the same in dataset 5

                for (int i = 0; i < dataset1.Lines.Count; i++)
                {
                    var d1row = dataset1.Data[i];
                    var d5row = Data[i];
                    if (d1row.ProlificId != d5row.ProlificId)
                    {
                        throw new Exception("Mismatch in Prolific Ids");
                    }

                    var d1Properties = DictionaryFromType(d1row);
                    var d5Properties = DictionaryFromType(d5row);
                    foreach (var key in d1Properties.Keys)
                    {
                        if (d5Properties[key].ToString() != d1Properties[key].ToString())
                        {
                            sw.WriteLine("Mismatch in " + d1row.ProlificId + " " + key + ": d1:" + d1Properties[key].ToString() + ", d5:" + d5Properties[key].ToString());
                        }
                    }
                }

                // 2 - Output some ranges so we can check that they are sensible

                //sw.WriteLine("Ranges");
                //sw.WriteLine("*****************");
                ////PrintRange(sw, Data, "SubjectiveNumeracy");
                //sw.WriteSepLine("\t", "SubjectiveNumeracy", Data.Min(x => double.Parse(x.SubjectiveNumeracy)), Data.Max(x => double.Parse(x.SubjectiveNumeracy)));
                //sw.WriteSepLine("\t", "CommunicationEfficacy", Data.Min(x => double.Parse(x.CommunicationEfficacy)), Data.Max(x => double.Parse(x.CommunicationEfficacy)));
                //sw.WriteSepLine("\t", "OcScore1", Data.Min(x => int.Parse(x.OcScore1)), Data.Max(x => int.Parse(x.OcScore1)));
                //sw.WriteSepLine("\t", "OcScore2", Data.Min(x => int.Parse(x.OcScore2)), Data.Max(x => int.Parse(x.OcScore2)));
                //sw.WriteSepLine("\t", "Age", Data.Min(x => int.Parse(x.Age)), Data.Max(x => int.Parse(x.Age)));
                //sw.WriteSepLine("\t", "Scheuner1", Data.Min(x => int.Parse(x.Scheuner1)), Data.Max(x => int.Parse(x.Scheuner1)));
                //sw.WriteSepLine("\t", "Scheuner2", Data.Min(x => int.Parse(x.Scheuner2)), Data.Max(x => int.Parse(x.Scheuner2)));
                //sw.WriteSepLine("\t", "Scheuner3", Data.Min(x => int.Parse(x.Scheuner3)), Data.Max(x => int.Parse(x.Scheuner3)));
                //sw.WriteSepLine("\t", "Scheuner4", Data.Min(x => int.Parse(x.Scheuner4)), Data.Max(x => int.Parse(x.Scheuner4)));
                //sw.WriteSepLine("\t", "Scheuner5", Data.Min(x => int.Parse(x.Scheuner5)), Data.Max(x => int.Parse(x.Scheuner5)));
                //sw.WriteSepLine("\t", "Scheuner6", Data.Min(x => int.Parse(x.Scheuner6)), Data.Max(x => int.Parse(x.Scheuner6)));
                //sw.WriteSepLine("\t", "Scheuner7", Data.Min(x => int.Parse(x.Scheuner7)), Data.Max(x => int.Parse(x.Scheuner7)));
                //sw.WriteSepLine("\t", "Scheuner8", Data.Min(x => int.Parse(x.Scheuner8)), Data.Max(x => int.Parse(x.Scheuner8)));
                //sw.WriteSepLine("\t", "Scheuner9", Data.Min(x => int.Parse(x.Scheuner9)), Data.Max(x => int.Parse(x.Scheuner9)));
                //sw.WriteSepLine("\t", "Scheuner10", Data.Min(x => int.Parse(x.Scheuner10)), Data.Max(x => int.Parse(x.Scheuner10)));
                //sw.WriteSepLine("\t", "Scheuner11", Data.Min(x => int.Parse(x.Scheuner11)), Data.Max(x => int.Parse(x.Scheuner11)));
                //sw.WriteSepLine("\t", "Scheuner12", Data.Min(x => int.Parse(x.Scheuner12)), Data.Max(x => int.Parse(x.Scheuner12)));
                //sw.WriteSepLine("\t", "Scheuner13", Data.Min(x => int.Parse(x.Scheuner13)), Data.Max(x => int.Parse(x.Scheuner13)));
                //sw.WriteSepLine("\t", "Scheuner14Value", Data.Min(x => int.Parse(x.Scheuner14Value)), Data.Max(x => int.Parse(x.Scheuner14Value)));
                //sw.WriteSepLine("\t", "Scheuner15Value", Data.Min(x => int.Parse(x.Scheuner15Value)), Data.Max(x => int.Parse(x.Scheuner15Value)));
                //sw.WriteSepLine("\t", "Scheuner16Value", Data.Min(x => int.Parse(x.Scheuner16Value)), Data.Max(x => int.Parse(x.Scheuner16Value)));
                //sw.WriteSepLine("\t", "Scheuner17Value", Data.Min(x => int.Parse(x.Scheuner17Value)), Data.Max(x => int.Parse(x.Scheuner17Value)));
                //sw.WriteSepLine("\t", "Scheuner18Value", Data.Min(x => int.Parse(x.Scheuner18Value)), Data.Max(x => int.Parse(x.Scheuner18Value)));

                //for (int i = 0; i < Data.Count; i++)
                //{
                //    var row = Data[i];
                //    var props = DictionaryFromType(Data[i]);
                //}

            } // end sanitycheck file
            
        }

        private void PrintIntegerVariableReport(StreamWriter sw, List<Result5Row> data, string variableName, QualtricsMapping qm)
        {
            List<int> results = new List<int>();

            foreach (Result5Row row in data)
            {
                string val = (string)typeof(Result5Row).GetField(variableName).GetValue(row);
                if (val != "") results.Add(int.Parse(val));
            }
            
        }
    }
}
