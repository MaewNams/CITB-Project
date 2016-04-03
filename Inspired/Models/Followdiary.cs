using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Followdiary
    {
        [Key]
        public int id { get; set; }
        public int diaryid { get; set; }
        public int userid { get; set; }
        public int latestchapterid { get; set; }

        [ForeignKey("diaryid")]
        public virtual Diary Diary { get; set; }

        [ForeignKey("userid")]
        public virtual Account Account { get; set; }

        [ForeignKey("latestchapterid")]
        public virtual Chapter Chapter { get; set; }
    }
}