using BarcodeSample.CustomControls;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace BarcodeSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : CustomTabbedPage
    {
        public MainTabbedPage()
        {
            this.InitializeComponent();
            this.On<Android>().SetIsSwipePagingEnabled(false);
        }
    }
}