using AutoMapper;
using Delivery.Api.Models;
using Delivery.Api.Models.Enum;
using Delivery.Domain.Entities;
using Delivery.Domain.Entities.Enum;

namespace Delivery.Api.Mapper
{
    public static class ConfigureAutoMapperExtension
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

            /*config.CreateMap<PaymentMethod, PaymentMethodModel>()
                .ForMember(m => m, n => n.MapFrom(m => m))
                .ReverseMap();*/

            config.CreateMap<OrderItem, OrderItemModel>()
                .ForMember(m => m.Id, n => n.MapFrom(m => m.Id))
                .ForMember(m => m.Quantity, n => n.MapFrom(m => m.Quantity))
                .ForMember(m => m.Item, n => n.MapFrom(m => m.Item))
                .ForMember(m => m.Comments, n => n.MapFrom(m => m.Comments))
                .ReverseMap();

            config.CreateMap<Order, OrderInsertModel>()
                .ForMember(m => m.Id, n => n.MapFrom(m => m.Id))
                .ForMember(m => m.PaymentMethod, n => n.MapFrom(m => m.PaymentMethod))
                .ForMember(m => m.Responsible, n => n.MapFrom(m => m.Responsible))
                .ForMember(m => m.Address, n => n.MapFrom(m => m.Address))
                .ForMember(m => m.CreatedAt, n => n.MapFrom(m => m.CreatedAt))
                .ForMember(m => m.Itens, n => n.MapFrom(m => m.Itens))
                .ReverseMap();

            config.CreateMap<Order, OrderUpdateModel>()
                .ForMember(m => m.Id, n => n.MapFrom(m => m.Id))
                .ForMember(m => m.PaymentMethod, n => n.MapFrom(m => m.PaymentMethod))
                .ForMember(m => m.Responsible, n => n.MapFrom(m => m.Responsible))
                .ForMember(m => m.Address, n => n.MapFrom(m => m.Address))
                .ForMember(m => m.CreatedAt, n => n.MapFrom(m => m.CreatedAt))
                .ForMember(m => m.Itens, n => n.MapFrom(m => m.Itens))
                .ReverseMap();

        }
    }
}
