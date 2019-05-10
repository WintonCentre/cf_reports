
library(dplyr)
library(MASS)
library(agricolae)
library(effsize)
library(rcompanion)
library(car)
library(plyr)
library(ggplot2)

d <- read.delim("Results_TidyClean.tsv.txt")

alpha <- .01

# Density plots

density.by.splitvar <- function(d, varname, title, omit.nas, splitvar, splitvar.value1, splitvar.value2, splitvar.name1, splitvar.name2,
                                splitvar.col1 = "black", splitvar.col2 = "blue",
                                splitvar.lty1 = 3, splitvar.lty2 = 1, splitvar.lwd1 = 2, splitvar.lwd2 = 2,
                                legend.position="topleft", sub=NULL, xlab="", ylab="Density", xlim=NULL, ylim=NULL, bw="nrd0") {
  
  split1 = filter(d, d[splitvar] == splitvar.value1)
  split2 = filter(d, d[splitvar] == splitvar.value2)
  split1nrows = nrow(split1)
  split2nrows = nrow(split2)
  
  if (omit.nas) {
    split1 <- split1[!is.na(split1[varname]),]
    split2 <- split2[!is.na(split2[varname]),]
  }
  if (nrow(split1) != split1nrows || nrow(split2) != split2nrows) {
    cat("(Removed NAs)\n")
  }
  
  plot(density(split1[[varname]], bw=bw), main = title, col=splitvar.col1, lwd=splitvar.lwd1, lty=splitvar.lty1, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim)
  lines(density(split2[[varname]], bw=bw), col=splitvar.col2, lwd=splitvar.lwd2, lty=splitvar.lty2, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim)
  legend(legend.position, legend=c(splitvar.name1, splitvar.name2), col=c(splitvar.col1, splitvar.col2), lty=c(splitvar.lty1, splitvar.lty2), lwd=c(splitvar.lwd1, splitvar.lwd2))
}

density.by.design <- function(d, varname, title, legend.position="topleft", sub=NULL, xlab="", ylab="Density", xlim=NULL, ylim=NULL, bw="nrd0", omit.nas=TRUE) {
  
  density.by.splitvar(d, varname, title, omit.nas, "Design", "Control", "UCD", "Control reports", "User-centred reports", 
                      legend.position=legend.position, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim, bw=bw, splitvar.lwd1=3)
}

density.by.testresult <- function(d, varname, title, legend.position="topleft", sub=NULL, xlab="", ylab="Density", xlim=NULL, ylim=NULL, bw="nrd0", omit.nas=TRUE) {
  
  density.by.splitvar(d, varname, title, omit.nas, "TestResult", "Positive", "Negative", "Positive", "Negative", 
                      "red", "black", 1, 1,
                      legend.position=legend.position, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim, bw=bw)
  
}

density.by.both <- function(d, varname, title, legend.position="topleft", sub=NULL, xlab="", ylab="Density", xlim=NULL, ylim=NULL, bw="nrd0") {
  plot(density(filter(d, d$TestResult=="Positive" & d$Design=="Control")[[varname]], bw=bw), main = title, col="red", lwd=2, lty=3, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim)
  lines(density(filter(d, d$TestResult=="Negative" & d$Design=="Control")[[varname]], bw=bw), col="black", lwd=2, lty=3, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim)
  lines(density(filter(d, d$TestResult=="Positive" & d$Design=="UCD")[[varname]], bw=bw), col="red", lwd=2, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim)
  lines(density(filter(d, d$TestResult=="Negative" & d$Design=="UCD")[[varname]], bw=bw), col="black", lwd=2, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim)
  legend(legend.position, legend=c("Positive, control", "Negative, control", "Positive, user-centred", "Negative, user-centred"), col=c("red", "black", "red", "black"), lwd=2, lty=c(3,3,1,1))
}

mann.whitney.by.design <- function(d, varname) {
  # Two-sample Mann-Whitney U test
  wtest = wilcox.test(d[[varname]] ~ d$Design)
  pvalue = wtest$p.value
  
  control <- filter(d, d$Design=="Control")[[varname]]
  ucd <- filter(d, d$Design=="UCD")[[varname]]
  
  control_mean <- formatC(round(mean(control, na.rm=TRUE), 2), format='f', digits=2)
  control_sd <- formatC(round(sd(control, na.rm=TRUE), 2), format='f', digits=2)
  ucd_mean <- formatC(round(mean(ucd, na.rm=TRUE), 2), format='f', digits=2)
  ucd_sd <- formatC(round(sd(ucd, na.rm=TRUE), 2), format='f', digits=2)
  
  cat(paste0("Mann-Whitney U test ",
             ifelse(pvalue < alpha, "reported", "did not report"),
             " a significant difference (alpha = ", alpha, ") between user-centered report (M_uc=",
             ucd_mean,
             ", SD_uc=",
             ucd_sd,
             ") and standard report (M_standard=",
             control_mean,
             ", SD_standard=",
             control_sd,
             "), U=",
             formatC(round(wtest$statistic, 3), format='f', digits=3),
             ", p = ",
             formatC(round(pvalue, 3), format='f', digits=3),
             ", Cohen's d = ",
             formatC(-round(cohen.d(as.numeric(d[[varname]]), as.factor(d$Design), pooled=TRUE, na.rm=TRUE)$estimate, 2), format='f', digits=2)))
  
  cat("\n")
}

mann.whitney.by.testresult <- function(d, varname) {
  # Two-sample Mann-Whitney U test
  pvalue = wilcox.test(d[[varname]] ~ d$TestResult)$p.value
  
  positive <- filter(d, d$TestResult=="Positive")[[varname]]
  negative <- filter(d, d$TestResult=="Negative")[[varname]]
  
  cat(paste0("Mann-Whitney U test ",
             ifelse(pvalue < .01, "reported", "did not report"), 
             " a significant difference (alpha = ", alpha, ") between positive reports (M=",
             formatC(round(mean(positive, na.rm=TRUE), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(positive, na.rm=TRUE), 2), format='f', digits=2), 
             ") and negative reports (M=",
             formatC(round(mean(negative, na.rm=TRUE), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(negative, na.rm=TRUE), 2), format='f', digits=2),
             "), p = ",
             formatC(round(pvalue, 3), format='f', digits=3),
             ", Cohen's d = ",
             formatC(-round(cohen.d(as.numeric(d[[varname]]), as.factor(d$TestResult), pooled=TRUE, na.rm=TRUE)$estimate, 2), format='f', digits=2)))
  cat("\n")
}

mann.whitney.by.subjective.numeracy <- function(d, varname) {
  # Two-sample Mann-Whitney U test
  d$binary.subjective.numeracy <- as.numeric(d$subjective.numeracy > 4.34)
  pvalue = wilcox.test(d[[varname]] ~ d$binary.subjective.numeracy)$p.value
  
  high <- filter(d, d$binary.subjective.numeracy==1)[[varname]]
  low <- filter(d, d$binary.subjective.numeracy==0)[[varname]]
  
  cat(paste0("Mann-Whitney U test ",
             ifelse(pvalue < .01, "reported", "did not report"), 
             " a significant difference (alpha = ", alpha, ") between high numeracy participants (M=",
             formatC(round(mean(high, na.rm=TRUE), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(high, na.rm=TRUE), 2), format='f', digits=2), 
             ") and low numeracy participants (M=",
             formatC(round(mean(low, na.rm=TRUE), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(low, na.rm=TRUE), 2), format='f', digits=2),
             "), p = ",
             formatC(round(pvalue, 3), format='f', digits=3),
             ", Cohen's d = ",
             formatC(round(-cohen.d(as.numeric(d[[varname]]), as.factor(d$binary.subjective.numeracy), pooled=TRUE, na.rm=TRUE)$estimate, 2), format='f', digits=2)))
  cat("\n")
}

mann.whitney.by.education <- function(d, varname) {
  
  

  d$Education2 <- mapvalues(d$Education, from=c(2,3,4,5,7), to=c(2,NA,NA,6,6))

  
  # Two-sample Mann-Whitney U test
  pvalue = wilcox.test(d[[varname]] ~ d$Education2)$p.value
  
  low_education = filter(d, d$Education2 == 2)[[varname]]
  high_education = filter(d, d$Education2 == 6)[[varname]]
  cat(paste0("low education count: ", length(low_education), "\n"));
  cat(paste0("high education count: ", length(high_education), "\n"));
  
  cat(paste0("Mann-Whitney U test ",
             ifelse(pvalue < .01, "reported", "did not report"), 
             " a significant difference (alpha = ", alpha, ") between low education participants (M=",
             formatC(round(mean(low_education, na.rm=TRUE), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(low_education, na.rm=TRUE), 2), format='f', digits=2), 
             ") and high education participants (M=",
             formatC(round(mean(high_education, na.rm=TRUE), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(high_education, na.rm=TRUE), 2), format='f', digits=2),
             "), p = ",
             formatC(round(pvalue, 3), format='f', digits=3),
             ", Cohen's d = ",
             formatC(round(-cohen.d(as.numeric(d[[varname]]), as.factor(d$Education2), pooled=TRUE, na.rm=TRUE)$estimate, 2), format='f', digits=2)))
  cat("\n")
}

mann.whitney.ucd.by.testresult <- function(d, varname) {
  # Two-sample Mann-Whitney U test
  pvalue = wilcox.test(d[[varname]] ~ d$TestResult)$p.value
  
  positive <- filter(d, d$TestResult=="Positive" & d$Design=="UCD")[[varname]]
  negative <- filter(d, d$TestResult=="Negative" & d$Design=="UCD")[[varname]]
  
  cat(paste0("Mann-Whitney U test ",
             ifelse(pvalue < .01, "reported", "did not report"), 
             " a significant difference (alpha = ", alpha, ") between UCD positive reports (M=",
             formatC(round(mean(positive), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(positive), 2), format='f', digits=2), 
             ") and UCD negative reports (M=",
             formatC(round(mean(negative), 2), format='f', digits=2),
             ", SD=",
             formatC(round(sd(negative), 2), format='f', digits=2),
             "), p = ",
             formatC(round(pvalue, 3), format='f', digits=3),
             ", Cohen's d = ",
             formatC(-round(cohen.d(as.numeric(d[[varname]]), as.factor(d$TestResult), pooled=TRUE)$estimate, 2), format='f', digits=2)))
  cat("\n")
}


test.log.normality <- function(d, varname) {
  
  x <- log(d[[varname]])
  print(shapiro.test(x))
}

test.sqrt.normality <- function(d, varname) {
  x <- sqrt(d[[varname]])
  print(shapiro.test(x))
}


# Bringing it all together
analyse.by.design <- function(d, varname, title, legend.position="topleft", sub=NULL, xlab="", ylab="Density", xlim=NULL, ylim=NULL, bw="nrd0", omit.nas=TRUE, suppress.plot=FALSE)
{
  cat("*****************************************\n")
  cat(title, "\n")
  cat("*****************************************\n")
  if (!suppress.plot) {
    density.by.design(d, varname, title, legend.position=legend.position, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim, bw=bw, omit.nas=omit.nas)
  }
  
  mann.whitney.by.design(d, varname)
  cat("\n")
}

analyse.by.testresult <- function(d, varname, title, legend.position="topleft", sub=NULL, xlab="", ylab="Density", xlim=NULL, ylim=NULL, bw="nrd0", omit.nas=TRUE)
{
  cat("*****************************************\n")
  cat(title, "\n")
  cat("*****************************************\n")
  density.by.testresult(d, varname, title, legend.position=legend.position, sub=sub, xlab=xlab, ylab=ylab, xlim=xlim, ylim=ylim, bw=bw, omit.nas=omit.nas)
  mann.whitney.by.testresult(d, varname)
  cat("\n")
}



#################################################
# Key analyses of variables of interest:
# key hypothesis tests that study was powered for
#################################################

print("Tests for normality")

print(shapiro.test(d$subj.understanding))
print(shapiro.test(d$subj.clarity))
print(shapiro.test(d$oc.score))

print("Running U-tests as variables of interest are not normally distributed.")

print("Key hypothesis tests that study was powered for")

analyse.by.design(d, "subj.understanding", "Subjective comprehension", xlim=c(1, 7))
analyse.by.design(d, "subj.clarity", "Subjective clarity", bw=.5, ylim=c(0,.4))
analyse.by.design(d, "communication.efficacy", "Communication efficacy", xlim=c(1, 4), ylim=c(0,.7))
analyse.by.design(d, "oc.score", "Risk probability comprehension", xlim=c(0, 7), xlab="Number of questions answered correctly")


print("Planned 2x2 ANOVAs crossing design with test result,")
print("and Scheirer-Ray-Hare extension of the Kruskal Wallis test, to rule out interactions")

print(summary(aov(subj.understanding ~ TestResult * Design, data = d)))
print(summary(aov(subj.clarity ~ TestResult * Design, data = d)))
print(summary(aov(communication.efficacy ~ TestResult * Design, data = d)))
print(summary(aov(oc.score ~ TestResult * Design, data = d)))

print(scheirerRayHare(subj.understanding ~ TestResult * Design, data = d))
print(scheirerRayHare(subj.clarity ~ TestResult * Design, data = d))
print(scheirerRayHare(communication.efficacy ~ TestResult * Design, data = d))
print(scheirerRayHare(oc.score ~ TestResult * Design, data = d))

#################################################
# EXPLORATORY ANALYSES START HERE
#################################################
#
cat("\n\n")
cat("Exploratory analyses", fill=TRUE)
cat("\n\n")

analyse.by.design(d, "subj.trusted", "Trust", xlim=c(1, 7), bw=.45, ylim=c(0,.5))
analyse.by.design(d, "Next.Steps.Average", "Actionability", xlim=c(1, 7), ylim=c(0,.35))
analyse.by.design(d, "Result.Understood.Value", "How easy is it to understand the result summary?", xlim=c(1, 7), bw=.45, ylim=c(0,.55))

cat("\n\n")
cat("Correlations with subjective numeracy:", fill=TRUE)
cat("Subj. understanding ", cor(d$subjective.numeracy, d$subj.understanding), fill=TRUE)
cat("Subj. clarity ", cor(d$subjective.numeracy, d$subj.clarity), fill=TRUE)
cat("Communication efficacy ", cor(d$subjective.numeracy, d$communication.efficacy), fill=TRUE)
cat("Risk probability comprehension ", cor(d$subjective.numeracy, d$oc.score), fill=TRUE)
cat("Trust ", cor(d$subjective.numeracy, d$subj.trusted), fill=TRUE)
cat("Actionability ", cor(d$subjective.numeracy, d$Next.Steps.Average), fill=TRUE)
cat("Easy of understanding result summary ", cor(d$subjective.numeracy, d$Result.Understood.Value), fill=TRUE)
cat("\n\n")


print("Analogous U-tests comparing positive vs negative reports on key variables of interest")

analyse.by.testresult(d, "subj.understanding", "Subjective understanding", xlim=c(1, 4), ylim=c(0,.7))
analyse.by.testresult(d, "subj.clarity", "Subjective clarity", xlim=c(1, 4), ylim=c(0,.7))
analyse.by.testresult(d, "communication.efficacy", "Communication efficacy", xlim=c(1, 4), ylim=c(0,.7))
analyse.by.testresult(d, "oc.score", "Objective comprehension", xlim=c(0, 7), xlab="Number of questions answered correctly")



print("Item-wise analyses")

d$q1 <- as.numeric(d$status.is.nearly.correct == "y")
d$q2 <- as.numeric(d$status.slider.is.nearly.correct == "y")
d$q3 <- as.numeric(d$child.is.nearly.correct == "y")
d$q4 <- as.numeric(d$child.slider.is.nearly.correct == "y")
d$q5 <- as.numeric(d$hard1000.is.nearly.correct == "y")
d$q6 <- as.numeric(d$hard800.is.nearly.correct == "y")
d$q7 <- as.numeric(d$oc.compare.is.correct == "y")

print("Item-wise chi-squared tests: comprehension questions, by design")
print("Q1")
print(chisq.test(table(d$q1, d$Design)))
print("Q2")
print(chisq.test(table(d$q2, d$Design)))
print("Q3")
print(chisq.test(table(d$q3, d$Design)))
print("Q4")
print(chisq.test(table(d$q4, d$Design)))
print("Q5")
print(chisq.test(table(d$q5, d$Design)))
print("Q6")
print(chisq.test(table(d$q6, d$Design)))
print("Q7")
print(chisq.test(table(d$q7, d$Design)))


print("Item-wise U-tests: communication efficacy questions, by design")

analyse.by.design(d, "Scheuner.1", "Scheuner 1", suppress.plot=T)
analyse.by.design(d, "Scheuner.2", "Scheuner 2", suppress.plot=T)
analyse.by.design(d, "Scheuner.3", "Scheuner 3", suppress.plot=T)
analyse.by.design(d, "Scheuner.4", "Scheuner 4", suppress.plot=T)
analyse.by.design(d, "Scheuner.5", "Scheuner 5", suppress.plot=T)
analyse.by.design(d, "Scheuner.6", "Scheuner 6", suppress.plot=T)
analyse.by.design(d, "Scheuner.7", "Scheuner 7", suppress.plot=T)
analyse.by.design(d, "Scheuner.8", "Scheuner 8", suppress.plot=T)
analyse.by.design(d, "Scheuner.9", "Scheuner 9", suppress.plot=T)
analyse.by.design(d, "Scheuner.10", "Scheuner 10", suppress.plot=T)
analyse.by.design(d, "Scheuner.11", "Scheuner 11", suppress.plot=T)
analyse.by.design(d, "Scheuner.12", "Scheuner 12", suppress.plot=T)
analyse.by.design(d, "Scheuner.13", "Scheuner 13", suppress.plot=T)

# NOTE: The variables Scheuner.14 through Scheuner.18 have scores of 2 through 5
# rather than 1 through 4 due to a issue with the Qualtrics mapping from choices
# to output numbers. The corrected values appear in the variables Scheuner.14.Value
# onwards, and are used below.

analyse.by.design(d, "Scheuner.14.Value", "Scheuner 14", suppress.plot=T)
analyse.by.design(d, "Scheuner.15.Value", "Scheuner 15", suppress.plot=T)
analyse.by.design(d, "Scheuner.16.Value", "Scheuner 16", suppress.plot=T)
analyse.by.design(d, "Scheuner.17.Value", "Scheuner 17", suppress.plot=T)
analyse.by.design(d, "Scheuner.18.Value", "Scheuner 18", suppress.plot=T)

print("Item-wise U-tests: actionability questions, by design")

analyse.by.design(d, "subj.next.1", "'Next steps' question 1", suppress.plot=T)
analyse.by.design(d, "subj.next.2", "'Next steps' question 2", suppress.plot=T)
analyse.by.design(d, "subj.next.3", "'Next steps' question 3", suppress.plot=T)
analyse.by.design(d, "subj.next.4", "'Next steps' question 4", suppress.plot=T)
analyse.by.design(d, "subj.next.5", "'Next steps' question 5", suppress.plot=T)

#################################################
# Differences in the degree to which people saw the box
#################################################

table(d$Result.Noticed.Binary, d$Design)

control <- filter(d, d$Design=="Control")$Result.Noticed.Binary
ucd <- filter(d, d$Design=="UCD")$Result.Noticed.Binary

control_mean <- formatC(100 * round(mean(control, na.rm=TRUE), 2), format='f', digits=0)
ucd_mean <- formatC(100 * round(mean(ucd, na.rm=TRUE), 2), format='f', digits=0)
print(paste0("Control: ", control_mean, "% saw results summary"))
print(paste0("UCD: ", ucd_mean, "% saw results summary"))

print(chisq.test(table(d$Result.Noticed.Binary, d$Design)))

######################################################################
# Are there differences in the probabilities of CF estimated by participants
# between the UCD & control conditions, when we restrict ourselves to the subset of
# reports that are positive, or the subset of reports that are negative?
######################################################################

d$oc.child.slider.100 <- d$oc.child.slider_1 / 100.0
d$oc.status.slider.100 <- d$oc.status.slider_1 / 100.0

positives = filter(d, d$TestResult == "Positive")
negatives = filter(d, d$TestResult == "Negative")


print("Child slider results")
print(paste0("median ucd positive: ", median(filter(d, d$TestResult == "Positive" & d$Design == "UCD")$oc.child.slider_1, na.rm=TRUE)))
print(paste0("median control positive: ", median(filter(d, d$TestResult == "Positive" & d$Design == "Control")$oc.child.slider_1, na.rm=TRUE)))
print(paste0("median ucd negative: ", median(filter(d, d$TestResult == "Negative" & d$Design == "UCD")$oc.child.slider_1, na.rm=TRUE)))
print(paste0("median control negative: ", median(filter(d, d$TestResult == "Negative" & d$Design == "Control")$oc.child.slider_1, na.rm=TRUE)))
print("***")
print("Status slider results")
print(paste0("median ucd positive: ", median(filter(d, d$TestResult == "Positive" & d$Design == "UCD")$oc.status.slider_1, na.rm=TRUE)))
print(paste0("median control positive: ", median(filter(d, d$TestResult == "Positive" & d$Design == "Control")$oc.status.slider_1, na.rm=TRUE)))
print(paste0("median ucd negative: ", median(filter(d, d$TestResult == "Negative" & d$Design == "UCD")$oc.status.slider_1, na.rm=TRUE)))
print(paste0("median control negative: ", median(filter(d, d$TestResult == "Negative" & d$Design == "Control")$oc.status.slider_1, na.rm=TRUE)))
print("***")

analyse.by.design(positives, "oc.child.slider.100", "Probability that child will have CF (slider): positive reports", xlim=c(0,100), ylim=c(0,.5), legend.position="topright", omit.nas=TRUE, bw=.6)
analyse.by.design(negatives, "oc.child.slider.100", "Probability that child will have CF (slider): negative reports", xlim=c(0,100), ylim=c(0,.5), legend.position="topright", omit.nas=TRUE, bw=.6)
analyse.by.design(positives, "oc.status.slider.100", "Probability that patient is a carrier (slider): positive reports", xlim=c(0,100), ylim=c(0,.5), legend.position="topleft", omit.nas=TRUE, bw=.6)
analyse.by.design(negatives, "oc.status.slider.100", "Probability that patient is a carrier (slider): negative reports", xlim=c(0,100), ylim=c(0,.5), legend.position="topleft", omit.nas=TRUE, bw=.6)


#################################################
# Differences in risk probability *interpretation*
#################################################

print("Differences in risk probability *interpretation*")

positives = filter(d, d$TestResult == "Positive")
fulltable = table(positives$oc.child.verbal, positives$Design)
print(fulltable)
print(chisq.test(fulltable))

print(paste0("Those who saw the user-centred positive report are more apt to say that a child of two",
" carriers was 'unlikely' to have cystic fibrosis than those who saw the",
" standard positive report:"))

positives$unlikely_or_not <- as.numeric(positives$oc.child.verbal == 2)  # 2 == "unlikely"
smalltable = table(positives$unlikely_or_not, positives$Design)
print(smalltable)
print(chisq.test(smalltable))

print("Analyses described in Figure 1 caption")

std_unlikely = filter(d, d$TestResult == "Positive" & d$Design == "Control" & d$oc.child.verbal == 2)
std_likely = filter(d, d$TestResult == "Positive" & d$Design == "Control" & d$oc.child.verbal == 3)
ucd_unlikely = filter(d, d$TestResult == "Positive" & d$Design == "UCD" & d$oc.child.verbal == 2)
ucd_likely = filter(d, d$TestResult == "Positive" & d$Design == "UCD" & d$oc.child.verbal == 3)

unlikely = filter(d, d$TestResult == "Positive" & d$oc.child.verbal == 2)
likely = filter(d, d$TestResult == "Positive" & d$oc.child.verbal == 3)

cat(paste0("std_unlikely ", mean(std_unlikely$oc.child.slider_1)), " (", sd(std_unlikely$oc.child.slider_1), ")\n")
cat(paste0("std_likely ", mean(std_likely$oc.child.slider_1)), " (", sd(std_likely$oc.child.slider_1), ")\n")
cat(paste0("ucd_unlikely ", mean(ucd_unlikely$oc.child.slider_1)), " (", sd(ucd_unlikely$oc.child.slider_1), ")\n")
cat(paste0("ucd_likely ", mean(ucd_likely$oc.child.slider_1)), " (", sd(ucd_likely$oc.child.slider_1), ")\n")

wilcox.test(likely$oc.child.slider_1 ~ likely$Design)
wilcox.test(unlikely$oc.child.slider_1 ~ unlikely$Design)


#################################################
# Exploring possible covariates and demographic variables
#################################################

print(Anova(lm(oc.score ~ Gender.Value * Design, data = d), type=2))
print(Anova(lm(subj.understanding ~ Gender.Value * Design, data = d), type=2))
print(Anova(lm(communication.efficacy ~ Gender.Value * Design, data = d), type=2))
print(Anova(lm(subj.clarity ~ Gender.Value * Design, data = d), type=2))

print(Anova(lm(oc.score ~ Age * Design, data = d), type=2))
print(Anova(lm(subj.understanding ~ Age * Design, data = d), type=2))
print(Anova(lm(communication.efficacy ~ Age * Design, data = d), type=2))
print(Anova(lm(subj.clarity ~ Age * Design, data = d), type=2))

print(Anova(lm(oc.score ~ income.lower.bound * Design, data = d), type=2))
print(Anova(lm(subj.understanding ~ income.lower.bound * Design, data = d), type=2))
print(Anova(lm(communication.efficacy ~ income.lower.bound * Design, data = d), type=2))
print(Anova(lm(subj.clarity ~ income.lower.bound * Design, data = d), type=2))

print(Anova(lm(oc.score ~ Adults.in.House.Value * Design, data = d), type=2))
print(Anova(lm(subj.understanding ~ Adults.in.House.Value * Design, data = d), type=2))
print(Anova(lm(communication.efficacy ~ Adults.in.House.Value * Design, data = d), type=2))
print(Anova(lm(subj.clarity ~ Adults.in.House.Value * Design, data = d), type=2))

print(Anova(lm(oc.score ~ Children.in.House.Value * Design, data = d), type=2))
print(Anova(lm(subj.understanding ~ Children.in.House.Value * Design, data = d), type=2))
print(Anova(lm(communication.efficacy ~ Children.in.House.Value * Design, data = d), type=2))
print(Anova(lm(subj.clarity ~ Children.in.House.Value * Design, data = d), type=2))

print(Anova(lm(oc.score ~ subjective.numeracy * Design, data = d), type=2))
print(Anova(lm(subj.understanding ~ subjective.numeracy * Design, data = d), type=2))
print(Anova(lm(communication.efficacy ~ subjective.numeracy * Design, data = d), type=2))
print(Anova(lm(subj.clarity ~ subjective.numeracy * Design, data = d), type=2))

# Examine range of educational backgrounds
# 2 = GCSE or equivalent
# 3 = A-level or equivalent
# 4 = Bachelors
# 5 = Masters
# 7 = PhD or greater
#
table(d$Education)

# Since so few in PhD category, lump 5 & 7 together into
# 6 = Postgraduate study

d$Education2 <- as.factor(mapvalues(d$Education,
                                     from=c(2,3,4,5,7),
                                     to=c(2,3,4,6,6)))

ggplot(data=subset(d, !is.na(d$Education2)), mapping=aes(x=Education2, y=oc.score)) + stat_boxplot(aes(col=Education2), geom = "errorbar", width = 0.3) +
  geom_boxplot( aes(col=Education2),outlier.shape=NA,notch=F) + #avoid plotting outliers twice, notch set to F as data means goes out of hinges
  geom_jitter(aes(col=Education2),position = position_jitter(width = .3, height=0.3), alpha = 0.15)+ theme_classic()+
  labs(x="Education level",y="Risk comprehension score") +
  theme(legend.position="none")


d$Education_low_vs_high <- mapvalues(d$Education,
                          from=c(2,3,4,5,7),
                          to=c(2,NA,NA,6,6))

print(summary(aov(oc.score ~ Education_low_vs_high * Design, data = d, na.action=na.omit)))
print(summary(aov(subj.understanding ~ Education_low_vs_high * Design, data = d, na.action=na.omit)))
print(summary(aov(communication.efficacy ~ Education_low_vs_high * Design, data = d, na.action=na.omit)))
print(summary(aov(subj.clarity ~ Education_low_vs_high * Design, data = d, na.action=na.omit)))
