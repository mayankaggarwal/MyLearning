using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProj.Aerospike.API.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public double Relevance { get; set; }
        public int Sponsored { get; set; }
    }
}
