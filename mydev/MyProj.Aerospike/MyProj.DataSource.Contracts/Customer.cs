using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.DataSource.Contracts
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public List<Offer> OfferList { get; set; }
    }
}
