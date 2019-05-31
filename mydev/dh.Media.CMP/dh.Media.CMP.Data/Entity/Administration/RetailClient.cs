using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class RetailClient:Helpers.Entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MarketSiteCode { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
