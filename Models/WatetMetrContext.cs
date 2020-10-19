using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

namespace Test.Models
{
    public class WaterMetrContext : DbContext
    {
        
            public DbSet<Home> Homes { get; set; }
            public DbSet<WaterMetr> WaterMetrs { get; set; }


    }
}