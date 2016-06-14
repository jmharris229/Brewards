using brewards.DAL;
using brewards.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;
using System.Collections;
using Twilio;

namespace brewards.Controllers
{
    public class UserpurchaseController : ApiController
    {
        private BrewardsRepository _repo;

        public UserpurchaseController()
        {
            _repo = new BrewardsRepository();
        }

        public UserpurchaseController(BrewardsRepository repo)
        {
            _repo = repo;
        }
        
        //posts a user pruchase to the user purchase table
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PostPurchase(Userpurchase purchase)
        {
            //checks to see if the post brewery pin matches a specific breweries pin number
            bool pinMatch = _repo.MatchPin(purchase.BreweryInfo.BreweryPin, purchase.BreweryInfo.BreweryName);

            //if there's a match updates the purchase date and adds to table
            if (pinMatch)
            {
                string user_id = User.Identity.GetUserId();
                purchase.Purchaser = _repo.getUser(user_id);
                purchase.PurchaseDate = DateTime.Now;
                _repo.AddPurchase(purchase);
                return Ok(purchase);
            }
            else
            {
                return NotFound();
            }
        }
        
        //gets the view model user purchase list
        public IEnumerable<UserPurchaseViewModel> Get(string filter)
        {
            bool boolFilter = Convert.ToBoolean(filter);
            string userId = User.Identity.GetUserId();
            if (boolFilter)
            {
                return _repo.GetPunchPurchases(userId);
            }
            else
            {
                return _repo.GetAllPurchases(userId);
            }
        }

    }
}
