using brewards.DAL;
using brewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace brewards.Controllers
{
    public class BeerController : ApiController
    {
        private BrewardsRepository _repo;

        public BeerController()
        {
            _repo = new BrewardsRepository();
        }

        public BeerController(BrewardsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Beer> Get()
        {
            return _repo.GetAllBeers();
        }
    }
}
