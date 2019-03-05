using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeritageApp.Models;
namespace HeritageApp.Models.Entities
{
    public class DbInitialise
    {
        public static void Initialize(HeritageDbContext db)
        {
            //db.Database.EnsureCreated();
            if (db.herities.Any())
            {
                return;
            }
            var heritiers = new Heritier[]
            {
                new Heritier{Description ="je suis un fils",Code=0, Illustration="test ulistration"},
                 new Heritier{Description ="je suis une mere",Code=1, Illustration="test ulistration 1"},
                  new Heritier{Description ="je suis un pere",Code=2, Illustration="test ulistration2"}
            };
            foreach (var h in heritiers)
            {
                db.herities.Add(h);
            }
            db.SaveChanges();
            var ayantdroits = new AyantDroit[]
            {
                new AyantDroit{Designation ="soeur de la defunte",Description="membre de la famille"},
                new AyantDroit{ Designation ="frere",Description="membre de la famille"}
            };
            foreach (var a in ayantdroits)
            {
                db.ayantdroits.Add(a);
            }
            db.SaveChanges();
        }
    }
}
