using System;
using System.Collections.Generic;
using algorithms.Common;

namespace algorithms.Algos
{
    public class PrimeFactors : IRunnable
    {
        public PrimeFactors(IProjIO io)
        {
            IO = io;
        }
        public IProjIO IO{get;private set;}
        public void Run()
        {
            IO.WriteLine("Enter Number:");
            int num = int.Parse(IO.Read());
            var facs = GetPrimeFactors(num);

            foreach(int n in facs){
                IO.Write(n + " ");
            }

        }

        private List<int> GetPrimeFactors(int num)
        {
            var lstFactors = new List<int>();
            if(num==1){
                return lstFactors;
            }
            
            while(num%2==0){
                lstFactors.Add(2);
                num/=2;
            }

            for(int i=3;i<Math.Sqrt(num);i=i+2){
                while(num%i==0){
                    lstFactors.Add(i);
                    num/=i;
                }
            }

            if(num>2)
                lstFactors.Add(num);

            return lstFactors;
        }
    }
}