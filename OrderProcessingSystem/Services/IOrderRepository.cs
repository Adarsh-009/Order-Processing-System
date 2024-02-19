using OrderProcessingSystem.DTO;

namespace OrderProcessingSystem.Services
{
    public interface IOrderRepository
    {
        public Task<bool> PlaceOrder(OrderDto order);
        public Task<IEnumerable<OrderDto>> GetOrders();
        public Task<OrderDto> GetOrderDetail(int orderId);
    }
}
