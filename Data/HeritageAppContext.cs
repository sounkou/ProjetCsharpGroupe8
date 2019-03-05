using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeritageApp.Models.Entities;

namespace HeritageApp.Models
{
    public class HeritageAppContext : DbContext
    {
        public HeritageAppContext (DbContextOptions<HeritageAppContext> options)
            : base(options)
        {
        }

        public DbSet<HeritageApp.Models.Entities.AyantDroit> AyantDroit { get; set; }

        public DbSet<HeritageApp.Models.Entities.Heritier> Heritier { get; set; }
    }
}
