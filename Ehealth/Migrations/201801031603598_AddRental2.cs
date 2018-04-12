namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateBought = c.DateTime(nullable: false),
                        Program_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Program_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buys", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Buys", "Program_Id", "dbo.Programs");
            DropIndex("dbo.Buys", new[] { "User_Id" });
            DropIndex("dbo.Buys", new[] { "Program_Id" });
            DropTable("dbo.Buys");
        }
    }
}
