using Prism;

namespace BarcodeSample.Configuration
{
    public interface IPlatformConfigurator : IPlatformInitializer
    {
        void ConfigureLogger();
    }
}