namespace IG.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IG.Common;
    using Refit;

    public interface IWSCountriesService
    {
        [Get("/all")]
        Task<IList<Country>> GetCountries([Header("X-RapidAPI-Key")]string apiKey);

        [Get("/name/{name}")]
        Task<IList<Country>> GetCountryByName(string name, [Header("X-RapidAPI-Key")] string apiKey);
    }

    public class CountriesService : ICountriesService
    {
        public async Task<IList<Country>> GetAll()
        {
            var countriesService = RestService.For<IWSCountriesService>(WebServices.HostUrl);
            var response = await countriesService.GetCountries(WebServices.ApiKey);

            return response;
        }

        public async Task<IList<Country>> GetByName(string name)
        {
            var countriesService = RestService.For<IWSCountriesService>(WebServices.HostUrl);
            var response = await countriesService.GetCountryByName(name, WebServices.ApiKey);

            return response;
        }
    }
}