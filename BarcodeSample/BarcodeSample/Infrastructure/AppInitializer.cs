using System;
using BarcodeSample.Configuration;

namespace BarcodeSample.Infrastructure
{
    public static class AppInitializer
    {
        private static IPlatformConfigurator platformConfigurator;

        public static IPlatformConfigurator GetPlatformConfigurator() => platformConfigurator ?? throw new InvalidOperationException();

        public static void SetPlatformConfigurator(IPlatformConfigurator platformConfigurator)
        {
            if (AppInitializer.platformConfigurator != null)
            {
                throw new InvalidOperationException();
            }

            AppInitializer.platformConfigurator = platformConfigurator;
        }
    }
}