using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Userpurchase
    {
        //primary key
        public int UserPurchaseId { get; set; }

        public DateTime PurchaseDate { get; set; }
          
        //navigation property for user object
        public virtual ApplicationUser Purchaser { get; set; }

        //navigation property for beer object
        public virtual Beer BeerInfo { get; set; }

        //navigation property for brewery object
        public virtual Brewery BreweryInfo { get; set; }

    }
}