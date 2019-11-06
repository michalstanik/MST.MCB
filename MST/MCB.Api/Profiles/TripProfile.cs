using AutoMapper;

namespace MCB.Api.Profiles
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            //Trips D-B
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripFullModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithStopsModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithStopsAndUsersModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithCountriesModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithCountriesAndStatsModel>();
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithCountriesAndWorldHeritagesModel>();
            //Trips B-D
            CreateMap<Business.Models.Trips.TripModelForCreation, Data.Domain.Trips.Trip>();
            CreateMap<Business.Models.Trips.TripWithStopsModelForCreation, Data.Domain.Trips.Trip>();
            //Stops D-B
            CreateMap<Data.Domain.Trips.Stop, Business.Models.Stops.StopModel>();
            //Stops B-D
            CreateMap<Business.Models.Stops.StopModelForCreation, Data.Domain.Trips.Stop>();
            //User D-B
            CreateMap<Data.Domain.User.TUser, Business.Models.Users.TUserModel>();
            //Country D-B
            CreateMap<Data.Domain.Geo.Country, Business.Models.Geo.CountryModel>();
            //WorldHeritage D-B
            CreateMap<Data.Domain.WorldHeritages.WorldHeritage, Business.Models.WorldHeritages.WorldHeritageModel>();
        }
    }
}
