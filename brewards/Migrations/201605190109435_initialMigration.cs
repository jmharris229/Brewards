namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beers",
                c => new
                    {
                        BeerId = c.Int(nullable: false, identity: true),
                        BreweryId = c.Int(nullable: false),
                        Beer_name = c.String(nullable: false, maxLength: 500),
                        Beer_type = c.String(nullable: false, maxLength: 50),
                        Beer_logo = c.String(maxLength: 600),
                    })
                .PrimaryKey(t => t.BeerId)
                .ForeignKey("dbo.Breweries", t => t.BreweryId, cascadeDelete: true)
                .Index(t => t.BreweryId);
            
            CreateTable(
                "dbo.Breweries",
                c => new
                    {
                        BreweryId = c.Int(nullable: false, identity: true),
                        Brewery_Name = c.String(nullable: false, maxLength: 100),
                        Brewery_address = c.String(nullable: false, maxLength: 75),
                        Brewery_city = c.String(nullable: false, maxLength: 50),
                        Brewery_state = c.String(nullable: false, maxLength: 3),
                        Brewery_zip = c.String(nullable: false, maxLength: 6),
                        Brewery_phone = c.String(maxLength: 11),
                        Brewery_url = c.String(nullable: false, maxLength: 100),
                        Brewery_logo = c.String(nullable: false, maxLength: 600),
                    })
                .PrimaryKey(t => t.BreweryId);
            
            CreateTable(
                "dbo.Rewardstatus",
                c => new
                    {
                        RewardstatusId = c.Int(nullable: false, identity: true),
                        BreweryId = c.Int(nullable: false),
                        Number_purchased = c.Int(nullable: false),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RewardstatusId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
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
                        UserpurchaseId = c.Int(nullable: false, identity: true),
                        BeerId = c.Int(nullable: false),
                        Purchase_date = c.DateTime(nullable: false),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserpurchaseId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Userpurchases", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rewardstatus", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries");
            DropIndex("dbo.Userpurchases", new[] { "UserId_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Rewardstatus", new[] { "UserId_Id" });
            DropIndex("dbo.Beers", new[] { "BreweryId" });
            DropTable("dbo.Userpurchases");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Rewardstatus");
            DropTable("dbo.Breweries");
            DropTable("dbo.Beers");
        }
    }
}
