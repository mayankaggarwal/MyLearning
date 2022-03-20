using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyProj.CM.Common.Caching;
using MyProj.CM.Common.Contracts.Data.Authorization;
using MyProj.CM.Apps.Common.Grpc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MyProj.CM.API.Authentication
{
    public class AuthProxyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string XAuthProxyAuthHeader = "X-Authproxy-Token";
        public const string XAuthProxyUserIdHeader = "X-Authproxy-Id";
        public const string UpnClaim = "upn";
        public const string GivenNameClaim = "givenname";
        public const string SurNameClaim = "surname";
        public const string EmailAddressClaim = "emailaddress";
        public const string RoleClaim = "role";

        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        //private readonly ICache _cache;
        private readonly IAdministration Administration;

        public const string SessionCookieName = "_med_cmp_ssn";
        public const string SessionCookieSeperator = "(#)";
        public const string AuthProxyScheme = "AuthProxy";
        public AuthProxyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,
            IAdministration administration,ICache cache) : base(options, logger, encoder, clock)
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            Administration = administration;
            //_cache = cache;

        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(XAuthProxyAuthHeader))
                return AuthenticateResult.Fail("Missing auth-proxy header");
            var authHeader = Request.Headers[XAuthProxyAuthHeader].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(authHeader))
                return AuthenticateResult.Fail("Empty value for auth-proxy header");

            var token = await Task.FromResult(_jwtSecurityTokenHandler.ReadJwtToken(authHeader));
            if (token == null)
            {
                return AuthenticateResult.Fail("Token validation failed");
            }

            if (!Request.Cookies.ContainsKey(SessionCookieName))
                return AuthenticateResult.Fail("Missing session details");

            var sessionData = Request.Cookies[SessionCookieName].Split(SessionCookieSeperator);
            //var markets = await _cache.Invoke(() => Administration.GetAllMarkets());
            var markets = Administration.GetAllMarkets();
            var selectedMarket = markets.SingleOrDefault(x => x.MarketSiteCode.Equals(sessionData.First(), StringComparison.OrdinalIgnoreCase));
            if (selectedMarket == null)
                return AuthenticateResult.Fail("Selected market code not present");

            var upn = token.Claims.First(x => UpnClaim.Equals(x.Type)).Value;
            var firstName = token.Claims.First(x => GivenNameClaim.Equals(x.Type)).Value;
            var lastName = token.Claims.First(x => SurNameClaim.Equals(x.Type)).Value;
            var emailAddress = token.Claims.First(x => EmailAddressClaim.Equals(x.Type)).Value;

            if (string.IsNullOrWhiteSpace(upn) || !upn.Equals(sessionData[1], StringComparison.OrdinalIgnoreCase))
                return AuthenticateResult.Fail("Invalid Upn in token");

            var userName = upn.Split('@').First();
            var marketId = selectedMarket.Id;
            //var emUserDetails = await _cache.Invoke(() => Administration.GetUserDetails(userName, marketId));
            var emUserDetails = Administration.GetUserDetails(userName, marketId);
            if (emUserDetails == null)
                return AuthenticateResult.Fail("User details not present");

            emUserDetails.MarketId = (int)selectedMarket.Id;
            emUserDetails.FullName = $"{firstName} {lastName}";
            emUserDetails.PreferredLanguageId = emUserDetails.PreferredLanguageId ?? selectedMarket.PrimaryLanguageId;

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(PrepareUserClaims(emUserDetails), AuthProxyScheme));
            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, AuthProxyScheme));

        }

        private IEnumerable<System.Security.Claims.Claim> PrepareUserClaims(UserDetails emUserDetails)
        {
            if (emUserDetails.AppRoles == null || emUserDetails.AppRoles.Length == 0)
                throw new Exception("App roles can't be null");

            return new[]
            {
                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.UserId.ToString(),Convert.ToString(emUserDetails.Id)),
                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.UserName.ToString(),emUserDetails.Name),
                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.Email.ToString(),emUserDetails.Email),
                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.FullName.ToString(),emUserDetails.FullName),
                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.PreferredLanguageId.ToString(),emUserDetails.PreferredLanguageId.ToString()),

                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.Market.ToString(),emUserDetails.MarketId.ToString()),
                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.Client.ToString(),emUserDetails.ClientId.ToString()),
                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.Type.ToString(),emUserDetails.ClientType.ToString()),

                new System.Security.Claims.Claim(MyProj.CM.Common.Security.Jwt.JwtConstants.AppRole.ToString(),emUserDetails.AppRoles.Aggregate("",(current,appRole) => current + $",{appRole.Application}/{appRole.Role}").ToString())
            };
        }
    }
}
