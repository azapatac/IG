namespace IG
{
    using AutoMapper;
    using IG.Common;

    public class CountriesProfile : Profile
    {
        public CountriesProfile()
        {
            CreateMap<Country, CountryViewModel>().ReverseMap();
        }
    }
}