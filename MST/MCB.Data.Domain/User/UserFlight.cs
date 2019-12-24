using MCB.Data.Domain.Flights;

namespace MCB.Data.Domain.User
{
    public class UserFlight
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public string TUserId { get; set; }
        public TUser TUser { get; set; }
    }
}
