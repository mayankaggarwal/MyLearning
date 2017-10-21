import numpy as np
from helper import sigmoid
def predict(w,b,X):
	"""
	Predict whether the label is 0 or 1 using learned logistic regression parameters

	Arguments:
	w -- weights, a numpy array of size (num_px * num_px * 3, 1)
	b -- bias, a scalar
	X -- data of size (num_px * num_px * 3, number of examples)

	Returns:
	Y_prediction -- a numpy array (vector) containing all predictions (0/1)
	"""

	m = X.shape[1]
	Y_prediction = np.zeros((1,m))
	if (w.shape != (X.shape[0],1)):
		w = w.reshape(X.shape[0],1)

	A = sigmoid(np.dot(w.T,X)+b)

	for i in range(A.shape[1]):
		if A[0][i] > 0.5:
			Y_prediction[0][i] = 1

	assert(Y_prediction.shape == (1,m))

	return Y_prediction
