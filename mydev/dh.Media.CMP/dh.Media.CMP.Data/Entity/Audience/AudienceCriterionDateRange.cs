using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceCriterionDateRange:Helpers.Entity
    {
        public override int Id { get; set; }
        public int AudienceCriterionId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public virtual AudienceCriterion AudienceCriterion { get; set; }
    }
}
