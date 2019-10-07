using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.Aerospike.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
