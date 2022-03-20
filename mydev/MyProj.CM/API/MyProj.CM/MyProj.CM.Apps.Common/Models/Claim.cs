using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Models
{
    public class Claim
    {
        public string Module { get; set; }
        public string Feature { get; set; }
        public string Permission { get; set; }
        public string ClientType { get; set; }
        public bool IsGrant { get; set; }
    }
}
