using System;
using System.IO;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var path  = @"D:\Samples\source";
            var data = "My name is mayank aggarwal and i have been wroking as software engineer from very long time";
            int input = 0;
            do{
                Console.WriteLine("Number of lines to print(0 to quit):");
                if(int.TryParse(Console.ReadLine(),out input)){
                    if(input>0){
                        string filePath = Path.Combine(path,"customfile_" + input + 
                        DateTime.Now.ToString().Replace(' ','_').Replace(':','_')+ ".csv");
                        using(var writer = new StreamWriter(filePath)){
                            for(int i=0;i<input;i++){
                                writer.WriteLine(data);
                            }
                        }
                    }else{
                        input=0;
                    }
                }else{
                    input =0;
                }
            }while(input!=0);
        }
    }
}
