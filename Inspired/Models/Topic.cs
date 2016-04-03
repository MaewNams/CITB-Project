using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Topic
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public int userid { get; set; }
        public DateTime timestamp { get; set; }
        public int topictypeid { get; set; }

        [ForeignKey("userid")]
        public virtual Account Account { get; set; }

        [ForeignKey("topictypeid")]
        public virtual Topictype Topictype { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<Adoption> Adoptions { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<Event> Events { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<Favoritetopic> Favoritetopics { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<Findowner> Findowners { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<Lostcat> Lostcats { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<News> News { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<Reporttopic> Reporttopics { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<SOS> SOSs { get; set; }

        [InverseProperty("Topic")]
        public virtual ICollection<Topiccomment> Topiccomments { get; set; }
    }
}