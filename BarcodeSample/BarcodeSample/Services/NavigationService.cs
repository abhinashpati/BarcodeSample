using System.Threading.Tasks;
using Prism.Behaviors;
using Prism.Common;
using Prism.Ioc;
using Prism.Logging;
using Prism.Navigation;
using Prism.Plugin.Popups;
using Rg.Plugins.Popup.Contracts;

namespace BarcodeSample.Services
{
    internal class NavigationService : PopupPageNavigationService, INavigationService
    {
        public NavigationService(IPopupNavigation popupNavigation, IContainerExtension container, IApplicationProvider applicationProvider, IPageBehaviorFactory pageBehaviorFactory, ILoggerFacade logger)
            : base(popupNavigation, container, applicationProvider, pageBehaviorFactory, logger)
        {
        }

        public Task<INavigationResult> NavigateToModalAsync(string name)
        {
            return this.NavigateToModalAsync(name, null);
        }

        public async Task<INavigationResult> NavigateToModalAsync(string name, INavigationParameters parameters)
        {
            return await this.NavigateAsync(name, parameters, useModalNavigation: true);
        }

        public Task<INavigationResult> PopModalAsync()
        {
            return this.PopModalAsync(null);
        }

        public async Task<INavigationResult> PopModalAsync(INavigationParameters parameters)
        {
            return await this.GoBackAsync(parameters, useModalNavigation: true);
        }

        public Task<INavigationResult> NavigateToMainTabbedPageAsync(string name)
        {
            return this.NavigateToMainTabbedPageAsync(name, null);
        }

        public async Task<INavigationResult> NavigateToMainTabbedPageAsync(string name, INavigationParameters parameters)
        {
            return await this.NavigateAsync($"/MainTabbedPage?selectedTab={name}", parameters);
        }
    }
}