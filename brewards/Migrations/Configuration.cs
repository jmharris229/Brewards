namespace brewards.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<brewards.DAL.brewardsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(brewards.DAL.brewardsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<Beer> Jackalope_Beers = new List<Beer>
            {
                new Beer {BeerId=1, Beer_name="Thunder Ann", BreweryId=1, Beer_type="APA", Beer_logo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-thunderann-500x500.png"},
                new Beer {BeerId=2, Beer_name="Rompo", BreweryId=1, Beer_type="Red Rye Ale", Beer_logo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jackalope-rompocirc-500x500.png"},
                new Beer {BeerId=3, Beer_name="Bearwalker", BreweryId=1, Beer_type="Brown Ale", Beer_logo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jackalope-bearwalker-500x500.png"},
                new Beer {BeerId=4, Beer_name="Leghorn", BreweryId=1, Beer_type="Rye IPA", Beer_logo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-leghorn-500x500.png"},
            };

            context.Breweries.AddOrUpdate(
                brewery => brewery.Brewery_Name,
                new Brewery { BreweryId= 1, Brewery_Name="Jackalope Brewing Co.", Brewery_address="701 8th Avenue South", Brewery_city="Nashville", Brewery_state="TN", Brewery_zip="37203", Brewery_phone="6158734313", Brewery_url= "www.jackalopebrew.com", Brewery_logo= "www.drinkabeerandplayagame.com/wp-content/uploads/2015/06/jackalope_logo_trademark.jpg", Brewery_beers= Jackalope_Beers  }
                );
        }
    }
}
