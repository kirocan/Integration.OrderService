using Integration.OrderService.Data;
using Integration.OrderService.Data.Models;
using Integration.OrderService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Integration.OrderService.Repositories.Impl
{
    /// <inheritdoc />
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Order> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        /// <inheritdoc />
        public async Task<Order?> GetByOrderIdAsync(Guid orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        /// <inheritdoc />
        public async Task<Order> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
