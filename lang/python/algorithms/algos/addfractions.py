def AddFractions(fr1,fr2):
    a = str(fr1).split('/')
    b = str(fr2).split('/')
    nr1 = int(a[0])
    dr1 = int(a[1])
    nr2 = int(b[0])
    dr2 = int(b[1])

    lcm = getLCM(dr1,dr2)
    print(lcm)

    nr = lcm/dr1 * nr1 + lcm/dr2 * nr2
    gcd = getGCD(nr,lcm)
    print("{0}/{1}".format(nr/gcd,lcm/gcd))



def getLCM(num1,num2):
    a = num1
    b = num2
    if(num2>num1):
        a = num2
        b = num1

    for x in range(1,b):
        if ((a*x)%b==0):
            return a*x

    return num1*num2

def getGCD(num1,num2):
    if(num1==0):
        return num2
    if(num2==0):
        return num1

    if(num1==num2):
        return num1

    if(num1>num2):
        return getGCD(num1-num2,num2)

    return getGCD(num1,num2-num1)
