using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Markets.Domain.Entities
{
    public class AudienceObjectiveType:Contracts.Entity
    {
        public override long Id { get => base.Id; set => base.Id = value; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
