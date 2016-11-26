namespace Labb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "UserId_UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId_UserId" });
            AddColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Comments", "UserId_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserId_UserId", c => c.Guid());
            DropColumn("dbo.Comments", "UserId");
            DropColumn("dbo.Comments", "Date");
            CreateIndex("dbo.Comments", "UserId_UserId");
            AddForeignKey("dbo.Comments", "UserId_UserId", "dbo.Users", "UserId");
        }
    }
}
