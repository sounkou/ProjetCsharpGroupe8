using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHeritageGroupe8.Models
{
    [Table("Regle")]
    public class Regle
    {
        [Key]
        public int RegleID { get; set; }
        public string description { get; set; }
        public string commentaire { get; set; }
        public ICollection<Ecole> ecoles { get; set; }
    }
}
