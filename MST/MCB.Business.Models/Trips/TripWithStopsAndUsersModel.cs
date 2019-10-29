using MCB.Business.Models.Users;
using System.Collections.Generic;

namespace MCB.Business.Models.Trips
{
    public class TripWithStopsAndUsersModel : TripWithStopsModel
    {
        public List<TUserModel> Users { get; set; } = new List<TUserModel>();
    }
}
