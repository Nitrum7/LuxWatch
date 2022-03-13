namespace LuxWatch.Data
{
    using LuxWatch.Model;
    using Microsoft.EntityFrameworkCore;
    public class AppDbContext : DbContext
    {
       
        public virtual DbSet<Watch> Watches { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.;Database=luxWatchDb;Trusted_Connection=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
