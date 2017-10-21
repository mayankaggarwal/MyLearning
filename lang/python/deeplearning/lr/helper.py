import numpy as np
def sigmoid(z):
	"""
	Compute the sigmlid of z

	Arguments:
	z -- A scalar or numpy arrary

	Returns:
	s -- sigmoid(z)
	"""

	s = 1.0/(1+np.exp(-z))
	return s

def initialize_with_zeros(dim):
	"""
	Argument:
	dim -- size of w vector we want

	Returns:
	w -- initialized vector of shape (dim,1)
	b -- initialized scalar corresponding to bias
	"""

	w = np.zeros((dim,1))
	b = 0

	assert(w.shape == (dim,1))
	assert(isinstance(b,float) or isinstance(b,int))

	return w,b
