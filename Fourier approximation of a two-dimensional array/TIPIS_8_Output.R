library(plot3D)
Vals <- read.csv("G:/Artem/TIPIS_Lab/graph.csv",
                 header = TRUE, sep = "", dec = ",")

disc <- 0.1

Z <- as.vector(Vals['Z'])

len <- sqrt(length(Z[,1]))

Ys <- seq(0, len*disc-0.1, by = disc)
Xs <- seq(0, len*disc-0.1, by = disc)

Zs <- matrix(Z$Z, 100, 100)

plot3D::persp3D(Xs, Ys, Zs)

dev.copy(png, 'G:/Artem/TIPIS_Lab/graph.png')
dev.off()