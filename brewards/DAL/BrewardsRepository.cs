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

        public bool AddPurchase(Beer beer, Brewery brewery, ApplicationUser user, DateTime POS)
        {
            bool success = true;

            //DateTime PointOfSale = DateTime.Now;
            //Beer found_beer = this.GetBeer(beer_Id);
           // Brewery found_brewery = this.getBreweryById(brewery_Id);
            //ApplicationUser found_user = _context.Users.FirstOrDefault(i => i.Id == user_Id);

            object[] UpComps = new object[] { beer, brewery, user, POS };

            if(UpComps.Any(i => i == null))
            {
                success = false;
            }
            else
            {
                _context.User_purchases.Add(new Userpurchase() { Beer_info = beer, Brewery_info = brewery, Purchaser = user, Purchase_date = POS });
                _context.SaveChanges();
            }

            return success;
        }

        public void addBrewery(Brewery jackalope)
        {
            _context.Breweries.Add(jackalope);
        }

        public IEnumerable<Userpurchase> getUserPurchases(string user_id)
        {
            IEnumerable<Userpurchase> pur = _context.User_purchases.Where(up => up.Purchaser.Id == user_id);
            return pur;
        }
    }
}