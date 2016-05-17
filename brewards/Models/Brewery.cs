using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Brewery
    {
        public int BreweryId { get; set; }
        public int Brewery_longitude { get; set; }
        public int Brewery_latitude { get; set; }
        public string Brewery_phone { get; set; }
        public string Brewery_url { get; set; }
        public string Brewery_logo { get; set; }
    }
}