namespace Labb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.Photos", new[] { "Album_AlbumId" });
            CreateTable(
                "dbo.PhotoAlbums",
                c => new
                    {
                        Photo_PhotoId = c.Guid(nullable: false),
                        Album_AlbumId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photo_PhotoId, t.Album_AlbumId })
                .ForeignKey("dbo.Photos", t => t.Photo_PhotoId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Photo_PhotoId)
                .Index(t => t.Album_AlbumId);
            
            DropColumn("dbo.Photos", "Album_AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "Album_AlbumId", c => c.Guid());
            DropForeignKey("dbo.PhotoAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PhotoAlbums", "Photo_PhotoId", "dbo.Photos");
            DropIndex("dbo.PhotoAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.PhotoAlbums", new[] { "Photo_PhotoId" });
            DropTable("dbo.PhotoAlbums");
            CreateIndex("dbo.Photos", "Album_AlbumId");
            AddForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums", "AlbumId");
        }
    }
}
