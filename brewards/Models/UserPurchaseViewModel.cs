using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class UserPurchaseViewModel
    {
        public int UserPurchaseViewModelID { get; set; }
        public string brewery_name { get; set; }
        public int number_purchased { get; set; }
        public virtual ICollection<Litebeer> purchased_beers { get; set; }
    }
}