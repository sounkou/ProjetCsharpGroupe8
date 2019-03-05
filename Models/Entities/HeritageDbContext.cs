using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeritageApp.Models.Entities
{
    public class HeritageDbContext : DbContext
    {
        public HeritageDbContext(DbContextOptions<HeritageDbContext> options):base(options) 
        {
            
        }
        public DbSet<Heritier> herities { get; set; }
        public DbSet<AyantDroit> ayantdroits { get; set; }
    }
}
