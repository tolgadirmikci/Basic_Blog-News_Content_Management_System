namespace NewsContentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_commentmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "News_Id", "dbo.News");
            DropIndex("dbo.Comments", new[] { "News_Id" });
            RenameColumn(table: "dbo.Comments", name: "News_Id", newName: "NewsId");
            AlterColumn("dbo.Comments", "NewsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "NewsId");
            AddForeignKey("dbo.Comments", "NewsId", "dbo.News", "Id", cascadeDelete: true);
            DropColumn("dbo.Comments", "HaberlerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "HaberlerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "NewsId", "dbo.News");
            DropIndex("dbo.Comments", new[] { "NewsId" });
            AlterColumn("dbo.Comments", "NewsId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "NewsId", newName: "News_Id");
            CreateIndex("dbo.Comments", "News_Id");
            AddForeignKey("dbo.Comments", "News_Id", "dbo.News", "Id");
        }
    }
}
