using System.Collections.Generic;

namespace MCB.Data.Domain.User
{
    public class TUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public List<UserTrip> UserTrips { get; set; }
        public List<UserCountry> UserCountries { get; set; }
    }
}
