using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using MyProj.CM.API.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.API.Middleware
{
    public class AuthProxyMoqMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtHeader _jwtHeader;
        private readonly AuthProxyMoqOptions _options;
        public AuthProxyMoqMiddleware(RequestDelegate next,IOptions<AuthProxyMoqOptions> options)
        {
            _next = next;
            _jwtHeader = new JwtHeader(new Microsoft.IdentityModel.Tokens.SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("some random key" + new Guid())),
                SecurityAlgorithms.HmacSha256Signature));
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userName = string.IsNullOrWhiteSpace(_options.UserName) ? "mayankgg" : _options.UserName;
            var upn = $"{userName}@dunnhumby.com";
            var claims = new List<Claim>
            {
                new Claim(AuthProxyAuthenticationHandler.UpnClaim,upn),
                new Claim(AuthProxyAuthenticationHandler.GivenNameClaim,_options.FirstName),
                new Claim(AuthProxyAuthenticationHandler.SurNameClaim,_options.LastName),
                new Claim(AuthProxyAuthenticationHandler.EmailAddressClaim,_options.EmailAddress)
            };

            claims.AddRange(Enumerable.Range(1, 5).Select(m => new Claim(AuthProxyAuthenticationHandler.RoleClaim, "ce-dev-media-" + m)));
            var token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_jwtHeader, new JwtPayload(
                nameof(AuthProxyMoqMiddleware), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, claims, DateTime.Now, DateTime.Now.AddSeconds(5))));

            context.Request.Headers.Add(AuthProxyAuthenticationHandler.XAuthProxyAuthHeader, new StringValues(token));
            context.Request.Headers.Add(AuthProxyAuthenticationHandler.XAuthProxyUserIdHeader, upn);

            await _next(context);
        }
    }
}
