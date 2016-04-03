using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Province
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Account> Accounts { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Adoption> Adoptions { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Event> Events { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Findowner> Findowners { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Followtopic> Followtopics { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Lostcat> Lostcats { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<SOS> SOSs { get; set; }
    }
}