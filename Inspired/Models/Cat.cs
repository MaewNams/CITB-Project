using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Cat
    {
        public int id { get; set; }
        public string name { get; set; }
        public string pic { get; set; }
        public int breed { get; set; }
        public int eyecolor { get; set; }
        public int coatpattern { get; set; }
        public int coatcolor { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime adoptdate { get; set; }
        public DateTime deathdate { get; set; }
        public string habit { get; set; }
        public string liked { get; set; }
        public string disliked { get; set; }
        public string description { get; set; }
        public string note { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Catbreeds> breeds { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Catcoatcolors> coatcolors { get; set; }

    }

}