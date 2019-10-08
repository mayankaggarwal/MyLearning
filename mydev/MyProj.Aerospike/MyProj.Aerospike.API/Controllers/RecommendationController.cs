using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Aerospike.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProj.Aerospike.API.Services;
using Newtonsoft.Json.Linq;

namespace MyProj.Aerospike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        IAerospikeClient client;
        public RecommendationController(IAerospikeClient dbClient,IDataModeller dataModeller)
        {
            client = dbClient;
        }

        [Route("products/{customerId:long}")]
        public async Task<IActionResult> Get(long customerId)
        {
            var key = new Key("test", "myset", $"{customerId:000000000000000}");
            var result = client.Get(null, key);
            JObject obj = JObject.Parse(result.GetString("recommendation"));
            return this.StatusCode(200, obj);
        }
    }
}