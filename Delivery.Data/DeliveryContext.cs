using Delivery.Data.Map;
using Delivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Data
{
    public class DeliveryContext : DbContext
    {
        private static string Schema = "mvp";
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<Category>(new CategoryMap().Configure);
            modelBuilder.Entity<SubCategory>(new SubCategoryMap().Configure);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }
    }
}