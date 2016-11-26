namespace Labb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Guid(nullable: false),
                        AlbumName = c.String(nullable: false),
                        User_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Guid(nullable: false),
                        PhotoName = c.String(nullable: false, maxLength: 20),
                        UploadDate = c.DateTime(),
                        PhotoUrl = c.String(),
                        Album_AlbumId = c.Guid(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .Index(t => t.Album_AlbumId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        CommentComment = c.String(),
                        UserId_UserId = c.Guid(),
                        Photo_PhotoId = c.Guid(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .ForeignKey("dbo.Photos", t => t.Photo_PhotoId)
                .Index(t => t.UserId_UserId)
                .Index(t => t.Photo_PhotoId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Comments", "Photo_PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Comments", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Albums", "User_UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Photo_PhotoId" });
            DropIndex("dbo.Comments", new[] { "UserId_UserId" });
            DropIndex("dbo.Photos", new[] { "Album_AlbumId" });
            DropIndex("dbo.Albums", new[] { "User_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Photos");
            DropTable("dbo.Albums");
        }
    }
}
