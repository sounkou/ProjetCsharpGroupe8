using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeritageApp.Models.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("ayantdroits")]
    public class AyantDroit
    {
        [Key]
        public int ayantDroitID { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public ICollection<Heritier> TypeHeritier { get; set; }
    }
}
