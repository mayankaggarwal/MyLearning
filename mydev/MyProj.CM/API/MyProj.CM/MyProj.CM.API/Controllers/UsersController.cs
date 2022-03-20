using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProj.CM.API.Authentication;
using MyProj.CM.Common.Security.Jwt;
using MyProj.CM.Apps.Common.Grpc;
using MyProj.CM.Apps.Common.ModelBuilder;
using MyProj.CM.Apps.Common.Models;

namespace MyProj.CM.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAdministration _administration;
        public UsersController(IAdministration administration)
        {
            _administration = administration;
        }

        [HttpGet]
        [Route("login-session/{selectedMarket}")]
        [AllowAnonymous]
        public IActionResult SetUserSession(string selectedMarket)
        {
            if (string.IsNullOrEmpty(selectedMarket))
                return BadRequest("No selected market");

            if (!Request.Headers.ContainsKey(AuthProxyAuthenticationHandler.XAuthProxyAuthHeader))
                throw new Exception("Missing header");

            Response.Cookies.Append(AuthProxyAuthenticationHandler.SessionCookieName
                ,selectedMarket + AuthProxyAuthenticationHandler.SessionCookieSeperator + Request.Headers[AuthProxyAuthenticationHandler.XAuthProxyUserIdHeader]
                + AuthProxyAuthenticationHandler.SessionCookieSeperator + Guid.NewGuid(),
            new CookieOptions { HttpOnly = true});

            return Ok();
        }

        [HttpGet]
        [Route("login-user-profile")]
        public async Task<ActionResult<object>> GetProfile()
        {
            var market = _administration.GetAllMarkets().First(m => m.Id == int.Parse(User.Claims.First(c => JwtConstants.Market.ToString().Equals(c.Type)).Value)).ToModel();
            var userInfo = new UserInfo
            {
                FullName = User.Claims.First(c=>JwtConstants.FullName.ToString().Equals(c.Type)).Value,
                Email = User.Claims.First(c => JwtConstants.Email.ToString().Equals(c.Type)).Value,
                HelpSite = "",
                Market = market,
                IsSupplier = MyProj.CM.Common.Contracts.Types.ClientType.Supplier.ToString().Equals(User.Claims.First(c=>JwtConstants.Type.ToString().Equals(c.Type)).Value),
                PreferredLanguageId = 1
            };

            return userInfo;
        }

        [HttpGet]
        [Route("UserDetailsWithRolePermission")]
        public async Task<ActionResult<object>> GetUserDetailsWithRolePermission()
        {
            var userDetails = _administration.GetUserDetailsWithRoleAndPermission("mayankgg");
            if (userDetails != null)
            {
                return userDetails.ToUserInfoModel();
            }

            return NoContent();
        }
    }
}