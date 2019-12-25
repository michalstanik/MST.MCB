using AutoMapper;

namespace MCB.Api.Profiles
{
    public class GeoProfile : Profile
    {
        public GeoProfile()
        {
            //Countries
            CreateMap<Data.Domain.Geo.Country, Business.Models.Geo.CountryModelWithAssesments>();
            CreateMap<Data.Domain.Geo.Country, Business.Models.Geo.CountryModel>();

            //Regions
            CreateMap<Data.Domain.Geo.Region, Business.Models.Geo.RegionModel>();
            CreateMap<Data.Domain.Geo.Region, Business.Models.Geo.RegionModelWithStats>();
            CreateMap<Data.Domain.Geo.Region, Business.Models.Geo.RegionModelWithStatsAndCountry>();
            CreateMap<Data.Domain.Geo.Region, Business.Models.Geo.RegionModelWithCountriesAndUserVisits>();

            //Continents
            CreateMap<Data.Domain.Geo.Continent, Business.Models.Geo.ContinentModel>();
            CreateMap<Data.Domain.Geo.Continent, Business.Models.Geo.ContinentWithRegionsModel>();
            CreateMap<Data.Domain.Geo.Continent, Business.Models.Geo.ContinentWithRegionsAndCountriesModel>();
        }
    }
}
