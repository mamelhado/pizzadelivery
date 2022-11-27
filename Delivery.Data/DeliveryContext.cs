using Delivery.Data.Interceptors;
using Delivery.Data.Map;
using Delivery.Domain.Entities;
using Delivery.Domain.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Data
{
    public class DeliveryContext : DbContext
    {
        private static string Schema = "mvp";
        private readonly AuditingInterceptor _auditingInterceptor = new AuditingInterceptor();

        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.AddInterceptors(_auditingInterceptor);        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<Order>(new OrderMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<Category>(new CategoryMap().Configure);
            modelBuilder.Entity<SubCategory>(new SubCategoryMap().Configure);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}