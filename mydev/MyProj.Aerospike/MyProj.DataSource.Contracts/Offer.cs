using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.DataSource.Contracts
{
    public class Offer
    {
        public string Offerid { get; set; }
        public string OfferName { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
