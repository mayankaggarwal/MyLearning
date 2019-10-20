using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.DataSource.Contracts
{
    public enum DbResponseStatus
    {
        Other=0,
        Success=1,
        Failure=2,
        DocumentExists=3
    }
}
