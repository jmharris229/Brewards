using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public int BreweryId { get; set; }
        public string Beer_name { get; set; }
        public string Beer_type { get; set; }
        public string Beer_logo { get; set; }
    }
}