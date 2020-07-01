namespace IG
{
    using System.Threading.Tasks;
    using IG.Common;

    public class MainPageViewModel
    {
        readonly ICountriesService countriesService;

        public MainPageViewModel(ICountriesService countriesService)
        {
            this.countriesService = countriesService;
        }

        private async Task LoadCountries()
        {
            var response = await countriesService.GetAll();
        }
    }
}