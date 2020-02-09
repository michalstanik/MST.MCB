using AutoMapper;

namespace MCB.Api.Profiles
{
    public class AviationProfile : Profile
    {
        public AviationProfile()
        {
            CreateMap<Data.Domain.Aviation.Airport, Business.Models.Aviation.AirportModel>();
            CreateMap<Data.Domain.Aviation.Aircraft, Business.Models.Aviation.AircraftBusinessModel>();
            CreateMap<Data.Domain.Aviation.AircraftFactory, Business.Models.Aviation.AircraftFactoryModel>();
            CreateMap<Data.Domain.Aviation.AircraftModel, Business.Models.Aviation.AircraftModelBusinessModel>();
            CreateMap<Data.Domain.Aviation.Airline, Business.Models.Aviation.AirlineModel>();
        }
    }
}
