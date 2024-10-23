using Microsoft.EntityFrameworkCore;
using MVCproject.config;
using MVCproject.Models;

namespace MVCproject.Repository
{
    public class OrderRepository : TRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await context.Orders.Include(o => o.OrderItems)
                                        .ThenInclude(oi => oi.Product)
                                        .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await context.Orders.Where(o => o.UserId == userId)
                                        .Include(o => o.OrderItems)
                                        .ThenInclude(oi => oi.Product)
                                        .ToListAsync();
        }
    }
}
