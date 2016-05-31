namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beerclassupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Beers", "Brewery_BreweryId", "dbo.Breweries");
            DropIndex("dbo.Beers", new[] { "Brewery_BreweryId" });
            RenameColumn(table: "dbo.Beers", name: "Brewery_BreweryId", newName: "BreweryId");
            AlterColumn("dbo.Beers", "BreweryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Beers", "BreweryId");
            AddForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries", "BreweryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries");
            DropIndex("dbo.Beers", new[] { "BreweryId" });
            AlterColumn("dbo.Beers", "BreweryId", c => c.Int());
            RenameColumn(table: "dbo.Beers", name: "BreweryId", newName: "Brewery_BreweryId");
            CreateIndex("dbo.Beers", "Brewery_BreweryId");
            AddForeignKey("dbo.Beers", "Brewery_BreweryId", "dbo.Breweries", "BreweryId");
        }
    }
}
