class Parent(object):
	def override(self):
		print "Parent override()"

	def implicit(self):
		print "Parent implicit()"

	def altered(self):
		print "Parent altered()"

class Child(Parent):
	def override(self):
		print "Child override()"

	def altered(self):
		print "Child altered before"
		super(Child,self).altered()
		print "Child altered after"

dad = Parent()
son = Child()

print "-" * 10
print "Calling overrides"
dad.override()
son.override()

print "-" * 10
print "Calling implicits"
dad.implicit()
son.implicit()

print "-" * 10
print "Calling altered"
dad.altered()
son.altered()
