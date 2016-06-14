using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class RewardStatus
    {
        public int RewardstatusId { get; set; }       
        public DateTime RedeemDate { get; set; }

        //retrieves user object
        public virtual ApplicationUser User { get; set; }
        public virtual Brewery BreweryInfo { get; set; }
    }
}