﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("api/Roles")]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = roleManager.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }
    }
}
