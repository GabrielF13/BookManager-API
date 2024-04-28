using BookManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence
{
    public class BookManagerDbContext : DbContext
    {
        public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Loan>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }
    }
}