using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Topictype
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int usertypeid { get; set; }

        [ForeignKey("usertypeid")]
        public virtual Usertype Usertype { get; set; }

        [InverseProperty("Topictype")]
        public virtual ICollection<Followtopic> Followtopics { get; set; }

        [InverseProperty("Topictype")]
        public virtual ICollection<Topic> Topics { get; set; }
    }
}