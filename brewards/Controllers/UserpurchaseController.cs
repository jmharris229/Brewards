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
        
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PostPurchase(Userpurchase purchase)
        {
            bool PinMatch = _repo.MatchPin(purchase.Brewery_info.Brewery_pin);

            if (PinMatch)
            {
                string user_id = User.Identity.GetUserId();
                purchase.Purchaser = _repo.getUser(user_id);
                purchase.Purchase_date = DateTime.Now;

                _repo.AddPurchase(purchase);

                return Ok(purchase);
            }
            else
            {
                return NotFound();
            }
        }
        
        public IEnumerable<UserPurchaseViewModel> Get()
        {
            string user_id = User.Identity.GetUserId();
            return _repo.getUserPurchases(user_id);
        }

    }
}
