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
                new Beer {BeerId=4, Beer_name="Leghorn", BreweryId=1, Beer_type="Rye IPA", Beer_logo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-leghorn-500x500.png"}
            };

            List<Beer> TBW_Beers = new List<Beer>
            {
                new Beer {BeerId=5, Beer_name="Southern Wit", BreweryId=2, Beer_type="Belgian White", Beer_logo="www.untappd.akamaized.net/site/beer_logos/beer-334613_25944_sm.jpeg"},
                new Beer {BeerId=6, Beer_name="Extra Easy", BreweryId=2, Beer_type="American ESB", Beer_logo="www.tnbrew.com/sites/default/files/Extra_Easy_Pick.png"},
                new Beer {BeerId=7, Beer_name="Cutaway IPA", BreweryId=2, Beer_type="IPA", Beer_logo="www.untappd.akamaized.net/site/beer_logos/beer-334960_e608a_sm.jpeg"}
            };

            List<Beer> BI_Beers = new List<Beer>
            {
                new Beer {BeerId=8, Beer_name="Lady Friend", BreweryId=3, Beer_type="Saison", Beer_logo=""},
                new Beer {BeerId=9, Beer_name="Habit", BreweryId=3, Beer_type="IPA", Beer_logo=""},
                new Beer {BeerId=10, Beer_name="Local Color", BreweryId=3, Beer_type="Beire de Garde", Beer_logo=""},
                new Beer {BeerId=11, Beer_name="Suspicion", BreweryId=3, Beer_type="Dark English Mild", Beer_logo=""},
                new Beer {BeerId=12, Beer_name="Persona", BreweryId=3, Beer_type="Pale Ale", Beer_logo=""}
            };

            List<Beer> Yazoo_Beers = new List<Beer>
            {
                new Beer {BeerId=13, Beer_name="Hop Project", BreweryId=4, Beer_type="IPA", Beer_logo="www.bruguru.com/hop-header1.png"},
                new Beer {BeerId=14, Beer_name="Dos Perros", BreweryId=4, Beer_type="Brown Ale", Beer_logo="www.bruguru.com/yazoodosperros.jpg"},
                new Beer {BeerId=15, Beer_name="Gerst", BreweryId=4, Beer_type="Amber Ale", Beer_logo="www.s-media-cache-ak0.pinimg.com/736x/80/0f/c8/800fc8b72afa7b38e3fd4c967738302e.jpg"},
                new Beer {BeerId=16, Beer_name="Sly Rye Porter", BreweryId=4, Beer_type="Porter", Beer_logo="www.beerstreetjournal.com/wp-content/uploads/Yazoo-Sly-Rye-Porter.jpg"}
            };

            List<Beer> Tailgate_Beers = new List<Beer>
            {
                new Beer {BeerId=17, Beer_name="Peanut Butter Milk Stout", BreweryId=5, Beer_type="Milk Stout", Beer_logo="www.r1.nashvillepost.com/files/base/scomm/nvp/image/2016/04/9x16/640w/PB_Milk_Stout.570ff01f308e3.jpg"},
                new Beer {BeerId=18, Beer_name="Grapefruit IPA", BreweryId=5, Beer_type="IPA", Beer_logo="www.worldbeerawards.com/media/bottles/25134-120x400.jpg"},
                new Beer {BeerId=19, Beer_name="Blacktop Blonde", BreweryId=5, Beer_type="Blonde Ale", Beer_logo="www.s-media-cache-ak0.pinimg.com/236x/b1/3a/c1/b13ac1a54511d47607a898ec91f61f7c.jpg"},
                new Beer {BeerId=20, Beer_name="Session IPA", BreweryId=5, Beer_type="IPA", Beer_logo="www.s-media-cache-ak0.pinimg.com/236x/83/00/0e/83000e2c8861a6b6fe3b54ebcb2997aa.jpg"}
            };

            List<Beer> SG_Beers = new List<Beer>
            {
                new Beer {BeerId=21, Beer_name="Bean There, Brown That", BreweryId=6, Beer_type="Brown Ale", Beer_logo=""},
                new Beer {BeerId=22, Beer_name="Nashville Mule", BreweryId=6, Beer_type="Sour", Beer_logo=""},
                new Beer {BeerId=23, Beer_name="Bine As Hell", BreweryId=6, Beer_type="Double IPA", Beer_logo=""},
                new Beer {BeerId=24, Beer_name="There Gose Train", BreweryId=6, Beer_type="Gose", Beer_logo=""}
            };

            List<Beer> BA_Beers = new List<Beer>
            {
                new Beer {BeerId=25, Beer_name="The Rose", BreweryId=7, Beer_type="Blonde Ale", Beer_logo="www.blackabbeybrewing.com/wp-content/uploads/2016/01/the-Rose-Logo-1-559x559.png"},
                new Beer {BeerId=26, Beer_name="Potus 44", BreweryId=7, Beer_type="Porter", Beer_logo="www.blackabbeybrewing.com/wp-content/uploads/2016/01/Potus-44-Logo-1-559x559.png"},
                new Beer {BeerId=27, Beer_name="The Champion", BreweryId=7, Beer_type="APA", Beer_logo="www.blackabbeybrewing.com/wp-content/uploads/2016/01/The-Champion-logo-1-559x559.png"},
                new Beer {BeerId=28, Beer_name="The Chapter House", BreweryId=7, Beer_type="Red Ale", Beer_logo="www.central-distributors.com/uploads/beer-images/TheChapterHouseFinal.png"}
            };


            //Jackalope
            context.Breweries.AddOrUpdate(
                brewery => brewery.Brewery_Name,
                new Brewery { BreweryId= 1, Brewery_Name="Jackalope Brewing Co.", Brewery_address="701 8th Avenue South", Brewery_city="Nashville", Brewery_state="TN", Brewery_zip="37203", Brewery_phone="6158734313", Brewery_url= "www.jackalopebrew.com", Brewery_logo= "www.drinkabeerandplayagame.com/wp-content/uploads/2015/06/jackalope_logo_trademark.jpg", Brewery_beers= Jackalope_Beers  }
                );
            //Tennessee Brew works
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 2, Brewery_Name = "Tennessee Brew Works", Brewery_address = "809 Ewing Avenue", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37203", Brewery_phone = "6154360050", Brewery_url = "www.tnbrew.com", Brewery_logo = "www.tnbrew.com/sites/all/themes/tnbrew/img/logo.png", Brewery_beers = TBW_Beers }
                );
            //Bearded Iris Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 3, Brewery_Name = "Bearded Iris Brewing Co.", Brewery_address = "101 Van Buren St.", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37208", Brewery_phone = "", Brewery_url = "www.beardedirisbrewing.com", Brewery_logo = "www.mtsusidelines.com/wp-content/uploads/2016/02/MTSUSidelines_Lifestyles_Food_BeardedIrisLogo_FILE.jpg", Brewery_beers = BI_Beers }
                );
            //Yazoo Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 4, Brewery_Name = "Yazoo Brewing Co.", Brewery_address = "901 Division St", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37207", Brewery_phone = "6158914649", Brewery_url = "www.yazoobrew.com", Brewery_logo = "www.yazoobrew.com/images/Yazoologo-Red.png", Brewery_beers = Yazoo_Beers }
                );
            //TailGate Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 5, Brewery_Name = "Tailgate Brewing Co.", Brewery_address = "7300 Charlotte Pike", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37209", Brewery_phone = "6158619842", Brewery_url = "www.tailgatebeer.com/", Brewery_logo = "www.tailgatebeer.com/wp-content/uploads/2015/04/beer_menu_tailgate.jpg", Brewery_beers = Tailgate_Beers }
                );
            //Southern Grist Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 6, Brewery_Name = "Southern Grist Brewing Co.", Brewery_address = "1201 Porter Rd", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37206", Brewery_phone = "6157271201", Brewery_url = "www.southerngristbrewing.com", Brewery_logo = "www.res.cloudinary.com/ratebeer/image/upload/w_400,c_limit/brew_26443.jpg", Brewery_beers = SG_Beers }
                );
            //Black Abbey Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.Brewery_Name,
            new Brewery { BreweryId = 7, Brewery_Name = "Black Abbey Brewing Co.", Brewery_address = "2952 Sidco Drive", Brewery_city = "Nashville", Brewery_state = "TN", Brewery_zip = "37204", Brewery_phone = "6157550070", Brewery_url = "www.blackabbeybrewing.com", Brewery_logo = "www.trademarks.justia.com/media/image.php?serial=85266168", Brewery_beers = BA_Beers }
                );
        }
    }
}
