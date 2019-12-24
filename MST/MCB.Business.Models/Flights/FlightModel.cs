using MCB.Business.Models.Aviation;
using MCB.Business.Models.Trips;

namespace MCB.Business.Models.Flights
{
    public class FlightModel : FlightAbstractBase
    {
        public int Id { get; set; }

        public AirportModel DepartureAirport { get; set; }

        public AirportModel ArrivalAirport { get; set; }

        public TripModel Trip { get; set; }
    }
}
