def cheeseshop(kind,*arguments,**keywords):
	print '-- Do you really have a ', kind, '?'
	print 'I\'m we are really out of ', kind

	for arg in arguments:
		print arg

	print '-' * 40
	keys = sorted(keywords.keys())
	for kw in keys:
		print kw, ':', keywords[kw]

cheeseshop("Limburger", "It's very runny, sir.",
"It's really very, VERY runny, sir.",
shopkeeper='Michael Palin',
client="John Cleese",
sketch="Cheese Shop Sketch")
