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
    public class BreweryController : ApiController
    {
        private BrewardsRepository _repo;

        public BreweryController()
        {
            _repo = new BrewardsRepository();
        }

        public BreweryController(BrewardsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Brewery> Get(string breweryCity)
        {
            IEnumerable<Brewery> cityBreweries = _repo.GetAllBreweries().FindAll(b => b.Brewery_city == breweryCity);
            return cityBreweries;
        }

    }
}
