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
        
        /*[ResponseType(typeof(Userpurchase))]
        public IHttpActionResult PostPurchase(Userpurchase purchase)
        {
            string user_id = User.Identity.GetUserId();
            ApplicationUser user = _repo.GetUser(user_id);

            _repo.AddPurchase(purchase.Beer_info, purchase.Brewery_info, purchase.Purchaser);
            return View();
        }*/


    }
}
