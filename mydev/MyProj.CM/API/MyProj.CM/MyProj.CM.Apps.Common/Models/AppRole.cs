using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Models
{
    public class AppRole
    {
        public string Application { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
