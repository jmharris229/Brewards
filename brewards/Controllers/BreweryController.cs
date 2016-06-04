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

        //gets a list of breweries by city name
        public IEnumerable<Brewery> GetBreweries(string breweryCity)
        {
            IEnumerable<Brewery> cityBreweries = _repo.GetAllBreweries().FindAll(b => b.Brewery_city == breweryCity);
            return cityBreweries;
        }

        //gets a specific brewery by brewery name
        public IEnumerable<Brewery> GetBreweryByName(string breweryName)
        {
            IEnumerable<Brewery> brewery = _repo.GetBrewery(breweryName);
            return brewery;
        }

    }
}
