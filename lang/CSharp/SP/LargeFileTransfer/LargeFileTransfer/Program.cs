using LoggerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeFileTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.Write("Enter Size of file:");
            int steps = int.Parse(Console.ReadLine());
            Console.Write("Enter Folder Path:");
            string folderPath = Console.ReadLine();
            CustomLogger logger = new CustomLogger(true);
            FileHandling fileHandling = new FileHandling(logger);
            fileHandling.CreateFile(folderPath, "TempFile.csv", steps);
            Console.Read();
        }
    }
}
