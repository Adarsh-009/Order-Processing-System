using OrderProcessingSystem.DTO;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem.Business
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> PlaceOrder(OrderDto order)
        {
            return await _orderRepository.PlaceOrder(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
          
            return await _orderRepository.GetOrders();
        }

        public async Task<OrderDto> GetOrderDetail(int orderId)
        {
            return await _orderRepository.GetOrderDetail(orderId);
        }
    }
}
