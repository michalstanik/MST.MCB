using AutoMapper;

namespace MCB.Api.Profiles
{
    public class FlightsProfile : Profile
    {
        public FlightsProfile()
        {
            CreateMap<Data.Domain.Flights.Flight, Business.Models.Flights.FlightModel>();
            CreateMap<Data.Domain.Flights.Flight, Business.Models.Flights.FlightModelFull>();
        }
    }
}
