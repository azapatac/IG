namespace IG.Common
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICountriesService
    {
        Task<IList<Country>> GetAll();
        Task<IList<Country>> GetByName(string name);
    }
}