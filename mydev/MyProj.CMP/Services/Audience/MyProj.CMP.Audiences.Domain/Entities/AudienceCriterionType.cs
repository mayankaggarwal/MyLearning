using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceCriterionType : Contracts.Entity
    {
        public override long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBoolValueType { get; set; }
        public bool IsIntValueType { get; set; }
        public bool IsDecimalValueType { get; set; }
        public bool IsStringValueType { get; set; }
        public bool IsDateValueType { get; set; }
        public bool IsDateRangeType { get; set; }
        public bool IsValueRangeType { get; set; }
        public bool IsReferenceType { get; set; }
        public int? ReferenceTypeId { get; set; }
        public virtual AudienceCriterionReferenceType ReferenceType { get; set; }
        public virtual ICollection<AudienceCriterionTypeMarket> AudienceCriterionTypeMarket { get; set; }
    }
}
