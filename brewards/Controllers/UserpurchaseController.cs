﻿using brewards.DAL;
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
        
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PostPurchase(Userpurchase purchase)
        {

            bool PinMatch = _repo.MatchPin(purchase.Brewery_info.Brewery_pin, purchase.Brewery_info.Brewery_Name);

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
        
        public IEnumerable<UserPurchaseViewModel> Get(string filter)
        {
            bool boolfilter = Convert.ToBoolean(filter);
            string user_id = User.Identity.GetUserId();
            if (boolfilter)
            {
                return _repo.GetPunchPurchases(user_id);
            }
            else
            {
                return _repo.GetAllPurchases(user_id);
            }
        }

    }
}
