using Microsoft.EntityFrameworkCore;
using Santa_Stefania_Lab2.Models;

namespace Santa_Stefania_Lab2.Data
{
    public class Santa_Stefania_Lab2Context : DbContext
    {
        public Santa_Stefania_Lab2Context(DbContextOptions<Santa_Stefania_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurare relație între Book și Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID)
                .OnDelete(DeleteBehavior.Cascade); // Setează comportamentul la ștergere
        }
        public DbSet<Santa_Stefania_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
