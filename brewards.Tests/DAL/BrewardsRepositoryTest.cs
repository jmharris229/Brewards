using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using brewards.DAL;
using Moq;
using System.Data.Entity;
using brewards.Models;
using System.Collections.Generic;
using System.Linq;


namespace brewards.Tests.DAL
{
    [TestClass]
    public class BrewardsRepositoryTest
    {
        Mock<brewardsContext> Mock_context { get; set; }
        BrewardsRepository repo { get; set; }

        List<Brewery> brewery_datasource { get; set; }
        Mock<DbSet<Brewery>> mock_brewery_table { get; set; }
        IQueryable<Brewery> brewery_data { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            Mock_context = new Mock<brewardsContext>();
            

            brewery_datasource = new List<Brewery>();
            mock_brewery_table = new Mock<DbSet<Brewery>>();

            repo = new BrewardsRepository(Mock_context.Object);
            brewery_data = brewery_datasource.AsQueryable();
        }

        void ConnectMockToDatastore()
        {
            // Telling our fake DbSet to use our datasource like something Queryable
            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.GetEnumerator()).Returns(brewery_data.GetEnumerator());
            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.ElementType).Returns(brewery_data.ElementType);
            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.Expression).Returns(brewery_data.Expression);
            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.Provider).Returns(brewery_data.Provider);

            // Tell our mocked VotrContext to use our fully mocked Datasource. (List<Poll>)
            Mock_context.Setup(m => m.Breweries).Returns(mock_brewery_table.Object);
        }
        [TestMethod]
        public void RepoEnsureICanCreateAnInstance()
        {
            Assert.IsNotNull(repo); 
        }
        [TestMethod]
        public void RepoEnsureICanGetBreweries()
        {

            List<Beer> beers = new List<Beer>
            {
                new Beer {
                BeerId = 1,
                Beer_name = "Thunder Ann",
                Beer_type = "APA",
                Beer_logo = "www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-thunderann-500x500.png" }
            };


            Brewery Jackalope = new Brewery()
            {
                BreweryId = 1,
                Brewery_Name = "Jackalope Brewing Co.",
                Brewery_address = "701 8th Avenue South",
                Brewery_city = "Nashville",
                Brewery_state = "TN",
                Brewery_zip = "37203",
                Brewery_phone = "6158734313",
                Brewery_url = "www.jackalopebrew.com",
                Brewery_logo = "www.drinkabeerandplayagame.com/wp-content/uploads/2015/06/jackalope_logo_trademark.jpg",
                Brewery_beers = beers
            };
            brewery_datasource.Add(Jackalope);
            ConnectMockToDatastore();

            int actual = repo.GetAllBreweries().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RepoEnsureICanGetSpecificBrewery()
        {

            List<Beer> beers = new List<Beer>
            {
                new Beer {
                BeerId = 1,
                Beer_name = "Thunder Ann",
                Beer_type = "APA",
                Beer_logo = "www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-thunderann-500x500.png" }
            };


            Brewery Jackalope = new Brewery()
            {
                BreweryId = 1,
                Brewery_Name = "Jackalope Brewing Co.",
                Brewery_address = "701 8th Avenue South",
                Brewery_city = "Nashville",
                Brewery_state = "TN",
                Brewery_zip = "37203",
                Brewery_phone = "6158734313",
                Brewery_url = "www.jackalopebrew.com",
                Brewery_logo = "www.drinkabeerandplayagame.com/wp-content/uploads/2015/06/jackalope_logo_trademark.jpg",
                Brewery_beers = beers
            };

            brewery_datasource.Add(Jackalope);
            ConnectMockToDatastore();
            Brewery expected = Jackalope;
            Brewery actual = repo.GetBrewery("Jackalope Brewing Co.");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepoEnsureICanAddPurchase()
        {
            ConnectMockToDatastore();
            List<Beer> beers = new List<Beer>
            {
                new Beer {
                BeerId = 1,
                Beer_name = "Thunder Ann",
                Beer_type = "APA",
                Beer_logo = "www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-thunderann-500x500.png" }
            };


            Brewery Jackalope = new Brewery()
            {
                BreweryId = 1,
                Brewery_Name = "Jackalope Brewing Co.",
                Brewery_address = "701 8th Avenue South",
                Brewery_city = "Nashville",
                Brewery_state = "TN",
                Brewery_zip = "37203",
                Brewery_phone = "6158734313",
                Brewery_url = "www.jackalopebrew.com",
                Brewery_logo = "www.drinkabeerandplayagame.com/wp-content/uploads/2015/06/jackalope_logo_trademark.jpg",
                Brewery_beers = beers
            };

            ApplicationUser user = new ApplicationUser();
            /* user.Id = "fake-user-id";
            repo.AddPurchase(beers.First(), Jackalope);*/

        }
    }
}
