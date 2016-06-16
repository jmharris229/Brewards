using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class BreweryNews
    {
        public int BreweryNewsId { get; set; }

        public DateTime NewsDate { get; set; }

        public string NewsMessage { get; set; }

        public virtual Brewery BreweryInfo { get; set; }
    }
}