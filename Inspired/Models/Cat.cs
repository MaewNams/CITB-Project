using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Cat
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string lifestage { get; set; }
        public string pic { get; set; }
        public int eyecolorid { get; set; }
        public int coatpatternid { get; set; }
        public int tailid { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime adoptdate { get; set; }
        public DateTime deathdate { get; set; }
        public string habit { get; set; }
        public string liked { get; set; }
        public string disliked { get; set; }
        public string description { get; set; }
        public string note { get; set; }
        public int status { get; set; }

        [ForeignKey("userid")]
        public virtual Account Account { get; set; }

        [ForeignKey("eyecolorid")]
        public virtual Eyecolor Eyecolor{ get; set; }

        [ForeignKey("coatpatternid")]
        public virtual Coatpattern Coatpattern { get; set; }

        [ForeignKey("tailid")]
        public virtual Tail Tail { get; set; }

        [InverseProperty("Cat")]
        public virtual Adoption Adoption { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Catbreed> Catbreeds { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Catcoatcolor> Catcoatcolors { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Catdiary> Catdiaries { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Findowner> Findowner { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Lostcat> Lostcats { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<SOS> SOSs { get; set; }

    }

}