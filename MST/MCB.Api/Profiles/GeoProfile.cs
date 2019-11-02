using AutoMapper;

namespace MCB.Api.Profiles
{
    public class GeoProfile : Profile
    {
        public GeoProfile()
        {
            CreateMap<Data.Domain.Geo.Country, Business.Models.Geo.CountryModelWithAssesments>();
            CreateMap<Data.Domain.Geo.Country, Business.Models.Geo.CountryModel>();

            CreateMap<Data.Domain.Geo.Region, Business.Models.Geo.RegionModel>();
            CreateMap<Data.Domain.Geo.Region, Business.Models.Geo.RegionWithCountryModel>();

            CreateMap<Data.Domain.Geo.Continent, Business.Models.Geo.ContinentModel>();
            CreateMap<Data.Domain.Geo.Continent, Business.Models.Geo.ContinentWithRegionsModel>();
            CreateMap<Data.Domain.Geo.Continent, Business.Models.Geo.ContinentWithRegionsAndCountriesModel>();
        }
    }
}
