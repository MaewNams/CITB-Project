using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Tail
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        [InverseProperty("Tail")]
        public virtual ICollection<Cat> Cats { get; set; }
    }
}