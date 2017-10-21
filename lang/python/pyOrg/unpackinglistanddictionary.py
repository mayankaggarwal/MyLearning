def parrot(voltage,state='a stiff',action='voom'):
	print 'This parrot wouldn\'t', action
	print 'If you put ', voltage, 'volts thorugh it.'
	print 'E\'s', state

d = {"voltage":"four million","state":"bleeding","action":"VOOM"}
parrot(d)
print '-'*40
parrot(**d)
