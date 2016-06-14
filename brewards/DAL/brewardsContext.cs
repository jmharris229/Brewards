using brewards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace brewards.DAL
{
    public class brewardsContext : ApplicationDbContext
    {
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<RewardStatus> RewardStatuses { get; set; }
        public virtual DbSet<Userpurchase> UserPurchases { get; set; }
    }
}