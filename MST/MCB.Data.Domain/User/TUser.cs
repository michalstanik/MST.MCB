using System.Collections.Generic;

namespace MCB.Data.Domain.User
{
    public class TUser
    {
        public TUser()
        {
            UserTrips = new List<UserTrip>();
            UserFlights = new List<UserFlight>();
            UserCountries = new List<UserCountry>();
        }
        public string Id { get; set; }

        public string UserName { get; set; }

        public List<UserTrip> UserTrips { get; set; }
        public List<UserFlight> UserFlights { get; set; }
        public List<UserCountry> UserCountries { get; set; }
    }
}
