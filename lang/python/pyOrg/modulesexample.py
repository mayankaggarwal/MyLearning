
print 'modulename:' +  __name__
def fib(n):
	result = []
	a,b = 0,1
	while b < n:
		result.append(b)
		a,b = b,a+b
	return result

def fib1(n):
	a,b = 0,1
	for i in range(n):
		print b,
		a,b = b,a+b


