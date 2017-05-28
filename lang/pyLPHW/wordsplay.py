def break_words(sentence):
	print 'Breaking the sentence'
	words = sentence.split(' ')
	return words

def sorted_words(words):
	print 'Sorting the words'
	return sorted(words)

def print_first_word(words):
	print 'Printing the first word'
    	print words.pop(0)

def print_last_word(words):
	print "Printing the last word"
	print words.pop(-1)

def sort_sentence(sentence):
	print "Sorting the sentence"
	words = break_words(sentence)
	return sorted_words(words)

def print_first_and_last(sentence):
	print "Printing first and last word of sentence"
	words = break_words(sentence)
	print_first_word(words)
	print_last_word(words)

def print_first_and_last_sorted(sentence):
	print "Printing first and last word of sorted sentence"
	words = break_words(sentence)
	words = sorted_words(words)
	print_first_word(words)
        print_last_word(words)
	
