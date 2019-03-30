using Microsoft.EntityFrameworkCore;
using ProjetHeritageGroupe8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetHeritageGroupe8.Data
{
    public class HeritageDbContext:DbContext
    {
        public HeritageDbContext(DbContextOptions<HeritageDbContext> options) : base(options)
        {
        }

       
        public DbSet<Heritier> heritiers { get; set; }
        public DbSet<Heritage> heritages { get; set; }
        public DbSet<Biens> Biens { get; set; }
        public DbSet<Regle> regles { get; set; }
        public DbSet<Source> sources { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }
        public DbSet<ProjetHeritageGroupe8.Models.Ecole> Ecole { get; set; }
        public DbSet<ProjetHeritageGroupe8.Models.AyantDroit> AyantDroit { get; set; }


    }
}
