using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceCriterionValueRange : Helpers.Entity
    {
        public override int Id { get; set; }
        public int AudienceCriterionId { get; set; }
        public int? StartIntValue { get; set; }
        public int? EndIntValue { get; set; }
        public decimal? StartDecimalValue { get; set; }
        public decimal? EndDecimalValue { get; set; }
        public virtual AudienceCriterion AudienceCriterion { get; set; }
    }
}
