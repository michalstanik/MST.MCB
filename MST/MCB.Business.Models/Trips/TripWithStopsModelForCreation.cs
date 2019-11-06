using MCB.Business.Models.Stops;
using System.Collections.Generic;

namespace MCB.Business.Models.Trips
{
    public class TripWithStopsModelForCreation : TripModelForCreation
    {
        public ICollection<StopModelForCreation> Stops { get; set; } 
            = new List<StopModelForCreation>();
    }
}
