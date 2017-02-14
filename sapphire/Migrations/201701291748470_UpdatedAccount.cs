namespace sapphire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "AccountName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "AccountName");
        }
    }
}
