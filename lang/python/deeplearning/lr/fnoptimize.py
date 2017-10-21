from fnpropagate import propagate

def optimize(w,b,X,Y,num_iterations,learning_rate,print_cost = False):
	"""
	This function optimizes w and b by running a gradient descent algorithm

	Arguments:
	w -- weights, a numpy array of size (num_px * num_px * 3, 1)
	b -- bias, a scalar
	X -- data of shape (num_px * num_px * 3, number of examples)
	Y -- true "label" vector
	num_iterations -- number of iterations of the optimization loop
	learning_rate -- learning rate of the gradient descent update rule
	print_cost -- True to print the loss every 100 steps

	Returns:
	params -- dictionary containing the weights w and bias b 
	grads -- dictionary containing the gradients of the weights and bias i.e. dw and db
	costs -- list of all the costs computed during the optimization
	"""

	costs = []
	for i in range(num_iterations):
		#Cost and Gradient calculation
		grads,cost = propagate(w,b,X,Y)

		dw = grads["dw"]
		db = grads["db"]

		w = w - learning_rate*dw
		b = b - learning_rate*db

		if i%100 == 0:
			costs.append(cost)

		if print_cost and i%100==0:
			print("Cost after iteration %i: %f" %(i,cost))

	params = {"w":w,"b":b}
	grads = {"dw":dw,"db":db}
	
	return params,grads,costs
