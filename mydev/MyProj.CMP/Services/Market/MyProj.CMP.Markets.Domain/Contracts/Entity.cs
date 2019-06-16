using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Markets.Domain.Contracts
{
    public abstract class Entity
    {
        public virtual long Id { get; set; }
    }
}
