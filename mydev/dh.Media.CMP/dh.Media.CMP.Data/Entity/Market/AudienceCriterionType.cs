using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceCriterionType : Helpers.Entity
    {
        public override int Id { get; set; }
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
