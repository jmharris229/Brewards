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

        [HttpPut]
        public IHttpActionResult PUT(Rewardstatus redemption)
        {
            string user_id = User.Identity.GetUserId();
            redemption.User = _repo.getUser(user_id);
            redemption.Redeem_date = DateTime.Now;
            _repo.AddRedemption(redemption);
            return Ok(redemption);
        }

    }
}
