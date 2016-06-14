using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class UserPurchaseViewModel
    {
        public int UserPurchaseViewModelID { get; set; }
        public virtual Brewery BreweryInfo { get; set; }
        public int NumberPurchased { get; set; }
        public virtual ICollection<Litebeer> PurchasedBeers { get; set; }
    }
}