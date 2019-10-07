using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProj.Aerospike.API.Services;

namespace MyProj.Aerospike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        public RecommendationController(IAerospikeClient dbClient,IDataModeller dataModeller)
        {

        }
    }
}