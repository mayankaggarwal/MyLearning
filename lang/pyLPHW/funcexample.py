from sys import argv

script, filename = argv

def print_all(f):
    print f.read()

def print_rewind(f):
    f.seek(0)

def print_a_line(line_count,f):
	print line_count, f.readline()

current_file = open(filename)

print "First let's print the whole file:"

print_all(current_file)

print "Now let's rewind, kind of like a tape"

print_rewind(current_file)

print "Let's print three lines:"

current_line = 1
print_a_line(current_line,current_file)

current_line += current_line
print_a_line(current_line,current_file)

current_line += 1
print_a_line(current_line,current_file)
