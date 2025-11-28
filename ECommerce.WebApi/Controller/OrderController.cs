using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost()]
        public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
        {
            var response = await _orderService.AddAsync(orderCreateDto);
            if (response.Status)
                return StatusCode(201, response);
            return NotFound(response);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var response = await _orderService.GetHistoryByUserAsync(userId);
            if (response.Status)
                return StatusCode(200, response);
            return NotFound(response);
        }
        
        
    }
}
