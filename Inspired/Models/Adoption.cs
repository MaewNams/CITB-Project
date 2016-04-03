using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Adoption
    {
        [Key]
        public int id { get; set; }
        public int catid { get; set; }
        public int provinceid { get; set; }
        public int topicid { get; set; }
        public string condition { get; set; }
        public string status { get; set; }

        [Required]
        public virtual Cat Cat { get; set; }

        [ForeignKey("provinceid")]
        public virtual Province Province { get; set; }

        [ForeignKey("topicid")]
        public virtual Topic Topic { get; set; }

        [InverseProperty("Adoption")]
        public virtual ICollection<Adopter> Adopters { get; set; }
    }
}