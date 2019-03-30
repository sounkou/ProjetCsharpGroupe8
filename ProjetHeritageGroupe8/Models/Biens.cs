using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetHeritageGroupe8.Models
{
    public class Biens
    {
        public int BiensID { get; set; }
        public string description { get; set; }
        public ICollection<Heritage> heritages { get; set; }

    }
}
