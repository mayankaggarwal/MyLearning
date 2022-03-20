using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Contracts.Data.Authorization
{
    public struct RolePermission
    {
        public int MarketId { get; set; }
        public string Application { get; set; }
        public string Role { get; set; }
        public string Module { get; set; }
        public string Feature { get; set; }
        public string Permission { get; set; }
        public bool IsGrant { get; set; }
        public int Level { get; set; }
    }
}
