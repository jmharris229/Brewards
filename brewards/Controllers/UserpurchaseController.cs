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
        
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PostPurchase(Userpurchase purchase)
        {
            string user_id = User.Identity.GetUserId();
            ApplicationUser user = _repo.getUser(user_id);
            DateTime POS = DateTime.Now;
            Beer beer = purchase.Beer_info;
            Brewery brewery = purchase.Brewery_info;
            bool success = _repo.AddPurchase(beer, brewery, user, POS);

            if (success)
            {
                return StatusCode(HttpStatusCode.OK);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }
        
        public IEnumerable<Userpurchase> Get()
        {
            string user_id = User.Identity.GetUserId();
           
            IEnumerable<Userpurchase> up = _repo.getUserPurchases(user_id);

            return up;
        }

    }
}
