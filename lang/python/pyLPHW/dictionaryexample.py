states = {
	'HimachalPradesh':'HP',
	'Haryana':'HR',
	'Punjab':'PUN',
	'Karnataka':'KR'
}

cities = {
	'New Delhi':'DL',
	'Chandigarh':'CDG',
	'Bangalore':'BNG',
	'Chennai':'MAD'
}

cities['New York'] = 'NY'
cities['Sydney'] = 'SYD'

print '-' * 10
print "Karnataka state has: ", cities['Bangalore']
print "Punjab state has: ",cities['Chandigarh']

print '-' * 10
for state,abbrev in states.items():
	print "%s is abbreviates as %s" % (state,abbrev)

print '-' * 10
state = states.get('UP',None)

if not state:
	print 'Sorry, no UP'

city = cities.get('Noida','Does not exists')
if not city:
	print 'No Noida'
else:
	print 'Noida having default value', city

