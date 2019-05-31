using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Contracts
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
