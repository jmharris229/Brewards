using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace brewards.Models
{
    public class Beer
    {
        //primary key
        public int BeerId { get; set; }

        [MaxLength(500)]
        [Required]
        public string BeerName { get; set; }

        [MaxLength(50)]
        [Required]
        public string BeerType { get; set; }

        [MaxLength(600)]
        public string BeerLogo { get; set; }
    
        //navigation key for brewery id
        public int BreweryId { get; set; }

    }
}