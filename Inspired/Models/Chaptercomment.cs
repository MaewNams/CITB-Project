using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Chaptercomment
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public int chapterid { get; set; }
        public string detail { get; set; }
        public DateTime timestamp { get; set; }

        [ForeignKey("userid")]
        public virtual Account Account { get; set; }

        [ForeignKey("chapterid")]
        public virtual Chapter Chapter { get; set; }

    }
}