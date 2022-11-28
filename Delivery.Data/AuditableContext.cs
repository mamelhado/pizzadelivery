using Delivery.Data.Map;
using Delivery.Domain.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Delivery.Data
{
    public class AuditableContext : DbContext
    {
        private static string Schema = "mvp";
        private string ConnectionString;

        public AuditableContext(string connString) 
        {
            ConnectionString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
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