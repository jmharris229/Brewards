using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using brewards.DAL;
using Moq;
using brewards.Repository;
using brewards.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace brewards.Tests.Repository
{
    [TestClass]
    public class brewardsRepositoryTest
    {
        Mock<brewardsContext> mock_context { get; set; }
        brewardsRepository repo { get; set; }

        //breweries
        List<Brewery> breweries_datasource { get; set; }
        Mock<DbSet<Brewery>> mock_brewery_table { get; set; }
        IQueryable<Brewery> brewery_data { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<brewardsContext>();
            breweries_datasource = new List<Brewery>();
            mock_brewery_table = new Mock<DbSet<Brewery>>();

            repo = new brewardsRepository(mock_context.Object);

            brewery_data.AsQueryable();
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        void ConnectMockToDatastore()
        {

            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.GetEnumerator()).Returns(brewery_data.GetEnumerator());
            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.ElementType).Returns(brewery_data.ElementType);
            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.Expression).Returns(brewery_data.Expression);
            mock_brewery_table.As<IQueryable<Brewery>>().Setup(m => m.Provider).Returns(brewery_data.Provider);

            // Tell our mocked VotrContext to use our fully mocked Datasource. (List<Poll>)
            mock_context.Setup(m => m.Breweries).Returns(mock_brewery_table.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
