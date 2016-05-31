using brewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.DAL
{
    public class BrewardsRepository
    {
        private brewardsContext _context { get; set; }

        public BrewardsRepository()
        {
            _context = new brewardsContext();
        }
        public BrewardsRepository(brewardsContext context)
        {
            _context = context;
        }

        public List<Beer> GetAllBeers()
        {
            return _context.Beers.ToList();
        }

        public List<Brewery> GetAllBreweries()
        {
            return _context.Breweries.ToList();
        }

        public Brewery GetBrewery(string brewery_name)
        {
            Brewery req_Brewery = this.GetAllBreweries().Find(b => b.Brewery_Name == brewery_name);
            return req_Brewery;
        }

        internal ApplicationUser getUser(string user_id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == user_id);
        }

        public Brewery getBreweryById(int brewery_id)
        {
            return _context.Breweries.FirstOrDefault(b => b.BreweryId == brewery_id);
        }

        public Beer GetBeer(int beer)
        {
            return _context.Beers.FirstOrDefault(b => b.BeerId == beer);
        }

        public void AddPurchase(Userpurchase purchase)
        {

            //DateTime PointOfSale = DateTime.Now;
            _context.Beers.Attach(purchase.Beer_info);
            _context.Breweries.Attach(purchase.Brewery_info);

            //purchase.Beer_info = this.GetBeer(purchase.Beer_info.BeerId);
            //purchase.Brewery_info = this.getBreweryById(purchase.Brewery_info.BreweryId);
            //ApplicationUser found_user = _context.Users.FirstOrDefault(i => i.Id == user_Id);

            //object[] UpComps = new object[] { beer, brewery, user, POS };

            _context.User_purchases.Add(purchase);

            Rewardstatus punchcard = _context.Reward_statuses.FirstOrDefault(punchThere => punchThere.UserId.Id == purchase.Purchaser.Id && punchThere.Brewery_info.Brewery_Name == purchase.Brewery_info.Brewery_Name);

            if(punchcard == null)
            {
                Rewardstatus newPunchCard = new Rewardstatus { UserId = purchase.Purchaser, Brewery_info = purchase.Brewery_info, Number_purchased = 1 };
                _context.Reward_statuses.Add(newPunchCard);
            }
            else
            {
                punchcard.Number_purchased += 1;
            }
            _context.SaveChanges();

        }

        public void addBrewery(Brewery jackalope)
        {
            _context.Breweries.Add(jackalope);
        }

        public List<Userpurchase> getUserPurchases(string user_id)
        {

            return _context.User_purchases.Where(user => user.Purchaser.Id == user_id).ToList();
        }
    }
}