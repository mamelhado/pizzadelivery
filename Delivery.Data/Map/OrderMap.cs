using Delivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Data.Map
{
    internal static class OrderDataBaseInfo 
    {
        internal static string Table = "tb_order";
        internal static string Id = "id";
        internal static string Responsible = "responsible";
        internal static string Itens = "itens";
        internal static string CreatedAt = "created_at";
        internal static string Address = "address";
        internal static string PaymentMethod = "payment_method";
        internal static string Phone = "phone";
    }

    public class OrderMap
    {
        public void Configure(EntityTypeBuilder<Order> builder) 
        {
            builder.ToTable(OrderDataBaseInfo.Table);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName(OrderDataBaseInfo.Id);

            builder.Property(x => x.Itens)
                   .HasColumnType("jsonb")
                   .HasColumnName(OrderDataBaseInfo.Itens);

            builder.Property(x => x.Responsible)
                   .HasColumnName(OrderDataBaseInfo.Responsible);

            builder.Property(x => x.Address)
                   .HasColumnName(OrderDataBaseInfo.Address);

            builder.Property(x => x.PaymentMethod)
                   .HasColumnName(OrderDataBaseInfo.PaymentMethod)
                   .HasConversion<int>();

            builder.Property(x => x.Phone)
                   .HasColumnName(OrderDataBaseInfo.Phone);

            builder.Property(x => x.CreatedAt)
                   .HasColumnName(OrderDataBaseInfo.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .ValueGeneratedOnAdd();
        }
    }
}
