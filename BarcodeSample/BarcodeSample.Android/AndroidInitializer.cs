using BarcodeSample.Configuration;
using Prism.Ioc;

namespace BarcodeSample.Android
{
    internal class AndroidInitializer : IPlatformConfigurator
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }

        public void ConfigureLogger()
        {
            // Do something with logging
        }
    }
}