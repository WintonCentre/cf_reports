This repository contains analyses and code for the paper "Creating genetic reports that are understood by non-specialists: a case study". It contains the following:

analysis_genetics1: 
Preprocessing code for going from original Qualtrics output to tsv "Results_TidyClean.tsv.txt". Best way to inspect is by opening analysis_genetics1.sln in Visual Studio.

Documentation_QualtricsMappings.txt:
Some variables were assigned unintuitive codes by Qualtrics and had to be remapped by the code in analysis_genetics1. Because the data file Results_TidyClean.tsv.txt preserves both the original Qualtrics codes as well as the new, remapped variables, it's recommended that people who plan to use the data in Results_TidyClean.tsv.txt take a look at this file so as not to inadvertently use the wrong data columns.

2019.05.03_Genetic-Reports-Analysis-Code.R: 
R code for conducting the analyses described in the paper. The code for the primary key analyses can be found after some boilerplate for pretty-printing the results of statistical tests (line ~236 onward). Code for more exploratory analyses follows.

Results_TidyClean.tsv.txt:
Data file. 2019.05.03_Genetic-Reports-Analysis-Code.R expects to find this file in the working directory.

2019.05.03_Genetic-Reports-Analysis-Code.html:
Knit document that includes the output of running the code in 2019.05.03_Genetic-Reports-Analysis-Code.R.