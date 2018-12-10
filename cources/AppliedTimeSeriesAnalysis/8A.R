xvec <- rnorm(200)
yvec <- 2.5*xvec + rnorm(length(xvec))

lmodyx <- lm(yvec ~ xvec)
lmodxy <- lm(xvec ~ yvec)




