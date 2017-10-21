from helper import sigmoid
import numpy as np

def propagate(w,b,X,Y):
	"""
	Implement the cost function and its gradient for the propagation

	Arguments:
	w -- weights, a numpy array of size (num_px * num_px * 3, 1)
	b -- bias, a scalar
	X -- data of size (num_px * num_px * 3,number of training examples)
	Y -- true "label" vector of size (1,number of training examples)

	Returns:
	cost -- negative log-likelihood cost for logistic regression
	dw -- gradient of the loss with respect to w, thus same shape as w
	db -- gradient of the loss with respect to b, thus same shape as b
	"""

	m = X.shape[1]
	#Calculating forward propagation
	A = sigmoid(np.dot(w.T,X)+b)
	cost = (-1.0/m)*np.sum(Y*np.log(A) + (1-Y)*np.log(1-A))

	#Caucluating backward propagation
	dw = (1.0/m)*np.dot(X,(A-Y).T)
	db = (1.0/m)*np.sum(A-Y)

	assert(dw.shape == w.shape)
	assert(db.dtype == float)
	cost = np.squeeze(cost)
	assert(cost.shape == ())
	
	grads = {"dw":dw, "db":db}

	return grads,cost
