using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceQueryProductGroup:Helpers.Entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public int AudienceQueryId { get; set; }
        public int UserProductGroupId { get; set; }
        public bool? IsProcessed { get; set; }
        public virtual AudienceQuery AudienceQuery { get; set; }
        public virtual UserProductGroup UserProductGroup { get; set; }
    }
}
