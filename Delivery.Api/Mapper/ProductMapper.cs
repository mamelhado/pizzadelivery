using AutoMapper;
using Delivery.Api.Models;
using Delivery.Domain.Entities;

namespace Delivery.Api.Mapper
{
    public static class ProductMapper
    {
        public static void ConfigureAutoMapper(this IMapperConfigurationExpression config) 
        {
            config.CreateMap<ProductInsertModel, Product>()
                .AfterMap((model, entity) => 
                {
                    entity.CreatedAt = model.CreatedAt ?? DateTime.Now;
                    entity.Description = model.Description;
                    entity.Name = model.Name;
                });

            config.CreateMap<Product, ProductInsertModel>()
                .AfterMap((entity, model) =>
                {
                    model.CreatedAt = entity.CreatedAt;
                    model.Description = entity.Description;
                    model.Name = entity.Name;
                    model.Id = entity.Id;
                });

            config.CreateMap<ProductUpdateModel, Product>()
                .AfterMap((model, entity) =>
                {
                    model.Id = entity.Id;
                    model.Description = entity.Description;
                    model.Name = entity.Name;
                });
        }
    }
}
