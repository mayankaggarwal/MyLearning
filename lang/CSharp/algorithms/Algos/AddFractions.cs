using System;
using algorithms.Common;

namespace algorithms.Algos
{
    public class AddFractions : IRunnable
    {
        public AddFractions(IProjIO io)
        {
            IO = io;
        }
        public IProjIO IO{get;private set;}


        public void Run()
        {
            IO.WriteLine("Enter Fraction 1");
            string[] fr1 = IO.Read().Split('/');
            int nr1 = int.Parse(fr1[0]);
            int dr1 = int.Parse(fr1[1]);
            IO.WriteLine("Enter Fraction 2");
            string[] fr2 = IO.Read().Split('/');
            int nr2 = int.Parse(fr2[0]);
            int dr2 = int.Parse(fr2[1]);

            IO.Write(SumFractions(nr1,dr1,nr2,dr2));
        }

        private string SumFractions(int nr1, int dr1, int nr2, int dr2)
        {
            int lcm = GetLCM(dr1,dr2);
            IO.WriteLine(lcm.ToString());
            int nr = (lcm/dr1 * nr1) + (lcm/dr2 * nr2);
            int gcd = GetGCD(nr,lcm);
            return $"{nr/gcd}/{lcm/gcd}";
        }

        private int GetLCM(int dr1, int dr2)
        {
            //IO.WriteLine($"{dr1} and {dr2}");
            int num1 = dr1;
            int num2 = dr2;
            if(dr2>dr1){
                num1 = dr2;
                num2 = dr1;
            }

            for(int i=1;i<num2;i++){
                if((num1*i)%num2==0){
                    return num1*i;
                }
            }

            return num1*num2;
        }

     private int GetGCD(int num1,int num2){
         if(num1==0)
            return num2;
        if(num2==0)
            return num1;

        if(num1==num2)
            return num1;

        if(num1>num2)
            return GetGCD(num1-num2,num2);

        return GetGCD(num1,num2-num1);

     }
    }
}