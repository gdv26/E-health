namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ArticleTypeId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleTypes", t => t.ArticleTypeId, cascadeDelete: true)
                .Index(t => t.ArticleTypeId);
            
            CreateTable(
                "dbo.ArticleTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "ArticleTypeId", "dbo.ArticleTypes");
            DropIndex("dbo.Articles", new[] { "ArticleTypeId" });
            DropTable("dbo.ArticleTypes");
            DropTable("dbo.Articles");
        }
    }
}
