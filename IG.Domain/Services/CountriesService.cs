namespace IG.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IG.Common;
    using Refit;

    public interface IWSCountriesService
    {
        [Get("/all")]
        Task<IList<Country>> GetData([Header("X-RapidAPI-Key")]string apiKey);
    }

    public class CountriesService : ICountriesService
    {
        public async Task<IList<Country>> GetAll()
        {
            var countriesService = RestService.For<IWSCountriesService>(WebServices.HostUrl);
            var response = await countriesService.GetData(WebServices.ApiKey);

            return response;
        }
    }
}