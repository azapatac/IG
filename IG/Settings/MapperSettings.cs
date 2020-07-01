namespace IG
{
    using AutoMapper;
    
    using Prism.Ioc;

    public static class MapperSettings
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration((config) =>
            {
                config.AddProfile(new CountriesProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            containerRegistry.RegisterInstance(typeof(IMapper), mapper);
        }
    }
}