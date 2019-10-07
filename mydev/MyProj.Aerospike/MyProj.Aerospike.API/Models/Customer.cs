using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProj.Aerospike.API.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
