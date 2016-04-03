﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inspired.Models
{
    public class Usertype
    {
        [Key]
        public int id { get; set; }
        public int topicid { get; set; }

        [InverseProperty("Usertype")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}