using Delivery.Domain.Entities;
using Delivery.Domain.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Data.Map
{
    internal static class AuditDataBaseInfo
    {
        internal static string Table = "tb_logs";
        internal static string Id           = "id";
        internal static string StartTime    = "start_time";
        internal static string EndTime      = "end_time";
        internal static string ErrorMessage = "error_message";
        internal static string AuditId      = "audit_id";
        internal static string Entities     = "entities";
        internal static string Succeeded    = "succeeded";
        internal static string Action       = "action";
    }

    public class SaveChangesAuditMap
    {
        public void Configure(EntityTypeBuilder<SaveChangesAudit> builder) 
        {
            builder.ToTable(AuditDataBaseInfo.Table);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName(AuditDataBaseInfo.Id);

            builder.Property(x => x.StartTime)
                   .HasColumnName(AuditDataBaseInfo.StartTime);

            builder.Property(x => x.EndTime)
                   .HasColumnName(AuditDataBaseInfo.EndTime);

            builder.Property(x => x.Action)
                   .HasColumnName(AuditDataBaseInfo.Action)
                   .HasConversion(v => Enum.GetName(typeof(EntityState),v),
                                  v => (EntityState)Enum.Parse(typeof(EntityState), v)
                                  );

            builder.Property(x => x.ErrorMessage)
                   .HasColumnName(AuditDataBaseInfo.ErrorMessage);

            builder.Property(x => x.AuditId)
                   .HasColumnName(AuditDataBaseInfo.AuditId)
                   .HasDefaultValue(new Guid())
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(x => x.Entities)
                   .HasColumnName(AuditDataBaseInfo.Entities)
                   .HasColumnType("jsonb")
                   .IsRequired();

            builder.Property(x => x.Succeeded)
                   .HasColumnName(AuditDataBaseInfo.Succeeded)
                   .HasDefaultValue(true)
                   .ValueGeneratedOnAdd();
        }
    }
}
