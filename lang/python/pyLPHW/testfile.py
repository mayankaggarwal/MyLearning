from sys import argv
from os.path import exists

script, from_file, to_file = argv

print script
print from_file
print to_file

print "Copying data from file %s to file %s" % (from_file,to_file)

in_file = open(from_file)
indata = in_file.read()

print "The input data is %d bytes long" % len(indata)

print "Does the output file exists? %r" % exists(to_file)
print "Hit Enter to continue, CTRL-C to abort."
raw_input()

out_file = open(to_file,"w")
out_file.write(indata)

print "All right. Done"

in_file.close()
out_file.close()
