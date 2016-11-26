namespace Labb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnModelCreatingMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PhotoAlbums", name: "Photo_PhotoId", newName: "PhotoId");
            RenameColumn(table: "dbo.PhotoAlbums", name: "Album_AlbumId", newName: "AlbumId");
            RenameIndex(table: "dbo.PhotoAlbums", name: "IX_Album_AlbumId", newName: "IX_AlbumId");
            RenameIndex(table: "dbo.PhotoAlbums", name: "IX_Photo_PhotoId", newName: "IX_PhotoId");
            DropPrimaryKey("dbo.PhotoAlbums");
            AddPrimaryKey("dbo.PhotoAlbums", new[] { "AlbumId", "PhotoId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PhotoAlbums");
            AddPrimaryKey("dbo.PhotoAlbums", new[] { "Photo_PhotoId", "Album_AlbumId" });
            RenameIndex(table: "dbo.PhotoAlbums", name: "IX_PhotoId", newName: "IX_Photo_PhotoId");
            RenameIndex(table: "dbo.PhotoAlbums", name: "IX_AlbumId", newName: "IX_Album_AlbumId");
            RenameColumn(table: "dbo.PhotoAlbums", name: "AlbumId", newName: "Album_AlbumId");
            RenameColumn(table: "dbo.PhotoAlbums", name: "PhotoId", newName: "Photo_PhotoId");
        }
    }
}
