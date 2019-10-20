using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.DataSource.Contracts
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
