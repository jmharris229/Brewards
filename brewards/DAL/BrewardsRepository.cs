using brewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using brewards.Services;

namespace brewards.DAL
{
    public class BrewardsRepository
    {
        TransformationService service = new TransformationService();
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

        internal void AddRedemption(Rewardstatus redemption)
        {
            Rewardstatus found_existing_punchcard = _context.Reward_statuses.FirstOrDefault(punchcard => punchcard.Brewery_info.BreweryId == redemption.Brewery_info.BreweryId);

            if(found_existing_punchcard != null)
            {
                found_existing_punchcard.Redeem_date = redemption.Redeem_date;
                _context.SaveChanges();
            }
            else
            {
                redemption.Brewery_info = _context.Breweries.Find(redemption.Brewery_info.BreweryId);
                _context.Reward_statuses.Add(redemption);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Brewery> GetBrewery(string brewery_name)
        {
            IEnumerable<Brewery> req_Brewery = _context.Breweries.Where(br => br.Brewery_Name == brewery_name);
            return req_Brewery;
        }

        internal bool MatchPin(int pin, string brewery_name)
        {
            Brewery returnedBrewery = _context.Breweries.FirstOrDefault(brew => brew.Brewery_pin == pin && brew.Brewery_Name == brewery_name);
            if (returnedBrewery != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            purchase.Brewery_info = _context.Breweries.Find(purchase.Brewery_info.BreweryId);
            purchase.Beer_info = _context.Beers.Find(purchase.Beer_info.BeerId);

            _context.User_purchases.Add(purchase);
            _context.SaveChanges();
        }

        public void addBrewery(Brewery newBrewery)
        {
            _context.Breweries.Add(newBrewery);
        }

        public List<UserPurchaseViewModel> GetPunchPurchases(string user_id)
        {
            List<Rewardstatus> punchcards = _context.Reward_statuses.Where(reward => reward.User.Id == user_id).ToList();
            List<Userpurchase> filtered_purchases = new List<Userpurchase>();

            if(punchcards.Count > 0)
            {
                foreach (var punchcard in punchcards)
                {
                    List<Userpurchase> prefiltered_purchases = _context.User_purchases.Include(p => p.Brewery_info.Brewery_beers).Where(user => user.Purchaser.Id == user_id && user.Purchase_date > punchcard.Redeem_date).ToList();
                    prefiltered_purchases.ForEach(delegate (Userpurchase purchase)
                    {
                        filtered_purchases.Add(purchase);
                    });
                }
            }
            else
            {
                filtered_purchases = _context.User_purchases.Include(p => p.Brewery_info.Brewery_beers).Where(user => user.Purchaser.Id == user_id).ToList();
            }

            
            List<UserPurchaseViewModel> viewModelPurchases = service.ToUserPurchaseViewModel(filtered_purchases);
            return viewModelPurchases;
        }

        public IEnumerable<UserPurchaseViewModel> GetAllPurchases(string user_id)
        {
            List<Userpurchase> UserPurchases = _context.User_purchases.Where(purchase => purchase.Purchaser.Id == user_id).ToList();

            List<UserPurchaseViewModel> ViewModelPurchases = service.ToUserPurchaseViewModel(UserPurchases);
            return ViewModelPurchases;
        }
    }
}