using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetHeritageGroupe8.Models
{
    public enum TypeUtilisateur
    {
        AUTH,NONAUTH

    }
    [Table("Utilisateur")]
    public class Utilisateur
    {
        [Key]
        public int UtilisateurID { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string passWord { get; set; }
        public TypeUtilisateur typeUtilisateur { get; set; }
        
    }
}
