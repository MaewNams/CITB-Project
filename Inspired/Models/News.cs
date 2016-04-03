using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class News
    {   [Key]
        public int id { get; set; }
        public int topicid { get; set; }
        public string pic { get; set; }

        [ForeignKey("topicid")]
        public virtual Topic Topic { get; set; }
    }
}