using System.Collections;
using System.Collections.Generic;
using System.Linq;
using algorithms.Common;

namespace algorithms.Algos
{
    public class HuffmanEncoding: IRunnable
    {
        public HuffmanEncoding(IProjIO io)
        {
            IO = io;
        }
        public IProjIO IO{get;private set;}
        public void Run()
        {
            //IO.WriteLine("Enter text for encoding");
            string txt = "HelloWorld";//IO.Read();
            var freq = CountCharacterFrequency(txt.ToLower());
            List<HuffmanNode> nodes = freq.OrderBy(x=>x.Value).Select(x=>new HuffmanNode{c=x.Key,data=x.Value}).ToList();
            while(nodes.Count()>1){
                List<HuffmanNode> orderedNodes = nodes.OrderBy(x=>x.data).ToList<HuffmanNode>();
                if(orderedNodes.Count()>=2){
                    List<HuffmanNode> taken = orderedNodes.Take(2).ToList<HuffmanNode>();
                    HuffmanNode parent = new HuffmanNode{
                        c = '*',
                        data = taken[0].data + taken[1].data,
                        left = taken[0],
                        right = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }
            }

        
        }

        private Dictionary<char,int> CountCharacterFrequency(string txt){
            var freqResponse = new Dictionary<char,int>();
            int[] freq = new int[26];
            for(int i=0;i<txt.Length;i++){
                freq[txt[i]-'a']++;
            }

            for(int j=0;j<26;j++){
                if(freq[j]>0){
                    freqResponse.Add(((char)(j+97)),freq[j]);
                }
            }

            return freqResponse;
        }
        
    }

    public class HuffmanNode :IComparer{
        public int data{get;set;}
        public char c{get;set;}
        public HuffmanNode left{get;set;}
        public HuffmanNode right{get;set;}

        public int Compare(object x, object y)
        {
            return ((HuffmanNode)x).data - ((HuffmanNode)y).data;
        }
    }
}