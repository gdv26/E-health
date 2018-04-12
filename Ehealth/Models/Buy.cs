using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Ehealth.Models;

namespace Ehealth.Models
{
    public class Buy
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Program Program { get; set; }

        public DateTime DateBought { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}