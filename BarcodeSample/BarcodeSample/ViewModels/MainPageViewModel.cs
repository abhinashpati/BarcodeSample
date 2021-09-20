using System;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using INavigationService = BarcodeSample.Services.INavigationService;

namespace BarcodeSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public AsyncCommand ScanRouteCommand => new AsyncCommand(async () => await this.navigationService.NavigateToModalAsync("ScanningPage"));

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            try
            {
                if (!parameters.TryGetValue<string>(ScanningPageViewModel.BarcodeScanResult, out var routeBarcode))
                {
                    return;
                }

                if (!long.TryParse(routeBarcode, out var parsedRouteId))
                {
                    return;
                }

                await this.navigationService.NavigateToMainTabbedPageAsync("PhotoPage");
            }
            catch (Exception)
            {
                // Show Error Dialog
            }
        }
    }
}