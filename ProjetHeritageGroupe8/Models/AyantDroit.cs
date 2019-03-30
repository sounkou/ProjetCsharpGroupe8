using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetHeritageGroupe8.Models
{
    public class AyantDroit
    {
        public int AyantDroitID { get; set; }
        public string  nom { get; set; }
        public string  prenom { get; set; }
        public string  sexe { get; set; }
        public DateTime dateNaissance { get; set; }
        public string designation { get; set; }
        public string ImageADr { get; set; }
        public string description { get; set; }
        public DateTime DateCreation { get; set; }
        public int HeritierID { get; set; }
        public virtual Heritier typeHeritier { get; set; }
    }
}
