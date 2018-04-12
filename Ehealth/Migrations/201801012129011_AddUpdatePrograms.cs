namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdatePrograms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ProgramTypeId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProgramTypes", t => t.ProgramTypeId, cascadeDelete: true)
                .Index(t => t.ProgramTypeId);
            
            CreateTable(
                "dbo.ProgramTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programs", "ProgramTypeId", "dbo.ProgramTypes");
            DropIndex("dbo.Programs", new[] { "ProgramTypeId" });
            DropTable("dbo.ProgramTypes");
            DropTable("dbo.Programs");
        }
    }
}
