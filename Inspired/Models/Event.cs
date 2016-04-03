using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Event
    {
        [Key]
        public int id { get; set; }
        public int topicid { get; set; }
        public string pic { get; set; }
        public string place { get; set; }
        public int provinceid { get; set; }
        public string contact { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }

        [ForeignKey("topicid")]
        public virtual Topic Topic { get; set; }

        [ForeignKey("provinceid")]
        public virtual Province Province { get; set; }


    }
}