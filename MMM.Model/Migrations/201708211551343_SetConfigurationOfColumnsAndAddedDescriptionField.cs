namespace MMM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetConfigurationOfColumnsAndAddedDescriptionField : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Accounts", newName: "BankAccounts");
            RenameColumn(table: "dbo.Transactions", name: "Account_Id", newName: "BankAccount_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Account_Id", newName: "IX_BankAccount_Id");
            AddColumn("dbo.Transactions", "Description", c => c.String(maxLength: 1500));
            AlterColumn("dbo.BankAccounts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transactions", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.Transactions", "Name", c => c.String());
            AlterColumn("dbo.BankAccounts", "Name", c => c.String());
            DropColumn("dbo.Transactions", "Description");
            RenameIndex(table: "dbo.Transactions", name: "IX_BankAccount_Id", newName: "IX_Account_Id");
            RenameColumn(table: "dbo.Transactions", name: "BankAccount_Id", newName: "Account_Id");
            RenameTable(name: "dbo.BankAccounts", newName: "Accounts");
        }
    }
}
