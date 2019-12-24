using AutoMapper;

namespace MCB.Api.Profiles
{
    public class AviationProfile : Profile
    {
        public AviationProfile()
        {
            CreateMap<Data.Domain.Aviation.Airport, Business.Models.Aviation.AirportModel>();
        }       
    }
}
