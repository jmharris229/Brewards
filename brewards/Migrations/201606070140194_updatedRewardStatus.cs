namespace brewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedRewardStatus : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rewardstatus", name: "UserId_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Rewardstatus", name: "IX_UserId_Id", newName: "IX_User_Id");
            AddColumn("dbo.Rewardstatus", "Redeem_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rewardstatus", "Number_purchased");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rewardstatus", "Number_purchased", c => c.Int(nullable: false));
            DropColumn("dbo.Rewardstatus", "Redeem_date");
            RenameIndex(table: "dbo.Rewardstatus", name: "IX_User_Id", newName: "IX_UserId_Id");
            RenameColumn(table: "dbo.Rewardstatus", name: "User_Id", newName: "UserId_Id");
        }
    }
}
