namespace NewsContentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        authorName = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        commentContent = c.String(),
                        Date = c.DateTime(nullable: false),
                        HaberlerId = c.Int(nullable: false),
                        News_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.News_Id)
                .Index(t => t.News_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "News_Id", "dbo.News");
            DropForeignKey("dbo.News", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Authors", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Comments", new[] { "News_Id" });
            DropIndex("dbo.News", new[] { "AuthorId" });
            DropIndex("dbo.News", new[] { "CategoryId" });
            DropIndex("dbo.Authors", new[] { "Category_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.News");
            DropTable("dbo.Authors");
        }
    }
}
