using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceCriterionReferenceTypeSelection : Helpers.Entity
    {
        public override int Id { get; set; }
        public int AudienceCriterionId { get; set; }
        public string ReferenceKey { get; set; }
        public string ReferenceValue { get; set; }
        public virtual AudienceCriterion AudienceCriterion { get; set; }
    }
}
