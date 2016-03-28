using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Breed
    {
        public int id { get; set; }
        public string name { get; set; }


        [InverseProperty("Breed")]
        public virtual ICollection<Catbreeds> breeds { get; set; }

    }
}