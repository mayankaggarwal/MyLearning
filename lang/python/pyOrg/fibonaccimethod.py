def fib(n):
	i,j = 0,1
	result = []
	while i<n:
		i,j = j,i+j
		result.append(i)
	return result

f100 = fib(100)
print f100
