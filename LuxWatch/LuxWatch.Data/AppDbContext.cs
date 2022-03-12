namespace LuxWatch.Data
{
    using LuxWatch.Model;
    using Microsoft.EntityFrameworkCore;
    public class AppDbContext : DbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Order> Rents { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Watch> Scooters { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-QNNJ5J4\\SQLEXPRESS;Database=luxWatchDb;Trusted_Connection=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
