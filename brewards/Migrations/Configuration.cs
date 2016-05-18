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

            //Jackalope
            context.Breweries.AddOrUpdate(
                brewery => brewery.Brewery_Name,
                new Brewery { BreweryId= 1, Brewery_Name="Jackalope Brewing Co.", Brewery_address="701 8th Avenue South", Brewery_city="Nashville", Brewery_state="TN", Brewery_zip="37203", Brewery_phone="6158734313", Brewery_url= "www.jackalopebrew.com", Brewery_logo= "www.drinkabeerandplayagame.com/wp-content/uploads/2015/06/jackalope_logo_trademark.jpg", Brewery_beers= Jackalope_Beers  }
                );
            //Tennessee Brew works
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 2, Brewery_Name = "Tennessee Brew Works", Brewery_address = "809 Ewing Avenue", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37203", Brewery_phone = "6154360050", Brewery_url = "www.tnbrew.com", Brewery_logo = "www.tnbrew.com/sites/all/themes/tnbrew/img/logo.png", Brewery_beers = Jackalope_Beers }
                );
            //Bearded Iris Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 2, Brewery_Name = "Bearded Iris Brewing Co.", Brewery_address = "101 Van Buren St.", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37208", Brewery_phone = "", Brewery_url = "www.beardedirisbrewing.com", Brewery_logo = "www.mtsusidelines.com/wp-content/uploads/2016/02/MTSUSidelines_Lifestyles_Food_BeardedIrisLogo_FILE.jpg", Brewery_beers = Jackalope_Beers }
                );
            //Yazoo Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 2, Brewery_Name = "Yazoo Brewing Co.", Brewery_address = "901 Division St", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37207", Brewery_phone = "6158914649", Brewery_url = "www.yazoobrew.com", Brewery_logo = "www.yazoobrew.com/images/Yazoologo-Red.png", Brewery_beers = Jackalope_Beers }
                );
            //TailGate Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 2, Brewery_Name = "Tailgate Brewing Co.", Brewery_address = "7300 Charlotte Pike", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37209", Brewery_phone = "6158619842", Brewery_url = "www.tailgatebeer.com/", Brewery_logo = "www.tailgatebeer.com/wp-content/uploads/2015/04/beer_menu_tailgate.jpg", Brewery_beers = Jackalope_Beers }
                );
            //Southern Grist Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 2, Brewery_Name = "Southern Grist Brewing Co.", Brewery_address = "1201 Porter Rd", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37206", Brewery_phone = "6157271201", Brewery_url = "www.southerngristbrewing.com", Brewery_logo = "www.res.cloudinary.com/ratebeer/image/upload/w_400,c_limit/brew_26443.jpg", Brewery_beers = Jackalope_Beers }
                );
            //Black Abbey Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 2, Brewery_Name = "Black Abbey Brewing Co.", Brewery_address = "2952 Sidco Drive", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37204", Brewery_phone = "6157550070", Brewery_url = "www.blackabbeybrewing.com", Brewery_logo = "www.trademarks.justia.com/media/image.php?serial=85266168", Brewery_beers = Jackalope_Beers }
                );
        }
    }
}
