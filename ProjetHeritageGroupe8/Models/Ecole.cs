using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHeritageGroupe8.Models
{
    [Table("Ecole")]
    public class Ecole
    {
        [Key]
        public int EcoleID { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public ICollection<Heritage> heritages { get; set; }
        public int RegleID { get; set; }
        public virtual Regle Regles { get; set; }
    }
}
