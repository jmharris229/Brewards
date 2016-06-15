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
    public class BreweriesController : ApiController
    {
        private BrewardsRepository _repo;

        public BreweriesController()
        {
            _repo = new BrewardsRepository();
        }

        public BreweriesController(BrewardsRepository repo)
        {
            _repo = repo;
        }

        //gets a list of breweries by city name
        public IEnumerable<Brewery> GetBreweries(string breweryCity)
        {
            IEnumerable<Brewery> cityBreweries = _repo.GetAllBreweries().FindAll(b => b.BreweryCity == breweryCity);
            return cityBreweries;
        }
    }
}
