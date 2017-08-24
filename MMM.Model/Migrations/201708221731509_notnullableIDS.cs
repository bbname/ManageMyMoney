namespace MMM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notnullableIDS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "BankAccount_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BankAccounts", new[] { "User_Id" });
            DropIndex("dbo.Transactions", new[] { "BankAccount_Id" });
            AlterColumn("dbo.BankAccounts", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Transactions", "BankAccount_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.BankAccounts", "User_Id");
            CreateIndex("dbo.Transactions", "BankAccount_Id");
            AddForeignKey("dbo.Transactions", "BankAccount_Id", "dbo.BankAccounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BankAccounts", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "BankAccount_Id", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "BankAccount_Id" });
            DropIndex("dbo.BankAccounts", new[] { "User_Id" });
            AlterColumn("dbo.Transactions", "BankAccount_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.BankAccounts", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "BankAccount_Id");
            CreateIndex("dbo.BankAccounts", "User_Id");
            AddForeignKey("dbo.BankAccounts", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Transactions", "BankAccount_Id", "dbo.BankAccounts", "Id");
        }
    }
}
