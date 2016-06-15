using brewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using brewards.Services;
using Twilio;

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

        //gets the user object
        internal ApplicationUser getUser(string userId)
        {
            return _context.Users.FirstOrDefault(user => user.Id == userId);
        }

        //gets a specific beer
        public Beer GetBeer(int beer)
        {
            return _context.Beers.FirstOrDefault(b => b.BeerId == beer);
        }

        //gets all beers in beer table
        public List<Beer> GetAllBeers()
        {
            return _context.Beers.ToList();
        }

        //adds a new brewery to the context
        public void addBrewery(Brewery newBrewery)
        {
            _context.Breweries.Add(newBrewery);
        }

        //gets all breweries in brewery table
        public List<Brewery> GetAllBreweries()
        {
            return _context.Breweries.ToList();
        }

        //returns a specific brewery
        public Brewery GetBreweryByCoords(double lat, double lng)
        {
            Brewery requestedBrewery = _context.Breweries.FirstOrDefault(br => br.BreweryLat == lat && br.BreweryLng == lng);
            return requestedBrewery;
        }

        //gets a brewery by the id
        public Brewery getBreweryById(int breweryId)
        {
            return _context.Breweries.FirstOrDefault(b => b.BreweryId == breweryId);
        }

        //adds or updates a redemption to the reward status table
        internal int AddRedemption(RewardStatus redemption)
        {
            //statement to determine if punchcard already exists or not
            RewardStatus foundExistingPunchcard = _context.RewardStatuses.FirstOrDefault(punchcard => punchcard.BreweryInfo.BreweryId == redemption.BreweryInfo.BreweryId);

            //a punch card was found updates redeem date and saves changes otherwise it adds a new reward status item
            if(foundExistingPunchcard != null)
            {
                //updates punchcard redemption date to new redeem date
                foundExistingPunchcard.RedeemDate = redemption.RedeemDate;
                return _context.SaveChanges();
            }
            else
            {
                redemption.BreweryInfo = _context.Breweries.Find(redemption.BreweryInfo.BreweryId);
                _context.RewardStatuses.Add(redemption);
                return _context.SaveChanges();               
            }
        }

        //matches the entered pin with a pin in the database to confirm a true purchase
        internal bool MatchPin(int pin, string breweryName)
        {
            Brewery returnedBrewery = _context.Breweries.FirstOrDefault(brew => brew.BreweryPin == pin && brew.BreweryName == breweryName);
            if (returnedBrewery != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //adds a purhcase and if the count is at 8 on a punchcard sends Twilio text
        public void AddPurchase(Userpurchase purchase)
        {
            purchase.BreweryInfo = _context.Breweries.Find(purchase.BreweryInfo.BreweryId);
            purchase.BeerInfo = _context.Beers.Find(purchase.BeerInfo.BeerId);

            _context.UserPurchases.Add(purchase);
            _context.SaveChanges();

            IEnumerable<UserPurchaseViewModel> punchCompletionCheck = this.GetPunchPurchases(purchase.Purchaser.Id);

            if(punchCompletionCheck.Any(punchcard => punchcard.BreweryInfo.BreweryName == purchase.BreweryInfo.BreweryName && punchcard.NumberPurchased == 8)){
                var accountSid = "--";
                var authToken = "--";

                var twilio = new TwilioRestClient(accountSid, authToken);

                var message = twilio.SendMessage(
                    "+--",
                    "+--",
                    "CHEERS! There's nothing sweeter in life than free beer. head over to your Brewards app to redeem your free pour of the nectar of the gods!"
                    );
            }
        }

        //returns all of a users purchases
        public IEnumerable<UserPurchaseViewModel> GetAllPurchases(string userId)
        {
            List<Userpurchase> UserPurchases = _context.UserPurchases.Where(purchase => purchase.Purchaser.Id == userId).ToList();

            List<UserPurchaseViewModel> ViewModelPurchases = service.ToUserPurchaseViewModel(UserPurchases);
            return ViewModelPurchases;
        }

        //generates the view model for userpurchase punchcards
        public List<UserPurchaseViewModel> GetPunchPurchases(string userId)
        {
            //finds punchcards for a user
            List<RewardStatus> punchcards = _context.RewardStatuses.Where(reward => reward.User.Id == userId).ToList();

            List<Userpurchase> filteredPurchases = new List<Userpurchase>();

            //if the list of user cards is greater than 0 then loop through cards and create a list of purhcases for those breweries
            if(punchcards.Count > 0)
            {
                foreach (var punchcard in punchcards)
                {
                    List<Userpurchase> prefilteredPurchases = _context.UserPurchases.Include(p => p.BreweryInfo.BreweryBeers).Where(user => user.Purchaser.Id == userId && user.PurchaseDate > punchcard.RedeemDate && user.BreweryInfo.BreweryName == punchcard.BreweryInfo.BreweryName).ToList();
                    prefilteredPurchases.ForEach(delegate (Userpurchase purchase)
                    {
                        filteredPurchases.Add(purchase);
                    });
                }
            }
            else
            {
                filteredPurchases = _context.UserPurchases.Include(p => p.BreweryInfo.BreweryBeers).Where(user => user.Purchaser.Id == userId).ToList();
            }

            //send the list of filtered purchases to the view model method
            List<UserPurchaseViewModel> viewModelPurchases = service.ToUserPurchaseViewModel(filteredPurchases);
            return viewModelPurchases;
        }
    }
}