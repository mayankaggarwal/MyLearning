using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Groups.Domain.Contracts
{
    public abstract class Entity
    {
        public virtual long Id { get; set; }
    }
}
