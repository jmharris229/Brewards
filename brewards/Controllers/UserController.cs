using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using brewards.DAL;
using Microsoft.AspNet.Identity;

namespace brewards.Controllers
{
    public class UserController : ApiController
    {
        private BrewardsRepository _repo = new BrewardsRepository();

        public UserController()
        {
            _repo = new BrewardsRepository();
        }

        public UserController(BrewardsRepository repo)
        {
            _repo = repo;
        }

        public bool Get()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}
