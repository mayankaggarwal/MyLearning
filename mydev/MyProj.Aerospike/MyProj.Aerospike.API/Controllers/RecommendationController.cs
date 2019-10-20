using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Aerospike.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProj.DataSource.Contracts;
using Newtonsoft.Json.Linq;

namespace MyProj.Aerospike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        IDataSource _source;
        public RecommendationController(IDataSource source)
        {
            _source = source;
        }

        [Route("products/{customerId:long}")]
        public async Task<IActionResult> Get(long customerId)
        {
            var obj = _source.Get<JObject>($"{customerId:000000000000000}");
            if (obj != null)
                return StatusCode(200, obj);
            else
                return StatusCode(404);
        }
    }
}