class Animal(object):
	def __init__(self,name):
		self.name = name
	
	def myName(self):
		print self.name

class Dog(Animal):
	def __init__(self,name):
		super(Dog,self).__init__(name)

class Cat(Animal):
	def __init__(self,name):
		super(Cat,self).__init__(name)

class Person(object):
	def __init__(self,name):
		self.name = name
		self.pet = None

class Employee(Person):
	def __init__(self,name,salary)
		super(Employee,self).__init__(name)
		self.salary = salary

class Fish(object):
	pass

class Salmon(Fish):
	pass

class Halibut(Fish):
	pass



mayank = Cat("Mayank")
mayank.myName()
print mayank.name
