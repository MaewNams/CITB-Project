using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Chapter
    {
        [Key]
        public int id { get; set; }
        public int diaryid { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public DateTime timestamp { get; set; }


        [ForeignKey("diaryid")]
        public virtual Diary Diary { get; set; }

        [InverseProperty("Chapter")]
        public virtual ICollection<Chaptercomment> Chaptercomments { get; set; }

        [InverseProperty("Chapter")]
        public virtual ICollection<Followdiary> Followdiaries { get; set; }
    }
}