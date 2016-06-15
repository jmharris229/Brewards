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

        public Brewery GetBreweryByCoords(string breweryCoords)
        {
            string[] coords = breweryCoords.Split(',');
            Brewery currentBrewery = _repo.GetBreweryByCoords(Convert.ToDouble(coords[0]), Convert.ToDouble(coords[1]));
            return currentBrewery;
        }
    }
}
