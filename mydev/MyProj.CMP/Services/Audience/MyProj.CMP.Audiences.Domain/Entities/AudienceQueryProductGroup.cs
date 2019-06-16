using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Audiences.Domain.Entities
{
    public class AudienceQueryProductGroup:Contracts.Entity
    {
        public override long Id { get => base.Id; set => base.Id = value; }
        public int AudienceQueryId { get; set; }
        public int UserProductGroupId { get; set; }
        public bool? IsProcessed { get; set; }
        public virtual AudienceQuery AudienceQuery { get; set; }
        //public virtual UserProductGroup UserProductGroup { get; set; }
    }
}
