using MVCproject.Models;

namespace MVCproject.Repository
{
    public interface IOrderRepository:ITRepository<Order>
    {
        
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
