using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceObjective:Contracts.Entity
    {
        public override long Id { get => base.Id; set => base.Id = value; }
        public int AudienceQueryId { get; set; }
        public int AudienceObjectiveTypeId { get; set; }
        public virtual AudienceQuery AudienceQuery { get; set; }
        //public virtual AudienceObjectiveType AudienceObjectiveType { get; set; }
    }
}
