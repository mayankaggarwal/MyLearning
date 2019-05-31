using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceCriterionTypeMarket:Helpers.Entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }

        public int AudienceCriterionTypeId { get; set; }
        public int RetailClientId { get; set; }
        public virtual AudienceCriterionType AudienceCriterionType { get; set; }
        public virtual RetailClient RetailClient { get; set; }
    }
}
