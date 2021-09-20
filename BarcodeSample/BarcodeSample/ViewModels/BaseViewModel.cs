using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace BarcodeSample.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
    {
        private string title;

        protected BaseViewModel()
        {
        }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        /// <summary>
        /// This method is invoked by prism when a ViewModel is loaded.
        /// </summary>
        public async void Initialize(INavigationParameters parameters)
        {
            await this.OnInitialized(parameters);
        }

        /// <summary>
        /// Async version of the <see cref="Initialize"/> that can be overridden.
        /// </summary>
        public virtual Task OnInitialized(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// This method is invoked by prism when a ViewModel is loaded.
        /// </summary>
        public async void OnNavigatedFrom(INavigationParameters parameters)
        {
            await this.OnNavigatedFromAsync(parameters);
        }

        /// <summary>
        /// Async version of the <see cref="OnNavigatedFrom"/> that can be overridden.
        /// </summary>
        public virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await this.OnNavigatedToAsync(parameters);
        }

        /// <summary>
        /// Async version of the <see cref="OnNavigatedTo"/> that can be overridden.
        /// </summary>
        public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void Destroy()
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }
}
