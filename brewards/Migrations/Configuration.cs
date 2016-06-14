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
                new Beer {BeerId=1, BeerName="Thunder Ann", BeerType="APA", BeerLogo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-thunderann-500x500.png"},
                new Beer {BeerId=2, BeerName="Rompo", BeerType="Red Rye Ale", BeerLogo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jackalope-rompocirc-500x500.png"},
                new Beer {BeerId=3, BeerName="Bearwalker",  BeerType="Brown Ale", BeerLogo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jackalope-bearwalker-500x500.png"},
                new Beer {BeerId=4, BeerName="Leghorn", BeerType="Rye IPA", BeerLogo="www.jackalopebrew.com/new/wp-content/uploads/2013/09/jacka-leghorn-500x500.png"}
            };

            List<Beer> TBW_Beers = new List<Beer>
            {
                new Beer {BeerId=5, BeerName="Southern Wit", BeerType="Belgian White", BeerLogo="www.untappd.akamaized.net/site/beer_logos/beer-334613_25944_sm.jpeg"},
                new Beer {BeerId=6, BeerName="Extra Easy", BeerType="American ESB", BeerLogo="www.tnbrew.com/sites/default/files/Extra_Easy_Pick.png"},
                new Beer {BeerId=7, BeerName="Cutaway IPA", BeerType="IPA", BeerLogo="www.untappd.akamaized.net/site/beer_logos/beer-334960_e608a_sm.jpeg"}
            };

            List<Beer> BI_Beers = new List<Beer>
            {
                new Beer {BeerId=8, BeerName="Lady Friend", BeerType="Saison", BeerLogo=""},
                new Beer {BeerId=9, BeerName="Habit", BeerType="IPA", BeerLogo=""},
                new Beer {BeerId=10, BeerName="Local Color", BeerType="Beire de Garde", BeerLogo=""},
                new Beer {BeerId=11, BeerName="Suspicion", BeerType="Dark English Mild", BeerLogo=""},
                new Beer {BeerId=12, BeerName="Persona", BeerType="Pale Ale", BeerLogo=""}
            };

            List<Beer> Yazoo_Beers = new List<Beer>
            {
                new Beer {BeerId=13, BeerName="Hop Project", BeerType="IPA", BeerLogo="www.bruguru.com/hop-header1.png"},
                new Beer {BeerId=14, BeerName="Dos Perros", BeerType="Brown Ale", BeerLogo="www.bruguru.com/yazoodosperros.jpg"},
                new Beer {BeerId=15, BeerName="Gerst", BeerType="Amber Ale", BeerLogo="www.s-media-cache-ak0.pinimg.com/736x/80/0f/c8/800fc8b72afa7b38e3fd4c967738302e.jpg"},
                new Beer {BeerId=16, BeerName="Sly Rye Porter", BeerType="Porter", BeerLogo="www.beerstreetjournal.com/wp-content/uploads/Yazoo-Sly-Rye-Porter.jpg"}
            };

            List<Beer> Tailgate_Beers = new List<Beer>
            {
                new Beer {BeerId=17, BeerName="Peanut Butter Milk Stout", BeerType="Milk Stout", BeerLogo="www.r1.nashvillepost.com/files/base/scomm/nvp/image/2016/04/9x16/640w/PB_Milk_Stout.570ff01f308e3.jpg"},
                new Beer {BeerId=18, BeerName="Grapefruit IPA", BeerType="IPA", BeerLogo="www.worldbeerawards.com/media/bottles/25134-120x400.jpg"},
                new Beer {BeerId=19, BeerName="Blacktop Blonde", BeerType="Blonde Ale", BeerLogo="www.s-media-cache-ak0.pinimg.com/236x/b1/3a/c1/b13ac1a54511d47607a898ec91f61f7c.jpg"},
                new Beer {BeerId=20, BeerName="Session IPA", BeerType="IPA", BeerLogo="www.s-media-cache-ak0.pinimg.com/236x/83/00/0e/83000e2c8861a6b6fe3b54ebcb2997aa.jpg"}
            };

            List<Beer> SG_Beers = new List<Beer>
            {
                new Beer {BeerId=21, BeerName="Bean There, Brown That", BeerType="Brown Ale", BeerLogo=""},
                new Beer {BeerId=22, BeerName="Nashville Mule", BeerType="Sour", BeerLogo=""},
                new Beer {BeerId=23, BeerName="Bine As Hell", BeerType="Double IPA", BeerLogo=""},
                new Beer {BeerId=24, BeerName="There Gose Train", BeerType="Gose", BeerLogo=""}
            };

            List<Beer> BA_Beers = new List<Beer>
            {
                new Beer {BeerId=25, BeerName="The Rose", BeerType="Blonde Ale", BeerLogo="www.blackabbeybrewing.com/wp-content/uploads/2016/01/the-Rose-Logo-1-559x559.png"},
                new Beer {BeerId=26, BeerName="Potus 44", BeerType="Porter", BeerLogo="www.blackabbeybrewing.com/wp-content/uploads/2016/01/Potus-44-Logo-1-559x559.png"},
                new Beer {BeerId=27, BeerName="The Champion", BeerType="APA", BeerLogo="www.blackabbeybrewing.com/wp-content/uploads/2016/01/The-Champion-logo-1-559x559.png"},
                new Beer {BeerId=28, BeerName="The Chapter House", BeerType="Red Ale", BeerLogo="www.central-distributors.com/uploads/beer-images/TheChapterHouseFinal.png"}
            };

            //Jackalope
            context.Breweries.AddOrUpdate(
                brewery => brewery.BreweryName,
                new Brewery{ BreweryId = 1, BreweryName = "Jackalope Brewing Co.", BreweryAddress = "701 8th Avenue South", BreweryCity = "Nashville", BreweryState = "TN", BreweryZip = "37203", BreweryPhone = "6158734313", BreweryUrl = "www.jackalopebrew.com", BreweryLogo = "www.drinkabeerandplayagame.com/wp-content/uploads/2015/06/jackalope_logo_trademark.jpg", BreweryBeers = Jackalope_Beers, BreweryPin = 1000 }
                );
            //Tennessee Brew works
            context.Breweries.AddOrUpdate(
            brewery => brewery.BreweryName,
            new Brewery { BreweryId = 2, BreweryName = "Tennessee Brew Works", BreweryAddress = "809 Ewing Avenue", BreweryCity = "Nashville", BreweryState = "TN", BreweryZip = "37203", BreweryPhone = "6154360050", BreweryUrl = "www.tnbrew.com", BreweryLogo = "www.tnbrew.com/sites/all/themes/tnbrew/img/logo.png", BreweryBeers = TBW_Beers, BreweryPin = 1001 }
                );
            //Bearded Iris Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.BreweryName,
            new Brewery { BreweryId = 3, BreweryName = "Bearded Iris Brewing Co.", BreweryAddress = "101 Van Buren St.", BreweryCity = "Nashville", BreweryState = "TN", BreweryZip = "37208", BreweryPhone = "", BreweryUrl = "www.beardedirisbrewing.com", BreweryLogo = "www.mtsusidelines.com/wp-content/uploads/2016/02/MTSUSidelines_Lifestyles_Food_BeardedIrisLogo_FILE.jpg", BreweryBeers = BI_Beers,BreweryPin = 1002 }
                );
            //Yazoo Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.BreweryName,
            new Brewery { BreweryId = 4, BreweryName = "Yazoo Brewing Co.", BreweryAddress = "901 Division St", BreweryCity = "Nashville", BreweryState = "TN", BreweryZip = "37207", BreweryPhone = "6158914649", BreweryUrl = "www.yazoobrew.com", BreweryLogo = "www.yazoobrew.com/images/Yazoologo-Red.png", BreweryBeers = Yazoo_Beers, BreweryPin = 1003 }
                );
            //TailGate Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.BreweryName,
            new Brewery { BreweryId = 5, BreweryName = "Tailgate Brewing Co.", BreweryAddress = "7300 Charlotte Pike", BreweryCity = "Nashville", BreweryState = "TN", BreweryZip = "37209", BreweryPhone = "6158619842", BreweryUrl = "www.tailgatebeer.com/", BreweryLogo = "www.tailgatebeer.com/wp-content/uploads/2015/04/beer_menu_tailgate.jpg", BreweryBeers = Tailgate_Beers, BreweryPin = 1004 }
                );
            //Southern Grist Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.BreweryName,
            new Brewery { BreweryId = 6, BreweryName = "Southern Grist Brewing Co.", BreweryAddress = "1201 Porter Rd", BreweryCity = "Nashville", BreweryState = "TN", BreweryZip = "37206", BreweryPhone = "6157271201", BreweryUrl = "www.southerngristbrewing.com", BreweryLogo = "www.res.cloudinary.com/ratebeer/image/upload/w_400,c_limit/brew_26443.jpg", BreweryBeers = SG_Beers, BreweryPin = 1005 }
                );
            //Black Abbey Brewing Co.
            context.Breweries.AddOrUpdate(
            brewery => brewery.BreweryName,
            new Brewery { BreweryId = 7, BreweryName = "Black Abbey Brewing Co.", BreweryAddress = "2952 Sidco Drive", BreweryCity = "Nashville", BreweryState = "TN", BreweryZip = "37204", BreweryPhone = "6157550070", BreweryUrl = "www.blackabbeybrewing.com", BreweryLogo = "www.trademarks.justia.com/media/image.php?serial=85266168", BreweryBeers = BA_Beers, BreweryPin = 1006 }
                );
        }
    }
}
