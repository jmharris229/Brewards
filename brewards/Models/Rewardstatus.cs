using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Rewardstatus
    {
        public int RewardstatusId { get; set; }       
        public DateTime Redeem_date { get; set; }

        //retrieves user object
        public virtual ApplicationUser User { get; set; }
        public virtual Brewery Brewery_info { get; set; }
    }
}