import sys
print "Hello from file."
print sys.argv[0]

i = 1
while i>0:
	try:
		i = int(raw_input("Please enter a number :"))
		print 'Valid Number'
	except ValueError:
		print "Invalid Number"		
