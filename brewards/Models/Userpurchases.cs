using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class Userpurchases
    {
        public int UserpurchaseId { get; set; }
        public int UserId { get; set; }
        public int BeerId { get; set; }
        public DateTime Purchase_date { get; set; }
    }
}