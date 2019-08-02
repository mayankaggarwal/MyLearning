using System;
using System.Collections.Generic;
using algorithms.Common;

namespace algorithms.Algos
{
    public class EgyptionFraction : IRunnable
    {
        public EgyptionFraction(IProjIO io)
        {
            IO = io;
        }
        public IProjIO IO{get;private set;}

        public void Run()
        {
            IO.WriteLine("Enter Numerator");
            uint nr = uint.Parse(IO.Read());
            IO.WriteLine("Enter Denominator");
            uint dn = uint.Parse(IO.Read());

            if(dn!=0 && dn>nr){
                EgyptionFractionCalc(nr,dn);
            } else{
                IO.WriteBatch("Invalid Inputs");
            }

        }

        private void EgyptionFractionCalc(uint nr, uint dn)
        {
            IO.WriteBatch("The Egyptian Fraction " + String.Format("Representation of {0}/{1} is",nr,dn) + "\n");

            var ef = new List<uint>();
            while(nr!=0){
                uint x = (uint)Math.Ceiling((double)dn/nr);
                ef.Add(x);
                nr = nr*x-dn;
                dn = dn*x;
            }

            foreach(var num in ef){
                IO.Write($"1/{num} ");
            }
        }
    }
}