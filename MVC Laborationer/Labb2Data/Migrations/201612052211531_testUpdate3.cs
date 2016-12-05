namespace Labb2Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testUpdate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumDataModels",
                c => new
                    {
                        AlbumId = c.Guid(nullable: false),
                        AlbumName = c.String(),
                        UserDataModel_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.UserDataModels", t => t.UserDataModel_UserId)
                .Index(t => t.UserDataModel_UserId);
            
            CreateTable(
                "dbo.PhotoDataModels",
                c => new
                    {
                        PhotoId = c.Guid(nullable: false),
                        PhotoName = c.String(),
                        UploadDate = c.DateTime(),
                        PhotoUrl = c.String(),
                    })
                .PrimaryKey(t => t.PhotoId);
            
            CreateTable(
                "dbo.CommentDataModels",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        CommentComment = c.String(),
                        Date = c.DateTime(nullable: false),
                        PhotoId = c.Guid(nullable: false),
                        CommentByUserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.PhotoDataModels", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.UserDataModels",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.PhotoAlbums",
                c => new
                    {
                        AlbumId = c.Guid(nullable: false),
                        PhotoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlbumId, t.PhotoId })
                .ForeignKey("dbo.AlbumDataModels", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.PhotoDataModels", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumDataModels", "UserDataModel_UserId", "dbo.UserDataModels");
            DropForeignKey("dbo.PhotoAlbums", "PhotoId", "dbo.PhotoDataModels");
            DropForeignKey("dbo.PhotoAlbums", "AlbumId", "dbo.AlbumDataModels");
            DropForeignKey("dbo.CommentDataModels", "PhotoId", "dbo.PhotoDataModels");
            DropIndex("dbo.PhotoAlbums", new[] { "PhotoId" });
            DropIndex("dbo.PhotoAlbums", new[] { "AlbumId" });
            DropIndex("dbo.CommentDataModels", new[] { "PhotoId" });
            DropIndex("dbo.AlbumDataModels", new[] { "UserDataModel_UserId" });
            DropTable("dbo.PhotoAlbums");
            DropTable("dbo.UserDataModels");
            DropTable("dbo.CommentDataModels");
            DropTable("dbo.PhotoDataModels");
            DropTable("dbo.AlbumDataModels");
        }
    }
}
