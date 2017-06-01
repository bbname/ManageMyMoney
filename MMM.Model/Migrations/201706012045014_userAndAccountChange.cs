namespace MMM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAndAccountChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.AspNetUsers", new[] { "Account_Id" });
            AddColumn("dbo.Accounts", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Accounts", "User_Id");
            AddForeignKey("dbo.Accounts", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Account_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Account_Id", c => c.Int());
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropColumn("dbo.Accounts", "User_Id");
            CreateIndex("dbo.AspNetUsers", "Account_Id");
            AddForeignKey("dbo.AspNetUsers", "Account_Id", "dbo.Accounts", "Id");
        }
    }
}
