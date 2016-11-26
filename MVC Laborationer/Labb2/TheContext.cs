using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;
using Labb2.Models;

namespace Labb2
{
    public class TheContext: DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments  { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().
              HasMany(c => c.Photos).
              WithMany(p => p.Albums).
              Map(
               m =>
               {
                   m.MapLeftKey("AlbumId");
                   m.MapRightKey("PhotoId");
                   m.ToTable("PhotoAlbums");
               });
        }
    }


}