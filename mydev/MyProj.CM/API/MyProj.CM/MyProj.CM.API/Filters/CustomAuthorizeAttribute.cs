using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyProj.CM.Apps.Common.Extensions;
using MyProj.CM.Apps.Common.Grpc;
using MyProj.CM.Apps.Common.Session;
using MyProj.CM.Common.Contracts.Data.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyProj.CM.API.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly PermissionData[] _permissionData;
        //private readonly IAdministration Administration => Container.GetService<IAdministration>();
        private IAdministration Administration;

        public CustomAuthorizeAttribute(params string[] permissions)
        {
            _permissionData = permissions.Select(m => new PermissionData(m)).ToArray();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // can be implemented as
            //this.Administration = context.HttpContext.RequestServices.GetService(typeof(IAdministration)) as IAdministration;
            var userPrinciple = context.HttpContext.User.GetUserPrincipal();
            var appRoleClaims = Administration.GetUserClaims(GetUserDetails(userPrinciple));

            foreach(var permissionData in _permissionData)
            {
                var application = appRoleClaims.FirstOrDefault(m => m.Application.Equals(permissionData.Application, StringComparison.OrdinalIgnoreCase));

                if (application != null && application.Claims.Any(m => m.Module.Equals(permissionData.Module)
                    && (m.Feature != null || permissionData.Feature.Equals(m.Feature))
                    && m.Permission.Equals(permissionData.Permission)
                    && m.IsGrant))
                    return;
            }

            context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
        }

        class PermissionData {
            public PermissionData(string permission)
            {
                var parts = permission.Split(':');

                Application = parts[0];
                Module = parts[1];
                Feature = parts[2];
                Permission = parts[3];
            }

            public string Application { get; }
            public string Module { get; }
            public string Feature { get; }
            public string Permission { get; }
        }

        public UserDetails GetUserDetails(IUserPrincipal userPrincipal)
        {
            return new UserDetails
            {
                Id = userPrincipal.AccountId,
                Name = userPrincipal.UserName,
                MarketId = userPrincipal.Market,
                // add other properties
                AppRoles = userPrincipal.ApplicationRole.Select(m => new AppRole
                {
                    Application = m.Application,
                    Role = m.Role
                }).ToArray(),
            };
        }
    }
}
