using BarcodeSample.Configuration;
using BarcodeSample.Services;
using BarcodeSample.ViewModels;
using BarcodeSample.Views;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace BarcodeSample
{
    public partial class App
    {
        public App(IPlatformConfigurator platformConfigurator)
            : base(platformConfigurator)
        {
            this.InitializeComponent();

            Application.Current.UserAppTheme = Application.Current.RequestedTheme;

            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                Application.Current.UserAppTheme = a.RequestedTheme;
            };
        }

        protected override async void OnInitialized()
        {
            await this.Container.Resolve<INavigationService>().NavigateToMainTabbedPageAsync("MainPage");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Application services
            containerRegistry.RegisterSingleton<INavigationService, NavigationService>();
            
            containerRegistry.RegisterPopupNavigationService<NavigationService>();

            // Additionally, we allow Prism Dialog Service to use the pop up library so rendering on top of navigation bars like tabs works propertly.
            containerRegistry.RegisterPopupDialogService();
            
            // Xamarin Essentials
            containerRegistry.RegisterSingleton<IMainThread, MainThreadImplementation>();
            containerRegistry.RegisterSingleton<IMediaPicker, MediaPickerImplementation>();

            containerRegistry.RegisterForNavigation<MainTabbedPage, MainTabbedPageViewModel>("MainTabbedPage");
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>("MainPage");
            containerRegistry.RegisterForNavigation<ScanningPage, ScanningPageViewModel>("ScanningPage");
            containerRegistry.RegisterForNavigation<PhotoPage, PhotoPageViewModel>("PhotoPage");
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
