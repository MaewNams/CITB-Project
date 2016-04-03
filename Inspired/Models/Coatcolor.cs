using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Coatcolor
    {
        public int id { get; set; }
        public string name { get; set; }

        [InverseProperty("Coatcolor")]
        public virtual ICollection<Catcoatcolor> Coatcolors { get; set; }

    }
}