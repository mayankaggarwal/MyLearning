using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceCriterion:Contracts.Entity
    {
        public override long Id { get; set; }
        public int AudienceQueryId { get; set; }
        public int AudienceCriterionTypeId { get; set; }
        public bool? BoolValue { get; set; }
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public string StringValue { get; set; }
        public DateTime? DateValue { get; set; }
        public virtual AudienceQuery AudienceQuery { get; set; }
        public virtual AudienceCriterionType AudienceCriterionType { get; set; }
        public virtual ICollection<AudienceCriterionDateRange> DateRanges { get; set; }
        public virtual ICollection<AudienceCriterionValueRange> ValueRanges { get; set; }
        public virtual ICollection<AudienceCriterionReferenceTypeSelection> ReferenceTypes { get; set; }
    }
}
