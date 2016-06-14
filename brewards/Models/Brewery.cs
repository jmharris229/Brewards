using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace brewards.Models
{
    public class Brewery
    {
        //primary key
        public int BreweryId { get; set; }

        [MaxLength(100)]
        [Required]
        public string BreweryName { get; set; }

        //address fields start
        [MaxLength(75)]
        [Required]
        public string BreweryAddress { get; set; }

        [MaxLength(50)]
        [Required]
        public string BreweryCity { get; set; }

        [MaxLength(3), MinLength(2)]
        [Required]
        public string BreweryState { get; set; }

        [MaxLength(6), MinLength(5)]
        [Required]
        public string BreweryZip { get; set; }

        [Range(1000, 9999)]
        [NonSerialized]
        private int _breweryPin;
        
        public int BreweryPin { get { return _breweryPin; } set { _breweryPin = value; } }

        [MaxLength(11)]
        public string BreweryPhone { get; set; }

        [MaxLength(100)]
        public string BreweryUrl { get; set; }

        [MaxLength(600)]
        public string BreweryLogo { get; set; }

        //Collection of beers specific to brewery
        public virtual ICollection<Beer> BreweryBeers { get; set; }
    }
}