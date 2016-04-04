using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Article
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string pic { get; set; }
        public DateTime timestamp { get; set; }

        [ForeignKey("userid")]
        public virtual Account Account { get; set; }


    }
}