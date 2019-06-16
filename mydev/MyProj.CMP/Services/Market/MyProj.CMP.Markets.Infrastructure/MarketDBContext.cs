using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Markets.Infrastructure
{
    public class MarketDBContext:DbContext
    {
        public MarketDBContext(DbContextOptions<MarketDBContext> options) : base(options) { }
    }
}
