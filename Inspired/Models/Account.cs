using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        public int provinceid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public int usertypeid { get; set; }

        public string pic { get; set; }

        [ForeignKey("provinceid")]
        public virtual Province Province { get; set; }

        [ForeignKey("usertypeid")]
        public virtual Usertype Usertype { get; set; }


        [InverseProperty("Account")]
        public virtual ICollection<Article> Articles { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Adopter> Adopters { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Cat> Cats { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Chaptercomment> Chaptercomments { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Diary> Diaries { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Favoritetopic> Favoritetopics { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Followdiary> Followdiaries { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Followtopic> Followtopics { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Reporttopic> Reporttopics { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Topic> Topics { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Topiccomment> Topiccomments { get; set; }
    }
}