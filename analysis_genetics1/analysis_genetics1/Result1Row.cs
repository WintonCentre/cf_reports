using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analysis_genetics1
{
    class Result1Row
    {
        enum Columns { StartDate, EndDate, Status, Progress, Duration, Finished, RecordedDate, ResponseId, DistributionChannel, UserLanguage, TimePISFirstClick, TimePISLastClick, TimePISPageSubmit, TimePISClickCount, TimeConsentFirstClick, TimeConsentLastClick, TimeConsentPageSubmit, TimeConsentClickCount, Consent, ConsentMistake, Q177FirstClick, Q177LastClick, Q177PageSubmit, Q177ClickCount, ProlificId, TimeContext1FirstClick, TimeContext1LastClick, TimeContext1PageSubmit, TimeContext1ClickCount, TimeContext2FirstClick, TimeContext2LastClick, TimeContext2PageSubmit, TimeContext2ClickCount, TimeContext3FirstClick, TimeContext3LastClick, TimeContext3PageSubmit, TimeContext3ClickCount, TimeControlReportFirstClick, TimeControlReportLastClick, TimeControlReportPageSubmit, TimeControlReportClickCount, TimeUcdReportP1FirstClick, TimeUcdReportP1LastClick, TimeUcdReportP1PageSubmit, TimeUcdReportP1ClickCount, TimeUcdReportP2FirstClick, TimeUcdReportP2LastClick, TimeUcdReportP2PageSubmit, TimeUcdReportP2ClickCount, TimeS1FirstClick, TimeS1LastClick, TimeS1PageSubmit, TimeS1ClickCount, SubjUnderstanding, SubjClarity, SubjTrusted, TimeS2FirstClick, TimeS2LastClick, TimeS2PageSubmit, TimeS2ClickCount, SubjNext1, SubjNext3, SubjNext2, SubjNext4, SubjNext5, TimeOcStatusFirstClick, TimeOcStatusLastClick, TimeOcStatusPageSubmit, TimeOcStatusClickCount, OcStatusVerbal, OcStatusProb, OcStatusSlider1, TimeOcChildFirstClick, TimeOcChildLastClick, TimeOcChildPageSubmit, TimeOcChildClickCount, OcChildVerbal, OcChildProb, OcChildSlider1, TimeOcCompareFirstClick, TimeOcCompareLastClick, TimeOcComparePageSubmit, TimeOcCompareClickCount, ObjcompCompare, TimeOcHardFirstClick, TimeOcHardLastClick, TimeOcHardPageSubmit, TimeOcHardClickCount, Objcomp1000Hard, Objcomp800Hard, TimeSch1FirstClick, TimeSch1LastClick, TimeSch1PageSubmit, TimeSch1ClickCount, Scheuner1, Scheuner2, Scheuner3, TimeSch2FirstClick, TimeSch2LastClick, TimeSch2PageSubmit, TimeSch2ClickCount, Scheuner4, Scheuner5, Scheuner6, Scheuner7, Scheuner8, TimeSch3FirstClick, TimeSch3LastClick, TimeSch3PageSubmit, TimeSch3ClickCount, Scheuner9, Scheuner10, Scheuner11, Scheuner12, Scheuner13, TimeSch4FirstClick, TimeSch4LastClick, TimeSch4PageSubmit, TimeSch4ClickCount, Scheuner14, Scheuner15, Scheuner16, Scheuner17, Scheuner18, TimeLimitationsFirstClick, TimeLimitationsLastClick, TimeLimitationsPageSubmit, TimeLimitationsClickCount, Limitations, TimeNoticedFirstClick, TimeNoticedLastClick, TimeNoticedPageSubmit, TimeNoticedClickCount, ResultNoticed, ResultUnderstood, TimeSnumeracyFirstClick, TimeSnumeracyLastClick, TimeSnumeracyPageSubmit, TimeSnumeracyClickCount, SNumeracy1, SNumeracy2, SNumeracy3, SNumeracy4, SNumeracy5, SNumeracy6, SNumeracy7, SNumeracy8, TimePriorexp1FirstClick, TimePriorexp1LastClick, TimePriorexp1PageSubmit, TimePriorexp1ClickCount, CFExperience, CFExperienceDetail, TimePriorexp2FirstClick, TimePriorexp2LastClick, TimePriorexp2PageSubmit, TimePriorexp2ClickCount, TimeDemo1FirstClick, TimeDemo1LastClick, TimeDemo1PageSubmit, TimeDemo1ClickCount, Age, Gender, GenderOther, CombinedIncome, AdultsInHouse, ChildrenInHouse, Education, TimeDemo2FirstClick, TimeDemo2LastClick, TimeDemo2PageSubmit, TimeDemo2ClickCount, Comments, Design, TestResult, OCStatusAbsoluteTime, OCChildAbsoluteTime, OCCompareAbsoluteTime }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }
        public string Duration { get; set; }
        public string Finished { get; set; }
        public string RecordedDate { get; set; }
        public string ResponseId { get; set; }
        public string DistributionChannel { get; set; }
        public string UserLanguage { get; set; }
        public string TimePISFirstClick { get; set; }
        public string TimePISLastClick { get; set; }
        public string TimePISPageSubmit { get; set; }
        public string TimePISClickCount { get; set; }
        public string TimeConsentFirstClick { get; set; }
        public string TimeConsentLastClick { get; set; }
        public string TimeConsentPageSubmit { get; set; }
        public string TimeConsentClickCount { get; set; }
        public string Consent { get; set; }
        public string ConsentMistake { get; set; }
        public string Q177FirstClick { get; set; }
        public string Q177LastClick { get; set; }
        public string Q177PageSubmit { get; set; }
        public string Q177ClickCount { get; set; }
        public string ProlificId { get; set; }
        public string TimeContext1FirstClick { get; set; }
        public string TimeContext1LastClick { get; set; }
        public string TimeContext1PageSubmit { get; set; }
        public string TimeContext1ClickCount { get; set; }
        public string TimeContext2FirstClick { get; set; }
        public string TimeContext2LastClick { get; set; }
        public string TimeContext2PageSubmit { get; set; }
        public string TimeContext2ClickCount { get; set; }
        public string TimeContext3FirstClick { get; set; }
        public string TimeContext3LastClick { get; set; }
        public string TimeContext3PageSubmit { get; set; }
        public string TimeContext3ClickCount { get; set; }
        public string TimeControlReportFirstClick { get; set; }
        public string TimeControlReportLastClick { get; set; }
        public string TimeControlReportPageSubmit { get; set; }
        public string TimeControlReportClickCount { get; set; }
        public string TimeUcdReportP1FirstClick { get; set; }
        public string TimeUcdReportP1LastClick { get; set; }
        public string TimeUcdReportP1PageSubmit { get; set; }
        public string TimeUcdReportP1ClickCount { get; set; }
        public string TimeUcdReportP2FirstClick { get; set; }
        public string TimeUcdReportP2LastClick { get; set; }
        public string TimeUcdReportP2PageSubmit { get; set; }
        public string TimeUcdReportP2ClickCount { get; set; }
        public string TimeS1FirstClick { get; set; }
        public string TimeS1LastClick { get; set; }
        public string TimeS1PageSubmit { get; set; }
        public string TimeS1ClickCount { get; set; }
        public string SubjUnderstanding { get; set; }
        public string SubjClarity { get; set; }
        public string SubjTrusted { get; set; }
        public string TimeS2FirstClick { get; set; }
        public string TimeS2LastClick { get; set; }
        public string TimeS2PageSubmit { get; set; }
        public string TimeS2ClickCount { get; set; }
        public string SubjNext1 { get; set; }
        public string SubjNext3 { get; set; }
        public string SubjNext2 { get; set; }
        public string SubjNext4 { get; set; }
        public string SubjNext5 { get; set; }
        public string TimeOcStatusFirstClick { get; set; }
        public string TimeOcStatusLastClick { get; set; }
        public string TimeOcStatusPageSubmit { get; set; }
        public string TimeOcStatusClickCount { get; set; }
        public string OcStatusVerbal { get; set; }
        public string OcStatusProb { get; set; }
        public string OcStatusSlider1 { get; set; }
        public string TimeOcChildFirstClick { get; set; }
        public string TimeOcChildLastClick { get; set; }
        public string TimeOcChildPageSubmit { get; set; }
        public string TimeOcChildClickCount { get; set; }
        public string OcChildVerbal { get; set; }
        public string OcChildProb { get; set; }
        public string OcChildSlider1 { get; set; }
        public string TimeOcCompareFirstClick { get; set; }
        public string TimeOcCompareLastClick { get; set; }
        public string TimeOcComparePageSubmit { get; set; }
        public string TimeOcCompareClickCount { get; set; }
        public string ObjcompCompare { get; set; }
        public string TimeOcHardFirstClick { get; set; }
        public string TimeOcHardLastClick { get; set; }
        public string TimeOcHardPageSubmit { get; set; }
        public string TimeOcHardClickCount { get; set; }
        public string Objcomp1000Hard { get; set; }
        public string Objcomp800Hard { get; set; }
        public string TimeSch1FirstClick { get; set; }
        public string TimeSch1LastClick { get; set; }
        public string TimeSch1PageSubmit { get; set; }
        public string TimeSch1ClickCount { get; set; }
        public string Scheuner1 { get; set; }
        public string Scheuner2 { get; set; }
        public string Scheuner3 { get; set; }
        public string TimeSch2FirstClick { get; set; }
        public string TimeSch2LastClick { get; set; }
        public string TimeSch2PageSubmit { get; set; }
        public string TimeSch2ClickCount { get; set; }
        public string Scheuner4 { get; set; }
        public string Scheuner5 { get; set; }
        public string Scheuner6 { get; set; }
        public string Scheuner7 { get; set; }
        public string Scheuner8 { get; set; }
        public string TimeSch3FirstClick { get; set; }
        public string TimeSch3LastClick { get; set; }
        public string TimeSch3PageSubmit { get; set; }
        public string TimeSch3ClickCount { get; set; }
        public string Scheuner9 { get; set; }
        public string Scheuner10 { get; set; }
        public string Scheuner11 { get; set; }
        public string Scheuner12 { get; set; }
        public string Scheuner13 { get; set; }
        public string TimeSch4FirstClick { get; set; }
        public string TimeSch4LastClick { get; set; }
        public string TimeSch4PageSubmit { get; set; }
        public string TimeSch4ClickCount { get; set; }
        public string Scheuner14 { get; set; }
        public string Scheuner15 { get; set; }
        public string Scheuner16 { get; set; }
        public string Scheuner17 { get; set; }
        public string Scheuner18 { get; set; }
        public string TimeLimitationsFirstClick { get; set; }
        public string TimeLimitationsLastClick { get; set; }
        public string TimeLimitationsPageSubmit { get; set; }
        public string TimeLimitationsClickCount { get; set; }
        public string Limitations { get; set; }
        public string TimeNoticedFirstClick { get; set; }
        public string TimeNoticedLastClick { get; set; }
        public string TimeNoticedPageSubmit { get; set; }
        public string TimeNoticedClickCount { get; set; }
        public string ResultNoticed { get; set; }
        public string ResultUnderstood { get; set; }
        public string TimeSnumeracyFirstClick { get; set; }
        public string TimeSnumeracyLastClick { get; set; }
        public string TimeSnumeracyPageSubmit { get; set; }
        public string TimeSnumeracyClickCount { get; set; }
        public string SNumeracy1 { get; set; }
        public string SNumeracy2 { get; set; }
        public string SNumeracy3 { get; set; }
        public string SNumeracy4 { get; set; }
        public string SNumeracy5 { get; set; }
        public string SNumeracy6 { get; set; }
        public string SNumeracy7 { get; set; }
        public string SNumeracy8 { get; set; }
        public string TimePriorexp1FirstClick { get; set; }
        public string TimePriorexp1LastClick { get; set; }
        public string TimePriorexp1PageSubmit { get; set; }
        public string TimePriorexp1ClickCount { get; set; }
        public string CFExperience { get; set; }
        public string CFExperienceDetail { get; set; }
        public string TimePriorexp2FirstClick { get; set; }
        public string TimePriorexp2LastClick { get; set; }
        public string TimePriorexp2PageSubmit { get; set; }
        public string TimePriorexp2ClickCount { get; set; }
        public string TimeDemo1FirstClick { get; set; }
        public string TimeDemo1LastClick { get; set; }
        public string TimeDemo1PageSubmit { get; set; }
        public string TimeDemo1ClickCount { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string GenderOther { get; set; }
        public string CombinedIncome { get; set; }
        public string AdultsInHouse { get; set; }
        public string ChildrenInHouse { get; set; }
        public string Education { get; set; }
        public string TimeDemo2FirstClick { get; set; }
        public string TimeDemo2LastClick { get; set; }
        public string TimeDemo2PageSubmit { get; set; }
        public string TimeDemo2ClickCount { get; set; }
        public string Comments { get; set; }
        public string Design { get; set; }
        public string TestResult { get; set; }
        public string OCStatusAbsoluteTime { get; set; }
        public string OCChildAbsoluteTime { get; set; }
        public string OCCompareAbsoluteTime { get; set; }


        public Result1Row(char delimiter, string line)
        {
            string[] toks = line.Split(delimiter);
            this.StartDate = toks[0];
            this.EndDate = toks[1];
            this.Status = toks[2];
            this.Progress = toks[3];
            this.Duration = toks[4];
            this.Finished = toks[5];
            this.RecordedDate = toks[6];
            this.ResponseId = toks[7];
            this.DistributionChannel = toks[8];
            this.UserLanguage = toks[9];
            this.TimePISFirstClick = toks[10];
            this.TimePISLastClick = toks[11];
            this.TimePISPageSubmit = toks[12];
            this.TimePISClickCount = toks[13];
            this.TimeConsentFirstClick = toks[14];
            this.TimeConsentLastClick = toks[15];
            this.TimeConsentPageSubmit = toks[16];
            this.TimeConsentClickCount = toks[17];
            this.Consent = toks[18];
            this.ConsentMistake = toks[19];
            this.Q177FirstClick = toks[20];
            this.Q177LastClick = toks[21];
            this.Q177PageSubmit = toks[22];
            this.Q177ClickCount = toks[23];
            this.ProlificId = toks[24];
            this.TimeContext1FirstClick = toks[25];
            this.TimeContext1LastClick = toks[26];
            this.TimeContext1PageSubmit = toks[27];
            this.TimeContext1ClickCount = toks[28];
            this.TimeContext2FirstClick = toks[29];
            this.TimeContext2LastClick = toks[30];
            this.TimeContext2PageSubmit = toks[31];
            this.TimeContext2ClickCount = toks[32];
            this.TimeContext3FirstClick = toks[33];
            this.TimeContext3LastClick = toks[34];
            this.TimeContext3PageSubmit = toks[35];
            this.TimeContext3ClickCount = toks[36];
            this.TimeControlReportFirstClick = toks[37];
            this.TimeControlReportLastClick = toks[38];
            this.TimeControlReportPageSubmit = toks[39];
            this.TimeControlReportClickCount = toks[40];
            this.TimeUcdReportP1FirstClick = toks[41];
            this.TimeUcdReportP1LastClick = toks[42];
            this.TimeUcdReportP1PageSubmit = toks[43];
            this.TimeUcdReportP1ClickCount = toks[44];
            this.TimeUcdReportP2FirstClick = toks[45];
            this.TimeUcdReportP2LastClick = toks[46];
            this.TimeUcdReportP2PageSubmit = toks[47];
            this.TimeUcdReportP2ClickCount = toks[48];
            this.TimeS1FirstClick = toks[49];
            this.TimeS1LastClick = toks[50];
            this.TimeS1PageSubmit = toks[51];
            this.TimeS1ClickCount = toks[52];
            this.SubjUnderstanding = toks[53];
            this.SubjClarity = toks[54];
            this.SubjTrusted = toks[55];
            this.TimeS2FirstClick = toks[56];
            this.TimeS2LastClick = toks[57];
            this.TimeS2PageSubmit = toks[58];
            this.TimeS2ClickCount = toks[59];
            this.SubjNext1 = toks[60];
            this.SubjNext3 = toks[61];
            this.SubjNext2 = toks[62];
            this.SubjNext4 = toks[63];
            this.SubjNext5 = toks[64];
            this.TimeOcStatusFirstClick = toks[65];
            this.TimeOcStatusLastClick = toks[66];
            this.TimeOcStatusPageSubmit = toks[67];
            this.TimeOcStatusClickCount = toks[68];
            this.OcStatusVerbal = toks[69];
            this.OcStatusProb = toks[70];
            this.OcStatusSlider1 = toks[71];
            this.TimeOcChildFirstClick = toks[72];
            this.TimeOcChildLastClick = toks[73];
            this.TimeOcChildPageSubmit = toks[74];
            this.TimeOcChildClickCount = toks[75];
            this.OcChildVerbal = toks[76];
            this.OcChildProb = toks[77];
            this.OcChildSlider1 = toks[78];
            this.TimeOcCompareFirstClick = toks[79];
            this.TimeOcCompareLastClick = toks[80];
            this.TimeOcComparePageSubmit = toks[81];
            this.TimeOcCompareClickCount = toks[82];
            this.ObjcompCompare = toks[83];
            this.TimeOcHardFirstClick = toks[84];
            this.TimeOcHardLastClick = toks[85];
            this.TimeOcHardPageSubmit = toks[86];
            this.TimeOcHardClickCount = toks[87];
            this.Objcomp1000Hard = toks[88];
            this.Objcomp800Hard = toks[89];
            this.TimeSch1FirstClick = toks[90];
            this.TimeSch1LastClick = toks[91];
            this.TimeSch1PageSubmit = toks[92];
            this.TimeSch1ClickCount = toks[93];
            this.Scheuner1 = toks[94];
            this.Scheuner2 = toks[95];
            this.Scheuner3 = toks[96];
            this.TimeSch2FirstClick = toks[97];
            this.TimeSch2LastClick = toks[98];
            this.TimeSch2PageSubmit = toks[99];
            this.TimeSch2ClickCount = toks[100];
            this.Scheuner4 = toks[101];
            this.Scheuner5 = toks[102];
            this.Scheuner6 = toks[103];
            this.Scheuner7 = toks[104];
            this.Scheuner8 = toks[105];
            this.TimeSch3FirstClick = toks[106];
            this.TimeSch3LastClick = toks[107];
            this.TimeSch3PageSubmit = toks[108];
            this.TimeSch3ClickCount = toks[109];
            this.Scheuner9 = toks[110];
            this.Scheuner10 = toks[111];
            this.Scheuner11 = toks[112];
            this.Scheuner12 = toks[113];
            this.Scheuner13 = toks[114];
            this.TimeSch4FirstClick = toks[115];
            this.TimeSch4LastClick = toks[116];
            this.TimeSch4PageSubmit = toks[117];
            this.TimeSch4ClickCount = toks[118];
            this.Scheuner14 = toks[119];
            this.Scheuner15 = toks[120];
            this.Scheuner16 = toks[121];
            this.Scheuner17 = toks[122];
            this.Scheuner18 = toks[123];
            this.TimeLimitationsFirstClick = toks[124];
            this.TimeLimitationsLastClick = toks[125];
            this.TimeLimitationsPageSubmit = toks[126];
            this.TimeLimitationsClickCount = toks[127];
            this.Limitations = toks[128];
            this.TimeNoticedFirstClick = toks[129];
            this.TimeNoticedLastClick = toks[130];
            this.TimeNoticedPageSubmit = toks[131];
            this.TimeNoticedClickCount = toks[132];
            this.ResultNoticed = toks[133];
            this.ResultUnderstood = toks[134];
            this.TimeSnumeracyFirstClick = toks[135];
            this.TimeSnumeracyLastClick = toks[136];
            this.TimeSnumeracyPageSubmit = toks[137];
            this.TimeSnumeracyClickCount = toks[138];
            this.SNumeracy1 = toks[139];
            this.SNumeracy2 = toks[140];
            this.SNumeracy3 = toks[141];
            this.SNumeracy4 = toks[142];
            this.SNumeracy5 = toks[143];
            this.SNumeracy6 = toks[144];
            this.SNumeracy7 = toks[145];
            this.SNumeracy8 = toks[146];
            this.TimePriorexp1FirstClick = toks[147];
            this.TimePriorexp1LastClick = toks[148];
            this.TimePriorexp1PageSubmit = toks[149];
            this.TimePriorexp1ClickCount = toks[150];
            this.CFExperience = toks[151];
            this.CFExperienceDetail = toks[152];
            this.TimePriorexp2FirstClick = toks[153];
            this.TimePriorexp2LastClick = toks[154];
            this.TimePriorexp2PageSubmit = toks[155];
            this.TimePriorexp2ClickCount = toks[156];
            this.TimeDemo1FirstClick = toks[157];
            this.TimeDemo1LastClick = toks[158];
            this.TimeDemo1PageSubmit = toks[159];
            this.TimeDemo1ClickCount = toks[160];
            this.Age = toks[161];
            this.Gender = toks[162];
            this.GenderOther = toks[163];
            this.CombinedIncome = toks[164];
            this.AdultsInHouse = toks[165];
            this.ChildrenInHouse = toks[166];
            this.Education = toks[167];
            this.TimeDemo2FirstClick = toks[168];
            this.TimeDemo2LastClick = toks[169];
            this.TimeDemo2PageSubmit = toks[170];
            this.TimeDemo2ClickCount = toks[171];
            this.Comments = toks[172];
            this.Design = toks[173];
            this.TestResult = toks[174];
            this.OCStatusAbsoluteTime = toks[175];
            this.OCChildAbsoluteTime = toks[176];
            this.OCCompareAbsoluteTime = toks[177];
        }

        public string ToString(string delimiter)
        {
            return StartDate.ToString() + delimiter + EndDate.ToString() + delimiter + Status.ToString() + delimiter + Progress.ToString() + delimiter + Duration.ToString() + delimiter + Finished.ToString() + delimiter + RecordedDate.ToString() + delimiter + ResponseId.ToString() + delimiter + DistributionChannel.ToString() + delimiter + UserLanguage.ToString() + delimiter + TimePISFirstClick.ToString() + delimiter + TimePISLastClick.ToString() + delimiter + TimePISPageSubmit.ToString() + delimiter + TimePISClickCount.ToString() + delimiter + TimeConsentFirstClick.ToString() + delimiter + TimeConsentLastClick.ToString() + delimiter + TimeConsentPageSubmit.ToString() + delimiter + TimeConsentClickCount.ToString() + delimiter + Consent.ToString() + delimiter + ConsentMistake.ToString() + delimiter + Q177FirstClick.ToString() + delimiter + Q177LastClick.ToString() + delimiter + Q177PageSubmit.ToString() + delimiter + Q177ClickCount.ToString() + delimiter + ProlificId.ToString() + delimiter + TimeContext1FirstClick.ToString() + delimiter + TimeContext1LastClick.ToString() + delimiter + TimeContext1PageSubmit.ToString() + delimiter + TimeContext1ClickCount.ToString() + delimiter + TimeContext2FirstClick.ToString() + delimiter + TimeContext2LastClick.ToString() + delimiter + TimeContext2PageSubmit.ToString() + delimiter + TimeContext2ClickCount.ToString() + delimiter + TimeContext3FirstClick.ToString() + delimiter + TimeContext3LastClick.ToString() + delimiter + TimeContext3PageSubmit.ToString() + delimiter + TimeContext3ClickCount.ToString() + delimiter + TimeControlReportFirstClick.ToString() + delimiter + TimeControlReportLastClick.ToString() + delimiter + TimeControlReportPageSubmit.ToString() + delimiter + TimeControlReportClickCount.ToString() + delimiter + TimeUcdReportP1FirstClick.ToString() + delimiter + TimeUcdReportP1LastClick.ToString() + delimiter + TimeUcdReportP1PageSubmit.ToString() + delimiter + TimeUcdReportP1ClickCount.ToString() + delimiter + TimeUcdReportP2FirstClick.ToString() + delimiter + TimeUcdReportP2LastClick.ToString() + delimiter + TimeUcdReportP2PageSubmit.ToString() + delimiter + TimeUcdReportP2ClickCount.ToString() + delimiter + TimeS1FirstClick.ToString() + delimiter + TimeS1LastClick.ToString() + delimiter + TimeS1PageSubmit.ToString() + delimiter + TimeS1ClickCount.ToString() + delimiter + SubjUnderstanding.ToString() + delimiter + SubjClarity.ToString() + delimiter + SubjTrusted.ToString() + delimiter + TimeS2FirstClick.ToString() + delimiter + TimeS2LastClick.ToString() + delimiter + TimeS2PageSubmit.ToString() + delimiter + TimeS2ClickCount.ToString() + delimiter + SubjNext1.ToString() + delimiter + SubjNext3.ToString() + delimiter + SubjNext2.ToString() + delimiter + SubjNext4.ToString() + delimiter + SubjNext5.ToString() + delimiter + TimeOcStatusFirstClick.ToString() + delimiter + TimeOcStatusLastClick.ToString() + delimiter + TimeOcStatusPageSubmit.ToString() + delimiter + TimeOcStatusClickCount.ToString() + delimiter + OcStatusVerbal.ToString() + delimiter + OcStatusProb.ToString() + delimiter + OcStatusSlider1.ToString() + delimiter + TimeOcChildFirstClick.ToString() + delimiter + TimeOcChildLastClick.ToString() + delimiter + TimeOcChildPageSubmit.ToString() + delimiter + TimeOcChildClickCount.ToString() + delimiter + OcChildVerbal.ToString() + delimiter + OcChildProb.ToString() + delimiter + OcChildSlider1.ToString() + delimiter + TimeOcCompareFirstClick.ToString() + delimiter + TimeOcCompareLastClick.ToString() + delimiter + TimeOcComparePageSubmit.ToString() + delimiter + TimeOcCompareClickCount.ToString() + delimiter + ObjcompCompare.ToString() + delimiter + TimeOcHardFirstClick.ToString() + delimiter + TimeOcHardLastClick.ToString() + delimiter + TimeOcHardPageSubmit.ToString() + delimiter + TimeOcHardClickCount.ToString() + delimiter + Objcomp1000Hard.ToString() + delimiter + Objcomp800Hard.ToString() + delimiter + TimeSch1FirstClick.ToString() + delimiter + TimeSch1LastClick.ToString() + delimiter + TimeSch1PageSubmit.ToString() + delimiter + TimeSch1ClickCount.ToString() + delimiter + Scheuner1.ToString() + delimiter + Scheuner2.ToString() + delimiter + Scheuner3.ToString() + delimiter + TimeSch2FirstClick.ToString() + delimiter + TimeSch2LastClick.ToString() + delimiter + TimeSch2PageSubmit.ToString() + delimiter + TimeSch2ClickCount.ToString() + delimiter + Scheuner4.ToString() + delimiter + Scheuner5.ToString() + delimiter + Scheuner6.ToString() + delimiter + Scheuner7.ToString() + delimiter + Scheuner8.ToString() + delimiter + TimeSch3FirstClick.ToString() + delimiter + TimeSch3LastClick.ToString() + delimiter + TimeSch3PageSubmit.ToString() + delimiter + TimeSch3ClickCount.ToString() + delimiter + Scheuner9.ToString() + delimiter + Scheuner10.ToString() + delimiter + Scheuner11.ToString() + delimiter + Scheuner12.ToString() + delimiter + Scheuner13.ToString() + delimiter + TimeSch4FirstClick.ToString() + delimiter + TimeSch4LastClick.ToString() + delimiter + TimeSch4PageSubmit.ToString() + delimiter + TimeSch4ClickCount.ToString() + delimiter + Scheuner14.ToString() + delimiter + Scheuner15.ToString() + delimiter + Scheuner16.ToString() + delimiter + Scheuner17.ToString() + delimiter + Scheuner18.ToString() + delimiter + TimeLimitationsFirstClick.ToString() + delimiter + TimeLimitationsLastClick.ToString() + delimiter + TimeLimitationsPageSubmit.ToString() + delimiter + TimeLimitationsClickCount.ToString() + delimiter + Limitations.ToString() + delimiter + TimeNoticedFirstClick.ToString() + delimiter + TimeNoticedLastClick.ToString() + delimiter + TimeNoticedPageSubmit.ToString() + delimiter + TimeNoticedClickCount.ToString() + delimiter + ResultNoticed.ToString() + delimiter + ResultUnderstood.ToString() + delimiter + TimeSnumeracyFirstClick.ToString() + delimiter + TimeSnumeracyLastClick.ToString() + delimiter + TimeSnumeracyPageSubmit.ToString() + delimiter + TimeSnumeracyClickCount.ToString() + delimiter + SNumeracy1.ToString() + delimiter + SNumeracy2.ToString() + delimiter + SNumeracy3.ToString() + delimiter + SNumeracy4.ToString() + delimiter + SNumeracy5.ToString() + delimiter + SNumeracy6.ToString() + delimiter + SNumeracy7.ToString() + delimiter + SNumeracy8.ToString() + delimiter + TimePriorexp1FirstClick.ToString() + delimiter + TimePriorexp1LastClick.ToString() + delimiter + TimePriorexp1PageSubmit.ToString() + delimiter + TimePriorexp1ClickCount.ToString() + delimiter + CFExperience.ToString() + delimiter + CFExperienceDetail.ToString() + delimiter + TimePriorexp2FirstClick.ToString() + delimiter + TimePriorexp2LastClick.ToString() + delimiter + TimePriorexp2PageSubmit.ToString() + delimiter + TimePriorexp2ClickCount.ToString() + delimiter + TimeDemo1FirstClick.ToString() + delimiter + TimeDemo1LastClick.ToString() + delimiter + TimeDemo1PageSubmit.ToString() + delimiter + TimeDemo1ClickCount.ToString() + delimiter + Age.ToString() + delimiter + Gender.ToString() + delimiter + GenderOther.ToString() + delimiter + CombinedIncome.ToString() + delimiter + AdultsInHouse.ToString() + delimiter + ChildrenInHouse.ToString() + delimiter + Education.ToString() + delimiter + TimeDemo2FirstClick.ToString() + delimiter + TimeDemo2LastClick.ToString() + delimiter + TimeDemo2PageSubmit.ToString() + delimiter + TimeDemo2ClickCount.ToString() + delimiter + Comments.ToString() + delimiter + Design.ToString() + delimiter + TestResult.ToString() + delimiter + OCStatusAbsoluteTime.ToString() + delimiter + OCChildAbsoluteTime.ToString() + delimiter + OCCompareAbsoluteTime.ToString();
        }

    }
}
