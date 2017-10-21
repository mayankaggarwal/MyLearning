for i in range(11):
	print repr(i).rjust(2),repr(i*i).rjust(3),
	print repr(i*i*i).rjust(4)

for i in xrange(1,11):
	print '{0:2d} {1:3d} {2:4d}'.format(i,i*i,i*i*i)
