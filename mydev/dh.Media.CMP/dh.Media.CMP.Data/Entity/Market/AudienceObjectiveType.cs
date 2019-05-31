using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class AudienceObjectiveType:Helpers.Entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
