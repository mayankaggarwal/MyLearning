using MyProj.CM.Apps.Common.Session;
using MyProj.CM.Common.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyProj.CM.Apps.Common.Extensions
{
    public static class UserPrincipalExtension
    {
        public static IUserPrincipal GetUserPrincipal(this ClaimsPrincipal user)
        {
            if (!user.Claims.Any())
                return null;

            var username = user.Claims.First(m => JwtConstants.UserName.ToString().Equals(m.Type)).Value;
            var activeMarket = user.Claims.Any(m => JwtConstants.Market.ToString().Equals(m.Type))
                ? System.Convert.ToInt32(user.Claims.First(m => JwtConstants.Market.ToString().Equals(m.Type)).Value) : 0;

            var applicationRole = new List<ApplicationRole>();
            foreach (var temp in user.Claims.First(m => JwtConstants.AppRole.ToString().Equals(m.Type)).Value.Split(','))
            {
                if (string.IsNullOrWhiteSpace(temp))
                    continue;

                var part = temp.Split('/');
                applicationRole.Add(new ApplicationRole(part[0], part[1]));
            }
            var clientId = user.Claims.Any(m => JwtConstants.Client.ToString().Equals(m.Type))
                ? System.Convert.ToInt32(user.Claims.First(m => JwtConstants.Client.ToString().Equals(m.Type)).Value) : 0;
            return new UserPrincipal
            {
                UserName = username,
                Market = activeMarket,
                Client = clientId,
                ApplicationRole = applicationRole.ToArray(),

            };
        }
    }
}
