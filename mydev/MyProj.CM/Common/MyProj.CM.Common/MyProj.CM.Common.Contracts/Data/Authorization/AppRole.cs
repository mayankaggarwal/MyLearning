using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Contracts.Data.Authorization
{
    public class AppRole
    {
        public string Application { get; set; }
        public string Role { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
