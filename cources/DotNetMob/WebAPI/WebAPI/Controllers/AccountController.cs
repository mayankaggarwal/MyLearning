using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            userManager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 3
            };
            IdentityResult result = userManager.Create(user, model.Password);

            userManager.AddToRoles(user.Id, model.Roles);
            return result;
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value,
            };

            return model;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "For Admin Role";
        }

        [HttpGet]
        [Authorize(Roles ="Author")]
        [Route("api/ForAuthorRole")]
        public string ForAuthorRole()
        {
            return "For Author Role";
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Author")]
        [Route("api/ForAdminOrAuthor")]
        public string ForAdminOrAuthor()
        {
            return "For Admin or Author";
        }
    }
}
