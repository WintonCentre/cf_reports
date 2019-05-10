using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analysis_genetics1
{
    class Result3Row
    {
        public string ProlificId { get; set; }
        public string TestResult { get; set; }
        public string StatusLaxAnswerKey { get; set; }
        public string OcStatusProb { get; set; }
        public string StatusIsNearlyCorrect { get; set; }
        public string ChildLaxAnswerKey { get; set; }
        public string OcChildProb { get; set; }
        public string ChildIsNearlyCorrect { get; set; }
        public string Hard1000LaxAnswerKey { get; set; }
        public string Objcomp1000Hard { get; set; }
        public string Hard1000IsNearlyCorrect { get; set; }
        public string Hard800LaxAnswerKey { get; set; }
        public string Objcomp800Hard { get; set; }
        public string Hard800IsNearlyCorrect { get; set; }


        public Result3Row(char delimiter, string line)
        {
            string[] toks = line.Split(delimiter);
            this.ProlificId = toks[0];
            this.TestResult = toks[1];
            this.StatusLaxAnswerKey = toks[2];
            this.OcStatusProb = toks[3];
            this.StatusIsNearlyCorrect = toks[4];
            this.ChildLaxAnswerKey = toks[5];
            this.OcChildProb = toks[6];
            this.ChildIsNearlyCorrect = toks[7];
            this.Hard1000LaxAnswerKey = toks[8];
            this.Objcomp1000Hard = toks[9];
            this.Hard1000IsNearlyCorrect = toks[10];
            this.Hard800LaxAnswerKey = toks[11];
            this.Objcomp800Hard = toks[12];
            this.Hard800IsNearlyCorrect = toks[13];
        }

        public string ToString(string delimiter)
        {
            return ProlificId.ToString() + delimiter + TestResult.ToString() + delimiter + StatusLaxAnswerKey.ToString() + delimiter + OcStatusProb.ToString() + delimiter + StatusIsNearlyCorrect.ToString() + delimiter + ChildLaxAnswerKey.ToString() + delimiter + OcChildProb.ToString() + delimiter + ChildIsNearlyCorrect.ToString() + delimiter + Hard1000LaxAnswerKey.ToString() + delimiter + Objcomp1000Hard.ToString() + delimiter + Hard1000IsNearlyCorrect.ToString() + delimiter + Hard800LaxAnswerKey.ToString() + delimiter + Objcomp800Hard.ToString() + delimiter + Hard800IsNearlyCorrect.ToString();
        }

        public const string UniqueColumnsHeader = "status-is-nearly-correct\tchild-is-nearly-correct\thard1000-is-nearly-correct\thard800-is-nearly-correct";
        public string ToUniqueColumnsString(string delimiter)
        {
            return StatusIsNearlyCorrect.ToString() + delimiter + ChildIsNearlyCorrect.ToString() + delimiter + Hard1000IsNearlyCorrect.ToString() + delimiter + Hard800IsNearlyCorrect.ToString();
        }

    }
}
