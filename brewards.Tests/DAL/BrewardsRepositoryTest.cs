using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using brewards.DAL;
using brewards;
using Moq;
using brewards.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace brewards.Tests.DAL
{
    [TestClass]
    public class BrewardsRepositoryTest
    {
        Mock<brewardsContext> mock_context { get; set; }
        BrewardsRepository repo { get; set; } // Injects mocked (fake) VotrContext

        // Polls
        List<Beer> Beer_datasource { get; set; }
       // Mock<DbSet<Beer>> mock_Beer_table { get; set; } // Fake Polls table
        IQueryable<Beer> Beer_data { get; set; }// Turns List<Poll> into something we can query with LINQ


        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<brewardsContext>();

            Beer_datasource = new List<Beer>();

           // mock_Beer_table = new Mock<DbSet<Beer>>();

            repo = new BrewardsRepository(mock_context.Object);
            Beer_data = Beer_datasource.AsQueryable();
        }

        void ConnectMocksToDatastore()
        {
           /* mock_Beer_table.As<IQueryable<Beer>>().Setup(m => m.GetEnumerator()).Returns(Beer_data.GetEnumerator());
            mock_Beer_table.As<IQueryable<Beer>>().Setup(m => m.ElementType).Returns(Beer_data.ElementType);
            mock_Beer_table.As<IQueryable<Beer>>().Setup(m => m.Expression).Returns(Beer_data.Expression);
            mock_Beer_table.As<IQueryable<Beer>>().Setup(m => m.Provider).Returns(Beer_data.Provider);*/

           // mock_context.Setup(m => m.Beers).Returns(mock_Beer_table.Object);
        }


        [TestMethod]
        public void RepoEnsureICanGetAllBeers()
        {

        }
    }
}
