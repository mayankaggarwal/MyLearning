using algorithms.Common;
using System;
using System.Text;
//https://www.hackerrank.com/challenges/the-power-sum/forum
namespace algorithms.Algos
{
    public class PowerSum: IRunnable
    {
        public PowerSum(IProjIO io)
        {
            IO = io;
        }
        public IProjIO IO{get;private set;}
        public void Run()
        {
            IO.WriteLine("Enter Number:");
            int X = int.Parse(IO.Read());
            IO.WriteLine("Enter Powered:");
            int Y = int.Parse(IO.Read());
            IO.WriteLine($"The power sum is :{totalSum(X,Y,1)}");
        }

        public int totalSum(int X,int N,int num){
            if(Math.Pow(num,N)<X){
                return totalSum(X,N,num+1) + totalSum(X-(int)Math.Pow(num,N),N,num+1);
            } else if(Math.Pow(num,N)==X){
                return 1;
            } else{
                return 0;
            }
        }
    }
}

// Recursion can be a bit of a mind-bender. The first key to understanding how this algorithm works is realizing that at each invocation, the totnum function branches off into two different recursive calls whose results are added together to get the final result.
// You can think of these two recursive branches as "alternate universes" that we are exploring to find the solution. In one universe, the current num (raised to the power of N) is added to our current sum. In the other universe, the current num is not used.
// Throughout the recursive calls, the X parameter acts as an accumulator to store the amount remaining to reach our target sum, and it starts out as the actual sum, the same number that is passed into the original call to the powerSum function. For recursive calls, in the universe where we do not use the current num, X stays the same. For the universe where we add the current num^N to the current sum, we use X - num^N as the next X. (To put it another way, if we are trying to reach the final sum of 100, and our current num^2 is 1, then we have 99 left to go to reach our target sum.)
// The mind-bending part of this process is that until a base case is reached, every alternate universe that splits off will itself branch in two. So we are effectively counting from 1 to X^(1/N) and trying every possible combination to see if it sums to the original X.
// The second key to understanding the algorithm is understanding the base cases.
// Let's look at the first base case, which is (pseudocode) if (num^N == X) return 1. Remember that X is the amount we have left to reach our target sum. So if the current num^2 is equal to the remaining amount we need, we have found one possible combination of numbers that, when raised to the power of N, add up to our target sum. Since the objective of the powerSum function is to return the number of possible combinations that meet this criterion, we return 1 to increment our count.
// In the second base case (the else branch), we have already checked if num^N <= X, so we can deduce that num^N > X. Since our num parameter is monotonically increasing starting from 1, we can safely terminate the current branch of our search. Again, our ultimate objective is to return the number of combinations that satisfy our criterion, so we return 0, which will be added to our count.

// powerSum(5, 2)
// totnum(5, 2, 1)
// totnum(5, 2, 2) + totnum(4, 2, 2)
// totnum(5, 2, 3) + totnum(1, 2, 3) + 1
// 0 + 0 + 1
// 1