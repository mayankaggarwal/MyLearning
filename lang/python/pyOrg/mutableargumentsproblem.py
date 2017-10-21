def f(a,L=[]):
	L.append(a)
	return L

print f(1)
print f(2)
print f(3)

def f1(a,L=None):
	if L is None:
		L=[]
	L.append(a)
	return L

print f1(1)
print f1(2)
print f1(3)
