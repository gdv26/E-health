namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateReturnedToBuys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buys", "DateReturned", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buys", "DateReturned");
        }
    }
}
