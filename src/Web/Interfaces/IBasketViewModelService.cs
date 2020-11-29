using System.Threading.Tasks;
using MaryShoppins.Web.Pages.Basket;

namespace MaryShoppins.Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    }
}
