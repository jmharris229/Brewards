using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace brewards.Models
{
    public class Brewery
    {
        public int BreweryId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Brewery_Name { get; set; }

        //address fields
        [MaxLength(75)]
        [Required]
        public string Brewery_address { get; set; }

        [MaxLength(50)]
        [Required]
        public string Brewery_city { get; set; }

        [MaxLength(3), MinLength(2)]
        [Required]
        public string Brewery_state { get; set; }

        [MaxLength(6), MinLength(5)]
        [Required]
        public string Brewery_zip { get; set; } 

        /*    
        public int Brewery_longitude { get; set; }
        public int Brewery_latitude { get; set; }
        */

        [MaxLength(15), MinLength(10)]
        public string Brewery_phone { get; set; }

        [MaxLength(100)]
        [Required]
        public string Brewery_url { get; set; }

        [MaxLength(600)]
        [Required]
        public string Brewery_logo { get; set; }

        //Collection of beers specific to brewery
        public virtual ICollection<Beer> Brewery_beers { get; set; }
    }
}