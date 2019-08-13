library(rcompanion)

set.seed(0)
iterations = 10000
alpha = .01
mu1 = 1
groupsize = 48

# Each combination of these sds and mu2s corresponds to an f of .25.
# To verify, see G*Power ("ANOVA: Fixed effects, omnibus"), click Determine => Effect size from means, 
# set SD within each group to sd1, set size of each group to 48, set mean of groups 1
# and 2 to mu1, set mean of groups 3 and 4 to mu2.
#
# So long as the combination of SD and mu2 corresponds to f = .25, the particular values
# selected for sd and mu2 should not matter, evidenced by the results of the 3 simulations below.
#
sds = c(1, 2, 3)
mu2s = c(1.5, 2, 2.5)


for (j in 1:3) {

  ps = c()
  sd = sds[j]
  mu2 = mu2s[j]

  for (i in 1:iterations){
    d = data.frame(
      X = c(rnorm(groupsize * 2, mean = mu1, sd = sd), rnorm(groupsize * 2, mean = mu2, sd = sd)),
      Design = factor(c(rep("Control", groupsize * 2), rep("UCD", groupsize * 2))),
      TestResult = factor(c(rep(c("Positive", "Negative"), groupsize * 2)))
    )
    ps = append(ps, scheirerRayHare(X ~ TestResult * Design, data = d, verbose = FALSE)$p.value[2])
    
  }
  print(paste0("Simulation ", j, ": power = ", sum(as.numeric(ps < .01)) / iterations))
}

