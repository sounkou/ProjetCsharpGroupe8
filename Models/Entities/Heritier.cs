using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeritageApp.Models.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("herities")]
    public class Heritier
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int nomenclatureID { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public string Illustration { get; set; }
      // public int ADrID { get; set; }
        public virtual AyantDroit ayantDroit { get; set; }

        /*public Heritier(string Description, int Code, string Illustration)
        {
          
            this.Description = Description;
            this.Code = Code;
            this.Illustration = Illustration;
        }*/
    }
    
}
