using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using BarcodeSample.Infrastructure;

namespace BarcodeSample.Android
{
    [Activity(Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public partial class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public override Resources Resources
        {
            get
            {
                var config = new global::Android.Content.Res.Configuration();
                config.SetToDefaults();

                return this.CreateConfigurationContext(config)?.Resources;
            }
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            GoogleVisionBarCodeScanner.Droid.RendererInitializer.Init();
            Rg.Plugins.Popup.Popup.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            AppInitializer.SetPlatformConfigurator(new AndroidInitializer());
            this.LoadApplication(new App(AppInitializer.GetPlatformConfigurator()));
        }
    }
}