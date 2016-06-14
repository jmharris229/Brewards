using brewards.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using brewards.Models;
using Microsoft.AspNet.Identity;

namespace brewards.Controllers
{
    public class RewardstatusController : ApiController
    {
        private BrewardsRepository _repo;

        public RewardstatusController()
        {
            _repo = new BrewardsRepository();
        }

        public RewardstatusController(BrewardsRepository repo)
        {
            _repo = repo;
        }

        //put request to update the reward status table
        [HttpPut]
        public IHttpActionResult PUT(RewardStatus redemption)
        {
            string userId = User.Identity.GetUserId();
            redemption.User = _repo.getUser(userId);
            redemption.RedeemDate = DateTime.Now;
            int redeemed = _repo.AddRedemption(redemption);
            if (redeemed == 1)
            {
                return Ok(redemption);
            }
            else
            {
                return NotFound();
            }           
        }
    }
}
