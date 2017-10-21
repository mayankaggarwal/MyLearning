import math
import numpy as np

#Basic sigmoid function with mat libary
def basic_sigmoid(x):
	"""
	Compute sigmoid of x.
	"""
	s = 1/(1+math.exp(-x))
	return s

def sigmoid(x):
	"""
	Compute sigmoid of x.
	"""
	s = 1/(1+np.exp(-x))
	return s

def image2vector(image):
	"""
	Argument:
	image -- a numpy array of shape (length,height,depth)
	
	Returns:
	v -- a vector of shape (length*height*depth,1)
	"""
	v = image.reshape(image.shape[0]*image.shape[1]*image.shape[2],1)
	return v

def normalizeRows(x):
	"""
	each element is divided by square root of sum of squares of reach row
	Argument:
	x -- A numoy matrix of shape(n,m)
	"""

	x_norm = np.linalg.norm(x,ord=2,axis=1,keepdims=True)
	x = x/x_norm
	return x

def softmax(x):
	"""
	Calculate the softmax for each row of input x
	Argument:
	x -- A numpy matrix of shape(n,m)
	"""

	x_exp = np.exp(x)
	x_sum = np.sum(x_exp,axis=1,keepdims=True)
	s = x_exp/x_sum
	return s

def L1(yhat,y):
	"""
	Calculating the value by implementing L1 loss function
	"""

	loss = np.sum(abs(y-yhat))
	return loss

def L2(yhat,y):
	"""
	Calculating the value by implementing L2 loss function
	"""
	
	loss = np.dot(y-yhat,y-yhat) #np.sum((y-yhat)**2)
	return loss

