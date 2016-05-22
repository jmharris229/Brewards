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

        public void AddPurchase(Beer beer, Brewery brewery, ApplicationUser user)
        {
            DateTime PointOfSale = DateTime.Now;
            Userpurchase added_purchase = new Userpurchase() { Beer_info = beer, Brewery_info = brewery, Purchaser = user, Purchase_date = PointOfSale};

            _context.User_purchases.Add(added_purchase);
            _context.SaveChanges();
        }
    }
}