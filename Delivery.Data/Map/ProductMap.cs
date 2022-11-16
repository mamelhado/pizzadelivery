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
    internal static class ProductDataBaseInfo 
    {
        internal static string Table = "tb_products";
        internal static string Id = "id";
        internal static string Name = "name";
        internal static string Description = "description";
        internal static string CreatedAt = "created_at";
    }

    public class ProductMap
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.ToTable(ProductDataBaseInfo.Table);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName(ProductDataBaseInfo.Id);

            builder.Property(x => x.Name)
                   .HasColumnName(ProductDataBaseInfo.Name);

            builder.Property(x => x.Description)
                   .HasColumnName(ProductDataBaseInfo.Description);

            builder.Property(x => x.CreatedAt)
                   .HasColumnName(ProductDataBaseInfo.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .ValueGeneratedOnAdd();
        }
    }
}
