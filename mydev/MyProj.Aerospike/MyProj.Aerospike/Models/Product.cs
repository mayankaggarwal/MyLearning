using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.Aerospike.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public double Relevance { get; set; }
        public int Sponsored { get; set; }
    }
}
