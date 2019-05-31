using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceCriterionReferenceType : Helpers.Entity
    {
        public override int Id { get; set; }
        public string ReferenceTypeName { get; set; }
        public string TargetTableName { get; set; }
        public string TargetKeyColumnName { get; set; }
        public string TargetValueColumnName { get; set; }
    }
}
