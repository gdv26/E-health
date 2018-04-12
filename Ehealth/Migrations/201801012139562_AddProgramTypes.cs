namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProgramTypes (Id, Name) VALUES (1, 'Activity')");
            Sql("INSERT INTO ProgramTypes (Id, Name) VALUES (2, 'Diet')");
        }
        
        public override void Down()
        {
        }
    }
}
