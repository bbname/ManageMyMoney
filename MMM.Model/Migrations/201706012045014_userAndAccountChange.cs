namespace MMM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAndAccountChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Account_Id", "dbo.BankAccounts");
            DropIndex("dbo.AspNetUsers", new[] { "Account_Id" });
            AddColumn("dbo.BankAccounts", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.BankAccounts", "User_Id");
            AddForeignKey("dbo.BankAccounts", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Account_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Account_Id", c => c.Int());
            DropForeignKey("dbo.BankAccounts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BankAccounts", new[] { "User_Id" });
            DropColumn("dbo.BankAccounts", "User_Id");
            CreateIndex("dbo.AspNetUsers", "Account_Id");
            AddForeignKey("dbo.AspNetUsers", "Account_Id", "dbo.BankAccounts", "Id");
        }
    }
}
