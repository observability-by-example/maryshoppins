using System.Threading.Tasks;
using MaryShoppins.ApplicationCore.Entities.OrderAggregate;

namespace MaryShoppins.ApplicationCore.Interfaces
{

    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
