using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceCriterionReferenceTypeSelection : Contracts.Entity
    {
        public override long Id { get; set; }
        public int AudienceCriterionId { get; set; }
        public string ReferenceKey { get; set; }
        public string ReferenceValue { get; set; }
        public virtual AudienceCriterion AudienceCriterion { get; set; }
    }
}
