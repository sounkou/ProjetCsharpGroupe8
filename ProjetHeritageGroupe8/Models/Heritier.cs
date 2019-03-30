using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHeritageGroupe8.Models
{
    [Table("Heritier")]
    public class Heritier
    {
        [Key]
        public int HeritierID { get; set; }
        public string description { get; set; }
        public int code { get; set; }
        public string  illustration { get; set; }
        public ICollection<AyantDroit> ayantDroits;
    }
}
