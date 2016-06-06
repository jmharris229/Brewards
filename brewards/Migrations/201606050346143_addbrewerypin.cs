namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbrewerypin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breweries", "Brewery_pin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Breweries", "Brewery_pin");
        }
    }
}
