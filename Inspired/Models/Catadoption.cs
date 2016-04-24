using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Catadoption
    {
        [Key]
        public int id { get; set; }
        public int catid { get; set; }
        public int adoptionid { get; set; }

        [ForeignKey("catid")]
        public virtual Cat Cat { get; set; }

        [ForeignKey("adoptionid")]
        public virtual Adoption Adoption { get; set; }
    }
}