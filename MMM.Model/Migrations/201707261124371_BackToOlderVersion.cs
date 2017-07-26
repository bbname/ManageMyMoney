namespace MMM.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackToOlderVersion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Name", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
