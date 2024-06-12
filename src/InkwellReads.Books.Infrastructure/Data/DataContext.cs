using InkWellReads.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InkwellReads.Books.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasMany(author => author.Books)
                                         .WithOne(b => b.Author)
                                         .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Category>().HasMany(c => c.Books)
                                           .WithOne(b => b.Category)
                                           .HasForeignKey(b => b.CategoryId);
        }
    }
}
