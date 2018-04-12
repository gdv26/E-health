namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateArticle : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ArticleTypes (Id, Name) VALUES (1, 'Activity Article')");
            Sql("INSERT INTO ArticleTypes (Id, Name) VALUES (2, 'Diet Article')");
        }
        
        public override void Down()
        {
        }
    }
}
