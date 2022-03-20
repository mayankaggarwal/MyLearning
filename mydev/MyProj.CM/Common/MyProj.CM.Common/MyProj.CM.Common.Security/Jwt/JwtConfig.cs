using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Security.Jwt
{
    public class JwtConfig
    {
        public string Audience;
        public string Issuer;
        public string PrivateKey;
        public int ExpirationTimeInSeconds;
        public JwtConfig(string audience, string issuer, string privateKey, int expirationTimeInSeconds)
        {
            Audience = audience;
            Issuer = issuer;
            PrivateKey = privateKey;
            ExpirationTimeInSeconds = expirationTimeInSeconds;
        }
    }
}
