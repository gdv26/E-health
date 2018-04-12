namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateProgramsNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Programs SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
