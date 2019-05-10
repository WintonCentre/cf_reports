using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using analysis_genetics1;

namespace analysis_genetics1
{
    class Dataset1
    {
        public List<Result1Row> Data = new List<Result1Row>();
        public List<string> Lines = new List<string>();
        public string Header = "";

        public Dataset1()
        {

        }

        public Dataset1(string infile)
        {
            infile = Globals.DataPath + infile;

            using (StreamReader sr = new StreamReader(infile))
            {
                Header = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "") continue;

                    Lines.Add(line);
                    Result1Row row = new Result1Row('\t', line);
                    Data.Add(row);
                }
            }
        }


        /// <summary>
        /// Create a tsv file (which we will manually copy-paste into an xlsx file) so that correct/incorrect
        /// assessments of the free-text responses to the objective comprehension questions can be coded blindly.
        /// </summary>
        public void WriteDataset2ForCoding(string outfile)
        {
            var designType = (new AnswerKey.Design()).GetType();
            var testResultType = (new AnswerKey.TestResult()).GetType();
            var answerKey = new AnswerKey();


            using (StreamWriter sw = new StreamWriter(Globals.DataPath + outfile))
            {
                sw.WriteSepLine("\t", "prolific-id", "TestResult", 
                    "StatusStrictAnswerKey", "oc-status-prob", "status-is-exactly-correct",
                    "ChildStrictAnswerKey", "oc-child-prob", "child-is-exactly-correct",
                    "Hard1000StrictAnswerKey", "objcomp-1000-hard", "hard1000-is-exactly-correct",
                    "Hard800StrictAnswerKey", "objcomp-800-hard", "hard800-is-exactly-correct",
                    "StatusLaxAnswerKey", "oc-status-prob", "status-is-nearly-correct",
                    "ChildLaxAnswerKey", "oc-child-prob", "child-is-nearly-correct",
                    "Hard1000LaxAnswerKey", "objcomp-1000-hard", "hard1000-is-nearly-correct",
                    "Hard800LaxAnswerKey", "objcomp-800-hard", "hard800-is-nearly-correct");

                HashSet<string> prolificIdSanityCheck = new HashSet<string>();

                foreach (var row in Data)
                {
                    if (prolificIdSanityCheck.Contains(row.ProlificId)) throw new Exception("The same prolific id appears twice: " + row.ProlificId);
                    prolificIdSanityCheck.Add(row.ProlificId);

                    AnswerKey.Design design = (AnswerKey.Design)Enum.Parse(designType, row.Design);
                    AnswerKey.TestResult testResult = (AnswerKey.TestResult)Enum.Parse(testResultType, row.TestResult);

                    sw.WriteSepLine("\t",
                        row.ProlificId,
                        row.TestResult,
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Strict, design, testResult, AnswerKey.Question.Status),
                        row.OcStatusProb,
                        "",
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Strict, design, testResult, AnswerKey.Question.Child),
                        row.OcChildProb,
                        "",
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Strict, design, testResult, AnswerKey.Question.Hard1000),
                        row.Objcomp1000Hard,
                        "",
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Strict, design, testResult, AnswerKey.Question.Hard800),
                        row.Objcomp800Hard,
                        "",
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Lax, design, testResult, AnswerKey.Question.Status),
                        row.OcStatusProb,
                        "",
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Lax, design, testResult, AnswerKey.Question.Child),
                        row.OcChildProb,
                        "",
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Lax, design, testResult, AnswerKey.Question.Hard1000),
                        row.Objcomp1000Hard,
                        "",
                        answerKey.GetCorrectAnswer(AnswerKey.Stringency.Lax, design, testResult, AnswerKey.Question.Hard800),
                        row.Objcomp800Hard,
                        ""
                        );
                }
            }
        }

    }


}
