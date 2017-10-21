def ask_ok(prompt,retries=4,complaint='Yes or no, please'):
	while True:
		ok = raw_input(prompt)
		if ok in ('y','ye','yes'):
			return True
		if ok in ('n','nop','no','nope'):
			return False
		retries -= 1
		if retries < 0:
			raise IOError('Retries done')
		print complaint

print ask_ok('Do you really want to quit?')
print ask_ok('OK to overwrite the file?',2)
