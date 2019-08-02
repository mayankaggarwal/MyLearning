using System;
using algorithms.Algos;
using algorithms.Common;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IProjIO writer = new ProjIO();
            IRunnable runner = null;

            //runner = new EgyptionFraction(writer);
            //runner = new AddFractions(writer);
            //runner = new PrimeFactors(writer);
            //runner = new PowerSum(writer);
            //runner = new CoinDistribution(writer);
            //runner = new StringEncryption(writer);
            runner = new HuffmanEncoding(writer);

            if(runner!=null)
                runner.Run();
            else
                writer.Write("No runner selected");
        }
    }
}
