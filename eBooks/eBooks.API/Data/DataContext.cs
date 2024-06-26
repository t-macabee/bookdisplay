using eBooks.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eBooks.API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }       
        public DbSet<Comments> Comments { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>()
            .HasOne(c => c.Book)
            .WithMany(b => b.Comments)
            .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<Books>()
            .Property(b => b.Genre)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
