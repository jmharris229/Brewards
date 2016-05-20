using brewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.DAL
{
    public class BrewardsRepository
    {
        private brewardsContext _context { get; set; }

        public BrewardsRepository()
        {
            _context = new brewardsContext();
        }
        public BrewardsRepository(brewardsContext context)
        {
            _context = context;
        }

        public List<Beer> GetAllBeers()
        {

            return _context.Beers.ToList();

            /*IEnumerable<Beer> Beers = _context.Beers;
            IEnumerable<Brewery> Breweries = _context.Breweries;

            var joinQuery = from beer in Beers
                            join brewery in Breweries on beer.BreweryId equals brewery.BreweryId
                            select new Beer { BeerId = beer.BeerId, Beer_name = beer.Beer_name, beer.Brewery_Name = brewery.Brewery_Name, Beer_type = beer.Beer_type, Beer_logo = beer.Beer_logo };

            //List<Beer> beers = joinQuery.Cast<Beer>().ToList();

            return joinQuery.ToList();*/
        }

        public List<Brewery> GetAllBreweries()
        {
            return _context.Breweries.ToList();
        }
    }
}