using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class SOS
    {
        [Key]
        public int id { get; set; }
        public int catid { get; set; }
        public int topicid { get; set; }
        public int provinceid { get; set; }
        public string hospital { get; set; }

        [ForeignKey("catid")]
        public virtual Cat Cat { get; set; }

        [ForeignKey("topicid")]
        public virtual Topic Topic { get; set; }

        [ForeignKey("provinceid")]
        public virtual Province Province { get; set; }
    }
}