using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Catcoatcolor
    {
        [Key]
        public int id { get; set; }
        public int catid { get; set; }
        public int coatcolorid { get; set; }



        [ForeignKey("catid")]
        public virtual Cat Cat { get; set; }

        [ForeignKey("coatcolorid")]
        public virtual Coatcolor Coatcolor { get; set; }




    }
}