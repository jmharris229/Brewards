using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class User
    {
        //retrieves user id and sets as primary key
        public virtual ApplicationUser UserId { get; set; }
        public virtual ICollection<Userpurchase> User_purchases { get; set; }
    }
}