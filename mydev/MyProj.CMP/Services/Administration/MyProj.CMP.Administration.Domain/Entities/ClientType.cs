using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Administration.Domain.Entities
{
    public class ClientType:Contracts.Entity
    {
        public override long Id { get => base.Id; set => base.Id = value; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
