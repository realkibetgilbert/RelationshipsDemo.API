using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RelationshipsDemo.API.Core.Models;

namespace RelationshipsDemo.API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Author> Authors { get; set; }  
        public DbSet<Book>  Books { get; set; }  
        public DbSet<Publisher> Publishers { get; set; }  
        public DbSet<BookPublisher> BookPublishers { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///put our configuration configuration can be done on classe using attributes
           
            
           
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(p=>p.Name).IsRequired();
                entity.HasOne(p =>p.Publisher)
                .WithOne(p => p.Author)
                .HasForeignKey<Publisher>(f=>f.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            }
            );
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(p=>p.Title).IsRequired();
                entity.HasOne(a=>a.Author)
                .WithMany(b=>b.Books)
                .HasForeignKey(f=>f.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            }
           );
            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(p => p.Name).IsRequired();
            }
           );

            modelBuilder.Entity<BookPublisher>(entity =>
            {
                entity.HasKey(bp => new
                {
                    bp.PublisherId,
                    bp.BookId
                });
                entity.HasOne(bp => bp.Book).WithMany(bp => bp.BookPublishers)
                .HasForeignKey(p => p.BookId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(bp => bp.Publisher).WithMany(bp => bp.BookPublishers)
             .HasForeignKey(p => p.PublisherId)
             .OnDelete(DeleteBehavior.NoAction);
            });

        }
    }
}
