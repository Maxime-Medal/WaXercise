using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaXercise.Models;

namespace WaXercise.Data
{
    public class WaXerciseContext : DbContext
    {
        public WaXerciseContext (DbContextOptions<WaXerciseContext> options)
            : base(options)
        {
        }

        public DbSet<WaXercise.Models.People> People { get; set; } = default!;

        public DbSet<WaXercise.Models.Compagny> Compagny { get; set; } = default!;

        public DbSet<WaXercise.Models.JobPeriod> JobPeriod { get; set; } = default!;
    }
}
