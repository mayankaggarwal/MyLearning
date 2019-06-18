using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProj.CMP.Administration.Domain.Entities
{
    [NotMapped]
    public class RetailClient : Contracts.Entity
    {
        public override long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MarketSiteCode { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
