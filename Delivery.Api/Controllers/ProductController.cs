using AutoMapper;
using Delivery.Api.Models;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product, ProductInsertModel, ProductInsertModel, ProductUpdateModel>
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, ILogger<ProductController> logger, IMapper mapper) : base(logger, productService, mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }



    }
}
