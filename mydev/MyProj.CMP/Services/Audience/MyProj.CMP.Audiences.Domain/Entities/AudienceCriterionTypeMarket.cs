using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceCriterionTypeMarket:Contracts.Entity
    {
        public override long Id { get => base.Id; set => base.Id = value; }

        public int AudienceCriterionTypeId { get; set; }
        public int RetailClientId { get; set; }
        public virtual AudienceCriterionType AudienceCriterionType { get; set; }
        //public virtual RetailClient RetailClient { get; set; }
    }
}
