import numpy as np
from helper import sigmoid,initialize_with_zeros
from fnpropagate import propagate
from fnpredict import predict
from fnoptimize import optimize

def model(X_train,Y_train,X_test,Y_test,num_iterations = 2000,learning_rate=0.5,print_cost = False):
	"""
	Builds the logistic regression model by calling the function predict,initialize_with_zeros,optimize

	Arguments:
	X_train -- training set represented by a numpy array of shape
	Y_train -- training labels represented by a numpy array (vector) of shape
	X_test -- test set represented by a numpy array of shape
	Y_test -- test labels represented by a numpy array (vector) of shape (1, m_test)
	num_iterations -- hyperparameter representing the number of iterations to optimize
	learning_rate -- hyperparameter representing the learning rate used in the update
	print_cost -- Set to true to print the cost every 100 iterations
	
	Returns:
	d -- dictionary containing information about the model.
	"""

	#Initializing parameters with zero values
	w,b = initialize_with_zeros(X_train.shape[0])

	#Computing Gradient descent
	parameters, grads, costs = optimize(w,b,X_train,Y_train,num_iterations,learning_rate,print_cost)

	#Retrieve paramters w and b from dictionary
	w = parameters["w"]
	b = parameters["b"]

	Y_prediction_test = predict(w,b,X_test)
	Y_prediction_train = predict(w,b,X_train)

	# Print train/test Errors
	print("train accuracy: {} %".format(100 - np.mean(np.abs(Y_prediction_train - Y_train))))
	print("test accuracy: {} %".format(100 - np.mean(np.abs(Y_prediction_test - Y_test))))

	d = {
		"costs": costs,
		"Y_prediction_test": Y_prediction_test,
		"Y_prediction_train" : Y_prediction_train,
		"w" : w,
		"b" : b,
		"learning_rate" : learning_rate,
		"num_iterations": num_iterations
	}
	return d
	
