namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beers",
                c => new
                    {
                        BeerId = c.Int(nullable: false, identity: true),
                        BeerName = c.String(nullable: false, maxLength: 500),
                        BeerType = c.String(nullable: false, maxLength: 50),
                        BeerLogo = c.String(maxLength: 600),
                        BreweryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeerId)
                .ForeignKey("dbo.Breweries", t => t.BreweryId, cascadeDelete: true)
                .Index(t => t.BreweryId);
            
            CreateTable(
                "dbo.Breweries",
                c => new
                    {
                        BreweryId = c.Int(nullable: false, identity: true),
                        BreweryName = c.String(nullable: false, maxLength: 100),
                        BreweryAddress = c.String(nullable: false, maxLength: 75),
                        BreweryCity = c.String(nullable: false, maxLength: 50),
                        BreweryState = c.String(nullable: false, maxLength: 3),
                        BreweryZip = c.String(nullable: false, maxLength: 6),
                        BreweryLat = c.Double(nullable: false),
                        BreweryLng = c.Double(nullable: false),
                        BreweryPin = c.Int(nullable: false),
                        BreweryPhone = c.String(maxLength: 11),
                        BreweryUrl = c.String(maxLength: 100),
                        BreweryLogo = c.String(maxLength: 600),
                    })
                .PrimaryKey(t => t.BreweryId);
            
            CreateTable(
                "dbo.BreweryNews",
                c => new
                    {
                        BreweryNewsId = c.Int(nullable: false, identity: true),
                        NewsDate = c.DateTime(nullable: false),
                        NewsMessage = c.String(),
                        BreweryInfo_BreweryId = c.Int(),
                    })
                .PrimaryKey(t => t.BreweryNewsId)
                .ForeignKey("dbo.Breweries", t => t.BreweryInfo_BreweryId)
                .Index(t => t.BreweryInfo_BreweryId);
            
            CreateTable(
                "dbo.RewardStatus",
                c => new
                    {
                        RewardstatusId = c.Int(nullable: false, identity: true),
                        RedeemDate = c.DateTime(nullable: false),
                        BreweryInfo_BreweryId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RewardstatusId)
                .ForeignKey("dbo.Breweries", t => t.BreweryInfo_BreweryId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.BreweryInfo_BreweryId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Userpurchases",
                c => new
                    {
                        UserPurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        BeerInfo_BeerId = c.Int(),
                        BreweryInfo_BreweryId = c.Int(),
                        Purchaser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserPurchaseId)
                .ForeignKey("dbo.Beers", t => t.BeerInfo_BeerId)
                .ForeignKey("dbo.Breweries", t => t.BreweryInfo_BreweryId)
                .ForeignKey("dbo.AspNetUsers", t => t.Purchaser_Id)
                .Index(t => t.BeerInfo_BeerId)
                .Index(t => t.BreweryInfo_BreweryId)
                .Index(t => t.Purchaser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Userpurchases", "Purchaser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Userpurchases", "BreweryInfo_BreweryId", "dbo.Breweries");
            DropForeignKey("dbo.Userpurchases", "BeerInfo_BeerId", "dbo.Beers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RewardStatus", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RewardStatus", "BreweryInfo_BreweryId", "dbo.Breweries");
            DropForeignKey("dbo.BreweryNews", "BreweryInfo_BreweryId", "dbo.Breweries");
            DropForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries");
            DropIndex("dbo.Userpurchases", new[] { "Purchaser_Id" });
            DropIndex("dbo.Userpurchases", new[] { "BreweryInfo_BreweryId" });
            DropIndex("dbo.Userpurchases", new[] { "BeerInfo_BeerId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RewardStatus", new[] { "User_Id" });
            DropIndex("dbo.RewardStatus", new[] { "BreweryInfo_BreweryId" });
            DropIndex("dbo.BreweryNews", new[] { "BreweryInfo_BreweryId" });
            DropIndex("dbo.Beers", new[] { "BreweryId" });
            DropTable("dbo.Userpurchases");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.RewardStatus");
            DropTable("dbo.BreweryNews");
            DropTable("dbo.Breweries");
            DropTable("dbo.Beers");
        }
    }
}
