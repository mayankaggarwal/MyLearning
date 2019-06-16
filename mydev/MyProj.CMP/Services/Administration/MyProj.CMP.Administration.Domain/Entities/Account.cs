using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Administration.Domain.Entities
{
    public class Account:Contracts.Entity
    {
        public override long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
