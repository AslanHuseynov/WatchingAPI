using Microsoft.EntityFrameworkCore;
using Watching.Model.Models;

namespace Company.Persistence.DB
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<WatchingName> WatchingNames { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-THVOU75\\MSSQLSERVER02;Database=WatchingAPI;Trusted_Connection=true;TrustServerCertificate=true;", b => b.MigrationsAssembly("API"));
        }
    }
}
