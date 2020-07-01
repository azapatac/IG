namespace IG
{
    using IG.Common;
    using IG.Domain;
    using Prism.Ioc;

    public static class ServicesContainer
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICountriesService, CountriesService>();
        }
    }
}