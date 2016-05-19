using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Userpurchase
    {
        public int UserpurchaseId { get; set; }

        //retrieves user ID
        public virtual ApplicationUser UserId { get; set; }
        public int BeerId { get; set; }
        public DateTime Purchase_date { get; set; }
    }
}