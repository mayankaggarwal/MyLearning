using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceCriterionValueRange : Contracts.Entity
    {
        public override long Id { get; set; }
        public int AudienceCriterionId { get; set; }
        public int? StartIntValue { get; set; }
        public int? EndIntValue { get; set; }
        public decimal? StartDecimalValue { get; set; }
        public decimal? EndDecimalValue { get; set; }
        public virtual AudienceCriterion AudienceCriterion { get; set; }
    }
}
