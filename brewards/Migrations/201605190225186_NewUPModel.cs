namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUPModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries");
            DropIndex("dbo.Beers", new[] { "BreweryId" });
            RenameColumn(table: "dbo.Beers", name: "BreweryId", newName: "Brewery_BreweryId");
            RenameColumn(table: "dbo.Userpurchases", name: "UserId_Id", newName: "Purchaser_Id");
            RenameIndex(table: "dbo.Userpurchases", name: "IX_UserId_Id", newName: "IX_Purchaser_Id");
            AddColumn("dbo.Rewardstatus", "Brewery_info_BreweryId", c => c.Int());
            AddColumn("dbo.Userpurchases", "Beer_info_BeerId", c => c.Int());
            AddColumn("dbo.Userpurchases", "Brewery_info_BreweryId", c => c.Int());
            AlterColumn("dbo.Beers", "Brewery_BreweryId", c => c.Int());
            AlterColumn("dbo.Breweries", "Brewery_url", c => c.String(maxLength: 100));
            AlterColumn("dbo.Breweries", "Brewery_logo", c => c.String(maxLength: 600));
            CreateIndex("dbo.Beers", "Brewery_BreweryId");
            CreateIndex("dbo.Rewardstatus", "Brewery_info_BreweryId");
            CreateIndex("dbo.Userpurchases", "Beer_info_BeerId");
            CreateIndex("dbo.Userpurchases", "Brewery_info_BreweryId");
            AddForeignKey("dbo.Rewardstatus", "Brewery_info_BreweryId", "dbo.Breweries", "BreweryId");
            AddForeignKey("dbo.Userpurchases", "Beer_info_BeerId", "dbo.Beers", "BeerId");
            AddForeignKey("dbo.Userpurchases", "Brewery_info_BreweryId", "dbo.Breweries", "BreweryId");
            AddForeignKey("dbo.Beers", "Brewery_BreweryId", "dbo.Breweries", "BreweryId");
            DropColumn("dbo.Rewardstatus", "BreweryId");
            DropColumn("dbo.Userpurchases", "BeerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Userpurchases", "BeerId", c => c.Int(nullable: false));
            AddColumn("dbo.Rewardstatus", "BreweryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Beers", "Brewery_BreweryId", "dbo.Breweries");
            DropForeignKey("dbo.Userpurchases", "Brewery_info_BreweryId", "dbo.Breweries");
            DropForeignKey("dbo.Userpurchases", "Beer_info_BeerId", "dbo.Beers");
            DropForeignKey("dbo.Rewardstatus", "Brewery_info_BreweryId", "dbo.Breweries");
            DropIndex("dbo.Userpurchases", new[] { "Brewery_info_BreweryId" });
            DropIndex("dbo.Userpurchases", new[] { "Beer_info_BeerId" });
            DropIndex("dbo.Rewardstatus", new[] { "Brewery_info_BreweryId" });
            DropIndex("dbo.Beers", new[] { "Brewery_BreweryId" });
            AlterColumn("dbo.Breweries", "Brewery_logo", c => c.String(nullable: false, maxLength: 600));
            AlterColumn("dbo.Breweries", "Brewery_url", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Beers", "Brewery_BreweryId", c => c.Int(nullable: false));
            DropColumn("dbo.Userpurchases", "Brewery_info_BreweryId");
            DropColumn("dbo.Userpurchases", "Beer_info_BeerId");
            DropColumn("dbo.Rewardstatus", "Brewery_info_BreweryId");
            RenameIndex(table: "dbo.Userpurchases", name: "IX_Purchaser_Id", newName: "IX_UserId_Id");
            RenameColumn(table: "dbo.Userpurchases", name: "Purchaser_Id", newName: "UserId_Id");
            RenameColumn(table: "dbo.Beers", name: "Brewery_BreweryId", newName: "BreweryId");
            CreateIndex("dbo.Beers", "BreweryId");
            AddForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries", "BreweryId", cascadeDelete: true);
        }
    }
}
