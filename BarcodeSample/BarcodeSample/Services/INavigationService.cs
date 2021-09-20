using System.Threading.Tasks;
using Prism.Navigation;

namespace BarcodeSample.Services
{
    public interface INavigationService : Prism.Navigation.INavigationService
    {
        Task<INavigationResult> NavigateToModalAsync(string name);

        Task<INavigationResult> NavigateToModalAsync(string name, INavigationParameters parameters);

        Task<INavigationResult> NavigateToMainTabbedPageAsync(string name);

        Task<INavigationResult> NavigateToMainTabbedPageAsync(string name, INavigationParameters parameters);

        Task<INavigationResult> PopModalAsync();

        Task<INavigationResult> PopModalAsync(INavigationParameters parameters);
    }
}