namespace IG
{
    using Prism.Ioc;

    public static class PagesContainer
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();            
        }
    }
}