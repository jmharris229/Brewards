using brewards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace brewards.DAL
{
    public class brewardsContext : DbContext
    {
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<Rewardstatus> Rstatuses { get; set; }
        public virtual DbSet<Userpurchase> Userpurchases { get; set; }
    }
}