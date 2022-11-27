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
    public class OrderController : BaseController<Order, ProductInsertModel, ProductInsertModel, ProductUpdateModel>
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IMapper mapper) : base(logger, orderService, mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }



    }
}
