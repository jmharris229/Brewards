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
    public class BreweryNewsController : ApiController
    {
        private BrewardsRepository _repo;

        public BreweryNewsController()
        {
            _repo = new BrewardsRepository();
        }

        public BreweryNewsController(BrewardsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<BreweryNewsViewModel> GetBreweryNews(string breweryCity)
        {
            return _repo.getNews(breweryCity);
        }
    }
}
