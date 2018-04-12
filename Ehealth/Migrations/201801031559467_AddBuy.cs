namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "NumberAvailable", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "NumberAvailable");
        }
    }
}
