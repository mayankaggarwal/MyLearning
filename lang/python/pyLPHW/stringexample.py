x = "There are %d type of people." % 10
binary = "binary"
do_not = "don't"
y = "Those who know %s and thos who %s." %(binary, do_not)

print x
print y

print "I said: %r." % x
print "I also said: '%s'." % y

hilarious = False
joke_evaluation = "Isn't that joke so funny?! %r"

print joke_evaluation % hilarious

w = "This is left side of..."
e = "a string with a rught side."

print w + e
print "." * 10 #What's that do

string1 = "Mayank"
string2 = "Aggarwal"

#watch the comma at the end
print string1,
print string2

formatter = "%r %r %r %r"
print formatter % (
"I had this thing.",
"That you could type up right.",
"But it didn't sing.",
"So I said goodnight."
)

days = "Mon Tue Wed Thu Fri Sat Sun"
months = "Jan\nFeb\nMar\nApril\nMay\nJune\nJuly\nAug\nSep\nOct\nNov\nDec"

print "Here are the days: ", days
print "Here are the months: ", months
