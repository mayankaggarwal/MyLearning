using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceCriterionDateRange:Contracts.Entity
    {
        public override long Id { get; set; }
        public int AudienceCriterionId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public virtual AudienceCriterion AudienceCriterion { get; set; }
    }
}
