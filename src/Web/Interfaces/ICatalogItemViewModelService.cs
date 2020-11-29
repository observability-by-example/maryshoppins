using System.Threading.Tasks;
using MaryShoppins.Web.ViewModels;

namespace MaryShoppins.Web.Interfaces
{
    public interface ICatalogItemViewModelService
    {
        Task UpdateCatalogItem(CatalogItemViewModel viewModel);
    }
}
