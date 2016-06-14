namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedPropertyNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RewardStatus", name: "Brewery_info_BreweryId", newName: "BreweryInfo_BreweryId");
            RenameColumn(table: "dbo.Userpurchases", name: "Beer_info_BeerId", newName: "BeerInfo_BeerId");
            RenameColumn(table: "dbo.Userpurchases", name: "Brewery_info_BreweryId", newName: "BreweryInfo_BreweryId");
            RenameIndex(table: "dbo.RewardStatus", name: "IX_Brewery_info_BreweryId", newName: "IX_BreweryInfo_BreweryId");
            RenameIndex(table: "dbo.Userpurchases", name: "IX_Beer_info_BeerId", newName: "IX_BeerInfo_BeerId");
            RenameIndex(table: "dbo.Userpurchases", name: "IX_Brewery_info_BreweryId", newName: "IX_BreweryInfo_BreweryId");
            AddColumn("dbo.Beers", "BeerName", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Beers", "BeerType", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Beers", "BeerLogo", c => c.String(maxLength: 600));
            AddColumn("dbo.Breweries", "BreweryName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Breweries", "BreweryAddress", c => c.String(nullable: false, maxLength: 75));
            AddColumn("dbo.Breweries", "BreweryCity", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Breweries", "BreweryState", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.Breweries", "BreweryZip", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.Breweries", "BreweryPin", c => c.Int(nullable: false));
            AddColumn("dbo.Breweries", "BreweryPhone", c => c.String(maxLength: 11));
            AddColumn("dbo.Breweries", "BreweryUrl", c => c.String(maxLength: 100));
            AddColumn("dbo.Breweries", "BreweryLogo", c => c.String(maxLength: 600));
            AddColumn("dbo.Userpurchases", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RewardStatus", "RedeemDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Beers", "Beer_name");
            DropColumn("dbo.Beers", "Beer_type");
            DropColumn("dbo.Beers", "Beer_logo");
            DropColumn("dbo.Breweries", "Brewery_Name");
            DropColumn("dbo.Breweries", "Brewery_address");
            DropColumn("dbo.Breweries", "Brewery_city");
            DropColumn("dbo.Breweries", "Brewery_state");
            DropColumn("dbo.Breweries", "Brewery_zip");
            DropColumn("dbo.Breweries", "Brewery_pin");
            DropColumn("dbo.Breweries", "Brewery_phone");
            DropColumn("dbo.Breweries", "Brewery_url");
            DropColumn("dbo.Breweries", "Brewery_logo");
            DropColumn("dbo.Userpurchases", "Purchase_date");
            DropColumn("dbo.RewardStatus", "Redeem_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RewardStatus", "Redeem_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Userpurchases", "Purchase_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Breweries", "Brewery_logo", c => c.String(maxLength: 600));
            AddColumn("dbo.Breweries", "Brewery_url", c => c.String(maxLength: 100));
            AddColumn("dbo.Breweries", "Brewery_phone", c => c.String(maxLength: 11));
            AddColumn("dbo.Breweries", "Brewery_pin", c => c.Int(nullable: false));
            AddColumn("dbo.Breweries", "Brewery_zip", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.Breweries", "Brewery_state", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.Breweries", "Brewery_city", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Breweries", "Brewery_address", c => c.String(nullable: false, maxLength: 75));
            AddColumn("dbo.Breweries", "Brewery_Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Beers", "Beer_logo", c => c.String(maxLength: 600));
            AddColumn("dbo.Beers", "Beer_type", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Beers", "Beer_name", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.RewardStatus", "RedeemDate");
            DropColumn("dbo.Userpurchases", "PurchaseDate");
            DropColumn("dbo.Breweries", "BreweryLogo");
            DropColumn("dbo.Breweries", "BreweryUrl");
            DropColumn("dbo.Breweries", "BreweryPhone");
            DropColumn("dbo.Breweries", "BreweryPin");
            DropColumn("dbo.Breweries", "BreweryZip");
            DropColumn("dbo.Breweries", "BreweryState");
            DropColumn("dbo.Breweries", "BreweryCity");
            DropColumn("dbo.Breweries", "BreweryAddress");
            DropColumn("dbo.Breweries", "BreweryName");
            DropColumn("dbo.Beers", "BeerLogo");
            DropColumn("dbo.Beers", "BeerType");
            DropColumn("dbo.Beers", "BeerName");
            RenameIndex(table: "dbo.Userpurchases", name: "IX_BreweryInfo_BreweryId", newName: "IX_Brewery_info_BreweryId");
            RenameIndex(table: "dbo.Userpurchases", name: "IX_BeerInfo_BeerId", newName: "IX_Beer_info_BeerId");
            RenameIndex(table: "dbo.RewardStatus", name: "IX_BreweryInfo_BreweryId", newName: "IX_Brewery_info_BreweryId");
            RenameColumn(table: "dbo.Userpurchases", name: "BreweryInfo_BreweryId", newName: "Brewery_info_BreweryId");
            RenameColumn(table: "dbo.Userpurchases", name: "BeerInfo_BeerId", newName: "Beer_info_BeerId");
            RenameColumn(table: "dbo.RewardStatus", name: "BreweryInfo_BreweryId", newName: "Brewery_info_BreweryId");
        }
    }
}
