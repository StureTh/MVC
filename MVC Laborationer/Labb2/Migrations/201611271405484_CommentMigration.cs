namespace Labb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Photo_PhotoId", "dbo.Photos");
            DropIndex("dbo.Comments", new[] { "Photo_PhotoId" });
            RenameColumn(table: "dbo.Comments", name: "Photo_PhotoId", newName: "PhotoId");
            AddColumn("dbo.Comments", "CommentByUser_UserId", c => c.Guid());
            AlterColumn("dbo.Comments", "CommentComment", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "PhotoId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comments", "PhotoId");
            CreateIndex("dbo.Comments", "CommentByUser_UserId");
            AddForeignKey("dbo.Comments", "CommentByUser_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Comments", "PhotoId", "dbo.Photos", "PhotoId", cascadeDelete: true);
            DropColumn("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Comments", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Comments", "CommentByUser_UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "CommentByUser_UserId" });
            DropIndex("dbo.Comments", new[] { "PhotoId" });
            AlterColumn("dbo.Comments", "PhotoId", c => c.Guid());
            AlterColumn("dbo.Comments", "CommentComment", c => c.String());
            DropColumn("dbo.Comments", "CommentByUser_UserId");
            RenameColumn(table: "dbo.Comments", name: "PhotoId", newName: "Photo_PhotoId");
            CreateIndex("dbo.Comments", "Photo_PhotoId");
            AddForeignKey("dbo.Comments", "Photo_PhotoId", "dbo.Photos", "PhotoId");
        }
    }
}
