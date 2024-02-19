using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OrderProcessingSystem.DTO;
using AutoMapper;
using OrderProcessingSystem.Models;
namespace OrderProcessingSystem.Services

{
    public class OrderProcessing : IOrderRepository 
    {
        private readonly OrderDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderProcessing(OrderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrderDto> GetOrderDetail(int orderId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentException("Invalid orderId", nameof(orderId));
            }

            var order = await _dbContext.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return null;
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }


        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            List<Models.Order> orders = await _dbContext.Orders
                .Include(o => o.OrderProducts)
                .ToListAsync();
            var orderDTOs = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return orderDTOs;
        }

        public async Task<bool> PlaceOrder(OrderDto order)
        {
            try
            {
                var orderEntity = _mapper.Map<Models.Order>(order);
                _dbContext.Orders.Add(orderEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error placing order: {ex}");
                return false;
            }
        }
    }
}
