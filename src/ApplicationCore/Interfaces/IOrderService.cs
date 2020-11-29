using System.Threading.Tasks;
using MaryShoppins.ApplicationCore.Entities.OrderAggregate;

namespace MaryShoppins.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}
