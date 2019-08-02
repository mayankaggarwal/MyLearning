import math;

def egyptionFraction(nr,dr):
    print("The Egyptian Fraction Representation of {0}/{1} is".format(nr,dr))

    ef = []

    while(nr!=0):
        x = math.ceil(dr / nr)
        ef.append(x)

        nr = x*nr -dr
        dr=dr*x

    for i in range(len(ef)):
        print("1/{0} ".format(ef[i]))