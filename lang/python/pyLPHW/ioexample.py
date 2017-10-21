print "How old are you?",
age = raw_input()
print "How tall are you?",
height = raw_input()
weight = raw_input("How much do you weigh? ") 

print "So, you are %r old, %r tall and %r heavy." %(
age,height,weight)

from sys import argv
script, first, second, third = argv

print "The script is called:", script
print "Your first variable is:", first
print "Your second variable is:", second
print "Your third variable is:", third
