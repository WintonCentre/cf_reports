using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analysis_genetics1
{
    class AnswerKey
    {
        // Correct answers for each combination of:
        // - stringency (strict or lax correctness criterion)
        // - design (control report or our user-centred design (UCD) report)
        // - test result (positive or negative)
        // - comprehension question requiring a typed answer:
        //    status ("the probability that John is a carrier of cystic fibrosis")
        //    child ("the probability that the child will have cystic fibrosis")
        //    hard1000 ("Imagine that there are 1000 couples... about how many of these children would have cystic fibrosis?")
        //    hard800 ("Imagine that there are 800 couples... about how many of these children would have cystic fibrosis?")

        internal enum Stringency { Strict, Lax }
        internal enum Design { Control, UCD }
        internal enum TestResult { Positive, Negative }
        internal enum Question { Status, Child, Hard1000, Hard800 }

        Dictionary<ParameterSet, string> correctAnswers = new Dictionary<ParameterSet, string>();

        class ParameterSet
        {
            internal Stringency stringency;
            internal Design design;
            internal TestResult testResult;
            internal Question question;

            public ParameterSet(Stringency stringency, Design design, TestResult testResult, Question question)
            {
                this.stringency = stringency;
                this.design = design;
                this.testResult = testResult;
                this.question = question;
            }

            // override object.Equals
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                ParameterSet other = (ParameterSet)obj;
                return (other.stringency == stringency &&
                    other.design == design &&
                    other.testResult == testResult &&
                    other.question == question) ;
            }

            // override object.GetHashCode
            public override int GetHashCode()
            {
                return (stringency.ToString() + design.ToString() + testResult.ToString() + question.ToString()).GetHashCode();
            }
        }
        

        public AnswerKey()
        {
            var stringencyType = (new Stringency()).GetType();
            var designType = (new Design()).GetType();
            var testResultType = (new TestResult()).GetType();
            var questionType = (new Question()).GetType();

            using (StreamReader sr = new StreamReader(Globals.DataPath + "AnswerKey.tsv.txt"))
            {
                string header = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();
                    if (line == "") continue;
                    string[] tokens = line.Split('\t');

                    ParameterSet pset = new ParameterSet(
                        (Stringency)Enum.Parse(stringencyType, tokens[3]),
                        (Design)Enum.Parse(designType, tokens[2]),
                        (TestResult)Enum.Parse(testResultType, tokens[1]),
                        (Question)Enum.Parse(questionType, tokens[0]));

                    correctAnswers.Add(pset, tokens[4]);
                }
            }
        }

        internal string GetCorrectAnswer(Stringency stringency, Design design, TestResult testResult, Question question)
        {
            ParameterSet pset = new ParameterSet(stringency, design, testResult, question);
            return correctAnswers[pset];
        }
    }
}
