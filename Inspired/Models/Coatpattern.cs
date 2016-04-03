using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Coatpattern
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string pic { get; set; }

        [InverseProperty("Coatpattern")]
        public virtual ICollection<Cat> Cats { get; set; }
    }
}