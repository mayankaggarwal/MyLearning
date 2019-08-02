using System;
using System.Text;
using algorithms.Common;
//https://www.hackerrank.com/challenges/encryption/problem
namespace algorithms.Algos
{
    public class StringEncryption: IRunnable
    {
        public StringEncryption(IProjIO io)
        {
            IO = io;
        }
        public IProjIO IO{get;private set;}
        public void Run()
        {
            IO.WriteLine("Enter Text to encrypt:");
            string s = IO.Read();
            IO.WriteLine(encryption(s));
        }
        string encryption(string s) {
            int L = s.Length;
            int maxDim = (int)Math.Ceiling(Math.Sqrt(L));
            int row = maxDim;
            int col = maxDim;
            while(row*col>=(L+row)){
                row = row-1;
                if(row*col>(L+col)){
                    col = col-1;
                }
            }

            string[] array = new string[row];
            for(int i=0;i<row;i++){
                if(i!=row-1){
                    array[i] = s.Substring(i*col,col);
                } else {
                    array[i] = s.Substring(i*col,L-(i*col));
                }
            }

            StringBuilder builder = new StringBuilder();
            for(int j=0;j<col;j++){
                for(int m=0;m<row;m++){
                    if(m<array.Length && j<array[m].Length)
                        builder.Append(array[m][j]);
                }
                builder.Append(" ");
            }
            return builder.ToString();
        }

    }
}