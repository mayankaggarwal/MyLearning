using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Entity
{
    public class ClientType:Helpers.Entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
