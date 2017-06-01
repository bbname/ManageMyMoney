namespace MMM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Account_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Account_Id");
            AddForeignKey("dbo.AspNetUsers", "Account_Id", "dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.AspNetUsers", new[] { "Account_Id" });
            DropColumn("dbo.AspNetUsers", "Account_Id");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
