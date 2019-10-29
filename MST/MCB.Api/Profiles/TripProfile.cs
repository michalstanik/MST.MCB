using AutoMapper;

namespace MCB.Api.Profiles
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripFullModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithStopsModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithStopsAndUsersModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithCountriesModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithCountriesAndStatsModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithCountriesAndWorldHeritagesModel>();

            CreateMap<Data.Domain.Trips.Stop, Business.Models.Trips.StopModel>();

            CreateMap<Data.Domain.User.TUser, Business.Models.Users.TUserModel>();

            CreateMap<Data.Domain.Geo.Country, Business.Models.Geo.CountryModel>();

            CreateMap<Data.Domain.WorldHeritages.WorldHeritage, Business.Models.WorldHeritages.WorldHeritageModel>();
        }
    }
}
