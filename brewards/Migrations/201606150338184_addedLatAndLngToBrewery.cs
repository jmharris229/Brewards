namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLatAndLngToBrewery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breweries", "BreweryLat", c => c.Double(nullable: false));
            AddColumn("dbo.Breweries", "BreweryLng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Breweries", "BreweryLng");
            DropColumn("dbo.Breweries", "BreweryLat");
        }
    }
}
