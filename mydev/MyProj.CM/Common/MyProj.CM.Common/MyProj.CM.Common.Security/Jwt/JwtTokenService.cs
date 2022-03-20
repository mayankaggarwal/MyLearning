using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.Common.Security.Jwt
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtHeader _jwtHeader;
        private readonly JwtConfig _config;
        public JwtTokenService(JwtConfig config)
        {
            _config = config;
            _jwtHeader = new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.PrivateKey)), SecurityAlgorithms.HmacSha256Signature));

        }
        public string SignToken(Dictionary<JwtConstants, string> userData, int overrideTimeInSeconds = 0)
        {
            var tokenPayload = new JwtPayload(
                _config.Issuer,
                _config.Audience,
                userData.Where(m => m.Value != null).Select(m => new Claim(m.Key.ToString(), m.Value)),
                DateTime.Now,
                DateTime.Now.AddSeconds(overrideTimeInSeconds > 0 ? overrideTimeInSeconds : _config.ExpirationTimeInSeconds));

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_jwtHeader, tokenPayload));
        }

        public Task<ClaimsPrincipal> ValidateToken(string token, bool isLifetimeValidationRequired = true)
        {
            var validationParameter = new TokenValidationParameters
            {
                IssuerSigningKey = _jwtHeader.SigningCredentials.Key,
                ValidIssuer = _config.Issuer,
                ValidAudience = _config.Audience,
                ValidateLifetime = isLifetimeValidationRequired
            };

            ClaimsPrincipal claimsPrincipal = null;
            try
            {
                claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameter, out var _);
            }
            catch(Exception exp)
            {
                throw;
            }

            return Task.FromResult(claimsPrincipal);
        }

        public Task<ClaimsPrincipal> ValidateToken(string token, out SecurityToken securityToken)
        {
            var validationParameter = new TokenValidationParameters
            {
                IssuerSigningKey = _jwtHeader.SigningCredentials.Key,
                ValidIssuer = _config.Issuer,
                ValidAudience = _config.Audience,
                ValidateLifetime = true
            };

            ClaimsPrincipal claimsPrincipal = null;
            securityToken = null;
            try
            {
                claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameter, out securityToken);
            }
            catch (Exception exp)
            {
                throw;
            }

            return Task.FromResult(claimsPrincipal);
        }
    }
}
