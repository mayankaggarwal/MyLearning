using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceObjective:Helpers.Entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public int AudienceQueryId { get; set; }
        public int AudienceObjectiveTypeId { get; set; }
        public virtual AudienceQuery AudienceQuery { get; set; }
        public virtual AudienceObjectiveType AudienceObjectiveType { get; set; }
    }
}
