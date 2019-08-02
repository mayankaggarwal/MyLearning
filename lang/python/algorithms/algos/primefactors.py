import math;

def printPrimeFactors(lstFactors):
    for i in range(len(lstFactors)):
        print(lstFactors[i],end=' ')

    print(end='\n')

def primeFactors(num):
    lst = []
    if(num==1):
        return lst
    while num % 2==0:
        lst.append(2)
        num/=2

    for i in range(3,int(math.sqrt(num))+1,2):
        while num % i==0:
            lst.append(i)
            num/=i

    if num>2:
        lst.append(num)

    return lst