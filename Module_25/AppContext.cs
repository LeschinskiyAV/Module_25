using Microsoft.EntityFrameworkCore;

namespace Module_25
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ADM-PROG-LESCH\SQLEXPRESS; Database=EF; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}