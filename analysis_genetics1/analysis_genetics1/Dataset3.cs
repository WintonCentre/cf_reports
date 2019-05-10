using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analysis_genetics1
{
    class Dataset3
    {
        public List<Result3Row> Data = new List<Result3Row>();
        public List<string> Lines = new List<string>();
        public string Header = "";

        public Dataset3()
        {

        }

        public Dataset3(string infile)
        {
            using (StreamReader sr = new StreamReader(Globals.DataPath + infile))
            {
                Header = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "") continue;

                    Lines.Add(line);
                    Result3Row row = new Result3Row('\t', line);
                    Data.Add(row);
                }
            }
        }

    }
}
