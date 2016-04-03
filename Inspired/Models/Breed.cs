using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Breed
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string detail { get; set; }

        [InverseProperty("Breed")]
        public virtual ICollection<Catbreed> Catsbreeds { get; set; }

    }
  
}