using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Adopter
    {
        [Key]
        public int id { get; set; }
        public int adoptionid { get; set; }
        public int userid { get; set; }
        public string contact { get; set; }
        public string status { get; set; }

        [ForeignKey("adoptionid")]
        public virtual Adoption Adoption { get; set; }

        [ForeignKey("userid")]
        public virtual Account Account { get; set; }

    }
}