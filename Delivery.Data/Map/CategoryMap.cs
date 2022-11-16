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
    internal static class CategoryDataBaseInfo 
    {
        internal static string Table = "tb_products_categories";
        internal static string Id = "id";
        internal static string Name = "name";
        internal static string Description = "description";
        internal static string CreatedAt = "created_at";
    }

    public class CategoryMap
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            builder.ToTable(CategoryDataBaseInfo.Table);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName(CategoryDataBaseInfo.Id);

            builder.Property(x => x.Name)
                   .HasColumnName(CategoryDataBaseInfo.Name);

            builder.Property(x => x.Description)
                   .HasColumnName(CategoryDataBaseInfo.Description);

            builder.Property(x => x.CreatedAt)
                   .HasColumnName(CategoryDataBaseInfo.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .ValueGeneratedOnAdd();

            builder.HasMany<SubCategory>()
                   .WithOne(x => x.Category)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey(x => x.CategoryId);
        }
    }
}
