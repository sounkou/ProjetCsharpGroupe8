using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHeritageGroupe8.Models
{
    [Table("Source")]
    public class Source
    {
        [Key]
        public int SourceID { get; set; }
        public string designation { get; set; }
        public string commentaire { get; set; }
        public ICollection<Regle> regles { get; set; }
    }
}
