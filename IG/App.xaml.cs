namespace IG
{
    using IG.Common;
    using Prism;
    using Prism.Ioc;

    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(NavigationRoutes.Main);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            MapperSettings.Register(containerRegistry);
            PagesContainer.Register(containerRegistry);
            ServicesContainer.Register(containerRegistry);
        }
    }
}