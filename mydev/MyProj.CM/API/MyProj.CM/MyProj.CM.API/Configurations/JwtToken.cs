using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProj.CM.API.Configurations
{
    public class JwtToken
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string PrivateKey { get; set; }
        public int TimeInSeconds { get; set; }
    }
}
