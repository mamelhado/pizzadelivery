using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces.Repositories;
using Delivery.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Delivery.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base( productRepository)
        {
            _productRepository = productRepository;
        }

        
    }
}