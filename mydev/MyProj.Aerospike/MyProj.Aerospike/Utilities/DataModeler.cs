using MyProj.Aerospike.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.Aerospike.Utilities
{
    public class DataModeler
    {
        public IEnumerable<Customer> GetData(long numberOfRecords,long? idStartNumber = null)
        {
            if (idStartNumber == null) idStartNumber = 1;
            for(long i = idStartNumber.Value; i <= numberOfRecords; i++)
            {
                Customer cust = new Customer
                {
                    CustomerId = $"{i:000000000000000}",
                    ProductList = GetProducts(i)
                };
                yield return cust;
            }
        }
        private List<Product> GetProducts(long recordNumber)
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId=$"{1000+recordNumber%10:000000000000000}",
                    Relevance=0.80,
                    Sponsored=0
                },
                new Product
                {
                    ProductId=$"{1005+recordNumber%10:000000000000000}",
                    Relevance=0.65,
                    Sponsored=0
                },
                new Product
                {
                    ProductId=$"{1003+recordNumber%10:000000000000000}",
                    Relevance=0.60,
                    Sponsored=1
                },
                new Product
                {
                    ProductId=$"{1002+recordNumber%10:000000000000000}",
                    Relevance=0.50,
                    Sponsored=0
                },
                new Product
                {
                    ProductId=$"{1009+recordNumber%10:000000000000000}",
                    Relevance=0.30,
                    Sponsored=0
                },
                new Product
                {
                    ProductId=$"{1008+recordNumber%10:000000000000000}",
                    Relevance=0.29,
                    Sponsored=0
                },
                new Product
                {
                    ProductId=$"{1001+recordNumber%10:000000000000000}",
                    Relevance=0.23,
                    Sponsored=0
                },
                new Product
                {
                    ProductId=$"{1004+recordNumber%10:000000000000000}",
                    Relevance=0.17,
                    Sponsored=1
                },
                new Product
                {
                    ProductId=$"{1007+recordNumber%10:000000000000000}",
                    Relevance=0.1,
                    Sponsored=0
                },
                new Product
                {
                    ProductId=$"{1006+recordNumber%10:000000000000000}",
                    Relevance=0.05,
                    Sponsored=0
                }
            };
        }
    }
}
