using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Labb2Data
{
    public class TheContext: DbContext
    {
        public DbSet<PhotoDataModel> Photos { get; set; }
        public DbSet<AlbumDataModel> Albums { get; set; }
        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<CommentDataModel> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumDataModel>().
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
