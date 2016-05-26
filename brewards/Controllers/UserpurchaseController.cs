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
        public IHttpActionResult PostPurchase(int beer, int brewery)
        {
            string user_id = User.Identity.GetUserId();

            bool success = _repo.AddPurchase(beer, brewery, User.Identity.GetUserId());

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
