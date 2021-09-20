using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using INavigationService = BarcodeSample.Services.INavigationService;

namespace BarcodeSample.ViewModels
{
    public class ScanningPageViewModel : BaseViewModel
    {
        public const string BarcodeScanResult = nameof(BarcodeScanResult);

        private readonly INavigationService navigationService;
        private readonly IMainThread mainThreadService;

        private bool isAnalyzing;
        private bool isTorchOn;
        private bool showScanErrorMessage;

        public ScanningPageViewModel(
            INavigationService navigationService,
            IMainThread mainThreadService)
        {
            this.navigationService = navigationService;
            this.mainThreadService = mainThreadService;
        }

        public string Result { get; set; }

        public bool IsTorchOn
        {
            get => this.isTorchOn;
            set => this.SetProperty(ref this.isTorchOn, value);
        }

        public bool IsAnalyzing
        {
            get => this.isAnalyzing;
            set => this.SetProperty(ref this.isAnalyzing, value);
        }

        public bool ShowScanErrorMessage
        {
            get => this.showScanErrorMessage;
            set => this.SetProperty(ref this.showScanErrorMessage, value);
        }

        public IAsyncCommand ScanCompletedCommand => new AsyncCommand(this.OnScanCompleted);

        public ICommand FlashCommand => new Command(this.SwitchFlash);

        public IAsyncCommand GoToPhotoPageCommand => new AsyncCommand(this.GoToPhotoPage);

        public IAsyncCommand CloseBarcodeScanningPage => new AsyncCommand(this.navigationService.GoBackAsync);

        public override void OnAppearing()
        {
            // Starting the scanning as soon as the page is displayed
            this.IsAnalyzing = true;
        }

        public override void OnDisappearing()
        {
            // Stopping the scanning as soon as the page is about to disappear
            this.IsAnalyzing = false;
        }

        private void SwitchFlash()
        {
            this.IsTorchOn = !this.IsTorchOn;
        }

        private async Task GoToPhotoPage()
        {
            await this.navigationService.NavigateToModalAsync("PhotoPage");
        }

        private async Task OnScanCompleted()
        {
            // We need to stop scanning immediately to avoid triggering another result
            this.IsAnalyzing = false;

            // Reset error from previous attempt
            this.ShowScanErrorMessage = false;

            if (string.IsNullOrWhiteSpace(this.Result))
            {
                this.ShowScanErrorMessage = true;

                // Continue trying to scan a barcode
                this.IsAnalyzing = true;
                return;
            }


            // This is done because the NavigateAsync doesn't work without being Invoked from the main thread.
            // This is only applicable when using along with ZXing Library properties
            await this.mainThreadService.InvokeOnMainThreadAsync(async () =>
            {
                var barcode = new NavigationParameters { { BarcodeScanResult, this.Result } };
                await this.navigationService.NavigateToMainTabbedPageAsync("MainPage", barcode);
            });
        }
    }
}