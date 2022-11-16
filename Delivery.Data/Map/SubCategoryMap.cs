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
    internal static class SubCategoryDataBaseInfo 
    {
        internal static string Table = "tb_products_subcategories";
        internal static string Id = "id";
        internal static string Name = "name";
        internal static string Description = "description";
        internal static string CategoryId = "category_id";
        internal static string CreatedAt = "created_at";
    }

    public class SubCategoryMap
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder) 
        {
            builder.ToTable(SubCategoryDataBaseInfo.Table);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName(SubCategoryDataBaseInfo.Id);

            builder.Property(x => x.Name)
                   .HasColumnName(SubCategoryDataBaseInfo.Name);

            builder.Property(x => x.Description)
                   .HasColumnName(SubCategoryDataBaseInfo.Description);

            builder.Property(x => x.CategoryId)
                   .HasColumnName(SubCategoryDataBaseInfo.CategoryId);

            builder.Property(x => x.CreatedAt)
                   .HasColumnName(SubCategoryDataBaseInfo.CreatedAt)
                   .HasDefaultValue(DateTime.UtcNow)
                   .ValueGeneratedOnAdd();

            
        }
    }
}
