using MCB.Data.Domain.Geo;

namespace MCB.Data.Domain.User
{
    public class UserCountry
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string TUserId { get; set; }
        public TUser TUser { get; set; }

        public long AreaLevelAssessment { get; set; }
        public CountryVisitType CountryKnowledgeType { get; set; }

        public enum CountryVisitType
        {
            BussinessTrip,
            JustVisit,
            Transfer,
            RealTrip
        }
    }
}