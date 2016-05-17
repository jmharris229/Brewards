using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Rewardstatus
    {
        public int RewardstatusId { get; set; }
        public int BreweryId { get; set; }

        //retrieves user id
        public virtual ApplicationUser UserId { get; set; }
        public int Number_purchased { get; set; }
    }
}