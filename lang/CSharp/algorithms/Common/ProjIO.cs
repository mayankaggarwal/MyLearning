using System;

namespace algorithms.Common
{
    public class ProjIO : IProjIO
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void WriteBatch(params string[] message)
        {
            Console.WriteLine("------------------------" + DateTime.Now.ToString() + "-------------------------------");

            foreach(var msg in message){
                Console.WriteLine(msg);
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        public void WriteLine(string message){
            Console.WriteLine(message);
        }

        public void Write(string message){
            Console.Write(message);
        }
    }
}