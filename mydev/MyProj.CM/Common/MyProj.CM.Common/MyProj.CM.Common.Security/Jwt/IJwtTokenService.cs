using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.Common.Security.Jwt
{
    public interface IJwtTokenService
    {
        string SignToken(Dictionary<JwtConstants, string> userData, int overrideTimeInSeconds = 0);
        Task<ClaimsPrincipal> ValidateToken(string token, bool isLifetimeValidationRequired = true);
        Task<ClaimsPrincipal> ValidateToken(string token, out SecurityToken securityToken);
    }
}
