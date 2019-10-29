using MCB.Data.Domain.Trips;

namespace MCB.Data.Domain.User
{
    public class UserTrip
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public string TUserId { get; set; }
        public TUser TUser { get; set; }
    }
}