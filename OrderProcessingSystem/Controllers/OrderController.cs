using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Business;
using OrderProcessingSystem.DTO;

namespace OrderProcessingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isOrderPlaced = await _orderService.PlaceOrder(orderRequest);
            if (!isOrderPlaced)
                return BadRequest("Failed to place the order");

            return Ok("Order placed successfully");
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("GetOrderDetail/{orderId}")]
        public async Task<IActionResult> GetOrderDetail(int orderId)
        {
            var orderDetail = await _orderService.GetOrderDetail(orderId);
            if (orderDetail == null)
                return NotFound();

            return Ok(orderDetail);
        }
    }
}
