using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Userpurchase
    {
        //primary key
        public int UserpurchaseId { get; set; }

        public DateTime Purchase_date { get; set; }
          
        //navigation property for user object
        public virtual ApplicationUser UserId { get; set; }

        //navigation property for beer object
        public virtual Beer Beer_info { get; set; }

        //navigation property for brewery object
        public virtual Brewery Brewery_info { get; set; }

    }
}