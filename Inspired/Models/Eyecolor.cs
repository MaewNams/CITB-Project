using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Eyecolor
    {
        public int id { get; set; }
        public string name { get; set; }

        [InverseProperty("Eyecolor")]
        public virtual ICollection<Cat> Cats { get; set; }
    }
}