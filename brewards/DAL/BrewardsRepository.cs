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

        public List<UserPurchaseViewModel> getUserPurchases(string user_id)
        {
            List<Userpurchase> purchases = _context.User_purchases.Include(p => p.Brewery_info.Brewery_beers).Where(user => user.Purchaser.Id == user_id).ToList();
            List<UserPurchaseViewModel> viewModelPurchases = service.ToUserPurchaseViewModel(purchases);
            return viewModelPurchases;
        }
    }
}