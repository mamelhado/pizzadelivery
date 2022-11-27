using Delivery.Data.Map;
using Delivery.Domain.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Delivery.Data
{
    public class AuditableContext : DbContext
    {
        private static string Schema = "mvp";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.local.json")
            .Build();
            var connString = config.GetConnectionString("Mvp");
            optionsBuilder.UseNpgsql(connString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<SaveChangesAudit>(new SaveChangesAuditMap().Configure);
        }

        public DbSet<SaveChangesAudit> Audits { get; set; }
    }
}