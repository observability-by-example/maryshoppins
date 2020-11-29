using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Ardalis.Specification;
using MaryShoppins.ApplicationCore.Entities.OrderAggregate;
using MaryShoppins.ApplicationCore.Interfaces;

namespace MaryShoppins.Infrastructure.Data
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(CatalogContext dbContext) : base(dbContext)
        {
        }

        public Task<Order> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Orders
                .Include(o => o.OrderItems)
                .Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
