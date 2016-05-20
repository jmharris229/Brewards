using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace brewards.Models
{
    public class Beer
    {
        //primary key
        public int BeerId { get; set; }

        [MaxLength(500)]
        [Required]
        public string Beer_name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Beer_type { get; set; }

        [MaxLength(600)]
        public string Beer_logo { get; set; }

        //navigation property for brewery object
        //public virtual Brewery Brewery_info { get; set; }

        //collection of purchases for each beer
        //public virtual ICollection<Userpurchase> Beer_purchases { get; set; }
    }
}