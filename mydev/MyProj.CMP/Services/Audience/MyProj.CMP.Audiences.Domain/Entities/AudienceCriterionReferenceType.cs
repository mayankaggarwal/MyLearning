using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceCriterionReferenceType : Contracts.Entity
    {
        public override long Id { get; set; }
        public string ReferenceTypeName { get; set; }
        public string TargetTableName { get; set; }
        public string TargetKeyColumnName { get; set; }
        public string TargetValueColumnName { get; set; }
    }
}
