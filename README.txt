This repository contains analyses and code for the paper "Creating genetic reports that are understood by non-specialists: a case study". It contains the following:

analysis_genetics1: 
Preprocessing code for going from original Qualtrics output to tsv "Results_TidyClean.tsv.txt". Best way to inspect is by opening analysis_genetics1.sln in Visual Studio.

Documentation_QualtricsMappings.txt:
Some variables were assigned unintuitive codes by Qualtrics and had to be remapped by the code in analysis_genetics1. Because the data file Results_TidyClean.tsv.txt preserves both the original Qualtrics codes as well as the new, remapped variables, it's recommended that people who plan to use the data in Results_TidyClean.tsv.txt take a look at this file so as not to inadvertently use the wrong data columns.

2019.07.22_Genetic-Reports-Analysis-Code.R: 
R code for conducting the analyses described in the paper. The code for the primary analyses can be found after some boilerplate for pretty-printing the results of statistical tests (line ~236 onward). Code for more exploratory analyses follows.

Results_TidyClean.tsv.txt:
Data file, formatted as a tab-separated value file. 2019.05.03_Genetic-Reports-Analysis-Code.R expects to find this file in the working directory.

Results_TidyClean.tsv.xlsx:
Results_TidyClean.tsv.txt, as an Excel file.

CF_Responses_Categorized_All.xlsx:
Participant responses to selected questions of interest, categorized by three different raters.

CF_Responses_Key_Mapping.xlsx:
The mapping between a participant's "ComboID" as given in CF_Responses_Categorized_All.xlsx and that participant's round, within-round participant number, and reports viewed.

Nonparametric-Power.R:
Code for the power analysis of the Scheirer-Ray-Hare extension of the Kruskal Wallis test. 

2019.07.22_Genetic-Reports-Analysis-Code.pdf:
Knit document that includes the output of running the code in 2019.07.22_Genetic-Reports-Analysis-Code.R as a PDF file.
