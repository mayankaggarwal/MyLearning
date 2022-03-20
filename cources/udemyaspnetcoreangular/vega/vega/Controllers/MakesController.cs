using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistance;

namespace vega.Controllers
{
     public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        public MakesController(VegaDbContext context,IMapper mapper)
        {
            this.context = context;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes =  await context.Makes.Include(m=>m.Models).ToListAsync();
            return Mapper.Map<List<Make>,List<MakeResource>>(makes);
        }
    }
}