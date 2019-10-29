using System.Collections.Generic;

namespace MCB.Business.Models.Trips
{
    public class TripWithStopsModel : TripModel
    {
        public List<StopModel> Stops { get; set; } = new List<StopModel>();
    }
}
