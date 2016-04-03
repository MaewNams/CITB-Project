using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Followtopic
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public int topictypeid { get; set; }
        public int provinceid { get; set; }

        [ForeignKey("userid")]
        public virtual Account Account { get; set; }

        [ForeignKey("topictypeid")]
        public virtual Topictype Topictype { get; set; }

        [ForeignKey("provinceid")]
        public virtual Province Province { get; set; }
    }
}