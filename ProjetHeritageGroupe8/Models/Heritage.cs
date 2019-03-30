using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHeritageGroupe8.Models
{
    [Table("Heritage")]
    public class Heritage
    {
        [Key]
        public int HeritageID { get; set; }
        public string description { get; set; }
        public DateTime DateDeces { get; set; }
        public DateTime DateHeritage { get; set; }
        public int EcoleID { get; set; }
        public virtual Ecole Ecole { get; set; }
        public float montant { get; set; }
        public int BiensID { get; set; }
        public virtual Biens Biens { get; set; }


    }
}
